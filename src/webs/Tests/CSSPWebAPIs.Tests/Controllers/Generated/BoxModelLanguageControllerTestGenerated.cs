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
    public partial class BoxModelLanguageControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IBoxModelLanguageService boxModelLanguageService { get; set; }
        private IBoxModelLanguageController boxModelLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task BoxModelLanguageController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(boxModelLanguageService);
            Assert.NotNull(boxModelLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task BoxModelLanguageController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionBoxModelLanguageList = await boxModelLanguageController.Get();
               Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelLanguageList.Result).Value);
               List<BoxModelLanguage> boxModelLanguageList = (List<BoxModelLanguage>)(((OkObjectResult)actionBoxModelLanguageList.Result).Value);

               int count = ((List<BoxModelLanguage>)((OkObjectResult)actionBoxModelLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(BoxModelLanguageID)
               var actionBoxModelLanguage = await boxModelLanguageController.Get(boxModelLanguageList[0].BoxModelLanguageID);
               Assert.Equal(200, ((ObjectResult)actionBoxModelLanguage.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelLanguage.Result).Value);
               BoxModelLanguage boxModelLanguage = (BoxModelLanguage)(((OkObjectResult)actionBoxModelLanguage.Result).Value);
               Assert.NotNull(boxModelLanguage);
               Assert.Equal(boxModelLanguageList[0].BoxModelLanguageID, boxModelLanguage.BoxModelLanguageID);

               // testing Post(BoxModelLanguage boxModelLanguage)
               boxModelLanguage.BoxModelLanguageID = 0;
               var actionBoxModelLanguageNew = await boxModelLanguageController.Post(boxModelLanguage);
               Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelLanguageNew.Result).Value);
               BoxModelLanguage boxModelLanguageNew = (BoxModelLanguage)(((OkObjectResult)actionBoxModelLanguageNew.Result).Value);
               Assert.NotNull(boxModelLanguageNew);

               // testing Put(BoxModelLanguage boxModelLanguage)
               var actionBoxModelLanguageUpdate = await boxModelLanguageController.Put(boxModelLanguageNew);
               Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelLanguageUpdate.Result).Value);
               BoxModelLanguage boxModelLanguageUpdate = (BoxModelLanguage)(((OkObjectResult)actionBoxModelLanguageUpdate.Result).Value);
               Assert.NotNull(boxModelLanguageUpdate);

               // testing Delete(BoxModelLanguage boxModelLanguage)
               var actionBoxModelLanguageDelete = await boxModelLanguageController.Delete(boxModelLanguageUpdate);
               Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelLanguageDelete.Result).Value);
               BoxModelLanguage boxModelLanguageDelete = (BoxModelLanguage)(((OkObjectResult)actionBoxModelLanguageDelete.Result).Value);
               Assert.NotNull(boxModelLanguageDelete);
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
            Services.AddSingleton<IBoxModelLanguageService, BoxModelLanguageService>();
            Services.AddSingleton<IBoxModelLanguageController, BoxModelLanguageController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            boxModelLanguageService = Provider.GetService<IBoxModelLanguageService>();
            Assert.NotNull(boxModelLanguageService);
        
            await boxModelLanguageService.SetCulture(culture);
        
            boxModelLanguageController = Provider.GetService<IBoxModelLanguageController>();
            Assert.NotNull(boxModelLanguageController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
