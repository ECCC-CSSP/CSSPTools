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
    public partial class DrogueRunPositionControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IDrogueRunPositionService drogueRunPositionService { get; set; }
        private IDrogueRunPositionController drogueRunPositionController { get; set; }
        #endregion Properties

        #region Constructors
        public DrogueRunPositionControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task DrogueRunPositionController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(drogueRunPositionService);
            Assert.NotNull(drogueRunPositionController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task DrogueRunPositionController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionDrogueRunPositionList = await drogueRunPositionController.Get();
               Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDrogueRunPositionList.Result).Value);
               List<DrogueRunPosition> drogueRunPositionList = (List<DrogueRunPosition>)(((OkObjectResult)actionDrogueRunPositionList.Result).Value);

               int count = ((List<DrogueRunPosition>)((OkObjectResult)actionDrogueRunPositionList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(DrogueRunPositionID)
               var actionDrogueRunPosition = await drogueRunPositionController.Get(drogueRunPositionList[0].DrogueRunPositionID);
               Assert.Equal(200, ((ObjectResult)actionDrogueRunPosition.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDrogueRunPosition.Result).Value);
               DrogueRunPosition drogueRunPosition = (DrogueRunPosition)(((OkObjectResult)actionDrogueRunPosition.Result).Value);
               Assert.NotNull(drogueRunPosition);
               Assert.Equal(drogueRunPositionList[0].DrogueRunPositionID, drogueRunPosition.DrogueRunPositionID);

               // testing Post(DrogueRunPosition drogueRunPosition)
               drogueRunPosition.DrogueRunPositionID = 0;
               var actionDrogueRunPositionNew = await drogueRunPositionController.Post(drogueRunPosition);
               Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDrogueRunPositionNew.Result).Value);
               DrogueRunPosition drogueRunPositionNew = (DrogueRunPosition)(((OkObjectResult)actionDrogueRunPositionNew.Result).Value);
               Assert.NotNull(drogueRunPositionNew);

               // testing Put(DrogueRunPosition drogueRunPosition)
               var actionDrogueRunPositionUpdate = await drogueRunPositionController.Put(drogueRunPositionNew);
               Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDrogueRunPositionUpdate.Result).Value);
               DrogueRunPosition drogueRunPositionUpdate = (DrogueRunPosition)(((OkObjectResult)actionDrogueRunPositionUpdate.Result).Value);
               Assert.NotNull(drogueRunPositionUpdate);

               // testing Delete(DrogueRunPosition drogueRunPosition)
               var actionDrogueRunPositionDelete = await drogueRunPositionController.Delete(drogueRunPositionUpdate);
               Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDrogueRunPositionDelete.Result).Value);
               DrogueRunPosition drogueRunPositionDelete = (DrogueRunPosition)(((OkObjectResult)actionDrogueRunPositionDelete.Result).Value);
               Assert.NotNull(drogueRunPositionDelete);
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
            Services.AddSingleton<IDrogueRunPositionService, DrogueRunPositionService>();
            Services.AddSingleton<IDrogueRunPositionController, DrogueRunPositionController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            drogueRunPositionService = Provider.GetService<IDrogueRunPositionService>();
            Assert.NotNull(drogueRunPositionService);
        
            await drogueRunPositionService.SetCulture(culture);
        
            drogueRunPositionController = Provider.GetService<IDrogueRunPositionController>();
            Assert.NotNull(drogueRunPositionController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
