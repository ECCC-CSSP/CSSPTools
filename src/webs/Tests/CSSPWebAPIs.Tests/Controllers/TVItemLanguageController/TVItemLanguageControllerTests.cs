/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPWebAPIs.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Collections.Generic;
using System.Text.Json;

namespace CSSPWebAPIs.TVItemLanguageManualController.Tests
{
    public partial class CSSPWebAPIsTVItemLanguageManualControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        //public CSSPWebAPIsTVItemLanguageManualControllerTests()
        //{
        // see setup
        //}
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLanguageController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(contact);
            Assert.True(contact.ContactTVItemID > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLanguageController_GetTVItemLanguageStartDateList_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                string url = $"{ CSSPAzureUrl }api/{ culture }/TVItemLanguage/GetTVItemLanguageStartDateList/2020/5/26";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                List<TVItemLanguage> tvItemLanguageList = JsonSerializer.Deserialize<List<TVItemLanguage>>(responseContent);
                Assert.NotNull(tvItemLanguageList);
                Assert.True(tvItemLanguageList.Count > 0);
            }
        }
        #endregion Functions private
    }
}
