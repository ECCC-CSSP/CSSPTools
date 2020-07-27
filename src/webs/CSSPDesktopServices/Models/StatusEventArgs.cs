using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPDesktopServices.Models
{
    public class ClearEventArgs : EventArgs
    {
        public ClearEventArgs()
        {
        }
    }
    public class AppendEventArgs : EventArgs
    {
        public AppendEventArgs(string Message)
        {
            this.Message = Message;
        }
        public string Message { get; set; }
    }
    public class AppendTempEventArgs : EventArgs
    {
        public AppendTempEventArgs(string Message)
        {
            this.Message = Message;
        }
        public string Message { get; set; }
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
