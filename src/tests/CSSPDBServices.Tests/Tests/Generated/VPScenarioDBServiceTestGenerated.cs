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

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class VPScenarioDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IVPScenarioDBService VPScenarioDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBContext dbIM { get; set; }
        private VPScenario vpScenario { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task VPScenarioDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task VPScenarioDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            vpScenario = GetFilledRandomVPScenario("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task VPScenario_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionVPScenarioList = await VPScenarioDBService.GetVPScenarioList();
            Assert.Equal(200, ((ObjectResult)actionVPScenarioList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPScenarioList.Result).Value);
            List<VPScenario> vpScenarioList = (List<VPScenario>)((OkObjectResult)actionVPScenarioList.Result).Value;

            count = vpScenarioList.Count();

            VPScenario vpScenario = GetFilledRandomVPScenario("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // vpScenario.VPScenarioID   (Int32)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.VPScenarioID = 0;

            var actionVPScenario = await VPScenarioDBService.Put(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.VPScenarioID = 10000000;
            actionVPScenario = await VPScenarioDBService.Put(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // vpScenario.DBCommand   (DBCommandEnum)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.DBCommand = (DBCommandEnum)1000000;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
            // vpScenario.InfrastructureTVItemID   (Int32)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.InfrastructureTVItemID = 0;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.InfrastructureTVItemID = 1;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // vpScenario.VPScenarioStatus   (ScenarioStatusEnum)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.VPScenarioStatus = (ScenarioStatusEnum)1000000;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);


            // -----------------------------------
            // Is NOT Nullable
            // vpScenario.UseAsBestEstimate   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // vpScenario.EffluentFlow_m3_s   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [EffluentFlow_m3_s]

            //CSSPError: Type not implemented [EffluentFlow_m3_s]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentFlow_m3_s = -1.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentFlow_m3_s = 1001.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10000000)]
            // vpScenario.EffluentConcentration_MPN_100ml   (Int32)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentConcentration_MPN_100ml = -1;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentConcentration_MPN_100ml = 10000001;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10000)]
            // vpScenario.FroudeNumber   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [FroudeNumber]

            //CSSPError: Type not implemented [FroudeNumber]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.FroudeNumber = -1.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.FroudeNumber = 10001.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10)]
            // vpScenario.PortDiameter_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [PortDiameter_m]

            //CSSPError: Type not implemented [PortDiameter_m]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortDiameter_m = -1.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortDiameter_m = 11.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // vpScenario.PortDepth_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [PortDepth_m]

            //CSSPError: Type not implemented [PortDepth_m]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortDepth_m = -1.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortDepth_m = 1001.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // vpScenario.PortElevation_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [PortElevation_m]

            //CSSPError: Type not implemented [PortElevation_m]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortElevation_m = -1.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortElevation_m = 1001.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-90, 90)]
            // vpScenario.VerticalAngle_deg   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [VerticalAngle_deg]

            //CSSPError: Type not implemented [VerticalAngle_deg]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.VerticalAngle_deg = -91.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.VerticalAngle_deg = 91.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-180, 180)]
            // vpScenario.HorizontalAngle_deg   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [HorizontalAngle_deg]

            //CSSPError: Type not implemented [HorizontalAngle_deg]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.HorizontalAngle_deg = -181.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.HorizontalAngle_deg = 181.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(1, 100)]
            // vpScenario.NumberOfPorts   (Int32)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.NumberOfPorts = 0;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.NumberOfPorts = 101;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // vpScenario.PortSpacing_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [PortSpacing_m]

            //CSSPError: Type not implemented [PortSpacing_m]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortSpacing_m = -1.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortSpacing_m = 1001.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 100)]
            // vpScenario.AcuteMixZone_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [AcuteMixZone_m]

            //CSSPError: Type not implemented [AcuteMixZone_m]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.AcuteMixZone_m = -1.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.AcuteMixZone_m = 101.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 40000)]
            // vpScenario.ChronicMixZone_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [ChronicMixZone_m]

            //CSSPError: Type not implemented [ChronicMixZone_m]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.ChronicMixZone_m = -1.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.ChronicMixZone_m = 40001.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 40)]
            // vpScenario.EffluentSalinity_PSU   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [EffluentSalinity_PSU]

            //CSSPError: Type not implemented [EffluentSalinity_PSU]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentSalinity_PSU = -1.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentSalinity_PSU = 41.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-10, 40)]
            // vpScenario.EffluentTemperature_C   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [EffluentTemperature_C]

            //CSSPError: Type not implemented [EffluentTemperature_C]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentTemperature_C = -11.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentTemperature_C = 41.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 100)]
            // vpScenario.EffluentVelocity_m_s   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [EffluentVelocity_m_s]

            //CSSPError: Type not implemented [EffluentVelocity_m_s]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentVelocity_m_s = -1.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentVelocity_m_s = 101.0D;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            //Assert.AreEqual(count, vpScenarioDBService.GetVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // vpScenario.RawResults   (String)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // vpScenario.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.LastUpdateDate_UTC = new DateTime();
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // vpScenario.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.LastUpdateContactTVItemID = 0;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.LastUpdateContactTVItemID = 1;
            actionVPScenario = await VPScenarioDBService.Post(vpScenario);
            Assert.IsType<BadRequestObjectResult>(actionVPScenario.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post VPScenario
            var actionVPScenarioAdded = await VPScenarioDBService.Post(vpScenario);
            Assert.Equal(200, ((ObjectResult)actionVPScenarioAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPScenarioAdded.Result).Value);
            VPScenario vpScenarioAdded = (VPScenario)((OkObjectResult)actionVPScenarioAdded.Result).Value;
            Assert.NotNull(vpScenarioAdded);

            // List<VPScenario>
            var actionVPScenarioList = await VPScenarioDBService.GetVPScenarioList();
            Assert.Equal(200, ((ObjectResult)actionVPScenarioList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPScenarioList.Result).Value);
            List<VPScenario> vpScenarioList = (List<VPScenario>)((OkObjectResult)actionVPScenarioList.Result).Value;

            int count = ((List<VPScenario>)((OkObjectResult)actionVPScenarioList.Result).Value).Count();
            Assert.True(count > 0);

            // List<VPScenario> with skip and take
            var actionVPScenarioListSkipAndTake = await VPScenarioDBService.GetVPScenarioList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionVPScenarioListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPScenarioListSkipAndTake.Result).Value);
            List<VPScenario> vpScenarioListSkipAndTake = (List<VPScenario>)((OkObjectResult)actionVPScenarioListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<VPScenario>)((OkObjectResult)actionVPScenarioListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(vpScenarioList[0].VPScenarioID == vpScenarioListSkipAndTake[0].VPScenarioID);

            // Get VPScenario With VPScenarioID
            var actionVPScenarioGet = await VPScenarioDBService.GetVPScenarioWithVPScenarioID(vpScenarioList[0].VPScenarioID);
            Assert.Equal(200, ((ObjectResult)actionVPScenarioGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPScenarioGet.Result).Value);
            VPScenario vpScenarioGet = (VPScenario)((OkObjectResult)actionVPScenarioGet.Result).Value;
            Assert.NotNull(vpScenarioGet);
            Assert.Equal(vpScenarioGet.VPScenarioID, vpScenarioList[0].VPScenarioID);

            // Put VPScenario
            var actionVPScenarioUpdated = await VPScenarioDBService.Put(vpScenario);
            Assert.Equal(200, ((ObjectResult)actionVPScenarioUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPScenarioUpdated.Result).Value);
            VPScenario vpScenarioUpdated = (VPScenario)((OkObjectResult)actionVPScenarioUpdated.Result).Value;
            Assert.NotNull(vpScenarioUpdated);

            // Delete VPScenario
            var actionVPScenarioDeleted = await VPScenarioDBService.Delete(vpScenario.VPScenarioID);
            Assert.Equal(200, ((ObjectResult)actionVPScenarioDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionVPScenarioDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionVPScenarioDeleted.Result).Value;
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
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IVPScenarioDBService, VPScenarioDBService>();

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

            VPScenarioDBService = Provider.GetService<IVPScenarioDBService>();
            Assert.NotNull(VPScenarioDBService);

            return await Task.FromResult(true);
        }
        private VPScenario GetFilledRandomVPScenario(string OmitPropName)
        {
            VPScenario vpScenario = new VPScenario();

            if (OmitPropName != "DBCommand") vpScenario.DBCommand = (DBCommandEnum)GetRandomEnumType(typeof(DBCommandEnum));
            if (OmitPropName != "InfrastructureTVItemID") vpScenario.InfrastructureTVItemID = 41;
            if (OmitPropName != "VPScenarioStatus") vpScenario.VPScenarioStatus = (ScenarioStatusEnum)GetRandomEnumType(typeof(ScenarioStatusEnum));
            if (OmitPropName != "UseAsBestEstimate") vpScenario.UseAsBestEstimate = true;
            if (OmitPropName != "EffluentFlow_m3_s") vpScenario.EffluentFlow_m3_s = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "EffluentConcentration_MPN_100ml") vpScenario.EffluentConcentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "FroudeNumber") vpScenario.FroudeNumber = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "PortDiameter_m") vpScenario.PortDiameter_m = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "PortDepth_m") vpScenario.PortDepth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "PortElevation_m") vpScenario.PortElevation_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "VerticalAngle_deg") vpScenario.VerticalAngle_deg = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "HorizontalAngle_deg") vpScenario.HorizontalAngle_deg = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "NumberOfPorts") vpScenario.NumberOfPorts = GetRandomInt(1, 100);
            if (OmitPropName != "PortSpacing_m") vpScenario.PortSpacing_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "AcuteMixZone_m") vpScenario.AcuteMixZone_m = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "ChronicMixZone_m") vpScenario.ChronicMixZone_m = GetRandomDouble(0.0D, 40000.0D);
            if (OmitPropName != "EffluentSalinity_PSU") vpScenario.EffluentSalinity_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "EffluentTemperature_C") vpScenario.EffluentTemperature_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "EffluentVelocity_m_s") vpScenario.EffluentVelocity_m_s = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "RawResults") vpScenario.RawResults = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") vpScenario.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") vpScenario.LastUpdateContactTVItemID = 2;

            return vpScenario;
        }
        private void CheckVPScenarioFields(List<VPScenario> vpScenarioList)
        {
            if (vpScenarioList[0].EffluentFlow_m3_s != null)
            {
                Assert.NotNull(vpScenarioList[0].EffluentFlow_m3_s);
            }
            if (vpScenarioList[0].EffluentConcentration_MPN_100ml != null)
            {
                Assert.NotNull(vpScenarioList[0].EffluentConcentration_MPN_100ml);
            }
            if (vpScenarioList[0].FroudeNumber != null)
            {
                Assert.NotNull(vpScenarioList[0].FroudeNumber);
            }
            if (vpScenarioList[0].PortDiameter_m != null)
            {
                Assert.NotNull(vpScenarioList[0].PortDiameter_m);
            }
            if (vpScenarioList[0].PortDepth_m != null)
            {
                Assert.NotNull(vpScenarioList[0].PortDepth_m);
            }
            if (vpScenarioList[0].PortElevation_m != null)
            {
                Assert.NotNull(vpScenarioList[0].PortElevation_m);
            }
            if (vpScenarioList[0].VerticalAngle_deg != null)
            {
                Assert.NotNull(vpScenarioList[0].VerticalAngle_deg);
            }
            if (vpScenarioList[0].HorizontalAngle_deg != null)
            {
                Assert.NotNull(vpScenarioList[0].HorizontalAngle_deg);
            }
            if (vpScenarioList[0].NumberOfPorts != null)
            {
                Assert.NotNull(vpScenarioList[0].NumberOfPorts);
            }
            if (vpScenarioList[0].PortSpacing_m != null)
            {
                Assert.NotNull(vpScenarioList[0].PortSpacing_m);
            }
            if (vpScenarioList[0].AcuteMixZone_m != null)
            {
                Assert.NotNull(vpScenarioList[0].AcuteMixZone_m);
            }
            if (vpScenarioList[0].ChronicMixZone_m != null)
            {
                Assert.NotNull(vpScenarioList[0].ChronicMixZone_m);
            }
            if (vpScenarioList[0].EffluentSalinity_PSU != null)
            {
                Assert.NotNull(vpScenarioList[0].EffluentSalinity_PSU);
            }
            if (vpScenarioList[0].EffluentTemperature_C != null)
            {
                Assert.NotNull(vpScenarioList[0].EffluentTemperature_C);
            }
            if (vpScenarioList[0].EffluentVelocity_m_s != null)
            {
                Assert.NotNull(vpScenarioList[0].EffluentVelocity_m_s);
            }
            if (!string.IsNullOrWhiteSpace(vpScenarioList[0].RawResults))
            {
                Assert.False(string.IsNullOrWhiteSpace(vpScenarioList[0].RawResults));
            }
        }

        #endregion Functions private
    }
}
