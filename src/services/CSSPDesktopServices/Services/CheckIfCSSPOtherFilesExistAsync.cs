using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using CSSPHelperModels;
using ManageServices;
using CSSPLocalLoggedInServices;
using CSSPCultureServices.Resources;
using CSSPScrambleServices;
using CSSPLogServices;
using System.Linq;
using System.IO;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        public async Task<bool> CheckIfCSSPOtherFilesExistAsync()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckIfCSSPOtherFilesExist));

            HasCSSPOtherFiles = true;

            foreach (string CSSPOtherFile in await GetCSSPOtherFileListAsync())
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
