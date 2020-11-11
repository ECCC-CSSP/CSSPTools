/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
    public partial class DrogueRunDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IDrogueRunDBService DrogueRunDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private DrogueRun drogueRun { get; set; }
        #endregion Properties

        #region Constructors
        public DrogueRunDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DrogueRunDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DrogueRunDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            drogueRun = GetFilledRandomDrogueRun("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DrogueRun_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionDrogueRunList = await DrogueRunDBService.GetDrogueRunList();
            Assert.Equal(200, ((ObjectResult)actionDrogueRunList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDrogueRunList.Result).Value);
            List<DrogueRun> drogueRunList = (List<DrogueRun>)((OkObjectResult)actionDrogueRunList.Result).Value;

            count = drogueRunList.Count();

            DrogueRun drogueRun = GetFilledRandomDrogueRun("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // drogueRun.DrogueRunID   (Int32)
            // -----------------------------------

            drogueRun = null;
            drogueRun = GetFilledRandomDrogueRun("");
            drogueRun.DrogueRunID = 0;

            var actionDrogueRun = await DrogueRunDBService.Put(drogueRun);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRun.Result);

            drogueRun = null;
            drogueRun = GetFilledRandomDrogueRun("");
            drogueRun.DrogueRunID = 10000000;
            actionDrogueRun = await DrogueRunDBService.Put(drogueRun);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRun.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
            // drogueRun.SubsectorTVItemID   (Int32)
            // -----------------------------------

            drogueRun = null;
            drogueRun = GetFilledRandomDrogueRun("");
            drogueRun.SubsectorTVItemID = 0;
            actionDrogueRun = await DrogueRunDBService.Post(drogueRun);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRun.Result);

            drogueRun = null;
            drogueRun = GetFilledRandomDrogueRun("");
            drogueRun.SubsectorTVItemID = 1;
            actionDrogueRun = await DrogueRunDBService.Post(drogueRun);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRun.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100)]
            // drogueRun.DrogueNumber   (Int32)
            // -----------------------------------

            drogueRun = null;
            drogueRun = GetFilledRandomDrogueRun("");
            drogueRun.DrogueNumber = -1;
            actionDrogueRun = await DrogueRunDBService.Post(drogueRun);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRun.Result);
            //Assert.AreEqual(count, drogueRunService.GetDrogueRunList().Count());
            drogueRun = null;
            drogueRun = GetFilledRandomDrogueRun("");
            drogueRun.DrogueNumber = 101;
            actionDrogueRun = await DrogueRunDBService.Post(drogueRun);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRun.Result);
            //Assert.AreEqual(count, drogueRunDBService.GetDrogueRunList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // drogueRun.DrogueType   (DrogueTypeEnum)
            // -----------------------------------

            drogueRun = null;
            drogueRun = GetFilledRandomDrogueRun("");
            drogueRun.DrogueType = (DrogueTypeEnum)1000000;
            actionDrogueRun = await DrogueRunDBService.Post(drogueRun);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRun.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // drogueRun.RunStartDateTime   (DateTime)
            // -----------------------------------

            drogueRun = null;
            drogueRun = GetFilledRandomDrogueRun("");
            drogueRun.RunStartDateTime = new DateTime();
            actionDrogueRun = await DrogueRunDBService.Post(drogueRun);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRun.Result);
            drogueRun = null;
            drogueRun = GetFilledRandomDrogueRun("");
            drogueRun.RunStartDateTime = new DateTime(1979, 1, 1);
            actionDrogueRun = await DrogueRunDBService.Post(drogueRun);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRun.Result);

            // -----------------------------------
            // Is NOT Nullable
            // drogueRun.IsRisingTide   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // drogueRun.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            drogueRun = null;
            drogueRun = GetFilledRandomDrogueRun("");
            drogueRun.LastUpdateDate_UTC = new DateTime();
            actionDrogueRun = await DrogueRunDBService.Post(drogueRun);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRun.Result);
            drogueRun = null;
            drogueRun = GetFilledRandomDrogueRun("");
            drogueRun.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionDrogueRun = await DrogueRunDBService.Post(drogueRun);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRun.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // drogueRun.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            drogueRun = null;
            drogueRun = GetFilledRandomDrogueRun("");
            drogueRun.LastUpdateContactTVItemID = 0;
            actionDrogueRun = await DrogueRunDBService.Post(drogueRun);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRun.Result);

            drogueRun = null;
            drogueRun = GetFilledRandomDrogueRun("");
            drogueRun.LastUpdateContactTVItemID = 1;
            actionDrogueRun = await DrogueRunDBService.Post(drogueRun);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRun.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post DrogueRun
            var actionDrogueRunAdded = await DrogueRunDBService.Post(drogueRun);
            Assert.Equal(200, ((ObjectResult)actionDrogueRunAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDrogueRunAdded.Result).Value);
            DrogueRun drogueRunAdded = (DrogueRun)((OkObjectResult)actionDrogueRunAdded.Result).Value;
            Assert.NotNull(drogueRunAdded);

            // List<DrogueRun>
            var actionDrogueRunList = await DrogueRunDBService.GetDrogueRunList();
            Assert.Equal(200, ((ObjectResult)actionDrogueRunList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDrogueRunList.Result).Value);
            List<DrogueRun> drogueRunList = (List<DrogueRun>)((OkObjectResult)actionDrogueRunList.Result).Value;

            int count = ((List<DrogueRun>)((OkObjectResult)actionDrogueRunList.Result).Value).Count();
            Assert.True(count > 0);

            // List<DrogueRun> with skip and take
            var actionDrogueRunListSkipAndTake = await DrogueRunDBService.GetDrogueRunList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionDrogueRunListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDrogueRunListSkipAndTake.Result).Value);
            List<DrogueRun> drogueRunListSkipAndTake = (List<DrogueRun>)((OkObjectResult)actionDrogueRunListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<DrogueRun>)((OkObjectResult)actionDrogueRunListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(drogueRunList[0].DrogueRunID == drogueRunListSkipAndTake[0].DrogueRunID);

            // Get DrogueRun With DrogueRunID
            var actionDrogueRunGet = await DrogueRunDBService.GetDrogueRunWithDrogueRunID(drogueRunList[0].DrogueRunID);
            Assert.Equal(200, ((ObjectResult)actionDrogueRunGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDrogueRunGet.Result).Value);
            DrogueRun drogueRunGet = (DrogueRun)((OkObjectResult)actionDrogueRunGet.Result).Value;
            Assert.NotNull(drogueRunGet);
            Assert.Equal(drogueRunGet.DrogueRunID, drogueRunList[0].DrogueRunID);

            // Put DrogueRun
            var actionDrogueRunUpdated = await DrogueRunDBService.Put(drogueRun);
            Assert.Equal(200, ((ObjectResult)actionDrogueRunUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDrogueRunUpdated.Result).Value);
            DrogueRun drogueRunUpdated = (DrogueRun)((OkObjectResult)actionDrogueRunUpdated.Result).Value;
            Assert.NotNull(drogueRunUpdated);

            // Delete DrogueRun
            var actionDrogueRunDeleted = await DrogueRunDBService.Delete(drogueRun.DrogueRunID);
            Assert.Equal(200, ((ObjectResult)actionDrogueRunDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDrogueRunDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionDrogueRunDeleted.Result).Value;
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

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IDrogueRunDBService, DrogueRunDBService>();

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

            DrogueRunDBService = Provider.GetService<IDrogueRunDBService>();
            Assert.NotNull(DrogueRunDBService);

            return await Task.FromResult(true);
        }
        private DrogueRun GetFilledRandomDrogueRun(string OmitPropName)
        {
            DrogueRun drogueRun = new DrogueRun();

            if (OmitPropName != "SubsectorTVItemID") drogueRun.SubsectorTVItemID = 11;
            if (OmitPropName != "DrogueNumber") drogueRun.DrogueNumber = GetRandomInt(0, 100);
            if (OmitPropName != "DrogueType") drogueRun.DrogueType = (DrogueTypeEnum)GetRandomEnumType(typeof(DrogueTypeEnum));
            if (OmitPropName != "RunStartDateTime") drogueRun.RunStartDateTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IsRisingTide") drogueRun.IsRisingTide = true;
            if (OmitPropName != "LastUpdateDate_UTC") drogueRun.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") drogueRun.LastUpdateContactTVItemID = 2;



            return drogueRun;
        }
        private void CheckDrogueRunFields(List<DrogueRun> drogueRunList)
        {
        }

        #endregion Functions private
    }
}
