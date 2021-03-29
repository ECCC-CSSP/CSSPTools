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
    public partial class VPAmbientDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IVPAmbientDBService VPAmbientDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBContext dbIM { get; set; }
        private VPAmbient vpAmbient { get; set; }
        #endregion Properties

        #region Constructors
        public VPAmbientDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task VPAmbientDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task VPAmbientDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            vpAmbient = GetFilledRandomVPAmbient("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

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

            var actionVPAmbientList = await VPAmbientDBService.GetVPAmbientList();
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

            var actionVPAmbient = await VPAmbientDBService.Put(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.VPAmbientID = 10000000;
            actionVPAmbient = await VPAmbientDBService.Put(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // vpAmbient.DBCommand   (DBCommandEnum)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.DBCommand = (DBCommandEnum)1000000;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = )]
            // vpAmbient.VPScenarioID   (Int32)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.VPScenarioID = 0;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10)]
            // vpAmbient.Row   (Int32)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.Row = -1;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.Row = 11;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.MeasurementDepth_m = 1001.0D;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.CurrentSpeed_m_s = 11.0D;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.CurrentDirection_deg = 181.0D;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.AmbientSalinity_PSU = 41.0D;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.AmbientTemperature_C = 41.0D;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10000000)]
            // vpAmbient.BackgroundConcentration_MPN_100ml   (Int32)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.BackgroundConcentration_MPN_100ml = -1;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.BackgroundConcentration_MPN_100ml = 10000001;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.PollutantDecayRate_per_day = 101.0D;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.FarFieldCurrentSpeed_m_s = 11.0D;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.FarFieldCurrentDirection_deg = 181.0D;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.FarFieldDiffusionCoefficient = 2.0D;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientDBService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // vpAmbient.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.LastUpdateDate_UTC = new DateTime();
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // vpAmbient.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.LastUpdateContactTVItemID = 0;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.LastUpdateContactTVItemID = 1;
            actionVPAmbient = await VPAmbientDBService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post VPAmbient
            var actionVPAmbientAdded = await VPAmbientDBService.Post(vpAmbient);
            Assert.Equal(200, ((ObjectResult)actionVPAmbientAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientAdded.Result).Value);
            VPAmbient vpAmbientAdded = (VPAmbient)((OkObjectResult)actionVPAmbientAdded.Result).Value;
            Assert.NotNull(vpAmbientAdded);

            // List<VPAmbient>
            var actionVPAmbientList = await VPAmbientDBService.GetVPAmbientList();
            Assert.Equal(200, ((ObjectResult)actionVPAmbientList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientList.Result).Value);
            List<VPAmbient> vpAmbientList = (List<VPAmbient>)((OkObjectResult)actionVPAmbientList.Result).Value;

            int count = ((List<VPAmbient>)((OkObjectResult)actionVPAmbientList.Result).Value).Count();
            Assert.True(count > 0);

            // List<VPAmbient> with skip and take
            var actionVPAmbientListSkipAndTake = await VPAmbientDBService.GetVPAmbientList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionVPAmbientListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientListSkipAndTake.Result).Value);
            List<VPAmbient> vpAmbientListSkipAndTake = (List<VPAmbient>)((OkObjectResult)actionVPAmbientListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<VPAmbient>)((OkObjectResult)actionVPAmbientListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(vpAmbientList[0].VPAmbientID == vpAmbientListSkipAndTake[0].VPAmbientID);

            // Get VPAmbient With VPAmbientID
            var actionVPAmbientGet = await VPAmbientDBService.GetVPAmbientWithVPAmbientID(vpAmbientList[0].VPAmbientID);
            Assert.Equal(200, ((ObjectResult)actionVPAmbientGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientGet.Result).Value);
            VPAmbient vpAmbientGet = (VPAmbient)((OkObjectResult)actionVPAmbientGet.Result).Value;
            Assert.NotNull(vpAmbientGet);
            Assert.Equal(vpAmbientGet.VPAmbientID, vpAmbientList[0].VPAmbientID);

            // Put VPAmbient
            var actionVPAmbientUpdated = await VPAmbientDBService.Put(vpAmbient);
            Assert.Equal(200, ((ObjectResult)actionVPAmbientUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientUpdated.Result).Value);
            VPAmbient vpAmbientUpdated = (VPAmbient)((OkObjectResult)actionVPAmbientUpdated.Result).Value;
            Assert.NotNull(vpAmbientUpdated);

            // Delete VPAmbient
            var actionVPAmbientDeleted = await VPAmbientDBService.Delete(vpAmbient.VPAmbientID);
            Assert.Equal(200, ((ObjectResult)actionVPAmbientDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionVPAmbientDeleted.Result).Value;
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
            Services.AddSingleton<IVPAmbientDBService, VPAmbientDBService>();

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

            VPAmbientDBService = Provider.GetService<IVPAmbientDBService>();
            Assert.NotNull(VPAmbientDBService);

            return await Task.FromResult(true);
        }
        private VPAmbient GetFilledRandomVPAmbient(string OmitPropName)
        {
            VPAmbient vpAmbient = new VPAmbient();

            if (OmitPropName != "DBCommand") vpAmbient.DBCommand = (DBCommandEnum)GetRandomEnumType(typeof(DBCommandEnum));
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
