/* 
 *  Manually Edited
 *  
 */

using CSSPEnums;
using CSSPWebModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task<List<TVItemModel>> GetWebBaseParentList(WebTypeEnum webType)
        {
            switch (webType)
            {
                case WebTypeEnum.WebRoot:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebCountry:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebCountry.TVItemModelParentList);
                    }
                case WebTypeEnum.WebProvince:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebProvince.TVItemModelParentList);
                    }
                case WebTypeEnum.WebArea:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebArea.TVItemModelParentList);
                    }
                case WebTypeEnum.WebSector:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebSubsector:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMunicipality:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMWQMSamples1980_2020:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMWQMSamples2021_2060:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMWQMRuns:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMWQMSites:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllContacts:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebClimateSites:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebClimateSites.TVItemModelParentList);
                    }
                case WebTypeEnum.WebHydrometricSites:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebHydrometricSites.TVItemModelParentList);
                    }
                case WebTypeEnum.WebDrogueRuns:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebDrogueRuns.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllHelpDocs:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllTideLocations:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebPolSourceSites:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllPolSourceGroupings:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllReportTypes:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllMunicipalities:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllProvinces:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebCountry.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllCountries:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllAddresses:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllEmails:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllSearch:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebAllSearch.TVItemModelList);
                    }
                case WebTypeEnum.WebAllTels:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebTideSites:
                    {
                        return await Task.FromResult(ReadGzFileService.webAppLoaded.WebTideSites.TVItemModelParentList);
                    }
                default:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
            }
        }
    }
}
