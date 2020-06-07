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
    public partial class RatingCurveValueControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IRatingCurveValueService ratingCurveValueService { get; set; }
        private IRatingCurveValueController ratingCurveValueController { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task RatingCurveValueController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(ratingCurveValueService);
            Assert.NotNull(ratingCurveValueController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task RatingCurveValueController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionRatingCurveValueList = await ratingCurveValueController.Get();
                Assert.Equal(200, ((ObjectResult)actionRatingCurveValueList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRatingCurveValueList.Result).Value);
                List<RatingCurveValue> ratingCurveValueList = (List<RatingCurveValue>)((OkObjectResult)actionRatingCurveValueList.Result).Value;

                int count = ((List<RatingCurveValue>)((OkObjectResult)actionRatingCurveValueList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(RatingCurveValueID)
                var actionRatingCurveValue = await ratingCurveValueController.Get(ratingCurveValueList[0].RatingCurveValueID);
                Assert.Equal(200, ((ObjectResult)actionRatingCurveValue.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRatingCurveValue.Result).Value);
                RatingCurveValue ratingCurveValue = (RatingCurveValue)((OkObjectResult)actionRatingCurveValue.Result).Value;
                Assert.NotNull(ratingCurveValue);
                Assert.Equal(ratingCurveValueList[0].RatingCurveValueID, ratingCurveValue.RatingCurveValueID);

                // testing Post(RatingCurveValue ratingCurveValue)
                ratingCurveValue.RatingCurveValueID = 0;
                var actionRatingCurveValueNew = await ratingCurveValueController.Post(ratingCurveValue);
                Assert.Equal(200, ((ObjectResult)actionRatingCurveValueNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRatingCurveValueNew.Result).Value);
                RatingCurveValue ratingCurveValueNew = (RatingCurveValue)((OkObjectResult)actionRatingCurveValueNew.Result).Value;
                Assert.NotNull(ratingCurveValueNew);

                // testing Put(RatingCurveValue ratingCurveValue)
                var actionRatingCurveValueUpdate = await ratingCurveValueController.Put(ratingCurveValueNew);
                Assert.Equal(200, ((ObjectResult)actionRatingCurveValueUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRatingCurveValueUpdate.Result).Value);
                RatingCurveValue ratingCurveValueUpdate = (RatingCurveValue)((OkObjectResult)actionRatingCurveValueUpdate.Result).Value;
                Assert.NotNull(ratingCurveValueUpdate);

                // testing Delete(int ratingCurveValue.RatingCurveValueID)
                var actionRatingCurveValueDelete = await ratingCurveValueController.Delete(ratingCurveValueUpdate.RatingCurveValueID);
                Assert.Equal(200, ((ObjectResult)actionRatingCurveValueDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRatingCurveValueDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionRatingCurveValueDelete.Result).Value;
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
            Services.AddSingleton<IRatingCurveValueService, RatingCurveValueService>();
            Services.AddSingleton<IRatingCurveValueController, RatingCurveValueController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            ratingCurveValueService = Provider.GetService<IRatingCurveValueService>();
            Assert.NotNull(ratingCurveValueService);

            await ratingCurveValueService.SetCulture(culture);

            ratingCurveValueController = Provider.GetService<IRatingCurveValueController>();
            Assert.NotNull(ratingCurveValueController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
