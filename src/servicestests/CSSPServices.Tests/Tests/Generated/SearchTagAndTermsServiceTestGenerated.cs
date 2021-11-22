///* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
// *
// * Do not edit this file.
// *
// */ 

//using CSSPEnums;
//using CSSPModels;
//using CSSPCultureServices.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Transactions;
//using Xunit;
//using System.ComponentModel.DataAnnotations;

//namespace CSSPServices.Tests
//{
//    public partial class SearchTagAndTermsServiceTest : TestHelper
//    {
//        #region Variables
//        #endregion Variables

//        #region Properties
//        private IConfiguration Config { get; set; }
//        private IServiceProvider Provider { get; set; }
//        private IServiceCollection Services { get; set; }
//        private ICSSPCultureService CSSPCultureService { get; set; }
//        private ISearchTagAndTermsService SearchTagAndTermsService { get; set; }
//        private SearchTagAndTerms searchTagAndTerms { get; set; }
//        #endregion Properties

//        #region Constructors
//        public SearchTagAndTermsServiceTest() : base()
//        {

//        }
//        #endregion Constructors

//        #region Tests Generated Basic Test Not Mapped
//        [Theory]
//        [InlineData("en-CA")]
//        [InlineData("fr-CA")]
//        public async Task SearchTagAndTermsService_Good_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            searchTagAndTerms = GetFilledRandomSearchTagAndTerms("");

//            List<ValidationResult> ValidationResultsList = SearchTagAndTermsService.Validate(new ValidationContext(searchTagAndTerms)).ToList();
//            Assert.True(ValidationResultsList.Count == 0);
//        }
//        #endregion Tests Generated Basic Test Not Mapped

//        #region Functions private
//        private async Task<bool> Setup(string culture)
//        {
//            Config = new ConfigurationBuilder()
//               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
//               .AddJsonFile("appsettings_csspservicestests.json")
//               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
//               .Build();

//            Services = new ServiceCollection();

//            Services.AddSingleton<IConfiguration>(Config);

//            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
//            Services.AddSingleton<IEnums, Enums>();
//            Services.AddSingleton<ISearchTagAndTermsService, SearchTagAndTermsService>();

//            Provider = Services.BuildServiceProvider();
//            Assert.NotNull(Provider);

//            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
//            Assert.NotNull(CSSPCultureService);

//            CSSPCultureService.SetCulture(culture);

//            SearchTagAndTermsService = Provider.GetService<ISearchTagAndTermsService>();
//            Assert.NotNull(SearchTagAndTermsService);

//            return await Task.FromResult(true);
//        }
//        private SearchTagAndTerms GetFilledRandomSearchTagAndTerms(string OmitPropName)
//        {
//            SearchTagAndTerms searchTagAndTerms = new SearchTagAndTerms();

//            if (OmitPropName != "SearchTag") searchTagAndTerms.SearchTag = (SearchTagEnum)GetRandomEnumType(typeof(SearchTagEnum));
//            if (OmitPropName != "SearchTagText") searchTagAndTerms.SearchTagText = GetRandomString("", 5);
//            if (OmitPropName != "SearchTermList") searchTagAndTerms.SearchTermList = new List<string>() { GetRandomString("", 20), GetRandomString("", 20) };

//            return searchTagAndTerms;
//        }
//        private void CheckSearchTagAndTermsFields(List<SearchTagAndTerms> searchTagAndTermsList)
//        {
//            if (!string.IsNullOrWhiteSpace(searchTagAndTermsList[0].SearchTagText))
//            {
//                Assert.False(string.IsNullOrWhiteSpace(searchTagAndTermsList[0].SearchTagText));
//            }
//            Assert.False(string.IsNullOrWhiteSpace(searchTagAndTermsList[0].SearchTermList));
//        }
//        #endregion Functions private
//    }
//}