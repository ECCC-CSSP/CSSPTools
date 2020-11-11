/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPWebAPIsLocal.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Collections.Generic;
using System.Text.Json;
using CSSPWebModels;

namespace CSSPWebAPIsLocal.ReadController.Tests
{
    public partial class CSSPWebAPIsLocalReadControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebArea_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebArea;
            int TVItemID = 629;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebArea webArea = JsonSerializer.Deserialize<WebArea>(responseContent);
                Assert.NotNull(webArea);
                Assert.NotNull(webArea.TVItemModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebClimateDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateDataValue;
            int TVItemID = 229465;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebClimateDataValue webClimateDataValue = JsonSerializer.Deserialize<WebClimateDataValue>(responseContent);
                Assert.NotNull(webClimateDataValue);
                Assert.NotNull(webClimateDataValue.ClimateDataValueList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebClimateSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebClimateSite webClimateSite = JsonSerializer.Deserialize<WebClimateSite>(responseContent);
                Assert.NotNull(webClimateSite);
                Assert.NotNull(webClimateSite.ClimateSiteList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebContact_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebContact;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebContact webContact = JsonSerializer.Deserialize<WebContact>(responseContent);
                Assert.NotNull(webContact);
                Assert.NotNull(webContact.ContactList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebCountry;
            int TVItemID = 5;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebCountry webCountry = JsonSerializer.Deserialize<WebCountry>(responseContent);
                Assert.NotNull(webCountry);
                Assert.NotNull(webCountry.TVItemProvinceList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebDrogueRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebDrogueRun;
            int TVItemID = 556;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebDrogueRun webDrogueRun = JsonSerializer.Deserialize<WebDrogueRun>(responseContent);
                Assert.NotNull(webDrogueRun);
                Assert.NotNull(webDrogueRun.DrogueRunList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebHelpDoc_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHelpDoc;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebHelpDoc webHelpDoc = JsonSerializer.Deserialize<WebHelpDoc>(responseContent);
                Assert.NotNull(webHelpDoc);
                Assert.NotNull(webHelpDoc.HelpDocList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebHydrometricDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricDataValue;
            int TVItemID = 51705;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebHydrometricDataValue webHydrometricDataValue = JsonSerializer.Deserialize<WebHydrometricDataValue>(responseContent);
                Assert.NotNull(webHydrometricDataValue);
                Assert.NotNull(webHydrometricDataValue.HydrometricDataValueList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebHydrometricSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebHydrometricSite webHydrometricSite = JsonSerializer.Deserialize<WebHydrometricSite>(responseContent);
                Assert.NotNull(webHydrometricSite);
                Assert.NotNull(webHydrometricSite.HydrometricSiteList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebMikeScenario_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMikeScenario;
            int TVItemID = 12281;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMikeScenario WebMikeScenario = JsonSerializer.Deserialize<WebMikeScenario>(responseContent);
                Assert.NotNull(WebMikeScenario);
                Assert.NotNull(WebMikeScenario.MikeScenario);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMunicipalities;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMunicipalities webMunicipalities = JsonSerializer.Deserialize<WebMunicipalities>(responseContent);
                Assert.NotNull(webMunicipalities);
                Assert.NotNull(webMunicipalities.TVItemMunicipalityList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMunicipality;
            int TVItemID = 12110;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMunicipality webMunicipality = JsonSerializer.Deserialize<WebMunicipality>(responseContent);
                Assert.NotNull(webMunicipality);
                Assert.NotNull(webMunicipality.InfrastructureModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebMWQMLookupMPN_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMLookupMPN;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMLookupMPN webMWQMLookupMPN = JsonSerializer.Deserialize<WebMWQMLookupMPN>(responseContent);
                Assert.NotNull(webMWQMLookupMPN);
                Assert.NotNull(webMWQMLookupMPN.MWQMLookupMPNList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebMWQMRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMRun;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMRun webMWQMRun = JsonSerializer.Deserialize<WebMWQMRun>(responseContent);
                Assert.NotNull(webMWQMRun);
                Assert.NotNull(webMWQMRun.MWQMRunModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_Web10YearOfSample1980_1989_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMSample webMWQMSample = JsonSerializer.Deserialize<WebMWQMSample>(responseContent);
                Assert.NotNull(webMWQMSample);
                Assert.NotNull(webMWQMSample.MWQMSampleList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_Web10YearOfSample1990_1999_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1990;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMSample webMWQMSample = JsonSerializer.Deserialize<WebMWQMSample>(responseContent);
                Assert.NotNull(webMWQMSample);
                Assert.NotNull(webMWQMSample.MWQMSampleList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_Web10YearOfSample2000_2010_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2000;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMSample webMWQMSample = JsonSerializer.Deserialize<WebMWQMSample>(responseContent);
                Assert.NotNull(webMWQMSample);
                Assert.NotNull(webMWQMSample.MWQMSampleList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_Web10YearOfSample2010_2020_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMSample webMWQMSample = JsonSerializer.Deserialize<WebMWQMSample>(responseContent);
                Assert.NotNull(webMWQMSample);
                Assert.NotNull(webMWQMSample.MWQMSampleList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_Web10YearOfSample2020_2030_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2020;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMSample webMWQMSample = JsonSerializer.Deserialize<WebMWQMSample>(responseContent);
                Assert.NotNull(webMWQMSample);
                Assert.NotNull(webMWQMSample.MWQMSampleList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_Web10YearOfSample2030_2040_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2030;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMSample webMWQMSample = JsonSerializer.Deserialize<WebMWQMSample>(responseContent);
                Assert.NotNull(webMWQMSample);
                Assert.NotNull(webMWQMSample.MWQMSampleList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_Web10YearOfSample2040_2050_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2040;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMSample webMWQMSample = JsonSerializer.Deserialize<WebMWQMSample>(responseContent);
                Assert.NotNull(webMWQMSample);
                Assert.NotNull(webMWQMSample.MWQMSampleList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_Web10YearOfSample2050_2060_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2050;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMSample webMWQMSample = JsonSerializer.Deserialize<WebMWQMSample>(responseContent);
                Assert.NotNull(webMWQMSample);
                Assert.NotNull(webMWQMSample.MWQMSampleList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebMWQMSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMSite webMWQMSite = JsonSerializer.Deserialize<WebMWQMSite>(responseContent);
                Assert.NotNull(webMWQMSite);
                Assert.NotNull(webMWQMSite.MWQMSiteModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebPolSourceGrouping_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceGrouping;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebPolSourceGrouping webPolSourceGrouping = JsonSerializer.Deserialize<WebPolSourceGrouping>(responseContent);
                Assert.NotNull(webPolSourceGrouping);
                Assert.NotNull(webPolSourceGrouping.PolSourceGroupingList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebPolSourceSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebPolSourceSite webPolSourceSite = JsonSerializer.Deserialize<WebPolSourceSite>(responseContent);
                Assert.NotNull(webPolSourceSite);
                Assert.NotNull(webPolSourceSite.PolSourceSiteModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebPolSourceSiteEffectTerm_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSiteEffectTerm;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebPolSourceSiteEffectTerm webPolSourceSiteEffectTerm = JsonSerializer.Deserialize<WebPolSourceSiteEffectTerm>(responseContent);
                Assert.NotNull(webPolSourceSiteEffectTerm);
                Assert.NotNull(webPolSourceSiteEffectTerm.PolSourceSiteEffectTermList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebProvince;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebProvince webProvince = JsonSerializer.Deserialize<WebProvince>(responseContent);
                Assert.NotNull(webProvince);
                Assert.NotNull(webProvince.SamplingPlanList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebReportType_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebReportType;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebReportType webReportType = JsonSerializer.Deserialize<WebReportType>(responseContent);
                Assert.NotNull(webReportType);
                Assert.NotNull(webReportType.ReportTypeModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebRoot;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebRoot webRoot = JsonSerializer.Deserialize<WebRoot>(responseContent);
                Assert.NotNull(webRoot);
                Assert.NotNull(webRoot.TVItemModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebSamplingPlan_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSamplingPlan;
            int TVItemID = 8; // TVItemID is SamplingPlanID in this case
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebSamplingPlan webSamplingPlan = JsonSerializer.Deserialize<WebSamplingPlan>(responseContent);
                Assert.NotNull(webSamplingPlan);
                Assert.NotNull(webSamplingPlan.SamplingPlanModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebSector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSector;
            int TVItemID = 633;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebSector webSector = JsonSerializer.Deserialize<WebSector>(responseContent);
                Assert.NotNull(webSector);
                Assert.NotNull(webSector.TVItemModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebSubsector webSubsector = JsonSerializer.Deserialize<WebSubsector>(responseContent);
                Assert.NotNull(webSubsector);
                Assert.NotNull(webSubsector.TVItemModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebTideLocation_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebTideLocation;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebTideLocation webTideLocation = JsonSerializer.Deserialize<WebTideLocation>(responseContent);
                Assert.NotNull(webTideLocation);
                Assert.NotNull(webTideLocation.TideLocationList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllTVItem_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTVItem;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllTVItem webAllTVItem = JsonSerializer.Deserialize<WebAllTVItem>(responseContent);
                Assert.NotNull(webAllTVItem);
                Assert.NotNull(webAllTVItem.TVItemList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllTVItemLanguage_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTVItemLanguage;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }/{ (int)webTypeYear }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllTVItemLanguage webAllTVItemLanguage = JsonSerializer.Deserialize<WebAllTVItemLanguage>(responseContent);
                Assert.NotNull(webAllTVItemLanguage);
                Assert.NotNull(webAllTVItemLanguage.TVItemLanguageList);
            }
        }
        #endregion Tests

        #region FunctionPrivate
        #endregion Functions private
    }
}
