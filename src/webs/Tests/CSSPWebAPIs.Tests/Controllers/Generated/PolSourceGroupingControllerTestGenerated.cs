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
    public partial class PolSourceGroupingControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IPolSourceGroupingService polSourceGroupingService { get; set; }
        private IPolSourceGroupingController polSourceGroupingController { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceGroupingController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(polSourceGroupingService);
            Assert.NotNull(polSourceGroupingController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceGroupingController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionPolSourceGroupingList = await polSourceGroupingController.Get();
               Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGroupingList.Result).Value);
               List<PolSourceGrouping> polSourceGroupingList = (List<PolSourceGrouping>)(((OkObjectResult)actionPolSourceGroupingList.Result).Value);

               int count = ((List<PolSourceGrouping>)((OkObjectResult)actionPolSourceGroupingList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(PolSourceGroupingID)
               var actionPolSourceGrouping = await polSourceGroupingController.Get(polSourceGroupingList[0].PolSourceGroupingID);
               Assert.Equal(200, ((ObjectResult)actionPolSourceGrouping.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGrouping.Result).Value);
               PolSourceGrouping polSourceGrouping = (PolSourceGrouping)(((OkObjectResult)actionPolSourceGrouping.Result).Value);
               Assert.NotNull(polSourceGrouping);
               Assert.Equal(polSourceGroupingList[0].PolSourceGroupingID, polSourceGrouping.PolSourceGroupingID);

               // testing Post(PolSourceGrouping polSourceGrouping)
               polSourceGrouping.PolSourceGroupingID = 0;
               var actionPolSourceGroupingNew = await polSourceGroupingController.Post(polSourceGrouping);
               Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGroupingNew.Result).Value);
               PolSourceGrouping polSourceGroupingNew = (PolSourceGrouping)(((OkObjectResult)actionPolSourceGroupingNew.Result).Value);
               Assert.NotNull(polSourceGroupingNew);

               // testing Put(PolSourceGrouping polSourceGrouping)
               var actionPolSourceGroupingUpdate = await polSourceGroupingController.Put(polSourceGroupingNew);
               Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGroupingUpdate.Result).Value);
               PolSourceGrouping polSourceGroupingUpdate = (PolSourceGrouping)(((OkObjectResult)actionPolSourceGroupingUpdate.Result).Value);
               Assert.NotNull(polSourceGroupingUpdate);

               // testing Delete(PolSourceGrouping polSourceGrouping)
               var actionPolSourceGroupingDelete = await polSourceGroupingController.Delete(polSourceGroupingUpdate);
               Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGroupingDelete.Result).Value);
               PolSourceGrouping polSourceGroupingDelete = (PolSourceGrouping)(((OkObjectResult)actionPolSourceGroupingDelete.Result).Value);
               Assert.NotNull(polSourceGroupingDelete);
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
            Services.AddSingleton<IPolSourceGroupingService, PolSourceGroupingService>();
            Services.AddSingleton<IPolSourceGroupingController, PolSourceGroupingController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            polSourceGroupingService = Provider.GetService<IPolSourceGroupingService>();
            Assert.NotNull(polSourceGroupingService);
        
            await polSourceGroupingService.SetCulture(culture);
        
            polSourceGroupingController = Provider.GetService<IPolSourceGroupingController>();
            Assert.NotNull(polSourceGroupingController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
