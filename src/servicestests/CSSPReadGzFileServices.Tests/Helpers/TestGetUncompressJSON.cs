using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;
using CSSPHelperModels;
using CSSPCultureServices.Resources;
using CSSPWebModels;
using Azure.Storage.Files.Shares;
using Azure;
using ManageServices;
using System.Linq;

namespace CSSPReadGzFileServices.Tests
{
    public partial class CSSPReadGzFileServiceTests
    {
        private async Task TestGetUncompressJSON(WebTypeEnum webType, int TVItemID)
        {

            switch (webType)
            {
                case WebTypeEnum.WebAllAddresses:
                    {
                        WebAllAddresses webAllAddresses = await CSSPReadGzFileService.GetUncompressJSON<WebAllAddresses>(webType, TVItemID);
                        Assert.NotNull(webAllAddresses);
                    }
                    break;
                case WebTypeEnum.WebAllContacts:
                    {
                        WebAllContacts webAllContacts = await CSSPReadGzFileService.GetUncompressJSON<WebAllContacts>(webType, TVItemID);
                        Assert.NotNull(webAllContacts);
                    }
                    break;
                case WebTypeEnum.WebAllCountries:
                    {
                        WebAllCountries webAllCountries = await CSSPReadGzFileService.GetUncompressJSON<WebAllCountries>(webType, TVItemID);
                        Assert.NotNull(webAllCountries);
                    }
                    break;
                case WebTypeEnum.WebAllEmails:
                    {
                        WebAllEmails webAllEmails = await CSSPReadGzFileService.GetUncompressJSON<WebAllEmails>(webType, TVItemID);
                        Assert.NotNull(webAllEmails);
                    }
                    break;
                case WebTypeEnum.WebAllHelpDocs:
                    {
                        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(webType, TVItemID);
                        Assert.NotNull(webAllHelpDocs);
                    }
                    break;
                case WebTypeEnum.WebAllMunicipalities:
                    {
                        WebAllMunicipalities webAllMunicipalities = await CSSPReadGzFileService.GetUncompressJSON<WebAllMunicipalities>(webType, TVItemID);
                        Assert.NotNull(webAllMunicipalities);
                    }
                    break;
                case WebTypeEnum.WebAllMWQMAnalysisReportParameters:
                    {
                        WebAllMWQMAnalysisReportParameters webAllMWQMAnalysisReportParameters = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMAnalysisReportParameters>(webType, TVItemID);
                        Assert.NotNull(webAllMWQMAnalysisReportParameters);
                    }
                    break;
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    {
                        WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(webType, TVItemID);
                        Assert.NotNull(webAllMWQMLookupMPNs);
                    }
                    break;
                case WebTypeEnum.WebAllMWQMSubsectors:
                    {
                        WebAllMWQMSubsectors webAllMWQMSubsectors = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMSubsectors>(webType, TVItemID);
                        Assert.NotNull(webAllMWQMSubsectors);
                    }
                    break;
                case WebTypeEnum.WebAllPolSourceGroupings:
                    {
                        WebAllPolSourceGroupings webAllPolSourceGroupings = await CSSPReadGzFileService.GetUncompressJSON<WebAllPolSourceGroupings>(webType, TVItemID);
                        Assert.NotNull(webAllPolSourceGroupings);
                    }
                    break;
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    {
                        WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms = await CSSPReadGzFileService.GetUncompressJSON<WebAllPolSourceSiteEffectTerms>(webType, TVItemID);
                        Assert.NotNull(webAllPolSourceSiteEffectTerms);
                    }
                    break;
                case WebTypeEnum.WebAllProvinces:
                    {
                        WebAllProvinces webAllProvinces = await CSSPReadGzFileService.GetUncompressJSON<WebAllProvinces>(webType, TVItemID);
                        Assert.NotNull(webAllProvinces);
                    }
                    break;
                case WebTypeEnum.WebAllReportTypes:
                    {
                        WebAllReportTypes webAllReportTypes = await CSSPReadGzFileService.GetUncompressJSON<WebAllReportTypes>(webType, TVItemID);
                        Assert.NotNull(webAllReportTypes);
                    }
                    break;
                case WebTypeEnum.WebAllSearch:
                    {
                        WebAllSearch webAllSearch = await CSSPReadGzFileService.GetUncompressJSON<WebAllSearch>(webType, TVItemID);
                        Assert.NotNull(webAllSearch);
                    }
                    break;
                case WebTypeEnum.WebAllTels:
                    {
                        WebAllTels webAllTels = await CSSPReadGzFileService.GetUncompressJSON<WebAllTels>(webType, TVItemID);
                        Assert.NotNull(webAllTels);
                    }
                    break;
                case WebTypeEnum.WebAllTideLocations:
                    {
                        WebAllTideLocations webAllTideLocations = await CSSPReadGzFileService.GetUncompressJSON<WebAllTideLocations>(webType, TVItemID);
                        Assert.NotNull(webAllTideLocations);
                    }
                    break;
                case WebTypeEnum.WebAllUseOfSites:
                    {
                        WebAllUseOfSites webAllUseOfSites = await CSSPReadGzFileService.GetUncompressJSON<WebAllUseOfSites>(webType, TVItemID);
                        Assert.NotNull(webAllUseOfSites);
                    }
                    break;
                case WebTypeEnum.WebArea:
                    {
                        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(webType, TVItemID);
                        Assert.NotNull(webArea);
                    }
                    break;
                case WebTypeEnum.WebClimateSites:
                    {
                        WebClimateSites webClimateSites = await CSSPReadGzFileService.GetUncompressJSON<WebClimateSites>(webType, TVItemID);
                        Assert.NotNull(webClimateSites);
                    }
                    break;
                case WebTypeEnum.WebCountry:
                    {
                        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(webType, TVItemID);
                        Assert.NotNull(webCountry);
                    }
                    break;
                case WebTypeEnum.WebDrogueRuns:
                    {
                        WebDrogueRuns webDrogueRuns = await CSSPReadGzFileService.GetUncompressJSON<WebDrogueRuns>(webType, TVItemID);
                        Assert.NotNull(webDrogueRuns);
                    }
                    break;
                case WebTypeEnum.WebHydrometricSites:
                    {
                        WebHydrometricSites webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSON<WebHydrometricSites>(webType, TVItemID);
                        Assert.NotNull(webHydrometricSites);
                    }
                    break;
                case WebTypeEnum.WebLabSheets:
                    {
                        WebLabSheets webLabSheets = await CSSPReadGzFileService.GetUncompressJSON<WebLabSheets>(webType, TVItemID);
                        Assert.NotNull(webLabSheets);
                    }
                    break;
                case WebTypeEnum.WebMikeScenarios:
                    {
                        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(webType, TVItemID);
                        Assert.NotNull(webMikeScenarios);
                    }
                    break;
                case WebTypeEnum.WebMonitoringOtherStatsCountry:
                    {
                        WebMonitoringOtherStatsCountry webMonitoringOtherStatsCountry = await CSSPReadGzFileService.GetUncompressJSON<WebMonitoringOtherStatsCountry>(webType, TVItemID);
                        Assert.NotNull(webMonitoringOtherStatsCountry);
                    }
                    break;
                case WebTypeEnum.WebMonitoringOtherStatsProvince:
                    {
                        WebMonitoringOtherStatsProvince webMonitoringOtherStatsProvince = await CSSPReadGzFileService.GetUncompressJSON<WebMonitoringOtherStatsProvince>(webType, TVItemID);
                        Assert.NotNull(webMonitoringOtherStatsProvince);
                    }
                    break;
                case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                    {
                        WebMonitoringRoutineStatsCountry webMonitoringRoutineStatsCountry = await CSSPReadGzFileService.GetUncompressJSON<WebMonitoringRoutineStatsCountry>(webType, TVItemID);
                        Assert.NotNull(webMonitoringRoutineStatsCountry);
                    }
                    break;
                case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                    {
                        WebMonitoringRoutineStatsProvince webMonitoringRoutineStatsProvince = await CSSPReadGzFileService.GetUncompressJSON<WebMonitoringRoutineStatsProvince>(webType, TVItemID);
                        Assert.NotNull(webMonitoringRoutineStatsProvince);
                    }
                    break;
                case WebTypeEnum.WebMunicipality:
                    {
                        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(webType, TVItemID);
                        Assert.NotNull(webMunicipality);
                    }
                    break;
                case WebTypeEnum.WebMWQMRuns:
                    {
                        WebMWQMRuns webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMRuns>(webType, TVItemID);
                        Assert.NotNull(webMWQMRuns);
                    }
                    break;
                case WebTypeEnum.WebMWQMSamples1980_2020:
                    {
                        WebMWQMSamples webMWQMSamples = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSamples>(webType, TVItemID);
                        Assert.NotNull(webMWQMSamples);
                    }
                    break;
                case WebTypeEnum.WebMWQMSamples2021_2060:
                    {
                        WebMWQMSamples webMWQMSamples = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSamples>(webType, TVItemID);
                        Assert.NotNull(webMWQMSamples);
                    }
                    break;
                case WebTypeEnum.WebMWQMSites:
                    {
                        WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(webType, TVItemID);
                        Assert.NotNull(webMWQMSites);
                    }
                    break;
                case WebTypeEnum.WebPolSourceSites:
                    {
                        WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(webType, TVItemID);
                        Assert.NotNull(webPolSourceSites);
                    }
                    break;
                case WebTypeEnum.WebProvince:
                    {
                        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(webType, TVItemID);
                        Assert.NotNull(webProvince);
                    }
                    break;
                case WebTypeEnum.WebRoot:
                    {
                        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(webType, TVItemID);
                        Assert.NotNull(webRoot);
                    }
                    break;
                case WebTypeEnum.WebSector:
                    {
                        WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(webType, TVItemID);
                        Assert.NotNull(webSector);
                    }
                    break;
                case WebTypeEnum.WebSubsector:
                    {
                        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(webType, TVItemID);
                        Assert.NotNull(webSubsector);
                    }
                    break;
                case WebTypeEnum.WebTideSites:
                    {
                        WebTideSites webTideSites = await CSSPReadGzFileService.GetUncompressJSON<WebTideSites>(webType, TVItemID);
                        Assert.NotNull(webTideSites);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
