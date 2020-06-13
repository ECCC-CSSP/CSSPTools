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
    public partial class DrogueRunControllerTest
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
        private IDrogueRunService drogueRunService { get; set; }
        private IDrogueRunController drogueRunController { get; set; }
        #endregion Properties

        #region Constructors
        public DrogueRunControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task DrogueRunController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(drogueRunService);
            Assert.NotNull(drogueRunController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task DrogueRunController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionDrogueRunList = await drogueRunController.Get();
                Assert.Equal(200, ((ObjectResult)actionDrogueRunList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionDrogueRunList.Result).Value);
                List<DrogueRun> drogueRunList = (List<DrogueRun>)((OkObjectResult)actionDrogueRunList.Result).Value;

                int count = ((List<DrogueRun>)((OkObjectResult)actionDrogueRunList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(DrogueRunID)
                var actionDrogueRun = await drogueRunController.Get(drogueRunList[0].DrogueRunID);
                Assert.Equal(200, ((ObjectResult)actionDrogueRun.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionDrogueRun.Result).Value);
                DrogueRun drogueRun = (DrogueRun)((OkObjectResult)actionDrogueRun.Result).Value;
                Assert.NotNull(drogueRun);
                Assert.Equal(drogueRunList[0].DrogueRunID, drogueRun.DrogueRunID);

                // testing Post(DrogueRun drogueRun)
                drogueRun.DrogueRunID = 0;
                var actionDrogueRunNew = await drogueRunController.Post(drogueRun);
                Assert.Equal(200, ((ObjectResult)actionDrogueRunNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionDrogueRunNew.Result).Value);
                DrogueRun drogueRunNew = (DrogueRun)((OkObjectResult)actionDrogueRunNew.Result).Value;
                Assert.NotNull(drogueRunNew);

                // testing Put(DrogueRun drogueRun)
                var actionDrogueRunUpdate = await drogueRunController.Put(drogueRunNew);
                Assert.Equal(200, ((ObjectResult)actionDrogueRunUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionDrogueRunUpdate.Result).Value);
                DrogueRun drogueRunUpdate = (DrogueRun)((OkObjectResult)actionDrogueRunUpdate.Result).Value;
                Assert.NotNull(drogueRunUpdate);

                // testing Delete(int drogueRun.DrogueRunID)
                var actionDrogueRunDelete = await drogueRunController.Delete(drogueRunUpdate.DrogueRunID);
                Assert.Equal(200, ((ObjectResult)actionDrogueRunDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionDrogueRunDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionDrogueRunDelete.Result).Value;
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
            Services.AddSingleton<IDrogueRunService, DrogueRunService>();
            Services.AddSingleton<IDrogueRunController, DrogueRunController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            drogueRunService = Provider.GetService<IDrogueRunService>();
            Assert.NotNull(drogueRunService);

            drogueRunController = Provider.GetService<IDrogueRunController>();
            Assert.NotNull(drogueRunController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
