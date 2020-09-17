/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
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
using LoggedInServices;

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class AppTaskLanguageDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IAppTaskLanguageDBService AppTaskLanguageDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private AppTaskLanguage appTaskLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLanguageDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLanguageDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            appTaskLanguage = GetFilledRandomAppTaskLanguage("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLanguage_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionAppTaskLanguageList = await AppTaskLanguageDBService.GetAppTaskLanguageList();
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageList.Result).Value);
            List<AppTaskLanguage> appTaskLanguageList = (List<AppTaskLanguage>)((OkObjectResult)actionAppTaskLanguageList.Result).Value;

            count = appTaskLanguageList.Count();

            AppTaskLanguage appTaskLanguage = GetFilledRandomAppTaskLanguage("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // appTaskLanguage.AppTaskLanguageID   (Int32)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.AppTaskLanguageID = 0;

            var actionAppTaskLanguage = await AppTaskLanguageDBService.Put(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.AppTaskLanguageID = 10000000;
            actionAppTaskLanguage = await AppTaskLanguageDBService.Put(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "AppTask", ExistPlurial = "s", ExistFieldID = "AppTaskID", AllowableTVtypeList = )]
            // appTaskLanguage.AppTaskID   (Int32)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.AppTaskID = 0;
            actionAppTaskLanguage = await AppTaskLanguageDBService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTaskLanguage.Language   (LanguageEnum)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.Language = (LanguageEnum)1000000;
            actionAppTaskLanguage = await AppTaskLanguageDBService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(250)]
            // appTaskLanguage.StatusText   (String)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.StatusText = GetRandomString("", 251);
            actionAppTaskLanguage = await AppTaskLanguageDBService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);
            //Assert.AreEqual(count, appTaskLanguageDBService.GetAppTaskLanguageList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(250)]
            // appTaskLanguage.ErrorText   (String)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.ErrorText = GetRandomString("", 251);
            actionAppTaskLanguage = await AppTaskLanguageDBService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);
            //Assert.AreEqual(count, appTaskLanguageDBService.GetAppTaskLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTaskLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            actionAppTaskLanguage = await AppTaskLanguageDBService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // appTaskLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.LastUpdateDate_UTC = new DateTime();
            actionAppTaskLanguage = await AppTaskLanguageDBService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);
            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionAppTaskLanguage = await AppTaskLanguageDBService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // appTaskLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.LastUpdateContactTVItemID = 0;
            actionAppTaskLanguage = await AppTaskLanguageDBService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.LastUpdateContactTVItemID = 1;
            actionAppTaskLanguage = await AppTaskLanguageDBService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post AppTaskLanguage
            var actionAppTaskLanguageAdded = await AppTaskLanguageDBService.Post(appTaskLanguage);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageAdded.Result).Value);
            AppTaskLanguage appTaskLanguageAdded = (AppTaskLanguage)((OkObjectResult)actionAppTaskLanguageAdded.Result).Value;
            Assert.NotNull(appTaskLanguageAdded);

            // List<AppTaskLanguage>
            var actionAppTaskLanguageList = await AppTaskLanguageDBService.GetAppTaskLanguageList();
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageList.Result).Value);
            List<AppTaskLanguage> appTaskLanguageList = (List<AppTaskLanguage>)((OkObjectResult)actionAppTaskLanguageList.Result).Value;

            int count = ((List<AppTaskLanguage>)((OkObjectResult)actionAppTaskLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // List<AppTaskLanguage> with skip and take
            var actionAppTaskLanguageListSkipAndTake = await AppTaskLanguageDBService.GetAppTaskLanguageList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageListSkipAndTake.Result).Value);
            List<AppTaskLanguage> appTaskLanguageListSkipAndTake = (List<AppTaskLanguage>)((OkObjectResult)actionAppTaskLanguageListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<AppTaskLanguage>)((OkObjectResult)actionAppTaskLanguageListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(appTaskLanguageList[0].AppTaskLanguageID == appTaskLanguageListSkipAndTake[0].AppTaskLanguageID);

            // Get AppTaskLanguage With AppTaskLanguageID
            var actionAppTaskLanguageGet = await AppTaskLanguageDBService.GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguageList[0].AppTaskLanguageID);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageGet.Result).Value);
            AppTaskLanguage appTaskLanguageGet = (AppTaskLanguage)((OkObjectResult)actionAppTaskLanguageGet.Result).Value;
            Assert.NotNull(appTaskLanguageGet);
            Assert.Equal(appTaskLanguageGet.AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);

            // Put AppTaskLanguage
            var actionAppTaskLanguageUpdated = await AppTaskLanguageDBService.Put(appTaskLanguage);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageUpdated.Result).Value);
            AppTaskLanguage appTaskLanguageUpdated = (AppTaskLanguage)((OkObjectResult)actionAppTaskLanguageUpdated.Result).Value;
            Assert.NotNull(appTaskLanguageUpdated);

            // Delete AppTaskLanguage
            var actionAppTaskLanguageDeleted = await AppTaskLanguageDBService.Delete(appTaskLanguage.AppTaskLanguageID);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionAppTaskLanguageDeleted.Result).Value;
            Assert.True(retBool);

            db.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("70c662c1-a1a8-4b2c-b594-d7834bb5e6db")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAppTaskLanguageDBService, AppTaskLanguageDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            AppTaskLanguageDBService = Provider.GetService<IAppTaskLanguageDBService>();
            Assert.NotNull(AppTaskLanguageDBService);

            return await Task.FromResult(true);
        }
        private AppTaskLanguage GetFilledRandomAppTaskLanguage(string OmitPropName)
        {
            AppTaskLanguage appTaskLanguage = new AppTaskLanguage();

            if (OmitPropName != "AppTaskID") appTaskLanguage.AppTaskID = 1;
            if (OmitPropName != "Language") appTaskLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "StatusText") appTaskLanguage.StatusText = GetRandomString("", 5);
            if (OmitPropName != "ErrorText") appTaskLanguage.ErrorText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") appTaskLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") appTaskLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appTaskLanguage.LastUpdateContactTVItemID = 2;



            return appTaskLanguage;
        }
        private void CheckAppTaskLanguageFields(List<AppTaskLanguage> appTaskLanguageList)
        {
            if (!string.IsNullOrWhiteSpace(appTaskLanguageList[0].StatusText))
            {
                Assert.False(string.IsNullOrWhiteSpace(appTaskLanguageList[0].StatusText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskLanguageList[0].ErrorText))
            {
                Assert.False(string.IsNullOrWhiteSpace(appTaskLanguageList[0].ErrorText));
            }
        }

        #endregion Functions private
    }
}