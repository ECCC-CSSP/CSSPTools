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
    public partial class LocalMWQMLookupMPNDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalMWQMLookupMPNDBService LocalMWQMLookupMPNDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalMWQMLookupMPN localMWQMLookupMPN { get; set; }
        #endregion Properties

        #region Constructors
        public LocalMWQMLookupMPNDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalMWQMLookupMPNDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalMWQMLookupMPNDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalMWQMLookupMPN_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalMWQMLookupMPNList = await LocalMWQMLookupMPNDBService.GetLocalMWQMLookupMPNList();
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMLookupMPNList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMLookupMPNList.Result).Value);
            List<LocalMWQMLookupMPN> localMWQMLookupMPNList = (List<LocalMWQMLookupMPN>)((OkObjectResult)actionLocalMWQMLookupMPNList.Result).Value;

            count = localMWQMLookupMPNList.Count();

            LocalMWQMLookupMPN localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localMWQMLookupMPN.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localMWQMLookupMPN.MWQMLookupMPNID   (Int32)
            // -----------------------------------

            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.MWQMLookupMPNID = 0;

            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Put(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);

            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.MWQMLookupMPNID = 10000000;
            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Put(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 5)]
            // localMWQMLookupMPN.Tubes10   (Int32)
            // -----------------------------------

            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.Tubes10 = -1;
            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);
            //Assert.AreEqual(count, localMWQMLookupMPNService.GetLocalMWQMLookupMPNList().Count());
            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.Tubes10 = 6;
            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);
            //Assert.AreEqual(count, localMWQMLookupMPNDBService.GetLocalMWQMLookupMPNList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 5)]
            // localMWQMLookupMPN.Tubes1   (Int32)
            // -----------------------------------

            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.Tubes1 = -1;
            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);
            //Assert.AreEqual(count, localMWQMLookupMPNService.GetLocalMWQMLookupMPNList().Count());
            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.Tubes1 = 6;
            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);
            //Assert.AreEqual(count, localMWQMLookupMPNDBService.GetLocalMWQMLookupMPNList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 5)]
            // localMWQMLookupMPN.Tubes01   (Int32)
            // -----------------------------------

            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.Tubes01 = -1;
            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);
            //Assert.AreEqual(count, localMWQMLookupMPNService.GetLocalMWQMLookupMPNList().Count());
            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.Tubes01 = 6;
            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);
            //Assert.AreEqual(count, localMWQMLookupMPNDBService.GetLocalMWQMLookupMPNList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, 10000)]
            // localMWQMLookupMPN.MPN_100ml   (Int32)
            // -----------------------------------

            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.MPN_100ml = 0;
            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);
            //Assert.AreEqual(count, localMWQMLookupMPNService.GetLocalMWQMLookupMPNList().Count());
            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.MPN_100ml = 10001;
            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);
            //Assert.AreEqual(count, localMWQMLookupMPNDBService.GetLocalMWQMLookupMPNList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localMWQMLookupMPN.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.LastUpdateDate_UTC = new DateTime();
            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);
            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localMWQMLookupMPN.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.LastUpdateContactTVItemID = 0;
            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);

            localMWQMLookupMPN = null;
            localMWQMLookupMPN = GetFilledRandomLocalMWQMLookupMPN("");
            localMWQMLookupMPN.LastUpdateContactTVItemID = 1;
            actionLocalMWQMLookupMPN = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMLookupMPN.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalMWQMLookupMPN
            var actionLocalMWQMLookupMPNAdded = await LocalMWQMLookupMPNDBService.Post(localMWQMLookupMPN);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMLookupMPNAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMLookupMPNAdded.Result).Value);
            LocalMWQMLookupMPN localMWQMLookupMPNAdded = (LocalMWQMLookupMPN)((OkObjectResult)actionLocalMWQMLookupMPNAdded.Result).Value;
            Assert.NotNull(localMWQMLookupMPNAdded);

            // List<LocalMWQMLookupMPN>
            var actionLocalMWQMLookupMPNList = await LocalMWQMLookupMPNDBService.GetLocalMWQMLookupMPNList();
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMLookupMPNList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMLookupMPNList.Result).Value);
            List<LocalMWQMLookupMPN> localMWQMLookupMPNList = (List<LocalMWQMLookupMPN>)((OkObjectResult)actionLocalMWQMLookupMPNList.Result).Value;

            int count = ((List<LocalMWQMLookupMPN>)((OkObjectResult)actionLocalMWQMLookupMPNList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalMWQMLookupMPN> with skip and take
            var actionLocalMWQMLookupMPNListSkipAndTake = await LocalMWQMLookupMPNDBService.GetLocalMWQMLookupMPNList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMLookupMPNListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMLookupMPNListSkipAndTake.Result).Value);
            List<LocalMWQMLookupMPN> localMWQMLookupMPNListSkipAndTake = (List<LocalMWQMLookupMPN>)((OkObjectResult)actionLocalMWQMLookupMPNListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalMWQMLookupMPN>)((OkObjectResult)actionLocalMWQMLookupMPNListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localMWQMLookupMPNList[0].MWQMLookupMPNID == localMWQMLookupMPNListSkipAndTake[0].MWQMLookupMPNID);

            // Get LocalMWQMLookupMPN With MWQMLookupMPNID
            var actionLocalMWQMLookupMPNGet = await LocalMWQMLookupMPNDBService.GetLocalMWQMLookupMPNWithMWQMLookupMPNID(localMWQMLookupMPNList[0].MWQMLookupMPNID);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMLookupMPNGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMLookupMPNGet.Result).Value);
            LocalMWQMLookupMPN localMWQMLookupMPNGet = (LocalMWQMLookupMPN)((OkObjectResult)actionLocalMWQMLookupMPNGet.Result).Value;
            Assert.NotNull(localMWQMLookupMPNGet);
            Assert.Equal(localMWQMLookupMPNGet.MWQMLookupMPNID, localMWQMLookupMPNList[0].MWQMLookupMPNID);

            // Put LocalMWQMLookupMPN
            var actionLocalMWQMLookupMPNUpdated = await LocalMWQMLookupMPNDBService.Put(localMWQMLookupMPN);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMLookupMPNUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMLookupMPNUpdated.Result).Value);
            LocalMWQMLookupMPN localMWQMLookupMPNUpdated = (LocalMWQMLookupMPN)((OkObjectResult)actionLocalMWQMLookupMPNUpdated.Result).Value;
            Assert.NotNull(localMWQMLookupMPNUpdated);

            // Delete LocalMWQMLookupMPN
            var actionLocalMWQMLookupMPNDeleted = await LocalMWQMLookupMPNDBService.Delete(localMWQMLookupMPN.MWQMLookupMPNID);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMLookupMPNDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMLookupMPNDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalMWQMLookupMPNDeleted.Result).Value;
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
            Services.AddSingleton<ILocalMWQMLookupMPNDBService, LocalMWQMLookupMPNDBService>();

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

            LocalMWQMLookupMPNDBService = Provider.GetService<ILocalMWQMLookupMPNDBService>();
            Assert.NotNull(LocalMWQMLookupMPNDBService);

            return await Task.FromResult(true);
        }
        private LocalMWQMLookupMPN GetFilledRandomLocalMWQMLookupMPN(string OmitPropName)
        {
            LocalMWQMLookupMPN localMWQMLookupMPN = new LocalMWQMLookupMPN();

            if (OmitPropName != "LocalDBCommand") localMWQMLookupMPN.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "Tubes10") localMWQMLookupMPN.Tubes10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tubes1") localMWQMLookupMPN.Tubes1 = GetRandomInt(0, 5);
            if (OmitPropName != "Tubes01") localMWQMLookupMPN.Tubes01 = GetRandomInt(0, 5);
            if (OmitPropName != "MPN_100ml") localMWQMLookupMPN.MPN_100ml = GetRandomInt(1, 10000);
            if (OmitPropName != "LastUpdateDate_UTC") localMWQMLookupMPN.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localMWQMLookupMPN.LastUpdateContactTVItemID = 2;



            return localMWQMLookupMPN;
        }
        private void CheckLocalMWQMLookupMPNFields(List<LocalMWQMLookupMPN> localMWQMLookupMPNList)
        {
        }

        #endregion Functions private
    }
}
