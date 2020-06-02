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
    public partial class VPResultControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IVPResultService vpResultService { get; set; }
        private IVPResultController vpResultController { get; set; }
        #endregion Properties

        #region Constructors
        public VPResultControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task VPResultController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(vpResultService);
            Assert.NotNull(vpResultController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task VPResultController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionVPResultList = await vpResultController.Get();
               Assert.Equal(200, ((ObjectResult)actionVPResultList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPResultList.Result).Value);
               List<VPResult> vpResultList = (List<VPResult>)(((OkObjectResult)actionVPResultList.Result).Value);

               int count = ((List<VPResult>)((OkObjectResult)actionVPResultList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(VPResultID)
               var actionVPResult = await vpResultController.Get(vpResultList[0].VPResultID);
               Assert.Equal(200, ((ObjectResult)actionVPResult.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPResult.Result).Value);
               VPResult vpResult = (VPResult)(((OkObjectResult)actionVPResult.Result).Value);
               Assert.NotNull(vpResult);
               Assert.Equal(vpResultList[0].VPResultID, vpResult.VPResultID);

               // testing Post(VPResult vpResult)
               vpResult.VPResultID = 0;
               var actionVPResultNew = await vpResultController.Post(vpResult);
               Assert.Equal(200, ((ObjectResult)actionVPResultNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPResultNew.Result).Value);
               VPResult vpResultNew = (VPResult)(((OkObjectResult)actionVPResultNew.Result).Value);
               Assert.NotNull(vpResultNew);

               // testing Put(VPResult vpResult)
               var actionVPResultUpdate = await vpResultController.Put(vpResultNew);
               Assert.Equal(200, ((ObjectResult)actionVPResultUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPResultUpdate.Result).Value);
               VPResult vpResultUpdate = (VPResult)(((OkObjectResult)actionVPResultUpdate.Result).Value);
               Assert.NotNull(vpResultUpdate);

               // testing Delete(VPResult vpResult)
               var actionVPResultDelete = await vpResultController.Delete(vpResultUpdate);
               Assert.Equal(200, ((ObjectResult)actionVPResultDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPResultDelete.Result).Value);
               VPResult vpResultDelete = (VPResult)(((OkObjectResult)actionVPResultDelete.Result).Value);
               Assert.NotNull(vpResultDelete);
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
            Services.AddSingleton<IVPResultService, VPResultService>();
            Services.AddSingleton<IVPResultController, VPResultController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            vpResultService = Provider.GetService<IVPResultService>();
            Assert.NotNull(vpResultService);
        
            await vpResultService.SetCulture(culture);
        
            vpResultController = Provider.GetService<IVPResultController>();
            Assert.NotNull(vpResultController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
