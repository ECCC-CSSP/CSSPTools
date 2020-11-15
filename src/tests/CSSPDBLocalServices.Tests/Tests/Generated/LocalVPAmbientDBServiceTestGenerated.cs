/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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
using CSSPDBModels;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class LocalVPAmbientDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalVPAmbientDBService LocalVPAmbientDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalVPAmbient localVPAmbient { get; set; }
        #endregion Properties

        #region Constructors
        public LocalVPAmbientDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalVPAmbientDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalVPAmbientDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localVPAmbient = GetFilledRandomLocalVPAmbient("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalVPAmbient_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalVPAmbientList = await LocalVPAmbientDBService.GetLocalVPAmbientList();
            Assert.Equal(200, ((ObjectResult)actionLocalVPAmbientList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPAmbientList.Result).Value);
            List<LocalVPAmbient> localVPAmbientList = (List<LocalVPAmbient>)((OkObjectResult)actionLocalVPAmbientList.Result).Value;

            count = localVPAmbientList.Count();

            LocalVPAmbient localVPAmbient = GetFilledRandomLocalVPAmbient("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localVPAmbient.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localVPAmbient.VPAmbientID   (Int32)
            // -----------------------------------

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.VPAmbientID = 0;

            actionLocalVPAmbient = await LocalVPAmbientDBService.Put(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.VPAmbientID = 10000000;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Put(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = )]
            // localVPAmbient.VPScenarioID   (Int32)
            // -----------------------------------

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.VPScenarioID = 0;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10)]
            // localVPAmbient.Row   (Int32)
            // -----------------------------------

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.Row = -1;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientService.GetLocalVPAmbientList().Count());
            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.Row = 11;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientDBService.GetLocalVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // localVPAmbient.MeasurementDepth_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [MeasurementDepth_m]

            //CSSPError: Type not implemented [MeasurementDepth_m]

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.MeasurementDepth_m = -1.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientService.GetLocalVPAmbientList().Count());
            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.MeasurementDepth_m = 1001.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientDBService.GetLocalVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10)]
            // localVPAmbient.CurrentSpeed_m_s   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [CurrentSpeed_m_s]

            //CSSPError: Type not implemented [CurrentSpeed_m_s]

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.CurrentSpeed_m_s = -1.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientService.GetLocalVPAmbientList().Count());
            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.CurrentSpeed_m_s = 11.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientDBService.GetLocalVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-180, 180)]
            // localVPAmbient.CurrentDirection_deg   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [CurrentDirection_deg]

            //CSSPError: Type not implemented [CurrentDirection_deg]

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.CurrentDirection_deg = -181.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientService.GetLocalVPAmbientList().Count());
            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.CurrentDirection_deg = 181.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientDBService.GetLocalVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 40)]
            // localVPAmbient.AmbientSalinity_PSU   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [AmbientSalinity_PSU]

            //CSSPError: Type not implemented [AmbientSalinity_PSU]

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.AmbientSalinity_PSU = -1.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientService.GetLocalVPAmbientList().Count());
            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.AmbientSalinity_PSU = 41.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientDBService.GetLocalVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-10, 40)]
            // localVPAmbient.AmbientTemperature_C   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [AmbientTemperature_C]

            //CSSPError: Type not implemented [AmbientTemperature_C]

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.AmbientTemperature_C = -11.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientService.GetLocalVPAmbientList().Count());
            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.AmbientTemperature_C = 41.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientDBService.GetLocalVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10000000)]
            // localVPAmbient.BackgroundConcentration_MPN_100ml   (Int32)
            // -----------------------------------

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.BackgroundConcentration_MPN_100ml = -1;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientService.GetLocalVPAmbientList().Count());
            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.BackgroundConcentration_MPN_100ml = 10000001;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientDBService.GetLocalVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 100)]
            // localVPAmbient.PollutantDecayRate_per_day   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [PollutantDecayRate_per_day]

            //CSSPError: Type not implemented [PollutantDecayRate_per_day]

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.PollutantDecayRate_per_day = -1.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientService.GetLocalVPAmbientList().Count());
            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.PollutantDecayRate_per_day = 101.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientDBService.GetLocalVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10)]
            // localVPAmbient.FarFieldCurrentSpeed_m_s   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [FarFieldCurrentSpeed_m_s]

            //CSSPError: Type not implemented [FarFieldCurrentSpeed_m_s]

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.FarFieldCurrentSpeed_m_s = -1.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientService.GetLocalVPAmbientList().Count());
            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.FarFieldCurrentSpeed_m_s = 11.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientDBService.GetLocalVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-180, 180)]
            // localVPAmbient.FarFieldCurrentDirection_deg   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [FarFieldCurrentDirection_deg]

            //CSSPError: Type not implemented [FarFieldCurrentDirection_deg]

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.FarFieldCurrentDirection_deg = -181.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientService.GetLocalVPAmbientList().Count());
            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.FarFieldCurrentDirection_deg = 181.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientDBService.GetLocalVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1)]
            // localVPAmbient.FarFieldDiffusionCoefficient   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [FarFieldDiffusionCoefficient]

            //CSSPError: Type not implemented [FarFieldDiffusionCoefficient]

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.FarFieldDiffusionCoefficient = -1.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientService.GetLocalVPAmbientList().Count());
            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.FarFieldDiffusionCoefficient = 2.0D;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            //Assert.AreEqual(count, localVPAmbientDBService.GetLocalVPAmbientList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localVPAmbient.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.LastUpdateDate_UTC = new DateTime();
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);
            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localVPAmbient.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.LastUpdateContactTVItemID = 0;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);

            localVPAmbient = null;
            localVPAmbient = GetFilledRandomLocalVPAmbient("");
            localVPAmbient.LastUpdateContactTVItemID = 1;
            actionLocalVPAmbient = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPAmbient.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalVPAmbient
            var actionLocalVPAmbientAdded = await LocalVPAmbientDBService.Post(localVPAmbient);
            Assert.Equal(200, ((ObjectResult)actionLocalVPAmbientAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPAmbientAdded.Result).Value);
            LocalVPAmbient localVPAmbientAdded = (LocalVPAmbient)((OkObjectResult)actionLocalVPAmbientAdded.Result).Value;
            Assert.NotNull(localVPAmbientAdded);

            // List<LocalVPAmbient>
            var actionLocalVPAmbientList = await LocalVPAmbientDBService.GetLocalVPAmbientList();
            Assert.Equal(200, ((ObjectResult)actionLocalVPAmbientList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPAmbientList.Result).Value);
            List<LocalVPAmbient> localVPAmbientList = (List<LocalVPAmbient>)((OkObjectResult)actionLocalVPAmbientList.Result).Value;

            int count = ((List<LocalVPAmbient>)((OkObjectResult)actionLocalVPAmbientList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalVPAmbient> with skip and take
            var actionLocalVPAmbientListSkipAndTake = await LocalVPAmbientDBService.GetLocalVPAmbientList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalVPAmbientListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPAmbientListSkipAndTake.Result).Value);
            List<LocalVPAmbient> localVPAmbientListSkipAndTake = (List<LocalVPAmbient>)((OkObjectResult)actionLocalVPAmbientListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalVPAmbient>)((OkObjectResult)actionLocalVPAmbientListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localVPAmbientList[0].VPAmbientID == localVPAmbientListSkipAndTake[0].VPAmbientID);

            // Get LocalVPAmbient With VPAmbientID
            var actionLocalVPAmbientGet = await LocalVPAmbientDBService.GetLocalVPAmbientWithVPAmbientID(localVPAmbientList[0].VPAmbientID);
            Assert.Equal(200, ((ObjectResult)actionLocalVPAmbientGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPAmbientGet.Result).Value);
            LocalVPAmbient localVPAmbientGet = (LocalVPAmbient)((OkObjectResult)actionLocalVPAmbientGet.Result).Value;
            Assert.NotNull(localVPAmbientGet);
            Assert.Equal(localVPAmbientGet.VPAmbientID, localVPAmbientList[0].VPAmbientID);

            // Put LocalVPAmbient
            var actionLocalVPAmbientUpdated = await LocalVPAmbientDBService.Put(localVPAmbient);
            Assert.Equal(200, ((ObjectResult)actionLocalVPAmbientUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPAmbientUpdated.Result).Value);
            LocalVPAmbient localVPAmbientUpdated = (LocalVPAmbient)((OkObjectResult)actionLocalVPAmbientUpdated.Result).Value;
            Assert.NotNull(localVPAmbientUpdated);

            // Delete LocalVPAmbient
            var actionLocalVPAmbientDeleted = await LocalVPAmbientDBService.Delete(localVPAmbient.VPAmbientID);
            Assert.Equal(200, ((ObjectResult)actionLocalVPAmbientDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPAmbientDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalVPAmbientDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocal = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILocalVPAmbientDBService, LocalVPAmbientDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            LocalVPAmbientDBService = Provider.GetService<ILocalVPAmbientDBService>();
            Assert.NotNull(LocalVPAmbientDBService);

            return await Task.FromResult(true);
        }
        private LocalVPAmbient GetFilledRandomLocalVPAmbient(string OmitPropName)
        {
            LocalVPAmbient localVPAmbient = new LocalVPAmbient();

            if (OmitPropName != "LocalDBCommand") localVPAmbient.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "VPScenarioID") localVPAmbient.VPScenarioID = 0;
            if (OmitPropName != "Row") localVPAmbient.Row = GetRandomInt(0, 10);
            if (OmitPropName != "MeasurementDepth_m") localVPAmbient.MeasurementDepth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "CurrentSpeed_m_s") localVPAmbient.CurrentSpeed_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "CurrentDirection_deg") localVPAmbient.CurrentDirection_deg = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "AmbientSalinity_PSU") localVPAmbient.AmbientSalinity_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "AmbientTemperature_C") localVPAmbient.AmbientTemperature_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "BackgroundConcentration_MPN_100ml") localVPAmbient.BackgroundConcentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "PollutantDecayRate_per_day") localVPAmbient.PollutantDecayRate_per_day = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "FarFieldCurrentSpeed_m_s") localVPAmbient.FarFieldCurrentSpeed_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "FarFieldCurrentDirection_deg") localVPAmbient.FarFieldCurrentDirection_deg = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "FarFieldDiffusionCoefficient") localVPAmbient.FarFieldDiffusionCoefficient = GetRandomDouble(0.0D, 1.0D);
            if (OmitPropName != "LastUpdateDate_UTC") localVPAmbient.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localVPAmbient.LastUpdateContactTVItemID = 2;



            return localVPAmbient;
        }
        private void CheckLocalVPAmbientFields(List<LocalVPAmbient> localVPAmbientList)
        {
            if (localVPAmbientList[0].MeasurementDepth_m != null)
            {
                Assert.NotNull(localVPAmbientList[0].MeasurementDepth_m);
            }
            if (localVPAmbientList[0].CurrentSpeed_m_s != null)
            {
                Assert.NotNull(localVPAmbientList[0].CurrentSpeed_m_s);
            }
            if (localVPAmbientList[0].CurrentDirection_deg != null)
            {
                Assert.NotNull(localVPAmbientList[0].CurrentDirection_deg);
            }
            if (localVPAmbientList[0].AmbientSalinity_PSU != null)
            {
                Assert.NotNull(localVPAmbientList[0].AmbientSalinity_PSU);
            }
            if (localVPAmbientList[0].AmbientTemperature_C != null)
            {
                Assert.NotNull(localVPAmbientList[0].AmbientTemperature_C);
            }
            if (localVPAmbientList[0].BackgroundConcentration_MPN_100ml != null)
            {
                Assert.NotNull(localVPAmbientList[0].BackgroundConcentration_MPN_100ml);
            }
            if (localVPAmbientList[0].PollutantDecayRate_per_day != null)
            {
                Assert.NotNull(localVPAmbientList[0].PollutantDecayRate_per_day);
            }
            if (localVPAmbientList[0].FarFieldCurrentSpeed_m_s != null)
            {
                Assert.NotNull(localVPAmbientList[0].FarFieldCurrentSpeed_m_s);
            }
            if (localVPAmbientList[0].FarFieldCurrentDirection_deg != null)
            {
                Assert.NotNull(localVPAmbientList[0].FarFieldCurrentDirection_deg);
            }
            if (localVPAmbientList[0].FarFieldDiffusionCoefficient != null)
            {
                Assert.NotNull(localVPAmbientList[0].FarFieldDiffusionCoefficient);
            }
        }

        #endregion Functions private
    }
}