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
    public partial class VPAmbientServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IVPAmbientService VPAmbientService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private VPAmbient vpAmbient { get; set; }
        #endregion Properties

        #region Constructors
        public VPAmbientServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task VPAmbient_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            vpAmbient = GetFilledRandomVPAmbient("");

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
            // Post VPAmbient
            var actionVPAmbientAdded = await VPAmbientService.Post(vpAmbient);
            Assert.Equal(200, ((ObjectResult)actionVPAmbientAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientAdded.Result).Value);
            VPAmbient vpAmbientAdded = (VPAmbient)((OkObjectResult)actionVPAmbientAdded.Result).Value;
            Assert.NotNull(vpAmbientAdded);

            // List<VPAmbient>
            var actionVPAmbientList = await VPAmbientService.GetVPAmbientList();
            Assert.Equal(200, ((ObjectResult)actionVPAmbientList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientList.Result).Value);
            List<VPAmbient> vpAmbientList = (List<VPAmbient>)((OkObjectResult)actionVPAmbientList.Result).Value;

            int count = ((List<VPAmbient>)((OkObjectResult)actionVPAmbientList.Result).Value).Count();
            Assert.True(count > 0);

            // Put VPAmbient
            var actionVPAmbientUpdated = await VPAmbientService.Put(vpAmbient);
            Assert.Equal(200, ((ObjectResult)actionVPAmbientUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientUpdated.Result).Value);
            VPAmbient vpAmbientUpdated = (VPAmbient)((OkObjectResult)actionVPAmbientUpdated.Result).Value;
            Assert.NotNull(vpAmbientUpdated);

            // Delete VPAmbient
            var actionVPAmbientDeleted = await VPAmbientService.Delete(vpAmbient.VPAmbientID);
            Assert.Equal(200, ((ObjectResult)actionVPAmbientDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionVPAmbientDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
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

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{appDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IVPAmbientService, VPAmbientService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            //string IsLocalStr = Config.GetValue<string>("IsLocal");
            //Assert.NotNull(IsLocalStr);

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            VPAmbientService = Provider.GetService<IVPAmbientService>();
            Assert.NotNull(VPAmbientService);

            return await Task.FromResult(true);
        }
        private VPAmbient GetFilledRandomVPAmbient(string OmitPropName)
        {
            List<VPAmbient> vpAmbientListToDelete = (from c in dbLocal.VPAmbients
                                                               select c).ToList(); 
            
            dbLocal.VPAmbients.RemoveRange(vpAmbientListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            VPAmbient vpAmbient = new VPAmbient();

            if (OmitPropName != "VPScenarioID") vpAmbient.VPScenarioID = 1;
            if (OmitPropName != "Row") vpAmbient.Row = GetRandomInt(0, 10);
            if (OmitPropName != "MeasurementDepth_m") vpAmbient.MeasurementDepth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "CurrentSpeed_m_s") vpAmbient.CurrentSpeed_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "CurrentDirection_deg") vpAmbient.CurrentDirection_deg = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "AmbientSalinity_PSU") vpAmbient.AmbientSalinity_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "AmbientTemperature_C") vpAmbient.AmbientTemperature_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "BackgroundConcentration_MPN_100ml") vpAmbient.BackgroundConcentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "PollutantDecayRate_per_day") vpAmbient.PollutantDecayRate_per_day = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "FarFieldCurrentSpeed_m_s") vpAmbient.FarFieldCurrentSpeed_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "FarFieldCurrentDirection_deg") vpAmbient.FarFieldCurrentDirection_deg = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "FarFieldDiffusionCoefficient") vpAmbient.FarFieldDiffusionCoefficient = GetRandomDouble(0.0D, 1.0D);
            if (OmitPropName != "LastUpdateDate_UTC") vpAmbient.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") vpAmbient.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "VPAmbientID") vpAmbient.VPAmbientID = 10000000;

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

            return vpAmbient;
        }
        #endregion Functions private
    }
}
