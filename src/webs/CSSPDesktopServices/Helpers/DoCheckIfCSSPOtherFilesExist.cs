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
        private async Task<bool> DoCheckIfCSSPOtherFilesExist()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckIfCSSPOtherFilesExist));

            HasCSSPOtherFiles = true;

            List<string> CSSPOtherFileList = new List<string>()
            {
                $"{ Configuration["CSSPOtherFilesPath"] }CssFamilyMaterial.css",
                $"{ Configuration["CSSPOtherFilesPath"] }flUhRq6tzZclQEJ-Vdg-IuiaDsNc.woff2",
                $"{ Configuration["CSSPOtherFilesPath"] }GoogleMap.js",
                $"{ Configuration["CSSPOtherFilesPath"] }IconFamilyMaterial.css",
                $"{ Configuration["CSSPOtherFilesPath"] }HelpDocEN.rtf",
                $"{ Configuration["CSSPOtherFilesPath"] }HelpDocFR.rtf"
            };

            foreach (string CSSPOtherFile in CSSPOtherFileList)
            {
                FileInfo fi = new FileInfo(CSSPOtherFile);
                if (fi.Exists)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CSSPOtherFileFound_, CSSPOtherFile)));
                }
                else
                {
                    HasCSSPOtherFiles = false;
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CSSPOtherFileNotFound_, CSSPOtherFile)));
                }

            }

            AppendStatus(new AppendEventArgs(""));

            if (!HasCSSPOtherFiles)
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
