using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using CSSPDesktopServices.Models;
using CSSPCultureServices.Resources;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckIfHelpFilesExist()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckIfHelpFileExist));

            HasHelpFiles = true;

            List<string> HelpFileList = new List<string>()
            {
                $"{ CSSPWebAPIsLocalPath }HelpDocEN.rtf",
                $"{ CSSPWebAPIsLocalPath }HelpDocFR.rtf"
            };

            foreach (string HelpFile in HelpFileList)
            {
                FileInfo fi = new FileInfo(HelpFile);
                if (fi.Exists)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.HelpFileFound_, HelpFile)));
                }
                else
                {
                    HasHelpFiles = false;
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.HelpFileNotFound_, HelpFile)));
                }

            }

            AppendStatus(new AppendEventArgs(""));

            if (!HasHelpFiles)
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
