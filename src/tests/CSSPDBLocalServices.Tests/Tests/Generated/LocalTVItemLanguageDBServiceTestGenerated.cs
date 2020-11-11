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
    public partial class LocalTVItemLanguageDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalTVItemLanguageDBService LocalTVItemLanguageDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalTVItemLanguage localTVItemLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public LocalTVItemLanguageDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalTVItemLanguageDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalTVItemLanguageDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalTVItemLanguage_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalTVItemLanguageList = await LocalTVItemLanguageDBService.GetLocalTVItemLanguageList();
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemLanguageList.Result).Value);
            List<LocalTVItemLanguage> localTVItemLanguageList = (List<LocalTVItemLanguage>)((OkObjectResult)actionLocalTVItemLanguageList.Result).Value;

            count = localTVItemLanguageList.Count();

            LocalTVItemLanguage localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localTVItemLanguage.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localTVItemLanguage = null;
            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");
            localTVItemLanguage.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalTVItemLanguage = await LocalTVItemLanguageDBService.Post(localTVItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItemLanguage.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localTVItemLanguage.TVItemLanguageID   (Int32)
            // -----------------------------------

            localTVItemLanguage = null;
            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");
            localTVItemLanguage.TVItemLanguageID = 0;

            actionLocalTVItemLanguage = await LocalTVItemLanguageDBService.Put(localTVItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItemLanguage.Result);

            localTVItemLanguage = null;
            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");
            localTVItemLanguage.TVItemLanguageID = 10000000;
            actionLocalTVItemLanguage = await LocalTVItemLanguageDBService.Put(localTVItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItemLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification)]
            // localTVItemLanguage.TVItemID   (Int32)
            // -----------------------------------

            localTVItemLanguage = null;
            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");
            localTVItemLanguage.TVItemID = 0;
            actionLocalTVItemLanguage = await LocalTVItemLanguageDBService.Post(localTVItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItemLanguage.Result);

            localTVItemLanguage = null;
            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");
            localTVItemLanguage.TVItemID = 38;
            actionLocalTVItemLanguage = await LocalTVItemLanguageDBService.Post(localTVItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItemLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localTVItemLanguage.Language   (LanguageEnum)
            // -----------------------------------

            localTVItemLanguage = null;
            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");
            localTVItemLanguage.Language = (LanguageEnum)1000000;
             actionLocalTVItemLanguage = await LocalTVItemLanguageDBService.Post(localTVItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItemLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(200)]
            // localTVItemLanguage.TVText   (String)
            // -----------------------------------

            localTVItemLanguage = null;
            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("TVText");
            actionLocalTVItemLanguage = await LocalTVItemLanguageDBService.Post(localTVItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItemLanguage.Result);

            localTVItemLanguage = null;
            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");
            localTVItemLanguage.TVText = GetRandomString("", 201);
            actionLocalTVItemLanguage = await LocalTVItemLanguageDBService.Post(localTVItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItemLanguage.Result);
            //Assert.AreEqual(count, localTVItemLanguageDBService.GetLocalTVItemLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localTVItemLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            localTVItemLanguage = null;
            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");
            localTVItemLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
             actionLocalTVItemLanguage = await LocalTVItemLanguageDBService.Post(localTVItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItemLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localTVItemLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localTVItemLanguage = null;
            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");
            localTVItemLanguage.LastUpdateDate_UTC = new DateTime();
            actionLocalTVItemLanguage = await LocalTVItemLanguageDBService.Post(localTVItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItemLanguage.Result);
            localTVItemLanguage = null;
            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");
            localTVItemLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalTVItemLanguage = await LocalTVItemLanguageDBService.Post(localTVItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItemLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localTVItemLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localTVItemLanguage = null;
            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");
            localTVItemLanguage.LastUpdateContactTVItemID = 0;
            actionLocalTVItemLanguage = await LocalTVItemLanguageDBService.Post(localTVItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItemLanguage.Result);

            localTVItemLanguage = null;
            localTVItemLanguage = GetFilledRandomLocalTVItemLanguage("");
            localTVItemLanguage.LastUpdateContactTVItemID = 1;
            actionLocalTVItemLanguage = await LocalTVItemLanguageDBService.Post(localTVItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVItemLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalTVItemLanguage
            var actionLocalTVItemLanguageAdded = await LocalTVItemLanguageDBService.Post(localTVItemLanguage);
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemLanguageAdded.Result).Value);
            LocalTVItemLanguage localTVItemLanguageAdded = (LocalTVItemLanguage)((OkObjectResult)actionLocalTVItemLanguageAdded.Result).Value;
            Assert.NotNull(localTVItemLanguageAdded);

            // List<LocalTVItemLanguage>
            var actionLocalTVItemLanguageList = await LocalTVItemLanguageDBService.GetLocalTVItemLanguageList();
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemLanguageList.Result).Value);
            List<LocalTVItemLanguage> localTVItemLanguageList = (List<LocalTVItemLanguage>)((OkObjectResult)actionLocalTVItemLanguageList.Result).Value;

            int count = ((List<LocalTVItemLanguage>)((OkObjectResult)actionLocalTVItemLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalTVItemLanguage> with skip and take
            var actionLocalTVItemLanguageListSkipAndTake = await LocalTVItemLanguageDBService.GetLocalTVItemLanguageList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemLanguageListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemLanguageListSkipAndTake.Result).Value);
            List<LocalTVItemLanguage> localTVItemLanguageListSkipAndTake = (List<LocalTVItemLanguage>)((OkObjectResult)actionLocalTVItemLanguageListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalTVItemLanguage>)((OkObjectResult)actionLocalTVItemLanguageListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localTVItemLanguageList[0].TVItemLanguageID == localTVItemLanguageListSkipAndTake[0].TVItemLanguageID);

            // Get LocalTVItemLanguage With TVItemLanguageID
            var actionLocalTVItemLanguageGet = await LocalTVItemLanguageDBService.GetLocalTVItemLanguageWithTVItemLanguageID(localTVItemLanguageList[0].TVItemLanguageID);
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemLanguageGet.Result).Value);
            LocalTVItemLanguage localTVItemLanguageGet = (LocalTVItemLanguage)((OkObjectResult)actionLocalTVItemLanguageGet.Result).Value;
            Assert.NotNull(localTVItemLanguageGet);
            Assert.Equal(localTVItemLanguageGet.TVItemLanguageID, localTVItemLanguageList[0].TVItemLanguageID);

            // Put LocalTVItemLanguage
            var actionLocalTVItemLanguageUpdated = await LocalTVItemLanguageDBService.Put(localTVItemLanguage);
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemLanguageUpdated.Result).Value);
            LocalTVItemLanguage localTVItemLanguageUpdated = (LocalTVItemLanguage)((OkObjectResult)actionLocalTVItemLanguageUpdated.Result).Value;
            Assert.NotNull(localTVItemLanguageUpdated);

            // Delete LocalTVItemLanguage
            var actionLocalTVItemLanguageDeleted = await LocalTVItemLanguageDBService.Delete(localTVItemLanguage.TVItemLanguageID);
            Assert.Equal(200, ((ObjectResult)actionLocalTVItemLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVItemLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalTVItemLanguageDeleted.Result).Value;
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
            Services.AddSingleton<ILocalTVItemLanguageDBService, LocalTVItemLanguageDBService>();

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

            LocalTVItemLanguageDBService = Provider.GetService<ILocalTVItemLanguageDBService>();
            Assert.NotNull(LocalTVItemLanguageDBService);

            return await Task.FromResult(true);
        }
        private LocalTVItemLanguage GetFilledRandomLocalTVItemLanguage(string OmitPropName)
        {
            LocalTVItemLanguage localTVItemLanguage = new LocalTVItemLanguage();

            if (OmitPropName != "LocalDBCommand") localTVItemLanguage.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "TVItemID") localTVItemLanguage.TVItemID = 1;
            if (OmitPropName != "Language") localTVItemLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "TVText") localTVItemLanguage.TVText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") localTVItemLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") localTVItemLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localTVItemLanguage.LastUpdateContactTVItemID = 2;



            return localTVItemLanguage;
        }
        private void CheckLocalTVItemLanguageFields(List<LocalTVItemLanguage> localTVItemLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(localTVItemLanguageList[0].TVText));
        }

        #endregion Functions private
    }
}
