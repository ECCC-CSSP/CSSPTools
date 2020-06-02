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
    public partial class TelControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ITelService telService { get; set; }
        private ITelController telController { get; set; }
        #endregion Properties

        #region Constructors
        public TelControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TelController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(telService);
            Assert.NotNull(telController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TelController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionTelList = await telController.Get();
               Assert.Equal(200, ((ObjectResult)actionTelList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTelList.Result).Value);
               List<Tel> telList = (List<Tel>)(((OkObjectResult)actionTelList.Result).Value);

               int count = ((List<Tel>)((OkObjectResult)actionTelList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(TelID)
               var actionTel = await telController.Get(telList[0].TelID);
               Assert.Equal(200, ((ObjectResult)actionTel.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTel.Result).Value);
               Tel tel = (Tel)(((OkObjectResult)actionTel.Result).Value);
               Assert.NotNull(tel);
               Assert.Equal(telList[0].TelID, tel.TelID);

               // testing Post(Tel tel)
               tel.TelID = 0;
               var actionTelNew = await telController.Post(tel);
               Assert.Equal(200, ((ObjectResult)actionTelNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTelNew.Result).Value);
               Tel telNew = (Tel)(((OkObjectResult)actionTelNew.Result).Value);
               Assert.NotNull(telNew);

               // testing Put(Tel tel)
               var actionTelUpdate = await telController.Put(telNew);
               Assert.Equal(200, ((ObjectResult)actionTelUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTelUpdate.Result).Value);
               Tel telUpdate = (Tel)(((OkObjectResult)actionTelUpdate.Result).Value);
               Assert.NotNull(telUpdate);

               // testing Delete(Tel tel)
               var actionTelDelete = await telController.Delete(telUpdate);
               Assert.Equal(200, ((ObjectResult)actionTelDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTelDelete.Result).Value);
               Tel telDelete = (Tel)(((OkObjectResult)actionTelDelete.Result).Value);
               Assert.NotNull(telDelete);
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
            Services.AddSingleton<ITelService, TelService>();
            Services.AddSingleton<ITelController, TelController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            telService = Provider.GetService<ITelService>();
            Assert.NotNull(telService);
        
            await telService.SetCulture(culture);
        
            telController = Provider.GetService<ITelController>();
            Assert.NotNull(telController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
