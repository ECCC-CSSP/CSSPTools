using CSSPDesktopUpdateServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopUpdateServices.Services
{
    public partial class CSSPDesktopUpdateService : ICSSPDesktopUpdateService
    {
        protected virtual void DownloadingStatus(DownloadingEventArgs e)
        {
            StatusDownloading?.Invoke(this, e);
        }

        public event EventHandler<DownloadingEventArgs> StatusDownloading;


        protected virtual void InstallingStatus(InstallingEventArgs e)
        {
            StatusInstalling?.Invoke(this, e);
        }

        public event EventHandler<InstallingEventArgs> StatusInstalling;

        protected virtual void ErrorMessageStatus(ErrorMessageEventArgs e)
        {
            StatusErrorMessage?.Invoke(this, e);
        }

        public event EventHandler<ErrorMessageEventArgs> StatusErrorMessage;
    }
}
