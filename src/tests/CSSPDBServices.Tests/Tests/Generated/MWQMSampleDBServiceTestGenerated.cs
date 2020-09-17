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
    public partial class MWQMSampleDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMWQMSampleDBService MWQMSampleDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private MWQMSample mwqmSample { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMSampleDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMSampleDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mwqmSample = GetFilledRandomMWQMSample("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMSample_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionMWQMSampleList = await MWQMSampleDBService.GetMWQMSampleList();
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleList.Result).Value);
            List<MWQMSample> mwqmSampleList = (List<MWQMSample>)((OkObjectResult)actionMWQMSampleList.Result).Value;

            count = mwqmSampleList.Count();

            MWQMSample mwqmSample = GetFilledRandomMWQMSample("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmSample.MWQMSampleID   (Int32)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.MWQMSampleID = 0;

            var actionMWQMSample = await MWQMSampleDBService.Put(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.MWQMSampleID = 10000000;
            actionMWQMSample = await MWQMSampleDBService.Put(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
            // mwqmSample.MWQMSiteTVItemID   (Int32)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.MWQMSiteTVItemID = 0;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.MWQMSiteTVItemID = 1;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMRun)]
            // mwqmSample.MWQMRunTVItemID   (Int32)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.MWQMRunTVItemID = 0;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.MWQMRunTVItemID = 1;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSample.SampleDateTime_Local   (DateTime)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.SampleDateTime_Local = new DateTime();
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.SampleDateTime_Local = new DateTime(1979, 1, 1);
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(6)]
            // mwqmSample.TimeText   (String)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.TimeText = GetRandomString("", 7);
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleDBService.GetMWQMSampleList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // mwqmSample.Depth_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Depth_m]

            //CSSPError: Type not implemented [Depth_m]

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.Depth_m = -1.0D;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.Depth_m = 1001.0D;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleDBService.GetMWQMSampleList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // mwqmSample.FecCol_MPN_100ml   (Int32)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.FecCol_MPN_100ml = -1;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.FecCol_MPN_100ml = 10000001;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleDBService.GetMWQMSampleList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 40)]
            // mwqmSample.Salinity_PPT   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Salinity_PPT]

            //CSSPError: Type not implemented [Salinity_PPT]

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.Salinity_PPT = -1.0D;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.Salinity_PPT = 41.0D;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleDBService.GetMWQMSampleList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-10, 40)]
            // mwqmSample.WaterTemp_C   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [WaterTemp_C]

            //CSSPError: Type not implemented [WaterTemp_C]

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.WaterTemp_C = -11.0D;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.WaterTemp_C = 41.0D;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleDBService.GetMWQMSampleList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 14)]
            // mwqmSample.PH   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [PH]

            //CSSPError: Type not implemented [PH]

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.PH = -1.0D;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.PH = 15.0D;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleDBService.GetMWQMSampleList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(50)]
            // mwqmSample.SampleTypesText   (String)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("SampleTypesText");
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.SampleTypesText = GetRandomString("", 51);
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleDBService.GetMWQMSampleList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // mwqmSample.SampleType_old   (SampleTypeEnum)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.SampleType_old = (SampleTypeEnum)1000000;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 5)]
            // mwqmSample.Tube_10   (Int32)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.Tube_10 = -1;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.Tube_10 = 6;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleDBService.GetMWQMSampleList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 5)]
            // mwqmSample.Tube_1_0   (Int32)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.Tube_1_0 = -1;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.Tube_1_0 = 6;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleDBService.GetMWQMSampleList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 5)]
            // mwqmSample.Tube_0_1   (Int32)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.Tube_0_1 = -1;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.Tube_0_1 = 6;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleDBService.GetMWQMSampleList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(10)]
            // mwqmSample.ProcessedBy   (String)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.ProcessedBy = GetRandomString("", 11);
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            //Assert.AreEqual(count, mwqmSampleDBService.GetMWQMSampleList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // mwqmSample.UseForOpenData   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSample.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.LastUpdateDate_UTC = new DateTime();
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);
            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mwqmSample.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.LastUpdateContactTVItemID = 0;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.LastUpdateContactTVItemID = 1;
            actionMWQMSample = await MWQMSampleDBService.Post(mwqmSample);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSample.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post MWQMSample
            var actionMWQMSampleAdded = await MWQMSampleDBService.Post(mwqmSample);
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleAdded.Result).Value);
            MWQMSample mwqmSampleAdded = (MWQMSample)((OkObjectResult)actionMWQMSampleAdded.Result).Value;
            Assert.NotNull(mwqmSampleAdded);

            // List<MWQMSample>
            var actionMWQMSampleList = await MWQMSampleDBService.GetMWQMSampleList();
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleList.Result).Value);
            List<MWQMSample> mwqmSampleList = (List<MWQMSample>)((OkObjectResult)actionMWQMSampleList.Result).Value;

            int count = ((List<MWQMSample>)((OkObjectResult)actionMWQMSampleList.Result).Value).Count();
            Assert.True(count > 0);

            // List<MWQMSample> with skip and take
            var actionMWQMSampleListSkipAndTake = await MWQMSampleDBService.GetMWQMSampleList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleListSkipAndTake.Result).Value);
            List<MWQMSample> mwqmSampleListSkipAndTake = (List<MWQMSample>)((OkObjectResult)actionMWQMSampleListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<MWQMSample>)((OkObjectResult)actionMWQMSampleListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(mwqmSampleList[0].MWQMSampleID == mwqmSampleListSkipAndTake[0].MWQMSampleID);

            // Get MWQMSample With MWQMSampleID
            var actionMWQMSampleGet = await MWQMSampleDBService.GetMWQMSampleWithMWQMSampleID(mwqmSampleList[0].MWQMSampleID);
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleGet.Result).Value);
            MWQMSample mwqmSampleGet = (MWQMSample)((OkObjectResult)actionMWQMSampleGet.Result).Value;
            Assert.NotNull(mwqmSampleGet);
            Assert.Equal(mwqmSampleGet.MWQMSampleID, mwqmSampleList[0].MWQMSampleID);

            // Put MWQMSample
            var actionMWQMSampleUpdated = await MWQMSampleDBService.Put(mwqmSample);
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleUpdated.Result).Value);
            MWQMSample mwqmSampleUpdated = (MWQMSample)((OkObjectResult)actionMWQMSampleUpdated.Result).Value;
            Assert.NotNull(mwqmSampleUpdated);

            // Delete MWQMSample
            var actionMWQMSampleDeleted = await MWQMSampleDBService.Delete(mwqmSample.MWQMSampleID);
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMSampleDeleted.Result).Value;
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
            Services.AddSingleton<IMWQMSampleDBService, MWQMSampleDBService>();

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

            MWQMSampleDBService = Provider.GetService<IMWQMSampleDBService>();
            Assert.NotNull(MWQMSampleDBService);

            return await Task.FromResult(true);
        }
        private MWQMSample GetFilledRandomMWQMSample(string OmitPropName)
        {
            MWQMSample mwqmSample = new MWQMSample();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSample.MWQMSiteTVItemID = 44;
            if (OmitPropName != "MWQMRunTVItemID") mwqmSample.MWQMRunTVItemID = 50;
            if (OmitPropName != "SampleDateTime_Local") mwqmSample.SampleDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "TimeText") mwqmSample.TimeText = GetRandomString("", 5);
            if (OmitPropName != "Depth_m") mwqmSample.Depth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "FecCol_MPN_100ml") mwqmSample.FecCol_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Salinity_PPT") mwqmSample.Salinity_PPT = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "WaterTemp_C") mwqmSample.WaterTemp_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "PH") mwqmSample.PH = GetRandomDouble(0.0D, 14.0D);
            if (OmitPropName != "SampleTypesText") mwqmSample.SampleTypesText = GetRandomString("", 5);
            if (OmitPropName != "SampleType_old") mwqmSample.SampleType_old = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "Tube_10") mwqmSample.Tube_10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube_1_0") mwqmSample.Tube_1_0 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube_0_1") mwqmSample.Tube_0_1 = GetRandomInt(0, 5);
            if (OmitPropName != "ProcessedBy") mwqmSample.ProcessedBy = GetRandomString("", 5);
            if (OmitPropName != "UseForOpenData") mwqmSample.UseForOpenData = true;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSample.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSample.LastUpdateContactTVItemID = 2;



            return mwqmSample;
        }
        private void CheckMWQMSampleFields(List<MWQMSample> mwqmSampleList)
        {
            if (!string.IsNullOrWhiteSpace(mwqmSampleList[0].TimeText))
            {
                Assert.False(string.IsNullOrWhiteSpace(mwqmSampleList[0].TimeText));
            }
            if (mwqmSampleList[0].Depth_m != null)
            {
                Assert.NotNull(mwqmSampleList[0].Depth_m);
            }
            if (mwqmSampleList[0].Salinity_PPT != null)
            {
                Assert.NotNull(mwqmSampleList[0].Salinity_PPT);
            }
            if (mwqmSampleList[0].WaterTemp_C != null)
            {
                Assert.NotNull(mwqmSampleList[0].WaterTemp_C);
            }
            if (mwqmSampleList[0].PH != null)
            {
                Assert.NotNull(mwqmSampleList[0].PH);
            }
            Assert.False(string.IsNullOrWhiteSpace(mwqmSampleList[0].SampleTypesText));
            if (mwqmSampleList[0].SampleType_old != null)
            {
                Assert.NotNull(mwqmSampleList[0].SampleType_old);
            }
            if (mwqmSampleList[0].Tube_10 != null)
            {
                Assert.NotNull(mwqmSampleList[0].Tube_10);
            }
            if (mwqmSampleList[0].Tube_1_0 != null)
            {
                Assert.NotNull(mwqmSampleList[0].Tube_1_0);
            }
            if (mwqmSampleList[0].Tube_0_1 != null)
            {
                Assert.NotNull(mwqmSampleList[0].Tube_0_1);
            }
            if (!string.IsNullOrWhiteSpace(mwqmSampleList[0].ProcessedBy))
            {
                Assert.False(string.IsNullOrWhiteSpace(mwqmSampleList[0].ProcessedBy));
            }
        }

        #endregion Functions private
    }
}