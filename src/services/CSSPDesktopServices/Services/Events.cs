namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    protected virtual void ClearStatus(ClearEventArgs e)
    {
        StatusClear?.Invoke(this, e);
    }

    public event EventHandler<ClearEventArgs> StatusClear;


    protected virtual void AppendStatus(AppendEventArgs e)
    {
        StatusAppend?.Invoke(this, e);
    }

    public event EventHandler<AppendEventArgs> StatusAppend;

    protected virtual void InstallingStatus(InstallingEventArgs e)
    {
        StatusInstalling?.Invoke(this, e);
    }

    public event EventHandler<InstallingEventArgs> StatusInstalling;
}

