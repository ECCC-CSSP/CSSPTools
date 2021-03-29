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
    public partial class SamplingPlanSubsectorSiteDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ISamplingPlanSubsectorSiteDBService SamplingPlanSubsectorSiteDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBContext dbIM { get; set; }
        private SamplingPlanSubsectorSite samplingPlanSubsectorSite { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SamplingPlanSubsectorSiteDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SamplingPlanSubsectorSiteDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SamplingPlanSubsectorSite_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionSamplingPlanSubsectorSiteList = await SamplingPlanSubsectorSiteDBService.GetSamplingPlanSubsectorSiteList();
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteList.Result).Value);
            List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = (List<SamplingPlanSubsectorSite>)((OkObjectResult)actionSamplingPlanSubsectorSiteList.Result).Value;

            count = samplingPlanSubsectorSiteList.Count();

            SamplingPlanSubsectorSite samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID   (Int32)
            // -----------------------------------

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 0;

            var actionSamplingPlanSubsectorSite = await SamplingPlanSubsectorSiteDBService.Put(samplingPlanSubsectorSite);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsectorSite.Result);

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 10000000;
            actionSamplingPlanSubsectorSite = await SamplingPlanSubsectorSiteDBService.Put(samplingPlanSubsectorSite);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsectorSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // samplingPlanSubsectorSite.DBCommand   (DBCommandEnum)
            // -----------------------------------

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.DBCommand = (DBCommandEnum)1000000;
            actionSamplingPlanSubsectorSite = await SamplingPlanSubsectorSiteDBService.Post(samplingPlanSubsectorSite);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsectorSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "SamplingPlanSubsector", ExistPlurial = "s", ExistFieldID = "SamplingPlanSubsectorID", AllowableTVtypeList = )]
            // samplingPlanSubsectorSite.SamplingPlanSubsectorID   (Int32)
            // -----------------------------------

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.SamplingPlanSubsectorID = 0;
            actionSamplingPlanSubsectorSite = await SamplingPlanSubsectorSiteDBService.Post(samplingPlanSubsectorSite);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsectorSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
            // samplingPlanSubsectorSite.MWQMSiteTVItemID   (Int32)
            // -----------------------------------

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.MWQMSiteTVItemID = 0;
            actionSamplingPlanSubsectorSite = await SamplingPlanSubsectorSiteDBService.Post(samplingPlanSubsectorSite);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsectorSite.Result);

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.MWQMSiteTVItemID = 1;
            actionSamplingPlanSubsectorSite = await SamplingPlanSubsectorSiteDBService.Post(samplingPlanSubsectorSite);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsectorSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // samplingPlanSubsectorSite.IsDuplicate   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // samplingPlanSubsectorSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.LastUpdateDate_UTC = new DateTime();
            actionSamplingPlanSubsectorSite = await SamplingPlanSubsectorSiteDBService.Post(samplingPlanSubsectorSite);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsectorSite.Result);
            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionSamplingPlanSubsectorSite = await SamplingPlanSubsectorSiteDBService.Post(samplingPlanSubsectorSite);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsectorSite.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // samplingPlanSubsectorSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.LastUpdateContactTVItemID = 0;
            actionSamplingPlanSubsectorSite = await SamplingPlanSubsectorSiteDBService.Post(samplingPlanSubsectorSite);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsectorSite.Result);

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.LastUpdateContactTVItemID = 1;
            actionSamplingPlanSubsectorSite = await SamplingPlanSubsectorSiteDBService.Post(samplingPlanSubsectorSite);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsectorSite.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post SamplingPlanSubsectorSite
            var actionSamplingPlanSubsectorSiteAdded = await SamplingPlanSubsectorSiteDBService.Post(samplingPlanSubsectorSite);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteAdded.Result).Value);
            SamplingPlanSubsectorSite samplingPlanSubsectorSiteAdded = (SamplingPlanSubsectorSite)((OkObjectResult)actionSamplingPlanSubsectorSiteAdded.Result).Value;
            Assert.NotNull(samplingPlanSubsectorSiteAdded);

            // List<SamplingPlanSubsectorSite>
            var actionSamplingPlanSubsectorSiteList = await SamplingPlanSubsectorSiteDBService.GetSamplingPlanSubsectorSiteList();
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteList.Result).Value);
            List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = (List<SamplingPlanSubsectorSite>)((OkObjectResult)actionSamplingPlanSubsectorSiteList.Result).Value;

            int count = ((List<SamplingPlanSubsectorSite>)((OkObjectResult)actionSamplingPlanSubsectorSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // List<SamplingPlanSubsectorSite> with skip and take
            var actionSamplingPlanSubsectorSiteListSkipAndTake = await SamplingPlanSubsectorSiteDBService.GetSamplingPlanSubsectorSiteList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteListSkipAndTake.Result).Value);
            List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteListSkipAndTake = (List<SamplingPlanSubsectorSite>)((OkObjectResult)actionSamplingPlanSubsectorSiteListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<SamplingPlanSubsectorSite>)((OkObjectResult)actionSamplingPlanSubsectorSiteListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID == samplingPlanSubsectorSiteListSkipAndTake[0].SamplingPlanSubsectorSiteID);

            // Get SamplingPlanSubsectorSite With SamplingPlanSubsectorSiteID
            var actionSamplingPlanSubsectorSiteGet = await SamplingPlanSubsectorSiteDBService.GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteGet.Result).Value);
            SamplingPlanSubsectorSite samplingPlanSubsectorSiteGet = (SamplingPlanSubsectorSite)((OkObjectResult)actionSamplingPlanSubsectorSiteGet.Result).Value;
            Assert.NotNull(samplingPlanSubsectorSiteGet);
            Assert.Equal(samplingPlanSubsectorSiteGet.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);

            // Put SamplingPlanSubsectorSite
            var actionSamplingPlanSubsectorSiteUpdated = await SamplingPlanSubsectorSiteDBService.Put(samplingPlanSubsectorSite);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteUpdated.Result).Value);
            SamplingPlanSubsectorSite samplingPlanSubsectorSiteUpdated = (SamplingPlanSubsectorSite)((OkObjectResult)actionSamplingPlanSubsectorSiteUpdated.Result).Value;
            Assert.NotNull(samplingPlanSubsectorSiteUpdated);

            // Delete SamplingPlanSubsectorSite
            var actionSamplingPlanSubsectorSiteDeleted = await SamplingPlanSubsectorSiteDBService.Delete(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionSamplingPlanSubsectorSiteDeleted.Result).Value;
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
            Services.AddSingleton<ISamplingPlanSubsectorSiteDBService, SamplingPlanSubsectorSiteDBService>();

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

            SamplingPlanSubsectorSiteDBService = Provider.GetService<ISamplingPlanSubsectorSiteDBService>();
            Assert.NotNull(SamplingPlanSubsectorSiteDBService);

            return await Task.FromResult(true);
        }
        private SamplingPlanSubsectorSite GetFilledRandomSamplingPlanSubsectorSite(string OmitPropName)
        {
            SamplingPlanSubsectorSite samplingPlanSubsectorSite = new SamplingPlanSubsectorSite();

            if (OmitPropName != "DBCommand") samplingPlanSubsectorSite.DBCommand = (DBCommandEnum)GetRandomEnumType(typeof(DBCommandEnum));
            if (OmitPropName != "SamplingPlanSubsectorID") samplingPlanSubsectorSite.SamplingPlanSubsectorID = 1;
            if (OmitPropName != "MWQMSiteTVItemID") samplingPlanSubsectorSite.MWQMSiteTVItemID = 44;
            if (OmitPropName != "IsDuplicate") samplingPlanSubsectorSite.IsDuplicate = true;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsectorSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanSubsectorSite.LastUpdateContactTVItemID = 2;

            return samplingPlanSubsectorSite;
        }
        private void CheckSamplingPlanSubsectorSiteFields(List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList)
        {
        }

        #endregion Functions private
    }
}
