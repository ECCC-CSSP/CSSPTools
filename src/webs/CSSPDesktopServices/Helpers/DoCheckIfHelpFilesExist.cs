using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckIfHelpFilesExist()
        {
            FileInfo fi = new FileInfo($"{ LocalCSSPHelpPath }HelpDocEN.rtf");
            if (fi.Exists)
            {
                HasHelpFiles = true;
            }
            else
            {
                HasHelpFiles = false;
            }

            return await Task.FromResult(true);
        }
    }
}
