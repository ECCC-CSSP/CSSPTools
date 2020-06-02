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
    public partial class MWQMRunControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMWQMRunService mwqmRunService { get; set; }
        private IMWQMRunController mwqmRunController { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMRunController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mwqmRunService);
            Assert.NotNull(mwqmRunController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMRunController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMWQMRunList = await mwqmRunController.Get();
               Assert.Equal(200, ((ObjectResult)actionMWQMRunList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMRunList.Result).Value);
               List<MWQMRun> mwqmRunList = (List<MWQMRun>)(((OkObjectResult)actionMWQMRunList.Result).Value);

               int count = ((List<MWQMRun>)((OkObjectResult)actionMWQMRunList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MWQMRunID)
               var actionMWQMRun = await mwqmRunController.Get(mwqmRunList[0].MWQMRunID);
               Assert.Equal(200, ((ObjectResult)actionMWQMRun.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMRun.Result).Value);
               MWQMRun mwqmRun = (MWQMRun)(((OkObjectResult)actionMWQMRun.Result).Value);
               Assert.NotNull(mwqmRun);
               Assert.Equal(mwqmRunList[0].MWQMRunID, mwqmRun.MWQMRunID);

               // testing Post(MWQMRun mwqmRun)
               mwqmRun.MWQMRunID = 0;
               var actionMWQMRunNew = await mwqmRunController.Post(mwqmRun);
               Assert.Equal(200, ((ObjectResult)actionMWQMRunNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMRunNew.Result).Value);
               MWQMRun mwqmRunNew = (MWQMRun)(((OkObjectResult)actionMWQMRunNew.Result).Value);
               Assert.NotNull(mwqmRunNew);

               // testing Put(MWQMRun mwqmRun)
               var actionMWQMRunUpdate = await mwqmRunController.Put(mwqmRunNew);
               Assert.Equal(200, ((ObjectResult)actionMWQMRunUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMRunUpdate.Result).Value);
               MWQMRun mwqmRunUpdate = (MWQMRun)(((OkObjectResult)actionMWQMRunUpdate.Result).Value);
               Assert.NotNull(mwqmRunUpdate);

               // testing Delete(MWQMRun mwqmRun)
               var actionMWQMRunDelete = await mwqmRunController.Delete(mwqmRunUpdate);
               Assert.Equal(200, ((ObjectResult)actionMWQMRunDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMRunDelete.Result).Value);
               MWQMRun mwqmRunDelete = (MWQMRun)(((OkObjectResult)actionMWQMRunDelete.Result).Value);
               Assert.NotNull(mwqmRunDelete);
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
            Services.AddSingleton<IMWQMRunService, MWQMRunService>();
            Services.AddSingleton<IMWQMRunController, MWQMRunController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mwqmRunService = Provider.GetService<IMWQMRunService>();
            Assert.NotNull(mwqmRunService);
        
            await mwqmRunService.SetCulture(culture);
        
            mwqmRunController = Provider.GetService<IMWQMRunController>();
            Assert.NotNull(mwqmRunController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
