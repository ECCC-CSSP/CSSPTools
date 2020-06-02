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
    public partial class SamplingPlanEmailControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ISamplingPlanEmailService samplingPlanEmailService { get; set; }
        private ISamplingPlanEmailController samplingPlanEmailController { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SamplingPlanEmailController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(samplingPlanEmailService);
            Assert.NotNull(samplingPlanEmailController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SamplingPlanEmailController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionSamplingPlanEmailList = await samplingPlanEmailController.Get();
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailList.Result).Value);
               List<SamplingPlanEmail> samplingPlanEmailList = (List<SamplingPlanEmail>)(((OkObjectResult)actionSamplingPlanEmailList.Result).Value);

               int count = ((List<SamplingPlanEmail>)((OkObjectResult)actionSamplingPlanEmailList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(SamplingPlanEmailID)
               var actionSamplingPlanEmail = await samplingPlanEmailController.Get(samplingPlanEmailList[0].SamplingPlanEmailID);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmail.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanEmail.Result).Value);
               SamplingPlanEmail samplingPlanEmail = (SamplingPlanEmail)(((OkObjectResult)actionSamplingPlanEmail.Result).Value);
               Assert.NotNull(samplingPlanEmail);
               Assert.Equal(samplingPlanEmailList[0].SamplingPlanEmailID, samplingPlanEmail.SamplingPlanEmailID);

               // testing Post(SamplingPlanEmail samplingPlanEmail)
               samplingPlanEmail.SamplingPlanEmailID = 0;
               var actionSamplingPlanEmailNew = await samplingPlanEmailController.Post(samplingPlanEmail);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailNew.Result).Value);
               SamplingPlanEmail samplingPlanEmailNew = (SamplingPlanEmail)(((OkObjectResult)actionSamplingPlanEmailNew.Result).Value);
               Assert.NotNull(samplingPlanEmailNew);

               // testing Put(SamplingPlanEmail samplingPlanEmail)
               var actionSamplingPlanEmailUpdate = await samplingPlanEmailController.Put(samplingPlanEmailNew);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailUpdate.Result).Value);
               SamplingPlanEmail samplingPlanEmailUpdate = (SamplingPlanEmail)(((OkObjectResult)actionSamplingPlanEmailUpdate.Result).Value);
               Assert.NotNull(samplingPlanEmailUpdate);

               // testing Delete(SamplingPlanEmail samplingPlanEmail)
               var actionSamplingPlanEmailDelete = await samplingPlanEmailController.Delete(samplingPlanEmailUpdate);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailDelete.Result).Value);
               SamplingPlanEmail samplingPlanEmailDelete = (SamplingPlanEmail)(((OkObjectResult)actionSamplingPlanEmailDelete.Result).Value);
               Assert.NotNull(samplingPlanEmailDelete);
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
            Services.AddSingleton<ISamplingPlanEmailService, SamplingPlanEmailService>();
            Services.AddSingleton<ISamplingPlanEmailController, SamplingPlanEmailController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            samplingPlanEmailService = Provider.GetService<ISamplingPlanEmailService>();
            Assert.NotNull(samplingPlanEmailService);
        
            await samplingPlanEmailService.SetCulture(culture);
        
            samplingPlanEmailController = Provider.GetService<ISamplingPlanEmailController>();
            Assert.NotNull(samplingPlanEmailController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
