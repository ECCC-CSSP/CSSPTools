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
    public partial class MikeBoundaryConditionControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMikeBoundaryConditionService mikeBoundaryConditionService { get; set; }
        private IMikeBoundaryConditionController mikeBoundaryConditionController { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeBoundaryConditionController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mikeBoundaryConditionService);
            Assert.NotNull(mikeBoundaryConditionController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeBoundaryConditionController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMikeBoundaryConditionList = await mikeBoundaryConditionController.Get();
               Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionList.Result).Value);
               List<MikeBoundaryCondition> mikeBoundaryConditionList = (List<MikeBoundaryCondition>)(((OkObjectResult)actionMikeBoundaryConditionList.Result).Value);

               int count = ((List<MikeBoundaryCondition>)((OkObjectResult)actionMikeBoundaryConditionList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MikeBoundaryConditionID)
               var actionMikeBoundaryCondition = await mikeBoundaryConditionController.Get(mikeBoundaryConditionList[0].MikeBoundaryConditionID);
               Assert.Equal(200, ((ObjectResult)actionMikeBoundaryCondition.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeBoundaryCondition.Result).Value);
               MikeBoundaryCondition mikeBoundaryCondition = (MikeBoundaryCondition)(((OkObjectResult)actionMikeBoundaryCondition.Result).Value);
               Assert.NotNull(mikeBoundaryCondition);
               Assert.Equal(mikeBoundaryConditionList[0].MikeBoundaryConditionID, mikeBoundaryCondition.MikeBoundaryConditionID);

               // testing Post(MikeBoundaryCondition mikeBoundaryCondition)
               mikeBoundaryCondition.MikeBoundaryConditionID = 0;
               var actionMikeBoundaryConditionNew = await mikeBoundaryConditionController.Post(mikeBoundaryCondition);
               Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionNew.Result).Value);
               MikeBoundaryCondition mikeBoundaryConditionNew = (MikeBoundaryCondition)(((OkObjectResult)actionMikeBoundaryConditionNew.Result).Value);
               Assert.NotNull(mikeBoundaryConditionNew);

               // testing Put(MikeBoundaryCondition mikeBoundaryCondition)
               var actionMikeBoundaryConditionUpdate = await mikeBoundaryConditionController.Put(mikeBoundaryConditionNew);
               Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionUpdate.Result).Value);
               MikeBoundaryCondition mikeBoundaryConditionUpdate = (MikeBoundaryCondition)(((OkObjectResult)actionMikeBoundaryConditionUpdate.Result).Value);
               Assert.NotNull(mikeBoundaryConditionUpdate);

               // testing Delete(MikeBoundaryCondition mikeBoundaryCondition)
               var actionMikeBoundaryConditionDelete = await mikeBoundaryConditionController.Delete(mikeBoundaryConditionUpdate);
               Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionDelete.Result).Value);
               MikeBoundaryCondition mikeBoundaryConditionDelete = (MikeBoundaryCondition)(((OkObjectResult)actionMikeBoundaryConditionDelete.Result).Value);
               Assert.NotNull(mikeBoundaryConditionDelete);
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
            Services.AddSingleton<IMikeBoundaryConditionService, MikeBoundaryConditionService>();
            Services.AddSingleton<IMikeBoundaryConditionController, MikeBoundaryConditionController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mikeBoundaryConditionService = Provider.GetService<IMikeBoundaryConditionService>();
            Assert.NotNull(mikeBoundaryConditionService);
        
            await mikeBoundaryConditionService.SetCulture(culture);
        
            mikeBoundaryConditionController = Provider.GetService<IMikeBoundaryConditionController>();
            Assert.NotNull(mikeBoundaryConditionController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
