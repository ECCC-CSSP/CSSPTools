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
    public partial class LabSheetDetailControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ILabSheetDetailService labSheetDetailService { get; set; }
        private ILabSheetDetailController labSheetDetailController { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task LabSheetDetailController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(labSheetDetailService);
            Assert.NotNull(labSheetDetailController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task LabSheetDetailController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionLabSheetDetailList = await labSheetDetailController.Get();
               Assert.Equal(200, ((ObjectResult)actionLabSheetDetailList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetDetailList.Result).Value);
               List<LabSheetDetail> labSheetDetailList = (List<LabSheetDetail>)(((OkObjectResult)actionLabSheetDetailList.Result).Value);

               int count = ((List<LabSheetDetail>)((OkObjectResult)actionLabSheetDetailList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(LabSheetDetailID)
               var actionLabSheetDetail = await labSheetDetailController.Get(labSheetDetailList[0].LabSheetDetailID);
               Assert.Equal(200, ((ObjectResult)actionLabSheetDetail.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetDetail.Result).Value);
               LabSheetDetail labSheetDetail = (LabSheetDetail)(((OkObjectResult)actionLabSheetDetail.Result).Value);
               Assert.NotNull(labSheetDetail);
               Assert.Equal(labSheetDetailList[0].LabSheetDetailID, labSheetDetail.LabSheetDetailID);

               // testing Post(LabSheetDetail labSheetDetail)
               labSheetDetail.LabSheetDetailID = 0;
               var actionLabSheetDetailNew = await labSheetDetailController.Post(labSheetDetail);
               Assert.Equal(200, ((ObjectResult)actionLabSheetDetailNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetDetailNew.Result).Value);
               LabSheetDetail labSheetDetailNew = (LabSheetDetail)(((OkObjectResult)actionLabSheetDetailNew.Result).Value);
               Assert.NotNull(labSheetDetailNew);

               // testing Put(LabSheetDetail labSheetDetail)
               var actionLabSheetDetailUpdate = await labSheetDetailController.Put(labSheetDetailNew);
               Assert.Equal(200, ((ObjectResult)actionLabSheetDetailUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetDetailUpdate.Result).Value);
               LabSheetDetail labSheetDetailUpdate = (LabSheetDetail)(((OkObjectResult)actionLabSheetDetailUpdate.Result).Value);
               Assert.NotNull(labSheetDetailUpdate);

               // testing Delete(LabSheetDetail labSheetDetail)
               var actionLabSheetDetailDelete = await labSheetDetailController.Delete(labSheetDetailUpdate);
               Assert.Equal(200, ((ObjectResult)actionLabSheetDetailDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetDetailDelete.Result).Value);
               LabSheetDetail labSheetDetailDelete = (LabSheetDetail)(((OkObjectResult)actionLabSheetDetailDelete.Result).Value);
               Assert.NotNull(labSheetDetailDelete);
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
            Services.AddSingleton<ILabSheetDetailService, LabSheetDetailService>();
            Services.AddSingleton<ILabSheetDetailController, LabSheetDetailController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            labSheetDetailService = Provider.GetService<ILabSheetDetailService>();
            Assert.NotNull(labSheetDetailService);
        
            await labSheetDetailService.SetCulture(culture);
        
            labSheetDetailController = Provider.GetService<ILabSheetDetailController>();
            Assert.NotNull(labSheetDetailController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
