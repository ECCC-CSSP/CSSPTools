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

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<List<string>> GetCSSPOtherFileListAsync()
        {
            return await Task.FromResult(new List<string>()
            {
                $"{ Configuration["CSSPOtherFilesPath"] }CssFamilyMaterial.css",
                $"{ Configuration["CSSPOtherFilesPath"] }flUhRq6tzZclQEJ-Vdg-IuiaDsNc.woff2",
                $"{ Configuration["CSSPOtherFilesPath"] }GoogleMap.js",
                $"{ Configuration["CSSPOtherFilesPath"] }IconFamilyMaterial.css",
                $"{ Configuration["CSSPOtherFilesPath"] }HelpDocEN.rtf",
                $"{ Configuration["CSSPOtherFilesPath"] }HelpDocFR.rtf"
            });
        }
    }
}
