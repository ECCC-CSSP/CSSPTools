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
        public async Task<List<string>> GetJsonFileNameListAsync()
        {
            return await Task.FromResult(new List<string>()
            {
                $"{ WebTypeEnum.WebAllAddresses }.gz",
                $"{ WebTypeEnum.WebAllContacts }.gz",
                $"{ WebTypeEnum.WebAllCountries }.gz",
                $"{ WebTypeEnum.WebAllEmails }.gz",
                $"{ WebTypeEnum.WebAllHelpDocs }.gz",
                $"{ WebTypeEnum.WebAllMunicipalities }.gz",
                $"{ WebTypeEnum.WebAllMWQMAnalysisReportParameters }.gz",
                $"{ WebTypeEnum.WebAllMWQMLookupMPNs }.gz",
                $"{ WebTypeEnum.WebAllMWQMSubsectors }.gz",
                $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz",
                $"{ WebTypeEnum.WebAllPolSourceSiteEffectTerms }.gz",
                $"{ WebTypeEnum.WebAllProvinces }.gz",
                $"{ WebTypeEnum.WebAllReportTypes }.gz",
                $"{ WebTypeEnum.WebAllSearch }.gz",
                $"{ WebTypeEnum.WebAllTels }.gz",
                $"{ WebTypeEnum.WebAllTideLocations }.gz",
                $"{ WebTypeEnum.WebAllUseOfSites }.gz",
                $"{ WebTypeEnum.WebRoot }.gz",
            });
        }
    }
}
