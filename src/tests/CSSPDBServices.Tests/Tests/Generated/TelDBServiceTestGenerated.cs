/* Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
using LoggedInServices;
using CSSPDBPreferenceModels;
using CSSPScrambleServices;
using CSSPHelperServices;

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class TelDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITelDBService TelDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBContext dbIM { get; set; }
        private Tel tel { get; set; }
        #endregion Properties

        #region Constructors
        public TelDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TelDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TelDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            tel = GetFilledRandomTel("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Tel_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionTelList = await TelDBService.GetTelList();
            Assert.Equal(200, ((ObjectResult)actionTelList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelList.Result).Value);
            List<Tel> telList = (List<Tel>)((OkObjectResult)actionTelList.Result).Value;

            count = telList.Count();

            Tel tel = GetFilledRandomTel("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tel.TelID   (Int32)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelID = 0;

            var actionTel = await TelDBService.Put(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelID = 10000000;
            actionTel = await TelDBService.Put(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tel.DBCommand   (DBCommandEnum)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.DBCommand = (DBCommandEnum)1000000;
            actionTel = await TelDBService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Tel)]
            // tel.TelTVItemID   (Int32)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelTVItemID = 0;
            actionTel = await TelDBService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelTVItemID = 1;
            actionTel = await TelDBService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(50)]
            // tel.TelNumber   (String)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("TelNumber");
            actionTel = await TelDBService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelNumber = GetRandomString("", 51);
            actionTel = await TelDBService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);
            //Assert.AreEqual(count, telDBService.GetTelList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tel.TelType   (TelTypeEnum)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelType = (TelTypeEnum)1000000;
            actionTel = await TelDBService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tel.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.LastUpdateDate_UTC = new DateTime();
            actionTel = await TelDBService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);
            tel = null;
            tel = GetFilledRandomTel("");
            tel.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTel = await TelDBService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tel.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.LastUpdateContactTVItemID = 0;
            actionTel = await TelDBService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);

            tel = null;
            tel = GetFilledRandomTel("");
            tel.LastUpdateContactTVItemID = 1;
            actionTel = await TelDBService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post Tel
            var actionTelAdded = await TelDBService.Post(tel);
            Assert.Equal(200, ((ObjectResult)actionTelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelAdded.Result).Value);
            Tel telAdded = (Tel)((OkObjectResult)actionTelAdded.Result).Value;
            Assert.NotNull(telAdded);

            // List<Tel>
            var actionTelList = await TelDBService.GetTelList();
            Assert.Equal(200, ((ObjectResult)actionTelList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelList.Result).Value);
            List<Tel> telList = (List<Tel>)((OkObjectResult)actionTelList.Result).Value;

            int count = ((List<Tel>)((OkObjectResult)actionTelList.Result).Value).Count();
            Assert.True(count > 0);

            // List<Tel> with skip and take
            var actionTelListSkipAndTake = await TelDBService.GetTelList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionTelListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelListSkipAndTake.Result).Value);
            List<Tel> telListSkipAndTake = (List<Tel>)((OkObjectResult)actionTelListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<Tel>)((OkObjectResult)actionTelListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(telList[0].TelID == telListSkipAndTake[0].TelID);

            // Get Tel With TelID
            var actionTelGet = await TelDBService.GetTelWithTelID(telList[0].TelID);
            Assert.Equal(200, ((ObjectResult)actionTelGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelGet.Result).Value);
            Tel telGet = (Tel)((OkObjectResult)actionTelGet.Result).Value;
            Assert.NotNull(telGet);
            Assert.Equal(telGet.TelID, telList[0].TelID);

            // Put Tel
            var actionTelUpdated = await TelDBService.Put(tel);
            Assert.Equal(200, ((ObjectResult)actionTelUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelUpdated.Result).Value);
            Tel telUpdated = (Tel)((OkObjectResult)actionTelUpdated.Result).Value;
            Assert.NotNull(telUpdated);

            // Delete Tel
            var actionTelDeleted = await TelDBService.Delete(tel.TelID);
            Assert.Equal(200, ((ObjectResult)actionTelDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTelDeleted.Result).Value;
            Assert.True(retBool);

            db.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("a79b4a81-ba75-4dfc-8d95-46259f73f055")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            string CSSPDBConnString = Configuration.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IScrambleService, ScrambleService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITelDBService, TelDBService>();

            /* ---------------------------------------------------------------------------------
             * using TestDB
             * ---------------------------------------------------------------------------------      
             */
            string TestDB = Configuration.GetValue<string>("TestDB");
            Assert.NotNull(TestDB);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDB);
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBPreference
             * ---------------------------------------------------------------------------------
             */
            string CSSPDBPreference = Configuration.GetValue<string>("CSSPDBPreference"); 
            Assert.NotNull(CSSPDBPreference);

            FileInfo fiCSSPDBPreference = new FileInfo(CSSPDBPreference);

            Services.AddDbContext<CSSPDBPreferenceContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBPreference.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(LoginEmail));

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            dbIM = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(dbIM);

            TelDBService = Provider.GetService<ITelDBService>();
            Assert.NotNull(TelDBService);

            return await Task.FromResult(true);
        }
        private Tel GetFilledRandomTel(string OmitPropName)
        {
            Tel tel = new Tel();

            if (OmitPropName != "DBCommand") tel.DBCommand = (DBCommandEnum)GetRandomEnumType(typeof(DBCommandEnum));
            if (OmitPropName != "TelTVItemID") tel.TelTVItemID = 55;
            if (OmitPropName != "TelNumber") tel.TelNumber = GetRandomString("", 5);
            if (OmitPropName != "TelType") tel.TelType = (TelTypeEnum)GetRandomEnumType(typeof(TelTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tel.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tel.LastUpdateContactTVItemID = 2;

            return tel;
        }
        private void CheckTelFields(List<Tel> telList)
        {
            Assert.False(string.IsNullOrWhiteSpace(telList[0].TelNumber));
        }

        #endregion Functions private
    }
}
