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
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllAddresses_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllAddresses);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllAddresses);
            CheckVar(actionRes, WebTypeEnum.WebAllAddresses);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllAddresses);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllAddresses);
            CheckVar(actionRes, WebTypeEnum.WebAllAddresses);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllAddresses);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllAddresses);
            CheckVar(actionRes, WebTypeEnum.WebAllAddresses);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllContacts_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllContacts);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllContacts);
            CheckVar(actionRes, WebTypeEnum.WebAllContacts);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllContacts);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllContacts);
            CheckVar(actionRes, WebTypeEnum.WebAllContacts);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllContacts);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllContacts);
            CheckVar(actionRes, WebTypeEnum.WebAllContacts);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllCountries_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllCountries);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllCountries);
            CheckVar(actionRes, WebTypeEnum.WebAllCountries);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllCountries);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllCountries);
            CheckVar(actionRes, WebTypeEnum.WebAllCountries);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllCountries);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllCountries);
            CheckVar(actionRes, WebTypeEnum.WebAllCountries);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllEmails_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllEmails);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllEmails);
            CheckVar(actionRes, WebTypeEnum.WebAllEmails);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllEmails);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllEmails);
            CheckVar(actionRes, WebTypeEnum.WebAllEmails);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllEmails);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllEmails);
            CheckVar(actionRes, WebTypeEnum.WebAllEmails);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllHelpDocs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllHelpDocs);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllHelpDocs);
            CheckVar(actionRes, WebTypeEnum.WebAllHelpDocs);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllHelpDocs);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllHelpDocs);
            CheckVar(actionRes, WebTypeEnum.WebAllHelpDocs);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllHelpDocs);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllHelpDocs);
            CheckVar(actionRes, WebTypeEnum.WebAllHelpDocs);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllMunicipalities);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMunicipalities);
            CheckVar(actionRes, WebTypeEnum.WebAllMunicipalities);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllMunicipalities);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllMunicipalities);
            CheckVar(actionRes, WebTypeEnum.WebAllMunicipalities);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllMunicipalities);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMunicipalities);
            CheckVar(actionRes, WebTypeEnum.WebAllMunicipalities);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllMWQMLookupMPNs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllMWQMLookupMPNs);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMWQMLookupMPNs);
            CheckVar(actionRes, WebTypeEnum.WebAllMWQMLookupMPNs);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllMWQMLookupMPNs);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllMWQMLookupMPNs);
            CheckVar(actionRes, WebTypeEnum.WebAllMWQMLookupMPNs);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllMWQMLookupMPNs);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMWQMLookupMPNs);
            CheckVar(actionRes, WebTypeEnum.WebAllMWQMLookupMPNs);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllPolSourceGroupings_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllPolSourceGroupings);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceGroupings);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceGroupings);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllPolSourceGroupings);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllPolSourceGroupings);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceGroupings);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllPolSourceGroupings);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceGroupings);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceGroupings);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllPolSourceSiteEffectTerms_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceSiteEffectTerms);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceSiteEffectTerms);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceSiteEffectTerms);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllProvinces_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllProvinces);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllProvinces);
            CheckVar(actionRes, WebTypeEnum.WebAllProvinces);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllProvinces);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllProvinces);
            CheckVar(actionRes, WebTypeEnum.WebAllProvinces);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllProvinces);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllProvinces);
            CheckVar(actionRes, WebTypeEnum.WebAllProvinces);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllReportTypes_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllReportTypes);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllReportTypes);
            CheckVar(actionRes, WebTypeEnum.WebAllReportTypes);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllReportTypes);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllReportTypes);
            CheckVar(actionRes, WebTypeEnum.WebAllReportTypes);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllReportTypes);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllReportTypes);
            CheckVar(actionRes, WebTypeEnum.WebAllReportTypes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllTels_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllTels);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTels);
            CheckVar(actionRes, WebTypeEnum.WebAllTels);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllTels);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllTels);
            CheckVar(actionRes, WebTypeEnum.WebAllTels);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllTels);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTels);
            CheckVar(actionRes, WebTypeEnum.WebAllTels);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllTideLocations_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllTideLocations);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTideLocations);
            CheckVar(actionRes, WebTypeEnum.WebAllTideLocations);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllTideLocations);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllTideLocations);
            CheckVar(actionRes, WebTypeEnum.WebAllTideLocations);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllTideLocations);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTideLocations);
            CheckVar(actionRes, WebTypeEnum.WebAllTideLocations);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAreaGzFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebArea);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebArea, 629);
            CheckVar(actionRes, WebTypeEnum.WebArea);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebArea);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebArea, 629);
            CheckVar(actionRes, WebTypeEnum.WebArea);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebArea);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebArea, 629);
            CheckVar(actionRes, WebTypeEnum.WebArea);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebClimateSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebClimateSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebClimateSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebClimateSites);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebClimateSites);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebClimateSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebClimateSites);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebClimateSites);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebClimateSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebClimateSites);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebCountry);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebCountry);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebCountry);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebCountry);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebCountry);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebCountry);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebDrogueRuns_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebDrogueRuns);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebDrogueRuns, 7);
            CheckVar(actionRes, WebTypeEnum.WebDrogueRuns);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebDrogueRuns);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebDrogueRuns, 7);
            CheckVar(actionRes, WebTypeEnum.WebDrogueRuns);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebDrogueRuns);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebDrogueRuns, 7);
            CheckVar(actionRes, WebTypeEnum.WebDrogueRuns);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebHydrometricSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebHydrometricSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebHydrometricSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebHydrometricSites);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebHydrometricSites);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebHydrometricSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebHydrometricSites);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebHydrometricSites);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebHydrometricSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebHydrometricSites);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebLabSheets_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebLabSheets);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebLabSheets, 635);
            CheckVar(actionRes, WebTypeEnum.WebLabSheets);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebLabSheets);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebLabSheets, 635);
            CheckVar(actionRes, WebTypeEnum.WebLabSheets);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebLabSheets);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebLabSheets, 635);
            CheckVar(actionRes, WebTypeEnum.WebLabSheets);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMikeScenarios_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMikeScenarios);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMikeScenarios, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMikeScenarios);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMikeScenarios);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMikeScenarios, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMikeScenarios);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMikeScenarios);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMikeScenarios, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMikeScenarios);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMunicipality);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMunicipality, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMunicipality);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMunicipality);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMunicipality, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMunicipality);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMunicipality);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMunicipality, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMunicipality);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMWQMRuns_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMRuns);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMRuns, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMRuns);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMRuns);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMWQMRuns, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMRuns);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMRuns);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMRuns, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMRuns);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMWQMSamples1980_2020_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMSamples1980_2020);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples1980_2020, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples1980_2020);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMSamples1980_2020);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMWQMSamples1980_2020, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples1980_2020);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMSamples1980_2020);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples1980_2020, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples1980_2020);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMWQMSamples2021_2060_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMSamples2021_2060);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples2021_2060, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples2021_2060);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMSamples2021_2060);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMWQMSamples2021_2060, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples2021_2060);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMSamples2021_2060);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples2021_2060, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples2021_2060);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMWQMSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSites);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMSites);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMWQMSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSites);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMWQMSites);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSites);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebPolSourceSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebPolSourceSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebPolSourceSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebPolSourceSites);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebPolSourceSites);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebPolSourceSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebPolSourceSites);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebPolSourceSites);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebPolSourceSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebPolSourceSites);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebProvince);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebProvince);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebProvince);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebProvince);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebProvince);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebProvince);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebRoot);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebRoot);
            CheckVar(actionRes, WebTypeEnum.WebRoot);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebRoot);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebRoot);
            CheckVar(actionRes, WebTypeEnum.WebRoot);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebRoot);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebRoot);
            CheckVar(actionRes, WebTypeEnum.WebRoot);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllSearch_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllSearch);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllSearch);
            CheckVar(actionRes, WebTypeEnum.WebAllSearch);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllSearch);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllSearch);
            CheckVar(actionRes, WebTypeEnum.WebAllSearch);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllSearch);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllSearch);
            CheckVar(actionRes, WebTypeEnum.WebAllSearch);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebSector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebSector);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSector, 633);
            CheckVar(actionRes, WebTypeEnum.WebSector);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebSector);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebSector, 633);
            CheckVar(actionRes, WebTypeEnum.WebSector);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebSector);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSector, 633);
            CheckVar(actionRes, WebTypeEnum.WebSector);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebSubsector);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSubsector, 635);
            CheckVar(actionRes, WebTypeEnum.WebSubsector);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebSubsector);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebSubsector, 635);
            CheckVar(actionRes, WebTypeEnum.WebSubsector);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebSubsector);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSubsector, 635);
            CheckVar(actionRes, WebTypeEnum.WebSubsector);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebTideSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebTideSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebTideSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebTideSites);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebTideSites);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebTideSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebTideSites);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebTideSites);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebTideSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebTideSites);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMonitoringRoutineStatsProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsProvince);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsProvince);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsProvince);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMonitoringRoutineStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsProvince);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsProvince);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsProvince);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMonitoringOtherStatsProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringOtherStatsProvince);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsProvince);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringOtherStatsProvince);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMonitoringOtherStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsProvince);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringOtherStatsProvince);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsProvince);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMonitoringRoutineStatsCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsCountry);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsCountry);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsCountry);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMonitoringRoutineStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsCountry);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsCountry);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsCountry);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMonitoringOtherStatsCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringOtherStatsCountry);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsCountry);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringOtherStatsCountry);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMonitoringOtherStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsCountry);

            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebMonitoringOtherStatsCountry);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsCountry);
        }
    }
}
