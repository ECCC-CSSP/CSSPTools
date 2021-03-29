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
using CSSPScrambleServices;
using CSSPHelperServices;

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class MWQMSubsectorDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMWQMSubsectorDBService MWQMSubsectorDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBContext dbIM { get; set; }
        private MWQMSubsector mwqmSubsector { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMSubsectorDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMSubsectorDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mwqmSubsector = GetFilledRandomMWQMSubsector("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMSubsector_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionMWQMSubsectorList = await MWQMSubsectorDBService.GetMWQMSubsectorList();
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorList.Result).Value);
            List<MWQMSubsector> mwqmSubsectorList = (List<MWQMSubsector>)((OkObjectResult)actionMWQMSubsectorList.Result).Value;

            count = mwqmSubsectorList.Count();

            MWQMSubsector mwqmSubsector = GetFilledRandomMWQMSubsector("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmSubsector.MWQMSubsectorID   (Int32)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.MWQMSubsectorID = 0;

            var actionMWQMSubsector = await MWQMSubsectorDBService.Put(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.MWQMSubsectorID = 10000000;
            actionMWQMSubsector = await MWQMSubsectorDBService.Put(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmSubsector.DBCommand   (DBCommandEnum)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.DBCommand = (DBCommandEnum)1000000;
            actionMWQMSubsector = await MWQMSubsectorDBService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
            // mwqmSubsector.MWQMSubsectorTVItemID   (Int32)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.MWQMSubsectorTVItemID = 0;
            actionMWQMSubsector = await MWQMSubsectorDBService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.MWQMSubsectorTVItemID = 1;
            actionMWQMSubsector = await MWQMSubsectorDBService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(20)]
            // mwqmSubsector.SubsectorHistoricKey   (String)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("SubsectorHistoricKey");
            actionMWQMSubsector = await MWQMSubsectorDBService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.SubsectorHistoricKey = GetRandomString("", 21);
            actionMWQMSubsector = await MWQMSubsectorDBService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);
            //Assert.AreEqual(count, mwqmSubsectorDBService.GetMWQMSubsectorList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(20)]
            // mwqmSubsector.TideLocationSIDText   (String)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.TideLocationSIDText = GetRandomString("", 21);
            actionMWQMSubsector = await MWQMSubsectorDBService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);
            //Assert.AreEqual(count, mwqmSubsectorDBService.GetMWQMSubsectorList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSubsector.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.LastUpdateDate_UTC = new DateTime();
            actionMWQMSubsector = await MWQMSubsectorDBService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);
            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMWQMSubsector = await MWQMSubsectorDBService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mwqmSubsector.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.LastUpdateContactTVItemID = 0;
            actionMWQMSubsector = await MWQMSubsectorDBService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.LastUpdateContactTVItemID = 1;
            actionMWQMSubsector = await MWQMSubsectorDBService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post MWQMSubsector
            var actionMWQMSubsectorAdded = await MWQMSubsectorDBService.Post(mwqmSubsector);
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorAdded.Result).Value);
            MWQMSubsector mwqmSubsectorAdded = (MWQMSubsector)((OkObjectResult)actionMWQMSubsectorAdded.Result).Value;
            Assert.NotNull(mwqmSubsectorAdded);

            // List<MWQMSubsector>
            var actionMWQMSubsectorList = await MWQMSubsectorDBService.GetMWQMSubsectorList();
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorList.Result).Value);
            List<MWQMSubsector> mwqmSubsectorList = (List<MWQMSubsector>)((OkObjectResult)actionMWQMSubsectorList.Result).Value;

            int count = ((List<MWQMSubsector>)((OkObjectResult)actionMWQMSubsectorList.Result).Value).Count();
            Assert.True(count > 0);

            // List<MWQMSubsector> with skip and take
            var actionMWQMSubsectorListSkipAndTake = await MWQMSubsectorDBService.GetMWQMSubsectorList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorListSkipAndTake.Result).Value);
            List<MWQMSubsector> mwqmSubsectorListSkipAndTake = (List<MWQMSubsector>)((OkObjectResult)actionMWQMSubsectorListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<MWQMSubsector>)((OkObjectResult)actionMWQMSubsectorListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(mwqmSubsectorList[0].MWQMSubsectorID == mwqmSubsectorListSkipAndTake[0].MWQMSubsectorID);

            // Get MWQMSubsector With MWQMSubsectorID
            var actionMWQMSubsectorGet = await MWQMSubsectorDBService.GetMWQMSubsectorWithMWQMSubsectorID(mwqmSubsectorList[0].MWQMSubsectorID);
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorGet.Result).Value);
            MWQMSubsector mwqmSubsectorGet = (MWQMSubsector)((OkObjectResult)actionMWQMSubsectorGet.Result).Value;
            Assert.NotNull(mwqmSubsectorGet);
            Assert.Equal(mwqmSubsectorGet.MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);

            // Put MWQMSubsector
            var actionMWQMSubsectorUpdated = await MWQMSubsectorDBService.Put(mwqmSubsector);
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorUpdated.Result).Value);
            MWQMSubsector mwqmSubsectorUpdated = (MWQMSubsector)((OkObjectResult)actionMWQMSubsectorUpdated.Result).Value;
            Assert.NotNull(mwqmSubsectorUpdated);

            // Delete MWQMSubsector
            var actionMWQMSubsectorDeleted = await MWQMSubsectorDBService.Delete(mwqmSubsector.MWQMSubsectorID);
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMSubsectorDeleted.Result).Value;
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
            Services.AddSingleton<IScrambleService, ScrambleService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IMWQMSubsectorDBService, MWQMSubsectorDBService>();

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

            MWQMSubsectorDBService = Provider.GetService<IMWQMSubsectorDBService>();
            Assert.NotNull(MWQMSubsectorDBService);

            return await Task.FromResult(true);
        }
        private MWQMSubsector GetFilledRandomMWQMSubsector(string OmitPropName)
        {
            MWQMSubsector mwqmSubsector = new MWQMSubsector();

            if (OmitPropName != "DBCommand") mwqmSubsector.DBCommand = (DBCommandEnum)GetRandomEnumType(typeof(DBCommandEnum));
            if (OmitPropName != "MWQMSubsectorTVItemID") mwqmSubsector.MWQMSubsectorTVItemID = 11;
            if (OmitPropName != "SubsectorHistoricKey") mwqmSubsector.SubsectorHistoricKey = GetRandomString("", 5);
            if (OmitPropName != "TideLocationSIDText") mwqmSubsector.TideLocationSIDText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSubsector.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSubsector.LastUpdateContactTVItemID = 2;

            return mwqmSubsector;
        }
        private void CheckMWQMSubsectorFields(List<MWQMSubsector> mwqmSubsectorList)
        {
            Assert.False(string.IsNullOrWhiteSpace(mwqmSubsectorList[0].SubsectorHistoricKey));
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorList[0].TideLocationSIDText))
            {
                Assert.False(string.IsNullOrWhiteSpace(mwqmSubsectorList[0].TideLocationSIDText));
            }
        }

        #endregion Functions private
    }
}
