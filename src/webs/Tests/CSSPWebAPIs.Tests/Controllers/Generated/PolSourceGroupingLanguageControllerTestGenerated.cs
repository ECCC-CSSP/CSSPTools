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
    public partial class PolSourceGroupingLanguageControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IPolSourceGroupingLanguageService polSourceGroupingLanguageService { get; set; }
        private IPolSourceGroupingLanguageController polSourceGroupingLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceGroupingLanguageController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(polSourceGroupingLanguageService);
            Assert.NotNull(polSourceGroupingLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceGroupingLanguageController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionPolSourceGroupingLanguageList = await polSourceGroupingLanguageController.Get();
               Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageList.Result).Value);
               List<PolSourceGroupingLanguage> polSourceGroupingLanguageList = (List<PolSourceGroupingLanguage>)(((OkObjectResult)actionPolSourceGroupingLanguageList.Result).Value);

               int count = ((List<PolSourceGroupingLanguage>)((OkObjectResult)actionPolSourceGroupingLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(PolSourceGroupingLanguageID)
               var actionPolSourceGroupingLanguage = await polSourceGroupingLanguageController.Get(polSourceGroupingLanguageList[0].PolSourceGroupingLanguageID);
               Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguage.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguage.Result).Value);
               PolSourceGroupingLanguage polSourceGroupingLanguage = (PolSourceGroupingLanguage)(((OkObjectResult)actionPolSourceGroupingLanguage.Result).Value);
               Assert.NotNull(polSourceGroupingLanguage);
               Assert.Equal(polSourceGroupingLanguageList[0].PolSourceGroupingLanguageID, polSourceGroupingLanguage.PolSourceGroupingLanguageID);

               // testing Post(PolSourceGroupingLanguage polSourceGroupingLanguage)
               polSourceGroupingLanguage.PolSourceGroupingLanguageID = 0;
               var actionPolSourceGroupingLanguageNew = await polSourceGroupingLanguageController.Post(polSourceGroupingLanguage);
               Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageNew.Result).Value);
               PolSourceGroupingLanguage polSourceGroupingLanguageNew = (PolSourceGroupingLanguage)(((OkObjectResult)actionPolSourceGroupingLanguageNew.Result).Value);
               Assert.NotNull(polSourceGroupingLanguageNew);

               // testing Put(PolSourceGroupingLanguage polSourceGroupingLanguage)
               var actionPolSourceGroupingLanguageUpdate = await polSourceGroupingLanguageController.Put(polSourceGroupingLanguageNew);
               Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageUpdate.Result).Value);
               PolSourceGroupingLanguage polSourceGroupingLanguageUpdate = (PolSourceGroupingLanguage)(((OkObjectResult)actionPolSourceGroupingLanguageUpdate.Result).Value);
               Assert.NotNull(polSourceGroupingLanguageUpdate);

               // testing Delete(PolSourceGroupingLanguage polSourceGroupingLanguage)
               var actionPolSourceGroupingLanguageDelete = await polSourceGroupingLanguageController.Delete(polSourceGroupingLanguageUpdate);
               Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageDelete.Result).Value);
               PolSourceGroupingLanguage polSourceGroupingLanguageDelete = (PolSourceGroupingLanguage)(((OkObjectResult)actionPolSourceGroupingLanguageDelete.Result).Value);
               Assert.NotNull(polSourceGroupingLanguageDelete);
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
            Services.AddSingleton<IPolSourceGroupingLanguageService, PolSourceGroupingLanguageService>();
            Services.AddSingleton<IPolSourceGroupingLanguageController, PolSourceGroupingLanguageController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            polSourceGroupingLanguageService = Provider.GetService<IPolSourceGroupingLanguageService>();
            Assert.NotNull(polSourceGroupingLanguageService);
        
            await polSourceGroupingLanguageService.SetCulture(culture);
        
            polSourceGroupingLanguageController = Provider.GetService<IPolSourceGroupingLanguageController>();
            Assert.NotNull(polSourceGroupingLanguageController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
