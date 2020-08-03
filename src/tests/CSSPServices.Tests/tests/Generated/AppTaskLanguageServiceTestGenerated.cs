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

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class AppTaskLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IAppTaskLanguageService AppTaskLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private AppTaskLanguage appTaskLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task AppTaskLanguage_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            appTaskLanguage = GetFilledRandomAppTaskLanguage("");

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                await DoCRUDTest();
            }
            else
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    await DoCRUDTest();
                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task AppTaskLanguage_Properties_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionAppTaskLanguageList = await AppTaskLanguageService.GetAppTaskLanguageList();
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

            var actionAppTaskLanguage = await AppTaskLanguageService.Put(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.AppTaskLanguageID = 10000000;
            actionAppTaskLanguage = await AppTaskLanguageService.Put(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "AppTask", ExistPlurial = "s", ExistFieldID = "AppTaskID", AllowableTVtypeList = )]
            // appTaskLanguage.AppTaskID   (Int32)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.AppTaskID = 0;
            actionAppTaskLanguage = await AppTaskLanguageService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTaskLanguage.Language   (LanguageEnum)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.Language = (LanguageEnum)1000000;
            actionAppTaskLanguage = await AppTaskLanguageService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(250)]
            // appTaskLanguage.StatusText   (String)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.StatusText = GetRandomString("", 251);
            actionAppTaskLanguage = await AppTaskLanguageService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);
            //Assert.AreEqual(count, appTaskLanguageService.GetAppTaskLanguageList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(250)]
            // appTaskLanguage.ErrorText   (String)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.ErrorText = GetRandomString("", 251);
            actionAppTaskLanguage = await AppTaskLanguageService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);
            //Assert.AreEqual(count, appTaskLanguageService.GetAppTaskLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTaskLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            actionAppTaskLanguage = await AppTaskLanguageService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // appTaskLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.LastUpdateDate_UTC = new DateTime();
            actionAppTaskLanguage = await AppTaskLanguageService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);
            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionAppTaskLanguage = await AppTaskLanguageService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // appTaskLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.LastUpdateContactTVItemID = 0;
            actionAppTaskLanguage = await AppTaskLanguageService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.LastUpdateContactTVItemID = 1;
            actionAppTaskLanguage = await AppTaskLanguageService.Post(appTaskLanguage);
            Assert.IsType<BadRequestObjectResult>(actionAppTaskLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post AppTaskLanguage
            var actionAppTaskLanguageAdded = await AppTaskLanguageService.Post(appTaskLanguage);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageAdded.Result).Value);
            AppTaskLanguage appTaskLanguageAdded = (AppTaskLanguage)((OkObjectResult)actionAppTaskLanguageAdded.Result).Value;
            Assert.NotNull(appTaskLanguageAdded);

            // List<AppTaskLanguage>
            var actionAppTaskLanguageList = await AppTaskLanguageService.GetAppTaskLanguageList();
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageList.Result).Value);
            List<AppTaskLanguage> appTaskLanguageList = (List<AppTaskLanguage>)((OkObjectResult)actionAppTaskLanguageList.Result).Value;

            int count = ((List<AppTaskLanguage>)((OkObjectResult)actionAppTaskLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<AppTaskLanguage> with skip and take
                var actionAppTaskLanguageListSkipAndTake = await AppTaskLanguageService.GetAppTaskLanguageList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAppTaskLanguageListSkipAndTake.Result).Value);
                List<AppTaskLanguage> appTaskLanguageListSkipAndTake = (List<AppTaskLanguage>)((OkObjectResult)actionAppTaskLanguageListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<AppTaskLanguage>)((OkObjectResult)actionAppTaskLanguageListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(appTaskLanguageList[0].AppTaskLanguageID == appTaskLanguageListSkipAndTake[0].AppTaskLanguageID);
            }

            // Get AppTaskLanguage With AppTaskLanguageID
            var actionAppTaskLanguageGet = await AppTaskLanguageService.GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguageList[0].AppTaskLanguageID);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageGet.Result).Value);
            AppTaskLanguage appTaskLanguageGet = (AppTaskLanguage)((OkObjectResult)actionAppTaskLanguageGet.Result).Value;
            Assert.NotNull(appTaskLanguageGet);
            Assert.Equal(appTaskLanguageGet.AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);

            // Put AppTaskLanguage
            var actionAppTaskLanguageUpdated = await AppTaskLanguageService.Put(appTaskLanguage);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageUpdated.Result).Value);
            AppTaskLanguage appTaskLanguageUpdated = (AppTaskLanguage)((OkObjectResult)actionAppTaskLanguageUpdated.Result).Value;
            Assert.NotNull(appTaskLanguageUpdated);

            // Delete AppTaskLanguage
            var actionAppTaskLanguageDeleted = await AppTaskLanguageService.Delete(appTaskLanguage.AppTaskLanguageID);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionAppTaskLanguageDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservices.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            string TestDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAppTaskLanguageService, AppTaskLanguageService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.DBLocation = DBLocationEnum.Local;

            dbIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            AppTaskLanguageService = Provider.GetService<IAppTaskLanguageService>();
            Assert.NotNull(AppTaskLanguageService);

            return await Task.FromResult(true);
        }
        private AppTaskLanguage GetFilledRandomAppTaskLanguage(string OmitPropName)
        {
            List<AppTaskLanguage> appTaskLanguageListToDelete = (from c in dbLocal.AppTaskLanguages
                                                               select c).ToList(); 
            
            dbLocal.AppTaskLanguages.RemoveRange(appTaskLanguageListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            AppTaskLanguage appTaskLanguage = new AppTaskLanguage();

            if (OmitPropName != "AppTaskID") appTaskLanguage.AppTaskID = 1;
            if (OmitPropName != "Language") appTaskLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "StatusText") appTaskLanguage.StatusText = GetRandomString("", 5);
            if (OmitPropName != "ErrorText") appTaskLanguage.ErrorText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") appTaskLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") appTaskLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appTaskLanguage.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "AppTaskLanguageID") appTaskLanguage.AppTaskLanguageID = 10000000;

                try
                {
                    dbIM.AppTasks.Add(new AppTask() { AppTaskID = 1, TVItemID = 5, TVItemID2 = 5, AppTaskCommand = (AppTaskCommandEnum)1, AppTaskStatus = (AppTaskStatusEnum)1, PercentCompleted = 1, Parameters = "a,a", Language = (LanguageEnum)1, StartDateTime_UTC = new DateTime(2015, 7, 23, 9, 37, 43), EndDateTime_UTC = new DateTime(2015, 7, 23, 13, 37, 43), EstimatedLength_second = 1201, RemainingTime_second = 234, LastUpdateDate_UTC = new DateTime(2020, 7, 23, 9, 37, 43), LastUpdateContactTVItemID = 2 });
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
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
