/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using TestHelpers.Tests;
using CSSPWebAPIs.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace CreateGzFileControllers.Tests
{
    public class CreateGzFileControllerTests : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CreateGzFileControllerTests() : base()
        {
        }
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(ContactService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(GzFileService);
            Assert.NotNull(ReadController);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebArea_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebArea;
            int TVItemID = 629;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebClimateDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateDataValue;
            int TVItemID = 229465;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebClimateSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebContact_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebContact;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebCountry;
            int TVItemID = 5;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebDrogueRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebDrogueRun;
            int TVItemID = 556;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebHelpDoc_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHelpDoc;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebHydrometricDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricDataValue;
            int TVItemID = 51705;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebHydrometricSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMikeScenario_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMikeScenario;
            int TVItemID = 12281;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMunicipalities;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMunicipality;
            int TVItemID = 12110;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMWQMLookupMPN_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMLookupMPN;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMWQMRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMRun;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMWQMSample_1980_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMWQMSample_1990_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1990;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMWQMSample_2000_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2000;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMWQMSample_2010_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMWQMSample_2020_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2020;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMWQMSample_2030_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2030;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMWQMSample_2040_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2040;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMWQMSample_2050_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2050;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebMWQMSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebPolSourceGrouping_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceGrouping;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebPolSourceSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebProvince;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebReportType_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebReportType;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebRoot;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebSamplingPlan_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSamplingPlan;
            int TVItemID = 8;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebSector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSector;
            int TVItemID = 633;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileController_WebTideLocation_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebTideLocation;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            string url = "https://localhost:44342/api/" + culture + $"/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
