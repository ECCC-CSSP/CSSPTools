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
    public partial class SamplingPlanControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ISamplingPlanService samplingPlanService { get; set; }
        private ISamplingPlanController samplingPlanController { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SamplingPlanController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(samplingPlanService);
            Assert.NotNull(samplingPlanController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SamplingPlanController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionSamplingPlanList = await samplingPlanController.Get();
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanList.Result).Value);
               List<SamplingPlan> samplingPlanList = (List<SamplingPlan>)(((OkObjectResult)actionSamplingPlanList.Result).Value);

               int count = ((List<SamplingPlan>)((OkObjectResult)actionSamplingPlanList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(SamplingPlanID)
               var actionSamplingPlan = await samplingPlanController.Get(samplingPlanList[0].SamplingPlanID);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlan.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlan.Result).Value);
               SamplingPlan samplingPlan = (SamplingPlan)(((OkObjectResult)actionSamplingPlan.Result).Value);
               Assert.NotNull(samplingPlan);
               Assert.Equal(samplingPlanList[0].SamplingPlanID, samplingPlan.SamplingPlanID);

               // testing Post(SamplingPlan samplingPlan)
               samplingPlan.SamplingPlanID = 0;
               samplingPlan.SamplingPlanName = samplingPlan.SamplingPlanName.Replace(samplingPlan.Year.ToString(), (samplingPlan.Year + 20).ToString());
               var actionSamplingPlanNew = await samplingPlanController.Post(samplingPlan);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanNew.Result).Value);
               SamplingPlan samplingPlanNew = (SamplingPlan)(((OkObjectResult)actionSamplingPlanNew.Result).Value);
               Assert.NotNull(samplingPlanNew);

               // testing Put(SamplingPlan samplingPlan)
               var actionSamplingPlanUpdate = await samplingPlanController.Put(samplingPlanNew);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanUpdate.Result).Value);
               SamplingPlan samplingPlanUpdate = (SamplingPlan)(((OkObjectResult)actionSamplingPlanUpdate.Result).Value);
               Assert.NotNull(samplingPlanUpdate);

               // testing Delete(SamplingPlan samplingPlan)
               var actionSamplingPlanDelete = await samplingPlanController.Delete(samplingPlanUpdate);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanDelete.Result).Value);
               SamplingPlan samplingPlanDelete = (SamplingPlan)(((OkObjectResult)actionSamplingPlanDelete.Result).Value);
               Assert.NotNull(samplingPlanDelete);
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
            Services.AddSingleton<ISamplingPlanService, SamplingPlanService>();
            Services.AddSingleton<ISamplingPlanController, SamplingPlanController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            samplingPlanService = Provider.GetService<ISamplingPlanService>();
            Assert.NotNull(samplingPlanService);
        
            await samplingPlanService.SetCulture(culture);
        
            samplingPlanController = Provider.GetService<ISamplingPlanController>();
            Assert.NotNull(samplingPlanController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
