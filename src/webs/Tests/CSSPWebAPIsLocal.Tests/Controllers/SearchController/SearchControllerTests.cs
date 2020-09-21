/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
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

namespace CSSPWebAPIsLocal.SearchController.Tests
{
    public partial class CSSPWebAPIsLocalSearchControllerTests
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
            Assert.NotNull(LocalService);
            Assert.NotNull(LocalService.LoggedInContactInfo);
            Assert.NotNull(LocalService.LoggedInContactInfo.LoggedInContact);
            Assert.NotNull(CSSPDBSearchService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SearchController_Search_Term_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> SearchTermList = new List<string>()
            {
                "Canada", "canada", "User1", "Charles", "Charles LeBlanc", "New Brunswick",
                "BIG TRACADIE RIVER", "BIG TRACADIE RIVER AT",
                "BIG TRACADIE RIVER AT MURCHY",
                "BIG TRACADIE RIVER AT MURCHY CROSSING",
                "Canada Canada"
            };

            foreach (string SearchText in SearchTermList)
            {
                List<TVItemLanguage> tvItemLanguageList = await SearchTest(culture, SearchText, 0);

                Assert.NotNull(tvItemLanguageList);
                Assert.True(tvItemLanguageList.Count > 0);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SearchController_Search_Under_NotFound_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> SearchTermList = new List<string>()
            {
                "Caraquet" 
            };

            int TVItemID = 10; /* 10 = Newfoundland and Labrador */
            foreach (string SearchText in SearchTermList)
            {
                List<TVItemLanguage> tvItemLanguageList = await SearchTest(culture, SearchText, TVItemID);

                Assert.NotNull(tvItemLanguageList);
                Assert.True(tvItemLanguageList.Count == 0);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SearchController_Search_NotFound_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> SearchTermList = new List<string>()
            {
                "lsiefjlsiejfilsjfilj"
            };

            foreach (string SearchText in SearchTermList)
            {
                List<TVItemLanguage> tvItemLanguageList = await SearchTest(culture, SearchText, 0);

                Assert.NotNull(tvItemLanguageList);
                Assert.True(tvItemLanguageList.Count == 0);
            }
        }
        #endregion Tests

        #region FunctionPrivate
        private async Task<List<TVItemLanguage>> SearchTest(string culture, string SearchTerm, int TVItemID)
        {
            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/Search/{ SearchTerm }/{ TVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                tvItemLanguageList = JsonSerializer.Deserialize<List<TVItemLanguage>>(response.Content.ReadAsStringAsync().Result);
            }

            return await Task.FromResult(tvItemLanguageList);
        }
        #endregion Functions private
    }
}
