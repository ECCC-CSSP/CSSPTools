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
    public partial class SamplingPlanSubsectorSiteControllerTest
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
        private ISamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService { get; set; }
        private ISamplingPlanSubsectorSiteController samplingPlanSubsectorSiteController { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SamplingPlanSubsectorSiteController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(samplingPlanSubsectorSiteService);
            Assert.NotNull(samplingPlanSubsectorSiteController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SamplingPlanSubsectorSiteController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionSamplingPlanSubsectorSiteList = await samplingPlanSubsectorSiteController.Get();
                Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteList.Result).Value);
                List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = (List<SamplingPlanSubsectorSite>)((OkObjectResult)actionSamplingPlanSubsectorSiteList.Result).Value;

                int count = ((List<SamplingPlanSubsectorSite>)((OkObjectResult)actionSamplingPlanSubsectorSiteList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(SamplingPlanSubsectorSiteID)
                var actionSamplingPlanSubsectorSite = await samplingPlanSubsectorSiteController.Get(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSite.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSite.Result).Value);
                SamplingPlanSubsectorSite samplingPlanSubsectorSite = (SamplingPlanSubsectorSite)((OkObjectResult)actionSamplingPlanSubsectorSite.Result).Value;
                Assert.NotNull(samplingPlanSubsectorSite);
                Assert.Equal(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID);

                // testing Post(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
                samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 0;
                var actionSamplingPlanSubsectorSiteNew = await samplingPlanSubsectorSiteController.Post(samplingPlanSubsectorSite);
                Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteNew.Result).Value);
                SamplingPlanSubsectorSite samplingPlanSubsectorSiteNew = (SamplingPlanSubsectorSite)((OkObjectResult)actionSamplingPlanSubsectorSiteNew.Result).Value;
                Assert.NotNull(samplingPlanSubsectorSiteNew);

                // testing Put(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
                var actionSamplingPlanSubsectorSiteUpdate = await samplingPlanSubsectorSiteController.Put(samplingPlanSubsectorSiteNew);
                Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteUpdate.Result).Value);
                SamplingPlanSubsectorSite samplingPlanSubsectorSiteUpdate = (SamplingPlanSubsectorSite)((OkObjectResult)actionSamplingPlanSubsectorSiteUpdate.Result).Value;
                Assert.NotNull(samplingPlanSubsectorSiteUpdate);

                // testing Delete(int samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID)
                var actionSamplingPlanSubsectorSiteDelete = await samplingPlanSubsectorSiteController.Delete(samplingPlanSubsectorSiteUpdate.SamplingPlanSubsectorSiteID);
                Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionSamplingPlanSubsectorSiteDelete.Result).Value;
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
            Services.AddSingleton<ISamplingPlanSubsectorSiteService, SamplingPlanSubsectorSiteService>();
            Services.AddSingleton<ISamplingPlanSubsectorSiteController, SamplingPlanSubsectorSiteController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            samplingPlanSubsectorSiteService = Provider.GetService<ISamplingPlanSubsectorSiteService>();
            Assert.NotNull(samplingPlanSubsectorSiteService);

            samplingPlanSubsectorSiteController = Provider.GetService<ISamplingPlanSubsectorSiteController>();
            Assert.NotNull(samplingPlanSubsectorSiteController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
