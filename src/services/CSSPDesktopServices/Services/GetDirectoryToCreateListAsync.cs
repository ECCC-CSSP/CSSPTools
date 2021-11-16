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
        public async Task<List<string>> GetDirectoryToCreateListAsync()
        {
            return await Task.FromResult(new List<string>()
            {
               Configuration["CSSPDesktopPath"],
               Configuration["CSSPDatabasesPath"],
               Configuration["CSSPWebAPIsLocalPath"],
               Configuration["CSSPJSONPath"],
               Configuration["CSSPJSONPathLocal"],
               Configuration["CSSPFilesPath"],
               Configuration["CSSPOtherFilesPath"],
               Configuration["CSSPTempFilesPath"]
            });
        }
    }
}
