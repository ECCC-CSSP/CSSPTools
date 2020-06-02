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
    public partial class VPAmbientControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IVPAmbientService vpAmbientService { get; set; }
        private IVPAmbientController vpAmbientController { get; set; }
        #endregion Properties

        #region Constructors
        public VPAmbientControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task VPAmbientController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(vpAmbientService);
            Assert.NotNull(vpAmbientController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task VPAmbientController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionVPAmbientList = await vpAmbientController.Get();
               Assert.Equal(200, ((ObjectResult)actionVPAmbientList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPAmbientList.Result).Value);
               List<VPAmbient> vpAmbientList = (List<VPAmbient>)(((OkObjectResult)actionVPAmbientList.Result).Value);

               int count = ((List<VPAmbient>)((OkObjectResult)actionVPAmbientList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(VPAmbientID)
               var actionVPAmbient = await vpAmbientController.Get(vpAmbientList[0].VPAmbientID);
               Assert.Equal(200, ((ObjectResult)actionVPAmbient.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPAmbient.Result).Value);
               VPAmbient vpAmbient = (VPAmbient)(((OkObjectResult)actionVPAmbient.Result).Value);
               Assert.NotNull(vpAmbient);
               Assert.Equal(vpAmbientList[0].VPAmbientID, vpAmbient.VPAmbientID);

               // testing Post(VPAmbient vpAmbient)
               vpAmbient.VPAmbientID = 0;
               var actionVPAmbientNew = await vpAmbientController.Post(vpAmbient);
               Assert.Equal(200, ((ObjectResult)actionVPAmbientNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPAmbientNew.Result).Value);
               VPAmbient vpAmbientNew = (VPAmbient)(((OkObjectResult)actionVPAmbientNew.Result).Value);
               Assert.NotNull(vpAmbientNew);

               // testing Put(VPAmbient vpAmbient)
               var actionVPAmbientUpdate = await vpAmbientController.Put(vpAmbientNew);
               Assert.Equal(200, ((ObjectResult)actionVPAmbientUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPAmbientUpdate.Result).Value);
               VPAmbient vpAmbientUpdate = (VPAmbient)(((OkObjectResult)actionVPAmbientUpdate.Result).Value);
               Assert.NotNull(vpAmbientUpdate);

               // testing Delete(VPAmbient vpAmbient)
               var actionVPAmbientDelete = await vpAmbientController.Delete(vpAmbientUpdate);
               Assert.Equal(200, ((ObjectResult)actionVPAmbientDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPAmbientDelete.Result).Value);
               VPAmbient vpAmbientDelete = (VPAmbient)(((OkObjectResult)actionVPAmbientDelete.Result).Value);
               Assert.NotNull(vpAmbientDelete);
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
            Services.AddSingleton<IVPAmbientService, VPAmbientService>();
            Services.AddSingleton<IVPAmbientController, VPAmbientController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            vpAmbientService = Provider.GetService<IVPAmbientService>();
            Assert.NotNull(vpAmbientService);
        
            await vpAmbientService.SetCulture(culture);
        
            vpAmbientController = Provider.GetService<IVPAmbientController>();
            Assert.NotNull(vpAmbientController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
