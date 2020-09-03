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
    public partial class AppTaskServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IAppTaskService AppTaskService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private AppTask appTask { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task AppTask_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            appTask = GetFilledRandomAppTask("");

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
        public async Task AppTask_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionAppTaskList = await AppTaskService.GetAppTaskList();
            Assert.Equal(200, ((ObjectResult)actionAppTaskList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskList.Result).Value);
            List<AppTask> appTaskList = (List<AppTask>)((OkObjectResult)actionAppTaskList.Result).Value;

            count = appTaskList.Count();

            AppTask appTask = GetFilledRandomAppTask("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // appTask.AppTaskID   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.AppTaskID = 0;

            var actionAppTask = await AppTaskService.Put(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.AppTaskID = 10000000;
            actionAppTask = await AppTaskService.Put(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow)]
            // appTask.TVItemID   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.TVItemID = 0;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.TVItemID = 2;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow)]
            // appTask.TVItemID2   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.TVItemID2 = 0;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.TVItemID2 = 2;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTask.AppTaskCommand   (AppTaskCommandEnum)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.AppTaskCommand = (AppTaskCommandEnum)1000000;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTask.AppTaskStatus   (AppTaskStatusEnum)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.AppTaskStatus = (AppTaskStatusEnum)1000000;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100)]
            // appTask.PercentCompleted   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.PercentCompleted = -1;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            //Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());
            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.PercentCompleted = 101;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            //Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // appTask.Parameters   (String)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("Parameters");
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTask.Language   (LanguageEnum)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.Language = (LanguageEnum)1000000;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // appTask.StartDateTime_UTC   (DateTime)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.StartDateTime_UTC = new DateTime();
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.StartDateTime_UTC = new DateTime(1979, 1, 1);
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = StartDateTime_UTC)]
            // appTask.EndDateTime_UTC   (DateTime)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.EndDateTime_UTC = new DateTime(1979, 1, 1);
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000000)]
            // appTask.EstimatedLength_second   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.EstimatedLength_second = -1;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            //Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());
            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.EstimatedLength_second = 1000001;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            //Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000000)]
            // appTask.RemainingTime_second   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.RemainingTime_second = -1;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            //Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());
            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.RemainingTime_second = 1000001;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            //Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // appTask.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.LastUpdateDate_UTC = new DateTime();
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // appTask.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.LastUpdateContactTVItemID = 0;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.LastUpdateContactTVItemID = 1;
            actionAppTask = await AppTaskService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post AppTask
            var actionAppTaskAdded = await AppTaskService.Post(appTask);
            Assert.Equal(200, ((ObjectResult)actionAppTaskAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskAdded.Result).Value);
            AppTask appTaskAdded = (AppTask)((OkObjectResult)actionAppTaskAdded.Result).Value;
            Assert.NotNull(appTaskAdded);

            // List<AppTask>
            var actionAppTaskList = await AppTaskService.GetAppTaskList();
            Assert.Equal(200, ((ObjectResult)actionAppTaskList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskList.Result).Value);
            List<AppTask> appTaskList = (List<AppTask>)((OkObjectResult)actionAppTaskList.Result).Value;

            int count = ((List<AppTask>)((OkObjectResult)actionAppTaskList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<AppTask> with skip and take
                var actionAppTaskListSkipAndTake = await AppTaskService.GetAppTaskList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionAppTaskListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAppTaskListSkipAndTake.Result).Value);
                List<AppTask> appTaskListSkipAndTake = (List<AppTask>)((OkObjectResult)actionAppTaskListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<AppTask>)((OkObjectResult)actionAppTaskListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(appTaskList[0].AppTaskID == appTaskListSkipAndTake[0].AppTaskID);
            }

            // Get AppTask With AppTaskID
            var actionAppTaskGet = await AppTaskService.GetAppTaskWithAppTaskID(appTaskList[0].AppTaskID);
            Assert.Equal(200, ((ObjectResult)actionAppTaskGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskGet.Result).Value);
            AppTask appTaskGet = (AppTask)((OkObjectResult)actionAppTaskGet.Result).Value;
            Assert.NotNull(appTaskGet);
            Assert.Equal(appTaskGet.AppTaskID, appTaskList[0].AppTaskID);

            // Put AppTask
            var actionAppTaskUpdated = await AppTaskService.Put(appTask);
            Assert.Equal(200, ((ObjectResult)actionAppTaskUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskUpdated.Result).Value);
            AppTask appTaskUpdated = (AppTask)((OkObjectResult)actionAppTaskUpdated.Result).Value;
            Assert.NotNull(appTaskUpdated);

            // Delete AppTask
            var actionAppTaskDeleted = await AppTaskService.Delete(appTask.AppTaskID);
            Assert.Equal(200, ((ObjectResult)actionAppTaskDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionAppTaskDeleted.Result).Value;
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
            Services.AddSingleton<IAppTaskService, AppTaskService>();

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

            AppTaskService = Provider.GetService<IAppTaskService>();
            Assert.NotNull(AppTaskService);

            return await Task.FromResult(true);
        }
        private AppTask GetFilledRandomAppTask(string OmitPropName)
        {
            List<AppTask> appTaskListToDelete = (from c in dbLocal.AppTasks
                                                               select c).ToList(); 
            
            dbLocal.AppTasks.RemoveRange(appTaskListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            AppTask appTask = new AppTask();

            if (OmitPropName != "TVItemID") appTask.TVItemID = 1;
            if (OmitPropName != "TVItemID2") appTask.TVItemID2 = 1;
            if (OmitPropName != "AppTaskCommand") appTask.AppTaskCommand = (AppTaskCommandEnum)GetRandomEnumType(typeof(AppTaskCommandEnum));
            if (OmitPropName != "AppTaskStatus") appTask.AppTaskStatus = (AppTaskStatusEnum)GetRandomEnumType(typeof(AppTaskStatusEnum));
            if (OmitPropName != "PercentCompleted") appTask.PercentCompleted = GetRandomInt(0, 100);
            if (OmitPropName != "Parameters") appTask.Parameters = GetRandomString("", 20);
            if (OmitPropName != "Language") appTask.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "StartDateTime_UTC") appTask.StartDateTime_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_UTC") appTask.EndDateTime_UTC = new DateTime(2005, 3, 7);
            if (OmitPropName != "EstimatedLength_second") appTask.EstimatedLength_second = GetRandomInt(0, 1000000);
            if (OmitPropName != "RemainingTime_second") appTask.RemainingTime_second = GetRandomInt(0, 1000000);
            if (OmitPropName != "LastUpdateDate_UTC") appTask.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appTask.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "AppTaskID") appTask.AppTaskID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 1, TVLevel = 0, TVPath = "p1", TVType = (TVTypeEnum)1, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
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

            return appTask;
        }
        private void CheckAppTaskFields(List<AppTask> appTaskList)
        {
            Assert.False(string.IsNullOrWhiteSpace(appTaskList[0].Parameters));
            if (appTaskList[0].EndDateTime_UTC != null)
            {
                Assert.NotNull(appTaskList[0].EndDateTime_UTC);
            }
            if (appTaskList[0].EstimatedLength_second != null)
            {
                Assert.NotNull(appTaskList[0].EstimatedLength_second);
            }
            if (appTaskList[0].RemainingTime_second != null)
            {
                Assert.NotNull(appTaskList[0].RemainingTime_second);
            }
        }
        #endregion Functions private
    }
}
