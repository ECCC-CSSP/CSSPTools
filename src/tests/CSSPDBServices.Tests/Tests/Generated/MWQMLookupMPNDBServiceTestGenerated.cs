/* Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBServices_Tests.exe
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
using CSSPDBPreferenceModels;

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class MWQMLookupMPNDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMWQMLookupMPNDBService MWQMLookupMPNDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBContext dbIM { get; set; }
        private MWQMLookupMPN mwqmLookupMPN { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMLookupMPNDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMLookupMPNDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMLookupMPN_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionMWQMLookupMPNList = await MWQMLookupMPNDBService.GetMWQMLookupMPNList();
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNList.Result).Value);
            List<MWQMLookupMPN> mwqmLookupMPNList = (List<MWQMLookupMPN>)((OkObjectResult)actionMWQMLookupMPNList.Result).Value;

            count = mwqmLookupMPNList.Count();

            MWQMLookupMPN mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmLookupMPN.MWQMLookupMPNID   (Int32)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.MWQMLookupMPNID = 0;

            var actionMWQMLookupMPN = await MWQMLookupMPNDBService.Put(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.MWQMLookupMPNID = 10000000;
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Put(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmLookupMPN.DBCommand   (DBCommandEnum)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.DBCommand = (DBCommandEnum)1000000;
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 5)]
            // mwqmLookupMPN.Tubes10   (Int32)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.Tubes10 = -1;
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());
            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.Tubes10 = 6;
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNDBService.GetMWQMLookupMPNList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 5)]
            // mwqmLookupMPN.Tubes1   (Int32)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.Tubes1 = -1;
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());
            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.Tubes1 = 6;
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNDBService.GetMWQMLookupMPNList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 5)]
            // mwqmLookupMPN.Tubes01   (Int32)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.Tubes01 = -1;
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());
            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.Tubes01 = 6;
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNDBService.GetMWQMLookupMPNList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, 10000)]
            // mwqmLookupMPN.MPN_100ml   (Int32)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.MPN_100ml = 0;
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());
            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.MPN_100ml = 10001;
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNDBService.GetMWQMLookupMPNList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmLookupMPN.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.LastUpdateDate_UTC = new DateTime();
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mwqmLookupMPN.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.LastUpdateContactTVItemID = 0;
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.LastUpdateContactTVItemID = 1;
            actionMWQMLookupMPN = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post MWQMLookupMPN
            var actionMWQMLookupMPNAdded = await MWQMLookupMPNDBService.Post(mwqmLookupMPN);
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNAdded.Result).Value);
            MWQMLookupMPN mwqmLookupMPNAdded = (MWQMLookupMPN)((OkObjectResult)actionMWQMLookupMPNAdded.Result).Value;
            Assert.NotNull(mwqmLookupMPNAdded);

            // List<MWQMLookupMPN>
            var actionMWQMLookupMPNList = await MWQMLookupMPNDBService.GetMWQMLookupMPNList();
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNList.Result).Value);
            List<MWQMLookupMPN> mwqmLookupMPNList = (List<MWQMLookupMPN>)((OkObjectResult)actionMWQMLookupMPNList.Result).Value;

            int count = ((List<MWQMLookupMPN>)((OkObjectResult)actionMWQMLookupMPNList.Result).Value).Count();
            Assert.True(count > 0);

            // List<MWQMLookupMPN> with skip and take
            var actionMWQMLookupMPNListSkipAndTake = await MWQMLookupMPNDBService.GetMWQMLookupMPNList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNListSkipAndTake.Result).Value);
            List<MWQMLookupMPN> mwqmLookupMPNListSkipAndTake = (List<MWQMLookupMPN>)((OkObjectResult)actionMWQMLookupMPNListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<MWQMLookupMPN>)((OkObjectResult)actionMWQMLookupMPNListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(mwqmLookupMPNList[0].MWQMLookupMPNID == mwqmLookupMPNListSkipAndTake[0].MWQMLookupMPNID);

            // Get MWQMLookupMPN With MWQMLookupMPNID
            var actionMWQMLookupMPNGet = await MWQMLookupMPNDBService.GetMWQMLookupMPNWithMWQMLookupMPNID(mwqmLookupMPNList[0].MWQMLookupMPNID);
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNGet.Result).Value);
            MWQMLookupMPN mwqmLookupMPNGet = (MWQMLookupMPN)((OkObjectResult)actionMWQMLookupMPNGet.Result).Value;
            Assert.NotNull(mwqmLookupMPNGet);
            Assert.Equal(mwqmLookupMPNGet.MWQMLookupMPNID, mwqmLookupMPNList[0].MWQMLookupMPNID);

            // Put MWQMLookupMPN
            var actionMWQMLookupMPNUpdated = await MWQMLookupMPNDBService.Put(mwqmLookupMPN);
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNUpdated.Result).Value);
            MWQMLookupMPN mwqmLookupMPNUpdated = (MWQMLookupMPN)((OkObjectResult)actionMWQMLookupMPNUpdated.Result).Value;
            Assert.NotNull(mwqmLookupMPNUpdated);

            // Delete MWQMLookupMPN
            var actionMWQMLookupMPNDeleted = await MWQMLookupMPNDBService.Delete(mwqmLookupMPN.MWQMLookupMPNID);
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMLookupMPNDeleted.Result).Value;
            Assert.True(retBool);

            db.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("a79b4a81-ba75-4dfc-8d95-46259f73f055")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            string CSSPDBConnString = Configuration.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IMWQMLookupMPNDBService, MWQMLookupMPNDBService>();

            /* ---------------------------------------------------------------------------------
             * using TestDB
             * ---------------------------------------------------------------------------------      
             */
            string TestDB = Configuration.GetValue<string>("TestDB");
            Assert.NotNull(TestDB);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDB);
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBPreference
             * ---------------------------------------------------------------------------------
             */
            string CSSPDBPreference = Configuration.GetValue<string>("CSSPDBPreference"); 
            Assert.NotNull(CSSPDBPreference);

            FileInfo fiCSSPDBPreference = new FileInfo(CSSPDBPreference);

            Services.AddDbContext<CSSPDBPreferenceContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBPreference.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(LoginEmail));

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            dbIM = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(dbIM);

            MWQMLookupMPNDBService = Provider.GetService<IMWQMLookupMPNDBService>();
            Assert.NotNull(MWQMLookupMPNDBService);

            return await Task.FromResult(true);
        }
        private MWQMLookupMPN GetFilledRandomMWQMLookupMPN(string OmitPropName)
        {
            MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();

            if (OmitPropName != "DBCommand") mwqmLookupMPN.DBCommand = (DBCommandEnum)GetRandomEnumType(typeof(DBCommandEnum));
            if (OmitPropName != "Tubes10") mwqmLookupMPN.Tubes10 = GetRandomInt(2, 5);
            if (OmitPropName != "Tubes1") mwqmLookupMPN.Tubes1 = GetRandomInt(2, 5);
            if (OmitPropName != "Tubes01") mwqmLookupMPN.Tubes01 = GetRandomInt(2, 5);
            if (OmitPropName != "MPN_100ml") mwqmLookupMPN.MPN_100ml = 14;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmLookupMPN.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmLookupMPN.LastUpdateContactTVItemID = 2;

            return mwqmLookupMPN;
        }
        private void CheckMWQMLookupMPNFields(List<MWQMLookupMPN> mwqmLookupMPNList)
        {
        }

        #endregion Functions private
    }
}
