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
    public partial class MWQMRunServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMWQMRunService MWQMRunService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private MWQMRun mwqmRun { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task MWQMRun_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            mwqmRun = GetFilledRandomMWQMRun("");

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
            // Post MWQMRun
            var actionMWQMRunAdded = await MWQMRunService.Post(mwqmRun);
            Assert.Equal(200, ((ObjectResult)actionMWQMRunAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunAdded.Result).Value);
            MWQMRun mwqmRunAdded = (MWQMRun)((OkObjectResult)actionMWQMRunAdded.Result).Value;
            Assert.NotNull(mwqmRunAdded);

            // List<MWQMRun>
            var actionMWQMRunList = await MWQMRunService.GetMWQMRunList();
            Assert.Equal(200, ((ObjectResult)actionMWQMRunList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunList.Result).Value);
            List<MWQMRun> mwqmRunList = (List<MWQMRun>)((OkObjectResult)actionMWQMRunList.Result).Value;

            int count = ((List<MWQMRun>)((OkObjectResult)actionMWQMRunList.Result).Value).Count();
            Assert.True(count > 0);

            // Put MWQMRun
            var actionMWQMRunUpdated = await MWQMRunService.Put(mwqmRun);
            Assert.Equal(200, ((ObjectResult)actionMWQMRunUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunUpdated.Result).Value);
            MWQMRun mwqmRunUpdated = (MWQMRun)((OkObjectResult)actionMWQMRunUpdated.Result).Value;
            Assert.NotNull(mwqmRunUpdated);

            // Delete MWQMRun
            var actionMWQMRunDeleted = await MWQMRunService.Delete(mwqmRun.MWQMRunID);
            Assert.Equal(200, ((ObjectResult)actionMWQMRunDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMRunDeleted.Result).Value;
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
            Services.AddSingleton<IMWQMRunService, MWQMRunService>();

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

            MWQMRunService = Provider.GetService<IMWQMRunService>();
            Assert.NotNull(MWQMRunService);

            return await Task.FromResult(true);
        }
        private MWQMRun GetFilledRandomMWQMRun(string OmitPropName)
        {
            dbIM.Database.EnsureDeleted();

            MWQMRun mwqmRun = new MWQMRun();

            if (OmitPropName != "SubsectorTVItemID") mwqmRun.SubsectorTVItemID = 11;
            if (OmitPropName != "MWQMRunTVItemID") mwqmRun.MWQMRunTVItemID = 50;
            if (OmitPropName != "RunSampleType") mwqmRun.RunSampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "DateTime_Local") mwqmRun.DateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "RunNumber") mwqmRun.RunNumber = GetRandomInt(1, 1000);
            if (OmitPropName != "StartDateTime_Local") mwqmRun.StartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_Local") mwqmRun.EndDateTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "LabReceivedDateTime_Local") mwqmRun.LabReceivedDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "TemperatureControl1_C") mwqmRun.TemperatureControl1_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TemperatureControl2_C") mwqmRun.TemperatureControl2_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SeaStateAtStart_BeaufortScale") mwqmRun.SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)GetRandomEnumType(typeof(BeaufortScaleEnum));
            if (OmitPropName != "SeaStateAtEnd_BeaufortScale") mwqmRun.SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)GetRandomEnumType(typeof(BeaufortScaleEnum));
            if (OmitPropName != "WaterLevelAtBrook_m") mwqmRun.WaterLevelAtBrook_m = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "WaveHightAtStart_m") mwqmRun.WaveHightAtStart_m = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "WaveHightAtEnd_m") mwqmRun.WaveHightAtEnd_m = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "SampleCrewInitials") mwqmRun.SampleCrewInitials = GetRandomString("", 5);
            if (OmitPropName != "AnalyzeMethod") mwqmRun.AnalyzeMethod = (AnalyzeMethodEnum)GetRandomEnumType(typeof(AnalyzeMethodEnum));
            if (OmitPropName != "SampleMatrix") mwqmRun.SampleMatrix = (SampleMatrixEnum)GetRandomEnumType(typeof(SampleMatrixEnum));
            if (OmitPropName != "Laboratory") mwqmRun.Laboratory = (LaboratoryEnum)GetRandomEnumType(typeof(LaboratoryEnum));
            if (OmitPropName != "SampleStatus") mwqmRun.SampleStatus = (SampleStatusEnum)GetRandomEnumType(typeof(SampleStatusEnum));
            if (OmitPropName != "LabSampleApprovalContactTVItemID") mwqmRun.LabSampleApprovalContactTVItemID = 2;
            if (OmitPropName != "LabAnalyzeBath1IncubationStartDateTime_Local") mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "LabAnalyzeBath2IncubationStartDateTime_Local") mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "LabAnalyzeBath3IncubationStartDateTime_Local") mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "LabRunSampleApprovalDateTime_Local") mwqmRun.LabRunSampleApprovalDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Tide_Start") mwqmRun.Tide_Start = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "Tide_End") mwqmRun.Tide_End = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "RainDay0_mm") mwqmRun.RainDay0_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay1_mm") mwqmRun.RainDay1_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay2_mm") mwqmRun.RainDay2_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay3_mm") mwqmRun.RainDay3_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay4_mm") mwqmRun.RainDay4_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay5_mm") mwqmRun.RainDay5_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay6_mm") mwqmRun.RainDay6_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay7_mm") mwqmRun.RainDay7_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay8_mm") mwqmRun.RainDay8_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay9_mm") mwqmRun.RainDay9_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay10_mm") mwqmRun.RainDay10_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RemoveFromStat") mwqmRun.RemoveFromStat = true;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmRun.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmRun.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "MWQMRunID") mwqmRun.MWQMRunID = 10000000;

                dbIM.TVItems.Add(new TVItem() { TVItemID = 11, TVLevel = 5, TVPath = "p1p5p6p9p10p11", TVType = (TVTypeEnum)20, ParentID = 10, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 18, 53, 40), LastUpdateContactTVItemID = 2});
                dbIM.SaveChanges();
                dbIM.TVItems.Add(new TVItem() { TVItemID = 50, TVLevel = 6, TVPath = "p1p5p6p9p10p12p50", TVType = (TVTypeEnum)31, ParentID = 12, IsActive = true, LastUpdateDate_UTC = new DateTime(2017, 6, 28, 12, 41, 23), LastUpdateContactTVItemID = 2});
                dbIM.SaveChanges();
                dbIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                dbIM.SaveChanges();
            }

            return mwqmRun;
        }
        #endregion Functions private
    }
}
