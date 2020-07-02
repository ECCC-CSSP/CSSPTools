/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
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
using Xunit;

namespace CSSPServices.Tests
{
    public partial class AppErrLogServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IAppErrLogService AppErrLogService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public AppErrLogServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task AppErrLog_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               AppErrLog appErrLog = GetFilledRandomAppErrLog(""); 

               // List<AppErrLog>
               var actionAppErrLogList = await AppErrLogService.GetAppErrLogList();
               Assert.Equal(200, ((ObjectResult)actionAppErrLogList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppErrLogList.Result).Value);
               List<AppErrLog> appErrLogList = (List<AppErrLog>)((OkObjectResult)actionAppErrLogList.Result).Value;

               int count = ((List<AppErrLog>)((OkObjectResult)actionAppErrLogList.Result).Value).Count();
                Assert.True(count > 0);

               // Post AppErrLog
               var actionAppErrLogAdded = await AppErrLogService.Post(appErrLog);
               Assert.Equal(200, ((ObjectResult)actionAppErrLogAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppErrLogAdded.Result).Value);
               AppErrLog appErrLogAdded = (AppErrLog)((OkObjectResult)actionAppErrLogAdded.Result).Value;
               Assert.NotNull(appErrLogAdded);

               // Put AppErrLog
               var actionAppErrLogUpdated = await AppErrLogService.Put(appErrLog);
               Assert.Equal(200, ((ObjectResult)actionAppErrLogUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppErrLogUpdated.Result).Value);
               AppErrLog appErrLogUpdated = (AppErrLog)((OkObjectResult)actionAppErrLogUpdated.Result).Value;
               Assert.NotNull(appErrLogUpdated);

               // Delete AppErrLog
               var actionAppErrLogDeleted = await AppErrLogService.Delete(appErrLog.AppErrLogID);
               Assert.Equal(200, ((ObjectResult)actionAppErrLogDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppErrLogDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionAppErrLogDeleted.Result).Value;
               Assert.True(retBool);
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAppErrLogService, AppErrLogService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            AppErrLogService = Provider.GetService<IAppErrLogService>();
            Assert.NotNull(AppErrLogService);

            return await Task.FromResult(true);
        }
        private AppErrLog GetFilledRandomAppErrLog(string OmitPropName)
        {
            AppErrLog appErrLog = new AppErrLog();

            if (OmitPropName != "Tag") appErrLog.Tag = GetRandomString("", 5);
            if (OmitPropName != "LineNumber") appErrLog.LineNumber = GetRandomInt(1, 11);
            if (OmitPropName != "Source") appErrLog.Source = GetRandomString("", 20);
            if (OmitPropName != "Message") appErrLog.Message = GetRandomString("", 20);
            if (OmitPropName != "DateTime_UTC") appErrLog.DateTime_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateDate_UTC") appErrLog.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appErrLog.LastUpdateContactTVItemID = 2;

            return appErrLog;
        }
        #endregion Functions private
    }
}
