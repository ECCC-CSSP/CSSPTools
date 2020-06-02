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
    public partial class LogControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ILogService logService { get; set; }
        private ILogController logController { get; set; }
        #endregion Properties

        #region Constructors
        public LogControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task LogController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(logService);
            Assert.NotNull(logController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task LogController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionLogList = await logController.Get();
               Assert.Equal(200, ((ObjectResult)actionLogList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLogList.Result).Value);
               List<Log> logList = (List<Log>)(((OkObjectResult)actionLogList.Result).Value);

               int count = ((List<Log>)((OkObjectResult)actionLogList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(LogID)
               var actionLog = await logController.Get(logList[0].LogID);
               Assert.Equal(200, ((ObjectResult)actionLog.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLog.Result).Value);
               Log log = (Log)(((OkObjectResult)actionLog.Result).Value);
               Assert.NotNull(log);
               Assert.Equal(logList[0].LogID, log.LogID);

               // testing Post(Log log)
               log.LogID = 0;
               var actionLogNew = await logController.Post(log);
               Assert.Equal(200, ((ObjectResult)actionLogNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLogNew.Result).Value);
               Log logNew = (Log)(((OkObjectResult)actionLogNew.Result).Value);
               Assert.NotNull(logNew);

               // testing Put(Log log)
               var actionLogUpdate = await logController.Put(logNew);
               Assert.Equal(200, ((ObjectResult)actionLogUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLogUpdate.Result).Value);
               Log logUpdate = (Log)(((OkObjectResult)actionLogUpdate.Result).Value);
               Assert.NotNull(logUpdate);

               // testing Delete(Log log)
               var actionLogDelete = await logController.Delete(logUpdate);
               Assert.Equal(200, ((ObjectResult)actionLogDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLogDelete.Result).Value);
               Log logDelete = (Log)(((OkObjectResult)actionLogDelete.Result).Value);
               Assert.NotNull(logDelete);
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
            Services.AddSingleton<ILogService, LogService>();
            Services.AddSingleton<ILogController, LogController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            logService = Provider.GetService<ILogService>();
            Assert.NotNull(logService);
        
            await logService.SetCulture(culture);
        
            logController = Provider.GetService<ILogController>();
            Assert.NotNull(logController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
