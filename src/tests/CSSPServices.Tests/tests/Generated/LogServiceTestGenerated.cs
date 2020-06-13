/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
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
    public partial class LogServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILogService logService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public LogServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task Log_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               Log log = GetFilledRandomLog(""); 

               // List<Log>
               var actionLogList = await logService.GetLogList();
               Assert.Equal(200, ((ObjectResult)actionLogList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLogList.Result).Value);
               List<Log> logList = (List<Log>)((OkObjectResult)actionLogList.Result).Value;

               int count = ((List<Log>)((OkObjectResult)actionLogList.Result).Value).Count();
                Assert.True(count > 0);

               // Add Log
               var actionLogAdded = await logService.Add(log);
               Assert.Equal(200, ((ObjectResult)actionLogAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLogAdded.Result).Value);
               Log logAdded = (Log)((OkObjectResult)actionLogAdded.Result).Value;
               Assert.NotNull(logAdded);

               // Update Log
               var actionLogUpdated = await logService.Update(log);
               Assert.Equal(200, ((ObjectResult)actionLogUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLogUpdated.Result).Value);
               Log logUpdated = (Log)((OkObjectResult)actionLogUpdated.Result).Value;
               Assert.NotNull(logUpdated);

               // Delete Log
               var actionLogDeleted = await logService.Delete(log.LogID);
               Assert.Equal(200, ((ObjectResult)actionLogDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLogDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionLogDeleted.Result).Value;
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
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILogService, LogService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            logService = Provider.GetService<ILogService>();
            Assert.NotNull(logService);

            return await Task.FromResult(true);
        }
        private Log GetFilledRandomLog(string OmitPropName)
        {
            Log log = new Log();

            if (OmitPropName != "TableName") log.TableName = GetRandomString("", 5);
            if (OmitPropName != "ID") log.ID = GetRandomInt(1, 11);
            if (OmitPropName != "LogCommand") log.LogCommand = (LogCommandEnum)GetRandomEnumType(typeof(LogCommandEnum));
            if (OmitPropName != "Information") log.Information = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") log.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") log.LastUpdateContactTVItemID = 2;

            return log;
        }
        #endregion Functions private
    }
}
