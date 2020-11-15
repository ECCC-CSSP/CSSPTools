/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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
using LocalServices;
using CSSPDBModels;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class LocalMWQMSiteStartEndDateDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalMWQMSiteStartEndDateDBService LocalMWQMSiteStartEndDateDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalMWQMSiteStartEndDate localMWQMSiteStartEndDate { get; set; }
        #endregion Properties

        #region Constructors
        public LocalMWQMSiteStartEndDateDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalMWQMSiteStartEndDateDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalMWQMSiteStartEndDateDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalMWQMSiteStartEndDate_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalMWQMSiteStartEndDateList = await LocalMWQMSiteStartEndDateDBService.GetLocalMWQMSiteStartEndDateList();
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSiteStartEndDateList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSiteStartEndDateList.Result).Value);
            List<LocalMWQMSiteStartEndDate> localMWQMSiteStartEndDateList = (List<LocalMWQMSiteStartEndDate>)((OkObjectResult)actionLocalMWQMSiteStartEndDateList.Result).Value;

            count = localMWQMSiteStartEndDateList.Count();

            LocalMWQMSiteStartEndDate localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localMWQMSiteStartEndDate.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localMWQMSiteStartEndDate = null;
            localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");
            localMWQMSiteStartEndDate.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalMWQMSiteStartEndDate = await LocalMWQMSiteStartEndDateDBService.Post(localMWQMSiteStartEndDate);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSiteStartEndDate.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localMWQMSiteStartEndDate.MWQMSiteStartEndDateID   (Int32)
            // -----------------------------------

            localMWQMSiteStartEndDate = null;
            localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");
            localMWQMSiteStartEndDate.MWQMSiteStartEndDateID = 0;

            actionLocalMWQMSiteStartEndDate = await LocalMWQMSiteStartEndDateDBService.Put(localMWQMSiteStartEndDate);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSiteStartEndDate.Result);

            localMWQMSiteStartEndDate = null;
            localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");
            localMWQMSiteStartEndDate.MWQMSiteStartEndDateID = 10000000;
            actionLocalMWQMSiteStartEndDate = await LocalMWQMSiteStartEndDateDBService.Put(localMWQMSiteStartEndDate);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSiteStartEndDate.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
            // localMWQMSiteStartEndDate.MWQMSiteTVItemID   (Int32)
            // -----------------------------------

            localMWQMSiteStartEndDate = null;
            localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");
            localMWQMSiteStartEndDate.MWQMSiteTVItemID = 0;
            actionLocalMWQMSiteStartEndDate = await LocalMWQMSiteStartEndDateDBService.Post(localMWQMSiteStartEndDate);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSiteStartEndDate.Result);

            localMWQMSiteStartEndDate = null;
            localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");
            localMWQMSiteStartEndDate.MWQMSiteTVItemID = 1;
            actionLocalMWQMSiteStartEndDate = await LocalMWQMSiteStartEndDateDBService.Post(localMWQMSiteStartEndDate);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSiteStartEndDate.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localMWQMSiteStartEndDate.StartDate   (DateTime)
            // -----------------------------------

            localMWQMSiteStartEndDate = null;
            localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");
            localMWQMSiteStartEndDate.StartDate = new DateTime();
            actionLocalMWQMSiteStartEndDate = await LocalMWQMSiteStartEndDateDBService.Post(localMWQMSiteStartEndDate);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSiteStartEndDate.Result);
            localMWQMSiteStartEndDate = null;
            localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");
            localMWQMSiteStartEndDate.StartDate = new DateTime(1979, 1, 1);
            actionLocalMWQMSiteStartEndDate = await LocalMWQMSiteStartEndDateDBService.Post(localMWQMSiteStartEndDate);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSiteStartEndDate.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = StartDate)]
            // localMWQMSiteStartEndDate.EndDate   (DateTime)
            // -----------------------------------

            localMWQMSiteStartEndDate = null;
            localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");
            localMWQMSiteStartEndDate.EndDate = new DateTime(1979, 1, 1);
            actionLocalMWQMSiteStartEndDate = await LocalMWQMSiteStartEndDateDBService.Post(localMWQMSiteStartEndDate);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSiteStartEndDate.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localMWQMSiteStartEndDate.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localMWQMSiteStartEndDate = null;
            localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");
            localMWQMSiteStartEndDate.LastUpdateDate_UTC = new DateTime();
            actionLocalMWQMSiteStartEndDate = await LocalMWQMSiteStartEndDateDBService.Post(localMWQMSiteStartEndDate);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSiteStartEndDate.Result);
            localMWQMSiteStartEndDate = null;
            localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");
            localMWQMSiteStartEndDate.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalMWQMSiteStartEndDate = await LocalMWQMSiteStartEndDateDBService.Post(localMWQMSiteStartEndDate);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSiteStartEndDate.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localMWQMSiteStartEndDate.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localMWQMSiteStartEndDate = null;
            localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");
            localMWQMSiteStartEndDate.LastUpdateContactTVItemID = 0;
            actionLocalMWQMSiteStartEndDate = await LocalMWQMSiteStartEndDateDBService.Post(localMWQMSiteStartEndDate);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSiteStartEndDate.Result);

            localMWQMSiteStartEndDate = null;
            localMWQMSiteStartEndDate = GetFilledRandomLocalMWQMSiteStartEndDate("");
            localMWQMSiteStartEndDate.LastUpdateContactTVItemID = 1;
            actionLocalMWQMSiteStartEndDate = await LocalMWQMSiteStartEndDateDBService.Post(localMWQMSiteStartEndDate);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSiteStartEndDate.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalMWQMSiteStartEndDate
            var actionLocalMWQMSiteStartEndDateAdded = await LocalMWQMSiteStartEndDateDBService.Post(localMWQMSiteStartEndDate);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSiteStartEndDateAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSiteStartEndDateAdded.Result).Value);
            LocalMWQMSiteStartEndDate localMWQMSiteStartEndDateAdded = (LocalMWQMSiteStartEndDate)((OkObjectResult)actionLocalMWQMSiteStartEndDateAdded.Result).Value;
            Assert.NotNull(localMWQMSiteStartEndDateAdded);

            // List<LocalMWQMSiteStartEndDate>
            var actionLocalMWQMSiteStartEndDateList = await LocalMWQMSiteStartEndDateDBService.GetLocalMWQMSiteStartEndDateList();
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSiteStartEndDateList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSiteStartEndDateList.Result).Value);
            List<LocalMWQMSiteStartEndDate> localMWQMSiteStartEndDateList = (List<LocalMWQMSiteStartEndDate>)((OkObjectResult)actionLocalMWQMSiteStartEndDateList.Result).Value;

            int count = ((List<LocalMWQMSiteStartEndDate>)((OkObjectResult)actionLocalMWQMSiteStartEndDateList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalMWQMSiteStartEndDate> with skip and take
            var actionLocalMWQMSiteStartEndDateListSkipAndTake = await LocalMWQMSiteStartEndDateDBService.GetLocalMWQMSiteStartEndDateList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSiteStartEndDateListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSiteStartEndDateListSkipAndTake.Result).Value);
            List<LocalMWQMSiteStartEndDate> localMWQMSiteStartEndDateListSkipAndTake = (List<LocalMWQMSiteStartEndDate>)((OkObjectResult)actionLocalMWQMSiteStartEndDateListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalMWQMSiteStartEndDate>)((OkObjectResult)actionLocalMWQMSiteStartEndDateListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localMWQMSiteStartEndDateList[0].MWQMSiteStartEndDateID == localMWQMSiteStartEndDateListSkipAndTake[0].MWQMSiteStartEndDateID);

            // Get LocalMWQMSiteStartEndDate With MWQMSiteStartEndDateID
            var actionLocalMWQMSiteStartEndDateGet = await LocalMWQMSiteStartEndDateDBService.GetLocalMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(localMWQMSiteStartEndDateList[0].MWQMSiteStartEndDateID);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSiteStartEndDateGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSiteStartEndDateGet.Result).Value);
            LocalMWQMSiteStartEndDate localMWQMSiteStartEndDateGet = (LocalMWQMSiteStartEndDate)((OkObjectResult)actionLocalMWQMSiteStartEndDateGet.Result).Value;
            Assert.NotNull(localMWQMSiteStartEndDateGet);
            Assert.Equal(localMWQMSiteStartEndDateGet.MWQMSiteStartEndDateID, localMWQMSiteStartEndDateList[0].MWQMSiteStartEndDateID);

            // Put LocalMWQMSiteStartEndDate
            var actionLocalMWQMSiteStartEndDateUpdated = await LocalMWQMSiteStartEndDateDBService.Put(localMWQMSiteStartEndDate);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSiteStartEndDateUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSiteStartEndDateUpdated.Result).Value);
            LocalMWQMSiteStartEndDate localMWQMSiteStartEndDateUpdated = (LocalMWQMSiteStartEndDate)((OkObjectResult)actionLocalMWQMSiteStartEndDateUpdated.Result).Value;
            Assert.NotNull(localMWQMSiteStartEndDateUpdated);

            // Delete LocalMWQMSiteStartEndDate
            var actionLocalMWQMSiteStartEndDateDeleted = await LocalMWQMSiteStartEndDateDBService.Delete(localMWQMSiteStartEndDate.MWQMSiteStartEndDateID);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSiteStartEndDateDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSiteStartEndDateDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalMWQMSiteStartEndDateDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocal = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILocalMWQMSiteStartEndDateDBService, LocalMWQMSiteStartEndDateDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            LocalMWQMSiteStartEndDateDBService = Provider.GetService<ILocalMWQMSiteStartEndDateDBService>();
            Assert.NotNull(LocalMWQMSiteStartEndDateDBService);

            return await Task.FromResult(true);
        }
        private LocalMWQMSiteStartEndDate GetFilledRandomLocalMWQMSiteStartEndDate(string OmitPropName)
        {
            LocalMWQMSiteStartEndDate localMWQMSiteStartEndDate = new LocalMWQMSiteStartEndDate();

            if (OmitPropName != "LocalDBCommand") localMWQMSiteStartEndDate.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "MWQMSiteTVItemID") localMWQMSiteStartEndDate.MWQMSiteTVItemID = 44;
            if (OmitPropName != "StartDate") localMWQMSiteStartEndDate.StartDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDate") localMWQMSiteStartEndDate.EndDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateDate_UTC") localMWQMSiteStartEndDate.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localMWQMSiteStartEndDate.LastUpdateContactTVItemID = 2;



            return localMWQMSiteStartEndDate;
        }
        private void CheckLocalMWQMSiteStartEndDateFields(List<LocalMWQMSiteStartEndDate> localMWQMSiteStartEndDateList)
        {
            if (localMWQMSiteStartEndDateList[0].EndDate != null)
            {
                Assert.NotNull(localMWQMSiteStartEndDateList[0].EndDate);
            }
        }

        #endregion Functions private
    }
}