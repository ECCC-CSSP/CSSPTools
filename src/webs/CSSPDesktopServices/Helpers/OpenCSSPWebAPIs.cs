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
        private bool OpenCSSPWebAPIs()
        {
            AppendStatus(new AppendEventArgs(string.Format(appTextModel.Executing_, $"{ LocalCSSPWebAPIsPath }CSSPWebAPIs.exe")));

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = $"{ LocalCSSPWebAPIsPath }CSSPWebAPIs.exe";
            processStartInfo.Arguments = "";
            processStartInfo.UseShellExecute = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processCSSPWebAPIs = Process.Start(processStartInfo);

            return true;
        }
    }
}
