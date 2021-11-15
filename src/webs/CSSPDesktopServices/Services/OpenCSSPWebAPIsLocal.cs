using CSSPCultureServices.Resources;
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
        private bool OpenCSSPWebAPIsLocal()
        {
            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Executing_, $"{ Configuration["CSSPWebAPIsLocalPath"] }CSSPWebAPIsLocal.exe")));

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = $"{ Configuration["CSSPWebAPIsLocalPath"] }CSSPWebAPIsLocal.exe";
            processStartInfo.Arguments = "";
            processStartInfo.UseShellExecute = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processCSSPWebAPIsLocal = Process.Start(processStartInfo);

            return true;
        }
    }
}
