/* 
 *  Manually Edited
 *  
 */

using CSSPEnums;
using CSSPWebModels;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task LoadWebType(int ParentTVItemID, WebTypeEnum webType)
        {
            switch (webType)
            {
                case WebTypeEnum.WebAllAddresses:
                    {
                        webAllAddresses = await CSSPReadGzFileService.GetUncompressJSON<WebAllAddresses>(webType, ParentTVItemID);
                        Assert.NotNull(webAllAddresses);
                    }
                    break;
                case WebTypeEnum.WebAllContacts:
                    {
                        webAllContacts = await CSSPReadGzFileService.GetUncompressJSON<WebAllContacts>(webType, ParentTVItemID);
                        Assert.NotNull(webAllContacts);
                    }
                    break;
                case WebTypeEnum.WebAllCountries:
                    {
                        webAllCountries = await CSSPReadGzFileService.GetUncompressJSON<WebAllCountries>(webType, ParentTVItemID);
                        Assert.NotNull(webAllCountries);
                    }
                    break;
                case WebTypeEnum.WebAllEmails:
                    {
                        webAllEmails = await CSSPReadGzFileService.GetUncompressJSON<WebAllEmails>(webType, ParentTVItemID);
                        Assert.NotNull(webAllEmails);
                    }
                    break;
                case WebTypeEnum.WebAllHelpDocs:
                    {
                        webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(webType, ParentTVItemID);
                        Assert.NotNull(webAllHelpDocs);
                    }
                    break;
                case WebTypeEnum.WebAllMunicipalities:
                    {
                        webAllMunicipalities = await CSSPReadGzFileService.GetUncompressJSON<WebAllMunicipalities>(webType, ParentTVItemID);
                        Assert.NotNull(webAllMunicipalities);
                    }
                    break;
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    {
                        webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(webType, ParentTVItemID);
                        Assert.NotNull(webAllMWQMLookupMPNs);
                    }
                    break;
                case WebTypeEnum.WebAllPolSourceGroupings:
                    {
                        webAllPolSourceGroupings = await CSSPReadGzFileService.GetUncompressJSON<WebAllPolSourceGroupings>(webType, ParentTVItemID);
                        Assert.NotNull(webAllPolSourceGroupings);
                    }
                    break;
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    {
                        webAllPolSourceSiteEffectTerms = await CSSPReadGzFileService.GetUncompressJSON<WebAllPolSourceSiteEffectTerms>(webType, ParentTVItemID);
                        Assert.NotNull(webAllPolSourceSiteEffectTerms);
                    }
                    break;
                case WebTypeEnum.WebAllProvinces:
                    {
                        webAllProvinces = await CSSPReadGzFileService.GetUncompressJSON<WebAllProvinces>(webType, ParentTVItemID);
                        Assert.NotNull(webAllProvinces);
                    }
                    break;
                case WebTypeEnum.WebAllReportTypes:
                    {
                        webAllReportTypes = await CSSPReadGzFileService.GetUncompressJSON<WebAllReportTypes>(webType, ParentTVItemID);
                        Assert.NotNull(webAllReportTypes);
                    }
                    break;
                case WebTypeEnum.WebAllSearch:
                    {
                        webAllSearch = await CSSPReadGzFileService.GetUncompressJSON<WebAllSearch>(webType, ParentTVItemID);
                        Assert.NotNull(webAllSearch);
                    }
                    break;
                case WebTypeEnum.WebAllTels:
                    {
                        webAllTels = await CSSPReadGzFileService.GetUncompressJSON<WebAllTels>(webType, ParentTVItemID);
                        Assert.NotNull(webAllTels);
                    }
                    break;
                case WebTypeEnum.WebAllTideLocations:
                    {
                        webAllTideLocations = await CSSPReadGzFileService.GetUncompressJSON<WebAllTideLocations>(webType, ParentTVItemID);
                        Assert.NotNull(webAllTideLocations);
                    }
                    break;
                case WebTypeEnum.WebArea:
                    {
                        webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(webType, ParentTVItemID);
                        Assert.NotNull(webArea);
                    }
                    break;
                case WebTypeEnum.WebClimateSites:
                    {
                        webClimateSites = await CSSPReadGzFileService.GetUncompressJSON<WebClimateSites>(webType, ParentTVItemID);
                        Assert.NotNull(webClimateSites);
                    }
                    break;
                case WebTypeEnum.WebCountry:
                    {
                        webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(webType, ParentTVItemID);
                        Assert.NotNull(webCountry);
                    }
                    break;
                case WebTypeEnum.WebDrogueRuns:
                    {
                        webDrogueRuns = await CSSPReadGzFileService.GetUncompressJSON<WebDrogueRuns>(webType, ParentTVItemID);
                        Assert.NotNull(webDrogueRuns);
                    }
                    break;
                case WebTypeEnum.WebHydrometricSites:
                    {
                        webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSON<WebHydrometricSites>(webType, ParentTVItemID);
                        Assert.NotNull(webHydrometricSites);
                    }
                    break;
                case WebTypeEnum.WebLabSheets:
                    {
                        webLabSheets = await CSSPReadGzFileService.GetUncompressJSON<WebLabSheets>(webType, ParentTVItemID);
                        Assert.NotNull(webLabSheets);
                    }
                    break;
                case WebTypeEnum.WebMikeScenarios:
                    {
                        webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(webType, ParentTVItemID);
                        Assert.NotNull(webMikeScenarios);
                    }
                    break;
                case WebTypeEnum.WebMonitoringOtherStatsCountry:
                    {
                        webMonitoringOtherStatsCountry = await CSSPReadGzFileService.GetUncompressJSON<WebMonitoringOtherStatsCountry>(webType, ParentTVItemID);
                        Assert.NotNull(webMonitoringOtherStatsCountry);
                    }
                    break;
                case WebTypeEnum.WebMonitoringOtherStatsProvince:
                    {
                        webMonitoringOtherStatsProvince = await CSSPReadGzFileService.GetUncompressJSON<WebMonitoringOtherStatsProvince>(webType, ParentTVItemID);
                        Assert.NotNull(webMonitoringOtherStatsProvince);
                    }
                    break;
                case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                    {
                        webMonitoringRoutineStatsCountry = await CSSPReadGzFileService.GetUncompressJSON<WebMonitoringRoutineStatsCountry>(webType, ParentTVItemID);
                        Assert.NotNull(webMonitoringRoutineStatsCountry);
                    }
                    break;
                case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                    {
                        webMonitoringRoutineStatsProvince = await CSSPReadGzFileService.GetUncompressJSON<WebMonitoringRoutineStatsProvince>(webType, ParentTVItemID);
                        Assert.NotNull(webMonitoringRoutineStatsProvince);
                    }
                    break;
                case WebTypeEnum.WebMunicipality:
                    {
                        webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(webType, ParentTVItemID);
                        Assert.NotNull(webMunicipality);
                    }
                    break;
                case WebTypeEnum.WebMWQMRuns:
                    {
                        webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMRuns>(webType, ParentTVItemID);
                        Assert.NotNull(webMWQMRuns);
                    }
                    break;
                case WebTypeEnum.WebMWQMSamples1980_2020:
                    {
                        webMWQMSamples1980_2020 = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSamples>(webType, ParentTVItemID);
                        Assert.NotNull(webMWQMSamples1980_2020);
                    }
                    break;
                case WebTypeEnum.WebMWQMSamples2021_2060:
                    {
                        webMWQMSamples2021_2060 = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSamples>(webType, ParentTVItemID);
                        Assert.NotNull(webMWQMSamples2021_2060);
                    }
                    break;
                case WebTypeEnum.WebMWQMSites:
                    {
                        webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(webType, ParentTVItemID);
                        Assert.NotNull(webMWQMSites);
                    }
                    break;
                case WebTypeEnum.WebPolSourceSites:
                    {
                        webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(webType, ParentTVItemID);
                        Assert.NotNull(webPolSourceSites);
                    }
                    break;
                case WebTypeEnum.WebProvince:
                    {
                        webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(webType, ParentTVItemID);
                        Assert.NotNull(webProvince);
                    }
                    break;
                case WebTypeEnum.WebRoot:
                    {
                        webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(webType, ParentTVItemID);
                        Assert.NotNull(webRoot);
                    }
                    break;
                case WebTypeEnum.WebSector:
                    {
                        webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(webType, ParentTVItemID);
                        Assert.NotNull(webSector);
                    }
                    break;
                case WebTypeEnum.WebSubsector:
                    {
                        webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(webType, ParentTVItemID);
                        Assert.NotNull(webSubsector);
                    }
                    break;
                case WebTypeEnum.WebTideSites:
                    {
                        webTideSites = await CSSPReadGzFileService.GetUncompressJSON<WebTideSites>(webType, ParentTVItemID);
                        Assert.NotNull(webTideSites);
                    }
                    break;
                default:
                    {
                        Assert.True(false, $"ParentTVItemID = {ParentTVItemID}   webType = {webType}");
                    }
                    break;
            }
        }
    }
}
