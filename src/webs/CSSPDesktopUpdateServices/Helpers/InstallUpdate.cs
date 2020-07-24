using CSSPDesktopUpdateServices.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPDesktopUpdateServices.Services
{
    public partial class CSSPDesktopUpdateService
    {
        private bool InstallUpdate()
        {
            InstallingStatus(new InstallingEventArgs(0));

            Thread.Sleep(1000);

            InstallingStatus(new InstallingEventArgs(10));

            if (!RestartCSSPDesktop()) return false;

            InstallingStatus(new InstallingEventArgs(80));

            Thread.Sleep(1000);

            return true;
        }
    }
}
