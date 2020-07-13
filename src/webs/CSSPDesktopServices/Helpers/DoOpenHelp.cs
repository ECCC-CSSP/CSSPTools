﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService
    {
        private async Task<bool> DoOpenHelp()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = HelpPath;
            if (!IsEnglish)
            {
                processStartInfo.FileName = HelpPath.Replace("EN.html", "FR.html");
            }
            processStartInfo.Arguments = "";
            processStartInfo.UseShellExecute = true;
            //processStartInfo.CreateNoWindow = true;
            //processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                processHelp = Process.Start(processStartInfo);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                processStartInfo.FileName = "xdg-open";
                processStartInfo.Arguments = HelpPath;

                processHelp = Process.Start(processStartInfo);
                //Process.Start("xdg-open", url);  // Works ok on linux
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                processStartInfo.FileName = "open";
                processStartInfo.Arguments = HelpPath;

                processHelp = Process.Start(processStartInfo);
                //Process.Start("open", url); // Not tested
            }
            else
            {
            }

            return await Task.FromResult(true);
        }
    }
}
