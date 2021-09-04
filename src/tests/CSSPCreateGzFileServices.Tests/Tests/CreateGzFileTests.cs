using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;
using System.Reflection;
using ManageServices;
using System.Collections.Generic;
using System.Linq;

namespace CreateGzFileServices.Tests
{
    public partial class CreateGzFileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see under GzFileServices Setup.cs
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllAddresses_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllAddresses);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllAddresses);
            CheckVar(actionRes, WebTypeEnum.WebAllAddresses);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllContacts_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllContacts);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllContacts);
            CheckVar(actionRes, WebTypeEnum.WebAllContacts);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllCountries_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllCountries);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllCountries);
            CheckVar(actionRes, WebTypeEnum.WebAllCountries);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllEmails_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllEmails);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllEmails);
            CheckVar(actionRes, WebTypeEnum.WebAllEmails);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllHelpDocs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllHelpDocs);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllHelpDocs);
            CheckVar(actionRes, WebTypeEnum.WebAllHelpDocs);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllMunicipalities);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMunicipalities);
            CheckVar(actionRes, WebTypeEnum.WebAllMunicipalities);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllMWQMLookupMPNs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllMWQMLookupMPNs);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMWQMLookupMPNs);
            CheckVar(actionRes, WebTypeEnum.WebAllMWQMLookupMPNs);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllPolSourceGroupings_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllPolSourceGroupings);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceGroupings);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceGroupings);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllPolSourceSiteEffectTerms_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceSiteEffectTerms);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllProvinces_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllProvinces);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllProvinces);
            CheckVar(actionRes, WebTypeEnum.WebAllProvinces);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllReportTypes_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllReportTypes);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllReportTypes);
            CheckVar(actionRes, WebTypeEnum.WebAllReportTypes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllTels_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllTels);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTels);
            CheckVar(actionRes, WebTypeEnum.WebAllTels);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllTideLocations_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllTideLocations);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTideLocations);
            CheckVar(actionRes, WebTypeEnum.WebAllTideLocations);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAreaGzFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebArea);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebArea, 629);
            CheckVar(actionRes, WebTypeEnum.WebArea);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebClimateSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebClimateSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebClimateSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebClimateSites);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebCountry);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebCountry);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebDrogueRuns_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebDrogueRuns);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebDrogueRuns, 7);
            CheckVar(actionRes, WebTypeEnum.WebDrogueRuns);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebHydrometricSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebHydrometricSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebHydrometricSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebHydrometricSites);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebLabSheets_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebLabSheets);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebLabSheets, 635);
            CheckVar(actionRes, WebTypeEnum.WebLabSheets);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebMikeScenarios_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMikeScenarios);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMikeScenarios, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMikeScenarios);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMunicipality);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMunicipality, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMunicipality);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebMWQMRuns_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMRuns);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMRuns, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMRuns);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebMWQMSamples1980_2020_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMSamples1980_2020);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples1980_2020, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples1980_2020);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebMWQMSamples2021_2060_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMSamples2021_2060);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples2021_2060, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples2021_2060);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebMWQMSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSites);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebPolSourceSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebPolSourceSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebPolSourceSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebPolSourceSites);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebProvince);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebProvince);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebRoot);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebRoot);
            CheckVar(actionRes, WebTypeEnum.WebRoot);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebAllSearch_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllSearch);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllSearch);
            CheckVar(actionRes, WebTypeEnum.WebAllSearch);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebSector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebSector);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSector, 633);
            CheckVar(actionRes, WebTypeEnum.WebSector);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebSubsector);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSubsector, 635);
            CheckVar(actionRes, WebTypeEnum.WebSubsector);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebTideSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebTideSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebTideSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebTideSites);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebMonitoringRoutineStatsProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsProvince);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsProvince);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebMonitoringOtherStatsProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringOtherStatsProvince);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsProvince);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebMonitoringRoutineStatsCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsCountry);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsCountry);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_WebMonitoringOtherStatsCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringOtherStatsCountry);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsCountry);
        }
        #endregion Tests 

        #region Functions private

        #endregion Functions private
    }
}
