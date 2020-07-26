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
        private async Task<bool> OpenBrowser()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = StartUrl;
            if (!IsEnglish)
            {
                processStartInfo.FileName = StartUrl.Replace("en-CA", "fr-CA");
            }
            processStartInfo.Arguments = "";
            processStartInfo.UseShellExecute = true;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                processBrowser = Process.Start(processStartInfo);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                processStartInfo.FileName = "xdg-open";
                processStartInfo.Arguments = StartUrl;

                processBrowser = Process.Start(processStartInfo);
                //Process.Start("xdg-open", url);  // Works ok on linux
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                processStartInfo.FileName = "open";
                processStartInfo.Arguments = StartUrl;

                processBrowser = Process.Start(processStartInfo);
                //Process.Start("open", url); // Not tested
            }
            else
            {
            }

            return await Task.FromResult(true);
        }
    }
}
