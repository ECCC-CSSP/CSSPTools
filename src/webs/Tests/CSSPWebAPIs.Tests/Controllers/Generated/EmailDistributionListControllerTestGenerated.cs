/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerTestGenerated.exe
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
    public partial class EmailDistributionListControllerTest
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
        private IEmailDistributionListService emailDistributionListService { get; set; }
        private IEmailDistributionListController emailDistributionListController { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EmailDistributionListController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(emailDistributionListService);
            Assert.NotNull(emailDistributionListController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EmailDistributionListController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionEmailDistributionListList = await emailDistributionListController.Get();
                Assert.Equal(200, ((ObjectResult)actionEmailDistributionListList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailDistributionListList.Result).Value);
                List<EmailDistributionList> emailDistributionListList = (List<EmailDistributionList>)((OkObjectResult)actionEmailDistributionListList.Result).Value;

                int count = ((List<EmailDistributionList>)((OkObjectResult)actionEmailDistributionListList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(EmailDistributionListID)
                var actionEmailDistributionList = await emailDistributionListController.Get(emailDistributionListList[0].EmailDistributionListID);
                Assert.Equal(200, ((ObjectResult)actionEmailDistributionList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailDistributionList.Result).Value);
                EmailDistributionList emailDistributionList = (EmailDistributionList)((OkObjectResult)actionEmailDistributionList.Result).Value;
                Assert.NotNull(emailDistributionList);
                Assert.Equal(emailDistributionListList[0].EmailDistributionListID, emailDistributionList.EmailDistributionListID);

                // testing Post(EmailDistributionList emailDistributionList)
                emailDistributionList.EmailDistributionListID = 0;
                var actionEmailDistributionListNew = await emailDistributionListController.Post(emailDistributionList);
                Assert.Equal(200, ((ObjectResult)actionEmailDistributionListNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailDistributionListNew.Result).Value);
                EmailDistributionList emailDistributionListNew = (EmailDistributionList)((OkObjectResult)actionEmailDistributionListNew.Result).Value;
                Assert.NotNull(emailDistributionListNew);

                // testing Put(EmailDistributionList emailDistributionList)
                var actionEmailDistributionListUpdate = await emailDistributionListController.Put(emailDistributionListNew);
                Assert.Equal(200, ((ObjectResult)actionEmailDistributionListUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailDistributionListUpdate.Result).Value);
                EmailDistributionList emailDistributionListUpdate = (EmailDistributionList)((OkObjectResult)actionEmailDistributionListUpdate.Result).Value;
                Assert.NotNull(emailDistributionListUpdate);

                // testing Delete(int emailDistributionList.EmailDistributionListID)
                var actionEmailDistributionListDelete = await emailDistributionListController.Delete(emailDistributionListUpdate.EmailDistributionListID);
                Assert.Equal(200, ((ObjectResult)actionEmailDistributionListDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailDistributionListDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionEmailDistributionListDelete.Result).Value;
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
            Services.AddSingleton<IEmailDistributionListService, EmailDistributionListService>();
            Services.AddSingleton<IEmailDistributionListController, EmailDistributionListController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            emailDistributionListService = Provider.GetService<IEmailDistributionListService>();
            Assert.NotNull(emailDistributionListService);

            emailDistributionListController = Provider.GetService<IEmailDistributionListController>();
            Assert.NotNull(emailDistributionListController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
