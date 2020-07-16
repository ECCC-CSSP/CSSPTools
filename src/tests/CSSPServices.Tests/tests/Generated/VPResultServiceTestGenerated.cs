/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
using LoggedInServices.Services;
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
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IVPResultService VPResultService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private VPResult vpResult { get; set; }
        #endregion Properties

        #region Constructors
        public VPResultServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task VPResult_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            vpResult = GetFilledRandomVPResult("");

            if (LoggedInService.IsLocal)
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
               .AddJsonFile("appsettings_csspservices.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IVPResultService, VPResultService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.IsLocal = true;

            dbIM = Provider.GetService<InMemoryDBContext>();
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

            if (LoggedInService.IsLocal)
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
        #endregion Functions private
    }
}
