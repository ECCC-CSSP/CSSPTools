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
        private bool OpenBrowser()
        {
            string culture = "fr-CA";
            if (IsEnglish)
            {
                culture = "en-CA";
            }

            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Executing_, $"{ CSSPLocalUrl }{ culture }/")));

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = $"{ CSSPLocalUrl }{ culture }/";
            processStartInfo.Arguments = "";
            processStartInfo.UseShellExecute = true;
            processBrowser = Process.Start(processStartInfo);

            return true;
        }
    }
}
