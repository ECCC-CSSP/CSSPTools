/* Auto generated from C:\CSSPTools\src\codegen\WebAPIClassNameControllerTestGenerated\bin\Debug\netcoreapp3.1\WebAPIClassNameControllerTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

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
    public partial class RainExceedanceClimateSiteControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IRainExceedanceClimateSiteService rainExceedanceClimateSiteService { get; set; }
        private IRainExceedanceClimateSiteController rainExceedanceClimateSiteController { get; set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task RainExceedanceClimateSiteController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(rainExceedanceClimateSiteService);
            Assert.NotNull(rainExceedanceClimateSiteController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task RainExceedanceClimateSiteController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionRainExceedanceClimateSiteList = await rainExceedanceClimateSiteController.Get();
                Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value);
                List<RainExceedanceClimateSite> rainExceedanceClimateSiteList = (List<RainExceedanceClimateSite>)((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value;

                int count = ((List<RainExceedanceClimateSite>)((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(RainExceedanceClimateSiteID)
                var actionRainExceedanceClimateSite = await rainExceedanceClimateSiteController.Get(rainExceedanceClimateSiteList[0].RainExceedanceClimateSiteID);
                Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSite.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSite.Result).Value);
                RainExceedanceClimateSite rainExceedanceClimateSite = (RainExceedanceClimateSite)((OkObjectResult)actionRainExceedanceClimateSite.Result).Value;
                Assert.NotNull(rainExceedanceClimateSite);
                Assert.Equal(rainExceedanceClimateSiteList[0].RainExceedanceClimateSiteID, rainExceedanceClimateSite.RainExceedanceClimateSiteID);

                // testing Post(RainExceedanceClimateSite rainExceedanceClimateSite)
                rainExceedanceClimateSite.RainExceedanceClimateSiteID = 0;
                var actionRainExceedanceClimateSiteNew = await rainExceedanceClimateSiteController.Post(rainExceedanceClimateSite);
                Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteNew.Result).Value);
                RainExceedanceClimateSite rainExceedanceClimateSiteNew = (RainExceedanceClimateSite)((OkObjectResult)actionRainExceedanceClimateSiteNew.Result).Value;
                Assert.NotNull(rainExceedanceClimateSiteNew);

                // testing Put(RainExceedanceClimateSite rainExceedanceClimateSite)
                var actionRainExceedanceClimateSiteUpdate = await rainExceedanceClimateSiteController.Put(rainExceedanceClimateSiteNew);
                Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteUpdate.Result).Value);
                RainExceedanceClimateSite rainExceedanceClimateSiteUpdate = (RainExceedanceClimateSite)((OkObjectResult)actionRainExceedanceClimateSiteUpdate.Result).Value;
                Assert.NotNull(rainExceedanceClimateSiteUpdate);

                // testing Delete(int rainExceedanceClimateSite.RainExceedanceClimateSiteID)
                var actionRainExceedanceClimateSiteDelete = await rainExceedanceClimateSiteController.Delete(rainExceedanceClimateSiteUpdate.RainExceedanceClimateSiteID);
                Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionRainExceedanceClimateSiteDelete.Result).Value;
                Assert.True(retBool2);
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
            Services.AddSingleton<IRainExceedanceClimateSiteService, RainExceedanceClimateSiteService>();
            Services.AddSingleton<IRainExceedanceClimateSiteController, RainExceedanceClimateSiteController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            rainExceedanceClimateSiteService = Provider.GetService<IRainExceedanceClimateSiteService>();
            Assert.NotNull(rainExceedanceClimateSiteService);

            await rainExceedanceClimateSiteService.SetCulture(culture);

            rainExceedanceClimateSiteController = Provider.GetService<IRainExceedanceClimateSiteController>();
            Assert.NotNull(rainExceedanceClimateSiteController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
