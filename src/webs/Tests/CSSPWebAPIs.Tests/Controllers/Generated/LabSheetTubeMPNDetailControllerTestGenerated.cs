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
    public partial class LabSheetTubeMPNDetailControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ILabSheetTubeMPNDetailService labSheetTubeMPNDetailService { get; set; }
        private ILabSheetTubeMPNDetailController labSheetTubeMPNDetailController { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task LabSheetTubeMPNDetailController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(labSheetTubeMPNDetailService);
            Assert.NotNull(labSheetTubeMPNDetailController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task LabSheetTubeMPNDetailController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionLabSheetTubeMPNDetailList = await labSheetTubeMPNDetailController.Get();
               Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value);
               List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = (List<LabSheetTubeMPNDetail>)(((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value);

               int count = ((List<LabSheetTubeMPNDetail>)((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(LabSheetTubeMPNDetailID)
               var actionLabSheetTubeMPNDetail = await labSheetTubeMPNDetailController.Get(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
               Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetail.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetail.Result).Value);
               LabSheetTubeMPNDetail labSheetTubeMPNDetail = (LabSheetTubeMPNDetail)(((OkObjectResult)actionLabSheetTubeMPNDetail.Result).Value);
               Assert.NotNull(labSheetTubeMPNDetail);
               Assert.Equal(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetail.LabSheetTubeMPNDetailID);

               // testing Post(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
               labSheetTubeMPNDetail.LabSheetTubeMPNDetailID = 0;
               var actionLabSheetTubeMPNDetailNew = await labSheetTubeMPNDetailController.Post(labSheetTubeMPNDetail);
               Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailNew.Result).Value);
               LabSheetTubeMPNDetail labSheetTubeMPNDetailNew = (LabSheetTubeMPNDetail)(((OkObjectResult)actionLabSheetTubeMPNDetailNew.Result).Value);
               Assert.NotNull(labSheetTubeMPNDetailNew);

               // testing Put(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
               var actionLabSheetTubeMPNDetailUpdate = await labSheetTubeMPNDetailController.Put(labSheetTubeMPNDetailNew);
               Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailUpdate.Result).Value);
               LabSheetTubeMPNDetail labSheetTubeMPNDetailUpdate = (LabSheetTubeMPNDetail)(((OkObjectResult)actionLabSheetTubeMPNDetailUpdate.Result).Value);
               Assert.NotNull(labSheetTubeMPNDetailUpdate);

               // testing Delete(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
               var actionLabSheetTubeMPNDetailDelete = await labSheetTubeMPNDetailController.Delete(labSheetTubeMPNDetailUpdate);
               Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailDelete.Result).Value);
               LabSheetTubeMPNDetail labSheetTubeMPNDetailDelete = (LabSheetTubeMPNDetail)(((OkObjectResult)actionLabSheetTubeMPNDetailDelete.Result).Value);
               Assert.NotNull(labSheetTubeMPNDetailDelete);
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
            Services.AddSingleton<ILabSheetTubeMPNDetailService, LabSheetTubeMPNDetailService>();
            Services.AddSingleton<ILabSheetTubeMPNDetailController, LabSheetTubeMPNDetailController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            labSheetTubeMPNDetailService = Provider.GetService<ILabSheetTubeMPNDetailService>();
            Assert.NotNull(labSheetTubeMPNDetailService);
        
            await labSheetTubeMPNDetailService.SetCulture(culture);
        
            labSheetTubeMPNDetailController = Provider.GetService<ILabSheetTubeMPNDetailController>();
            Assert.NotNull(labSheetTubeMPNDetailController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
