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
    public partial class TVFileLanguageControllerTest
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
        private ITVFileLanguageService tvFileLanguageService { get; set; }
        private ITVFileLanguageController tvFileLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVFileLanguageController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(tvFileLanguageService);
            Assert.NotNull(tvFileLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVFileLanguageController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionTVFileLanguageList = await tvFileLanguageController.Get();
                Assert.Equal(200, ((ObjectResult)actionTVFileLanguageList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionTVFileLanguageList.Result).Value);
                List<TVFileLanguage> tvFileLanguageList = (List<TVFileLanguage>)((OkObjectResult)actionTVFileLanguageList.Result).Value;

                int count = ((List<TVFileLanguage>)((OkObjectResult)actionTVFileLanguageList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(TVFileLanguageID)
                var actionTVFileLanguage = await tvFileLanguageController.Get(tvFileLanguageList[0].TVFileLanguageID);
                Assert.Equal(200, ((ObjectResult)actionTVFileLanguage.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionTVFileLanguage.Result).Value);
                TVFileLanguage tvFileLanguage = (TVFileLanguage)((OkObjectResult)actionTVFileLanguage.Result).Value;
                Assert.NotNull(tvFileLanguage);
                Assert.Equal(tvFileLanguageList[0].TVFileLanguageID, tvFileLanguage.TVFileLanguageID);

                // testing Post(TVFileLanguage tvFileLanguage)
                tvFileLanguage.TVFileLanguageID = 0;
                var actionTVFileLanguageNew = await tvFileLanguageController.Post(tvFileLanguage);
                Assert.Equal(200, ((ObjectResult)actionTVFileLanguageNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionTVFileLanguageNew.Result).Value);
                TVFileLanguage tvFileLanguageNew = (TVFileLanguage)((OkObjectResult)actionTVFileLanguageNew.Result).Value;
                Assert.NotNull(tvFileLanguageNew);

                // testing Put(TVFileLanguage tvFileLanguage)
                var actionTVFileLanguageUpdate = await tvFileLanguageController.Put(tvFileLanguageNew);
                Assert.Equal(200, ((ObjectResult)actionTVFileLanguageUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionTVFileLanguageUpdate.Result).Value);
                TVFileLanguage tvFileLanguageUpdate = (TVFileLanguage)((OkObjectResult)actionTVFileLanguageUpdate.Result).Value;
                Assert.NotNull(tvFileLanguageUpdate);

                // testing Delete(int tvFileLanguage.TVFileLanguageID)
                var actionTVFileLanguageDelete = await tvFileLanguageController.Delete(tvFileLanguageUpdate.TVFileLanguageID);
                Assert.Equal(200, ((ObjectResult)actionTVFileLanguageDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionTVFileLanguageDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionTVFileLanguageDelete.Result).Value;
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
            Services.AddSingleton<ITVFileLanguageService, TVFileLanguageService>();
            Services.AddSingleton<ITVFileLanguageController, TVFileLanguageController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            tvFileLanguageService = Provider.GetService<ITVFileLanguageService>();
            Assert.NotNull(tvFileLanguageService);

            tvFileLanguageController = Provider.GetService<ITVFileLanguageController>();
            Assert.NotNull(tvFileLanguageController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
