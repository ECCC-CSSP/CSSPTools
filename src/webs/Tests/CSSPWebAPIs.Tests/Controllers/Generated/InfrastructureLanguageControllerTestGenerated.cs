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
    public partial class InfrastructureLanguageControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IInfrastructureLanguageService infrastructureLanguageService { get; set; }
        private IInfrastructureLanguageController infrastructureLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task InfrastructureLanguageController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(infrastructureLanguageService);
            Assert.NotNull(infrastructureLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task InfrastructureLanguageController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionInfrastructureLanguageList = await infrastructureLanguageController.Get();
               Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageList.Result).Value);
               List<InfrastructureLanguage> infrastructureLanguageList = (List<InfrastructureLanguage>)(((OkObjectResult)actionInfrastructureLanguageList.Result).Value);

               int count = ((List<InfrastructureLanguage>)((OkObjectResult)actionInfrastructureLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(InfrastructureLanguageID)
               var actionInfrastructureLanguage = await infrastructureLanguageController.Get(infrastructureLanguageList[0].InfrastructureLanguageID);
               Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguage.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionInfrastructureLanguage.Result).Value);
               InfrastructureLanguage infrastructureLanguage = (InfrastructureLanguage)(((OkObjectResult)actionInfrastructureLanguage.Result).Value);
               Assert.NotNull(infrastructureLanguage);
               Assert.Equal(infrastructureLanguageList[0].InfrastructureLanguageID, infrastructureLanguage.InfrastructureLanguageID);

               // testing Post(InfrastructureLanguage infrastructureLanguage)
               infrastructureLanguage.InfrastructureLanguageID = 0;
               var actionInfrastructureLanguageNew = await infrastructureLanguageController.Post(infrastructureLanguage);
               Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageNew.Result).Value);
               InfrastructureLanguage infrastructureLanguageNew = (InfrastructureLanguage)(((OkObjectResult)actionInfrastructureLanguageNew.Result).Value);
               Assert.NotNull(infrastructureLanguageNew);

               // testing Put(InfrastructureLanguage infrastructureLanguage)
               var actionInfrastructureLanguageUpdate = await infrastructureLanguageController.Put(infrastructureLanguageNew);
               Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageUpdate.Result).Value);
               InfrastructureLanguage infrastructureLanguageUpdate = (InfrastructureLanguage)(((OkObjectResult)actionInfrastructureLanguageUpdate.Result).Value);
               Assert.NotNull(infrastructureLanguageUpdate);

               // testing Delete(InfrastructureLanguage infrastructureLanguage)
               var actionInfrastructureLanguageDelete = await infrastructureLanguageController.Delete(infrastructureLanguageUpdate);
               Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageDelete.Result).Value);
               InfrastructureLanguage infrastructureLanguageDelete = (InfrastructureLanguage)(((OkObjectResult)actionInfrastructureLanguageDelete.Result).Value);
               Assert.NotNull(infrastructureLanguageDelete);
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
            Services.AddSingleton<IInfrastructureLanguageService, InfrastructureLanguageService>();
            Services.AddSingleton<IInfrastructureLanguageController, InfrastructureLanguageController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            infrastructureLanguageService = Provider.GetService<IInfrastructureLanguageService>();
            Assert.NotNull(infrastructureLanguageService);
        
            await infrastructureLanguageService.SetCulture(culture);
        
            infrastructureLanguageController = Provider.GetService<IInfrastructureLanguageController>();
            Assert.NotNull(infrastructureLanguageController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
