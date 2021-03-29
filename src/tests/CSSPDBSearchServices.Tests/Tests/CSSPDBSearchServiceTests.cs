using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Linq;
using CSSPDBSearchServices;
using CSSPHelperModels;
using CSSPDBPreferenceModels;
using CSSPDBSearchModels;
using LoggedInServices;
using CSSPCultureServices.Resources;
using CSSPScrambleServices;

namespace CSSPSearchServices.Tests
{
    public partial class CSSPSearchServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBSearch_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(Configuration);
            Assert.Equal(culture, CSSPCultureServicesRes.Culture.ToString());
            Assert.NotNull(LoggedInService);
            Assert.NotNull(CSSPDBSearchService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBSearch_Search_Good_Test(string culture)
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
                var actionRes = await CSSPDBSearchService.Search(SearchText, 0);
                Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
                List<SearchResult> searchResultList = (List<SearchResult>)((OkObjectResult)actionRes.Result).Value;
                Assert.NotNull(searchResultList);
                Assert.True(searchResultList.Count > 0);

                List<string> TermList = SearchText.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();

                foreach (SearchResult searchResult in searchResultList)
                {
                    foreach (string term in TermList)
                    {
                        Assert.Contains(term.ToLower(), searchResult.TVItemLanguage.TVText.ToLower());
                    }
                }
            }

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBSearch_Search_Empty_String_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPDBSearchService.Search("", 0);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            List<SearchResult> searchResultList = (List<SearchResult>)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(searchResultList);
            Assert.True(searchResultList.Count == 0);

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBSearch_Search_Number_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPDBSearchService.Search("635", 0);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            List<SearchResult> searchResultList = (List<SearchResult>)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(searchResultList);
            Assert.True(searchResultList.Count > 0);

        }
        [Theory]
        //[InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CSSPDBSearch_Search_FR_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> SearchTermList = new List<string>()
            {
                "Canada", "NB-01-010-001"
            };

            foreach (string SearchText in SearchTermList)
            {
                var actionRes = await CSSPDBSearchService.Search(SearchText, 0);
                Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
                List<SearchResult> searchResultList = (List<SearchResult>)((OkObjectResult)actionRes.Result).Value;
                Assert.NotNull(searchResultList);
                Assert.True(searchResultList.Count > 0);

                List<string> TermList = SearchText.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();

                foreach (SearchResult searchResult in searchResultList)
                {
                    foreach (string term in TermList)
                    {
                        Assert.Contains(term.ToLower(), searchResult.TVItemLanguage.TVText.ToLower());
                    }
                }
            }

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBSearch_Search_Under_NotFound_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> SearchTermList = new List<string>()
            {
                "Caraquet"
            };

            foreach (string SearchText in SearchTermList)
            {
                var actionRes = await CSSPDBSearchService.Search(SearchText, 10 /* 10 = Newfoundland and Labrador */);
                Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
                List<SearchResult> searchResultList = (List<SearchResult>)((OkObjectResult)actionRes.Result).Value;
                Assert.NotNull(searchResultList);
                Assert.True(searchResultList.Count == 0);
            }

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBSearch_Search_NotFound_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> SearchTermList = new List<string>()
            {
                "lsiefjlsiejfilsjfilj"
            };

            foreach (string SearchText in SearchTermList)
            {
                var actionRes = await CSSPDBSearchService.Search(SearchText, 0);
                Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
                List<SearchResult> searchResultList = (List<SearchResult>)((OkObjectResult)actionRes.Result).Value;
                Assert.NotNull(searchResultList);
                Assert.True(searchResultList.Count == 0);
            }

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBSearch_Search_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo.LoggedInContact = null;

            List<string> SearchTermList = new List<string>()
            {
                "Canada"
            };

            foreach (string SearchText in SearchTermList)
            {
                var actionRes = await CSSPDBSearchService.Search(SearchText, 0);
                Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
                Assert.NotNull(((UnauthorizedObjectResult)actionRes.Result).Value);
            }

        }
        #endregion Functions public
    }
}
