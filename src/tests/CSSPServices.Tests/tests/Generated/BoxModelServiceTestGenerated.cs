/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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
using Xunit;

namespace CSSPServices.Tests
{
    public partial class BoxModelServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IBoxModelService boxModelService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task BoxModel_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            BoxModel boxModel = GetFilledRandomBoxModel(""); 

            // List<BoxModel>
            var actionBoxModelList = await boxModelService.GetBoxModelList();
            Assert.Equal(200, ((ObjectResult)actionBoxModelList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelList.Result).Value);
            List<BoxModel> boxModelList = (List<BoxModel>)(((OkObjectResult)actionBoxModelList.Result).Value);

            int count = ((List<BoxModel>)((OkObjectResult)actionBoxModelList.Result).Value).Count();
            Assert.True(count > 0);

            // Add BoxModel
            var actionBoxModelAdded = await boxModelService.Add(boxModel);
            Assert.Equal(200, ((ObjectResult)actionBoxModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelAdded.Result).Value);
            BoxModel boxModelAdded = (BoxModel)(((OkObjectResult)actionBoxModelAdded.Result).Value);
            Assert.NotNull(boxModelAdded);

            // Update BoxModel
            var actionBoxModelUpdated = await boxModelService.Update(boxModel);
            Assert.Equal(200, ((ObjectResult)actionBoxModelUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelUpdated.Result).Value);
            BoxModel boxModelUpdated = (BoxModel)(((OkObjectResult)actionBoxModelUpdated.Result).Value);
            Assert.NotNull(boxModelUpdated);

            // Delete BoxModel
            var actionBoxModelDeleted = await boxModelService.Delete(boxModel);
            Assert.Equal(200, ((ObjectResult)actionBoxModelDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelDeleted.Result).Value);
            BoxModel boxModelDeleted = (BoxModel)(((OkObjectResult)actionBoxModelDeleted.Result).Value);
            Assert.NotNull(boxModelDeleted);
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();
        
            Services = new ServiceCollection();
        
            Services.AddSingleton<IConfiguration>(Config);
        
            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);
        
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });
        
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IBoxModelService, BoxModelService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            boxModelService = Provider.GetService<IBoxModelService>();
            Assert.NotNull(boxModelService);
        
            await boxModelService.SetCulture(culture);
        
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
        #endregion Functions private
    }
}
