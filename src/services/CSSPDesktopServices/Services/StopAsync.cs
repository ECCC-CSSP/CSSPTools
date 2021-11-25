namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    public async Task<bool> StopAsync()
    {
        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.StoppingBrowserAndCSSPWebAPIsLocalProcesses));

        if (processCSSPWebAPIsLocal != null)
        {
            if (!processCSSPWebAPIsLocal.HasExited)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Stopping_, processCSSPWebAPIsLocal.ProcessName)));
                processCSSPWebAPIsLocal.Kill();
            }
        }

        if (processBrowser != null)
        {
            if (!processBrowser.HasExited)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Stopping_, CSSPCultureDesktopRes.BrowserIfOpenByCSSPDesktop)));
                processBrowser.Kill();
            }
        }

        AppendStatus(new AppendEventArgs(""));

        return await Task.FromResult(true);
    }
}

