/* 
 *  Manually Edited
 *  
 */

using CSSPEnums;
using CSSPWebModels;
using System.Threading.Tasks;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task<TVItemModel> GetTVItemModel(WebTypeEnum webType)
        {
            switch (webType)
            {
                case WebTypeEnum.WebAllAddresses:
                    {
                        return await Task.FromResult(webRoot.TVItemModel);
                    }
                case WebTypeEnum.WebAllContacts:
                    {
                        return await Task.FromResult(webRoot.TVItemModel);
                    }
                case WebTypeEnum.WebAllCountries:
                    {
                        return await Task.FromResult(webRoot.TVItemModel);
                    }
                case WebTypeEnum.WebAllEmails:
                    {
                        return await Task.FromResult(webRoot.TVItemModel);
                    }
                case WebTypeEnum.WebAllHelpDocs:
                    {
                        return await Task.FromResult(webRoot.TVItemModel);
                    }
                case WebTypeEnum.WebAllMunicipalities:
                    {
                        return await Task.FromResult(webRoot.TVItemModel);
                    }
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    {
                        return await Task.FromResult(webRoot.TVItemModel);
                    }
                case WebTypeEnum.WebAllPolSourceGroupings:
                    {
                        return await Task.FromResult(webRoot.TVItemModel);
                    }
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    {
                        return await Task.FromResult(webRoot.TVItemModel);
                    }
                case WebTypeEnum.WebAllProvinces:
                    {
                        return await Task.FromResult(webCountry.TVItemModel);
                    }
                case WebTypeEnum.WebAllReportTypes:
                    {
                        return await Task.FromResult(webRoot.TVItemModel);
                    }
                case WebTypeEnum.WebAllSearch:
                    {
                        //return await Task.FromResult(webAllSearch.TVItemModelList);
                        return await Task.FromResult(new TVItemModel());
                    }
                case WebTypeEnum.WebAllTels:
                    {
                        return await Task.FromResult(webRoot.TVItemModel);
                    }
                case WebTypeEnum.WebAllTideLocations:
                    {
                        return await Task.FromResult(webRoot.TVItemModel);
                    }
                case WebTypeEnum.WebArea:
                    {
                        return await Task.FromResult(webArea.TVItemModel);
                    }
                case WebTypeEnum.WebClimateSites:
                    {
                        return await Task.FromResult(webClimateSites.TVItemModel);
                    }
                case WebTypeEnum.WebCountry:
                    {
                        return await Task.FromResult(webCountry.TVItemModel);
                    }
                case WebTypeEnum.WebDrogueRuns:
                    {
                        return await Task.FromResult(webDrogueRuns.TVItemModel);
                    }
                case WebTypeEnum.WebHydrometricSites:
                    {
                        return await Task.FromResult(webHydrometricSites.TVItemModel);
                    }
                case WebTypeEnum.WebLabSheets:
                    {
                        return await Task.FromResult(webLabSheets.TVItemModel);
                    }
                case WebTypeEnum.WebMikeScenarios:
                    {
                        return await Task.FromResult(webMikeScenarios.TVItemModel);
                    }
                case WebTypeEnum.WebMonitoringOtherStatsCountry:
                    {
                        return await Task.FromResult(webCountry.TVItemModel);
                    }
                case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                    {
                        return await Task.FromResult(webCountry.TVItemModel);
                    }
                case WebTypeEnum.WebMonitoringOtherStatsProvince:
                    {
                        return await Task.FromResult(webProvince.TVItemModel);
                    }
                case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                    {
                        return await Task.FromResult(webProvince.TVItemModel);
                    }
                case WebTypeEnum.WebMunicipality:
                    {
                        return await Task.FromResult(webMunicipality.TVItemModel);
                    }
                case WebTypeEnum.WebMWQMRuns:
                    {
                        return await Task.FromResult(webSubsector.TVItemModel);
                    }
                case WebTypeEnum.WebMWQMSamples1980_2020:
                    {
                        return await Task.FromResult(webSubsector.TVItemModel);
                    }
                case WebTypeEnum.WebMWQMSamples2021_2060:
                    {
                        return await Task.FromResult(webSubsector.TVItemModel);
                    }
                case WebTypeEnum.WebMWQMSites:
                    {
                        return await Task.FromResult(webSubsector.TVItemModel);
                    }
                case WebTypeEnum.WebPolSourceSites:
                    {
                        return await Task.FromResult(webSubsector.TVItemModel);
                    }
                case WebTypeEnum.WebProvince:
                    {
                        return await Task.FromResult(webProvince.TVItemModel);
                    }
                case WebTypeEnum.WebRoot:
                    {
                        return await Task.FromResult(webRoot.TVItemModel);
                    }
                case WebTypeEnum.WebSector:
                    {
                        return await Task.FromResult(webSector.TVItemModel);
                    }
                case WebTypeEnum.WebSubsector:
                    {
                        return await Task.FromResult(webSubsector.TVItemModel);
                    }
                case WebTypeEnum.WebTideSites:
                    {
                        return await Task.FromResult(webTideSites.TVItemModel);
                    }
                default:
                    {
                        return await Task.FromResult(new TVItemModel());
                    }
            }
        }
    }
}
