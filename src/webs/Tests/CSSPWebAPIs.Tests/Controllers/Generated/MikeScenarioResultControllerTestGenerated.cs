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
    public partial class MikeScenarioResultControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMikeScenarioResultService mikeScenarioResultService { get; set; }
        private IMikeScenarioResultController mikeScenarioResultController { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioResultControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeScenarioResultController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mikeScenarioResultService);
            Assert.NotNull(mikeScenarioResultController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeScenarioResultController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMikeScenarioResultList = await mikeScenarioResultController.Get();
               Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeScenarioResultList.Result).Value);
               List<MikeScenarioResult> mikeScenarioResultList = (List<MikeScenarioResult>)(((OkObjectResult)actionMikeScenarioResultList.Result).Value);

               int count = ((List<MikeScenarioResult>)((OkObjectResult)actionMikeScenarioResultList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MikeScenarioResultID)
               var actionMikeScenarioResult = await mikeScenarioResultController.Get(mikeScenarioResultList[0].MikeScenarioResultID);
               Assert.Equal(200, ((ObjectResult)actionMikeScenarioResult.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeScenarioResult.Result).Value);
               MikeScenarioResult mikeScenarioResult = (MikeScenarioResult)(((OkObjectResult)actionMikeScenarioResult.Result).Value);
               Assert.NotNull(mikeScenarioResult);
               Assert.Equal(mikeScenarioResultList[0].MikeScenarioResultID, mikeScenarioResult.MikeScenarioResultID);

               // testing Post(MikeScenarioResult mikeScenarioResult)
               mikeScenarioResult.MikeScenarioResultID = 0;
               var actionMikeScenarioResultNew = await mikeScenarioResultController.Post(mikeScenarioResult);
               Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeScenarioResultNew.Result).Value);
               MikeScenarioResult mikeScenarioResultNew = (MikeScenarioResult)(((OkObjectResult)actionMikeScenarioResultNew.Result).Value);
               Assert.NotNull(mikeScenarioResultNew);

               // testing Put(MikeScenarioResult mikeScenarioResult)
               var actionMikeScenarioResultUpdate = await mikeScenarioResultController.Put(mikeScenarioResultNew);
               Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeScenarioResultUpdate.Result).Value);
               MikeScenarioResult mikeScenarioResultUpdate = (MikeScenarioResult)(((OkObjectResult)actionMikeScenarioResultUpdate.Result).Value);
               Assert.NotNull(mikeScenarioResultUpdate);

               // testing Delete(MikeScenarioResult mikeScenarioResult)
               var actionMikeScenarioResultDelete = await mikeScenarioResultController.Delete(mikeScenarioResultUpdate);
               Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeScenarioResultDelete.Result).Value);
               MikeScenarioResult mikeScenarioResultDelete = (MikeScenarioResult)(((OkObjectResult)actionMikeScenarioResultDelete.Result).Value);
               Assert.NotNull(mikeScenarioResultDelete);
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
            Services.AddSingleton<IMikeScenarioResultService, MikeScenarioResultService>();
            Services.AddSingleton<IMikeScenarioResultController, MikeScenarioResultController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mikeScenarioResultService = Provider.GetService<IMikeScenarioResultService>();
            Assert.NotNull(mikeScenarioResultService);
        
            await mikeScenarioResultService.SetCulture(culture);
        
            mikeScenarioResultController = Provider.GetService<IMikeScenarioResultController>();
            Assert.NotNull(mikeScenarioResultController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
