/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDBPreferenceModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPScrambleServices;
using CSSPWebModels;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task<TVItemModel> GetWebBase(WebTypeEnum webType)
        {
            switch (webType)
            {
                case WebTypeEnum.WebRoot:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModel);
                    }
                case WebTypeEnum.WebCountry:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebCountry.TVItemModel);
                    }
                case WebTypeEnum.WebProvince:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebProvince.TVItemModel);
                    }
                case WebTypeEnum.WebArea:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebArea.TVItemModel);
                    }
                //case WebTypeEnum.WebMunicipalities:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebMunicipalities);
                //    }
                case WebTypeEnum.WebSector:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSector.TVItemModel);
                    }
                case WebTypeEnum.WebSubsector:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel);
                    }
                case WebTypeEnum.WebMunicipality:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel);
                    }
                //case WebTypeEnum.WebMWQMSamples1980_2020:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebMWQMSamples1980_2020);
                //    }
                //case WebTypeEnum.WebMWQMSamples2021_2060:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebMWQMSamples2021_2060);
                //    }
                //case WebTypeEnum.WebMWQMRuns:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebMWQMRuns);
                //    }
                //case WebTypeEnum.WebMWQMSites:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebMWQMSites);
                //    }
                //case WebTypeEnum.WebAllContacts:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebClimateSites:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebClimateSites);
                //    }
                //case WebTypeEnum.WebHydrometricSites:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebHydrometricSites);
                //    }
                //case WebTypeEnum.WebDrogueRuns:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebDrogueRuns);
                //    }
                //case WebTypeEnum.WebAllMWQMLookupMPNs:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebAllHelpDocs:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebAllTideLocations:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebPolSourceSites:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebPolSourceSites);
                //    }
                //case WebTypeEnum.WebAllPolSourceGroupings:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebAllReportTypes:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebAllTVItems:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebAllTVItemLanguages:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebAllMunicipalities:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebAllProvinces:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebAllCountries:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebAllAddresses:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebAllEmails:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebAllTels:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot);
                //    }
                //case WebTypeEnum.WebTideSites:
                //    {
                //        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebTideSites);
                //    }
                default:
                    {
                        return await Task.FromResult(new TVItemModel());
                    }
            }
        }
    }
}
