namespace BackupApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Controls.HorizontalSplitter horizontalSplitter1;
            Controls.HorizontalSplitter horizontalSplitter2;
            label1 = new Label();
            label2 = new Label();
            btnOpenSrcPath = new Button();
            btnOpenDestPath = new Button();
            txtSrcPath = new TextBox();
            txtDestPath = new TextBox();
            ckbIncludeSubdirs = new CheckBox();
            ckbUseFilters = new CheckBox();
            txtFilters = new TextBox();
            label3 = new Label();
            pbTotal = new ProgressBar();
            pbCurrent = new ProgressBar();
            label4 = new Label();
            lbInfo = new Label();
            btnProcess = new Button();
            lbStatus = new Label();
            ckbCreateDestIfNotExist = new CheckBox();
            ckbVerifyHash = new CheckBox();
            horizontalSplitter1 = new Controls.HorizontalSplitter();
            horizontalSplitter2 = new Controls.HorizontalSplitter();
            SuspendLayout();
            // 
            // horizontalSplitter1
            // 
            horizontalSplitter1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            horizontalSplitter1.BackColor = Color.Gray;
            horizontalSplitter1.BorderStyle = BorderStyle.Fixed3D;
            horizontalSplitter1.Enabled = false;
            horizontalSplitter1.Location = new Point(12, 196);
            horizontalSplitter1.MaximumSize = new Size(int.MaxValue, 1);
            horizontalSplitter1.MinimumSize = new Size(1, 1);
            horizontalSplitter1.Name = "horizontalSplitter1";
            horizontalSplitter1.Size = new Size(567, 1);
            horizontalSplitter1.TabIndex = 14;
            // 
            // horizontalSplitter2
            // 
            horizontalSplitter2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            horizontalSplitter2.BackColor = Color.Gray;
            horizontalSplitter2.BorderStyle = BorderStyle.Fixed3D;
            horizontalSplitter2.Enabled = false;
            horizontalSplitter2.Location = new Point(12, 290);
            horizontalSplitter2.MaximumSize = new Size(int.MaxValue, 1);
            horizontalSplitter2.MinimumSize = new Size(1, 1);
            horizontalSplitter2.Name = "horizontalSplitter2";
            horizontalSplitter2.Size = new Size(567, 1);
            horizontalSplitter2.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(88, 13);
            label1.TabIndex = 2;
            label1.Text = "Pasta de Origem:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 42);
            label2.Name = "label2";
            label2.Size = new Size(91, 13);
            label2.TabIndex = 3;
            label2.Text = "Pasta de Destino:";
            // 
            // btnOpenSrcPath
            // 
            btnOpenSrcPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenSrcPath.Location = new Point(554, 12);
            btnOpenSrcPath.Name = "btnOpenSrcPath";
            btnOpenSrcPath.Size = new Size(25, 20);
            btnOpenSrcPath.TabIndex = 4;
            btnOpenSrcPath.Text = "...";
            btnOpenSrcPath.UseVisualStyleBackColor = true;
            btnOpenSrcPath.Click += BtnOpenSrcPath_Click;
            // 
            // btnOpenDestPath
            // 
            btnOpenDestPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenDestPath.Location = new Point(554, 39);
            btnOpenDestPath.Name = "btnOpenDestPath";
            btnOpenDestPath.Size = new Size(25, 20);
            btnOpenDestPath.TabIndex = 5;
            btnOpenDestPath.Text = "...";
            btnOpenDestPath.UseVisualStyleBackColor = true;
            btnOpenDestPath.Click += BtnOpenDestPath_Click;
            // 
            // txtSrcPath
            // 
            txtSrcPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSrcPath.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSrcPath.AutoCompleteSource = AutoCompleteSource.FileSystem;
            txtSrcPath.Location = new Point(109, 12);
            txtSrcPath.Name = "txtSrcPath";
            txtSrcPath.Size = new Size(439, 20);
            txtSrcPath.TabIndex = 0;
            // 
            // txtDestPath
            // 
            txtDestPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDestPath.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDestPath.AutoCompleteSource = AutoCompleteSource.FileSystem;
            txtDestPath.Location = new Point(109, 39);
            txtDestPath.Name = "txtDestPath";
            txtDestPath.Size = new Size(439, 20);
            txtDestPath.TabIndex = 1;
            // 
            // ckbIncludeSubdirs
            // 
            ckbIncludeSubdirs.AutoSize = true;
            ckbIncludeSubdirs.Checked = true;
            ckbIncludeSubdirs.CheckState = CheckState.Checked;
            ckbIncludeSubdirs.Location = new Point(109, 166);
            ckbIncludeSubdirs.Name = "ckbIncludeSubdirs";
            ckbIncludeSubdirs.Size = new Size(111, 17);
            ckbIncludeSubdirs.TabIndex = 6;
            ckbIncludeSubdirs.Text = "Incluir Sub Pastas";
            ckbIncludeSubdirs.UseVisualStyleBackColor = true;
            // 
            // ckbUseFilters
            // 
            ckbUseFilters.AutoSize = true;
            ckbUseFilters.Location = new Point(109, 65);
            ckbUseFilters.Name = "ckbUseFilters";
            ckbUseFilters.Size = new Size(84, 17);
            ckbUseFilters.TabIndex = 7;
            ckbUseFilters.Text = "Incluir Filtros";
            ckbUseFilters.UseVisualStyleBackColor = true;
            ckbUseFilters.CheckedChanged += CkbUseFilters_CheckedChanged;
            // 
            // txtFilters
            // 
            txtFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFilters.Enabled = false;
            txtFilters.Location = new Point(109, 88);
            txtFilters.Multiline = true;
            txtFilters.Name = "txtFilters";
            txtFilters.ScrollBars = ScrollBars.Vertical;
            txtFilters.Size = new Size(470, 72);
            txtFilters.TabIndex = 8;
            txtFilters.WordWrap = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 216);
            label3.Name = "label3";
            label3.Size = new Size(84, 13);
            label3.TabIndex = 9;
            label3.Text = "Progresso Total:";
            // 
            // pbTotal
            // 
            pbTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbTotal.Location = new Point(102, 216);
            pbTotal.Name = "pbTotal";
            pbTotal.Size = new Size(477, 13);
            pbTotal.TabIndex = 10;
            // 
            // pbCurrent
            // 
            pbCurrent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbCurrent.Location = new Point(102, 235);
            pbCurrent.Name = "pbCurrent";
            pbCurrent.Size = new Size(477, 13);
            pbCurrent.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 235);
            label4.Name = "label4";
            label4.Size = new Size(84, 13);
            label4.TabIndex = 12;
            label4.Text = "Progresso Atual:";
            // 
            // lbInfo
            // 
            lbInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbInfo.AutoEllipsis = true;
            lbInfo.Location = new Point(12, 258);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new Size(567, 19);
            lbInfo.TabIndex = 13;
            lbInfo.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnProcess
            // 
            btnProcess.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnProcess.Location = new Point(484, 300);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(95, 23);
            btnProcess.TabIndex = 16;
            btnProcess.Text = "Iniciar";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += BtnProcess_Click;
            // 
            // lbStatus
            // 
            lbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbStatus.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbStatus.Location = new Point(12, 305);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(466, 15);
            lbStatus.TabIndex = 17;
            lbStatus.Text = "Status: Inativo";
            // 
            // ckbCreateDestIfNotExist
            // 
            ckbCreateDestIfNotExist.AutoSize = true;
            ckbCreateDestIfNotExist.Checked = true;
            ckbCreateDestIfNotExist.CheckState = CheckState.Checked;
            ckbCreateDestIfNotExist.Location = new Point(237, 166);
            ckbCreateDestIfNotExist.Name = "ckbCreateDestIfNotExist";
            ckbCreateDestIfNotExist.Size = new Size(185, 17);
            ckbCreateDestIfNotExist.TabIndex = 18;
            ckbCreateDestIfNotExist.Text = "Criar Pasta Destino Se Não Existir";
            ckbCreateDestIfNotExist.UseVisualStyleBackColor = true;
            // 
            // ckbVerifyHash
            // 
            ckbVerifyHash.AutoSize = true;
            ckbVerifyHash.Checked = true;
            ckbVerifyHash.CheckState = CheckState.Checked;
            ckbVerifyHash.Location = new Point(237, 65);
            ckbVerifyHash.Name = "ckbVerifyHash";
            ckbVerifyHash.Size = new Size(167, 17);
            ckbVerifyHash.TabIndex = 19;
            ckbVerifyHash.Text = "Fazer Verificação de Arquivos";
            ckbVerifyHash.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(591, 331);
            Controls.Add(ckbVerifyHash);
            Controls.Add(ckbCreateDestIfNotExist);
            Controls.Add(lbStatus);
            Controls.Add(btnProcess);
            Controls.Add(horizontalSplitter2);
            Controls.Add(horizontalSplitter1);
            Controls.Add(lbInfo);
            Controls.Add(label4);
            Controls.Add(pbCurrent);
            Controls.Add(pbTotal);
            Controls.Add(label3);
            Controls.Add(txtFilters);
            Controls.Add(ckbUseFilters);
            Controls.Add(ckbIncludeSubdirs);
            Controls.Add(btnOpenDestPath);
            Controls.Add(btnOpenSrcPath);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDestPath);
            Controls.Add(txtSrcPath);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MaximumSize = new Size(999999, 370);
            MinimumSize = new Size(551, 370);
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cópia de Segurança";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSrcPath;
        private TextBox txtDestPath;
        private Label label1;
        private Label label2;
        private Button btnOpenSrcPath;
        private Button btnOpenDestPath;
        private CheckBox ckbIncludeSubdirs;
        private CheckBox ckbUseFilters;
        private TextBox txtFilters;
        private Label label3;
        private ProgressBar pbTotal;
        private ProgressBar pbCurrent;
        private Label label4;
        private Label lbInfo;
        private Controls.HorizontalSplitter horizontalSplitter1;
        private Button btnProcess;
        private Label lbStatus;
        private CheckBox ckbCreateDestIfNotExist;
        private CheckBox ckbVerifyHash;
    }
}