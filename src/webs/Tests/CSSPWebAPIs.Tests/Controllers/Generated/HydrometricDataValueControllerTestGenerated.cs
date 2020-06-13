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
    public partial class HydrometricDataValueControllerTest
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
        private IHydrometricDataValueService hydrometricDataValueService { get; set; }
        private IHydrometricDataValueController hydrometricDataValueController { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricDataValueControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task HydrometricDataValueController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(hydrometricDataValueService);
            Assert.NotNull(hydrometricDataValueController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task HydrometricDataValueController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionHydrometricDataValueList = await hydrometricDataValueController.Get();
                Assert.Equal(200, ((ObjectResult)actionHydrometricDataValueList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionHydrometricDataValueList.Result).Value);
                List<HydrometricDataValue> hydrometricDataValueList = (List<HydrometricDataValue>)((OkObjectResult)actionHydrometricDataValueList.Result).Value;

                int count = ((List<HydrometricDataValue>)((OkObjectResult)actionHydrometricDataValueList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(HydrometricDataValueID)
                var actionHydrometricDataValue = await hydrometricDataValueController.Get(hydrometricDataValueList[0].HydrometricDataValueID);
                Assert.Equal(200, ((ObjectResult)actionHydrometricDataValue.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionHydrometricDataValue.Result).Value);
                HydrometricDataValue hydrometricDataValue = (HydrometricDataValue)((OkObjectResult)actionHydrometricDataValue.Result).Value;
                Assert.NotNull(hydrometricDataValue);
                Assert.Equal(hydrometricDataValueList[0].HydrometricDataValueID, hydrometricDataValue.HydrometricDataValueID);

                // testing Post(HydrometricDataValue hydrometricDataValue)
                hydrometricDataValue.HydrometricDataValueID = 0;
                var actionHydrometricDataValueNew = await hydrometricDataValueController.Post(hydrometricDataValue);
                Assert.Equal(200, ((ObjectResult)actionHydrometricDataValueNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionHydrometricDataValueNew.Result).Value);
                HydrometricDataValue hydrometricDataValueNew = (HydrometricDataValue)((OkObjectResult)actionHydrometricDataValueNew.Result).Value;
                Assert.NotNull(hydrometricDataValueNew);

                // testing Put(HydrometricDataValue hydrometricDataValue)
                var actionHydrometricDataValueUpdate = await hydrometricDataValueController.Put(hydrometricDataValueNew);
                Assert.Equal(200, ((ObjectResult)actionHydrometricDataValueUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionHydrometricDataValueUpdate.Result).Value);
                HydrometricDataValue hydrometricDataValueUpdate = (HydrometricDataValue)((OkObjectResult)actionHydrometricDataValueUpdate.Result).Value;
                Assert.NotNull(hydrometricDataValueUpdate);

                // testing Delete(int hydrometricDataValue.HydrometricDataValueID)
                var actionHydrometricDataValueDelete = await hydrometricDataValueController.Delete(hydrometricDataValueUpdate.HydrometricDataValueID);
                Assert.Equal(200, ((ObjectResult)actionHydrometricDataValueDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionHydrometricDataValueDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionHydrometricDataValueDelete.Result).Value;
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
            Services.AddSingleton<IHydrometricDataValueService, HydrometricDataValueService>();
            Services.AddSingleton<IHydrometricDataValueController, HydrometricDataValueController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            hydrometricDataValueService = Provider.GetService<IHydrometricDataValueService>();
            Assert.NotNull(hydrometricDataValueService);

            hydrometricDataValueController = Provider.GetService<IHydrometricDataValueController>();
            Assert.NotNull(hydrometricDataValueController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
