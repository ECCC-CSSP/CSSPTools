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
    public partial class MikeScenarioControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMikeScenarioService mikeScenarioService { get; set; }
        private IMikeScenarioController mikeScenarioController { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeScenarioController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mikeScenarioService);
            Assert.NotNull(mikeScenarioController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeScenarioController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMikeScenarioList = await mikeScenarioController.Get();
               Assert.Equal(200, ((ObjectResult)actionMikeScenarioList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeScenarioList.Result).Value);
               List<MikeScenario> mikeScenarioList = (List<MikeScenario>)(((OkObjectResult)actionMikeScenarioList.Result).Value);

               int count = ((List<MikeScenario>)((OkObjectResult)actionMikeScenarioList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MikeScenarioID)
               var actionMikeScenario = await mikeScenarioController.Get(mikeScenarioList[0].MikeScenarioID);
               Assert.Equal(200, ((ObjectResult)actionMikeScenario.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeScenario.Result).Value);
               MikeScenario mikeScenario = (MikeScenario)(((OkObjectResult)actionMikeScenario.Result).Value);
               Assert.NotNull(mikeScenario);
               Assert.Equal(mikeScenarioList[0].MikeScenarioID, mikeScenario.MikeScenarioID);

               // testing Post(MikeScenario mikeScenario)
               mikeScenario.MikeScenarioID = 0;
               var actionMikeScenarioNew = await mikeScenarioController.Post(mikeScenario);
               Assert.Equal(200, ((ObjectResult)actionMikeScenarioNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeScenarioNew.Result).Value);
               MikeScenario mikeScenarioNew = (MikeScenario)(((OkObjectResult)actionMikeScenarioNew.Result).Value);
               Assert.NotNull(mikeScenarioNew);

               // testing Put(MikeScenario mikeScenario)
               var actionMikeScenarioUpdate = await mikeScenarioController.Put(mikeScenarioNew);
               Assert.Equal(200, ((ObjectResult)actionMikeScenarioUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeScenarioUpdate.Result).Value);
               MikeScenario mikeScenarioUpdate = (MikeScenario)(((OkObjectResult)actionMikeScenarioUpdate.Result).Value);
               Assert.NotNull(mikeScenarioUpdate);

               // testing Delete(MikeScenario mikeScenario)
               var actionMikeScenarioDelete = await mikeScenarioController.Delete(mikeScenarioUpdate);
               Assert.Equal(200, ((ObjectResult)actionMikeScenarioDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeScenarioDelete.Result).Value);
               MikeScenario mikeScenarioDelete = (MikeScenario)(((OkObjectResult)actionMikeScenarioDelete.Result).Value);
               Assert.NotNull(mikeScenarioDelete);
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
            Services.AddSingleton<IMikeScenarioService, MikeScenarioService>();
            Services.AddSingleton<IMikeScenarioController, MikeScenarioController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mikeScenarioService = Provider.GetService<IMikeScenarioService>();
            Assert.NotNull(mikeScenarioService);
        
            await mikeScenarioService.SetCulture(culture);
        
            mikeScenarioController = Provider.GetService<IMikeScenarioController>();
            Assert.NotNull(mikeScenarioController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
