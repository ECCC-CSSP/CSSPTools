/* Auto generated from C:\CSSPTools\src\codegen\WebAPIClassNameControllerTestGenerated\bin\Debug\netcoreapp3.1\WebAPIClassNameControllerTestGenerated.exe
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
    public partial class EmailControllerTest
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
        private IEmailService emailService { get; set; }
        private IEmailController emailController { get; set; }
        #endregion Properties

        #region Constructors
        public EmailControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EmailController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(emailService);
            Assert.NotNull(emailController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EmailController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionEmailList = await emailController.Get();
                Assert.Equal(200, ((ObjectResult)actionEmailList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailList.Result).Value);
                List<Email> emailList = (List<Email>)((OkObjectResult)actionEmailList.Result).Value;

                int count = ((List<Email>)((OkObjectResult)actionEmailList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(EmailID)
                var actionEmail = await emailController.Get(emailList[0].EmailID);
                Assert.Equal(200, ((ObjectResult)actionEmail.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmail.Result).Value);
                Email email = (Email)((OkObjectResult)actionEmail.Result).Value;
                Assert.NotNull(email);
                Assert.Equal(emailList[0].EmailID, email.EmailID);

                // testing Post(Email email)
                email.EmailID = 0;
                var actionEmailNew = await emailController.Post(email);
                Assert.Equal(200, ((ObjectResult)actionEmailNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailNew.Result).Value);
                Email emailNew = (Email)((OkObjectResult)actionEmailNew.Result).Value;
                Assert.NotNull(emailNew);

                // testing Put(Email email)
                var actionEmailUpdate = await emailController.Put(emailNew);
                Assert.Equal(200, ((ObjectResult)actionEmailUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailUpdate.Result).Value);
                Email emailUpdate = (Email)((OkObjectResult)actionEmailUpdate.Result).Value;
                Assert.NotNull(emailUpdate);

                // testing Delete(int email.EmailID)
                var actionEmailDelete = await emailController.Delete(emailUpdate.EmailID);
                Assert.Equal(200, ((ObjectResult)actionEmailDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionEmailDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionEmailDelete.Result).Value;
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
            Services.AddSingleton<IEmailService, EmailService>();
            Services.AddSingleton<IEmailController, EmailController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            emailService = Provider.GetService<IEmailService>();
            Assert.NotNull(emailService);

            emailController = Provider.GetService<IEmailController>();
            Assert.NotNull(emailController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
