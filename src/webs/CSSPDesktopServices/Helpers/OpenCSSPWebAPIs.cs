using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService
    {
        private async Task<bool> OpenCSSPWebAPIs()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = CSSPWebAPIsExeFullPath;
            processStartInfo.Arguments = "";
            processStartInfo.UseShellExecute = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processCSSPWebAPIs = Process.Start(processStartInfo);

            return await Task.FromResult(true);
        }
    }
}
