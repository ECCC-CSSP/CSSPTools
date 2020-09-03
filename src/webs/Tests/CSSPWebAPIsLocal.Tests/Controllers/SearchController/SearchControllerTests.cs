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
using CSSPWebAPIsLocal.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Collections.Generic;
using System.Text.Json;

namespace SearchControllers.Tests
{
    public partial class SearchControllerTests
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
        public async Task SearchController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(CSSPDBSearchService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SearchController_Search_1_Term_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoginTest();
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            await SearchTest(culture, "Canada", 0);
        }
        #endregion Tests

        #region FunctionPrivate
        private async Task SearchTest(string culture, string SearchTerm, int TVItemID)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

                string url = $"{ CSSPLocalUrl }api/{ culture }/Search/{ SearchTerm }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                List<TVItemLanguage> tvItemLanguageList = JsonSerializer.Deserialize<List<TVItemLanguage>>(response.Content.ReadAsStringAsync().Result);
            }
        }
        #endregion Functions private
    }
}
