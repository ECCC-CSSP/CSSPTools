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
                        webAllAddresses = await ReadGzFileService.GetUncompressJSON<WebAllAddresses>(webType, ParentTVItemID);
                        Assert.NotNull(webAllAddresses);
                    }
                    break;
                case WebTypeEnum.WebAllContacts:
                    {
                        webAllContacts = await ReadGzFileService.GetUncompressJSON<WebAllContacts>(webType, ParentTVItemID);
                        Assert.NotNull(webAllContacts);
                    }
                    break;
                case WebTypeEnum.WebAllCountries:
                    {
                        webAllCountries = await ReadGzFileService.GetUncompressJSON<WebAllCountries>(webType, ParentTVItemID);
                        Assert.NotNull(webAllCountries);
                    }
                    break;
                case WebTypeEnum.WebAllEmails:
                    {
                        webAllEmails = await ReadGzFileService.GetUncompressJSON<WebAllEmails>(webType, ParentTVItemID);
                        Assert.NotNull(webAllEmails);
                    }
                    break;
                case WebTypeEnum.WebAllHelpDocs:
                    {
                        webAllHelpDocs = await ReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(webType, ParentTVItemID);
                        Assert.NotNull(webAllHelpDocs);
                    }
                    break;
                case WebTypeEnum.WebAllMunicipalities:
                    {
                        webAllMunicipalities = await ReadGzFileService.GetUncompressJSON<WebAllMunicipalities>(webType, ParentTVItemID);
                        Assert.NotNull(webAllMunicipalities);
                    }
                    break;
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    {
                        webAllMWQMLookupMPNs = await ReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(webType, ParentTVItemID);
                        Assert.NotNull(webAllMWQMLookupMPNs);
                    }
                    break;
                case WebTypeEnum.WebAllPolSourceGroupings:
                    {
                        webAllPolSourceGroupings = await ReadGzFileService.GetUncompressJSON<WebAllPolSourceGroupings>(webType, ParentTVItemID);
                        Assert.NotNull(webAllPolSourceGroupings);
                    }
                    break;
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    {
                        webAllPolSourceSiteEffectTerms = await ReadGzFileService.GetUncompressJSON<WebAllPolSourceSiteEffectTerms>(webType, ParentTVItemID);
                        Assert.NotNull(webAllPolSourceSiteEffectTerms);
                    }
                    break;
                case WebTypeEnum.WebAllProvinces:
                    {
                        webAllProvinces = await ReadGzFileService.GetUncompressJSON<WebAllProvinces>(webType, ParentTVItemID);
                        Assert.NotNull(webAllProvinces);
                    }
                    break;
                case WebTypeEnum.WebAllReportTypes:
                    {
                        webAllReportTypes = await ReadGzFileService.GetUncompressJSON<WebAllReportTypes>(webType, ParentTVItemID);
                        Assert.NotNull(webAllReportTypes);
                    }
                    break;
                case WebTypeEnum.WebAllSearch:
                    {
                        webAllSearch = await ReadGzFileService.GetUncompressJSON<WebAllSearch>(webType, ParentTVItemID);
                        Assert.NotNull(webAllSearch);
                    }
                    break;
                case WebTypeEnum.WebAllTels:
                    {
                        webAllTels = await ReadGzFileService.GetUncompressJSON<WebAllTels>(webType, ParentTVItemID);
                        Assert.NotNull(webAllTels);
                    }
                    break;
                case WebTypeEnum.WebAllTideLocations:
                    {
                        webAllTideLocations = await ReadGzFileService.GetUncompressJSON<WebAllTideLocations>(webType, ParentTVItemID);
                        Assert.NotNull(webAllTideLocations);
                    }
                    break;
                case WebTypeEnum.WebArea:
                    {
                        webArea = await ReadGzFileService.GetUncompressJSON<WebArea>(webType, ParentTVItemID);
                        Assert.NotNull(webArea);
                    }
                    break;
                case WebTypeEnum.WebClimateSites:
                    {
                        webClimateSites = await ReadGzFileService.GetUncompressJSON<WebClimateSites>(webType, ParentTVItemID);
                        Assert.NotNull(webClimateSites);
                    }
                    break;
                case WebTypeEnum.WebCountry:
                    {
                        webCountry = await ReadGzFileService.GetUncompressJSON<WebCountry>(webType, ParentTVItemID);
                        Assert.NotNull(webCountry);
                    }
                    break;
                case WebTypeEnum.WebDrogueRuns:
                    {
                        webDrogueRuns = await ReadGzFileService.GetUncompressJSON<WebDrogueRuns>(webType, ParentTVItemID);
                        Assert.NotNull(webDrogueRuns);
                    }
                    break;
                case WebTypeEnum.WebHydrometricSites:
                    {
                        webHydrometricSites = await ReadGzFileService.GetUncompressJSON<WebHydrometricSites>(webType, ParentTVItemID);
                        Assert.NotNull(webHydrometricSites);
                    }
                    break;
                case WebTypeEnum.WebLabSheets:
                    {
                        webLabSheets = await ReadGzFileService.GetUncompressJSON<WebLabSheets>(webType, ParentTVItemID);
                        Assert.NotNull(webLabSheets);
                    }
                    break;
                case WebTypeEnum.WebMikeScenarios:
                    {
                        webMikeScenarios = await ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(webType, ParentTVItemID);
                        Assert.NotNull(webMikeScenarios);
                    }
                    break;
                case WebTypeEnum.WebMonitoringOtherStatsCountry:
                    {
                        webMonitoringOtherStatsCountry = await ReadGzFileService.GetUncompressJSON<WebMonitoringOtherStatsCountry>(webType, ParentTVItemID);
                        Assert.NotNull(webMonitoringOtherStatsCountry);
                    }
                    break;
                case WebTypeEnum.WebMonitoringOtherStatsProvince:
                    {
                        webMonitoringOtherStatsProvince = await ReadGzFileService.GetUncompressJSON<WebMonitoringOtherStatsProvince>(webType, ParentTVItemID);
                        Assert.NotNull(webMonitoringOtherStatsProvince);
                    }
                    break;
                case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                    {
                        webMonitoringRoutineStatsCountry = await ReadGzFileService.GetUncompressJSON<WebMonitoringRoutineStatsCountry>(webType, ParentTVItemID);
                        Assert.NotNull(webMonitoringRoutineStatsCountry);
                    }
                    break;
                case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                    {
                        webMonitoringRoutineStatsProvince = await ReadGzFileService.GetUncompressJSON<WebMonitoringRoutineStatsProvince>(webType, ParentTVItemID);
                        Assert.NotNull(webMonitoringRoutineStatsProvince);
                    }
                    break;
                case WebTypeEnum.WebMunicipality:
                    {
                        webMunicipality = await ReadGzFileService.GetUncompressJSON<WebMunicipality>(webType, ParentTVItemID);
                        Assert.NotNull(webMunicipality);
                    }
                    break;
                case WebTypeEnum.WebMWQMRuns:
                    {
                        webMWQMRuns = await ReadGzFileService.GetUncompressJSON<WebMWQMRuns>(webType, ParentTVItemID);
                        Assert.NotNull(webMWQMRuns);
                    }
                    break;
                case WebTypeEnum.WebMWQMSamples1980_2020:
                    {
                        webMWQMSamples1980_2020 = await ReadGzFileService.GetUncompressJSON<WebMWQMSamples>(webType, ParentTVItemID);
                        Assert.NotNull(webMWQMSamples1980_2020);
                    }
                    break;
                case WebTypeEnum.WebMWQMSamples2021_2060:
                    {
                        webMWQMSamples2021_2060 = await ReadGzFileService.GetUncompressJSON<WebMWQMSamples>(webType, ParentTVItemID);
                        Assert.NotNull(webMWQMSamples2021_2060);
                    }
                    break;
                case WebTypeEnum.WebMWQMSites:
                    {
                        webMWQMSites = await ReadGzFileService.GetUncompressJSON<WebMWQMSites>(webType, ParentTVItemID);
                        Assert.NotNull(webMWQMSites);
                    }
                    break;
                case WebTypeEnum.WebPolSourceSites:
                    {
                        webPolSourceSites = await ReadGzFileService.GetUncompressJSON<WebPolSourceSites>(webType, ParentTVItemID);
                        Assert.NotNull(webPolSourceSites);
                    }
                    break;
                case WebTypeEnum.WebProvince:
                    {
                        webProvince = await ReadGzFileService.GetUncompressJSON<WebProvince>(webType, ParentTVItemID);
                        Assert.NotNull(webProvince);
                    }
                    break;
                case WebTypeEnum.WebRoot:
                    {
                        webRoot = await ReadGzFileService.GetUncompressJSON<WebRoot>(webType, ParentTVItemID);
                        Assert.NotNull(webRoot);
                    }
                    break;
                case WebTypeEnum.WebSector:
                    {
                        webSector = await ReadGzFileService.GetUncompressJSON<WebSector>(webType, ParentTVItemID);
                        Assert.NotNull(webSector);
                    }
                    break;
                case WebTypeEnum.WebSubsector:
                    {
                        webSubsector = await ReadGzFileService.GetUncompressJSON<WebSubsector>(webType, ParentTVItemID);
                        Assert.NotNull(webSubsector);
                    }
                    break;
                case WebTypeEnum.WebTideSites:
                    {
                        webTideSites = await ReadGzFileService.GetUncompressJSON<WebTideSites>(webType, ParentTVItemID);
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
