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
    public partial class VPScenarioControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IVPScenarioService vpScenarioService { get; set; }
        private IVPScenarioController vpScenarioController { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task VPScenarioController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(vpScenarioService);
            Assert.NotNull(vpScenarioController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task VPScenarioController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionVPScenarioList = await vpScenarioController.Get();
               Assert.Equal(200, ((ObjectResult)actionVPScenarioList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPScenarioList.Result).Value);
               List<VPScenario> vpScenarioList = (List<VPScenario>)(((OkObjectResult)actionVPScenarioList.Result).Value);

               int count = ((List<VPScenario>)((OkObjectResult)actionVPScenarioList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(VPScenarioID)
               var actionVPScenario = await vpScenarioController.Get(vpScenarioList[0].VPScenarioID);
               Assert.Equal(200, ((ObjectResult)actionVPScenario.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPScenario.Result).Value);
               VPScenario vpScenario = (VPScenario)(((OkObjectResult)actionVPScenario.Result).Value);
               Assert.NotNull(vpScenario);
               Assert.Equal(vpScenarioList[0].VPScenarioID, vpScenario.VPScenarioID);

               // testing Post(VPScenario vpScenario)
               vpScenario.VPScenarioID = 0;
               var actionVPScenarioNew = await vpScenarioController.Post(vpScenario);
               Assert.Equal(200, ((ObjectResult)actionVPScenarioNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPScenarioNew.Result).Value);
               VPScenario vpScenarioNew = (VPScenario)(((OkObjectResult)actionVPScenarioNew.Result).Value);
               Assert.NotNull(vpScenarioNew);

               // testing Put(VPScenario vpScenario)
               var actionVPScenarioUpdate = await vpScenarioController.Put(vpScenarioNew);
               Assert.Equal(200, ((ObjectResult)actionVPScenarioUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPScenarioUpdate.Result).Value);
               VPScenario vpScenarioUpdate = (VPScenario)(((OkObjectResult)actionVPScenarioUpdate.Result).Value);
               Assert.NotNull(vpScenarioUpdate);

               // testing Delete(VPScenario vpScenario)
               var actionVPScenarioDelete = await vpScenarioController.Delete(vpScenarioUpdate);
               Assert.Equal(200, ((ObjectResult)actionVPScenarioDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPScenarioDelete.Result).Value);
               VPScenario vpScenarioDelete = (VPScenario)(((OkObjectResult)actionVPScenarioDelete.Result).Value);
               Assert.NotNull(vpScenarioDelete);
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
            Services.AddSingleton<IVPScenarioService, VPScenarioService>();
            Services.AddSingleton<IVPScenarioController, VPScenarioController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            vpScenarioService = Provider.GetService<IVPScenarioService>();
            Assert.NotNull(vpScenarioService);
        
            await vpScenarioService.SetCulture(culture);
        
            vpScenarioController = Provider.GetService<IVPScenarioController>();
            Assert.NotNull(vpScenarioController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
