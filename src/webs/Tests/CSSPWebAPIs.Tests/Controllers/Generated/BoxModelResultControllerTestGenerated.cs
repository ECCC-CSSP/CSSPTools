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
    public partial class BoxModelResultControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IBoxModelResultService boxModelResultService { get; set; }
        private IBoxModelResultController boxModelResultController { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelResultControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task BoxModelResultController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(boxModelResultService);
            Assert.NotNull(boxModelResultController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task BoxModelResultController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionBoxModelResultList = await boxModelResultController.Get();
               Assert.Equal(200, ((ObjectResult)actionBoxModelResultList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelResultList.Result).Value);
               List<BoxModelResult> boxModelResultList = (List<BoxModelResult>)(((OkObjectResult)actionBoxModelResultList.Result).Value);

               int count = ((List<BoxModelResult>)((OkObjectResult)actionBoxModelResultList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(BoxModelResultID)
               var actionBoxModelResult = await boxModelResultController.Get(boxModelResultList[0].BoxModelResultID);
               Assert.Equal(200, ((ObjectResult)actionBoxModelResult.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelResult.Result).Value);
               BoxModelResult boxModelResult = (BoxModelResult)(((OkObjectResult)actionBoxModelResult.Result).Value);
               Assert.NotNull(boxModelResult);
               Assert.Equal(boxModelResultList[0].BoxModelResultID, boxModelResult.BoxModelResultID);

               // testing Post(BoxModelResult boxModelResult)
               boxModelResult.BoxModelResultID = 0;
               var actionBoxModelResultNew = await boxModelResultController.Post(boxModelResult);
               Assert.Equal(200, ((ObjectResult)actionBoxModelResultNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelResultNew.Result).Value);
               BoxModelResult boxModelResultNew = (BoxModelResult)(((OkObjectResult)actionBoxModelResultNew.Result).Value);
               Assert.NotNull(boxModelResultNew);

               // testing Put(BoxModelResult boxModelResult)
               var actionBoxModelResultUpdate = await boxModelResultController.Put(boxModelResultNew);
               Assert.Equal(200, ((ObjectResult)actionBoxModelResultUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelResultUpdate.Result).Value);
               BoxModelResult boxModelResultUpdate = (BoxModelResult)(((OkObjectResult)actionBoxModelResultUpdate.Result).Value);
               Assert.NotNull(boxModelResultUpdate);

               // testing Delete(BoxModelResult boxModelResult)
               var actionBoxModelResultDelete = await boxModelResultController.Delete(boxModelResultUpdate);
               Assert.Equal(200, ((ObjectResult)actionBoxModelResultDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelResultDelete.Result).Value);
               BoxModelResult boxModelResultDelete = (BoxModelResult)(((OkObjectResult)actionBoxModelResultDelete.Result).Value);
               Assert.NotNull(boxModelResultDelete);
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
            Services.AddSingleton<IBoxModelResultService, BoxModelResultService>();
            Services.AddSingleton<IBoxModelResultController, BoxModelResultController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            boxModelResultService = Provider.GetService<IBoxModelResultService>();
            Assert.NotNull(boxModelResultService);
        
            await boxModelResultService.SetCulture(culture);
        
            boxModelResultController = Provider.GetService<IBoxModelResultController>();
            Assert.NotNull(boxModelResultController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
