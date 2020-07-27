using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService
    {
        private async Task<bool> DoInstallUpdates()
        {
            InstallingStatus(new InstallingEventArgs(0));

            // need to download the CSSPWebAPIs.zip and unzip under the userapp \\cssp\\
            // need to download the CSSPClient.zip and unzip under the userapp \\cssp\\
            // should have already create all the local databases is they don't already exist

            return await Task.FromResult(true);
        }
    }
}
