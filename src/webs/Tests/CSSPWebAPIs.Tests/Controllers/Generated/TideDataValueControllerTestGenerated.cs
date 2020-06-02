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
    public partial class TideDataValueControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ITideDataValueService tideDataValueService { get; set; }
        private ITideDataValueController tideDataValueController { get; set; }
        #endregion Properties

        #region Constructors
        public TideDataValueControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TideDataValueController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(tideDataValueService);
            Assert.NotNull(tideDataValueController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TideDataValueController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionTideDataValueList = await tideDataValueController.Get();
               Assert.Equal(200, ((ObjectResult)actionTideDataValueList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideDataValueList.Result).Value);
               List<TideDataValue> tideDataValueList = (List<TideDataValue>)(((OkObjectResult)actionTideDataValueList.Result).Value);

               int count = ((List<TideDataValue>)((OkObjectResult)actionTideDataValueList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(TideDataValueID)
               var actionTideDataValue = await tideDataValueController.Get(tideDataValueList[0].TideDataValueID);
               Assert.Equal(200, ((ObjectResult)actionTideDataValue.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideDataValue.Result).Value);
               TideDataValue tideDataValue = (TideDataValue)(((OkObjectResult)actionTideDataValue.Result).Value);
               Assert.NotNull(tideDataValue);
               Assert.Equal(tideDataValueList[0].TideDataValueID, tideDataValue.TideDataValueID);

               // testing Post(TideDataValue tideDataValue)
               tideDataValue.TideDataValueID = 0;
               var actionTideDataValueNew = await tideDataValueController.Post(tideDataValue);
               Assert.Equal(200, ((ObjectResult)actionTideDataValueNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideDataValueNew.Result).Value);
               TideDataValue tideDataValueNew = (TideDataValue)(((OkObjectResult)actionTideDataValueNew.Result).Value);
               Assert.NotNull(tideDataValueNew);

               // testing Put(TideDataValue tideDataValue)
               var actionTideDataValueUpdate = await tideDataValueController.Put(tideDataValueNew);
               Assert.Equal(200, ((ObjectResult)actionTideDataValueUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideDataValueUpdate.Result).Value);
               TideDataValue tideDataValueUpdate = (TideDataValue)(((OkObjectResult)actionTideDataValueUpdate.Result).Value);
               Assert.NotNull(tideDataValueUpdate);

               // testing Delete(TideDataValue tideDataValue)
               var actionTideDataValueDelete = await tideDataValueController.Delete(tideDataValueUpdate);
               Assert.Equal(200, ((ObjectResult)actionTideDataValueDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideDataValueDelete.Result).Value);
               TideDataValue tideDataValueDelete = (TideDataValue)(((OkObjectResult)actionTideDataValueDelete.Result).Value);
               Assert.NotNull(tideDataValueDelete);
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
            Services.AddSingleton<ITideDataValueService, TideDataValueService>();
            Services.AddSingleton<ITideDataValueController, TideDataValueController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            tideDataValueService = Provider.GetService<ITideDataValueService>();
            Assert.NotNull(tideDataValueService);
        
            await tideDataValueService.SetCulture(culture);
        
            tideDataValueController = Provider.GetService<ITideDataValueController>();
            Assert.NotNull(tideDataValueController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
