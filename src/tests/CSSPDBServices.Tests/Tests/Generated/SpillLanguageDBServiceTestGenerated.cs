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
    public partial class SpillLanguageDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ISpillLanguageDBService SpillLanguageDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBContext dbIM { get; set; }
        private SpillLanguage spillLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SpillLanguageDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SpillLanguageDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            spillLanguage = GetFilledRandomSpillLanguage("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SpillLanguage_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionSpillLanguageList = await SpillLanguageDBService.GetSpillLanguageList();
            Assert.Equal(200, ((ObjectResult)actionSpillLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillLanguageList.Result).Value);
            List<SpillLanguage> spillLanguageList = (List<SpillLanguage>)((OkObjectResult)actionSpillLanguageList.Result).Value;

            count = spillLanguageList.Count();

            SpillLanguage spillLanguage = GetFilledRandomSpillLanguage("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // spillLanguage.SpillLanguageID   (Int32)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.SpillLanguageID = 0;

            var actionSpillLanguage = await SpillLanguageDBService.Put(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.SpillLanguageID = 10000000;
            actionSpillLanguage = await SpillLanguageDBService.Put(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // spillLanguage.DBCommand   (DBCommandEnum)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.DBCommand = (DBCommandEnum)1000000;
            actionSpillLanguage = await SpillLanguageDBService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "Spill", ExistPlurial = "s", ExistFieldID = "SpillID", AllowableTVtypeList = )]
            // spillLanguage.SpillID   (Int32)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.SpillID = 0;
            actionSpillLanguage = await SpillLanguageDBService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // spillLanguage.Language   (LanguageEnum)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.Language = (LanguageEnum)1000000;
            actionSpillLanguage = await SpillLanguageDBService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // spillLanguage.SpillComment   (String)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("SpillComment");
            actionSpillLanguage = await SpillLanguageDBService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // spillLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            actionSpillLanguage = await SpillLanguageDBService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // spillLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.LastUpdateDate_UTC = new DateTime();
            actionSpillLanguage = await SpillLanguageDBService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);
            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionSpillLanguage = await SpillLanguageDBService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // spillLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.LastUpdateContactTVItemID = 0;
            actionSpillLanguage = await SpillLanguageDBService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.LastUpdateContactTVItemID = 1;
            actionSpillLanguage = await SpillLanguageDBService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post SpillLanguage
            var actionSpillLanguageAdded = await SpillLanguageDBService.Post(spillLanguage);
            Assert.Equal(200, ((ObjectResult)actionSpillLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillLanguageAdded.Result).Value);
            SpillLanguage spillLanguageAdded = (SpillLanguage)((OkObjectResult)actionSpillLanguageAdded.Result).Value;
            Assert.NotNull(spillLanguageAdded);

            // List<SpillLanguage>
            var actionSpillLanguageList = await SpillLanguageDBService.GetSpillLanguageList();
            Assert.Equal(200, ((ObjectResult)actionSpillLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillLanguageList.Result).Value);
            List<SpillLanguage> spillLanguageList = (List<SpillLanguage>)((OkObjectResult)actionSpillLanguageList.Result).Value;

            int count = ((List<SpillLanguage>)((OkObjectResult)actionSpillLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // List<SpillLanguage> with skip and take
            var actionSpillLanguageListSkipAndTake = await SpillLanguageDBService.GetSpillLanguageList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionSpillLanguageListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillLanguageListSkipAndTake.Result).Value);
            List<SpillLanguage> spillLanguageListSkipAndTake = (List<SpillLanguage>)((OkObjectResult)actionSpillLanguageListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<SpillLanguage>)((OkObjectResult)actionSpillLanguageListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(spillLanguageList[0].SpillLanguageID == spillLanguageListSkipAndTake[0].SpillLanguageID);

            // Get SpillLanguage With SpillLanguageID
            var actionSpillLanguageGet = await SpillLanguageDBService.GetSpillLanguageWithSpillLanguageID(spillLanguageList[0].SpillLanguageID);
            Assert.Equal(200, ((ObjectResult)actionSpillLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillLanguageGet.Result).Value);
            SpillLanguage spillLanguageGet = (SpillLanguage)((OkObjectResult)actionSpillLanguageGet.Result).Value;
            Assert.NotNull(spillLanguageGet);
            Assert.Equal(spillLanguageGet.SpillLanguageID, spillLanguageList[0].SpillLanguageID);

            // Put SpillLanguage
            var actionSpillLanguageUpdated = await SpillLanguageDBService.Put(spillLanguage);
            Assert.Equal(200, ((ObjectResult)actionSpillLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillLanguageUpdated.Result).Value);
            SpillLanguage spillLanguageUpdated = (SpillLanguage)((OkObjectResult)actionSpillLanguageUpdated.Result).Value;
            Assert.NotNull(spillLanguageUpdated);

            // Delete SpillLanguage
            var actionSpillLanguageDeleted = await SpillLanguageDBService.Delete(spillLanguage.SpillLanguageID);
            Assert.Equal(200, ((ObjectResult)actionSpillLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionSpillLanguageDeleted.Result).Value;
            Assert.True(retBool);

            db.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("a79b4a81-ba75-4dfc-8d95-46259f73f055")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ISpillLanguageDBService, SpillLanguageDBService>();

            /* ---------------------------------------------------------------------------------
             * using TestDB
             * ---------------------------------------------------------------------------------      
             */
            string TestDB = Config.GetValue<string>("TestDB");
            Assert.NotNull(TestDB);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDB);
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBPreference
             * ---------------------------------------------------------------------------------
             */
            string CSSPDBPreference = Config.GetValue<string>("CSSPDBPreference"); 
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

            string LoginEmail = Config.GetValue<string>("LoginEmail");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(LoginEmail));

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            dbIM = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(dbIM);

            SpillLanguageDBService = Provider.GetService<ISpillLanguageDBService>();
            Assert.NotNull(SpillLanguageDBService);

            return await Task.FromResult(true);
        }
        private SpillLanguage GetFilledRandomSpillLanguage(string OmitPropName)
        {
            SpillLanguage spillLanguage = new SpillLanguage();

            if (OmitPropName != "DBCommand") spillLanguage.DBCommand = (DBCommandEnum)GetRandomEnumType(typeof(DBCommandEnum));
            if (OmitPropName != "SpillID") spillLanguage.SpillID = 1;
            if (OmitPropName != "Language") spillLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "SpillComment") spillLanguage.SpillComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") spillLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") spillLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") spillLanguage.LastUpdateContactTVItemID = 2;

            return spillLanguage;
        }
        private void CheckSpillLanguageFields(List<SpillLanguage> spillLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(spillLanguageList[0].SpillComment));
        }

        #endregion Functions private
    }
}
