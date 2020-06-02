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
    public partial class HelpDocControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IHelpDocService helpDocService { get; set; }
        private IHelpDocController helpDocController { get; set; }
        #endregion Properties

        #region Constructors
        public HelpDocControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task HelpDocController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(helpDocService);
            Assert.NotNull(helpDocController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task HelpDocController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionHelpDocList = await helpDocController.Get();
               Assert.Equal(200, ((ObjectResult)actionHelpDocList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHelpDocList.Result).Value);
               List<HelpDoc> helpDocList = (List<HelpDoc>)(((OkObjectResult)actionHelpDocList.Result).Value);

               int count = ((List<HelpDoc>)((OkObjectResult)actionHelpDocList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(HelpDocID)
               var actionHelpDoc = await helpDocController.Get(helpDocList[0].HelpDocID);
               Assert.Equal(200, ((ObjectResult)actionHelpDoc.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHelpDoc.Result).Value);
               HelpDoc helpDoc = (HelpDoc)(((OkObjectResult)actionHelpDoc.Result).Value);
               Assert.NotNull(helpDoc);
               Assert.Equal(helpDocList[0].HelpDocID, helpDoc.HelpDocID);

               // testing Post(HelpDoc helpDoc)
               helpDoc.HelpDocID = 0;
               var actionHelpDocNew = await helpDocController.Post(helpDoc);
               Assert.Equal(200, ((ObjectResult)actionHelpDocNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHelpDocNew.Result).Value);
               HelpDoc helpDocNew = (HelpDoc)(((OkObjectResult)actionHelpDocNew.Result).Value);
               Assert.NotNull(helpDocNew);

               // testing Put(HelpDoc helpDoc)
               var actionHelpDocUpdate = await helpDocController.Put(helpDocNew);
               Assert.Equal(200, ((ObjectResult)actionHelpDocUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHelpDocUpdate.Result).Value);
               HelpDoc helpDocUpdate = (HelpDoc)(((OkObjectResult)actionHelpDocUpdate.Result).Value);
               Assert.NotNull(helpDocUpdate);

               // testing Delete(HelpDoc helpDoc)
               var actionHelpDocDelete = await helpDocController.Delete(helpDocUpdate);
               Assert.Equal(200, ((ObjectResult)actionHelpDocDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHelpDocDelete.Result).Value);
               HelpDoc helpDocDelete = (HelpDoc)(((OkObjectResult)actionHelpDocDelete.Result).Value);
               Assert.NotNull(helpDocDelete);
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
            Services.AddSingleton<IHelpDocService, HelpDocService>();
            Services.AddSingleton<IHelpDocController, HelpDocController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            helpDocService = Provider.GetService<IHelpDocService>();
            Assert.NotNull(helpDocService);
        
            await helpDocService.SetCulture(culture);
        
            helpDocController = Provider.GetService<IHelpDocController>();
            Assert.NotNull(helpDocController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
