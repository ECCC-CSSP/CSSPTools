/* Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPHelperServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPHelperModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;
using System.ComponentModel.DataAnnotations;
using CSSPCultureServices.Resources;
using CSSPHelperServices.Tests;

namespace CSSPHelperServices.Tests
{
    [Collection("Sequential")]
    public partial class SearchResultServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ISearchResultService SearchResultService { get; set; }
        #endregion Properties

        #region Constructors
        public SearchResultServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructors
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskParameter_Constructor_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(enums);
        }
        #endregion Tests Generated Constructors

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SearchResult_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SearchResult searchResult = GetFilledRandomSearchResult("");


            // -----------------------------------
            // Is NOT Nullable
            // searchResult.TVItem   (TVItem)
            // -----------------------------------

            //CSSPError: Type not implemented [TVItem]

            //CSSPError: Type not implemented [TVItem]


            // -----------------------------------
            // Is NOT Nullable
            // searchResult.TVItemLanguage   (TVItemLanguage)
            // -----------------------------------

            //CSSPError: Type not implemented [TVItemLanguage]

            //CSSPError: Type not implemented [TVItemLanguage]

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_CSSPDBServicestests.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ISearchResultService, SearchResultService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            SearchResultService = Provider.GetService<ISearchResultService>();
            Assert.NotNull(SearchResultService);

            return await Task.FromResult(true);
        }
        private SearchResult GetFilledRandomSearchResult(string OmitPropName)
        {
            SearchResult searchResult = new SearchResult();

            //CSSPError: property [TVItem] and type [SearchResult] is  not implemented
            //CSSPError: property [TVItemLanguage] and type [SearchResult] is  not implemented

            return searchResult;
        }

        #endregion Functions private
    }
}
