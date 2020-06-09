/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
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

namespace CSSPServices.Tests
{
    public partial class TVItemLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ITVItemLanguageService tvItemLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItemLanguage_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               TVItemLanguage tvItemLanguage = GetFilledRandomTVItemLanguage(""); 

               // List<TVItemLanguage>
               var actionTVItemLanguageList = await tvItemLanguageService.GetTVItemLanguageList();
               Assert.Equal(200, ((ObjectResult)actionTVItemLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLanguageList.Result).Value);
               List<TVItemLanguage> tvItemLanguageList = (List<TVItemLanguage>)((OkObjectResult)actionTVItemLanguageList.Result).Value;

               int count = ((List<TVItemLanguage>)((OkObjectResult)actionTVItemLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // Add TVItemLanguage
               var actionTVItemLanguageAdded = await tvItemLanguageService.Add(tvItemLanguage);
               Assert.Equal(200, ((ObjectResult)actionTVItemLanguageAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLanguageAdded.Result).Value);
               TVItemLanguage tvItemLanguageAdded = (TVItemLanguage)((OkObjectResult)actionTVItemLanguageAdded.Result).Value;
               Assert.NotNull(tvItemLanguageAdded);

               // Update TVItemLanguage
               var actionTVItemLanguageUpdated = await tvItemLanguageService.Update(tvItemLanguage);
               Assert.Equal(200, ((ObjectResult)actionTVItemLanguageUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLanguageUpdated.Result).Value);
               TVItemLanguage tvItemLanguageUpdated = (TVItemLanguage)((OkObjectResult)actionTVItemLanguageUpdated.Result).Value;
               Assert.NotNull(tvItemLanguageUpdated);

               // Delete TVItemLanguage
               var actionTVItemLanguageDeleted = await tvItemLanguageService.Delete(tvItemLanguage.TVItemLanguageID);
               Assert.Equal(200, ((ObjectResult)actionTVItemLanguageDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLanguageDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionTVItemLanguageDeleted.Result).Value;
               Assert.True(retBool);
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITVItemLanguageService, TVItemLanguageService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            tvItemLanguageService = Provider.GetService<ITVItemLanguageService>();
            Assert.NotNull(tvItemLanguageService);

            return await Task.FromResult(true);
        }
        private TVItemLanguage GetFilledRandomTVItemLanguage(string OmitPropName)
        {
            TVItemLanguage tvItemLanguage = new TVItemLanguage();

            if (OmitPropName != "TVItemID") tvItemLanguage.TVItemID = 1;
            if (OmitPropName != "Language") tvItemLanguage.Language = LanguageRequest;
            if (OmitPropName != "TVText") tvItemLanguage.TVText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") tvItemLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLanguage.LastUpdateContactTVItemID = 2;

            return tvItemLanguage;
        }
        #endregion Functions private
    }
}
