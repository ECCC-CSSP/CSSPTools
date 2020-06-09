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
    public partial class BoxModelControllerTest
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
        private IBoxModelService boxModelService { get; set; }
        private IBoxModelController boxModelController { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task BoxModelController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(boxModelService);
            Assert.NotNull(boxModelController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task BoxModelController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionBoxModelList = await boxModelController.Get();
                Assert.Equal(200, ((ObjectResult)actionBoxModelList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionBoxModelList.Result).Value);
                List<BoxModel> boxModelList = (List<BoxModel>)((OkObjectResult)actionBoxModelList.Result).Value;

                int count = ((List<BoxModel>)((OkObjectResult)actionBoxModelList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(BoxModelID)
                var actionBoxModel = await boxModelController.Get(boxModelList[0].BoxModelID);
                Assert.Equal(200, ((ObjectResult)actionBoxModel.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionBoxModel.Result).Value);
                BoxModel boxModel = (BoxModel)((OkObjectResult)actionBoxModel.Result).Value;
                Assert.NotNull(boxModel);
                Assert.Equal(boxModelList[0].BoxModelID, boxModel.BoxModelID);

                // testing Post(BoxModel boxModel)
                boxModel.BoxModelID = 0;
                var actionBoxModelNew = await boxModelController.Post(boxModel);
                Assert.Equal(200, ((ObjectResult)actionBoxModelNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionBoxModelNew.Result).Value);
                BoxModel boxModelNew = (BoxModel)((OkObjectResult)actionBoxModelNew.Result).Value;
                Assert.NotNull(boxModelNew);

                // testing Put(BoxModel boxModel)
                var actionBoxModelUpdate = await boxModelController.Put(boxModelNew);
                Assert.Equal(200, ((ObjectResult)actionBoxModelUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionBoxModelUpdate.Result).Value);
                BoxModel boxModelUpdate = (BoxModel)((OkObjectResult)actionBoxModelUpdate.Result).Value;
                Assert.NotNull(boxModelUpdate);

                // testing Delete(int boxModel.BoxModelID)
                var actionBoxModelDelete = await boxModelController.Delete(boxModelUpdate.BoxModelID);
                Assert.Equal(200, ((ObjectResult)actionBoxModelDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionBoxModelDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionBoxModelDelete.Result).Value;
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
            Services.AddSingleton<IBoxModelService, BoxModelService>();
            Services.AddSingleton<IBoxModelController, BoxModelController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            boxModelService = Provider.GetService<IBoxModelService>();
            Assert.NotNull(boxModelService);

            boxModelController = Provider.GetService<IBoxModelController>();
            Assert.NotNull(boxModelController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
