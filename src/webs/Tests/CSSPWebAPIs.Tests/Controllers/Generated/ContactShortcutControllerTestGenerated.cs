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
    public partial class ContactShortcutControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IContactShortcutService contactShortcutService { get; set; }
        private IContactShortcutController contactShortcutController { get; set; }
        #endregion Properties

        #region Constructors
        public ContactShortcutControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactShortcutController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(contactShortcutService);
            Assert.NotNull(contactShortcutController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactShortcutController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionContactShortcutList = await contactShortcutController.Get();
               Assert.Equal(200, ((ObjectResult)actionContactShortcutList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactShortcutList.Result).Value);
               List<ContactShortcut> contactShortcutList = (List<ContactShortcut>)(((OkObjectResult)actionContactShortcutList.Result).Value);

               int count = ((List<ContactShortcut>)((OkObjectResult)actionContactShortcutList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(ContactShortcutID)
               var actionContactShortcut = await contactShortcutController.Get(contactShortcutList[0].ContactShortcutID);
               Assert.Equal(200, ((ObjectResult)actionContactShortcut.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactShortcut.Result).Value);
               ContactShortcut contactShortcut = (ContactShortcut)(((OkObjectResult)actionContactShortcut.Result).Value);
               Assert.NotNull(contactShortcut);
               Assert.Equal(contactShortcutList[0].ContactShortcutID, contactShortcut.ContactShortcutID);

               // testing Post(ContactShortcut contactShortcut)
               contactShortcut.ContactShortcutID = 0;
               var actionContactShortcutNew = await contactShortcutController.Post(contactShortcut);
               Assert.Equal(200, ((ObjectResult)actionContactShortcutNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactShortcutNew.Result).Value);
               ContactShortcut contactShortcutNew = (ContactShortcut)(((OkObjectResult)actionContactShortcutNew.Result).Value);
               Assert.NotNull(contactShortcutNew);

               // testing Put(ContactShortcut contactShortcut)
               var actionContactShortcutUpdate = await contactShortcutController.Put(contactShortcutNew);
               Assert.Equal(200, ((ObjectResult)actionContactShortcutUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactShortcutUpdate.Result).Value);
               ContactShortcut contactShortcutUpdate = (ContactShortcut)(((OkObjectResult)actionContactShortcutUpdate.Result).Value);
               Assert.NotNull(contactShortcutUpdate);

               // testing Delete(ContactShortcut contactShortcut)
               var actionContactShortcutDelete = await contactShortcutController.Delete(contactShortcutUpdate);
               Assert.Equal(200, ((ObjectResult)actionContactShortcutDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactShortcutDelete.Result).Value);
               ContactShortcut contactShortcutDelete = (ContactShortcut)(((OkObjectResult)actionContactShortcutDelete.Result).Value);
               Assert.NotNull(contactShortcutDelete);
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
            Services.AddSingleton<IContactShortcutService, ContactShortcutService>();
            Services.AddSingleton<IContactShortcutController, ContactShortcutController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            contactShortcutService = Provider.GetService<IContactShortcutService>();
            Assert.NotNull(contactShortcutService);
        
            await contactShortcutService.SetCulture(culture);
        
            contactShortcutController = Provider.GetService<IContactShortcutController>();
            Assert.NotNull(contactShortcutController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
