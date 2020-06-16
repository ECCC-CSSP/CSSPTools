/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
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
    public partial class BoxModelLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private IBoxModelLanguageService BoxModelLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task BoxModelLanguage_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               BoxModelLanguage boxModelLanguage = GetFilledRandomBoxModelLanguage(""); 

               // List<BoxModelLanguage>
               var actionBoxModelLanguageList = await BoxModelLanguageService.GetBoxModelLanguageList();
               Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelLanguageList.Result).Value);
               List<BoxModelLanguage> boxModelLanguageList = (List<BoxModelLanguage>)((OkObjectResult)actionBoxModelLanguageList.Result).Value;

               int count = ((List<BoxModelLanguage>)((OkObjectResult)actionBoxModelLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // Post BoxModelLanguage
               var actionBoxModelLanguageAdded = await BoxModelLanguageService.Post(boxModelLanguage);
               Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelLanguageAdded.Result).Value);
               BoxModelLanguage boxModelLanguageAdded = (BoxModelLanguage)((OkObjectResult)actionBoxModelLanguageAdded.Result).Value;
               Assert.NotNull(boxModelLanguageAdded);

               // Put BoxModelLanguage
               var actionBoxModelLanguageUpdated = await BoxModelLanguageService.Put(boxModelLanguage);
               Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelLanguageUpdated.Result).Value);
               BoxModelLanguage boxModelLanguageUpdated = (BoxModelLanguage)((OkObjectResult)actionBoxModelLanguageUpdated.Result).Value;
               Assert.NotNull(boxModelLanguageUpdated);

               // Delete BoxModelLanguage
               var actionBoxModelLanguageDeleted = await BoxModelLanguageService.Delete(boxModelLanguage.BoxModelLanguageID);
               Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelLanguageDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionBoxModelLanguageDeleted.Result).Value;
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
            Services.AddSingleton<IBoxModelLanguageService, BoxModelLanguageService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            BoxModelLanguageService = Provider.GetService<IBoxModelLanguageService>();
            Assert.NotNull(BoxModelLanguageService);

            return await Task.FromResult(true);
        }
        private BoxModelLanguage GetFilledRandomBoxModelLanguage(string OmitPropName)
        {
            BoxModelLanguage boxModelLanguage = new BoxModelLanguage();

            if (OmitPropName != "BoxModelID") boxModelLanguage.BoxModelID = 1;
            if (OmitPropName != "Language") boxModelLanguage.Language = LanguageRequest;
            if (OmitPropName != "ScenarioName") boxModelLanguage.ScenarioName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") boxModelLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") boxModelLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") boxModelLanguage.LastUpdateContactTVItemID = 2;

            return boxModelLanguage;
        }
        #endregion Functions private
    }
}
