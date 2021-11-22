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
    public partial class HydrometricSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IHydrometricSiteService HydrometricSiteService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private HydrometricSite hydrometricSite { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricSiteServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task HydrometricSite_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            hydrometricSite = GetFilledRandomHydrometricSite("");

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
        public async Task HydrometricSite_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionHydrometricSiteList = await HydrometricSiteService.GetHydrometricSiteList();
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteList.Result).Value);
            List<HydrometricSite> hydrometricSiteList = (List<HydrometricSite>)((OkObjectResult)actionHydrometricSiteList.Result).Value;

            count = hydrometricSiteList.Count();

            HydrometricSite hydrometricSite = GetFilledRandomHydrometricSite("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // hydrometricSite.HydrometricSiteID   (Int32)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.HydrometricSiteID = 0;

            var actionHydrometricSite = await HydrometricSiteService.Put(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.HydrometricSiteID = 10000000;
            actionHydrometricSite = await HydrometricSiteService.Put(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = HydrometricSite)]
            // hydrometricSite.HydrometricSiteTVItemID   (Int32)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.HydrometricSiteTVItemID = 0;
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.HydrometricSiteTVItemID = 1;
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(7)]
            // hydrometricSite.FedSiteNumber   (String)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.FedSiteNumber = GetRandomString("", 8);
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(7)]
            // hydrometricSite.QuebecSiteNumber   (String)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.QuebecSiteNumber = GetRandomString("", 8);
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(200)]
            // hydrometricSite.HydrometricSiteName   (String)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("HydrometricSiteName");
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.HydrometricSiteName = GetRandomString("", 201);
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(200)]
            // hydrometricSite.Description   (String)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.Description = GetRandomString("", 201);
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(4)]
            // hydrometricSite.Province   (String)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("Province");
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.Province = GetRandomString("", 5);
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10000)]
            // hydrometricSite.Elevation_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Elevation_m]

            //CSSPError: Type not implemented [Elevation_m]

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.Elevation_m = -1.0D;
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());
            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.Elevation_m = 10001.0D;
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1849)]
            // hydrometricSite.StartDate_Local   (DateTime)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.StartDate_Local = new DateTime(1848, 1, 1);
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1849)]
            // [CSSPBigger(OtherField = StartDate_Local)]
            // hydrometricSite.EndDate_Local   (DateTime)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.EndDate_Local = new DateTime(1848, 1, 1);
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-10, 0)]
            // hydrometricSite.TimeOffset_hour   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [TimeOffset_hour]

            //CSSPError: Type not implemented [TimeOffset_hour]

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.TimeOffset_hour = -11.0D;
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());
            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.TimeOffset_hour = 1.0D;
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000000)]
            // hydrometricSite.DrainageArea_km2   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [DrainageArea_km2]

            //CSSPError: Type not implemented [DrainageArea_km2]

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.DrainageArea_km2 = -1.0D;
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());
            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.DrainageArea_km2 = 1000001.0D;
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // hydrometricSite.IsNatural   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // hydrometricSite.IsActive   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // hydrometricSite.Sediment   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // hydrometricSite.RHBN   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // hydrometricSite.RealTime   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // hydrometricSite.HasDischarge   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // hydrometricSite.HasLevel   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // hydrometricSite.HasRatingCurve   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // hydrometricSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.LastUpdateDate_UTC = new DateTime();
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // hydrometricSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.LastUpdateContactTVItemID = 0;
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.LastUpdateContactTVItemID = 1;
            actionHydrometricSite = await HydrometricSiteService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post HydrometricSite
            var actionHydrometricSiteAdded = await HydrometricSiteService.Post(hydrometricSite);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteAdded.Result).Value);
            HydrometricSite hydrometricSiteAdded = (HydrometricSite)((OkObjectResult)actionHydrometricSiteAdded.Result).Value;
            Assert.NotNull(hydrometricSiteAdded);

            // List<HydrometricSite>
            var actionHydrometricSiteList = await HydrometricSiteService.GetHydrometricSiteList();
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteList.Result).Value);
            List<HydrometricSite> hydrometricSiteList = (List<HydrometricSite>)((OkObjectResult)actionHydrometricSiteList.Result).Value;

            int count = ((List<HydrometricSite>)((OkObjectResult)actionHydrometricSiteList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<HydrometricSite> with skip and take
                var actionHydrometricSiteListSkipAndTake = await HydrometricSiteService.GetHydrometricSiteList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionHydrometricSiteListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionHydrometricSiteListSkipAndTake.Result).Value);
                List<HydrometricSite> hydrometricSiteListSkipAndTake = (List<HydrometricSite>)((OkObjectResult)actionHydrometricSiteListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<HydrometricSite>)((OkObjectResult)actionHydrometricSiteListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(hydrometricSiteList[0].HydrometricSiteID == hydrometricSiteListSkipAndTake[0].HydrometricSiteID);
            }

            // Get HydrometricSite With HydrometricSiteID
            var actionHydrometricSiteGet = await HydrometricSiteService.GetHydrometricSiteWithHydrometricSiteID(hydrometricSiteList[0].HydrometricSiteID);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteGet.Result).Value);
            HydrometricSite hydrometricSiteGet = (HydrometricSite)((OkObjectResult)actionHydrometricSiteGet.Result).Value;
            Assert.NotNull(hydrometricSiteGet);
            Assert.Equal(hydrometricSiteGet.HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);

            // Put HydrometricSite
            var actionHydrometricSiteUpdated = await HydrometricSiteService.Put(hydrometricSite);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteUpdated.Result).Value);
            HydrometricSite hydrometricSiteUpdated = (HydrometricSite)((OkObjectResult)actionHydrometricSiteUpdated.Result).Value;
            Assert.NotNull(hydrometricSiteUpdated);

            // Delete HydrometricSite
            var actionHydrometricSiteDeleted = await HydrometricSiteService.Delete(hydrometricSite.HydrometricSiteID);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionHydrometricSiteDeleted.Result).Value;
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
            Services.AddSingleton<IHydrometricSiteService, HydrometricSiteService>();

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

            HydrometricSiteService = Provider.GetService<IHydrometricSiteService>();
            Assert.NotNull(HydrometricSiteService);

            return await Task.FromResult(true);
        }
        private HydrometricSite GetFilledRandomHydrometricSite(string OmitPropName)
        {
            List<HydrometricSite> hydrometricSiteListToDelete = (from c in dbLocal.HydrometricSites
                                                               select c).ToList(); 
            
            dbLocal.HydrometricSites.RemoveRange(hydrometricSiteListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            HydrometricSite hydrometricSite = new HydrometricSite();

            if (OmitPropName != "HydrometricSiteTVItemID") hydrometricSite.HydrometricSiteTVItemID = 8;
            if (OmitPropName != "FedSiteNumber") hydrometricSite.FedSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "QuebecSiteNumber") hydrometricSite.QuebecSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "HydrometricSiteName") hydrometricSite.HydrometricSiteName = GetRandomString("", 5);
            if (OmitPropName != "Description") hydrometricSite.Description = GetRandomString("", 5);
            if (OmitPropName != "Province") hydrometricSite.Province = GetRandomString("", 4);
            if (OmitPropName != "Elevation_m") hydrometricSite.Elevation_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "StartDate_Local") hydrometricSite.StartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDate_Local") hydrometricSite.EndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "TimeOffset_hour") hydrometricSite.TimeOffset_hour = GetRandomDouble(-10.0D, 0.0D);
            if (OmitPropName != "DrainageArea_km2") hydrometricSite.DrainageArea_km2 = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "IsNatural") hydrometricSite.IsNatural = true;
            if (OmitPropName != "IsActive") hydrometricSite.IsActive = true;
            if (OmitPropName != "Sediment") hydrometricSite.Sediment = true;
            if (OmitPropName != "RHBN") hydrometricSite.RHBN = true;
            if (OmitPropName != "RealTime") hydrometricSite.RealTime = true;
            if (OmitPropName != "HasDischarge") hydrometricSite.HasDischarge = true;
            if (OmitPropName != "HasLevel") hydrometricSite.HasLevel = true;
            if (OmitPropName != "HasRatingCurve") hydrometricSite.HasRatingCurve = true;
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricSite.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "HydrometricSiteID") hydrometricSite.HydrometricSiteID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 8, TVLevel = 3, TVPath = "p1p5p6p8", TVType = (TVTypeEnum)9, ParentID = 6, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 3, 20, 45, 2), LastUpdateContactTVItemID = 2});
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

            return hydrometricSite;
        }
        private void CheckHydrometricSiteFields(List<HydrometricSite> hydrometricSiteList)
        {
            if (!string.IsNullOrWhiteSpace(hydrometricSiteList[0].FedSiteNumber))
            {
                Assert.False(string.IsNullOrWhiteSpace(hydrometricSiteList[0].FedSiteNumber));
            }
            if (!string.IsNullOrWhiteSpace(hydrometricSiteList[0].QuebecSiteNumber))
            {
                Assert.False(string.IsNullOrWhiteSpace(hydrometricSiteList[0].QuebecSiteNumber));
            }
            Assert.False(string.IsNullOrWhiteSpace(hydrometricSiteList[0].HydrometricSiteName));
            if (!string.IsNullOrWhiteSpace(hydrometricSiteList[0].Description))
            {
                Assert.False(string.IsNullOrWhiteSpace(hydrometricSiteList[0].Description));
            }
            Assert.False(string.IsNullOrWhiteSpace(hydrometricSiteList[0].Province));
            if (hydrometricSiteList[0].Elevation_m != null)
            {
                Assert.NotNull(hydrometricSiteList[0].Elevation_m);
            }
            if (hydrometricSiteList[0].StartDate_Local != null)
            {
                Assert.NotNull(hydrometricSiteList[0].StartDate_Local);
            }
            if (hydrometricSiteList[0].EndDate_Local != null)
            {
                Assert.NotNull(hydrometricSiteList[0].EndDate_Local);
            }
            if (hydrometricSiteList[0].TimeOffset_hour != null)
            {
                Assert.NotNull(hydrometricSiteList[0].TimeOffset_hour);
            }
            if (hydrometricSiteList[0].DrainageArea_km2 != null)
            {
                Assert.NotNull(hydrometricSiteList[0].DrainageArea_km2);
            }
            if (hydrometricSiteList[0].IsNatural != null)
            {
                Assert.NotNull(hydrometricSiteList[0].IsNatural);
            }
            if (hydrometricSiteList[0].IsActive != null)
            {
                Assert.NotNull(hydrometricSiteList[0].IsActive);
            }
            if (hydrometricSiteList[0].Sediment != null)
            {
                Assert.NotNull(hydrometricSiteList[0].Sediment);
            }
            if (hydrometricSiteList[0].RHBN != null)
            {
                Assert.NotNull(hydrometricSiteList[0].RHBN);
            }
            if (hydrometricSiteList[0].RealTime != null)
            {
                Assert.NotNull(hydrometricSiteList[0].RealTime);
            }
            if (hydrometricSiteList[0].HasDischarge != null)
            {
                Assert.NotNull(hydrometricSiteList[0].HasDischarge);
            }
            if (hydrometricSiteList[0].HasLevel != null)
            {
                Assert.NotNull(hydrometricSiteList[0].HasLevel);
            }
            if (hydrometricSiteList[0].HasRatingCurve != null)
            {
                Assert.NotNull(hydrometricSiteList[0].HasRatingCurve);
            }
        }
        #endregion Functions private
    }
}