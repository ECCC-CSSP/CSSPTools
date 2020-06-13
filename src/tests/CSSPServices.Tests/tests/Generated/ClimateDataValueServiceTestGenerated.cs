/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
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
    public partial class ClimateDataValueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private IClimateDataValueService climateDataValueService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateDataValueServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ClimateDataValue_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               ClimateDataValue climateDataValue = GetFilledRandomClimateDataValue(""); 

               // List<ClimateDataValue>
               var actionClimateDataValueList = await climateDataValueService.GetClimateDataValueList();
               Assert.Equal(200, ((ObjectResult)actionClimateDataValueList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateDataValueList.Result).Value);
               List<ClimateDataValue> climateDataValueList = (List<ClimateDataValue>)((OkObjectResult)actionClimateDataValueList.Result).Value;

               int count = ((List<ClimateDataValue>)((OkObjectResult)actionClimateDataValueList.Result).Value).Count();
                Assert.True(count > 0);

               // Add ClimateDataValue
               var actionClimateDataValueAdded = await climateDataValueService.Add(climateDataValue);
               Assert.Equal(200, ((ObjectResult)actionClimateDataValueAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateDataValueAdded.Result).Value);
               ClimateDataValue climateDataValueAdded = (ClimateDataValue)((OkObjectResult)actionClimateDataValueAdded.Result).Value;
               Assert.NotNull(climateDataValueAdded);

               // Update ClimateDataValue
               var actionClimateDataValueUpdated = await climateDataValueService.Update(climateDataValue);
               Assert.Equal(200, ((ObjectResult)actionClimateDataValueUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateDataValueUpdated.Result).Value);
               ClimateDataValue climateDataValueUpdated = (ClimateDataValue)((OkObjectResult)actionClimateDataValueUpdated.Result).Value;
               Assert.NotNull(climateDataValueUpdated);

               // Delete ClimateDataValue
               var actionClimateDataValueDeleted = await climateDataValueService.Delete(climateDataValue.ClimateDataValueID);
               Assert.Equal(200, ((ObjectResult)actionClimateDataValueDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateDataValueDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionClimateDataValueDeleted.Result).Value;
               Assert.True(retBool);
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
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

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IClimateDataValueService, ClimateDataValueService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            climateDataValueService = Provider.GetService<IClimateDataValueService>();
            Assert.NotNull(climateDataValueService);

            return await Task.FromResult(true);
        }
        private ClimateDataValue GetFilledRandomClimateDataValue(string OmitPropName)
        {
            ClimateDataValue climateDataValue = new ClimateDataValue();

            if (OmitPropName != "ClimateSiteID") climateDataValue.ClimateSiteID = 1;
            if (OmitPropName != "DateTime_Local") climateDataValue.DateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Keep") climateDataValue.Keep = true;
            if (OmitPropName != "StorageDataType") climateDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "HasBeenRead") climateDataValue.HasBeenRead = true;
            if (OmitPropName != "Snow_cm") climateDataValue.Snow_cm = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "Rainfall_mm") climateDataValue.Rainfall_mm = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "RainfallEntered_mm") climateDataValue.RainfallEntered_mm = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "TotalPrecip_mm_cm") climateDataValue.TotalPrecip_mm_cm = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "MaxTemp_C") climateDataValue.MaxTemp_C = GetRandomDouble(-50.0D, 50.0D);
            if (OmitPropName != "MinTemp_C") climateDataValue.MinTemp_C = GetRandomDouble(-50.0D, 50.0D);
            if (OmitPropName != "HeatDegDays_C") climateDataValue.HeatDegDays_C = GetRandomDouble(-1000.0D, 100.0D);
            if (OmitPropName != "CoolDegDays_C") climateDataValue.CoolDegDays_C = GetRandomDouble(-1000.0D, 100.0D);
            if (OmitPropName != "SnowOnGround_cm") climateDataValue.SnowOnGround_cm = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "DirMaxGust_0North") climateDataValue.DirMaxGust_0North = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "SpdMaxGust_kmh") climateDataValue.SpdMaxGust_kmh = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "HourlyValues") climateDataValue.HourlyValues = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") climateDataValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") climateDataValue.LastUpdateContactTVItemID = 2;

            return climateDataValue;
        }
        #endregion Functions private
    }
}
