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

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllAddresses);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllAddresses);
            CheckVar(actionRes, WebTypeEnum.WebAllAddresses);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllAddresses);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllAddresses);
            CheckVar(actionRes, WebTypeEnum.WebAllAddresses);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllAddresses);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllAddresses);
            CheckVar(actionRes, WebTypeEnum.WebAllAddresses);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllContacts_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllContacts);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllContacts);
            CheckVar(actionRes, WebTypeEnum.WebAllContacts);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllContacts);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllContacts);
            CheckVar(actionRes, WebTypeEnum.WebAllContacts);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllContacts);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllContacts);
            CheckVar(actionRes, WebTypeEnum.WebAllContacts);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllCountries_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllCountries);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllCountries);
            CheckVar(actionRes, WebTypeEnum.WebAllCountries);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllCountries);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllCountries);
            CheckVar(actionRes, WebTypeEnum.WebAllCountries);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllCountries);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllCountries);
            CheckVar(actionRes, WebTypeEnum.WebAllCountries);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllEmails_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllEmails);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllEmails);
            CheckVar(actionRes, WebTypeEnum.WebAllEmails);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllEmails);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllEmails);
            CheckVar(actionRes, WebTypeEnum.WebAllEmails);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllEmails);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllEmails);
            CheckVar(actionRes, WebTypeEnum.WebAllEmails);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllHelpDocs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllHelpDocs);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllHelpDocs);
            CheckVar(actionRes, WebTypeEnum.WebAllHelpDocs);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllHelpDocs);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllHelpDocs);
            CheckVar(actionRes, WebTypeEnum.WebAllHelpDocs);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllHelpDocs);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllHelpDocs);
            CheckVar(actionRes, WebTypeEnum.WebAllHelpDocs);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllMunicipalities);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMunicipalities);
            CheckVar(actionRes, WebTypeEnum.WebAllMunicipalities);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllMunicipalities);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllMunicipalities);
            CheckVar(actionRes, WebTypeEnum.WebAllMunicipalities);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllMunicipalities);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMunicipalities);
            CheckVar(actionRes, WebTypeEnum.WebAllMunicipalities);
        
            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());      
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllMWQMLookupMPNs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllMWQMLookupMPNs);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMWQMLookupMPNs);
            CheckVar(actionRes, WebTypeEnum.WebAllMWQMLookupMPNs);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllMWQMLookupMPNs);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllMWQMLookupMPNs);
            CheckVar(actionRes, WebTypeEnum.WebAllMWQMLookupMPNs);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllMWQMLookupMPNs);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMWQMLookupMPNs);
            CheckVar(actionRes, WebTypeEnum.WebAllMWQMLookupMPNs);
        
            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllPolSourceGroupings_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllPolSourceGroupings);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceGroupings);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceGroupings);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllPolSourceGroupings);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllPolSourceGroupings);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceGroupings);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllPolSourceGroupings);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceGroupings);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceGroupings);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllPolSourceSiteEffectTerms_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceSiteEffectTerms);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceSiteEffectTerms);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            CheckVar(actionRes, WebTypeEnum.WebAllPolSourceSiteEffectTerms);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllProvinces_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllProvinces);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllProvinces);
            CheckVar(actionRes, WebTypeEnum.WebAllProvinces);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllProvinces);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllProvinces);
            CheckVar(actionRes, WebTypeEnum.WebAllProvinces);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllProvinces);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllProvinces);
            CheckVar(actionRes, WebTypeEnum.WebAllProvinces);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllReportTypes_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllReportTypes);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllReportTypes);
            CheckVar(actionRes, WebTypeEnum.WebAllReportTypes);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllReportTypes);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllReportTypes);
            CheckVar(actionRes, WebTypeEnum.WebAllReportTypes);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllReportTypes);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllReportTypes);
            CheckVar(actionRes, WebTypeEnum.WebAllReportTypes);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllTels_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllTels);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTels);
            CheckVar(actionRes, WebTypeEnum.WebAllTels);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllTels);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllTels);
            CheckVar(actionRes, WebTypeEnum.WebAllTels);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllTels);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTels);
            CheckVar(actionRes, WebTypeEnum.WebAllTels);
        
            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllTideLocations_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllTideLocations);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTideLocations);
            CheckVar(actionRes, WebTypeEnum.WebAllTideLocations);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllTideLocations);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllTideLocations);
            CheckVar(actionRes, WebTypeEnum.WebAllTideLocations);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebAllTideLocations);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTideLocations);
            CheckVar(actionRes, WebTypeEnum.WebAllTideLocations);
            
            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAreaGzFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebArea);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebArea, 629);
            CheckVar(actionRes, WebTypeEnum.WebArea);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebArea);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebArea, 629);
            CheckVar(actionRes, WebTypeEnum.WebArea);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebArea);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebArea, 629);
            CheckVar(actionRes, WebTypeEnum.WebArea);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebClimateSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebClimateSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebClimateSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebClimateSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebClimateSites);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebClimateSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebClimateSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
            SetVar(WebTypeEnum.WebClimateSites);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebClimateSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebClimateSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebCountry);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebCountry);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebCountry);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebCountry);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebCountry);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebCountry);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebDrogueRuns_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebDrogueRuns);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebDrogueRuns, 7);
            CheckVar(actionRes, WebTypeEnum.WebDrogueRuns);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebDrogueRuns);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebDrogueRuns, 7);
            CheckVar(actionRes, WebTypeEnum.WebDrogueRuns);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebDrogueRuns);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebDrogueRuns, 7);
            CheckVar(actionRes, WebTypeEnum.WebDrogueRuns);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebHydrometricSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebHydrometricSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebHydrometricSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebHydrometricSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebHydrometricSites);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebHydrometricSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebHydrometricSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebHydrometricSites);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebHydrometricSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebHydrometricSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebLabSheets_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebLabSheets);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebLabSheets, 635);
            CheckVar(actionRes, WebTypeEnum.WebLabSheets);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebLabSheets);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebLabSheets, 635);
            CheckVar(actionRes, WebTypeEnum.WebLabSheets);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebLabSheets);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebLabSheets, 635);
            CheckVar(actionRes, WebTypeEnum.WebLabSheets);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMikeScenarios_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMikeScenarios);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMikeScenarios, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMikeScenarios);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMikeScenarios);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMikeScenarios, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMikeScenarios);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMikeScenarios);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMikeScenarios, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMikeScenarios);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMunicipality);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMunicipality, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMunicipality);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMunicipality);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMunicipality, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMunicipality);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMunicipality);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMunicipality, 27764);
            CheckVar(actionRes, WebTypeEnum.WebMunicipality);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMWQMRuns_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMWQMRuns);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMRuns, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMRuns);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMWQMRuns);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMWQMRuns, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMRuns);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMWQMRuns);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMRuns, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMRuns);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMWQMSamples1980_2020_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMWQMSamples1980_2020);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples1980_2020, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples1980_2020);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMWQMSamples1980_2020);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMWQMSamples1980_2020, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples1980_2020);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMWQMSamples1980_2020);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples1980_2020, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples1980_2020);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMWQMSamples2021_2060_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMWQMSamples2021_2060);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples2021_2060, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples2021_2060);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMWQMSamples2021_2060);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMWQMSamples2021_2060, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples2021_2060);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMWQMSamples2021_2060);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples2021_2060, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSamples2021_2060);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMWQMSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMWQMSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMWQMSites);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMWQMSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMWQMSites);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebMWQMSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebPolSourceSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebPolSourceSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebPolSourceSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebPolSourceSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebPolSourceSites);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebPolSourceSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebPolSourceSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebPolSourceSites);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebPolSourceSites, 635);
            CheckVar(actionRes, WebTypeEnum.WebPolSourceSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebProvince);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebProvince);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebProvince);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebProvince);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebProvince);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebProvince);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebRoot);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebRoot);
            CheckVar(actionRes, WebTypeEnum.WebRoot);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebRoot);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebRoot);
            CheckVar(actionRes, WebTypeEnum.WebRoot);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebRoot);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebRoot);
            CheckVar(actionRes, WebTypeEnum.WebRoot);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebAllSearch_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllSearch);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllSearch);
            CheckVar(actionRes, WebTypeEnum.WebAllSearch);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllSearch);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllSearch);
            CheckVar(actionRes, WebTypeEnum.WebAllSearch);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebAllSearch);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllSearch);
            CheckVar(actionRes, WebTypeEnum.WebAllSearch);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebSector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebSector);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSector, 633);
            CheckVar(actionRes, WebTypeEnum.WebSector);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebSector);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebSector, 633);
            CheckVar(actionRes, WebTypeEnum.WebSector);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebSector);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSector, 633);
            CheckVar(actionRes, WebTypeEnum.WebSector);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebSubsector);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSubsector, 635);
            CheckVar(actionRes, WebTypeEnum.WebSubsector);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebSubsector);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebSubsector, 635);
            CheckVar(actionRes, WebTypeEnum.WebSubsector);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebSubsector);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSubsector, 635);
            CheckVar(actionRes, WebTypeEnum.WebSubsector);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebTideSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebTideSites);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebTideSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebTideSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebTideSites);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebTideSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebTideSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebTideSites);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebTideSites, 7);
            CheckVar(actionRes, WebTypeEnum.WebTideSites);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMonitoringRoutineStatsProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsProvince);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsProvince);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsProvince);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMonitoringRoutineStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsProvince);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsProvince);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsProvince);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMonitoringOtherStatsProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMonitoringOtherStatsProvince);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsProvince);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMonitoringOtherStatsProvince);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMonitoringOtherStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsProvince);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMonitoringOtherStatsProvince);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsProvince, 7);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsProvince);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMonitoringRoutineStatsCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsCountry);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsCountry);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsCountry);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMonitoringRoutineStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsCountry);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMonitoringRoutineStatsCountry);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringRoutineStatsCountry);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebMonitoringOtherStatsCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMonitoringOtherStatsCountry);
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsCountry);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMonitoringOtherStatsCountry);
            actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebMonitoringOtherStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsCountry);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            SetVar(WebTypeEnum.WebMonitoringOtherStatsCountry);
            actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsCountry, 5);
            CheckVar(actionRes, WebTypeEnum.WebMonitoringOtherStatsCountry);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
