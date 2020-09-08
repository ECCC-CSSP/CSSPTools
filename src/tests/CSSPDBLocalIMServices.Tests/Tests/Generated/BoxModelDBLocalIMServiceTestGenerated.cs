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
    public partial class BoxModelDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IBoxModelDBLocalIMService BoxModelDBLocalIMService { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private BoxModel boxModel { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocalIM]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task BoxModelDBLocalIM_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            boxModel = GetFilledRandomBoxModel("");

            await DoCRUDDBLocalIMTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task BoxModel_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionBoxModelList = await BoxModelDBLocalIMService.GetBoxModelList();
            Assert.Equal(200, ((ObjectResult)actionBoxModelList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelList.Result).Value);
            List<BoxModel> boxModelList = (List<BoxModel>)((OkObjectResult)actionBoxModelList.Result).Value;

            count = boxModelList.Count();

            BoxModel boxModel = GetFilledRandomBoxModel("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // boxModel.BoxModelID   (Int32)
            // -----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.BoxModelID = 0;

            var actionBoxModel = await BoxModelDBLocalIMService.Put(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.BoxModelID = 10000000;
            actionBoxModel = await BoxModelDBLocalIMService.Put(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
            // boxModel.InfrastructureTVItemID   (Int32)
            // -----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.InfrastructureTVItemID = 0;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.InfrastructureTVItemID = 1;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000)]
            // boxModel.Discharge_m3_day   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Discharge_m3_day]

            //CSSPError: Type not implemented [Discharge_m3_day]

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.Discharge_m3_day = -1.0D;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.Discharge_m3_day = 10001.0D;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelDBLocalIMService.GetBoxModelList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // boxModel.Depth_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Depth_m]

            //CSSPError: Type not implemented [Depth_m]

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.Depth_m = -1.0D;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.Depth_m = 1001.0D;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelDBLocalIMService.GetBoxModelList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-15, 40)]
            // boxModel.Temperature_C   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Temperature_C]

            //CSSPError: Type not implemented [Temperature_C]

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.Temperature_C = -16.0D;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.Temperature_C = 41.0D;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelDBLocalIMService.GetBoxModelList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // boxModel.Dilution   (Int32)
            // -----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.Dilution = -1;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.Dilution = 10000001;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelDBLocalIMService.GetBoxModelList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100)]
            // boxModel.DecayRate_per_day   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [DecayRate_per_day]

            //CSSPError: Type not implemented [DecayRate_per_day]

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.DecayRate_per_day = -1.0D;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.DecayRate_per_day = 101.0D;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelDBLocalIMService.GetBoxModelList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // boxModel.FCUntreated_MPN_100ml   (Int32)
            // -----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.FCUntreated_MPN_100ml = -1;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.FCUntreated_MPN_100ml = 10000001;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelDBLocalIMService.GetBoxModelList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // boxModel.FCPreDisinfection_MPN_100ml   (Int32)
            // -----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.FCPreDisinfection_MPN_100ml = -1;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.FCPreDisinfection_MPN_100ml = 10000001;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelDBLocalIMService.GetBoxModelList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // boxModel.Concentration_MPN_100ml   (Int32)
            // -----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.Concentration_MPN_100ml = -1;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.Concentration_MPN_100ml = 10000001;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelDBLocalIMService.GetBoxModelList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, -1)]
            // boxModel.T90_hour   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [T90_hour]

            //CSSPError: Type not implemented [T90_hour]

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.T90_hour = -1.0D;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 24)]
            // boxModel.DischargeDuration_hour   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [DischargeDuration_hour]

            //CSSPError: Type not implemented [DischargeDuration_hour]

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.DischargeDuration_hour = -1.0D;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.DischargeDuration_hour = 25.0D;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            //Assert.AreEqual(count, boxModelDBLocalIMService.GetBoxModelList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // boxModel.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.LastUpdateDate_UTC = new DateTime();
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);
            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // boxModel.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.LastUpdateContactTVItemID = 0;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.LastUpdateContactTVItemID = 1;
            actionBoxModel = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.IsType<BadRequestObjectResult>(actionBoxModel.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalIMTest()
        {
            boxModel.BoxModelID = 10000000;

            // Post BoxModel
            var actionBoxModelAdded = await BoxModelDBLocalIMService.Post(boxModel);
            Assert.Equal(200, ((ObjectResult)actionBoxModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelAdded.Result).Value);
            BoxModel boxModelAdded = (BoxModel)((OkObjectResult)actionBoxModelAdded.Result).Value;
            Assert.NotNull(boxModelAdded);

            // List<BoxModel>
            var actionBoxModelList = await BoxModelDBLocalIMService.GetBoxModelList();
            Assert.Equal(200, ((ObjectResult)actionBoxModelList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelList.Result).Value);
            List<BoxModel> boxModelList = (List<BoxModel>)((OkObjectResult)actionBoxModelList.Result).Value;

            int count = ((List<BoxModel>)((OkObjectResult)actionBoxModelList.Result).Value).Count();
            Assert.True(count > 0);

            // Get BoxModel With BoxModelID
            var actionBoxModelGet = await BoxModelDBLocalIMService.GetBoxModelWithBoxModelID(boxModelList[0].BoxModelID);
            Assert.Equal(200, ((ObjectResult)actionBoxModelGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelGet.Result).Value);
            BoxModel boxModelGet = (BoxModel)((OkObjectResult)actionBoxModelGet.Result).Value;
            Assert.NotNull(boxModelGet);
            Assert.Equal(boxModelGet.BoxModelID, boxModelList[0].BoxModelID);

            // Put BoxModel
            var actionBoxModelUpdated = await BoxModelDBLocalIMService.Put(boxModel);
            Assert.Equal(200, ((ObjectResult)actionBoxModelUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelUpdated.Result).Value);
            BoxModel boxModelUpdated = (BoxModel)((OkObjectResult)actionBoxModelUpdated.Result).Value;
            Assert.NotNull(boxModelUpdated);

            // Delete BoxModel
            var actionBoxModelDeleted = await BoxModelDBLocalIMService.Delete(boxModel.BoxModelID);
            Assert.Equal(200, ((ObjectResult)actionBoxModelDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionBoxModelDeleted.Result).Value;
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
            Services.AddSingleton<IBoxModelDBLocalIMService, BoxModelDBLocalIMService>();

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

            BoxModelDBLocalIMService = Provider.GetService<IBoxModelDBLocalIMService>();
            Assert.NotNull(BoxModelDBLocalIMService);

            return await Task.FromResult(true);
        }
        private BoxModel GetFilledRandomBoxModel(string OmitPropName)
        {
            BoxModel boxModel = new BoxModel();

            if (OmitPropName != "InfrastructureTVItemID") boxModel.InfrastructureTVItemID = 41;
            if (OmitPropName != "Discharge_m3_day") boxModel.Discharge_m3_day = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "Depth_m") boxModel.Depth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "Temperature_C") boxModel.Temperature_C = GetRandomDouble(-15.0D, 40.0D);
            if (OmitPropName != "Dilution") boxModel.Dilution = GetRandomInt(0, 10000000);
            if (OmitPropName != "DecayRate_per_day") boxModel.DecayRate_per_day = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "FCUntreated_MPN_100ml") boxModel.FCUntreated_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "FCPreDisinfection_MPN_100ml") boxModel.FCPreDisinfection_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Concentration_MPN_100ml") boxModel.Concentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "T90_hour") boxModel.T90_hour = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "DischargeDuration_hour") boxModel.DischargeDuration_hour = GetRandomDouble(0.0D, 24.0D);
            if (OmitPropName != "LastUpdateDate_UTC") boxModel.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") boxModel.LastUpdateContactTVItemID = 2;



            return boxModel;
        }
        private void CheckBoxModelFields(List<BoxModel> boxModelList)
        {
        }

        #endregion Functions private
    }
}
