/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Services;
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
using System.ComponentModel.DataAnnotations;
using CSSPCultureServices.Resources;
using LocalServices;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class LogDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILogDBLocalService LogDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private Log log { get; set; }
        #endregion Properties

        #region Constructors
        public LogDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocal]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LogDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            log = GetFilledRandomLog("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Log_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLogList = await LogDBLocalService.GetLogList();
            Assert.Equal(200, ((ObjectResult)actionLogList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLogList.Result).Value);
            List<Log> logList = (List<Log>)((OkObjectResult)actionLogList.Result).Value;

            count = logList.Count();

            Log log = GetFilledRandomLog("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // log.LogID   (Int32)
            // -----------------------------------

            log = null;
            log = GetFilledRandomLog("");
            log.LogID = 0;

            var actionLog = await LogDBLocalService.Put(log);
            Assert.IsType<BadRequestObjectResult>(actionLog.Result);

            log = null;
            log = GetFilledRandomLog("");
            log.LogID = 10000000;
            actionLog = await LogDBLocalService.Put(log);
            Assert.IsType<BadRequestObjectResult>(actionLog.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(50)]
            // log.TableName   (String)
            // -----------------------------------

            log = null;
            log = GetFilledRandomLog("TableName");
            actionLog = await LogDBLocalService.Post(log);
            Assert.IsType<BadRequestObjectResult>(actionLog.Result);

            log = null;
            log = GetFilledRandomLog("");
            log.TableName = GetRandomString("", 51);
            actionLog = await LogDBLocalService.Post(log);
            Assert.IsType<BadRequestObjectResult>(actionLog.Result);
            //Assert.AreEqual(count, logDBLocalService.GetLogList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // log.ID   (Int32)
            // -----------------------------------

            log = null;
            log = GetFilledRandomLog("");
            log.ID = 0;
            actionLog = await LogDBLocalService.Post(log);
            Assert.IsType<BadRequestObjectResult>(actionLog.Result);
            //Assert.AreEqual(count, logService.GetLogList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // log.LogCommand   (LogCommandEnum)
            // -----------------------------------

            log = null;
            log = GetFilledRandomLog("");
            log.LogCommand = (LogCommandEnum)1000000;
            actionLog = await LogDBLocalService.Post(log);
            Assert.IsType<BadRequestObjectResult>(actionLog.Result);


            // -----------------------------------
            // Is NOT Nullable
            // log.Information   (String)
            // -----------------------------------

            log = null;
            log = GetFilledRandomLog("Information");
            actionLog = await LogDBLocalService.Post(log);
            Assert.IsType<BadRequestObjectResult>(actionLog.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // log.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            log = null;
            log = GetFilledRandomLog("");
            log.LastUpdateDate_UTC = new DateTime();
            actionLog = await LogDBLocalService.Post(log);
            Assert.IsType<BadRequestObjectResult>(actionLog.Result);
            log = null;
            log = GetFilledRandomLog("");
            log.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLog = await LogDBLocalService.Post(log);
            Assert.IsType<BadRequestObjectResult>(actionLog.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // log.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            log = null;
            log = GetFilledRandomLog("");
            log.LastUpdateContactTVItemID = 0;
            actionLog = await LogDBLocalService.Post(log);
            Assert.IsType<BadRequestObjectResult>(actionLog.Result);

            log = null;
            log = GetFilledRandomLog("");
            log.LastUpdateContactTVItemID = 1;
            actionLog = await LogDBLocalService.Post(log);
            Assert.IsType<BadRequestObjectResult>(actionLog.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post Log
            var actionLogAdded = await LogDBLocalService.Post(log);
            Assert.Equal(200, ((ObjectResult)actionLogAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLogAdded.Result).Value);
            Log logAdded = (Log)((OkObjectResult)actionLogAdded.Result).Value;
            Assert.NotNull(logAdded);

            // List<Log>
            var actionLogList = await LogDBLocalService.GetLogList();
            Assert.Equal(200, ((ObjectResult)actionLogList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLogList.Result).Value);
            List<Log> logList = (List<Log>)((OkObjectResult)actionLogList.Result).Value;

            int count = ((List<Log>)((OkObjectResult)actionLogList.Result).Value).Count();
            Assert.True(count > 0);

            // List<Log> with skip and take
            var actionLogListSkipAndTake = await LogDBLocalService.GetLogList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLogListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLogListSkipAndTake.Result).Value);
            List<Log> logListSkipAndTake = (List<Log>)((OkObjectResult)actionLogListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<Log>)((OkObjectResult)actionLogListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(logList[0].LogID == logListSkipAndTake[0].LogID);

            // Get Log With LogID
            var actionLogGet = await LogDBLocalService.GetLogWithLogID(logList[0].LogID);
            Assert.Equal(200, ((ObjectResult)actionLogGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLogGet.Result).Value);
            Log logGet = (Log)((OkObjectResult)actionLogGet.Result).Value;
            Assert.NotNull(logGet);
            Assert.Equal(logGet.LogID, logList[0].LogID);

            // Put Log
            var actionLogUpdated = await LogDBLocalService.Put(log);
            Assert.Equal(200, ((ObjectResult)actionLogUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLogUpdated.Result).Value);
            Log logUpdated = (Log)((OkObjectResult)actionLogUpdated.Result).Value;
            Assert.NotNull(logUpdated);

            // Delete Log
            var actionLogDeleted = await LogDBLocalService.Delete(log.LogID);
            Assert.Equal(200, ((ObjectResult)actionLogDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLogDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLogDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLoginFileName = Config.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILogDBLocalService, LogDBLocalService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            LogDBLocalService = Provider.GetService<ILogDBLocalService>();
            Assert.NotNull(LogDBLocalService);

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

            try
            {
                dbLocal.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocal.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }


            return log;
        }
        private void CheckLogFields(List<Log> logList)
        {
            Assert.False(string.IsNullOrWhiteSpace(logList[0].TableName));
            Assert.False(string.IsNullOrWhiteSpace(logList[0].Information));
        }

        #endregion Functions private
    }
}
