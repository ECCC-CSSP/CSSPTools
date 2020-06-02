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
    public partial class EmailDistributionListContactLanguageControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IEmailDistributionListContactLanguageService emailDistributionListContactLanguageService { get; set; }
        private IEmailDistributionListContactLanguageController emailDistributionListContactLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EmailDistributionListContactLanguageController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(emailDistributionListContactLanguageService);
            Assert.NotNull(emailDistributionListContactLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EmailDistributionListContactLanguageController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionEmailDistributionListContactLanguageList = await emailDistributionListContactLanguageController.Get();
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactLanguageList.Result).Value);
               List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList = (List<EmailDistributionListContactLanguage>)(((OkObjectResult)actionEmailDistributionListContactLanguageList.Result).Value);

               int count = ((List<EmailDistributionListContactLanguage>)((OkObjectResult)actionEmailDistributionListContactLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(EmailDistributionListContactLanguageID)
               var actionEmailDistributionListContactLanguage = await emailDistributionListContactLanguageController.Get(emailDistributionListContactLanguageList[0].EmailDistributionListContactLanguageID);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactLanguage.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactLanguage.Result).Value);
               EmailDistributionListContactLanguage emailDistributionListContactLanguage = (EmailDistributionListContactLanguage)(((OkObjectResult)actionEmailDistributionListContactLanguage.Result).Value);
               Assert.NotNull(emailDistributionListContactLanguage);
               Assert.Equal(emailDistributionListContactLanguageList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguage.EmailDistributionListContactLanguageID);

               // testing Post(EmailDistributionListContactLanguage emailDistributionListContactLanguage)
               emailDistributionListContactLanguage.EmailDistributionListContactLanguageID = 0;
               var actionEmailDistributionListContactLanguageNew = await emailDistributionListContactLanguageController.Post(emailDistributionListContactLanguage);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactLanguageNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactLanguageNew.Result).Value);
               EmailDistributionListContactLanguage emailDistributionListContactLanguageNew = (EmailDistributionListContactLanguage)(((OkObjectResult)actionEmailDistributionListContactLanguageNew.Result).Value);
               Assert.NotNull(emailDistributionListContactLanguageNew);

               // testing Put(EmailDistributionListContactLanguage emailDistributionListContactLanguage)
               var actionEmailDistributionListContactLanguageUpdate = await emailDistributionListContactLanguageController.Put(emailDistributionListContactLanguageNew);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactLanguageUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactLanguageUpdate.Result).Value);
               EmailDistributionListContactLanguage emailDistributionListContactLanguageUpdate = (EmailDistributionListContactLanguage)(((OkObjectResult)actionEmailDistributionListContactLanguageUpdate.Result).Value);
               Assert.NotNull(emailDistributionListContactLanguageUpdate);

               // testing Delete(EmailDistributionListContactLanguage emailDistributionListContactLanguage)
               var actionEmailDistributionListContactLanguageDelete = await emailDistributionListContactLanguageController.Delete(emailDistributionListContactLanguageUpdate);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactLanguageDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactLanguageDelete.Result).Value);
               EmailDistributionListContactLanguage emailDistributionListContactLanguageDelete = (EmailDistributionListContactLanguage)(((OkObjectResult)actionEmailDistributionListContactLanguageDelete.Result).Value);
               Assert.NotNull(emailDistributionListContactLanguageDelete);
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
            Services.AddSingleton<IEmailDistributionListContactLanguageService, EmailDistributionListContactLanguageService>();
            Services.AddSingleton<IEmailDistributionListContactLanguageController, EmailDistributionListContactLanguageController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            emailDistributionListContactLanguageService = Provider.GetService<IEmailDistributionListContactLanguageService>();
            Assert.NotNull(emailDistributionListContactLanguageService);
        
            await emailDistributionListContactLanguageService.SetCulture(culture);
        
            emailDistributionListContactLanguageController = Provider.GetService<IEmailDistributionListContactLanguageController>();
            Assert.NotNull(emailDistributionListContactLanguageController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
