/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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
using CSSPDBModels;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class LocalAppErrLogDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalAppErrLogDBService LocalAppErrLogDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalAppErrLog localAppErrLog { get; set; }
        #endregion Properties

        #region Constructors
        public LocalAppErrLogDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalAppErrLogDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalAppErrLogDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localAppErrLog = GetFilledRandomLocalAppErrLog("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalAppErrLog_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalAppErrLogList = await LocalAppErrLogDBService.GetLocalAppErrLogList();
            Assert.Equal(200, ((ObjectResult)actionLocalAppErrLogList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalAppErrLogList.Result).Value);
            List<LocalAppErrLog> localAppErrLogList = (List<LocalAppErrLog>)((OkObjectResult)actionLocalAppErrLogList.Result).Value;

            count = localAppErrLogList.Count();

            LocalAppErrLog localAppErrLog = GetFilledRandomLocalAppErrLog("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localAppErrLog.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("");
            localAppErrLog.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalAppErrLog = await LocalAppErrLogDBService.Post(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localAppErrLog.AppErrLogID   (Int32)
            // -----------------------------------

            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("");
            localAppErrLog.AppErrLogID = 0;

            actionLocalAppErrLog = await LocalAppErrLogDBService.Put(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);

            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("");
            localAppErrLog.AppErrLogID = 10000000;
            actionLocalAppErrLog = await LocalAppErrLogDBService.Put(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // localAppErrLog.Tag   (String)
            // -----------------------------------

            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("Tag");
            actionLocalAppErrLog = await LocalAppErrLogDBService.Post(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);

            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("");
            localAppErrLog.Tag = GetRandomString("", 101);
            actionLocalAppErrLog = await LocalAppErrLogDBService.Post(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);
            //Assert.AreEqual(count, localAppErrLogDBService.GetLocalAppErrLogList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // localAppErrLog.LineNumber   (Int32)
            // -----------------------------------

            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("");
            localAppErrLog.LineNumber = 0;
            actionLocalAppErrLog = await LocalAppErrLogDBService.Post(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);
            //Assert.AreEqual(count, localAppErrLogService.GetLocalAppErrLogList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // localAppErrLog.Source   (String)
            // -----------------------------------

            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("Source");
            actionLocalAppErrLog = await LocalAppErrLogDBService.Post(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);


            // -----------------------------------
            // Is NOT Nullable
            // localAppErrLog.Message   (String)
            // -----------------------------------

            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("Message");
            actionLocalAppErrLog = await LocalAppErrLogDBService.Post(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localAppErrLog.DateTime_UTC   (DateTime)
            // -----------------------------------

            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("");
            localAppErrLog.DateTime_UTC = new DateTime();
            actionLocalAppErrLog = await LocalAppErrLogDBService.Post(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);
            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("");
            localAppErrLog.DateTime_UTC = new DateTime(1979, 1, 1);
            actionLocalAppErrLog = await LocalAppErrLogDBService.Post(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localAppErrLog.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("");
            localAppErrLog.LastUpdateDate_UTC = new DateTime();
            actionLocalAppErrLog = await LocalAppErrLogDBService.Post(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);
            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("");
            localAppErrLog.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalAppErrLog = await LocalAppErrLogDBService.Post(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localAppErrLog.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("");
            localAppErrLog.LastUpdateContactTVItemID = 0;
            actionLocalAppErrLog = await LocalAppErrLogDBService.Post(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);

            localAppErrLog = null;
            localAppErrLog = GetFilledRandomLocalAppErrLog("");
            localAppErrLog.LastUpdateContactTVItemID = 1;
            actionLocalAppErrLog = await LocalAppErrLogDBService.Post(localAppErrLog);
            Assert.IsType<BadRequestObjectResult>(actionLocalAppErrLog.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalAppErrLog
            var actionLocalAppErrLogAdded = await LocalAppErrLogDBService.Post(localAppErrLog);
            Assert.Equal(200, ((ObjectResult)actionLocalAppErrLogAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalAppErrLogAdded.Result).Value);
            LocalAppErrLog localAppErrLogAdded = (LocalAppErrLog)((OkObjectResult)actionLocalAppErrLogAdded.Result).Value;
            Assert.NotNull(localAppErrLogAdded);

            // List<LocalAppErrLog>
            var actionLocalAppErrLogList = await LocalAppErrLogDBService.GetLocalAppErrLogList();
            Assert.Equal(200, ((ObjectResult)actionLocalAppErrLogList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalAppErrLogList.Result).Value);
            List<LocalAppErrLog> localAppErrLogList = (List<LocalAppErrLog>)((OkObjectResult)actionLocalAppErrLogList.Result).Value;

            int count = ((List<LocalAppErrLog>)((OkObjectResult)actionLocalAppErrLogList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalAppErrLog> with skip and take
            var actionLocalAppErrLogListSkipAndTake = await LocalAppErrLogDBService.GetLocalAppErrLogList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalAppErrLogListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalAppErrLogListSkipAndTake.Result).Value);
            List<LocalAppErrLog> localAppErrLogListSkipAndTake = (List<LocalAppErrLog>)((OkObjectResult)actionLocalAppErrLogListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalAppErrLog>)((OkObjectResult)actionLocalAppErrLogListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localAppErrLogList[0].AppErrLogID == localAppErrLogListSkipAndTake[0].AppErrLogID);

            // Get LocalAppErrLog With AppErrLogID
            var actionLocalAppErrLogGet = await LocalAppErrLogDBService.GetLocalAppErrLogWithAppErrLogID(localAppErrLogList[0].AppErrLogID);
            Assert.Equal(200, ((ObjectResult)actionLocalAppErrLogGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalAppErrLogGet.Result).Value);
            LocalAppErrLog localAppErrLogGet = (LocalAppErrLog)((OkObjectResult)actionLocalAppErrLogGet.Result).Value;
            Assert.NotNull(localAppErrLogGet);
            Assert.Equal(localAppErrLogGet.AppErrLogID, localAppErrLogList[0].AppErrLogID);

            // Put LocalAppErrLog
            var actionLocalAppErrLogUpdated = await LocalAppErrLogDBService.Put(localAppErrLog);
            Assert.Equal(200, ((ObjectResult)actionLocalAppErrLogUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalAppErrLogUpdated.Result).Value);
            LocalAppErrLog localAppErrLogUpdated = (LocalAppErrLog)((OkObjectResult)actionLocalAppErrLogUpdated.Result).Value;
            Assert.NotNull(localAppErrLogUpdated);

            // Delete LocalAppErrLog
            var actionLocalAppErrLogDeleted = await LocalAppErrLogDBService.Delete(localAppErrLog.AppErrLogID);
            Assert.Equal(200, ((ObjectResult)actionLocalAppErrLogDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalAppErrLogDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalAppErrLogDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocal = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILocalAppErrLogDBService, LocalAppErrLogDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            LocalAppErrLogDBService = Provider.GetService<ILocalAppErrLogDBService>();
            Assert.NotNull(LocalAppErrLogDBService);

            return await Task.FromResult(true);
        }
        private LocalAppErrLog GetFilledRandomLocalAppErrLog(string OmitPropName)
        {
            LocalAppErrLog localAppErrLog = new LocalAppErrLog();

            if (OmitPropName != "LocalDBCommand") localAppErrLog.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "Tag") localAppErrLog.Tag = GetRandomString("", 5);
            if (OmitPropName != "LineNumber") localAppErrLog.LineNumber = GetRandomInt(1, 11);
            if (OmitPropName != "Source") localAppErrLog.Source = GetRandomString("", 20);
            if (OmitPropName != "Message") localAppErrLog.Message = GetRandomString("", 20);
            if (OmitPropName != "DateTime_UTC") localAppErrLog.DateTime_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateDate_UTC") localAppErrLog.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localAppErrLog.LastUpdateContactTVItemID = 2;



            return localAppErrLog;
        }
        private void CheckLocalAppErrLogFields(List<LocalAppErrLog> localAppErrLogList)
        {
            Assert.False(string.IsNullOrWhiteSpace(localAppErrLogList[0].Tag));
            Assert.False(string.IsNullOrWhiteSpace(localAppErrLogList[0].Source));
            Assert.False(string.IsNullOrWhiteSpace(localAppErrLogList[0].Message));
        }

        #endregion Functions private
    }
}
