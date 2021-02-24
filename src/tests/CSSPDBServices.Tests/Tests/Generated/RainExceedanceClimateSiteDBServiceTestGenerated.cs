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

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class RainExceedanceClimateSiteDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IRainExceedanceClimateSiteDBService RainExceedanceClimateSiteDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBContext dbIM { get; set; }
        private RainExceedanceClimateSite rainExceedanceClimateSite { get; set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RainExceedanceClimateSiteDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RainExceedanceClimateSiteDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RainExceedanceClimateSite_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionRainExceedanceClimateSiteList = await RainExceedanceClimateSiteDBService.GetRainExceedanceClimateSiteList();
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value);
            List<RainExceedanceClimateSite> rainExceedanceClimateSiteList = (List<RainExceedanceClimateSite>)((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value;

            count = rainExceedanceClimateSiteList.Count();

            RainExceedanceClimateSite rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // rainExceedanceClimateSite.RainExceedanceClimateSiteID   (Int32)
            // -----------------------------------

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.RainExceedanceClimateSiteID = 0;

            var actionRainExceedanceClimateSite = await RainExceedanceClimateSiteDBService.Put(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.RainExceedanceClimateSiteID = 10000000;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteDBService.Put(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // rainExceedanceClimateSite.DBCommand   (DBCommandEnum)
            // -----------------------------------

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.DBCommand = (DBCommandEnum)1000000;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteDBService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = RainExceedance)]
            // rainExceedanceClimateSite.RainExceedanceTVItemID   (Int32)
            // -----------------------------------

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.RainExceedanceTVItemID = 0;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteDBService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.RainExceedanceTVItemID = 1;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteDBService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = ClimateSite)]
            // rainExceedanceClimateSite.ClimateSiteTVItemID   (Int32)
            // -----------------------------------

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.ClimateSiteTVItemID = 0;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteDBService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.ClimateSiteTVItemID = 1;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteDBService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // rainExceedanceClimateSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.LastUpdateDate_UTC = new DateTime();
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteDBService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);
            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteDBService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // rainExceedanceClimateSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.LastUpdateContactTVItemID = 0;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteDBService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.LastUpdateContactTVItemID = 1;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteDBService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post RainExceedanceClimateSite
            var actionRainExceedanceClimateSiteAdded = await RainExceedanceClimateSiteDBService.Post(rainExceedanceClimateSite);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteAdded.Result).Value);
            RainExceedanceClimateSite rainExceedanceClimateSiteAdded = (RainExceedanceClimateSite)((OkObjectResult)actionRainExceedanceClimateSiteAdded.Result).Value;
            Assert.NotNull(rainExceedanceClimateSiteAdded);

            // List<RainExceedanceClimateSite>
            var actionRainExceedanceClimateSiteList = await RainExceedanceClimateSiteDBService.GetRainExceedanceClimateSiteList();
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value);
            List<RainExceedanceClimateSite> rainExceedanceClimateSiteList = (List<RainExceedanceClimateSite>)((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value;

            int count = ((List<RainExceedanceClimateSite>)((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // List<RainExceedanceClimateSite> with skip and take
            var actionRainExceedanceClimateSiteListSkipAndTake = await RainExceedanceClimateSiteDBService.GetRainExceedanceClimateSiteList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteListSkipAndTake.Result).Value);
            List<RainExceedanceClimateSite> rainExceedanceClimateSiteListSkipAndTake = (List<RainExceedanceClimateSite>)((OkObjectResult)actionRainExceedanceClimateSiteListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<RainExceedanceClimateSite>)((OkObjectResult)actionRainExceedanceClimateSiteListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(rainExceedanceClimateSiteList[0].RainExceedanceClimateSiteID == rainExceedanceClimateSiteListSkipAndTake[0].RainExceedanceClimateSiteID);

            // Get RainExceedanceClimateSite With RainExceedanceClimateSiteID
            var actionRainExceedanceClimateSiteGet = await RainExceedanceClimateSiteDBService.GetRainExceedanceClimateSiteWithRainExceedanceClimateSiteID(rainExceedanceClimateSiteList[0].RainExceedanceClimateSiteID);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteGet.Result).Value);
            RainExceedanceClimateSite rainExceedanceClimateSiteGet = (RainExceedanceClimateSite)((OkObjectResult)actionRainExceedanceClimateSiteGet.Result).Value;
            Assert.NotNull(rainExceedanceClimateSiteGet);
            Assert.Equal(rainExceedanceClimateSiteGet.RainExceedanceClimateSiteID, rainExceedanceClimateSiteList[0].RainExceedanceClimateSiteID);

            // Put RainExceedanceClimateSite
            var actionRainExceedanceClimateSiteUpdated = await RainExceedanceClimateSiteDBService.Put(rainExceedanceClimateSite);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteUpdated.Result).Value);
            RainExceedanceClimateSite rainExceedanceClimateSiteUpdated = (RainExceedanceClimateSite)((OkObjectResult)actionRainExceedanceClimateSiteUpdated.Result).Value;
            Assert.NotNull(rainExceedanceClimateSiteUpdated);

            // Delete RainExceedanceClimateSite
            var actionRainExceedanceClimateSiteDeleted = await RainExceedanceClimateSiteDBService.Delete(rainExceedanceClimateSite.RainExceedanceClimateSiteID);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionRainExceedanceClimateSiteDeleted.Result).Value;
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
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IRainExceedanceClimateSiteDBService, RainExceedanceClimateSiteDBService>();

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

            RainExceedanceClimateSiteDBService = Provider.GetService<IRainExceedanceClimateSiteDBService>();
            Assert.NotNull(RainExceedanceClimateSiteDBService);

            return await Task.FromResult(true);
        }
        private RainExceedanceClimateSite GetFilledRandomRainExceedanceClimateSite(string OmitPropName)
        {
            RainExceedanceClimateSite rainExceedanceClimateSite = new RainExceedanceClimateSite();

            if (OmitPropName != "DBCommand") rainExceedanceClimateSite.DBCommand = (DBCommandEnum)GetRandomEnumType(typeof(DBCommandEnum));
            if (OmitPropName != "RainExceedanceTVItemID") rainExceedanceClimateSite.RainExceedanceTVItemID = 56;
            if (OmitPropName != "ClimateSiteTVItemID") rainExceedanceClimateSite.ClimateSiteTVItemID = 7;
            if (OmitPropName != "LastUpdateDate_UTC") rainExceedanceClimateSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") rainExceedanceClimateSite.LastUpdateContactTVItemID = 2;

            return rainExceedanceClimateSite;
        }
        private void CheckRainExceedanceClimateSiteFields(List<RainExceedanceClimateSite> rainExceedanceClimateSiteList)
        {
        }

        #endregion Functions private
    }
}
