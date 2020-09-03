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
    public partial class MWQMRunLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMWQMRunLanguageService MWQMRunLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private MWQMRunLanguage mwqmRunLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task MWQMRunLanguage_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");

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
        public async Task MWQMRunLanguage_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionMWQMRunLanguageList = await MWQMRunLanguageService.GetMWQMRunLanguageList();
            Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageList.Result).Value);
            List<MWQMRunLanguage> mwqmRunLanguageList = (List<MWQMRunLanguage>)((OkObjectResult)actionMWQMRunLanguageList.Result).Value;

            count = mwqmRunLanguageList.Count();

            MWQMRunLanguage mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmRunLanguage.MWQMRunLanguageID   (Int32)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.MWQMRunLanguageID = 0;

            var actionMWQMRunLanguage = await MWQMRunLanguageService.Put(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.MWQMRunLanguageID = 10000000;
            actionMWQMRunLanguage = await MWQMRunLanguageService.Put(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "MWQMRun", ExistPlurial = "s", ExistFieldID = "MWQMRunID", AllowableTVtypeList = )]
            // mwqmRunLanguage.MWQMRunID   (Int32)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.MWQMRunID = 0;
            actionMWQMRunLanguage = await MWQMRunLanguageService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmRunLanguage.Language   (LanguageEnum)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.Language = (LanguageEnum)1000000;
            actionMWQMRunLanguage = await MWQMRunLanguageService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // mwqmRunLanguage.RunComment   (String)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunComment");
            actionMWQMRunLanguage = await MWQMRunLanguageService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmRunLanguage.TranslationStatusRunComment   (TranslationStatusEnum)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.TranslationStatusRunComment = (TranslationStatusEnum)1000000;
            actionMWQMRunLanguage = await MWQMRunLanguageService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // mwqmRunLanguage.RunWeatherComment   (String)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunWeatherComment");
            actionMWQMRunLanguage = await MWQMRunLanguageService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmRunLanguage.TranslationStatusRunWeatherComment   (TranslationStatusEnum)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.TranslationStatusRunWeatherComment = (TranslationStatusEnum)1000000;
            actionMWQMRunLanguage = await MWQMRunLanguageService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmRunLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.LastUpdateDate_UTC = new DateTime();
            actionMWQMRunLanguage = await MWQMRunLanguageService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);
            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMWQMRunLanguage = await MWQMRunLanguageService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mwqmRunLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.LastUpdateContactTVItemID = 0;
            actionMWQMRunLanguage = await MWQMRunLanguageService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.LastUpdateContactTVItemID = 1;
            actionMWQMRunLanguage = await MWQMRunLanguageService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post MWQMRunLanguage
            var actionMWQMRunLanguageAdded = await MWQMRunLanguageService.Post(mwqmRunLanguage);
            Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageAdded.Result).Value);
            MWQMRunLanguage mwqmRunLanguageAdded = (MWQMRunLanguage)((OkObjectResult)actionMWQMRunLanguageAdded.Result).Value;
            Assert.NotNull(mwqmRunLanguageAdded);

            // List<MWQMRunLanguage>
            var actionMWQMRunLanguageList = await MWQMRunLanguageService.GetMWQMRunLanguageList();
            Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageList.Result).Value);
            List<MWQMRunLanguage> mwqmRunLanguageList = (List<MWQMRunLanguage>)((OkObjectResult)actionMWQMRunLanguageList.Result).Value;

            int count = ((List<MWQMRunLanguage>)((OkObjectResult)actionMWQMRunLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<MWQMRunLanguage> with skip and take
                var actionMWQMRunLanguageListSkipAndTake = await MWQMRunLanguageService.GetMWQMRunLanguageList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageListSkipAndTake.Result).Value);
                List<MWQMRunLanguage> mwqmRunLanguageListSkipAndTake = (List<MWQMRunLanguage>)((OkObjectResult)actionMWQMRunLanguageListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<MWQMRunLanguage>)((OkObjectResult)actionMWQMRunLanguageListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(mwqmRunLanguageList[0].MWQMRunLanguageID == mwqmRunLanguageListSkipAndTake[0].MWQMRunLanguageID);
            }

            // Get MWQMRunLanguage With MWQMRunLanguageID
            var actionMWQMRunLanguageGet = await MWQMRunLanguageService.GetMWQMRunLanguageWithMWQMRunLanguageID(mwqmRunLanguageList[0].MWQMRunLanguageID);
            Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageGet.Result).Value);
            MWQMRunLanguage mwqmRunLanguageGet = (MWQMRunLanguage)((OkObjectResult)actionMWQMRunLanguageGet.Result).Value;
            Assert.NotNull(mwqmRunLanguageGet);
            Assert.Equal(mwqmRunLanguageGet.MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);

            // Put MWQMRunLanguage
            var actionMWQMRunLanguageUpdated = await MWQMRunLanguageService.Put(mwqmRunLanguage);
            Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageUpdated.Result).Value);
            MWQMRunLanguage mwqmRunLanguageUpdated = (MWQMRunLanguage)((OkObjectResult)actionMWQMRunLanguageUpdated.Result).Value;
            Assert.NotNull(mwqmRunLanguageUpdated);

            // Delete MWQMRunLanguage
            var actionMWQMRunLanguageDeleted = await MWQMRunLanguageService.Delete(mwqmRunLanguage.MWQMRunLanguageID);
            Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMRunLanguageDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservicestests.json")
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
            Services.AddSingleton<IMWQMRunLanguageService, MWQMRunLanguageService>();

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

            MWQMRunLanguageService = Provider.GetService<IMWQMRunLanguageService>();
            Assert.NotNull(MWQMRunLanguageService);

            return await Task.FromResult(true);
        }
        private MWQMRunLanguage GetFilledRandomMWQMRunLanguage(string OmitPropName)
        {
            List<MWQMRunLanguage> mwqmRunLanguageListToDelete = (from c in dbLocal.MWQMRunLanguages
                                                               select c).ToList(); 
            
            dbLocal.MWQMRunLanguages.RemoveRange(mwqmRunLanguageListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            MWQMRunLanguage mwqmRunLanguage = new MWQMRunLanguage();

            if (OmitPropName != "MWQMRunID") mwqmRunLanguage.MWQMRunID = 1;
            if (OmitPropName != "Language") mwqmRunLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "RunComment") mwqmRunLanguage.RunComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusRunComment") mwqmRunLanguage.TranslationStatusRunComment = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "RunWeatherComment") mwqmRunLanguage.RunWeatherComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusRunWeatherComment") mwqmRunLanguage.TranslationStatusRunWeatherComment = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmRunLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmRunLanguage.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "MWQMRunLanguageID") mwqmRunLanguage.MWQMRunLanguageID = 10000000;

                try
                {
                    dbIM.MWQMRuns.Add(new MWQMRun() { MWQMRunID = 1, SubsectorTVItemID = 12, MWQMRunTVItemID = 50, RunSampleType = (SampleTypeEnum)109, DateTime_Local = new DateTime(2017, 6, 21, 0, 0, 0), RunNumber = 1, StartDateTime_Local = new DateTime(2017, 6, 21, 6, 28, 0), EndDateTime_Local = new DateTime(2017, 6, 21, 7, 59, 0), LabReceivedDateTime_Local = new DateTime(2017, 6, 21, 0, 0, 0), TemperatureControl1_C = null, TemperatureControl2_C = null, SeaStateAtStart_BeaufortScale = null, SeaStateAtEnd_BeaufortScale = null, WaterLevelAtBrook_m = null, WaveHightAtStart_m = null, WaveHightAtEnd_m = null, SampleCrewInitials = "null", AnalyzeMethod = (AnalyzeMethodEnum)6, SampleMatrix = (SampleMatrixEnum)7, Laboratory = (LaboratoryEnum)19, SampleStatus = (SampleStatusEnum)2, LabSampleApprovalContactTVItemID = 2, LabAnalyzeBath1IncubationStartDateTime_Local = null, LabAnalyzeBath2IncubationStartDateTime_Local = null, LabAnalyzeBath3IncubationStartDateTime_Local = null, LabRunSampleApprovalDateTime_Local = new DateTime(2017, 6, 28, 9, 41, 23), Tide_Start = (TideTextEnum)7, Tide_End = (TideTextEnum)8, RainDay0_mm = 2.3, RainDay1_mm = 4.8, RainDay2_mm = 0, RainDay3_mm = 0, RainDay4_mm = 7.4, RainDay5_mm = 1.1, RainDay6_mm = 1, RainDay7_mm = 0, RainDay8_mm = 0.2, RainDay9_mm = 0.2, RainDay10_mm = 0, RemoveFromStat = null, LastUpdateDate_UTC = new DateTime(2018, 4, 27, 17, 23, 2), LastUpdateContactTVItemID = 2 });
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

            return mwqmRunLanguage;
        }
        private void CheckMWQMRunLanguageFields(List<MWQMRunLanguage> mwqmRunLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].RunComment));
            Assert.False(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].RunWeatherComment));
        }
        #endregion Functions private
    }
}
