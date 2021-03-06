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
using LocalServices;

namespace CSSPDBLocalIMServices.Tests
{
    [Collection("Sequential")]
    public partial class AppTaskLanguageDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IAppTaskLanguageDBLocalIMService AppTaskLanguageDBLocalIMService { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private AppTaskLanguage appTaskLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocalIM]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLanguageDBLocalIM_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocalIM]

        #region Tests Generated [DBLocalIM] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLanguageDBLocalIM_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            appTaskLanguage = GetFilledRandomAppTaskLanguage("");

            await DoCRUDDBLocalIMTest();
        }
        #endregion Tests Generated [DBLocalIM] CRUD

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

            var actionAppTaskLanguageList = await AppTaskLanguageDBLocalIMService.GetAppTaskLanguageList();
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

            var actionAppTaskLanguage = await AppTaskLanguageDBLocalIMService.Put(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.AppTaskLanguageID = 10000000;
            actionAppTaskLanguage = await AppTaskLanguageDBLocalIMService.Put(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "AppTask", ExistPlurial = "s", ExistFieldID = "AppTaskID", AllowableTVtypeList = )]
            // appTaskLanguage.AppTaskID   (Int32)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.AppTaskID = 0;
            actionAppTaskLanguage = await AppTaskLanguageDBLocalIMService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTaskLanguage.Language   (LanguageEnum)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.Language = (LanguageEnum)1000000;
            actionAppTaskLanguage = await AppTaskLanguageDBLocalIMService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(250)]
            // appTaskLanguage.StatusText   (String)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.StatusText = GetRandomString("", 251);
            actionAppTaskLanguage = await AppTaskLanguageDBLocalIMService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);
            //Assert.AreEqual(count, appTaskLanguageDBLocalIMService.GetAppTaskLanguageList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(250)]
            // appTaskLanguage.ErrorText   (String)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.ErrorText = GetRandomString("", 251);
            actionAppTaskLanguage = await AppTaskLanguageDBLocalIMService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);
            //Assert.AreEqual(count, appTaskLanguageDBLocalIMService.GetAppTaskLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTaskLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            actionAppTaskLanguage = await AppTaskLanguageDBLocalIMService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // appTaskLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.LastUpdateDate_UTC = new DateTime();
            actionAppTaskLanguage = await AppTaskLanguageDBLocalIMService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);
            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionAppTaskLanguage = await AppTaskLanguageDBLocalIMService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // appTaskLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.LastUpdateContactTVItemID = 0;
            actionAppTaskLanguage = await AppTaskLanguageDBLocalIMService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.LastUpdateContactTVItemID = 1;
            actionAppTaskLanguage = await AppTaskLanguageDBLocalIMService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalIMTest()
        {
            appTaskLanguage.AppTaskLanguageID = 10000000;

            // Post AppTaskLanguage
            var actionAppTaskLanguageAdded = await AppTaskLanguageDBLocalIMService.Post(appTaskLanguage);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageAdded.Result).Value);
            AppTaskLanguage appTaskLanguageAdded = (AppTaskLanguage)((OkObjectResult)actionAppTaskLanguageAdded.Result).Value;
            Assert.NotNull(appTaskLanguageAdded);

            // List<AppTaskLanguage>
            var actionAppTaskLanguageList = await AppTaskLanguageDBLocalIMService.GetAppTaskLanguageList();
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageList.Result).Value);
            List<AppTaskLanguage> appTaskLanguageList = (List<AppTaskLanguage>)((OkObjectResult)actionAppTaskLanguageList.Result).Value;

            int count = ((List<AppTaskLanguage>)((OkObjectResult)actionAppTaskLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // Get AppTaskLanguage With AppTaskLanguageID
            var actionAppTaskLanguageGet = await AppTaskLanguageDBLocalIMService.GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguageList[0].AppTaskLanguageID);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageGet.Result).Value);
            AppTaskLanguage appTaskLanguageGet = (AppTaskLanguage)((OkObjectResult)actionAppTaskLanguageGet.Result).Value;
            Assert.NotNull(appTaskLanguageGet);
            Assert.Equal(appTaskLanguageGet.AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);

            // Put AppTaskLanguage
            var actionAppTaskLanguageUpdated = await AppTaskLanguageDBLocalIMService.Put(appTaskLanguage);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageUpdated.Result).Value);
            AppTaskLanguage appTaskLanguageUpdated = (AppTaskLanguage)((OkObjectResult)actionAppTaskLanguageUpdated.Result).Value;
            Assert.NotNull(appTaskLanguageUpdated);

            // Delete AppTaskLanguage
            var actionAppTaskLanguageDeleted = await AppTaskLanguageDBLocalIMService.Delete(appTaskLanguage.AppTaskLanguageID);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionAppTaskLanguageDeleted.Result).Value;
            Assert.True(retBool);

        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalimservicestests.json")
               .AddUserSecrets("64a6d1e4-0d0c-4e59-9c2e-640182417704")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLoginFileName = Config.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAppTaskLanguageDBLocalIMService, AppTaskLanguageDBLocalIMService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbLocalIM);

            AppTaskLanguageDBLocalIMService = Provider.GetService<IAppTaskLanguageDBLocalIMService>();
            Assert.NotNull(AppTaskLanguageDBLocalIMService);

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

            try
            {
                dbLocalIM.AppTasks.Add(new AppTask() { AppTaskID = 1, TVItemID = 5, TVItemID2 = 5, AppTaskCommand = (AppTaskCommandEnum)1, AppTaskStatus = (AppTaskStatusEnum)1, PercentCompleted = 1, Parameters = "a,a", Language = (LanguageEnum)1, StartDateTime_UTC = new DateTime(2015, 9, 3, 9, 17, 7), EndDateTime_UTC = new DateTime(2015, 9, 3, 13, 17, 7), EstimatedLength_second = 1201, RemainingTime_second = 234, LastUpdateDate_UTC = new DateTime(2020, 9, 3, 9, 17, 7), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }
            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }


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
