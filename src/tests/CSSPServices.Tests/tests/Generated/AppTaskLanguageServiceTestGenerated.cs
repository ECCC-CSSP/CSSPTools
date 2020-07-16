/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
using LoggedInServices.Services;
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
    [Collection("Sequential")]
    public partial class AppTaskLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IAppTaskLanguageService AppTaskLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private AppTaskLanguage appTaskLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task AppTaskLanguage_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            appTaskLanguage = GetFilledRandomAppTaskLanguage("");

            if (LoggedInService.IsLocal)
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

            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAppTaskLanguageService, AppTaskLanguageService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.IsLocal = true;

            dbIM = Provider.GetService<InMemoryDBContext>();
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
            if (OmitPropName != "Language") appTaskLanguage.Language = LanguageRequest;
            if (OmitPropName != "StatusText") appTaskLanguage.StatusText = GetRandomString("", 5);
            if (OmitPropName != "ErrorText") appTaskLanguage.ErrorText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") appTaskLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") appTaskLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appTaskLanguage.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "AppTaskLanguageID") appTaskLanguage.AppTaskLanguageID = 10000000;

                try
                {
                    dbIM.AppTasks.Add(new AppTask() { AppTaskID = 1, TVItemID = 5, TVItemID2 = 5, AppTaskCommand = (AppTaskCommandEnum)1, AppTaskStatus = (AppTaskStatusEnum)1, PercentCompleted = 1, Parameters = "a,a", Language = (LanguageEnum)1, StartDateTime_UTC = new DateTime(2015, 7, 6, 10, 38, 3), EndDateTime_UTC = new DateTime(2015, 7, 6, 14, 38, 3), EstimatedLength_second = 1201, RemainingTime_second = 234, LastUpdateDate_UTC = new DateTime(2020, 7, 6, 10, 38, 3), LastUpdateContactTVItemID = 2 });
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
        #endregion Functions private
    }
}
