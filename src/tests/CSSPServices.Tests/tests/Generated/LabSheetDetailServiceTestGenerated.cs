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
    public partial class LabSheetDetailServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ILabSheetDetailService LabSheetDetailService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private LabSheetDetail labSheetDetail { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task LabSheetDetail_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            labSheetDetail = GetFilledRandomLabSheetDetail("");

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
            // Post LabSheetDetail
            var actionLabSheetDetailAdded = await LabSheetDetailService.Post(labSheetDetail);
            Assert.Equal(200, ((ObjectResult)actionLabSheetDetailAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetDetailAdded.Result).Value);
            LabSheetDetail labSheetDetailAdded = (LabSheetDetail)((OkObjectResult)actionLabSheetDetailAdded.Result).Value;
            Assert.NotNull(labSheetDetailAdded);

            // List<LabSheetDetail>
            var actionLabSheetDetailList = await LabSheetDetailService.GetLabSheetDetailList();
            Assert.Equal(200, ((ObjectResult)actionLabSheetDetailList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetDetailList.Result).Value);
            List<LabSheetDetail> labSheetDetailList = (List<LabSheetDetail>)((OkObjectResult)actionLabSheetDetailList.Result).Value;

            int count = ((List<LabSheetDetail>)((OkObjectResult)actionLabSheetDetailList.Result).Value).Count();
            Assert.True(count > 0);

            // Put LabSheetDetail
            var actionLabSheetDetailUpdated = await LabSheetDetailService.Put(labSheetDetail);
            Assert.Equal(200, ((ObjectResult)actionLabSheetDetailUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetDetailUpdated.Result).Value);
            LabSheetDetail labSheetDetailUpdated = (LabSheetDetail)((OkObjectResult)actionLabSheetDetailUpdated.Result).Value;
            Assert.NotNull(labSheetDetailUpdated);

            // Delete LabSheetDetail
            var actionLabSheetDetailDeleted = await LabSheetDetailService.Delete(labSheetDetail.LabSheetDetailID);
            Assert.Equal(200, ((ObjectResult)actionLabSheetDetailDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetDetailDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLabSheetDetailDeleted.Result).Value;
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
            Services.AddSingleton<ILabSheetDetailService, LabSheetDetailService>();

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

            LabSheetDetailService = Provider.GetService<ILabSheetDetailService>();
            Assert.NotNull(LabSheetDetailService);

            return await Task.FromResult(true);
        }
        private LabSheetDetail GetFilledRandomLabSheetDetail(string OmitPropName)
        {
            List<LabSheetDetail> labSheetDetailListToDelete = (from c in dbLocal.LabSheetDetails
                                                               select c).ToList(); 
            
            dbLocal.LabSheetDetails.RemoveRange(labSheetDetailListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            LabSheetDetail labSheetDetail = new LabSheetDetail();

            if (OmitPropName != "LabSheetID") labSheetDetail.LabSheetID = 1;
            if (OmitPropName != "SamplingPlanID") labSheetDetail.SamplingPlanID = 1;
            if (OmitPropName != "SubsectorTVItemID") labSheetDetail.SubsectorTVItemID = 11;
            if (OmitPropName != "Version") labSheetDetail.Version = GetRandomInt(1, 5);
            if (OmitPropName != "RunDate") labSheetDetail.RunDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "Tides") labSheetDetail.Tides = GetRandomString("", 6);
            if (OmitPropName != "SampleCrewInitials") labSheetDetail.SampleCrewInitials = GetRandomString("", 5);
            if (OmitPropName != "WaterBathCount") labSheetDetail.WaterBathCount = GetRandomInt(1, 3);
            if (OmitPropName != "IncubationBath1StartTime") labSheetDetail.IncubationBath1StartTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath2StartTime") labSheetDetail.IncubationBath2StartTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath3StartTime") labSheetDetail.IncubationBath3StartTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath1EndTime") labSheetDetail.IncubationBath1EndTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath2EndTime") labSheetDetail.IncubationBath2EndTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath3EndTime") labSheetDetail.IncubationBath3EndTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath1TimeCalculated_minutes") labSheetDetail.IncubationBath1TimeCalculated_minutes = GetRandomInt(0, 10000);
            if (OmitPropName != "IncubationBath2TimeCalculated_minutes") labSheetDetail.IncubationBath2TimeCalculated_minutes = GetRandomInt(0, 10000);
            if (OmitPropName != "IncubationBath3TimeCalculated_minutes") labSheetDetail.IncubationBath3TimeCalculated_minutes = GetRandomInt(0, 10000);
            if (OmitPropName != "WaterBath1") labSheetDetail.WaterBath1 = GetRandomString("", 5);
            if (OmitPropName != "WaterBath2") labSheetDetail.WaterBath2 = GetRandomString("", 5);
            if (OmitPropName != "WaterBath3") labSheetDetail.WaterBath3 = GetRandomString("", 5);
            if (OmitPropName != "TCField1") labSheetDetail.TCField1 = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCLab1") labSheetDetail.TCLab1 = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCField2") labSheetDetail.TCField2 = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCLab2") labSheetDetail.TCLab2 = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCFirst") labSheetDetail.TCFirst = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCAverage") labSheetDetail.TCAverage = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "ControlLot") labSheetDetail.ControlLot = GetRandomString("", 5);
            if (OmitPropName != "Positive35") labSheetDetail.Positive35 = GetRandomString("", 1);
            if (OmitPropName != "NonTarget35") labSheetDetail.NonTarget35 = GetRandomString("", 1);
            if (OmitPropName != "Negative35") labSheetDetail.Negative35 = GetRandomString("", 1);
            if (OmitPropName != "Bath1Positive44_5") labSheetDetail.Bath1Positive44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath2Positive44_5") labSheetDetail.Bath2Positive44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath3Positive44_5") labSheetDetail.Bath3Positive44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath1NonTarget44_5") labSheetDetail.Bath1NonTarget44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath2NonTarget44_5") labSheetDetail.Bath2NonTarget44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath3NonTarget44_5") labSheetDetail.Bath3NonTarget44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath1Negative44_5") labSheetDetail.Bath1Negative44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath2Negative44_5") labSheetDetail.Bath2Negative44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath3Negative44_5") labSheetDetail.Bath3Negative44_5 = GetRandomString("", 1);
            if (OmitPropName != "Blank35") labSheetDetail.Blank35 = GetRandomString("", 1);
            if (OmitPropName != "Bath1Blank44_5") labSheetDetail.Bath1Blank44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath2Blank44_5") labSheetDetail.Bath2Blank44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath3Blank44_5") labSheetDetail.Bath3Blank44_5 = GetRandomString("", 1);
            if (OmitPropName != "Lot35") labSheetDetail.Lot35 = GetRandomString("", 5);
            if (OmitPropName != "Lot44_5") labSheetDetail.Lot44_5 = GetRandomString("", 5);
            if (OmitPropName != "Weather") labSheetDetail.Weather = GetRandomString("", 5);
            if (OmitPropName != "RunComment") labSheetDetail.RunComment = GetRandomString("", 5);
            if (OmitPropName != "RunWeatherComment") labSheetDetail.RunWeatherComment = GetRandomString("", 5);
            if (OmitPropName != "SampleBottleLotNumber") labSheetDetail.SampleBottleLotNumber = GetRandomString("", 5);
            if (OmitPropName != "SalinitiesReadBy") labSheetDetail.SalinitiesReadBy = GetRandomString("", 5);
            if (OmitPropName != "SalinitiesReadDate") labSheetDetail.SalinitiesReadDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "ResultsReadBy") labSheetDetail.ResultsReadBy = GetRandomString("", 5);
            if (OmitPropName != "ResultsReadDate") labSheetDetail.ResultsReadDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "ResultsRecordedBy") labSheetDetail.ResultsRecordedBy = GetRandomString("", 5);
            if (OmitPropName != "ResultsRecordedDate") labSheetDetail.ResultsRecordedDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "DailyDuplicateRLog") labSheetDetail.DailyDuplicateRLog = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") labSheetDetail.DailyDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "DailyDuplicateAcceptable") labSheetDetail.DailyDuplicateAcceptable = true;
            if (OmitPropName != "IntertechDuplicateRLog") labSheetDetail.IntertechDuplicateRLog = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") labSheetDetail.IntertechDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicateAcceptable") labSheetDetail.IntertechDuplicateAcceptable = true;
            if (OmitPropName != "IntertechReadAcceptable") labSheetDetail.IntertechReadAcceptable = true;
            if (OmitPropName != "LastUpdateDate_UTC") labSheetDetail.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") labSheetDetail.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "LabSheetDetailID") labSheetDetail.LabSheetDetailID = 10000000;

                try
                {
                    dbIM.LabSheets.Add(new LabSheet() { LabSheetID = 1, OtherServerLabSheetID = 52, SamplingPlanID = 1, SamplingPlanName = @"C:\CSSPLabSheets\SamplingPlan_Subsector_Routine_A1_2017_Classification-Moncton.txt", Year = 2017, Month = 6, Day = 21, RunNumber = 1, SubsectorTVItemID = 12, MWQMRunTVItemID = 50, SamplingPlanType = (SamplingPlanTypeEnum)1, SampleType = (SampleTypeEnum)109, LabSheetType = (LabSheetTypeEnum)1, LabSheetStatus = (LabSheetStatusEnum)3, FileName = @"C:\CSSPLabSheets\SamplingPlan_Subsector_Routine_A1_2017_Classification-Moncton\2017\NB-06-020-002_2017_06_21_A1_R01_C.txt", FileLastModifiedDate_Local = new DateTime(2017, 6, 26, 15, 37, 48), FileContent = "", AcceptedOrRejectedByContactTVItemID = 2, AcceptedOrRejectedDateTime = new DateTime(2017, 6, 28, 9, 41, 35), RejectReason = "", LastUpdateDate_UTC = new DateTime(2017, 6, 28, 12, 41, 35), LastUpdateContactTVItemID = 2 });
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.SamplingPlans.Add(new SamplingPlan() { SamplingPlanID = 1, IsActive = false, SamplingPlanName = @"C:\CSSPLabSheets\SamplingPlan_Subsector_Routine_A1_2019_a_aa.txt", ForGroupName = "a_aa", SampleType = (SampleTypeEnum)109, SamplingPlanType = (SamplingPlanTypeEnum)1, LabSheetType = (LabSheetTypeEnum)1, ProvinceTVItemID = 6, CreatorTVItemID = 2, Year = 2019, AccessCode = "Microlab12", DailyDuplicatePrecisionCriteria = 0.6872000098228455, IntertechDuplicatePrecisionCriteria = 0.09300000220537186, IncludeLaboratoryQAQC = false, ApprovalCode = "aaabbb", SamplingPlanFileTVItemID = 49, AnalyzeMethodDefault = (AnalyzeMethodEnum)6, SampleMatrixDefault = (SampleMatrixEnum)7, LaboratoryDefault = (LaboratoryEnum)19, BackupDirectory = @"\\Atlantic.int.ec.gc.ca\shares\Branches\EPB\ShellFish\CSSPTools\CSSPLabSheets\", LastUpdateDate_UTC = new DateTime(2019, 1, 28, 15, 15, 42), LastUpdateContactTVItemID = 2 });
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 11, TVLevel = 5, TVPath = "p1p5p6p9p10p11", TVType = (TVTypeEnum)20, ParentID = 10, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 18, 53, 40), LastUpdateContactTVItemID = 2});
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

            return labSheetDetail;
        }
        #endregion Functions private
    }
}
