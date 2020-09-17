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
using LocalServices;
using System.Threading;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class HydrometricSiteDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IHydrometricSiteDBLocalService HydrometricSiteDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private HydrometricSite hydrometricSite { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricSiteDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocal]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task HydrometricSiteDBLocal_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocal]

        #region Tests Generated [DBLocal] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task HydrometricSiteDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            hydrometricSite = GetFilledRandomHydrometricSite("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated [DBLocal] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task HydrometricSite_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionHydrometricSiteList = await HydrometricSiteDBLocalService.GetHydrometricSiteList();
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

            var actionHydrometricSite = await HydrometricSiteDBLocalService.Put(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.HydrometricSiteID = 10000000;
            actionHydrometricSite = await HydrometricSiteDBLocalService.Put(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = HydrometricSite)]
            // hydrometricSite.HydrometricSiteTVItemID   (Int32)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.HydrometricSiteTVItemID = 0;
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.HydrometricSiteTVItemID = 1;
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(7)]
            // hydrometricSite.FedSiteNumber   (String)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.FedSiteNumber = GetRandomString("", 8);
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteDBLocalService.GetHydrometricSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(7)]
            // hydrometricSite.QuebecSiteNumber   (String)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.QuebecSiteNumber = GetRandomString("", 8);
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteDBLocalService.GetHydrometricSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(200)]
            // hydrometricSite.HydrometricSiteName   (String)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("HydrometricSiteName");
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.HydrometricSiteName = GetRandomString("", 201);
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteDBLocalService.GetHydrometricSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(200)]
            // hydrometricSite.Description   (String)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.Description = GetRandomString("", 201);
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteDBLocalService.GetHydrometricSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(4)]
            // hydrometricSite.Province   (String)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("Province");
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.Province = GetRandomString("", 5);
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteDBLocalService.GetHydrometricSiteList().Count());

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
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());
            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.Elevation_m = 10001.0D;
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteDBLocalService.GetHydrometricSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1849)]
            // hydrometricSite.StartDate_Local   (DateTime)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.StartDate_Local = new DateTime(1848, 1, 1);
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
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
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
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
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());
            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.TimeOffset_hour = 1.0D;
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteDBLocalService.GetHydrometricSiteList().Count());

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
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());
            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.DrainageArea_km2 = 1000001.0D;
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            //Assert.AreEqual(count, hydrometricSiteDBLocalService.GetHydrometricSiteList().Count());

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
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);
            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // hydrometricSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.LastUpdateContactTVItemID = 0;
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.LastUpdateContactTVItemID = 1;
            actionHydrometricSite = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricSite.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post HydrometricSite
            var actionHydrometricSiteAdded = await HydrometricSiteDBLocalService.Post(hydrometricSite);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteAdded.Result).Value);
            HydrometricSite hydrometricSiteAdded = (HydrometricSite)((OkObjectResult)actionHydrometricSiteAdded.Result).Value;
            Assert.NotNull(hydrometricSiteAdded);

            // List<HydrometricSite>
            var actionHydrometricSiteList = await HydrometricSiteDBLocalService.GetHydrometricSiteList();
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteList.Result).Value);
            List<HydrometricSite> hydrometricSiteList = (List<HydrometricSite>)((OkObjectResult)actionHydrometricSiteList.Result).Value;

            int count = ((List<HydrometricSite>)((OkObjectResult)actionHydrometricSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // Get HydrometricSite With HydrometricSiteID
            var actionHydrometricSiteGet = await HydrometricSiteDBLocalService.GetHydrometricSiteWithHydrometricSiteID(hydrometricSiteList[0].HydrometricSiteID);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteGet.Result).Value);
            HydrometricSite hydrometricSiteGet = (HydrometricSite)((OkObjectResult)actionHydrometricSiteGet.Result).Value;
            Assert.NotNull(hydrometricSiteGet);
            Assert.Equal(hydrometricSiteGet.HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);

            // Put HydrometricSite
            var actionHydrometricSiteUpdated = await HydrometricSiteDBLocalService.Put(hydrometricSite);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteUpdated.Result).Value);
            HydrometricSite hydrometricSiteUpdated = (HydrometricSite)((OkObjectResult)actionHydrometricSiteUpdated.Result).Value;
            Assert.NotNull(hydrometricSiteUpdated);

            // Delete HydrometricSite
            var actionHydrometricSiteDeleted = await HydrometricSiteDBLocalService.Delete(hydrometricSite.HydrometricSiteID);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionHydrometricSiteDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLoginFileName = Config.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IHydrometricSiteDBLocalService, HydrometricSiteDBLocalService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbLocalIM);

            HydrometricSiteDBLocalService = Provider.GetService<IHydrometricSiteDBLocalService>();
            Assert.NotNull(HydrometricSiteDBLocalService);

            return await Task.FromResult(true);
        }
        private HydrometricSite GetFilledRandomHydrometricSite(string OmitPropName)
        {
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

            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 8, TVLevel = 3, TVPath = "p1p5p6p8", TVType = (TVTypeEnum)9, ParentID = 6, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 3, 20, 45, 2), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }
            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
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