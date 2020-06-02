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
    public partial class MWQMSubsectorControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMWQMSubsectorService mwqmSubsectorService { get; set; }
        private IMWQMSubsectorController mwqmSubsectorController { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSubsectorController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mwqmSubsectorService);
            Assert.NotNull(mwqmSubsectorController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSubsectorController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMWQMSubsectorList = await mwqmSubsectorController.Get();
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsectorList.Result).Value);
               List<MWQMSubsector> mwqmSubsectorList = (List<MWQMSubsector>)(((OkObjectResult)actionMWQMSubsectorList.Result).Value);

               int count = ((List<MWQMSubsector>)((OkObjectResult)actionMWQMSubsectorList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MWQMSubsectorID)
               var actionMWQMSubsector = await mwqmSubsectorController.Get(mwqmSubsectorList[0].MWQMSubsectorID);
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsector.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsector.Result).Value);
               MWQMSubsector mwqmSubsector = (MWQMSubsector)(((OkObjectResult)actionMWQMSubsector.Result).Value);
               Assert.NotNull(mwqmSubsector);
               Assert.Equal(mwqmSubsectorList[0].MWQMSubsectorID, mwqmSubsector.MWQMSubsectorID);

               // testing Post(MWQMSubsector mwqmSubsector)
               mwqmSubsector.MWQMSubsectorID = 0;
               var actionMWQMSubsectorNew = await mwqmSubsectorController.Post(mwqmSubsector);
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsectorNew.Result).Value);
               MWQMSubsector mwqmSubsectorNew = (MWQMSubsector)(((OkObjectResult)actionMWQMSubsectorNew.Result).Value);
               Assert.NotNull(mwqmSubsectorNew);

               // testing Put(MWQMSubsector mwqmSubsector)
               var actionMWQMSubsectorUpdate = await mwqmSubsectorController.Put(mwqmSubsectorNew);
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsectorUpdate.Result).Value);
               MWQMSubsector mwqmSubsectorUpdate = (MWQMSubsector)(((OkObjectResult)actionMWQMSubsectorUpdate.Result).Value);
               Assert.NotNull(mwqmSubsectorUpdate);

               // testing Delete(MWQMSubsector mwqmSubsector)
               var actionMWQMSubsectorDelete = await mwqmSubsectorController.Delete(mwqmSubsectorUpdate);
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsectorDelete.Result).Value);
               MWQMSubsector mwqmSubsectorDelete = (MWQMSubsector)(((OkObjectResult)actionMWQMSubsectorDelete.Result).Value);
               Assert.NotNull(mwqmSubsectorDelete);
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
            Services.AddSingleton<IMWQMSubsectorService, MWQMSubsectorService>();
            Services.AddSingleton<IMWQMSubsectorController, MWQMSubsectorController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mwqmSubsectorService = Provider.GetService<IMWQMSubsectorService>();
            Assert.NotNull(mwqmSubsectorService);
        
            await mwqmSubsectorService.SetCulture(culture);
        
            mwqmSubsectorController = Provider.GetService<IMWQMSubsectorController>();
            Assert.NotNull(mwqmSubsectorController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
