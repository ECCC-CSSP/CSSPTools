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
    public partial class VPResultServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IVPResultService VPResultService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private VPResult vpResult { get; set; }
        #endregion Properties

        #region Constructors
        public VPResultServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task VPResult_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            vpResult = GetFilledRandomVPResult("");

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
        public async Task VPResult_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionVPResultList = await VPResultService.GetVPResultList();
            Assert.Equal(200, ((ObjectResult)actionVPResultList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPResultList.Result).Value);
            List<VPResult> vpResultList = (List<VPResult>)((OkObjectResult)actionVPResultList.Result).Value;

            count = vpResultList.Count();

            VPResult vpResult = GetFilledRandomVPResult("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // vpResult.VPResultID   (Int32)
            // -----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.VPResultID = 0;

            var actionVPResult = await VPResultService.Put(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.VPResultID = 10000000;
            actionVPResult = await VPResultService.Put(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = )]
            // vpResult.VPScenarioID   (Int32)
            // -----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.VPScenarioID = 0;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // vpResult.Ordinal   (Int32)
            // -----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.Ordinal = -1;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);
            //Assert.AreEqual(count, vpResultService.GetVPResultList().Count());
            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.Ordinal = 1001;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);
            //Assert.AreEqual(count, vpResultService.GetVPResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // vpResult.Concentration_MPN_100ml   (Int32)
            // -----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.Concentration_MPN_100ml = -1;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);
            //Assert.AreEqual(count, vpResultService.GetVPResultList().Count());
            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.Concentration_MPN_100ml = 10000001;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);
            //Assert.AreEqual(count, vpResultService.GetVPResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000000)]
            // vpResult.Dilution   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Dilution]

            //CSSPError: Type not implemented [Dilution]

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.Dilution = -1.0D;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);
            //Assert.AreEqual(count, vpResultService.GetVPResultList().Count());
            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.Dilution = 1000001.0D;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);
            //Assert.AreEqual(count, vpResultService.GetVPResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000)]
            // vpResult.FarFieldWidth_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [FarFieldWidth_m]

            //CSSPError: Type not implemented [FarFieldWidth_m]

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.FarFieldWidth_m = -1.0D;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);
            //Assert.AreEqual(count, vpResultService.GetVPResultList().Count());
            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.FarFieldWidth_m = 10001.0D;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);
            //Assert.AreEqual(count, vpResultService.GetVPResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100000)]
            // vpResult.DispersionDistance_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [DispersionDistance_m]

            //CSSPError: Type not implemented [DispersionDistance_m]

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.DispersionDistance_m = -1.0D;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);
            //Assert.AreEqual(count, vpResultService.GetVPResultList().Count());
            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.DispersionDistance_m = 100001.0D;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);
            //Assert.AreEqual(count, vpResultService.GetVPResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100)]
            // vpResult.TravelTime_hour   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [TravelTime_hour]

            //CSSPError: Type not implemented [TravelTime_hour]

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.TravelTime_hour = -1.0D;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);
            //Assert.AreEqual(count, vpResultService.GetVPResultList().Count());
            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.TravelTime_hour = 101.0D;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);
            //Assert.AreEqual(count, vpResultService.GetVPResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // vpResult.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.LastUpdateDate_UTC = new DateTime();
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);
            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // vpResult.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.LastUpdateContactTVItemID = 0;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            vpResult.LastUpdateContactTVItemID = 1;
            actionVPResult = await VPResultService.Post(vpResult);
            Assert.IsType<BadRequestObjectResult>(actionVPResult.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post VPResult
            var actionVPResultAdded = await VPResultService.Post(vpResult);
            Assert.Equal(200, ((ObjectResult)actionVPResultAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPResultAdded.Result).Value);
            VPResult vpResultAdded = (VPResult)((OkObjectResult)actionVPResultAdded.Result).Value;
            Assert.NotNull(vpResultAdded);

            // List<VPResult>
            var actionVPResultList = await VPResultService.GetVPResultList();
            Assert.Equal(200, ((ObjectResult)actionVPResultList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPResultList.Result).Value);
            List<VPResult> vpResultList = (List<VPResult>)((OkObjectResult)actionVPResultList.Result).Value;

            int count = ((List<VPResult>)((OkObjectResult)actionVPResultList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<VPResult> with skip and take
                var actionVPResultListSkipAndTake = await VPResultService.GetVPResultList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionVPResultListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionVPResultListSkipAndTake.Result).Value);
                List<VPResult> vpResultListSkipAndTake = (List<VPResult>)((OkObjectResult)actionVPResultListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<VPResult>)((OkObjectResult)actionVPResultListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(vpResultList[0].VPResultID == vpResultListSkipAndTake[0].VPResultID);
            }

            // Get VPResult With VPResultID
            var actionVPResultGet = await VPResultService.GetVPResultWithVPResultID(vpResultList[0].VPResultID);
            Assert.Equal(200, ((ObjectResult)actionVPResultGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPResultGet.Result).Value);
            VPResult vpResultGet = (VPResult)((OkObjectResult)actionVPResultGet.Result).Value;
            Assert.NotNull(vpResultGet);
            Assert.Equal(vpResultGet.VPResultID, vpResultList[0].VPResultID);

            // Put VPResult
            var actionVPResultUpdated = await VPResultService.Put(vpResult);
            Assert.Equal(200, ((ObjectResult)actionVPResultUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPResultUpdated.Result).Value);
            VPResult vpResultUpdated = (VPResult)((OkObjectResult)actionVPResultUpdated.Result).Value;
            Assert.NotNull(vpResultUpdated);

            // Delete VPResult
            var actionVPResultDeleted = await VPResultService.Delete(vpResult.VPResultID);
            Assert.Equal(200, ((ObjectResult)actionVPResultDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPResultDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionVPResultDeleted.Result).Value;
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
            Services.AddSingleton<IVPResultService, VPResultService>();

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

            VPResultService = Provider.GetService<IVPResultService>();
            Assert.NotNull(VPResultService);

            return await Task.FromResult(true);
        }
        private VPResult GetFilledRandomVPResult(string OmitPropName)
        {
            List<VPResult> vpResultListToDelete = (from c in dbLocal.VPResults
                                                               select c).ToList(); 
            
            dbLocal.VPResults.RemoveRange(vpResultListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            VPResult vpResult = new VPResult();

            if (OmitPropName != "VPScenarioID") vpResult.VPScenarioID = 1;
            if (OmitPropName != "Ordinal") vpResult.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "Concentration_MPN_100ml") vpResult.Concentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Dilution") vpResult.Dilution = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "FarFieldWidth_m") vpResult.FarFieldWidth_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "DispersionDistance_m") vpResult.DispersionDistance_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "TravelTime_hour") vpResult.TravelTime_hour = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "LastUpdateDate_UTC") vpResult.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") vpResult.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "VPResultID") vpResult.VPResultID = 10000000;

                try
                {
                    dbIM.VPScenarios.Add(new VPScenario() { VPScenarioID = 1, InfrastructureTVItemID = 41, VPScenarioStatus = (ScenarioStatusEnum)8, UseAsBestEstimate = true, EffluentFlow_m3_s = 0.01609, EffluentConcentration_MPN_100ml = 2500000, FroudeNumber = 0.432, PortDiameter_m = 0.4, PortDepth_m = 0.3, PortElevation_m = 0.2, VerticalAngle_deg = 0, HorizontalAngle_deg = 90, NumberOfPorts = 1, PortSpacing_m = 1000, AcuteMixZone_m = 50, ChronicMixZone_m = 40000, EffluentSalinity_PSU = 0, EffluentTemperature_C = 15, EffluentVelocity_m_s = 0.128, RawResults = "Raw Results not shown... too long", LastUpdateDate_UTC = new DateTime(2015, 2, 25, 11, 49, 31), LastUpdateContactTVItemID = 2 });
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

            return vpResult;
        }
        private void CheckVPResultFields(List<VPResult> vpResultList)
        {
        }
        #endregion Functions private
    }
}