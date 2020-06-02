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
    public partial class RatingCurveControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IRatingCurveService ratingCurveService { get; set; }
        private IRatingCurveController ratingCurveController { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task RatingCurveController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(ratingCurveService);
            Assert.NotNull(ratingCurveController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task RatingCurveController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionRatingCurveList = await ratingCurveController.Get();
               Assert.Equal(200, ((ObjectResult)actionRatingCurveList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionRatingCurveList.Result).Value);
               List<RatingCurve> ratingCurveList = (List<RatingCurve>)(((OkObjectResult)actionRatingCurveList.Result).Value);

               int count = ((List<RatingCurve>)((OkObjectResult)actionRatingCurveList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(RatingCurveID)
               var actionRatingCurve = await ratingCurveController.Get(ratingCurveList[0].RatingCurveID);
               Assert.Equal(200, ((ObjectResult)actionRatingCurve.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionRatingCurve.Result).Value);
               RatingCurve ratingCurve = (RatingCurve)(((OkObjectResult)actionRatingCurve.Result).Value);
               Assert.NotNull(ratingCurve);
               Assert.Equal(ratingCurveList[0].RatingCurveID, ratingCurve.RatingCurveID);

               // testing Post(RatingCurve ratingCurve)
               ratingCurve.RatingCurveID = 0;
               var actionRatingCurveNew = await ratingCurveController.Post(ratingCurve);
               Assert.Equal(200, ((ObjectResult)actionRatingCurveNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionRatingCurveNew.Result).Value);
               RatingCurve ratingCurveNew = (RatingCurve)(((OkObjectResult)actionRatingCurveNew.Result).Value);
               Assert.NotNull(ratingCurveNew);

               // testing Put(RatingCurve ratingCurve)
               var actionRatingCurveUpdate = await ratingCurveController.Put(ratingCurveNew);
               Assert.Equal(200, ((ObjectResult)actionRatingCurveUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionRatingCurveUpdate.Result).Value);
               RatingCurve ratingCurveUpdate = (RatingCurve)(((OkObjectResult)actionRatingCurveUpdate.Result).Value);
               Assert.NotNull(ratingCurveUpdate);

               // testing Delete(RatingCurve ratingCurve)
               var actionRatingCurveDelete = await ratingCurveController.Delete(ratingCurveUpdate);
               Assert.Equal(200, ((ObjectResult)actionRatingCurveDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionRatingCurveDelete.Result).Value);
               RatingCurve ratingCurveDelete = (RatingCurve)(((OkObjectResult)actionRatingCurveDelete.Result).Value);
               Assert.NotNull(ratingCurveDelete);
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
            Services.AddSingleton<IRatingCurveService, RatingCurveService>();
            Services.AddSingleton<IRatingCurveController, RatingCurveController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            ratingCurveService = Provider.GetService<IRatingCurveService>();
            Assert.NotNull(ratingCurveService);
        
            await ratingCurveService.SetCulture(culture);
        
            ratingCurveController = Provider.GetService<IRatingCurveController>();
            Assert.NotNull(ratingCurveController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
