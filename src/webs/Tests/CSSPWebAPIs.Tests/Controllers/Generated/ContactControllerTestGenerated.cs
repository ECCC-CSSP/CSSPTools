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
    public partial class ContactControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IContactService contactService { get; set; }
        private IContactController contactController { get; set; }
        #endregion Properties

        #region Constructors
        public ContactControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(contactService);
            Assert.NotNull(contactController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionContactList = await contactController.Get();
               Assert.Equal(200, ((ObjectResult)actionContactList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactList.Result).Value);
               List<Contact> contactList = (List<Contact>)(((OkObjectResult)actionContactList.Result).Value);

               int count = ((List<Contact>)((OkObjectResult)actionContactList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(ContactID)
               var actionContact = await contactController.Get(contactList[0].ContactID);
               Assert.Equal(200, ((ObjectResult)actionContact.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContact.Result).Value);
               Contact contact = (Contact)(((OkObjectResult)actionContact.Result).Value);
               Assert.NotNull(contact);
               Assert.Equal(contactList[0].ContactID, contact.ContactID);

               // testing Post(Contact contact)
               contact.ContactID = 0;
               var actionContactNew = await contactController.Post(contact);
               Assert.Equal(200, ((ObjectResult)actionContactNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactNew.Result).Value);
               Contact contactNew = (Contact)(((OkObjectResult)actionContactNew.Result).Value);
               Assert.NotNull(contactNew);

               // testing Put(Contact contact)
               var actionContactUpdate = await contactController.Put(contactNew);
               Assert.Equal(200, ((ObjectResult)actionContactUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactUpdate.Result).Value);
               Contact contactUpdate = (Contact)(((OkObjectResult)actionContactUpdate.Result).Value);
               Assert.NotNull(contactUpdate);

               // testing Delete(Contact contact)
               var actionContactDelete = await contactController.Delete(contactUpdate);
               Assert.Equal(200, ((ObjectResult)actionContactDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactDelete.Result).Value);
               Contact contactDelete = (Contact)(((OkObjectResult)actionContactDelete.Result).Value);
               Assert.NotNull(contactDelete);
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
            Services.AddSingleton<IContactService, ContactService>();
            Services.AddSingleton<IContactController, ContactController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            contactService = Provider.GetService<IContactService>();
            Assert.NotNull(contactService);
        
            await contactService.SetCulture(culture);
        
            contactController = Provider.GetService<IContactController>();
            Assert.NotNull(contactController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
