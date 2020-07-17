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
    public partial class SamplingPlanServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ISamplingPlanService SamplingPlanService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private SamplingPlan samplingPlan { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task SamplingPlan_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            samplingPlan = GetFilledRandomSamplingPlan("");

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

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post SamplingPlan
            var actionSamplingPlanAdded = await SamplingPlanService.Post(samplingPlan);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanAdded.Result).Value);
            SamplingPlan samplingPlanAdded = (SamplingPlan)((OkObjectResult)actionSamplingPlanAdded.Result).Value;
            Assert.NotNull(samplingPlanAdded);

            // List<SamplingPlan>
            var actionSamplingPlanList = await SamplingPlanService.GetSamplingPlanList();
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanList.Result).Value);
            List<SamplingPlan> samplingPlanList = (List<SamplingPlan>)((OkObjectResult)actionSamplingPlanList.Result).Value;

            int count = ((List<SamplingPlan>)((OkObjectResult)actionSamplingPlanList.Result).Value).Count();
            Assert.True(count > 0);

            // Put SamplingPlan
            var actionSamplingPlanUpdated = await SamplingPlanService.Put(samplingPlan);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanUpdated.Result).Value);
            SamplingPlan samplingPlanUpdated = (SamplingPlan)((OkObjectResult)actionSamplingPlanUpdated.Result).Value;
            Assert.NotNull(samplingPlanUpdated);

            // Delete SamplingPlan
            var actionSamplingPlanDeleted = await SamplingPlanService.Delete(samplingPlan.SamplingPlanID);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionSamplingPlanDeleted.Result).Value;
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
            Services.AddSingleton<ISamplingPlanService, SamplingPlanService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.DBLocation = DBLocationEnum.Local;

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            SamplingPlanService = Provider.GetService<ISamplingPlanService>();
            Assert.NotNull(SamplingPlanService);

            return await Task.FromResult(true);
        }
        private SamplingPlan GetFilledRandomSamplingPlan(string OmitPropName)
        {
            List<SamplingPlan> samplingPlanListToDelete = (from c in dbLocal.SamplingPlans
                                                               select c).ToList(); 
            
            dbLocal.SamplingPlans.RemoveRange(samplingPlanListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            SamplingPlan samplingPlan = new SamplingPlan();

            if (OmitPropName != "IsActive") samplingPlan.IsActive = true;
            if (OmitPropName != "SamplingPlanName") samplingPlan.SamplingPlanName = GetRandomString("", 5);
            if (OmitPropName != "ForGroupName") samplingPlan.ForGroupName = GetRandomString("", 5);
            if (OmitPropName != "SampleType") samplingPlan.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "SamplingPlanType") samplingPlan.SamplingPlanType = (SamplingPlanTypeEnum)GetRandomEnumType(typeof(SamplingPlanTypeEnum));
            if (OmitPropName != "LabSheetType") samplingPlan.LabSheetType = (LabSheetTypeEnum)GetRandomEnumType(typeof(LabSheetTypeEnum));
            if (OmitPropName != "ProvinceTVItemID") samplingPlan.ProvinceTVItemID = 6;
            if (OmitPropName != "CreatorTVItemID") samplingPlan.CreatorTVItemID = 2;
            if (OmitPropName != "Year") samplingPlan.Year = GetRandomInt(2000, 2050);
            if (OmitPropName != "AccessCode") samplingPlan.AccessCode = GetRandomString("", 5);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") samplingPlan.DailyDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") samplingPlan.IntertechDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IncludeLaboratoryQAQC") samplingPlan.IncludeLaboratoryQAQC = true;
            if (OmitPropName != "ApprovalCode") samplingPlan.ApprovalCode = GetRandomString("", 5);
            if (OmitPropName != "SamplingPlanFileTVItemID") samplingPlan.SamplingPlanFileTVItemID = 42;
            if (OmitPropName != "AnalyzeMethodDefault") samplingPlan.AnalyzeMethodDefault = (AnalyzeMethodEnum)GetRandomEnumType(typeof(AnalyzeMethodEnum));
            if (OmitPropName != "SampleMatrixDefault") samplingPlan.SampleMatrixDefault = (SampleMatrixEnum)GetRandomEnumType(typeof(SampleMatrixEnum));
            if (OmitPropName != "LaboratoryDefault") samplingPlan.LaboratoryDefault = (LaboratoryEnum)GetRandomEnumType(typeof(LaboratoryEnum));
            if (OmitPropName != "BackupDirectory") samplingPlan.BackupDirectory = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlan.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlan.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "SamplingPlanID") samplingPlan.SamplingPlanID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 6, TVLevel = 2, TVPath = "p1p5p6", TVType = (TVTypeEnum)18, ParentID = 5, IsActive = true, LastUpdateDate_UTC = new DateTime(2015, 2, 17, 14, 14, 24), LastUpdateContactTVItemID = 2});
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
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 42, TVLevel = 5, TVPath = "p1p5p6p39p41p42", TVType = (TVTypeEnum)8, ParentID = 41, IsActive = true, LastUpdateDate_UTC = new DateTime(2016, 5, 5, 17, 18, 26), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
            }

            return samplingPlan;
        }
        #endregion Functions private
    }
}
