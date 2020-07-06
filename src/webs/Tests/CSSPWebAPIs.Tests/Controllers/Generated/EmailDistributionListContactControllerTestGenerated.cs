/* Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using CultureServices.Services;
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
    public partial class EmailDistributionListContactControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ICultureService CultureService { get; set; }
        private IEmailDistributionListContactService emailDistributionListContactService { get; set; }
        private IEmailDistributionListContactController emailDistributionListContactController { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EmailDistributionListContactController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(emailDistributionListContactService);
            Assert.NotNull(emailDistributionListContactController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EmailDistributionListContactController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionEmailDistributionListContactList = await emailDistributionListContactController.Get();
                Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactList.Result).Value);
                List<EmailDistributionListContact> emailDistributionListContactList = (List<EmailDistributionListContact>)((OkObjectResult)actionEmailDistributionListContactList.Result).Value;

                int count = ((List<EmailDistributionListContact>)((OkObjectResult)actionEmailDistributionListContactList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(EmailDistributionListContactID)
                var actionEmailDistributionListContact = await emailDistributionListContactController.Get(emailDistributionListContactList[0].EmailDistributionListContactID);
                Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContact.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailDistributionListContact.Result).Value);
                EmailDistributionListContact emailDistributionListContact = (EmailDistributionListContact)((OkObjectResult)actionEmailDistributionListContact.Result).Value;
                Assert.NotNull(emailDistributionListContact);
                Assert.Equal(emailDistributionListContactList[0].EmailDistributionListContactID, emailDistributionListContact.EmailDistributionListContactID);

                // testing Post(EmailDistributionListContact emailDistributionListContact)
                emailDistributionListContact.EmailDistributionListContactID = 0;
                var actionEmailDistributionListContactNew = await emailDistributionListContactController.Post(emailDistributionListContact);
                Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactNew.Result).Value);
                EmailDistributionListContact emailDistributionListContactNew = (EmailDistributionListContact)((OkObjectResult)actionEmailDistributionListContactNew.Result).Value;
                Assert.NotNull(emailDistributionListContactNew);

                // testing Put(EmailDistributionListContact emailDistributionListContact)
                var actionEmailDistributionListContactUpdate = await emailDistributionListContactController.Put(emailDistributionListContactNew);
                Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactUpdate.Result).Value);
                EmailDistributionListContact emailDistributionListContactUpdate = (EmailDistributionListContact)((OkObjectResult)actionEmailDistributionListContactUpdate.Result).Value;
                Assert.NotNull(emailDistributionListContactUpdate);

                // testing Delete(int emailDistributionListContact.EmailDistributionListContactID)
                var actionEmailDistributionListContactDelete = await emailDistributionListContactController.Delete(emailDistributionListContactUpdate.EmailDistributionListContactID);
                Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionEmailDistributionListContactDelete.Result).Value;
                Assert.True(retBool2);
            }
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
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

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEmailDistributionListContactService, EmailDistributionListContactService>();
            Services.AddSingleton<IEmailDistributionListContactController, EmailDistributionListContactController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            emailDistributionListContactService = Provider.GetService<IEmailDistributionListContactService>();
            Assert.NotNull(emailDistributionListContactService);

            emailDistributionListContactController = Provider.GetService<IEmailDistributionListContactController>();
            Assert.NotNull(emailDistributionListContactController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
