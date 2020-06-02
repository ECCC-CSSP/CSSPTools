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
    public partial class LabSheetControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ILabSheetService labSheetService { get; set; }
        private ILabSheetController labSheetController { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task LabSheetController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(labSheetService);
            Assert.NotNull(labSheetController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task LabSheetController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionLabSheetList = await labSheetController.Get();
               Assert.Equal(200, ((ObjectResult)actionLabSheetList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetList.Result).Value);
               List<LabSheet> labSheetList = (List<LabSheet>)(((OkObjectResult)actionLabSheetList.Result).Value);

               int count = ((List<LabSheet>)((OkObjectResult)actionLabSheetList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(LabSheetID)
               var actionLabSheet = await labSheetController.Get(labSheetList[0].LabSheetID);
               Assert.Equal(200, ((ObjectResult)actionLabSheet.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheet.Result).Value);
               LabSheet labSheet = (LabSheet)(((OkObjectResult)actionLabSheet.Result).Value);
               Assert.NotNull(labSheet);
               Assert.Equal(labSheetList[0].LabSheetID, labSheet.LabSheetID);

               // testing Post(LabSheet labSheet)
               labSheet.LabSheetID = 0;
               var actionLabSheetNew = await labSheetController.Post(labSheet);
               Assert.Equal(200, ((ObjectResult)actionLabSheetNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetNew.Result).Value);
               LabSheet labSheetNew = (LabSheet)(((OkObjectResult)actionLabSheetNew.Result).Value);
               Assert.NotNull(labSheetNew);

               // testing Put(LabSheet labSheet)
               var actionLabSheetUpdate = await labSheetController.Put(labSheetNew);
               Assert.Equal(200, ((ObjectResult)actionLabSheetUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetUpdate.Result).Value);
               LabSheet labSheetUpdate = (LabSheet)(((OkObjectResult)actionLabSheetUpdate.Result).Value);
               Assert.NotNull(labSheetUpdate);

               // testing Delete(LabSheet labSheet)
               var actionLabSheetDelete = await labSheetController.Delete(labSheetUpdate);
               Assert.Equal(200, ((ObjectResult)actionLabSheetDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetDelete.Result).Value);
               LabSheet labSheetDelete = (LabSheet)(((OkObjectResult)actionLabSheetDelete.Result).Value);
               Assert.NotNull(labSheetDelete);
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
            Services.AddSingleton<ILabSheetService, LabSheetService>();
            Services.AddSingleton<ILabSheetController, LabSheetController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            labSheetService = Provider.GetService<ILabSheetService>();
            Assert.NotNull(labSheetService);
        
            await labSheetService.SetCulture(culture);
        
            labSheetController = Provider.GetService<ILabSheetController>();
            Assert.NotNull(labSheetController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
