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
                case WebTypeEnum.WebRoot:
                    {
                        ReadGzFileService.webAppLoaded.WebRoot = await ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);
                    }
                    break;
                case WebTypeEnum.WebAllSearch:
                    {
                        ReadGzFileService.webAppLoaded.WebAllSearch = await ReadGzFileService.GetUncompressJSON<WebAllSearch>(WebTypeEnum.WebAllSearch, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllSearch);
                    }
                    break;
                case WebTypeEnum.WebCountry:
                    {
                        ReadGzFileService.webAppLoaded.WebCountry = await ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebCountry);
                    }
                    break;
                case WebTypeEnum.WebProvince:
                    {
                        ReadGzFileService.webAppLoaded.WebProvince = await ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebProvince);
                    }
                    break;
                case WebTypeEnum.WebArea:
                    {
                        ReadGzFileService.webAppLoaded.WebArea = await ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebArea);
                    }
                    break;
                case WebTypeEnum.WebSector:
                    {
                        ReadGzFileService.webAppLoaded.WebSector = await ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebSector);
                    }
                    break;
                case WebTypeEnum.WebSubsector:
                    {
                        ReadGzFileService.webAppLoaded.WebSubsector = await ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);
                    }
                    break;
                case WebTypeEnum.WebMunicipality:
                    {
                        ReadGzFileService.webAppLoaded.WebMunicipality = await ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebMunicipality);
                    }
                    break;
                case WebTypeEnum.WebMWQMSamples1980_2020:
                    {
                        ReadGzFileService.webAppLoaded.WebMWQMSamples1980_2020 = await ReadGzFileService.GetUncompressJSON<WebMWQMSamples>(WebTypeEnum.WebMWQMSamples1980_2020, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebMWQMSamples1980_2020);
                    }
                    break;
                case WebTypeEnum.WebMWQMSamples2021_2060:
                    {
                        ReadGzFileService.webAppLoaded.WebMWQMSamples2021_2060 = await ReadGzFileService.GetUncompressJSON<WebMWQMSamples>(WebTypeEnum.WebMWQMSamples2021_2060, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebMWQMSamples2021_2060);
                    }
                    break;
                case WebTypeEnum.WebMWQMRuns:
                    {
                        ReadGzFileService.webAppLoaded.WebMWQMRuns = await ReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebMWQMRuns);
                    }
                    break;
                case WebTypeEnum.WebMWQMSites:
                    {
                        ReadGzFileService.webAppLoaded.WebMWQMSites = await ReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebMWQMSites);
                    }
                    break;
                case WebTypeEnum.WebAllContacts:
                    {
                        ReadGzFileService.webAppLoaded.WebAllContacts = await ReadGzFileService.GetUncompressJSON<WebAllContacts>(WebTypeEnum.WebAllContacts, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllContacts);
                    }
                    break;
                case WebTypeEnum.WebClimateSites:
                    {
                        ReadGzFileService.webAppLoaded.WebClimateSites = await ReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebClimateSites);
                    }
                    break;
                case WebTypeEnum.WebHydrometricSites:
                    {
                        ReadGzFileService.webAppLoaded.WebHydrometricSites = await ReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebHydrometricSites);
                    }
                    break;
                case WebTypeEnum.WebDrogueRuns:
                    {
                        ReadGzFileService.webAppLoaded.WebDrogueRuns = await ReadGzFileService.GetUncompressJSON<WebDrogueRuns>(WebTypeEnum.WebDrogueRuns, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebDrogueRuns);
                    }
                    break;
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    {
                        ReadGzFileService.webAppLoaded.WebAllMWQMLookupMPNs = await ReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllMWQMLookupMPNs);
                    }
                    break;
                case WebTypeEnum.WebAllHelpDocs:
                    {
                        ReadGzFileService.webAppLoaded.WebAllHelpDocs = await ReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllHelpDocs);
                    }
                    break;
                case WebTypeEnum.WebAllTideLocations:
                    {
                        ReadGzFileService.webAppLoaded.WebAllTideLocations = await ReadGzFileService.GetUncompressJSON<WebAllTideLocations>(WebTypeEnum.WebAllTideLocations, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllTideLocations);
                    }
                    break;
                case WebTypeEnum.WebPolSourceSites:
                    {
                        ReadGzFileService.webAppLoaded.WebPolSourceSites = await ReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebPolSourceSites);
                    }
                    break;
                case WebTypeEnum.WebAllPolSourceGroupings:
                    {
                        ReadGzFileService.webAppLoaded.WebAllPolSourceGroupings = await ReadGzFileService.GetUncompressJSON<WebAllPolSourceGroupings>(WebTypeEnum.WebAllPolSourceGroupings, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllPolSourceGroupings);
                    }
                    break;
                case WebTypeEnum.WebAllReportTypes:
                    {
                        ReadGzFileService.webAppLoaded.WebAllReportTypes = await ReadGzFileService.GetUncompressJSON<WebAllReportTypes>(WebTypeEnum.WebAllReportTypes, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllReportTypes);
                    }
                    break;
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    {
                        ReadGzFileService.webAppLoaded.WebAllPolSourceSiteEffectTerms = await ReadGzFileService.GetUncompressJSON<WebAllPolSourceSiteEffectTerms>(WebTypeEnum.WebAllPolSourceSiteEffectTerms, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllPolSourceSiteEffectTerms);
                    }
                    break;
                case WebTypeEnum.WebAllMunicipalities:
                    {
                        ReadGzFileService.webAppLoaded.WebAllMunicipalities = await ReadGzFileService.GetUncompressJSON<WebAllMunicipalities>(WebTypeEnum.WebAllMunicipalities, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllMunicipalities);
                    }
                    break;
                case WebTypeEnum.WebAllProvinces:
                    {
                        ReadGzFileService.webAppLoaded.WebAllProvinces = await ReadGzFileService.GetUncompressJSON<WebAllProvinces>(WebTypeEnum.WebAllProvinces, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllProvinces);
                    }
                    break;
                case WebTypeEnum.WebAllCountries:
                    {
                        ReadGzFileService.webAppLoaded.WebAllCountries = await ReadGzFileService.GetUncompressJSON<WebAllCountries>(WebTypeEnum.WebAllCountries, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllCountries);
                    }
                    break;
                case WebTypeEnum.WebAllAddresses:
                    {
                        ReadGzFileService.webAppLoaded.WebAllAddresses = await ReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllAddresses);
                    }
                    break;
                case WebTypeEnum.WebAllEmails:
                    {
                        ReadGzFileService.webAppLoaded.WebAllEmails = await ReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllEmails);
                    }
                    break;
                case WebTypeEnum.WebAllTels:
                    {
                        ReadGzFileService.webAppLoaded.WebAllTels = await ReadGzFileService.GetUncompressJSON<WebAllTels>(WebTypeEnum.WebAllTels, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllTels);
                    }
                    break;
                case WebTypeEnum.WebTideSites:
                    {
                        ReadGzFileService.webAppLoaded.WebTideSites = await ReadGzFileService.GetUncompressJSON<WebTideSites>(WebTypeEnum.WebTideSites, ParentTVItemID);
                        Assert.NotNull(ReadGzFileService.webAppLoaded.WebTideSites);
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
