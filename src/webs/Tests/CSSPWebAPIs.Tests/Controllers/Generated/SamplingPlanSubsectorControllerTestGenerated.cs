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
    public partial class SamplingPlanSubsectorControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ISamplingPlanSubsectorService samplingPlanSubsectorService { get; set; }
        private ISamplingPlanSubsectorController samplingPlanSubsectorController { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SamplingPlanSubsectorController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(samplingPlanSubsectorService);
            Assert.NotNull(samplingPlanSubsectorController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SamplingPlanSubsectorController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionSamplingPlanSubsectorList = await samplingPlanSubsectorController.Get();
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorList.Result).Value);
               List<SamplingPlanSubsector> samplingPlanSubsectorList = (List<SamplingPlanSubsector>)(((OkObjectResult)actionSamplingPlanSubsectorList.Result).Value);

               int count = ((List<SamplingPlanSubsector>)((OkObjectResult)actionSamplingPlanSubsectorList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(SamplingPlanSubsectorID)
               var actionSamplingPlanSubsector = await samplingPlanSubsectorController.Get(samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsector.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsector.Result).Value);
               SamplingPlanSubsector samplingPlanSubsector = (SamplingPlanSubsector)(((OkObjectResult)actionSamplingPlanSubsector.Result).Value);
               Assert.NotNull(samplingPlanSubsector);
               Assert.Equal(samplingPlanSubsectorList[0].SamplingPlanSubsectorID, samplingPlanSubsector.SamplingPlanSubsectorID);

               // testing Post(SamplingPlanSubsector samplingPlanSubsector)
               samplingPlanSubsector.SamplingPlanSubsectorID = 0;
               var actionSamplingPlanSubsectorNew = await samplingPlanSubsectorController.Post(samplingPlanSubsector);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorNew.Result).Value);
               SamplingPlanSubsector samplingPlanSubsectorNew = (SamplingPlanSubsector)(((OkObjectResult)actionSamplingPlanSubsectorNew.Result).Value);
               Assert.NotNull(samplingPlanSubsectorNew);

               // testing Put(SamplingPlanSubsector samplingPlanSubsector)
               var actionSamplingPlanSubsectorUpdate = await samplingPlanSubsectorController.Put(samplingPlanSubsectorNew);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorUpdate.Result).Value);
               SamplingPlanSubsector samplingPlanSubsectorUpdate = (SamplingPlanSubsector)(((OkObjectResult)actionSamplingPlanSubsectorUpdate.Result).Value);
               Assert.NotNull(samplingPlanSubsectorUpdate);

               // testing Delete(SamplingPlanSubsector samplingPlanSubsector)
               var actionSamplingPlanSubsectorDelete = await samplingPlanSubsectorController.Delete(samplingPlanSubsectorUpdate);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorDelete.Result).Value);
               SamplingPlanSubsector samplingPlanSubsectorDelete = (SamplingPlanSubsector)(((OkObjectResult)actionSamplingPlanSubsectorDelete.Result).Value);
               Assert.NotNull(samplingPlanSubsectorDelete);
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
            Services.AddSingleton<ISamplingPlanSubsectorService, SamplingPlanSubsectorService>();
            Services.AddSingleton<ISamplingPlanSubsectorController, SamplingPlanSubsectorController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            samplingPlanSubsectorService = Provider.GetService<ISamplingPlanSubsectorService>();
            Assert.NotNull(samplingPlanSubsectorService);
        
            await samplingPlanSubsectorService.SetCulture(culture);
        
            samplingPlanSubsectorController = Provider.GetService<ISamplingPlanSubsectorController>();
            Assert.NotNull(samplingPlanSubsectorController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
