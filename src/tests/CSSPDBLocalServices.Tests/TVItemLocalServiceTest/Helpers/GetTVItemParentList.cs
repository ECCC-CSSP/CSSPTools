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
        private async Task<List<TVItemStatModel>> GetWebBaseParentList(WebTypeEnum webType)
        {
            switch (webType)
            {
                case WebTypeEnum.WebRoot:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebCountry:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebCountry.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebProvince:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebProvince.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebArea:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebArea.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebSector:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSector.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebSubsector:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebMunicipality:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebMWQMSamples1980_2020:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebMWQMSamples2021_2060:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebMWQMRuns:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebMWQMSites:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllContacts:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebClimateSites:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebClimateSites.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebHydrometricSites:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebHydrometricSites.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebDrogueRuns:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebDrogueRuns.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllHelpDocs:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllTideLocations:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebPolSourceSites:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllPolSourceGroupings:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllReportTypes:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllTVItems1980_2020:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllTVItems2021_2060:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllTVItemLanguages1980_2020:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllTVItemLanguages2021_2060:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllMunicipalities:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllProvinces:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebCountry.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllCountries:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllAddresses:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllEmails:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebAllTels:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList);
                    }
                case WebTypeEnum.WebTideSites:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebTideSites.TVItemStatModelParentList);
                    }
                default:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
            }
        }
    }
}
