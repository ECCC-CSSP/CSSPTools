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
    public partial class LocalTVItemDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalTVItemDBService LocalTVItemDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalTVItem localTVItem { get; set; }
        #endregion Properties

        #region Constructors
        public LocalTVItemDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalTVItemDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalTVItemDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localTVItem = GetFilledRandomLocalTVItem("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalTVItem_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalTVItemList = await LocalTVItemDBService.GetLocalTVItemList();
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemList.Result).Value);
            List<LocalTVItem> localTVItemList = (List<LocalTVItem>)((OkObjectResult)actionLocalTVItemList.Result).Value;

            count = localTVItemList.Count();

            LocalTVItem localTVItem = GetFilledRandomLocalTVItem("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localTVItem.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("");
            localTVItem.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalTVItem = await LocalTVItemDBService.Post(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localTVItem.TVItemID   (Int32)
            // -----------------------------------

            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("");
            localTVItem.TVItemID = 0;

            actionLocalTVItem = await LocalTVItemDBService.Put(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);

            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("");
            localTVItem.TVItemID = 10000000;
            actionLocalTVItem = await LocalTVItemDBService.Put(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100)]
            // localTVItem.TVLevel   (Int32)
            // -----------------------------------

            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("");
            localTVItem.TVLevel = -1;
            actionLocalTVItem = await LocalTVItemDBService.Post(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);
            //Assert.AreEqual(count, localTVItemService.GetLocalTVItemList().Count());
            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("");
            localTVItem.TVLevel = 101;
            actionLocalTVItem = await LocalTVItemDBService.Post(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);
            //Assert.AreEqual(count, localTVItemDBService.GetLocalTVItemList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // localTVItem.TVPath   (String)
            // -----------------------------------

            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("TVPath");
            actionLocalTVItem = await LocalTVItemDBService.Post(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);

            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("");
            localTVItem.TVPath = GetRandomString("", 251);
            actionLocalTVItem = await LocalTVItemDBService.Post(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);
            //Assert.AreEqual(count, localTVItemDBService.GetLocalTVItemList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localTVItem.TVType   (TVTypeEnum)
            // -----------------------------------

            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("");
            localTVItem.TVType = (TVTypeEnum)1000000;
             actionLocalTVItem = await LocalTVItemDBService.Post(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,RainExceedance,Classification)]
            // localTVItem.ParentID   (Int32)
            // -----------------------------------

            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("");
            localTVItem.ParentID = 0;
            actionLocalTVItem = await LocalTVItemDBService.Post(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);

            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("");
            localTVItem.ParentID = 38;
            actionLocalTVItem = await LocalTVItemDBService.Post(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);


            // -----------------------------------
            // Is NOT Nullable
            // localTVItem.IsActive   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localTVItem.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("");
            localTVItem.LastUpdateDate_UTC = new DateTime();
            actionLocalTVItem = await LocalTVItemDBService.Post(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);
            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("");
            localTVItem.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalTVItem = await LocalTVItemDBService.Post(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localTVItem.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("");
            localTVItem.LastUpdateContactTVItemID = 0;
            actionLocalTVItem = await LocalTVItemDBService.Post(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);

            localTVItem = null;
            localTVItem = GetFilledRandomLocalTVItem("");
            localTVItem.LastUpdateContactTVItemID = 1;
            actionLocalTVItem = await LocalTVItemDBService.Post(localTVItem);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItem.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalTVItem
            var actionLocalTVItemAdded = await LocalTVItemDBService.Post(localTVItem);
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemAdded.Result).Value);
            LocalTVItem localTVItemAdded = (LocalTVItem)((OkObjectResult)actionLocalTVItemAdded.Result).Value;
            Assert.NotNull(localTVItemAdded);

            // List<LocalTVItem>
            var actionLocalTVItemList = await LocalTVItemDBService.GetLocalTVItemList();
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemList.Result).Value);
            List<LocalTVItem> localTVItemList = (List<LocalTVItem>)((OkObjectResult)actionLocalTVItemList.Result).Value;

            int count = ((List<LocalTVItem>)((OkObjectResult)actionLocalTVItemList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalTVItem> with skip and take
            var actionLocalTVItemListSkipAndTake = await LocalTVItemDBService.GetLocalTVItemList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemListSkipAndTake.Result).Value);
            List<LocalTVItem> localTVItemListSkipAndTake = (List<LocalTVItem>)((OkObjectResult)actionLocalTVItemListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalTVItem>)((OkObjectResult)actionLocalTVItemListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localTVItemList[0].TVItemID == localTVItemListSkipAndTake[0].TVItemID);

            // Get LocalTVItem With TVItemID
            var actionLocalTVItemGet = await LocalTVItemDBService.GetLocalTVItemWithTVItemID(localTVItemList[0].TVItemID);
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemGet.Result).Value);
            LocalTVItem localTVItemGet = (LocalTVItem)((OkObjectResult)actionLocalTVItemGet.Result).Value;
            Assert.NotNull(localTVItemGet);
            Assert.Equal(localTVItemGet.TVItemID, localTVItemList[0].TVItemID);

            // Put LocalTVItem
            var actionLocalTVItemUpdated = await LocalTVItemDBService.Put(localTVItem);
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemUpdated.Result).Value);
            LocalTVItem localTVItemUpdated = (LocalTVItem)((OkObjectResult)actionLocalTVItemUpdated.Result).Value;
            Assert.NotNull(localTVItemUpdated);

            // Delete LocalTVItem
            var actionLocalTVItemDeleted = await LocalTVItemDBService.Delete(localTVItem.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalTVItemDeleted.Result).Value;
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
            Services.AddSingleton<ILocalTVItemDBService, LocalTVItemDBService>();

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

            LocalTVItemDBService = Provider.GetService<ILocalTVItemDBService>();
            Assert.NotNull(LocalTVItemDBService);

            return await Task.FromResult(true);
        }
        private LocalTVItem GetFilledRandomLocalTVItem(string OmitPropName)
        {
            LocalTVItem localTVItem = new LocalTVItem();

            if (OmitPropName != "LocalDBCommand") localTVItem.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "TVLevel") localTVItem.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") localTVItem.TVPath = GetRandomString("", 5);
            if (OmitPropName != "TVType") localTVItem.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ParentID") localTVItem.ParentID = 1;
            if (OmitPropName != "IsActive") localTVItem.IsActive = true;
            if (OmitPropName != "LastUpdateDate_UTC") localTVItem.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localTVItem.LastUpdateContactTVItemID = 2;



            return localTVItem;
        }
        private void CheckLocalTVItemFields(List<LocalTVItem> localTVItemList)
        {
            Assert.False(string.IsNullOrWhiteSpace(localTVItemList[0].TVPath));
            if (localTVItemList[0].ParentID != null)
            {
                Assert.NotNull(localTVItemList[0].ParentID);
            }
        }

        #endregion Functions private
    }
}