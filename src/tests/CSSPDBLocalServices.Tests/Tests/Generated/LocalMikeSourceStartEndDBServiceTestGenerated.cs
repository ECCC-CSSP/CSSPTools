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
    public partial class LocalMikeSourceStartEndDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalMikeSourceStartEndDBService LocalMikeSourceStartEndDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalMikeSourceStartEnd localMikeSourceStartEnd { get; set; }
        #endregion Properties

        #region Constructors
        public LocalMikeSourceStartEndDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalMikeSourceStartEndDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalMikeSourceStartEndDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalMikeSourceStartEnd_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalMikeSourceStartEndList = await LocalMikeSourceStartEndDBService.GetLocalMikeSourceStartEndList();
            Assert.Equal(200, ((ObjectResult)actionLocalMikeSourceStartEndList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMikeSourceStartEndList.Result).Value);
            List<LocalMikeSourceStartEnd> localMikeSourceStartEndList = (List<LocalMikeSourceStartEnd>)((OkObjectResult)actionLocalMikeSourceStartEndList.Result).Value;

            count = localMikeSourceStartEndList.Count();

            LocalMikeSourceStartEnd localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localMikeSourceStartEnd.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localMikeSourceStartEnd.MikeSourceStartEndID   (Int32)
            // -----------------------------------

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.MikeSourceStartEndID = 0;

            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Put(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.MikeSourceStartEndID = 10000000;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Put(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "MikeSource", ExistPlurial = "s", ExistFieldID = "MikeSourceID", AllowableTVtypeList = )]
            // localMikeSourceStartEnd.MikeSourceID   (Int32)
            // -----------------------------------

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.MikeSourceID = 0;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localMikeSourceStartEnd.StartDateAndTime_Local   (DateTime)
            // -----------------------------------

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.StartDateAndTime_Local = new DateTime();
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.StartDateAndTime_Local = new DateTime(1979, 1, 1);
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = StartDateAndTime_Local)]
            // localMikeSourceStartEnd.EndDateAndTime_Local   (DateTime)
            // -----------------------------------

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.EndDateAndTime_Local = new DateTime();
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.EndDateAndTime_Local = new DateTime(1979, 1, 1);
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000000)]
            // localMikeSourceStartEnd.SourceFlowStart_m3_day   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [SourceFlowStart_m3_day]

            //CSSPError: Type not implemented [SourceFlowStart_m3_day]

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourceFlowStart_m3_day = -1.0D;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndService.GetLocalMikeSourceStartEndList().Count());
            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourceFlowStart_m3_day = 1000001.0D;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndDBService.GetLocalMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000000)]
            // localMikeSourceStartEnd.SourceFlowEnd_m3_day   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [SourceFlowEnd_m3_day]

            //CSSPError: Type not implemented [SourceFlowEnd_m3_day]

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourceFlowEnd_m3_day = -1.0D;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndService.GetLocalMikeSourceStartEndList().Count());
            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourceFlowEnd_m3_day = 1000001.0D;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndDBService.GetLocalMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // localMikeSourceStartEnd.SourcePollutionStart_MPN_100ml   (Int32)
            // -----------------------------------

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourcePollutionStart_MPN_100ml = -1;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndService.GetLocalMikeSourceStartEndList().Count());
            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 10000001;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndDBService.GetLocalMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // localMikeSourceStartEnd.SourcePollutionEnd_MPN_100ml   (Int32)
            // -----------------------------------

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = -1;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndService.GetLocalMikeSourceStartEndList().Count());
            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 10000001;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndDBService.GetLocalMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-10, 40)]
            // localMikeSourceStartEnd.SourceTemperatureStart_C   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [SourceTemperatureStart_C]

            //CSSPError: Type not implemented [SourceTemperatureStart_C]

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourceTemperatureStart_C = -11.0D;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndService.GetLocalMikeSourceStartEndList().Count());
            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourceTemperatureStart_C = 41.0D;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndDBService.GetLocalMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-10, 40)]
            // localMikeSourceStartEnd.SourceTemperatureEnd_C   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [SourceTemperatureEnd_C]

            //CSSPError: Type not implemented [SourceTemperatureEnd_C]

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourceTemperatureEnd_C = -11.0D;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndService.GetLocalMikeSourceStartEndList().Count());
            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourceTemperatureEnd_C = 41.0D;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndDBService.GetLocalMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 40)]
            // localMikeSourceStartEnd.SourceSalinityStart_PSU   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [SourceSalinityStart_PSU]

            //CSSPError: Type not implemented [SourceSalinityStart_PSU]

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourceSalinityStart_PSU = -1.0D;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndService.GetLocalMikeSourceStartEndList().Count());
            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourceSalinityStart_PSU = 41.0D;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndDBService.GetLocalMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 40)]
            // localMikeSourceStartEnd.SourceSalinityEnd_PSU   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [SourceSalinityEnd_PSU]

            //CSSPError: Type not implemented [SourceSalinityEnd_PSU]

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourceSalinityEnd_PSU = -1.0D;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndService.GetLocalMikeSourceStartEndList().Count());
            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.SourceSalinityEnd_PSU = 41.0D;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, localMikeSourceStartEndDBService.GetLocalMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localMikeSourceStartEnd.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.LastUpdateDate_UTC = new DateTime();
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);
            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localMikeSourceStartEnd.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.LastUpdateContactTVItemID = 0;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);

            localMikeSourceStartEnd = null;
            localMikeSourceStartEnd = GetFilledRandomLocalMikeSourceStartEnd("");
            localMikeSourceStartEnd.LastUpdateContactTVItemID = 1;
            actionLocalMikeSourceStartEnd = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionLocalMikeSourceStartEnd.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalMikeSourceStartEnd
            var actionLocalMikeSourceStartEndAdded = await LocalMikeSourceStartEndDBService.Post(localMikeSourceStartEnd);
            Assert.Equal(200, ((ObjectResult)actionLocalMikeSourceStartEndAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMikeSourceStartEndAdded.Result).Value);
            LocalMikeSourceStartEnd localMikeSourceStartEndAdded = (LocalMikeSourceStartEnd)((OkObjectResult)actionLocalMikeSourceStartEndAdded.Result).Value;
            Assert.NotNull(localMikeSourceStartEndAdded);

            // List<LocalMikeSourceStartEnd>
            var actionLocalMikeSourceStartEndList = await LocalMikeSourceStartEndDBService.GetLocalMikeSourceStartEndList();
            Assert.Equal(200, ((ObjectResult)actionLocalMikeSourceStartEndList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMikeSourceStartEndList.Result).Value);
            List<LocalMikeSourceStartEnd> localMikeSourceStartEndList = (List<LocalMikeSourceStartEnd>)((OkObjectResult)actionLocalMikeSourceStartEndList.Result).Value;

            int count = ((List<LocalMikeSourceStartEnd>)((OkObjectResult)actionLocalMikeSourceStartEndList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalMikeSourceStartEnd> with skip and take
            var actionLocalMikeSourceStartEndListSkipAndTake = await LocalMikeSourceStartEndDBService.GetLocalMikeSourceStartEndList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalMikeSourceStartEndListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMikeSourceStartEndListSkipAndTake.Result).Value);
            List<LocalMikeSourceStartEnd> localMikeSourceStartEndListSkipAndTake = (List<LocalMikeSourceStartEnd>)((OkObjectResult)actionLocalMikeSourceStartEndListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalMikeSourceStartEnd>)((OkObjectResult)actionLocalMikeSourceStartEndListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localMikeSourceStartEndList[0].MikeSourceStartEndID == localMikeSourceStartEndListSkipAndTake[0].MikeSourceStartEndID);

            // Get LocalMikeSourceStartEnd With MikeSourceStartEndID
            var actionLocalMikeSourceStartEndGet = await LocalMikeSourceStartEndDBService.GetLocalMikeSourceStartEndWithMikeSourceStartEndID(localMikeSourceStartEndList[0].MikeSourceStartEndID);
            Assert.Equal(200, ((ObjectResult)actionLocalMikeSourceStartEndGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMikeSourceStartEndGet.Result).Value);
            LocalMikeSourceStartEnd localMikeSourceStartEndGet = (LocalMikeSourceStartEnd)((OkObjectResult)actionLocalMikeSourceStartEndGet.Result).Value;
            Assert.NotNull(localMikeSourceStartEndGet);
            Assert.Equal(localMikeSourceStartEndGet.MikeSourceStartEndID, localMikeSourceStartEndList[0].MikeSourceStartEndID);

            // Put LocalMikeSourceStartEnd
            var actionLocalMikeSourceStartEndUpdated = await LocalMikeSourceStartEndDBService.Put(localMikeSourceStartEnd);
            Assert.Equal(200, ((ObjectResult)actionLocalMikeSourceStartEndUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMikeSourceStartEndUpdated.Result).Value);
            LocalMikeSourceStartEnd localMikeSourceStartEndUpdated = (LocalMikeSourceStartEnd)((OkObjectResult)actionLocalMikeSourceStartEndUpdated.Result).Value;
            Assert.NotNull(localMikeSourceStartEndUpdated);

            // Delete LocalMikeSourceStartEnd
            var actionLocalMikeSourceStartEndDeleted = await LocalMikeSourceStartEndDBService.Delete(localMikeSourceStartEnd.MikeSourceStartEndID);
            Assert.Equal(200, ((ObjectResult)actionLocalMikeSourceStartEndDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMikeSourceStartEndDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalMikeSourceStartEndDeleted.Result).Value;
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
            Services.AddSingleton<ILocalMikeSourceStartEndDBService, LocalMikeSourceStartEndDBService>();

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

            LocalMikeSourceStartEndDBService = Provider.GetService<ILocalMikeSourceStartEndDBService>();
            Assert.NotNull(LocalMikeSourceStartEndDBService);

            return await Task.FromResult(true);
        }
        private LocalMikeSourceStartEnd GetFilledRandomLocalMikeSourceStartEnd(string OmitPropName)
        {
            LocalMikeSourceStartEnd localMikeSourceStartEnd = new LocalMikeSourceStartEnd();

            if (OmitPropName != "LocalDBCommand") localMikeSourceStartEnd.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "MikeSourceID") localMikeSourceStartEnd.MikeSourceID = 0;
            if (OmitPropName != "StartDateAndTime_Local") localMikeSourceStartEnd.StartDateAndTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateAndTime_Local") localMikeSourceStartEnd.EndDateAndTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "SourceFlowStart_m3_day") localMikeSourceStartEnd.SourceFlowStart_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourceFlowEnd_m3_day") localMikeSourceStartEnd.SourceFlowEnd_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourcePollutionStart_MPN_100ml") localMikeSourceStartEnd.SourcePollutionStart_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourcePollutionEnd_MPN_100ml") localMikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourceTemperatureStart_C") localMikeSourceStartEnd.SourceTemperatureStart_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceTemperatureEnd_C") localMikeSourceStartEnd.SourceTemperatureEnd_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceSalinityStart_PSU") localMikeSourceStartEnd.SourceSalinityStart_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "SourceSalinityEnd_PSU") localMikeSourceStartEnd.SourceSalinityEnd_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "LastUpdateDate_UTC") localMikeSourceStartEnd.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localMikeSourceStartEnd.LastUpdateContactTVItemID = 2;



            return localMikeSourceStartEnd;
        }
        private void CheckLocalMikeSourceStartEndFields(List<LocalMikeSourceStartEnd> localMikeSourceStartEndList)
        {
        }

        #endregion Functions private
    }
}