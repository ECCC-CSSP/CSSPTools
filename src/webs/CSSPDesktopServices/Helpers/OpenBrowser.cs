using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private bool OpenBrowser()
        {
            AppendStatus(new AppendEventArgs(string.Format(appTextModel.Executing_, $"{ CSSPLocalUrl }en-CA/")));

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = $"{ CSSPLocalUrl }en-CA/";
            if (!IsEnglish)
            {
                processStartInfo.FileName = processStartInfo.FileName.Replace("en-CA", "fr-CA");
            }
            processStartInfo.Arguments = "";
            processStartInfo.UseShellExecute = true;
            processBrowser = Process.Start(processStartInfo);

            return true;
        }
    }
}
