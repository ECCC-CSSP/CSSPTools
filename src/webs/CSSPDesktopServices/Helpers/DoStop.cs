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
            AppendStatus(new AppendEventArgs(appTextModel.StoppingBrowserAndCSSPWebAPIsProcesses));

            if (processBrowser != null)
            {
                if (!processBrowser.HasExited)
                {
                    AppendStatus(new AppendEventArgs(string.Format(appTextModel.Stopping_, processBrowser.ProcessName)));
                    processBrowser.Kill();
                }
            }

            if (processCSSPWebAPIs != null)
            {
                if (!processCSSPWebAPIs.HasExited)
                {
                    AppendStatus(new AppendEventArgs(string.Format(appTextModel.Stopping_, processBrowser.ProcessName)));
                    processCSSPWebAPIs.Kill();
                }
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
