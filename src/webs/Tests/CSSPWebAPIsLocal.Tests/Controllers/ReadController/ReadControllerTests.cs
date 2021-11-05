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
        public async Task ReadController_WebAllAddresses_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllAddresses webAllAddresses = JsonSerializer.Deserialize<WebAllAddresses>(responseContent);
                Assert.NotNull(webAllAddresses);
                //Assert.NotNull(webAllAddresses.AddressModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllContacts_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllContacts;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllContacts webAllContacts = JsonSerializer.Deserialize<WebAllContacts>(responseContent);
                Assert.NotNull(webAllContacts);
                Assert.NotNull(webAllContacts.ContactModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllCountries_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllCountries;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllCountries webAllCountries = JsonSerializer.Deserialize<WebAllCountries>(responseContent);
                Assert.NotNull(webAllCountries);
                //Assert.NotNull(webAllCountries.TVItemModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllEmails_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllEmails;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllEmails webAllEmails = JsonSerializer.Deserialize<WebAllEmails>(responseContent);
                Assert.NotNull(webAllEmails);
                //Assert.NotNull(webAllEmails.EmailModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllHelpDocs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllHelpDocs;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllHelpDocs webAllHelpDocs = JsonSerializer.Deserialize<WebAllHelpDocs>(responseContent);
                Assert.NotNull(webAllHelpDocs);
                Assert.NotNull(webAllHelpDocs.HelpDocList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllMunicipalities;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllMunicipalities webAllMunicipalities = JsonSerializer.Deserialize<WebAllMunicipalities>(responseContent);
                Assert.NotNull(webAllMunicipalities);
                //Assert.NotNull(webAllMunicipalities.TVItemModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllMWQMLookupMPNs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllMWQMLookupMPNs;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = JsonSerializer.Deserialize<WebAllMWQMLookupMPNs>(responseContent);
                Assert.NotNull(webAllMWQMLookupMPNs);
                Assert.NotNull(webAllMWQMLookupMPNs.MWQMLookupMPNList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllPolSourceGroupings_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceGroupings;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllPolSourceGroupings webAllPolSourceGroupings = JsonSerializer.Deserialize<WebAllPolSourceGroupings>(responseContent);
                Assert.NotNull(webAllPolSourceGroupings);
                Assert.NotNull(webAllPolSourceGroupings.PolSourceGroupingModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllPolSourceSiteEffectTerms_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceSiteEffectTerms;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms = JsonSerializer.Deserialize<WebAllPolSourceSiteEffectTerms>(responseContent);
                Assert.NotNull(webAllPolSourceSiteEffectTerms);
                Assert.NotNull(webAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllProvinces_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllProvinces;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllProvinces webAllProvinces = JsonSerializer.Deserialize<WebAllProvinces>(responseContent);
                Assert.NotNull(webAllProvinces);
                //Assert.NotNull(webAllProvinces.TVItemModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllReportTypes_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllReportTypes;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllReportTypes webAllReportTypes = JsonSerializer.Deserialize<WebAllReportTypes>(responseContent);
                Assert.NotNull(webAllReportTypes);
                Assert.NotNull(webAllReportTypes.ReportTypeModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllTels_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTels;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllTels webAllTels = JsonSerializer.Deserialize<WebAllTels>(responseContent);
                Assert.NotNull(webAllTels);
                //Assert.NotNull(webAllTels.TelModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllTideLocations_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTideLocations;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllTideLocations webAllTideLocations = JsonSerializer.Deserialize<WebAllTideLocations>(responseContent);
                Assert.NotNull(webAllTideLocations);
                Assert.NotNull(webAllTideLocations.TideLocationList);
            }
        }
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task ReadController_WebAllTVItemLanguages1980_2020_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllTVItemLanguages1980_2020;

        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
        //        var response = await httpClient.GetAsync(url);
        //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //        string responseContent = await response.Content.ReadAsStringAsync();
        //        WebAllTVItemLanguages webAllTVItemLanguages = JsonSerializer.Deserialize<WebAllTVItemLanguages>(responseContent);
        //        Assert.NotNull(webAllTVItemLanguages);
        //        Assert.NotNull(webAllTVItemLanguages.TVItemLanguageList);
        //    }
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task ReadController_WebAllTVItemLanguages2021_2060_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllTVItemLanguages2021_2060;

        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
        //        var response = await httpClient.GetAsync(url);
        //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //        string responseContent = await response.Content.ReadAsStringAsync();
        //        WebAllTVItemLanguages webAllTVItemLanguages = JsonSerializer.Deserialize<WebAllTVItemLanguages>(responseContent);
        //        Assert.NotNull(webAllTVItemLanguages);
        //        Assert.NotNull(webAllTVItemLanguages.TVItemLanguageList);
        //    }
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task ReadController_WebAllTVItems1980_2020_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllTVItems1980_2020;

        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
        //        var response = await httpClient.GetAsync(url);
        //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //        string responseContent = await response.Content.ReadAsStringAsync();
        //        WebAllTVItems webAllTVItems = JsonSerializer.Deserialize<WebAllTVItems>(responseContent);
        //        Assert.NotNull(webAllTVItems);
        //        Assert.NotNull(webAllTVItems.TVItemList);
        //    }
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task ReadController_WebAllTVItems2021_2060_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllTVItems2021_2060;

        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
        //        var response = await httpClient.GetAsync(url);
        //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //        string responseContent = await response.Content.ReadAsStringAsync();
        //        WebAllTVItems webAllTVItems = JsonSerializer.Deserialize<WebAllTVItems>(responseContent);
        //        Assert.NotNull(webAllTVItems);
        //        Assert.NotNull(webAllTVItems.TVItemList);
        //    }
        //}
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebArea_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebArea;
            int TVItemID = 629;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
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
        public async Task ReadController_WebClimateSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateSites;
            int TVItemID = 7;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebClimateSites webClimateSite = JsonSerializer.Deserialize<WebClimateSites>(responseContent);
                Assert.NotNull(webClimateSite);
                Assert.NotNull(webClimateSite.ClimateSiteModelList);
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

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebCountry webCountry = JsonSerializer.Deserialize<WebCountry>(responseContent);
                Assert.NotNull(webCountry);
                Assert.NotNull(webCountry.TVItemModelProvinceList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebHydrometricSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricSites;
            int TVItemID = 7;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebHydrometricSites webHydrometricSite = JsonSerializer.Deserialize<WebHydrometricSites>(responseContent);
                Assert.NotNull(webHydrometricSite);
                Assert.NotNull(webHydrometricSite.HydrometricSiteModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebMikeScenarios_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;
            int TVItemID = 27764;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMikeScenarios webMikeScenarios = JsonSerializer.Deserialize<WebMikeScenarios>(responseContent);
                Assert.NotNull(webMikeScenarios);
                Assert.NotNull(webMikeScenarios.MikeScenarioModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebMWQMRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMRuns;
            int TVItemID = 635;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMRuns webMWQMRun = JsonSerializer.Deserialize<WebMWQMRuns>(responseContent);
                Assert.NotNull(webMWQMRun);
                Assert.NotNull(webMWQMRun.MWQMRunModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebMWQMSamples1980_2020_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSamples1980_2020;
            int TVItemID = 635;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMSamples webMWQMSample = JsonSerializer.Deserialize<WebMWQMSamples>(responseContent);
                Assert.NotNull(webMWQMSample);
                Assert.NotNull(webMWQMSample.MWQMSampleModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_Web10YearOfSample1990_1999_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSamples2021_2060;
            int TVItemID = 635;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMSamples webMWQMSample = JsonSerializer.Deserialize<WebMWQMSamples>(responseContent);
                Assert.NotNull(webMWQMSample);
                Assert.NotNull(webMWQMSample.MWQMSampleModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebMWQMSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSites;
            int TVItemID = 635;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebMWQMSites webMWQMSite = JsonSerializer.Deserialize<WebMWQMSites>(responseContent);
                Assert.NotNull(webMWQMSite);
                Assert.NotNull(webMWQMSite.MWQMSiteModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebPolSourceSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSites;
            int TVItemID = 635;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebPolSourceSites webPolSourceSite = JsonSerializer.Deserialize<WebPolSourceSites>(responseContent);
                Assert.NotNull(webPolSourceSite);
                Assert.NotNull(webPolSourceSite.PolSourceSiteModelList);
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

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebProvince webProvince = JsonSerializer.Deserialize<WebProvince>(responseContent);
                Assert.NotNull(webProvince);
                Assert.NotNull(webProvince.TVItemModelAreaList);
                Assert.NotNull(webProvince.SamplingPlanModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebRoot;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebRoot webRoot = JsonSerializer.Deserialize<WebRoot>(responseContent);
                Assert.NotNull(webRoot);
                Assert.NotNull(webRoot.TVItemModelCountryList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebAllSearch_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllSearch;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebAllSearch WebAllSearch = JsonSerializer.Deserialize<WebAllSearch>(responseContent);
                Assert.NotNull(WebAllSearch);
                //Assert.NotNull(WebAllSearch.TVItemModelList);
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

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebSector webSector = JsonSerializer.Deserialize<WebSector>(responseContent);
                Assert.NotNull(webSector);
                Assert.NotNull(webSector.TVItemModelSubsectorList);
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

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebSubsector webSubsector = JsonSerializer.Deserialize<WebSubsector>(responseContent);
                Assert.NotNull(webSubsector);
                Assert.NotNull(webSubsector.ClassificationModelList);
            }
        }
        [Theory(Skip = "not implemented yet")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadController_WebTideSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebTideSites;
            int TVItemID = 7;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Read/{ webType }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                WebTideSites webTideSite = JsonSerializer.Deserialize<WebTideSites>(responseContent);
                Assert.NotNull(webTideSite);
                Assert.NotNull(webTideSite.TideSiteModelList);
            }
        }
        #endregion Tests

        #region FunctionPrivate
        #endregion Functions private
    }
}
