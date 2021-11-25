namespace CSSPDesktopServices.Models;

public class ClearEventArgs : EventArgs
{
    public ClearEventArgs()
    {
    }
}
public class AppendEventArgs : EventArgs
{
    public AppendEventArgs(string Message)
    {
        this.Message = Message;
    }
    public string Message { get; set; }
}
public class InstallingEventArgs : EventArgs
{
    public InstallingEventArgs(int Percent)
    {
        this.Percent = Percent;
    }
    public int Percent { get; set; }
}

