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
        private async Task<bool> DoCheckIfCSSIconJSFilesExist()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckIfCSSIconJSFileExist));

            HasCSSIconJSFiles = true;

            List<string> CSSIconJSFileList = new List<string>()
            {
                $"CssFamilyMaterial.css",
                $"flUhRq6tzZclQEJ-Vdg-IuiaDsNc.woff2",
                "GoogleMap.js",
                "IconFamilyMaterial.css",
            };

            foreach (string CSSIconJSFile in CSSIconJSFileList)
            {
                FileInfo fi = new FileInfo($"{ CSSPCSSIconJSPath }{CSSIconJSFile}");
                if (fi.Exists)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CSSIconJSFileFound_, $"{ CSSPCSSIconJSPath }{CSSIconJSFile}")));
                }
                else
                {
                    HasCSSIconJSFiles = false;
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CSSIconJSFileNotFound_, $"{ CSSPCSSIconJSPath }{CSSIconJSFile}")));
                }

            }

            AppendStatus(new AppendEventArgs(""));

            if (!HasCSSIconJSFiles)
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
