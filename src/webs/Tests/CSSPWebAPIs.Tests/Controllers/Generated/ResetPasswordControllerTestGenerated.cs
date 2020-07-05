/* Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
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
    public partial class ResetPasswordControllerTest
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
        private IResetPasswordService resetPasswordService { get; set; }
        private IResetPasswordController resetPasswordController { get; set; }
        #endregion Properties

        #region Constructors
        public ResetPasswordControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ResetPasswordController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(resetPasswordService);
            Assert.NotNull(resetPasswordController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ResetPasswordController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionResetPasswordList = await resetPasswordController.Get();
                Assert.Equal(200, ((ObjectResult)actionResetPasswordList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionResetPasswordList.Result).Value);
                List<ResetPassword> resetPasswordList = (List<ResetPassword>)((OkObjectResult)actionResetPasswordList.Result).Value;

                int count = ((List<ResetPassword>)((OkObjectResult)actionResetPasswordList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(ResetPasswordID)
                var actionResetPassword = await resetPasswordController.Get(resetPasswordList[0].ResetPasswordID);
                Assert.Equal(200, ((ObjectResult)actionResetPassword.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionResetPassword.Result).Value);
                ResetPassword resetPassword = (ResetPassword)((OkObjectResult)actionResetPassword.Result).Value;
                Assert.NotNull(resetPassword);
                Assert.Equal(resetPasswordList[0].ResetPasswordID, resetPassword.ResetPasswordID);

                // testing Post(ResetPassword resetPassword)
                resetPassword.ResetPasswordID = 0;
                var actionResetPasswordNew = await resetPasswordController.Post(resetPassword);
                Assert.Equal(200, ((ObjectResult)actionResetPasswordNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionResetPasswordNew.Result).Value);
                ResetPassword resetPasswordNew = (ResetPassword)((OkObjectResult)actionResetPasswordNew.Result).Value;
                Assert.NotNull(resetPasswordNew);

                // testing Put(ResetPassword resetPassword)
                var actionResetPasswordUpdate = await resetPasswordController.Put(resetPasswordNew);
                Assert.Equal(200, ((ObjectResult)actionResetPasswordUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionResetPasswordUpdate.Result).Value);
                ResetPassword resetPasswordUpdate = (ResetPassword)((OkObjectResult)actionResetPasswordUpdate.Result).Value;
                Assert.NotNull(resetPasswordUpdate);

                // testing Delete(int resetPassword.ResetPasswordID)
                var actionResetPasswordDelete = await resetPasswordController.Delete(resetPasswordUpdate.ResetPasswordID);
                Assert.Equal(200, ((ObjectResult)actionResetPasswordDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionResetPasswordDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionResetPasswordDelete.Result).Value;
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
            Services.AddSingleton<IResetPasswordService, ResetPasswordService>();
            Services.AddSingleton<IResetPasswordController, ResetPasswordController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            resetPasswordService = Provider.GetService<IResetPasswordService>();
            Assert.NotNull(resetPasswordService);

            resetPasswordController = Provider.GetService<IResetPasswordController>();
            Assert.NotNull(resetPasswordController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
