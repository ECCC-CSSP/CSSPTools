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
    public partial class RainExceedanceControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IRainExceedanceService rainExceedanceService { get; set; }
        private IRainExceedanceController rainExceedanceController { get; set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task RainExceedanceController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(rainExceedanceService);
            Assert.NotNull(rainExceedanceController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task RainExceedanceController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionRainExceedanceList = await rainExceedanceController.Get();
               Assert.Equal(200, ((ObjectResult)actionRainExceedanceList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionRainExceedanceList.Result).Value);
               List<RainExceedance> rainExceedanceList = (List<RainExceedance>)(((OkObjectResult)actionRainExceedanceList.Result).Value);

               int count = ((List<RainExceedance>)((OkObjectResult)actionRainExceedanceList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(RainExceedanceID)
               var actionRainExceedance = await rainExceedanceController.Get(rainExceedanceList[0].RainExceedanceID);
               Assert.Equal(200, ((ObjectResult)actionRainExceedance.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionRainExceedance.Result).Value);
               RainExceedance rainExceedance = (RainExceedance)(((OkObjectResult)actionRainExceedance.Result).Value);
               Assert.NotNull(rainExceedance);
               Assert.Equal(rainExceedanceList[0].RainExceedanceID, rainExceedance.RainExceedanceID);

               // testing Post(RainExceedance rainExceedance)
               rainExceedance.RainExceedanceID = 0;
               var actionRainExceedanceNew = await rainExceedanceController.Post(rainExceedance);
               Assert.Equal(200, ((ObjectResult)actionRainExceedanceNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionRainExceedanceNew.Result).Value);
               RainExceedance rainExceedanceNew = (RainExceedance)(((OkObjectResult)actionRainExceedanceNew.Result).Value);
               Assert.NotNull(rainExceedanceNew);

               // testing Put(RainExceedance rainExceedance)
               var actionRainExceedanceUpdate = await rainExceedanceController.Put(rainExceedanceNew);
               Assert.Equal(200, ((ObjectResult)actionRainExceedanceUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionRainExceedanceUpdate.Result).Value);
               RainExceedance rainExceedanceUpdate = (RainExceedance)(((OkObjectResult)actionRainExceedanceUpdate.Result).Value);
               Assert.NotNull(rainExceedanceUpdate);

               // testing Delete(RainExceedance rainExceedance)
               var actionRainExceedanceDelete = await rainExceedanceController.Delete(rainExceedanceUpdate);
               Assert.Equal(200, ((ObjectResult)actionRainExceedanceDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionRainExceedanceDelete.Result).Value);
               RainExceedance rainExceedanceDelete = (RainExceedance)(((OkObjectResult)actionRainExceedanceDelete.Result).Value);
               Assert.NotNull(rainExceedanceDelete);
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
            Services.AddSingleton<IRainExceedanceService, RainExceedanceService>();
            Services.AddSingleton<IRainExceedanceController, RainExceedanceController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            rainExceedanceService = Provider.GetService<IRainExceedanceService>();
            Assert.NotNull(rainExceedanceService);
        
            await rainExceedanceService.SetCulture(culture);
        
            rainExceedanceController = Provider.GetService<IRainExceedanceController>();
            Assert.NotNull(rainExceedanceController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
