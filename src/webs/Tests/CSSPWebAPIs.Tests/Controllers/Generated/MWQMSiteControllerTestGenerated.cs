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
    public partial class MWQMSiteControllerTest
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
        private IMWQMSiteService mwqmSiteService { get; set; }
        private IMWQMSiteController mwqmSiteController { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSiteController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(mwqmSiteService);
            Assert.NotNull(mwqmSiteController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSiteController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionMWQMSiteList = await mwqmSiteController.Get();
                Assert.Equal(200, ((ObjectResult)actionMWQMSiteList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMSiteList.Result).Value);
                List<MWQMSite> mwqmSiteList = (List<MWQMSite>)((OkObjectResult)actionMWQMSiteList.Result).Value;

                int count = ((List<MWQMSite>)((OkObjectResult)actionMWQMSiteList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(MWQMSiteID)
                var actionMWQMSite = await mwqmSiteController.Get(mwqmSiteList[0].MWQMSiteID);
                Assert.Equal(200, ((ObjectResult)actionMWQMSite.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMSite.Result).Value);
                MWQMSite mwqmSite = (MWQMSite)((OkObjectResult)actionMWQMSite.Result).Value;
                Assert.NotNull(mwqmSite);
                Assert.Equal(mwqmSiteList[0].MWQMSiteID, mwqmSite.MWQMSiteID);

                // testing Post(MWQMSite mwqmSite)
                mwqmSite.MWQMSiteID = 0;
                var actionMWQMSiteNew = await mwqmSiteController.Post(mwqmSite);
                Assert.Equal(200, ((ObjectResult)actionMWQMSiteNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMSiteNew.Result).Value);
                MWQMSite mwqmSiteNew = (MWQMSite)((OkObjectResult)actionMWQMSiteNew.Result).Value;
                Assert.NotNull(mwqmSiteNew);

                // testing Put(MWQMSite mwqmSite)
                var actionMWQMSiteUpdate = await mwqmSiteController.Put(mwqmSiteNew);
                Assert.Equal(200, ((ObjectResult)actionMWQMSiteUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMSiteUpdate.Result).Value);
                MWQMSite mwqmSiteUpdate = (MWQMSite)((OkObjectResult)actionMWQMSiteUpdate.Result).Value;
                Assert.NotNull(mwqmSiteUpdate);

                // testing Delete(int mwqmSite.MWQMSiteID)
                var actionMWQMSiteDelete = await mwqmSiteController.Delete(mwqmSiteUpdate.MWQMSiteID);
                Assert.Equal(200, ((ObjectResult)actionMWQMSiteDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMSiteDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionMWQMSiteDelete.Result).Value;
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
            Services.AddSingleton<IMWQMSiteService, MWQMSiteService>();
            Services.AddSingleton<IMWQMSiteController, MWQMSiteController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            mwqmSiteService = Provider.GetService<IMWQMSiteService>();
            Assert.NotNull(mwqmSiteService);

            mwqmSiteController = Provider.GetService<IMWQMSiteController>();
            Assert.NotNull(mwqmSiteController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
