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
    public partial class TVItemLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITVItemLanguageService TVItemLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private TVItemLanguage tvItemLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task TVItemLanguage_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            tvItemLanguage = GetFilledRandomTVItemLanguage("");

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
            // Post TVItemLanguage
            var actionTVItemLanguageAdded = await TVItemLanguageService.Post(tvItemLanguage);
            Assert.Equal(200, ((ObjectResult)actionTVItemLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLanguageAdded.Result).Value);
            TVItemLanguage tvItemLanguageAdded = (TVItemLanguage)((OkObjectResult)actionTVItemLanguageAdded.Result).Value;
            Assert.NotNull(tvItemLanguageAdded);

            // List<TVItemLanguage>
            var actionTVItemLanguageList = await TVItemLanguageService.GetTVItemLanguageList();
            Assert.Equal(200, ((ObjectResult)actionTVItemLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLanguageList.Result).Value);
            List<TVItemLanguage> tvItemLanguageList = (List<TVItemLanguage>)((OkObjectResult)actionTVItemLanguageList.Result).Value;

            int count = ((List<TVItemLanguage>)((OkObjectResult)actionTVItemLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // Put TVItemLanguage
            var actionTVItemLanguageUpdated = await TVItemLanguageService.Put(tvItemLanguage);
            Assert.Equal(200, ((ObjectResult)actionTVItemLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLanguageUpdated.Result).Value);
            TVItemLanguage tvItemLanguageUpdated = (TVItemLanguage)((OkObjectResult)actionTVItemLanguageUpdated.Result).Value;
            Assert.NotNull(tvItemLanguageUpdated);

            // Delete TVItemLanguage
            var actionTVItemLanguageDeleted = await TVItemLanguageService.Delete(tvItemLanguage.TVItemLanguageID);
            Assert.Equal(200, ((ObjectResult)actionTVItemLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVItemLanguageDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
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

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{appDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITVItemLanguageService, TVItemLanguageService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            //string IsLocalStr = Config.GetValue<string>("IsLocal");
            //Assert.NotNull(IsLocalStr);

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            TVItemLanguageService = Provider.GetService<ITVItemLanguageService>();
            Assert.NotNull(TVItemLanguageService);

            return await Task.FromResult(true);
        }
        private TVItemLanguage GetFilledRandomTVItemLanguage(string OmitPropName)
        {
            dbIM.Database.EnsureDeleted();

            TVItemLanguage tvItemLanguage = new TVItemLanguage();

            if (OmitPropName != "TVItemID") tvItemLanguage.TVItemID = 1;
            if (OmitPropName != "Language") tvItemLanguage.Language = LanguageRequest;
            if (OmitPropName != "TVText") tvItemLanguage.TVText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") tvItemLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLanguage.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "TVItemLanguageID") tvItemLanguage.TVItemLanguageID = 10000000;

                dbIM.TVItems.Add(new TVItem() { TVItemID = 1, TVLevel = 0, TVPath = "p1", TVType = (TVTypeEnum)1, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                dbIM.SaveChanges();
                dbIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                dbIM.SaveChanges();
            }

            return tvItemLanguage;
        }
        #endregion Functions private
    }
}
