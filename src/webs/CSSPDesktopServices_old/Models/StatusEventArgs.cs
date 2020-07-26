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

}
