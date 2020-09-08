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
using LoggedInServices;

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class AppTaskDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IAppTaskDBService AppTaskDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private AppTask appTask { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DB]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            appTask = GetFilledRandomAppTask("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTask_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionAppTaskList = await AppTaskDBService.GetAppTaskList();
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

            var actionAppTask = await AppTaskDBService.Put(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.AppTaskID = 10000000;
            actionAppTask = await AppTaskDBService.Put(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow)]
            // appTask.TVItemID   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.TVItemID = 0;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.TVItemID = 2;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow)]
            // appTask.TVItemID2   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.TVItemID2 = 0;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.TVItemID2 = 2;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTask.AppTaskCommand   (AppTaskCommandEnum)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.AppTaskCommand = (AppTaskCommandEnum)1000000;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTask.AppTaskStatus   (AppTaskStatusEnum)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.AppTaskStatus = (AppTaskStatusEnum)1000000;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100)]
            // appTask.PercentCompleted   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.PercentCompleted = -1;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            //Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());
            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.PercentCompleted = 101;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            //Assert.AreEqual(count, appTaskDBService.GetAppTaskList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // appTask.Parameters   (String)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("Parameters");
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTask.Language   (LanguageEnum)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.Language = (LanguageEnum)1000000;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // appTask.StartDateTime_UTC   (DateTime)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.StartDateTime_UTC = new DateTime();
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.StartDateTime_UTC = new DateTime(1979, 1, 1);
            actionAppTask = await AppTaskDBService.Post(appTask);
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
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000000)]
            // appTask.EstimatedLength_second   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.EstimatedLength_second = -1;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            //Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());
            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.EstimatedLength_second = 1000001;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            //Assert.AreEqual(count, appTaskDBService.GetAppTaskList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000000)]
            // appTask.RemainingTime_second   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.RemainingTime_second = -1;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            //Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());
            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.RemainingTime_second = 1000001;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            //Assert.AreEqual(count, appTaskDBService.GetAppTaskList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // appTask.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.LastUpdateDate_UTC = new DateTime();
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);
            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // appTask.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.LastUpdateContactTVItemID = 0;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.LastUpdateContactTVItemID = 1;
            actionAppTask = await AppTaskDBService.Post(appTask);
            Assert.IsType<BadRequestObjectResult>(actionAppTask.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post AppTask
            var actionAppTaskAdded = await AppTaskDBService.Post(appTask);
            Assert.Equal(200, ((ObjectResult)actionAppTaskAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskAdded.Result).Value);
            AppTask appTaskAdded = (AppTask)((OkObjectResult)actionAppTaskAdded.Result).Value;
            Assert.NotNull(appTaskAdded);

            // List<AppTask>
            var actionAppTaskList = await AppTaskDBService.GetAppTaskList();
            Assert.Equal(200, ((ObjectResult)actionAppTaskList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskList.Result).Value);
            List<AppTask> appTaskList = (List<AppTask>)((OkObjectResult)actionAppTaskList.Result).Value;

            int count = ((List<AppTask>)((OkObjectResult)actionAppTaskList.Result).Value).Count();
            Assert.True(count > 0);

            // List<AppTask> with skip and take
            var actionAppTaskListSkipAndTake = await AppTaskDBService.GetAppTaskList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionAppTaskListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskListSkipAndTake.Result).Value);
            List<AppTask> appTaskListSkipAndTake = (List<AppTask>)((OkObjectResult)actionAppTaskListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<AppTask>)((OkObjectResult)actionAppTaskListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(appTaskList[0].AppTaskID == appTaskListSkipAndTake[0].AppTaskID);

            // Get AppTask With AppTaskID
            var actionAppTaskGet = await AppTaskDBService.GetAppTaskWithAppTaskID(appTaskList[0].AppTaskID);
            Assert.Equal(200, ((ObjectResult)actionAppTaskGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskGet.Result).Value);
            AppTask appTaskGet = (AppTask)((OkObjectResult)actionAppTaskGet.Result).Value;
            Assert.NotNull(appTaskGet);
            Assert.Equal(appTaskGet.AppTaskID, appTaskList[0].AppTaskID);

            // Put AppTask
            var actionAppTaskUpdated = await AppTaskDBService.Put(appTask);
            Assert.Equal(200, ((ObjectResult)actionAppTaskUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskUpdated.Result).Value);
            AppTask appTaskUpdated = (AppTask)((OkObjectResult)actionAppTaskUpdated.Result).Value;
            Assert.NotNull(appTaskUpdated);

            // Delete AppTask
            var actionAppTaskDeleted = await AppTaskDBService.Delete(appTask.AppTaskID);
            Assert.Equal(200, ((ObjectResult)actionAppTaskDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionAppTaskDeleted.Result).Value;
            Assert.True(retBool);

            db.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("70c662c1-a1a8-4b2c-b594-d7834bb5e6db")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAppTaskDBService, AppTaskDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            AppTaskDBService = Provider.GetService<IAppTaskDBService>();
            Assert.NotNull(AppTaskDBService);

            return await Task.FromResult(true);
        }
        private AppTask GetFilledRandomAppTask(string OmitPropName)
        {
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
