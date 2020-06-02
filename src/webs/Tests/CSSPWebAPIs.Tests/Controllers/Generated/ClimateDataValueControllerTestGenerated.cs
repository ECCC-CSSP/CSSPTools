using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
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
using UserServices.Models;
using Xunit;

namespace CSSPWebAPIs.Tests.Controllers
{
    public partial class ClimateDataValueControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IClimateDataValueService climateDataValueService { get; set; }
        private IClimateDataValueController climateDataValueController { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateDataValueControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ClimateDataValueController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(climateDataValueService);
            Assert.NotNull(climateDataValueController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ClimateDataValueController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionClimateDataValueList = await climateDataValueController.Get();
               Assert.Equal(200, ((ObjectResult)actionClimateDataValueList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateDataValueList.Result).Value);
               List<ClimateDataValue> climateDataValueList = (List<ClimateDataValue>)(((OkObjectResult)actionClimateDataValueList.Result).Value);

               int count = ((List<ClimateDataValue>)((OkObjectResult)actionClimateDataValueList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(ClimateDataValueID)
               var actionClimateDataValue = await climateDataValueController.Get(climateDataValueList[0].ClimateDataValueID);
               Assert.Equal(200, ((ObjectResult)actionClimateDataValue.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateDataValue.Result).Value);
               ClimateDataValue climateDataValue = (ClimateDataValue)(((OkObjectResult)actionClimateDataValue.Result).Value);
               Assert.NotNull(climateDataValue);
               Assert.Equal(climateDataValueList[0].ClimateDataValueID, climateDataValue.ClimateDataValueID);

               // testing Post(ClimateDataValue climateDataValue)
               climateDataValue.ClimateDataValueID = 0;
               var actionClimateDataValueNew = await climateDataValueController.Post(climateDataValue);
               Assert.Equal(200, ((ObjectResult)actionClimateDataValueNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateDataValueNew.Result).Value);
               ClimateDataValue climateDataValueNew = (ClimateDataValue)(((OkObjectResult)actionClimateDataValueNew.Result).Value);
               Assert.NotNull(climateDataValueNew);

               // testing Put(ClimateDataValue climateDataValue)
               var actionClimateDataValueUpdate = await climateDataValueController.Put(climateDataValueNew);
               Assert.Equal(200, ((ObjectResult)actionClimateDataValueUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateDataValueUpdate.Result).Value);
               ClimateDataValue climateDataValueUpdate = (ClimateDataValue)(((OkObjectResult)actionClimateDataValueUpdate.Result).Value);
               Assert.NotNull(climateDataValueUpdate);

               // testing Delete(ClimateDataValue climateDataValue)
               var actionClimateDataValueDelete = await climateDataValueController.Delete(climateDataValueUpdate);
               Assert.Equal(200, ((ObjectResult)actionClimateDataValueDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateDataValueDelete.Result).Value);
               ClimateDataValue climateDataValueDelete = (ClimateDataValue)(((OkObjectResult)actionClimateDataValueDelete.Result).Value);
               Assert.NotNull(climateDataValueDelete);
            }
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();
        
            Services = new ServiceCollection();
        
            IConfigurationSection connectionStringsSection = Config.GetSection("ConnectionStrings");
            Services.Configure<ConnectionStringsModel>(connectionStringsSection);
        
            ConnectionStringsModel connectionStrings = connectionStringsSection.Get<ConnectionStringsModel>();
        
            Services.AddSingleton<IConfiguration>(Config);
        
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(connectionStrings.TestDB);
            });
        
            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionStrings.TestDB));
        
            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IClimateDataValueService, ClimateDataValueService>();
            Services.AddSingleton<IClimateDataValueController, ClimateDataValueController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            climateDataValueService = Provider.GetService<IClimateDataValueService>();
            Assert.NotNull(climateDataValueService);
        
            await climateDataValueService.SetCulture(culture);
        
            climateDataValueController = Provider.GetService<IClimateDataValueController>();
            Assert.NotNull(climateDataValueController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
