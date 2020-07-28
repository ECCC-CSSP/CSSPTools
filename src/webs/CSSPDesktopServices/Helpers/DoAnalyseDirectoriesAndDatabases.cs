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
        private async Task<bool> DoAnalyseDirectoriesAndDatabases()
        {
            InstallingStatus(new InstallingEventArgs(0));

            //do the Analyse
            LoginRequired = true;
            
            return await Task.FromResult(true);
        }
    }
}
