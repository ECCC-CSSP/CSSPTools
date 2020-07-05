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
    public partial class ClassificationControllerTest
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
        private IClassificationService classificationService { get; set; }
        private IClassificationController classificationController { get; set; }
        #endregion Properties

        #region Constructors
        public ClassificationControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ClassificationController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(classificationService);
            Assert.NotNull(classificationController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ClassificationController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionClassificationList = await classificationController.Get();
                Assert.Equal(200, ((ObjectResult)actionClassificationList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionClassificationList.Result).Value);
                List<Classification> classificationList = (List<Classification>)((OkObjectResult)actionClassificationList.Result).Value;

                int count = ((List<Classification>)((OkObjectResult)actionClassificationList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(ClassificationID)
                var actionClassification = await classificationController.Get(classificationList[0].ClassificationID);
                Assert.Equal(200, ((ObjectResult)actionClassification.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionClassification.Result).Value);
                Classification classification = (Classification)((OkObjectResult)actionClassification.Result).Value;
                Assert.NotNull(classification);
                Assert.Equal(classificationList[0].ClassificationID, classification.ClassificationID);

                // testing Post(Classification classification)
                classification.ClassificationID = 0;
                var actionClassificationNew = await classificationController.Post(classification);
                Assert.Equal(200, ((ObjectResult)actionClassificationNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionClassificationNew.Result).Value);
                Classification classificationNew = (Classification)((OkObjectResult)actionClassificationNew.Result).Value;
                Assert.NotNull(classificationNew);

                // testing Put(Classification classification)
                var actionClassificationUpdate = await classificationController.Put(classificationNew);
                Assert.Equal(200, ((ObjectResult)actionClassificationUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionClassificationUpdate.Result).Value);
                Classification classificationUpdate = (Classification)((OkObjectResult)actionClassificationUpdate.Result).Value;
                Assert.NotNull(classificationUpdate);

                // testing Delete(int classification.ClassificationID)
                var actionClassificationDelete = await classificationController.Delete(classificationUpdate.ClassificationID);
                Assert.Equal(200, ((ObjectResult)actionClassificationDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionClassificationDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionClassificationDelete.Result).Value;
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
            Services.AddSingleton<IClassificationService, ClassificationService>();
            Services.AddSingleton<IClassificationController, ClassificationController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            classificationService = Provider.GetService<IClassificationService>();
            Assert.NotNull(classificationService);

            classificationController = Provider.GetService<IClassificationController>();
            Assert.NotNull(classificationController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
