namespace BackupApp.Controls;

internal class HorizontalSplitter : Panel
{
    public HorizontalSplitter()
    {
        BackColor = Color.Gray;
        BorderStyle = BorderStyle.Fixed3D;
        MinimumSize = new(1, 1);
        MaximumSize = new(int.MaxValue, 1);
        Enabled = false;
    }
}
