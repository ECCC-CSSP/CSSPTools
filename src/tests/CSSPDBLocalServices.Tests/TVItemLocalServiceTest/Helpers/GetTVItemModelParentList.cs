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
        private async Task<List<TVItemModel>> GetTVItemModelParentList(WebTypeEnum webType)
        {
            switch (webType)
            {
                case WebTypeEnum.WebAllAddresses:
                    {
                        return await Task.FromResult(webRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllContacts:
                    {
                        return await Task.FromResult(webRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllCountries:
                    {
                        return await Task.FromResult(webRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllEmails:
                    {
                        return await Task.FromResult(webRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllHelpDocs:
                    {
                        return await Task.FromResult(webRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllMunicipalities:
                    {
                        return await Task.FromResult(webRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    {
                        return await Task.FromResult(webRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllPolSourceGroupings:
                    {
                        return await Task.FromResult(webRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    {
                        return await Task.FromResult(webRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllProvinces:
                    {
                        return await Task.FromResult(webCountry.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllReportTypes:
                    {
                        return await Task.FromResult(webRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllSearch:
                    {
                        return await Task.FromResult(webAllSearch.TVItemModelList);
                    }
                case WebTypeEnum.WebAllTels:
                    {
                        return await Task.FromResult(webRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebAllTideLocations:
                    {
                        return await Task.FromResult(webRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebArea:
                    {
                        return await Task.FromResult(webArea.TVItemModelParentList);
                    }
                case WebTypeEnum.WebClimateSites:
                    {
                        return await Task.FromResult(webClimateSites.TVItemModelParentList);
                    }
                case WebTypeEnum.WebCountry:
                    {
                        return await Task.FromResult(webCountry.TVItemModelParentList);
                    }
                case WebTypeEnum.WebDrogueRuns:
                    {
                        return await Task.FromResult(webDrogueRuns.TVItemModelParentList);
                    }
                case WebTypeEnum.WebHydrometricSites:
                    {
                        return await Task.FromResult(webHydrometricSites.TVItemModelParentList);
                    }
                case WebTypeEnum.WebLabSheets:
                    {
                        return await Task.FromResult(webLabSheets.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMikeScenarios:
                    {
                        return await Task.FromResult(webMikeScenarios.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMonitoringOtherStatsCountry:
                    {
                        return await Task.FromResult(webCountry.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                    {
                        return await Task.FromResult(webCountry.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMonitoringOtherStatsProvince:
                    {
                        return await Task.FromResult(webProvince.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                    {
                        return await Task.FromResult(webProvince.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMunicipality:
                    {
                        return await Task.FromResult(webMunicipality.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMWQMRuns:
                    {
                        return await Task.FromResult(webSubsector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMWQMSamples1980_2020:
                    {
                        return await Task.FromResult(webSubsector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMWQMSamples2021_2060:
                    {
                        return await Task.FromResult(webSubsector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebMWQMSites:
                    {
                        return await Task.FromResult(webSubsector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebPolSourceSites:
                    {
                        return await Task.FromResult(webSubsector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebProvince:
                    {
                        return await Task.FromResult(webProvince.TVItemModelParentList);
                    }
                case WebTypeEnum.WebRoot:
                    {
                        return await Task.FromResult(webRoot.TVItemModelParentList);
                    }
                case WebTypeEnum.WebSector:
                    {
                        return await Task.FromResult(webSector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebSubsector:
                    {
                        return await Task.FromResult(webSubsector.TVItemModelParentList);
                    }
                case WebTypeEnum.WebTideSites:
                    {
                        return await Task.FromResult(webTideSites.TVItemModelParentList);
                    }
                default:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
            }
        }
    }
}
