using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoStop()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.StoppingBrowserAndCSSPWebAPIsLocalProcesses));

            if (processCSSPWebAPIsLocal != null)
            {
                if (!processCSSPWebAPIsLocal.HasExited)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Stopping_, processBrowser.ProcessName)));
                    processCSSPWebAPIsLocal.Kill();
                }
            }

            if (processBrowser != null)
            {
                if (!processBrowser.HasExited)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Stopping_, processBrowser.ProcessName)));
                    processBrowser.Kill();
                }
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
