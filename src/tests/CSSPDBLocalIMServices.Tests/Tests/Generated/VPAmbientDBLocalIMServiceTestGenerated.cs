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

namespace CSSPDBLocalIMServices.Tests
{
    [Collection("Sequential")]
    public partial class VPAmbientDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IVPAmbientDBLocalIMService VPAmbientDBLocalIMService { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private VPAmbient vpAmbient { get; set; }
        #endregion Properties

        #region Constructors
        public VPAmbientDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocalIM]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task VPAmbientDBLocalIM_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocalIM]

        #region Tests Generated [DBLocalIM] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task VPAmbientDBLocalIM_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            vpAmbient = GetFilledRandomVPAmbient("");

            await DoCRUDDBLocalIMTest();
        }
        #endregion Tests Generated [DBLocalIM] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task VPAmbient_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionVPAmbientList = await VPAmbientDBLocalIMService.GetVPAmbientList();
            Assert.Equal(200, ((ObjectResult)actionVPAmbientList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientList.Result).Value);
            List<VPAmbient> vpAmbientList = (List<VPAmbient>)((OkObjectResult)actionVPAmbientList.Result).Value;

            count = vpAmbientList.Count();

            VPAmbient vpAmbient = GetFilledRandomVPAmbient("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // vpAmbient.VPAmbientID   (Int32)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.VPAmbientID = 0;

            var actionVPAmbient = await VPAmbientDBLocalIMService.Put(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.VPAmbientID = 10000000;
            actionVPAmbient = await VPAmbientDBLocalIMService.Put(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = )]
            // vpAmbient.VPScenarioID   (Int32)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.VPScenarioID = 0;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10)]
            // vpAmbient.Row   (Int32)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.Row = -1;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.Row = 11;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBLocalIMService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // vpAmbient.MeasurementDepth_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [MeasurementDepth_m]

            //CSSPError: Type not implemented [MeasurementDepth_m]

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.MeasurementDepth_m = -1.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.MeasurementDepth_m = 1001.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBLocalIMService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10)]
            // vpAmbient.CurrentSpeed_m_s   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [CurrentSpeed_m_s]

            //CSSPError: Type not implemented [CurrentSpeed_m_s]

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.CurrentSpeed_m_s = -1.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.CurrentSpeed_m_s = 11.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBLocalIMService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-180, 180)]
            // vpAmbient.CurrentDirection_deg   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [CurrentDirection_deg]

            //CSSPError: Type not implemented [CurrentDirection_deg]

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.CurrentDirection_deg = -181.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.CurrentDirection_deg = 181.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBLocalIMService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 40)]
            // vpAmbient.AmbientSalinity_PSU   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [AmbientSalinity_PSU]

            //CSSPError: Type not implemented [AmbientSalinity_PSU]

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.AmbientSalinity_PSU = -1.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.AmbientSalinity_PSU = 41.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBLocalIMService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-10, 40)]
            // vpAmbient.AmbientTemperature_C   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [AmbientTemperature_C]

            //CSSPError: Type not implemented [AmbientTemperature_C]

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.AmbientTemperature_C = -11.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.AmbientTemperature_C = 41.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBLocalIMService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10000000)]
            // vpAmbient.BackgroundConcentration_MPN_100ml   (Int32)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.BackgroundConcentration_MPN_100ml = -1;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.BackgroundConcentration_MPN_100ml = 10000001;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBLocalIMService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 100)]
            // vpAmbient.PollutantDecayRate_per_day   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [PollutantDecayRate_per_day]

            //CSSPError: Type not implemented [PollutantDecayRate_per_day]

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.PollutantDecayRate_per_day = -1.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.PollutantDecayRate_per_day = 101.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBLocalIMService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10)]
            // vpAmbient.FarFieldCurrentSpeed_m_s   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [FarFieldCurrentSpeed_m_s]

            //CSSPError: Type not implemented [FarFieldCurrentSpeed_m_s]

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.FarFieldCurrentSpeed_m_s = -1.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.FarFieldCurrentSpeed_m_s = 11.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBLocalIMService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-180, 180)]
            // vpAmbient.FarFieldCurrentDirection_deg   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [FarFieldCurrentDirection_deg]

            //CSSPError: Type not implemented [FarFieldCurrentDirection_deg]

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.FarFieldCurrentDirection_deg = -181.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.FarFieldCurrentDirection_deg = 181.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBLocalIMService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1)]
            // vpAmbient.FarFieldDiffusionCoefficient   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [FarFieldDiffusionCoefficient]

            //CSSPError: Type not implemented [FarFieldDiffusionCoefficient]

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.FarFieldDiffusionCoefficient = -1.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.FarFieldDiffusionCoefficient = 2.0D;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBLocalIMService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // vpAmbient.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.LastUpdateDate_UTC = new DateTime();
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // vpAmbient.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.LastUpdateContactTVItemID = 0;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.LastUpdateContactTVItemID = 1;
            actionVPAmbient = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalIMTest()
        {
            vpAmbient.VPAmbientID = 10000000;

            // Post VPAmbient
            var actionVPAmbientAdded = await VPAmbientDBLocalIMService.Post(vpAmbient);
            Assert.Equal(200, ((ObjectResult)actionVPAmbientAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientAdded.Result).Value);
            VPAmbient vpAmbientAdded = (VPAmbient)((OkObjectResult)actionVPAmbientAdded.Result).Value;
            Assert.NotNull(vpAmbientAdded);

            // List<VPAmbient>
            var actionVPAmbientList = await VPAmbientDBLocalIMService.GetVPAmbientList();
            Assert.Equal(200, ((ObjectResult)actionVPAmbientList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientList.Result).Value);
            List<VPAmbient> vpAmbientList = (List<VPAmbient>)((OkObjectResult)actionVPAmbientList.Result).Value;

            int count = ((List<VPAmbient>)((OkObjectResult)actionVPAmbientList.Result).Value).Count();
            Assert.True(count > 0);

            // Get VPAmbient With VPAmbientID
            var actionVPAmbientGet = await VPAmbientDBLocalIMService.GetVPAmbientWithVPAmbientID(vpAmbientList[0].VPAmbientID);
            Assert.Equal(200, ((ObjectResult)actionVPAmbientGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientGet.Result).Value);
            VPAmbient vpAmbientGet = (VPAmbient)((OkObjectResult)actionVPAmbientGet.Result).Value;
            Assert.NotNull(vpAmbientGet);
            Assert.Equal(vpAmbientGet.VPAmbientID, vpAmbientList[0].VPAmbientID);

            // Put VPAmbient
            var actionVPAmbientUpdated = await VPAmbientDBLocalIMService.Put(vpAmbient);
            Assert.Equal(200, ((ObjectResult)actionVPAmbientUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientUpdated.Result).Value);
            VPAmbient vpAmbientUpdated = (VPAmbient)((OkObjectResult)actionVPAmbientUpdated.Result).Value;
            Assert.NotNull(vpAmbientUpdated);

            // Delete VPAmbient
            var actionVPAmbientDeleted = await VPAmbientDBLocalIMService.Delete(vpAmbient.VPAmbientID);
            Assert.Equal(200, ((ObjectResult)actionVPAmbientDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionVPAmbientDeleted.Result).Value;
            Assert.True(retBool);

        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalimservicestests.json")
               .AddUserSecrets("64a6d1e4-0d0c-4e59-9c2e-640182417704")
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

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IVPAmbientDBLocalIMService, VPAmbientDBLocalIMService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbLocalIM);

            VPAmbientDBLocalIMService = Provider.GetService<IVPAmbientDBLocalIMService>();
            Assert.NotNull(VPAmbientDBLocalIMService);

            return await Task.FromResult(true);
        }
        private VPAmbient GetFilledRandomVPAmbient(string OmitPropName)
        {
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

            try
            {
                dbLocalIM.VPScenarios.Add(new VPScenario() { VPScenarioID = 1, InfrastructureTVItemID = 41, VPScenarioStatus = (ScenarioStatusEnum)8, UseAsBestEstimate = true, EffluentFlow_m3_s = 0.01609, EffluentConcentration_MPN_100ml = 2500000, FroudeNumber = 0.432, PortDiameter_m = 0.4, PortDepth_m = 0.3, PortElevation_m = 0.2, VerticalAngle_deg = 0, HorizontalAngle_deg = 90, NumberOfPorts = 1, PortSpacing_m = 1000, AcuteMixZone_m = 50, ChronicMixZone_m = 40000, EffluentSalinity_PSU = 0, EffluentTemperature_C = 15, EffluentVelocity_m_s = 0.128, RawResults = "Raw Results not shown... too long", LastUpdateDate_UTC = new DateTime(2015, 2, 25, 11, 49, 31), LastUpdateContactTVItemID = 2 });
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


            return vpAmbient;
        }
        private void CheckVPAmbientFields(List<VPAmbient> vpAmbientList)
        {
            if (vpAmbientList[0].MeasurementDepth_m != null)
            {
                Assert.NotNull(vpAmbientList[0].MeasurementDepth_m);
            }
            if (vpAmbientList[0].CurrentSpeed_m_s != null)
            {
                Assert.NotNull(vpAmbientList[0].CurrentSpeed_m_s);
            }
            if (vpAmbientList[0].CurrentDirection_deg != null)
            {
                Assert.NotNull(vpAmbientList[0].CurrentDirection_deg);
            }
            if (vpAmbientList[0].AmbientSalinity_PSU != null)
            {
                Assert.NotNull(vpAmbientList[0].AmbientSalinity_PSU);
            }
            if (vpAmbientList[0].AmbientTemperature_C != null)
            {
                Assert.NotNull(vpAmbientList[0].AmbientTemperature_C);
            }
            if (vpAmbientList[0].BackgroundConcentration_MPN_100ml != null)
            {
                Assert.NotNull(vpAmbientList[0].BackgroundConcentration_MPN_100ml);
            }
            if (vpAmbientList[0].PollutantDecayRate_per_day != null)
            {
                Assert.NotNull(vpAmbientList[0].PollutantDecayRate_per_day);
            }
            if (vpAmbientList[0].FarFieldCurrentSpeed_m_s != null)
            {
                Assert.NotNull(vpAmbientList[0].FarFieldCurrentSpeed_m_s);
            }
            if (vpAmbientList[0].FarFieldCurrentDirection_deg != null)
            {
                Assert.NotNull(vpAmbientList[0].FarFieldCurrentDirection_deg);
            }
            if (vpAmbientList[0].FarFieldDiffusionCoefficient != null)
            {
                Assert.NotNull(vpAmbientList[0].FarFieldDiffusionCoefficient);
            }
        }

        #endregion Functions private
    }
}