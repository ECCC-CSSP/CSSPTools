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
    public partial class HydrometricDataValueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IHydrometricDataValueService HydrometricDataValueService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private HydrometricDataValue hydrometricDataValue { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricDataValueServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task HydrometricDataValue_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");

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
        public async Task HydrometricDataValue_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionHydrometricDataValueList = await HydrometricDataValueService.GetHydrometricDataValueList();
            Assert.Equal(200, ((ObjectResult)actionHydrometricDataValueList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricDataValueList.Result).Value);
            List<HydrometricDataValue> hydrometricDataValueList = (List<HydrometricDataValue>)((OkObjectResult)actionHydrometricDataValueList.Result).Value;

            count = hydrometricDataValueList.Count();

            HydrometricDataValue hydrometricDataValue = GetFilledRandomHydrometricDataValue("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // hydrometricDataValue.HydrometricDataValueID   (Int32)
            // -----------------------------------

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.HydrometricDataValueID = 0;

            var actionHydrometricDataValue = await HydrometricDataValueService.Put(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.HydrometricDataValueID = 10000000;
            actionHydrometricDataValue = await HydrometricDataValueService.Put(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID", AllowableTVtypeList = )]
            // hydrometricDataValue.HydrometricSiteID   (Int32)
            // -----------------------------------

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.HydrometricSiteID = 0;
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // hydrometricDataValue.DateTime_Local   (DateTime)
            // -----------------------------------

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.DateTime_Local = new DateTime();
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);
            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.DateTime_Local = new DateTime(1979, 1, 1);
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);

            // -----------------------------------
            // Is NOT Nullable
            // hydrometricDataValue.Keep   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // hydrometricDataValue.StorageDataType   (StorageDataTypeEnum)
            // -----------------------------------

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.StorageDataType = (StorageDataTypeEnum)1000000;
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);


            // -----------------------------------
            // Is NOT Nullable
            // hydrometricDataValue.HasBeenRead   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 100000)]
            // hydrometricDataValue.Discharge_m3_s   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Discharge_m3_s]

            //CSSPError: Type not implemented [Discharge_m3_s]

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.Discharge_m3_s = -1.0D;
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);
            //Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());
            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.Discharge_m3_s = 100001.0D;
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);
            //Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 100000)]
            // hydrometricDataValue.DischargeEntered_m3_s   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [DischargeEntered_m3_s]

            //CSSPError: Type not implemented [DischargeEntered_m3_s]

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.DischargeEntered_m3_s = -1.0D;
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);
            //Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());
            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.DischargeEntered_m3_s = 100001.0D;
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);
            //Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10000)]
            // hydrometricDataValue.Level_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Level_m]

            //CSSPError: Type not implemented [Level_m]

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.Level_m = -1.0D;
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);
            //Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());
            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.Level_m = 10001.0D;
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);
            //Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());

            // -----------------------------------
            // Is Nullable
            // hydrometricDataValue.HourlyValues   (String)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // hydrometricDataValue.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.LastUpdateDate_UTC = new DateTime();
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);
            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // hydrometricDataValue.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.LastUpdateContactTVItemID = 0;
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.LastUpdateContactTVItemID = 1;
            actionHydrometricDataValue = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.IsType<BadRequestObjectResult>(actionHydrometricDataValue.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post HydrometricDataValue
            var actionHydrometricDataValueAdded = await HydrometricDataValueService.Post(hydrometricDataValue);
            Assert.Equal(200, ((ObjectResult)actionHydrometricDataValueAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricDataValueAdded.Result).Value);
            HydrometricDataValue hydrometricDataValueAdded = (HydrometricDataValue)((OkObjectResult)actionHydrometricDataValueAdded.Result).Value;
            Assert.NotNull(hydrometricDataValueAdded);

            // List<HydrometricDataValue>
            var actionHydrometricDataValueList = await HydrometricDataValueService.GetHydrometricDataValueList();
            Assert.Equal(200, ((ObjectResult)actionHydrometricDataValueList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricDataValueList.Result).Value);
            List<HydrometricDataValue> hydrometricDataValueList = (List<HydrometricDataValue>)((OkObjectResult)actionHydrometricDataValueList.Result).Value;

            int count = ((List<HydrometricDataValue>)((OkObjectResult)actionHydrometricDataValueList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<HydrometricDataValue> with skip and take
                var actionHydrometricDataValueListSkipAndTake = await HydrometricDataValueService.GetHydrometricDataValueList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionHydrometricDataValueListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionHydrometricDataValueListSkipAndTake.Result).Value);
                List<HydrometricDataValue> hydrometricDataValueListSkipAndTake = (List<HydrometricDataValue>)((OkObjectResult)actionHydrometricDataValueListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<HydrometricDataValue>)((OkObjectResult)actionHydrometricDataValueListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(hydrometricDataValueList[0].HydrometricDataValueID == hydrometricDataValueListSkipAndTake[0].HydrometricDataValueID);
            }

            // Get HydrometricDataValue With HydrometricDataValueID
            var actionHydrometricDataValueGet = await HydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValueList[0].HydrometricDataValueID);
            Assert.Equal(200, ((ObjectResult)actionHydrometricDataValueGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricDataValueGet.Result).Value);
            HydrometricDataValue hydrometricDataValueGet = (HydrometricDataValue)((OkObjectResult)actionHydrometricDataValueGet.Result).Value;
            Assert.NotNull(hydrometricDataValueGet);
            Assert.Equal(hydrometricDataValueGet.HydrometricDataValueID, hydrometricDataValueList[0].HydrometricDataValueID);

            // Put HydrometricDataValue
            var actionHydrometricDataValueUpdated = await HydrometricDataValueService.Put(hydrometricDataValue);
            Assert.Equal(200, ((ObjectResult)actionHydrometricDataValueUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricDataValueUpdated.Result).Value);
            HydrometricDataValue hydrometricDataValueUpdated = (HydrometricDataValue)((OkObjectResult)actionHydrometricDataValueUpdated.Result).Value;
            Assert.NotNull(hydrometricDataValueUpdated);

            // Delete HydrometricDataValue
            var actionHydrometricDataValueDeleted = await HydrometricDataValueService.Delete(hydrometricDataValue.HydrometricDataValueID);
            Assert.Equal(200, ((ObjectResult)actionHydrometricDataValueDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricDataValueDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionHydrometricDataValueDeleted.Result).Value;
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
            Services.AddSingleton<IHydrometricDataValueService, HydrometricDataValueService>();

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

            HydrometricDataValueService = Provider.GetService<IHydrometricDataValueService>();
            Assert.NotNull(HydrometricDataValueService);

            return await Task.FromResult(true);
        }
        private HydrometricDataValue GetFilledRandomHydrometricDataValue(string OmitPropName)
        {
            List<HydrometricDataValue> hydrometricDataValueListToDelete = (from c in dbLocal.HydrometricDataValues
                                                               select c).ToList(); 
            
            dbLocal.HydrometricDataValues.RemoveRange(hydrometricDataValueListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            HydrometricDataValue hydrometricDataValue = new HydrometricDataValue();

            if (OmitPropName != "HydrometricSiteID") hydrometricDataValue.HydrometricSiteID = 1;
            if (OmitPropName != "DateTime_Local") hydrometricDataValue.DateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Keep") hydrometricDataValue.Keep = true;
            if (OmitPropName != "StorageDataType") hydrometricDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "HasBeenRead") hydrometricDataValue.HasBeenRead = true;
            if (OmitPropName != "Discharge_m3_s") hydrometricDataValue.Discharge_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "DischargeEntered_m3_s") hydrometricDataValue.DischargeEntered_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "Level_m") hydrometricDataValue.Level_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "HourlyValues") hydrometricDataValue.HourlyValues = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricDataValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricDataValue.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "HydrometricDataValueID") hydrometricDataValue.HydrometricDataValueID = 10000000;

                try
                {
                    dbIM.HydrometricSites.Add(new HydrometricSite() { HydrometricSiteID = 1, HydrometricSiteTVItemID = 8, FedSiteNumber = "01BL003", QuebecSiteNumber = "null", HydrometricSiteName = "BIG TRACADIE RIVER AT MURCHY BRIDGE CROSSING", Description = "null", Province = "NB", Elevation_m = null, StartDate_Local = new DateTime(1970, 1, 1, 0, 0, 0), EndDate_Local = new DateTime(2028, 12, 31, 0, 0, 0), TimeOffset_hour = -4D, DrainageArea_km2 = 383, IsNatural = true, IsActive = true, Sediment = false, RHBN = false, RealTime = true, HasDischarge = true, HasLevel = true, HasRatingCurve = true, LastUpdateDate_UTC = new DateTime(2018, 9, 13, 16, 56, 10), LastUpdateContactTVItemID = 2 });
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

            return hydrometricDataValue;
        }
        private void CheckHydrometricDataValueFields(List<HydrometricDataValue> hydrometricDataValueList)
        {
            if (hydrometricDataValueList[0].Discharge_m3_s != null)
            {
                Assert.NotNull(hydrometricDataValueList[0].Discharge_m3_s);
            }
            if (hydrometricDataValueList[0].DischargeEntered_m3_s != null)
            {
                Assert.NotNull(hydrometricDataValueList[0].DischargeEntered_m3_s);
            }
            if (hydrometricDataValueList[0].Level_m != null)
            {
                Assert.NotNull(hydrometricDataValueList[0].Level_m);
            }
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueList[0].HourlyValues))
            {
                Assert.False(string.IsNullOrWhiteSpace(hydrometricDataValueList[0].HourlyValues));
            }
        }
        #endregion Functions private
    }
}