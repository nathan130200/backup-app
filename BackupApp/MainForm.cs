using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace BackupApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        static void ShowFolderBrowser(Form owner, TextBox outTextBox)
        {
            try
            {
                owner.Enabled = false;

                using var dlg = new FolderBrowserDialog
                {
                    AutoUpgradeEnabled = true,
                    AddToRecent = true,
                    RootFolder = Environment.SpecialFolder.MyComputer,
                    ShowHiddenFiles = true,
                    ShowNewFolderButton = true,
                    ShowPinnedPlaces = true
                };

                if (dlg.ShowDialog(owner) != DialogResult.OK)
                    return;

                outTextBox.Text = dlg.SelectedPath;
            }
            finally
            {
                owner.Enabled = true;
            }
        }

        private void BtnOpenSrcPath_Click(object sender, EventArgs e)
            => ShowFolderBrowser(this, txtSrcPath);

        private void BtnOpenDestPath_Click(object sender, EventArgs e)
            => ShowFolderBrowser(this, txtDestPath);

        private void CkbUseFilters_CheckedChanged(object sender, EventArgs e)
            => txtFilters.Enabled = ckbUseFilters.Checked;

        DialogResult MsgBox(string msg, string title = "Erro", MessageBoxButtons btn = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Error)
            => MessageBox.Show(this, msg, title, btn, icon);

        void SetUILocked(bool isLocked)
        {
            ckbCreateDestIfNotExist.Enabled
                = ckbIncludeSubdirs.Enabled
                = ckbUseFilters.Enabled
                = ckbVerifyHash.Enabled
                = btnOpenSrcPath.Enabled
                = btnOpenDestPath.Enabled
                = !isLocked;

            txtSrcPath.ReadOnly
                = txtDestPath.ReadOnly
                = isLocked;
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtSrcPath.Text))
            {
                MsgBox("Pasta de origem não existe ou inválida!", icon: MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(txtDestPath.Text))
            {
                if (!ckbCreateDestIfNotExist.Checked)
                {
                    MsgBox("Pasta de destino não existe ou inválida!");
                    return;
                }

                try
                {
                    Directory.CreateDirectory(txtDestPath.Text);
                }
                catch (Exception ex)
                {
                    MsgBox(ex.ToString(), icon: MessageBoxIcon.Error);
                }
            }

            SetUILocked(true);
            btnProcess.Text = "Cancelar";
            btnProcess.Click -= BtnProcess_Click;
            btnProcess.Click += BtnInterrupt_Click;

            _sourceDir = Path.GetFullPath(txtSrcPath.Text);
            _targetDir = Path.GetFullPath(txtDestPath.Text);

            Thread.Sleep(100);
            btnProcess.Enabled = true;

            _ = Task.Run(async () =>
            {
                _running = true;

                lbStatus.Text = "Status: Indexando";
                lbStatus.ForeColor = Color.Blue;

                ScanFiles();

                await Task.Delay(500);

                lbStatus.Text = "Status: Copiando";
                lbStatus.ForeColor = Color.Orange;

                await CopyFiles();

                await Task.Delay(500);

                lbStatus.Text = "Status: Finalizando";
                lbStatus.ForeColor = Color.LimeGreen;

                await Task.Delay(500);

                lbStatus.Text = "Status: Inativo";
                lbStatus.ForeColor = Color.Black;

                if (_running)
                {
                    btnProcess.PerformClick();
                    _running = false;
                }
            });
        }

        string _sourceDir;
        string _targetDir;

        void BtnInterrupt_Click(object sender, EventArgs e)
        {
            SetUILocked(false);
            _files.Clear();
            lbInfo.Text = string.Empty;
            btnProcess.Text = "Iniciar";
            btnProcess.Enabled = false;
            btnProcess.Click += BtnProcess_Click;
            btnProcess.Click -= BtnInterrupt_Click;
            Thread.Sleep(100);
            _running = false;
            btnProcess.Enabled = true;
        }

        private ConcurrentQueue<string> _files = new();
        private volatile bool _running = false;

        static bool TryMatch(string input, string pattern)
        {
            try { return Regex.IsMatch(input, pattern); }
            catch { return false; }
        }

        #region Copy files

        async Task CopyFiles()
        {
            bool verifyArchive = ckbVerifyHash.Checked;

            if (_files.Count < 1)
                return;

            var buffer = new byte[ushort.MaxValue];
            int len;

            var totalFiles = _files.Count;
            var currentFiles = 0;

            while (_files.TryDequeue(out var srcFile))
            {
                Invoke(() => pbTotal.Value = ((int)((currentFiles / (float)totalFiles) * 100f)));

                var destFile = srcFile.Replace(_sourceDir, string.Empty);

                if (destFile.StartsWith("\\"))
                    destFile = destFile[1..];

                var srcFileInfo = new FileInfo(srcFile);
                var destFileInfo = new FileInfo(Path.Combine(_targetDir, destFile));

                if (!destFileInfo.Directory.Exists)
                {
                    destFileInfo.Directory.Create();
                    destFileInfo.Refresh();
                    destFileInfo.Directory.Attributes = srcFileInfo.Directory.Attributes;
                    destFileInfo.Directory.CreationTimeUtc = srcFileInfo.Directory.CreationTimeUtc;
                    destFileInfo.Directory.LastAccessTimeUtc = srcFileInfo.Directory.LastAccessTimeUtc;
                    destFileInfo.Directory.LastWriteTimeUtc = srcFileInfo.Directory.LastWriteTimeUtc;
                }

                using (var inputStream = new FileStream(srcFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (var outputStream = new FileStream(destFileInfo.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
                {
                    bool isSameLength = false;

                    if (verifyArchive)
                    {
                        if (outputStream.Length == inputStream.Length)
                        {
                            isSameLength = true;
                            goto _Check;
                        }
                    }

                _Copy:
                    {
                        outputStream.Position = inputStream.Position = 0;

                        long totalLength = inputStream.Length;

                        while ((len = await inputStream.ReadAsync(buffer)) > 0)
                        {
                            await outputStream.WriteAsync(buffer.AsMemory(0, len));
                            float ratio = (outputStream.Length / (float)totalLength) * 100f;

                            Invoke(() =>
                            {
                                pbCurrent.Value = (int)(ratio);
                                lbInfo.Text = $"Copiando arquivo ({ratio:F2}%): '{destFile}' ...";
                            });
                        }

                        await outputStream.FlushAsync();
                        isSameLength = true;
                        goto _Check;
                    }

                _Check:
                    {
                        if (!verifyArchive)
                            goto _Next;

                        await Task.Delay(16);

                        Invoke(() =>
                        {
                            pbCurrent.Style = ProgressBarStyle.Marquee;
                            lbInfo.Text = $"Verificando arquivo: '{destFile}' ...";
                        });

                        inputStream.Position = outputStream.Position = 0;

                        var tcs = new TaskCompletionSource<(bool match, string hash)>();

                        _ = Task.Run(async () =>
                        {
                            var expectedHash = await MD5.HashDataAsync(inputStream);
                            var currentHash = await MD5.HashDataAsync(outputStream);
                            tcs.TrySetResult((expectedHash.SequenceEqual(currentHash), Convert.ToHexString(expectedHash)));
                        });

                        var result = await tcs.Task;
                        Debug.WriteLine($"<Checksum> File {destFile} hash {(result.match ? "match" : "mismatch")}: {result.hash}");

                        if (!result.match)
                        {
                            if (!isSameLength)
                            {
                                await Task.Delay(16);
                                goto _Copy;
                            }
                        }

                        Invoke(() => pbCurrent.Style = ProgressBarStyle.Blocks);
                        goto _Next;
                    }
                }

            _Next:

                destFileInfo.Attributes = srcFileInfo.Attributes;
                destFileInfo.CreationTimeUtc = srcFileInfo.CreationTimeUtc;
                destFileInfo.LastAccessTimeUtc = srcFileInfo.LastAccessTimeUtc;
                destFileInfo.LastWriteTimeUtc = srcFileInfo.LastWriteTimeUtc;

                currentFiles++;
            }

            pbTotal.Value = ((int)((currentFiles / (float)totalFiles) * 100f));
            buffer = default;
        }

        #endregion

        #region Scan files

        void ScanFiles(string path = default)
        {
            path ??= _sourceDir;

            bool recursive = ckbIncludeSubdirs.Checked;

            if (!_running)
                return;

            Invoke(() => lbInfo.Text = $"Indexando pasta: '{path.Replace(_sourceDir, string.Empty)}' ...");

            try
            {
                foreach (var file in Directory.GetFiles(path))
                {
                    if (!ckbUseFilters.Checked)
                    {
                        _files.Enqueue(file);
                        continue;
                    }

                    foreach (var line in txtFilters.Lines)
                    {
                        if (TryMatch(file, line))
                        {
                            _files.Enqueue(file);
                            break;
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (Exception)
            {
                if (Debugger.IsAttached)
                    throw;
            }

            if (recursive)
            {
                try
                {
                    foreach (var subdir in Directory.GetDirectories(path))
                        ScanFiles(subdir);
                }
                catch (UnauthorizedAccessException) { }
                catch (Exception)
                {
                    if (Debugger.IsAttached)
                        throw;
                }
            }
        }

        #endregion
    }
}
