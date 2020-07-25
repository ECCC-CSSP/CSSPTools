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
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fi = new FileInfo(appDataPath + "\\cssp\\csspdesktop\\CSSPDesktop.exe");
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
