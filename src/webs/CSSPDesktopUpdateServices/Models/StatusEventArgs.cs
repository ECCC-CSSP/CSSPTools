using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPDesktopUpdateServices.Models
{
    public class DownloadingEventArgs : EventArgs
    {
        public DownloadingEventArgs(int Percent)
        {
            this.Percent = Percent;
        }
        public int Percent { get; set; }
    }
    public class InstallingEventArgs : EventArgs
    {
        public InstallingEventArgs(int Percent)
        {
            this.Percent = Percent;
        }
        public int Percent { get; set; }
    }
    public class ErrorMessageEventArgs : EventArgs
    {
        public ErrorMessageEventArgs(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
        }
        public string ErrorMessage { get; set; }
    }
}
