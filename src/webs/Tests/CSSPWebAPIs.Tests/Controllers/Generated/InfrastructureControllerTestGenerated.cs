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
    public partial class InfrastructureControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IInfrastructureService infrastructureService { get; set; }
        private IInfrastructureController infrastructureController { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task InfrastructureController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(infrastructureService);
            Assert.NotNull(infrastructureController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task InfrastructureController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionInfrastructureList = await infrastructureController.Get();
               Assert.Equal(200, ((ObjectResult)actionInfrastructureList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionInfrastructureList.Result).Value);
               List<Infrastructure> infrastructureList = (List<Infrastructure>)(((OkObjectResult)actionInfrastructureList.Result).Value);

               int count = ((List<Infrastructure>)((OkObjectResult)actionInfrastructureList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(InfrastructureID)
               var actionInfrastructure = await infrastructureController.Get(infrastructureList[0].InfrastructureID);
               Assert.Equal(200, ((ObjectResult)actionInfrastructure.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionInfrastructure.Result).Value);
               Infrastructure infrastructure = (Infrastructure)(((OkObjectResult)actionInfrastructure.Result).Value);
               Assert.NotNull(infrastructure);
               Assert.Equal(infrastructureList[0].InfrastructureID, infrastructure.InfrastructureID);

               // testing Post(Infrastructure infrastructure)
               infrastructure.InfrastructureID = 0;
               var actionInfrastructureNew = await infrastructureController.Post(infrastructure);
               Assert.Equal(200, ((ObjectResult)actionInfrastructureNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionInfrastructureNew.Result).Value);
               Infrastructure infrastructureNew = (Infrastructure)(((OkObjectResult)actionInfrastructureNew.Result).Value);
               Assert.NotNull(infrastructureNew);

               // testing Put(Infrastructure infrastructure)
               var actionInfrastructureUpdate = await infrastructureController.Put(infrastructureNew);
               Assert.Equal(200, ((ObjectResult)actionInfrastructureUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionInfrastructureUpdate.Result).Value);
               Infrastructure infrastructureUpdate = (Infrastructure)(((OkObjectResult)actionInfrastructureUpdate.Result).Value);
               Assert.NotNull(infrastructureUpdate);

               // testing Delete(Infrastructure infrastructure)
               var actionInfrastructureDelete = await infrastructureController.Delete(infrastructureUpdate);
               Assert.Equal(200, ((ObjectResult)actionInfrastructureDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionInfrastructureDelete.Result).Value);
               Infrastructure infrastructureDelete = (Infrastructure)(((OkObjectResult)actionInfrastructureDelete.Result).Value);
               Assert.NotNull(infrastructureDelete);
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
            Services.AddSingleton<IInfrastructureService, InfrastructureService>();
            Services.AddSingleton<IInfrastructureController, InfrastructureController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            infrastructureService = Provider.GetService<IInfrastructureService>();
            Assert.NotNull(infrastructureService);
        
            await infrastructureService.SetCulture(culture);
        
            infrastructureController = Provider.GetService<IInfrastructureController>();
            Assert.NotNull(infrastructureController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
