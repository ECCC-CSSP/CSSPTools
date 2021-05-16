using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;

namespace CreateGzFileServices.Tests
{
    [Collection("Sequential")]
    public partial class CreateGzFileServiceTests
    {
        #region Variables
        DateTime LastTime = DateTime.Now;
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see under GzFileServices Setup.cs
        #endregion Constructors

        #region Tests
        private void WriteTimeSpan(Type type)
        {
            DateTime NewTime = DateTime.Now;

            TimeSpan ts = new TimeSpan(NewTime.Ticks - LastTime.Ticks);

            Process proc = Process.GetCurrentProcess();

            Console.WriteLine($"{ type.Name } --- { ts.TotalSeconds } --- { proc.PrivateMemorySize64 / (1024 * 1024) }");
            LastTime = DateTime.Now;

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(CreateGzFileService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllAddresses_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WriteTimeSpan(typeof(Address));
            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllAddresses);
            WriteTimeSpan(typeof(Address));
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllContacts_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllContacts);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllCountries_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllCountries);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllEmails_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllEmails);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllHelpDocs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllHelpDocs);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMunicipalities);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllMWQMLookupMPNs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMWQMLookupMPNs);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllPolSourceGroupings_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceGroupings);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllPolSourceSiteEffectTerms_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllProvinces_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllProvinces);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllReportTypes_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllReportTypes);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllTels_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTels);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllTideLocations_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTideLocations);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAreaGzFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebArea, 629);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebClimateSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebClimateSites, 7);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebCountry, 5);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebDrogueRuns_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebDrogueRuns, 7);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebHydrometricSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebHydrometricSites, 7);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebLabSheets_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebLabSheets, 635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebMikeScenarios_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMikeScenarios, 27764);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMunicipality, 27764);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebMWQMRuns_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMRuns, 635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebMWQMSamples1980_2020_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples1980_2020, 635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebMWQMSamples2021_2060_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples2021_2060, 635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebMWQMSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSites, 635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebPolSourceSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebPolSourceSites, 635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebProvince, 7);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebRoot);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebAllSearch_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllSearch);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebSector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSector, 633);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSubsector, 635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebTideSites_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CreateGzFileService.CreateGzFile(WebTypeEnum.WebTideSites, 7);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
