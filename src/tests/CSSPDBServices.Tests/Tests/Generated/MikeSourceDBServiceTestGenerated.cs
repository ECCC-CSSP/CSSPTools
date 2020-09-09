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
    public partial class MikeSourceDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMikeSourceDBService MikeSourceDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private MikeSource mikeSource { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MikeSourceDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MikeSourceDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mikeSource = GetFilledRandomMikeSource("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MikeSource_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionMikeSourceList = await MikeSourceDBService.GetMikeSourceList();
            Assert.Equal(200, ((ObjectResult)actionMikeSourceList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceList.Result).Value);
            List<MikeSource> mikeSourceList = (List<MikeSource>)((OkObjectResult)actionMikeSourceList.Result).Value;

            count = mikeSourceList.Count();

            MikeSource mikeSource = GetFilledRandomMikeSource("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mikeSource.MikeSourceID   (Int32)
            // -----------------------------------

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.MikeSourceID = 0;

            var actionMikeSource = await MikeSourceDBService.Put(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.MikeSourceID = 10000000;
            actionMikeSource = await MikeSourceDBService.Put(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeSource)]
            // mikeSource.MikeSourceTVItemID   (Int32)
            // -----------------------------------

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.MikeSourceTVItemID = 0;
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.MikeSourceTVItemID = 1;
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);


            // -----------------------------------
            // Is NOT Nullable
            // mikeSource.IsContinuous   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // mikeSource.Include   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // mikeSource.IsRiver   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // mikeSource.UseHydrometric   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = HydrometricSite)]
            // mikeSource.HydrometricTVItemID   (Int32)
            // -----------------------------------

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.HydrometricTVItemID = 0;
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.HydrometricTVItemID = 1;
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000000)]
            // mikeSource.DrainageArea_km2   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [DrainageArea_km2]

            //CSSPError: Type not implemented [DrainageArea_km2]

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.DrainageArea_km2 = -1.0D;
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);
            //Assert.AreEqual(count, mikeSourceService.GetMikeSourceList().Count());
            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.DrainageArea_km2 = 1000001.0D;
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);
            //Assert.AreEqual(count, mikeSourceDBService.GetMikeSourceList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000000)]
            // mikeSource.Factor   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Factor]

            //CSSPError: Type not implemented [Factor]

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.Factor = -1.0D;
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);
            //Assert.AreEqual(count, mikeSourceService.GetMikeSourceList().Count());
            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.Factor = 1000001.0D;
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);
            //Assert.AreEqual(count, mikeSourceDBService.GetMikeSourceList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(50)]
            // mikeSource.SourceNumberString   (String)
            // -----------------------------------

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("SourceNumberString");
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.SourceNumberString = GetRandomString("", 51);
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);
            //Assert.AreEqual(count, mikeSourceDBService.GetMikeSourceList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeSource.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.LastUpdateDate_UTC = new DateTime();
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);
            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mikeSource.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.LastUpdateContactTVItemID = 0;
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.LastUpdateContactTVItemID = 1;
            actionMikeSource = await MikeSourceDBService.Post(mikeSource);
            Assert.IsType<BadRequestObjectResult>(actionMikeSource.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post MikeSource
            var actionMikeSourceAdded = await MikeSourceDBService.Post(mikeSource);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceAdded.Result).Value);
            MikeSource mikeSourceAdded = (MikeSource)((OkObjectResult)actionMikeSourceAdded.Result).Value;
            Assert.NotNull(mikeSourceAdded);

            // List<MikeSource>
            var actionMikeSourceList = await MikeSourceDBService.GetMikeSourceList();
            Assert.Equal(200, ((ObjectResult)actionMikeSourceList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceList.Result).Value);
            List<MikeSource> mikeSourceList = (List<MikeSource>)((OkObjectResult)actionMikeSourceList.Result).Value;

            int count = ((List<MikeSource>)((OkObjectResult)actionMikeSourceList.Result).Value).Count();
            Assert.True(count > 0);

            // List<MikeSource> with skip and take
            var actionMikeSourceListSkipAndTake = await MikeSourceDBService.GetMikeSourceList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceListSkipAndTake.Result).Value);
            List<MikeSource> mikeSourceListSkipAndTake = (List<MikeSource>)((OkObjectResult)actionMikeSourceListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<MikeSource>)((OkObjectResult)actionMikeSourceListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(mikeSourceList[0].MikeSourceID == mikeSourceListSkipAndTake[0].MikeSourceID);

            // Get MikeSource With MikeSourceID
            var actionMikeSourceGet = await MikeSourceDBService.GetMikeSourceWithMikeSourceID(mikeSourceList[0].MikeSourceID);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceGet.Result).Value);
            MikeSource mikeSourceGet = (MikeSource)((OkObjectResult)actionMikeSourceGet.Result).Value;
            Assert.NotNull(mikeSourceGet);
            Assert.Equal(mikeSourceGet.MikeSourceID, mikeSourceList[0].MikeSourceID);

            // Put MikeSource
            var actionMikeSourceUpdated = await MikeSourceDBService.Put(mikeSource);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceUpdated.Result).Value);
            MikeSource mikeSourceUpdated = (MikeSource)((OkObjectResult)actionMikeSourceUpdated.Result).Value;
            Assert.NotNull(mikeSourceUpdated);

            // Delete MikeSource
            var actionMikeSourceDeleted = await MikeSourceDBService.Delete(mikeSource.MikeSourceID);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMikeSourceDeleted.Result).Value;
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
            Services.AddSingleton<IMikeSourceDBService, MikeSourceDBService>();

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

            MikeSourceDBService = Provider.GetService<IMikeSourceDBService>();
            Assert.NotNull(MikeSourceDBService);

            return await Task.FromResult(true);
        }
        private MikeSource GetFilledRandomMikeSource(string OmitPropName)
        {
            MikeSource mikeSource = new MikeSource();

            if (OmitPropName != "MikeSourceTVItemID") mikeSource.MikeSourceTVItemID = 53;
            if (OmitPropName != "IsContinuous") mikeSource.IsContinuous = true;
            if (OmitPropName != "Include") mikeSource.Include = true;
            if (OmitPropName != "IsRiver") mikeSource.IsRiver = true;
            if (OmitPropName != "UseHydrometric") mikeSource.UseHydrometric = true;
            if (OmitPropName != "HydrometricTVItemID") mikeSource.HydrometricTVItemID = 8;
            if (OmitPropName != "DrainageArea_km2") mikeSource.DrainageArea_km2 = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "Factor") mikeSource.Factor = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourceNumberString") mikeSource.SourceNumberString = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") mikeSource.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSource.LastUpdateContactTVItemID = 2;



            return mikeSource;
        }
        private void CheckMikeSourceFields(List<MikeSource> mikeSourceList)
        {
            if (mikeSourceList[0].HydrometricTVItemID != null)
            {
                Assert.NotNull(mikeSourceList[0].HydrometricTVItemID);
            }
            if (mikeSourceList[0].DrainageArea_km2 != null)
            {
                Assert.NotNull(mikeSourceList[0].DrainageArea_km2);
            }
            if (mikeSourceList[0].Factor != null)
            {
                Assert.NotNull(mikeSourceList[0].Factor);
            }
            Assert.False(string.IsNullOrWhiteSpace(mikeSourceList[0].SourceNumberString));
        }

        #endregion Functions private
    }
}
