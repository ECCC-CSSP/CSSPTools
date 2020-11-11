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
    public partial class LocalVPScenarioDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalVPScenarioDBService LocalVPScenarioDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalVPScenario localVPScenario { get; set; }
        #endregion Properties

        #region Constructors
        public LocalVPScenarioDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalVPScenarioDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalVPScenarioDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localVPScenario = GetFilledRandomLocalVPScenario("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalVPScenario_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalVPScenarioList = await LocalVPScenarioDBService.GetLocalVPScenarioList();
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioList.Result).Value);
            List<LocalVPScenario> localVPScenarioList = (List<LocalVPScenario>)((OkObjectResult)actionLocalVPScenarioList.Result).Value;

            count = localVPScenarioList.Count();

            LocalVPScenario localVPScenario = GetFilledRandomLocalVPScenario("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localVPScenario.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localVPScenario.VPScenarioID   (Int32)
            // -----------------------------------

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.VPScenarioID = 0;

            actionLocalVPScenario = await LocalVPScenarioDBService.Put(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.VPScenarioID = 10000000;
            actionLocalVPScenario = await LocalVPScenarioDBService.Put(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
            // localVPScenario.InfrastructureTVItemID   (Int32)
            // -----------------------------------

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.InfrastructureTVItemID = 0;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.InfrastructureTVItemID = 1;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localVPScenario.VPScenarioStatus   (ScenarioStatusEnum)
            // -----------------------------------

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.VPScenarioStatus = (ScenarioStatusEnum)1000000;
             actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);


            // -----------------------------------
            // Is NOT Nullable
            // localVPScenario.UseAsBestEstimate   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // localVPScenario.EffluentFlow_m3_s   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [EffluentFlow_m3_s]

            //CSSPError: Type not implemented [EffluentFlow_m3_s]

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.EffluentFlow_m3_s = -1.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.EffluentFlow_m3_s = 1001.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10000000)]
            // localVPScenario.EffluentConcentration_MPN_100ml   (Int32)
            // -----------------------------------

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.EffluentConcentration_MPN_100ml = -1;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.EffluentConcentration_MPN_100ml = 10000001;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10000)]
            // localVPScenario.FroudeNumber   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [FroudeNumber]

            //CSSPError: Type not implemented [FroudeNumber]

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.FroudeNumber = -1.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.FroudeNumber = 10001.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 10)]
            // localVPScenario.PortDiameter_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [PortDiameter_m]

            //CSSPError: Type not implemented [PortDiameter_m]

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.PortDiameter_m = -1.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.PortDiameter_m = 11.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // localVPScenario.PortDepth_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [PortDepth_m]

            //CSSPError: Type not implemented [PortDepth_m]

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.PortDepth_m = -1.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.PortDepth_m = 1001.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // localVPScenario.PortElevation_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [PortElevation_m]

            //CSSPError: Type not implemented [PortElevation_m]

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.PortElevation_m = -1.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.PortElevation_m = 1001.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-90, 90)]
            // localVPScenario.VerticalAngle_deg   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [VerticalAngle_deg]

            //CSSPError: Type not implemented [VerticalAngle_deg]

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.VerticalAngle_deg = -91.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.VerticalAngle_deg = 91.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-180, 180)]
            // localVPScenario.HorizontalAngle_deg   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [HorizontalAngle_deg]

            //CSSPError: Type not implemented [HorizontalAngle_deg]

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.HorizontalAngle_deg = -181.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.HorizontalAngle_deg = 181.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(1, 100)]
            // localVPScenario.NumberOfPorts   (Int32)
            // -----------------------------------

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.NumberOfPorts = 0;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.NumberOfPorts = 101;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // localVPScenario.PortSpacing_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [PortSpacing_m]

            //CSSPError: Type not implemented [PortSpacing_m]

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.PortSpacing_m = -1.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.PortSpacing_m = 1001.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 100)]
            // localVPScenario.AcuteMixZone_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [AcuteMixZone_m]

            //CSSPError: Type not implemented [AcuteMixZone_m]

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.AcuteMixZone_m = -1.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.AcuteMixZone_m = 101.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 40000)]
            // localVPScenario.ChronicMixZone_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [ChronicMixZone_m]

            //CSSPError: Type not implemented [ChronicMixZone_m]

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.ChronicMixZone_m = -1.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.ChronicMixZone_m = 40001.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 40)]
            // localVPScenario.EffluentSalinity_PSU   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [EffluentSalinity_PSU]

            //CSSPError: Type not implemented [EffluentSalinity_PSU]

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.EffluentSalinity_PSU = -1.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.EffluentSalinity_PSU = 41.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-10, 40)]
            // localVPScenario.EffluentTemperature_C   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [EffluentTemperature_C]

            //CSSPError: Type not implemented [EffluentTemperature_C]

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.EffluentTemperature_C = -11.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.EffluentTemperature_C = 41.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 100)]
            // localVPScenario.EffluentVelocity_m_s   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [EffluentVelocity_m_s]

            //CSSPError: Type not implemented [EffluentVelocity_m_s]

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.EffluentVelocity_m_s = -1.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioService.GetLocalVPScenarioList().Count());
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.EffluentVelocity_m_s = 101.0D;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            //Assert.AreEqual(count, localVPScenarioDBService.GetLocalVPScenarioList().Count());

            // -----------------------------------
            // Is Nullable
            // localVPScenario.RawResults   (String)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localVPScenario.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.LastUpdateDate_UTC = new DateTime();
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);
            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localVPScenario.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.LastUpdateContactTVItemID = 0;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);

            localVPScenario = null;
            localVPScenario = GetFilledRandomLocalVPScenario("");
            localVPScenario.LastUpdateContactTVItemID = 1;
            actionLocalVPScenario = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenario.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalVPScenario
            var actionLocalVPScenarioAdded = await LocalVPScenarioDBService.Post(localVPScenario);
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioAdded.Result).Value);
            LocalVPScenario localVPScenarioAdded = (LocalVPScenario)((OkObjectResult)actionLocalVPScenarioAdded.Result).Value;
            Assert.NotNull(localVPScenarioAdded);

            // List<LocalVPScenario>
            var actionLocalVPScenarioList = await LocalVPScenarioDBService.GetLocalVPScenarioList();
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioList.Result).Value);
            List<LocalVPScenario> localVPScenarioList = (List<LocalVPScenario>)((OkObjectResult)actionLocalVPScenarioList.Result).Value;

            int count = ((List<LocalVPScenario>)((OkObjectResult)actionLocalVPScenarioList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalVPScenario> with skip and take
            var actionLocalVPScenarioListSkipAndTake = await LocalVPScenarioDBService.GetLocalVPScenarioList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioListSkipAndTake.Result).Value);
            List<LocalVPScenario> localVPScenarioListSkipAndTake = (List<LocalVPScenario>)((OkObjectResult)actionLocalVPScenarioListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalVPScenario>)((OkObjectResult)actionLocalVPScenarioListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localVPScenarioList[0].VPScenarioID == localVPScenarioListSkipAndTake[0].VPScenarioID);

            // Get LocalVPScenario With VPScenarioID
            var actionLocalVPScenarioGet = await LocalVPScenarioDBService.GetLocalVPScenarioWithVPScenarioID(localVPScenarioList[0].VPScenarioID);
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioGet.Result).Value);
            LocalVPScenario localVPScenarioGet = (LocalVPScenario)((OkObjectResult)actionLocalVPScenarioGet.Result).Value;
            Assert.NotNull(localVPScenarioGet);
            Assert.Equal(localVPScenarioGet.VPScenarioID, localVPScenarioList[0].VPScenarioID);

            // Put LocalVPScenario
            var actionLocalVPScenarioUpdated = await LocalVPScenarioDBService.Put(localVPScenario);
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioUpdated.Result).Value);
            LocalVPScenario localVPScenarioUpdated = (LocalVPScenario)((OkObjectResult)actionLocalVPScenarioUpdated.Result).Value;
            Assert.NotNull(localVPScenarioUpdated);

            // Delete LocalVPScenario
            var actionLocalVPScenarioDeleted = await LocalVPScenarioDBService.Delete(localVPScenario.VPScenarioID);
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalVPScenarioDeleted.Result).Value;
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
            Services.AddSingleton<ILocalVPScenarioDBService, LocalVPScenarioDBService>();

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

            LocalVPScenarioDBService = Provider.GetService<ILocalVPScenarioDBService>();
            Assert.NotNull(LocalVPScenarioDBService);

            return await Task.FromResult(true);
        }
        private LocalVPScenario GetFilledRandomLocalVPScenario(string OmitPropName)
        {
            LocalVPScenario localVPScenario = new LocalVPScenario();

            if (OmitPropName != "LocalDBCommand") localVPScenario.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "InfrastructureTVItemID") localVPScenario.InfrastructureTVItemID = 41;
            if (OmitPropName != "VPScenarioStatus") localVPScenario.VPScenarioStatus = (ScenarioStatusEnum)GetRandomEnumType(typeof(ScenarioStatusEnum));
            if (OmitPropName != "UseAsBestEstimate") localVPScenario.UseAsBestEstimate = true;
            if (OmitPropName != "EffluentFlow_m3_s") localVPScenario.EffluentFlow_m3_s = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "EffluentConcentration_MPN_100ml") localVPScenario.EffluentConcentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "FroudeNumber") localVPScenario.FroudeNumber = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "PortDiameter_m") localVPScenario.PortDiameter_m = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "PortDepth_m") localVPScenario.PortDepth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "PortElevation_m") localVPScenario.PortElevation_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "VerticalAngle_deg") localVPScenario.VerticalAngle_deg = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "HorizontalAngle_deg") localVPScenario.HorizontalAngle_deg = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "NumberOfPorts") localVPScenario.NumberOfPorts = GetRandomInt(1, 100);
            if (OmitPropName != "PortSpacing_m") localVPScenario.PortSpacing_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "AcuteMixZone_m") localVPScenario.AcuteMixZone_m = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "ChronicMixZone_m") localVPScenario.ChronicMixZone_m = GetRandomDouble(0.0D, 40000.0D);
            if (OmitPropName != "EffluentSalinity_PSU") localVPScenario.EffluentSalinity_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "EffluentTemperature_C") localVPScenario.EffluentTemperature_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "EffluentVelocity_m_s") localVPScenario.EffluentVelocity_m_s = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "RawResults") localVPScenario.RawResults = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") localVPScenario.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localVPScenario.LastUpdateContactTVItemID = 2;



            return localVPScenario;
        }
        private void CheckLocalVPScenarioFields(List<LocalVPScenario> localVPScenarioList)
        {
            if (localVPScenarioList[0].EffluentFlow_m3_s != null)
            {
                Assert.NotNull(localVPScenarioList[0].EffluentFlow_m3_s);
            }
            if (localVPScenarioList[0].EffluentConcentration_MPN_100ml != null)
            {
                Assert.NotNull(localVPScenarioList[0].EffluentConcentration_MPN_100ml);
            }
            if (localVPScenarioList[0].FroudeNumber != null)
            {
                Assert.NotNull(localVPScenarioList[0].FroudeNumber);
            }
            if (localVPScenarioList[0].PortDiameter_m != null)
            {
                Assert.NotNull(localVPScenarioList[0].PortDiameter_m);
            }
            if (localVPScenarioList[0].PortDepth_m != null)
            {
                Assert.NotNull(localVPScenarioList[0].PortDepth_m);
            }
            if (localVPScenarioList[0].PortElevation_m != null)
            {
                Assert.NotNull(localVPScenarioList[0].PortElevation_m);
            }
            if (localVPScenarioList[0].VerticalAngle_deg != null)
            {
                Assert.NotNull(localVPScenarioList[0].VerticalAngle_deg);
            }
            if (localVPScenarioList[0].HorizontalAngle_deg != null)
            {
                Assert.NotNull(localVPScenarioList[0].HorizontalAngle_deg);
            }
            if (localVPScenarioList[0].NumberOfPorts != null)
            {
                Assert.NotNull(localVPScenarioList[0].NumberOfPorts);
            }
            if (localVPScenarioList[0].PortSpacing_m != null)
            {
                Assert.NotNull(localVPScenarioList[0].PortSpacing_m);
            }
            if (localVPScenarioList[0].AcuteMixZone_m != null)
            {
                Assert.NotNull(localVPScenarioList[0].AcuteMixZone_m);
            }
            if (localVPScenarioList[0].ChronicMixZone_m != null)
            {
                Assert.NotNull(localVPScenarioList[0].ChronicMixZone_m);
            }
            if (localVPScenarioList[0].EffluentSalinity_PSU != null)
            {
                Assert.NotNull(localVPScenarioList[0].EffluentSalinity_PSU);
            }
            if (localVPScenarioList[0].EffluentTemperature_C != null)
            {
                Assert.NotNull(localVPScenarioList[0].EffluentTemperature_C);
            }
            if (localVPScenarioList[0].EffluentVelocity_m_s != null)
            {
                Assert.NotNull(localVPScenarioList[0].EffluentVelocity_m_s);
            }
            if (!string.IsNullOrWhiteSpace(localVPScenarioList[0].RawResults))
            {
                Assert.False(string.IsNullOrWhiteSpace(localVPScenarioList[0].RawResults));
            }
        }

        #endregion Functions private
    }
}
