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
    public partial class VPAmbientServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IVPAmbientService VPAmbientService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private VPAmbient vpAmbient { get; set; }
        #endregion Properties

        #region Constructors
        public VPAmbientServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task VPAmbient_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            vpAmbient = GetFilledRandomVPAmbient("");

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
        public async Task VPAmbient_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionVPAmbientList = await VPAmbientService.GetVPAmbientList();
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

            var actionVPAmbient = await VPAmbientService.Put(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.VPAmbientID = 10000000;
            actionVPAmbient = await VPAmbientService.Put(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = )]
            // vpAmbient.VPScenarioID   (Int32)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.VPScenarioID = 0;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10)]
            // vpAmbient.Row   (Int32)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.Row = -1;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.Row = 11;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.MeasurementDepth_m = 1001.0D;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.CurrentSpeed_m_s = 11.0D;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.CurrentDirection_deg = 181.0D;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.AmbientSalinity_PSU = 41.0D;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.AmbientTemperature_C = 41.0D;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10000000)]
            // vpAmbient.BackgroundConcentration_MPN_100ml   (Int32)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.BackgroundConcentration_MPN_100ml = -1;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.BackgroundConcentration_MPN_100ml = 10000001;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.PollutantDecayRate_per_day = 101.0D;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.FarFieldCurrentSpeed_m_s = 11.0D;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.FarFieldCurrentDirection_deg = 181.0D;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

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
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.FarFieldDiffusionCoefficient = 2.0D;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            //Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // vpAmbient.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.LastUpdateDate_UTC = new DateTime();
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);
            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // vpAmbient.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.LastUpdateContactTVItemID = 0;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.LastUpdateContactTVItemID = 1;
            actionVPAmbient = await VPAmbientService.Post(vpAmbient);
            Assert.IsType<BadRequestObjectResult>(actionVPAmbient.Result);

        }
        #endregion Tests Generated Properties

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

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<VPAmbient> with skip and take
                var actionVPAmbientListSkipAndTake = await VPAmbientService.GetVPAmbientList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionVPAmbientListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionVPAmbientListSkipAndTake.Result).Value);
                List<VPAmbient> vpAmbientListSkipAndTake = (List<VPAmbient>)((OkObjectResult)actionVPAmbientListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<VPAmbient>)((OkObjectResult)actionVPAmbientListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(vpAmbientList[0].VPAmbientID == vpAmbientListSkipAndTake[0].VPAmbientID);
            }

            // Get VPAmbient With VPAmbientID
            var actionVPAmbientGet = await VPAmbientService.GetVPAmbientWithVPAmbientID(vpAmbientList[0].VPAmbientID);
            Assert.Equal(200, ((ObjectResult)actionVPAmbientGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPAmbientGet.Result).Value);
            VPAmbient vpAmbientGet = (VPAmbient)((OkObjectResult)actionVPAmbientGet.Result).Value;
            Assert.NotNull(vpAmbientGet);
            Assert.Equal(vpAmbientGet.VPAmbientID, vpAmbientList[0].VPAmbientID);

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
               .AddJsonFile("appsettings_csspservices.json")
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

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IVPAmbientService, VPAmbientService>();

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

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
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
