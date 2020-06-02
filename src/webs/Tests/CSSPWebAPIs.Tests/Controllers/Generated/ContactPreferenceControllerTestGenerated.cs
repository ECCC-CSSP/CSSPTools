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
    public partial class ContactPreferenceControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IContactPreferenceService contactPreferenceService { get; set; }
        private IContactPreferenceController contactPreferenceController { get; set; }
        #endregion Properties

        #region Constructors
        public ContactPreferenceControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactPreferenceController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(contactPreferenceService);
            Assert.NotNull(contactPreferenceController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactPreferenceController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionContactPreferenceList = await contactPreferenceController.Get();
               Assert.Equal(200, ((ObjectResult)actionContactPreferenceList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactPreferenceList.Result).Value);
               List<ContactPreference> contactPreferenceList = (List<ContactPreference>)(((OkObjectResult)actionContactPreferenceList.Result).Value);

               int count = ((List<ContactPreference>)((OkObjectResult)actionContactPreferenceList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(ContactPreferenceID)
               var actionContactPreference = await contactPreferenceController.Get(contactPreferenceList[0].ContactPreferenceID);
               Assert.Equal(200, ((ObjectResult)actionContactPreference.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactPreference.Result).Value);
               ContactPreference contactPreference = (ContactPreference)(((OkObjectResult)actionContactPreference.Result).Value);
               Assert.NotNull(contactPreference);
               Assert.Equal(contactPreferenceList[0].ContactPreferenceID, contactPreference.ContactPreferenceID);

               // testing Post(ContactPreference contactPreference)
               contactPreference.ContactPreferenceID = 0;
               var actionContactPreferenceNew = await contactPreferenceController.Post(contactPreference);
               Assert.Equal(200, ((ObjectResult)actionContactPreferenceNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactPreferenceNew.Result).Value);
               ContactPreference contactPreferenceNew = (ContactPreference)(((OkObjectResult)actionContactPreferenceNew.Result).Value);
               Assert.NotNull(contactPreferenceNew);

               // testing Put(ContactPreference contactPreference)
               var actionContactPreferenceUpdate = await contactPreferenceController.Put(contactPreferenceNew);
               Assert.Equal(200, ((ObjectResult)actionContactPreferenceUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactPreferenceUpdate.Result).Value);
               ContactPreference contactPreferenceUpdate = (ContactPreference)(((OkObjectResult)actionContactPreferenceUpdate.Result).Value);
               Assert.NotNull(contactPreferenceUpdate);

               // testing Delete(ContactPreference contactPreference)
               var actionContactPreferenceDelete = await contactPreferenceController.Delete(contactPreferenceUpdate);
               Assert.Equal(200, ((ObjectResult)actionContactPreferenceDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactPreferenceDelete.Result).Value);
               ContactPreference contactPreferenceDelete = (ContactPreference)(((OkObjectResult)actionContactPreferenceDelete.Result).Value);
               Assert.NotNull(contactPreferenceDelete);
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
            Services.AddSingleton<IContactPreferenceService, ContactPreferenceService>();
            Services.AddSingleton<IContactPreferenceController, ContactPreferenceController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            contactPreferenceService = Provider.GetService<IContactPreferenceService>();
            Assert.NotNull(contactPreferenceService);
        
            await contactPreferenceService.SetCulture(culture);
        
            contactPreferenceController = Provider.GetService<IContactPreferenceController>();
            Assert.NotNull(contactPreferenceController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
