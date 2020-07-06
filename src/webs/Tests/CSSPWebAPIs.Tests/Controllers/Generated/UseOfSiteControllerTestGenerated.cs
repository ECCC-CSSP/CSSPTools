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
    public partial class UseOfSiteControllerTest
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
        private IUseOfSiteService useOfSiteService { get; set; }
        private IUseOfSiteController useOfSiteController { get; set; }
        #endregion Properties

        #region Constructors
        public UseOfSiteControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task UseOfSiteController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(useOfSiteService);
            Assert.NotNull(useOfSiteController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task UseOfSiteController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionUseOfSiteList = await useOfSiteController.Get();
                Assert.Equal(200, ((ObjectResult)actionUseOfSiteList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionUseOfSiteList.Result).Value);
                List<UseOfSite> useOfSiteList = (List<UseOfSite>)((OkObjectResult)actionUseOfSiteList.Result).Value;

                int count = ((List<UseOfSite>)((OkObjectResult)actionUseOfSiteList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(UseOfSiteID)
                var actionUseOfSite = await useOfSiteController.Get(useOfSiteList[0].UseOfSiteID);
                Assert.Equal(200, ((ObjectResult)actionUseOfSite.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionUseOfSite.Result).Value);
                UseOfSite useOfSite = (UseOfSite)((OkObjectResult)actionUseOfSite.Result).Value;
                Assert.NotNull(useOfSite);
                Assert.Equal(useOfSiteList[0].UseOfSiteID, useOfSite.UseOfSiteID);

                // testing Post(UseOfSite useOfSite)
                useOfSite.UseOfSiteID = 0;
                var actionUseOfSiteNew = await useOfSiteController.Post(useOfSite);
                Assert.Equal(200, ((ObjectResult)actionUseOfSiteNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionUseOfSiteNew.Result).Value);
                UseOfSite useOfSiteNew = (UseOfSite)((OkObjectResult)actionUseOfSiteNew.Result).Value;
                Assert.NotNull(useOfSiteNew);

                // testing Put(UseOfSite useOfSite)
                var actionUseOfSiteUpdate = await useOfSiteController.Put(useOfSiteNew);
                Assert.Equal(200, ((ObjectResult)actionUseOfSiteUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionUseOfSiteUpdate.Result).Value);
                UseOfSite useOfSiteUpdate = (UseOfSite)((OkObjectResult)actionUseOfSiteUpdate.Result).Value;
                Assert.NotNull(useOfSiteUpdate);

                // testing Delete(int useOfSite.UseOfSiteID)
                var actionUseOfSiteDelete = await useOfSiteController.Delete(useOfSiteUpdate.UseOfSiteID);
                Assert.Equal(200, ((ObjectResult)actionUseOfSiteDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionUseOfSiteDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionUseOfSiteDelete.Result).Value;
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
            Services.AddSingleton<IUseOfSiteService, UseOfSiteService>();
            Services.AddSingleton<IUseOfSiteController, UseOfSiteController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            useOfSiteService = Provider.GetService<IUseOfSiteService>();
            Assert.NotNull(useOfSiteService);

            useOfSiteController = Provider.GetService<IUseOfSiteController>();
            Assert.NotNull(useOfSiteController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
