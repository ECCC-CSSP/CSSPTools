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
    public partial class ClimateSiteControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IClimateSiteService climateSiteService { get; set; }
        private IClimateSiteController climateSiteController { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateSiteControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ClimateSiteController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(climateSiteService);
            Assert.NotNull(climateSiteController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ClimateSiteController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionClimateSiteList = await climateSiteController.Get();
               Assert.Equal(200, ((ObjectResult)actionClimateSiteList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateSiteList.Result).Value);
               List<ClimateSite> climateSiteList = (List<ClimateSite>)(((OkObjectResult)actionClimateSiteList.Result).Value);

               int count = ((List<ClimateSite>)((OkObjectResult)actionClimateSiteList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(ClimateSiteID)
               var actionClimateSite = await climateSiteController.Get(climateSiteList[0].ClimateSiteID);
               Assert.Equal(200, ((ObjectResult)actionClimateSite.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateSite.Result).Value);
               ClimateSite climateSite = (ClimateSite)(((OkObjectResult)actionClimateSite.Result).Value);
               Assert.NotNull(climateSite);
               Assert.Equal(climateSiteList[0].ClimateSiteID, climateSite.ClimateSiteID);

               // testing Post(ClimateSite climateSite)
               climateSite.ClimateSiteID = 0;
               var actionClimateSiteNew = await climateSiteController.Post(climateSite);
               Assert.Equal(200, ((ObjectResult)actionClimateSiteNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateSiteNew.Result).Value);
               ClimateSite climateSiteNew = (ClimateSite)(((OkObjectResult)actionClimateSiteNew.Result).Value);
               Assert.NotNull(climateSiteNew);

               // testing Put(ClimateSite climateSite)
               var actionClimateSiteUpdate = await climateSiteController.Put(climateSiteNew);
               Assert.Equal(200, ((ObjectResult)actionClimateSiteUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateSiteUpdate.Result).Value);
               ClimateSite climateSiteUpdate = (ClimateSite)(((OkObjectResult)actionClimateSiteUpdate.Result).Value);
               Assert.NotNull(climateSiteUpdate);

               // testing Delete(ClimateSite climateSite)
               var actionClimateSiteDelete = await climateSiteController.Delete(climateSiteUpdate);
               Assert.Equal(200, ((ObjectResult)actionClimateSiteDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClimateSiteDelete.Result).Value);
               ClimateSite climateSiteDelete = (ClimateSite)(((OkObjectResult)actionClimateSiteDelete.Result).Value);
               Assert.NotNull(climateSiteDelete);
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
            Services.AddSingleton<IClimateSiteService, ClimateSiteService>();
            Services.AddSingleton<IClimateSiteController, ClimateSiteController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            climateSiteService = Provider.GetService<IClimateSiteService>();
            Assert.NotNull(climateSiteService);
        
            await climateSiteService.SetCulture(culture);
        
            climateSiteController = Provider.GetService<IClimateSiteController>();
            Assert.NotNull(climateSiteController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
