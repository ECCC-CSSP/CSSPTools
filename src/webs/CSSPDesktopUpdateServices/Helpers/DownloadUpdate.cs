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
        private bool DownloadUpdate()
        {
            DownloadingStatus(new DownloadingEventArgs(0));

            Thread.Sleep(1000);

            DownloadingStatus(new DownloadingEventArgs(10));

            Thread.Sleep(1000);

            if (!DoCheckingInternetConnection()) return false;

            DownloadingStatus(new DownloadingEventArgs(80));

            Thread.Sleep(1000);

            if (!InstallUpdate()) return false;

            return true;
        }
    }
}
