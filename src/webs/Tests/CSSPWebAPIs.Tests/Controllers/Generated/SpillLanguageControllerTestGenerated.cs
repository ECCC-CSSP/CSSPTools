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
    public partial class SpillLanguageControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ISpillLanguageService spillLanguageService { get; set; }
        private ISpillLanguageController spillLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SpillLanguageController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(spillLanguageService);
            Assert.NotNull(spillLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SpillLanguageController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionSpillLanguageList = await spillLanguageController.Get();
               Assert.Equal(200, ((ObjectResult)actionSpillLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillLanguageList.Result).Value);
               List<SpillLanguage> spillLanguageList = (List<SpillLanguage>)(((OkObjectResult)actionSpillLanguageList.Result).Value);

               int count = ((List<SpillLanguage>)((OkObjectResult)actionSpillLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(SpillLanguageID)
               var actionSpillLanguage = await spillLanguageController.Get(spillLanguageList[0].SpillLanguageID);
               Assert.Equal(200, ((ObjectResult)actionSpillLanguage.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillLanguage.Result).Value);
               SpillLanguage spillLanguage = (SpillLanguage)(((OkObjectResult)actionSpillLanguage.Result).Value);
               Assert.NotNull(spillLanguage);
               Assert.Equal(spillLanguageList[0].SpillLanguageID, spillLanguage.SpillLanguageID);

               // testing Post(SpillLanguage spillLanguage)
               spillLanguage.SpillLanguageID = 0;
               var actionSpillLanguageNew = await spillLanguageController.Post(spillLanguage);
               Assert.Equal(200, ((ObjectResult)actionSpillLanguageNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillLanguageNew.Result).Value);
               SpillLanguage spillLanguageNew = (SpillLanguage)(((OkObjectResult)actionSpillLanguageNew.Result).Value);
               Assert.NotNull(spillLanguageNew);

               // testing Put(SpillLanguage spillLanguage)
               var actionSpillLanguageUpdate = await spillLanguageController.Put(spillLanguageNew);
               Assert.Equal(200, ((ObjectResult)actionSpillLanguageUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillLanguageUpdate.Result).Value);
               SpillLanguage spillLanguageUpdate = (SpillLanguage)(((OkObjectResult)actionSpillLanguageUpdate.Result).Value);
               Assert.NotNull(spillLanguageUpdate);

               // testing Delete(SpillLanguage spillLanguage)
               var actionSpillLanguageDelete = await spillLanguageController.Delete(spillLanguageUpdate);
               Assert.Equal(200, ((ObjectResult)actionSpillLanguageDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillLanguageDelete.Result).Value);
               SpillLanguage spillLanguageDelete = (SpillLanguage)(((OkObjectResult)actionSpillLanguageDelete.Result).Value);
               Assert.NotNull(spillLanguageDelete);
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
            Services.AddSingleton<ISpillLanguageService, SpillLanguageService>();
            Services.AddSingleton<ISpillLanguageController, SpillLanguageController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            spillLanguageService = Provider.GetService<ISpillLanguageService>();
            Assert.NotNull(spillLanguageService);
        
            await spillLanguageService.SetCulture(culture);
        
            spillLanguageController = Provider.GetService<ISpillLanguageController>();
            Assert.NotNull(spillLanguageController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
