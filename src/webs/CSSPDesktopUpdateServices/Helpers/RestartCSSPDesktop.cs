using CSSPDesktopUpdateServices.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPDesktopUpdateServices.Services
{
    public partial class CSSPDesktopUpdateService
    {
        private bool RestartCSSPDesktop()
        {
            FileInfo fi = new FileInfo(Environment.CurrentDirectory + @"\CSSPDesktop.exe");
            if (!fi.Exists)
            {
                ErrorMessageStatus(new ErrorMessageEventArgs(string.Format(appTextModel.CSSPDesktopApplicationNotFoundText, fi.FullName)));
                return false;
            }

            Process process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = fi.FullName;
            processStartInfo.Arguments = "";
            processStartInfo.UseShellExecute = true;

            process.StartInfo = processStartInfo;
            process.Start();

            return true;
        }
    }
}
