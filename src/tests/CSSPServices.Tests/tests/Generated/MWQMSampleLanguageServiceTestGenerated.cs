/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
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
    public partial class MWQMSampleLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMWQMSampleLanguageService MWQMSampleLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private MWQMSampleLanguage mwqmSampleLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task MWQMSampleLanguage_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");

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
            // Post MWQMSampleLanguage
            var actionMWQMSampleLanguageAdded = await MWQMSampleLanguageService.Post(mwqmSampleLanguage);
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleLanguageAdded.Result).Value);
            MWQMSampleLanguage mwqmSampleLanguageAdded = (MWQMSampleLanguage)((OkObjectResult)actionMWQMSampleLanguageAdded.Result).Value;
            Assert.NotNull(mwqmSampleLanguageAdded);

            // List<MWQMSampleLanguage>
            var actionMWQMSampleLanguageList = await MWQMSampleLanguageService.GetMWQMSampleLanguageList();
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleLanguageList.Result).Value);
            List<MWQMSampleLanguage> mwqmSampleLanguageList = (List<MWQMSampleLanguage>)((OkObjectResult)actionMWQMSampleLanguageList.Result).Value;

            int count = ((List<MWQMSampleLanguage>)((OkObjectResult)actionMWQMSampleLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // Put MWQMSampleLanguage
            var actionMWQMSampleLanguageUpdated = await MWQMSampleLanguageService.Put(mwqmSampleLanguage);
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleLanguageUpdated.Result).Value);
            MWQMSampleLanguage mwqmSampleLanguageUpdated = (MWQMSampleLanguage)((OkObjectResult)actionMWQMSampleLanguageUpdated.Result).Value;
            Assert.NotNull(mwqmSampleLanguageUpdated);

            // Delete MWQMSampleLanguage
            var actionMWQMSampleLanguageDeleted = await MWQMSampleLanguageService.Delete(mwqmSampleLanguage.MWQMSampleLanguageID);
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMSampleLanguageDeleted.Result).Value;
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
            Services.AddSingleton<IMWQMSampleLanguageService, MWQMSampleLanguageService>();

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

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            MWQMSampleLanguageService = Provider.GetService<IMWQMSampleLanguageService>();
            Assert.NotNull(MWQMSampleLanguageService);

            return await Task.FromResult(true);
        }
        private MWQMSampleLanguage GetFilledRandomMWQMSampleLanguage(string OmitPropName)
        {
            List<MWQMSampleLanguage> mwqmSampleLanguageListToDelete = (from c in dbLocal.MWQMSampleLanguages
                                                               select c).ToList(); 
            
            dbLocal.MWQMSampleLanguages.RemoveRange(mwqmSampleLanguageListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            MWQMSampleLanguage mwqmSampleLanguage = new MWQMSampleLanguage();

            if (OmitPropName != "MWQMSampleID") mwqmSampleLanguage.MWQMSampleID = 1;
            if (OmitPropName != "Language") mwqmSampleLanguage.Language = LanguageRequest;
            if (OmitPropName != "MWQMSampleNote") mwqmSampleLanguage.MWQMSampleNote = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") mwqmSampleLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSampleLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSampleLanguage.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "MWQMSampleLanguageID") mwqmSampleLanguage.MWQMSampleLanguageID = 10000000;

                try
                {
                    dbIM.MWQMSamples.Add(new MWQMSample() { MWQMSampleID = 1, MWQMSiteTVItemID = 44, MWQMRunTVItemID = 50, SampleDateTime_Local = new DateTime(2017, 6, 21, 7, 59, 0), TimeText = null, Depth_m = null, FecCol_MPN_100ml = 49, Salinity_PPT = 12, WaterTemp_C = 19, PH = null, SampleTypesText = "109,", SampleType_old = null, Tube_10 = 5, Tube_1_0 = 1, Tube_0_1 = 0, ProcessedBy = null, UseForOpenData = true, LastUpdateDate_UTC = new DateTime(2017, 6, 28, 12, 41, 37), LastUpdateContactTVItemID = 2 });
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

            return mwqmSampleLanguage;
        }
        #endregion Functions private
    }
}
