using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService
    {
        private async Task<bool> DoStop()
        {
            if (processBrowser != null)
            {
                if (!processBrowser.HasExited)
                {
                    processBrowser.Kill();
                }
            }

            if (processCSSPWebAPIs != null)
            {
                if (!processCSSPWebAPIs.HasExited)
                {
                    processCSSPWebAPIs.Kill();
                }
            }

            return await Task.FromResult(true);
        }
    }
}
