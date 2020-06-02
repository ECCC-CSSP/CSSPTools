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
    public partial class EmailDistributionListLanguageControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IEmailDistributionListLanguageService emailDistributionListLanguageService { get; set; }
        private IEmailDistributionListLanguageController emailDistributionListLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EmailDistributionListLanguageController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(emailDistributionListLanguageService);
            Assert.NotNull(emailDistributionListLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EmailDistributionListLanguageController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionEmailDistributionListLanguageList = await emailDistributionListLanguageController.Get();
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListLanguageList.Result).Value);
               List<EmailDistributionListLanguage> emailDistributionListLanguageList = (List<EmailDistributionListLanguage>)(((OkObjectResult)actionEmailDistributionListLanguageList.Result).Value);

               int count = ((List<EmailDistributionListLanguage>)((OkObjectResult)actionEmailDistributionListLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(EmailDistributionListLanguageID)
               var actionEmailDistributionListLanguage = await emailDistributionListLanguageController.Get(emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListLanguage.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListLanguage.Result).Value);
               EmailDistributionListLanguage emailDistributionListLanguage = (EmailDistributionListLanguage)(((OkObjectResult)actionEmailDistributionListLanguage.Result).Value);
               Assert.NotNull(emailDistributionListLanguage);
               Assert.Equal(emailDistributionListLanguageList[0].EmailDistributionListLanguageID, emailDistributionListLanguage.EmailDistributionListLanguageID);

               // testing Post(EmailDistributionListLanguage emailDistributionListLanguage)
               emailDistributionListLanguage.EmailDistributionListLanguageID = 0;
               var actionEmailDistributionListLanguageNew = await emailDistributionListLanguageController.Post(emailDistributionListLanguage);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListLanguageNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListLanguageNew.Result).Value);
               EmailDistributionListLanguage emailDistributionListLanguageNew = (EmailDistributionListLanguage)(((OkObjectResult)actionEmailDistributionListLanguageNew.Result).Value);
               Assert.NotNull(emailDistributionListLanguageNew);

               // testing Put(EmailDistributionListLanguage emailDistributionListLanguage)
               var actionEmailDistributionListLanguageUpdate = await emailDistributionListLanguageController.Put(emailDistributionListLanguageNew);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListLanguageUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListLanguageUpdate.Result).Value);
               EmailDistributionListLanguage emailDistributionListLanguageUpdate = (EmailDistributionListLanguage)(((OkObjectResult)actionEmailDistributionListLanguageUpdate.Result).Value);
               Assert.NotNull(emailDistributionListLanguageUpdate);

               // testing Delete(EmailDistributionListLanguage emailDistributionListLanguage)
               var actionEmailDistributionListLanguageDelete = await emailDistributionListLanguageController.Delete(emailDistributionListLanguageUpdate);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListLanguageDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListLanguageDelete.Result).Value);
               EmailDistributionListLanguage emailDistributionListLanguageDelete = (EmailDistributionListLanguage)(((OkObjectResult)actionEmailDistributionListLanguageDelete.Result).Value);
               Assert.NotNull(emailDistributionListLanguageDelete);
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
            Services.AddSingleton<IEmailDistributionListLanguageService, EmailDistributionListLanguageService>();
            Services.AddSingleton<IEmailDistributionListLanguageController, EmailDistributionListLanguageController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            emailDistributionListLanguageService = Provider.GetService<IEmailDistributionListLanguageService>();
            Assert.NotNull(emailDistributionListLanguageService);
        
            await emailDistributionListLanguageService.SetCulture(culture);
        
            emailDistributionListLanguageController = Provider.GetService<IEmailDistributionListLanguageController>();
            Assert.NotNull(emailDistributionListLanguageController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
