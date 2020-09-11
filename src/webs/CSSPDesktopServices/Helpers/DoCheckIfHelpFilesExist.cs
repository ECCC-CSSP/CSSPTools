using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using CSSPDesktopServices.Models;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckIfHelpFilesExist()
        {
            AppendStatus(new AppendEventArgs(appTextModel.CheckIfHelpFileExist));

            HasHelpFiles = true;

            List<string> HelpFileList = new List<string>()
            {
                $"{ LocalCSSPWebAPIsPath }HelpDocEN.rtf",
                $"{ LocalCSSPWebAPIsPath }HelpDocFR.rtf"
            };

            foreach (string HelpFile in HelpFileList)
            {
                FileInfo fi = new FileInfo(HelpFile);
                if (fi.Exists)
                {
                    AppendStatus(new AppendEventArgs(string.Format(appTextModel.HelpFileFound_, HelpFile)));
                }
                else
                {
                    HasHelpFiles = false;
                    AppendStatus(new AppendEventArgs(string.Format(appTextModel.HelpFileNotFound_, HelpFile)));
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
