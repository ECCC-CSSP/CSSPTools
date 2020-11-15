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
    public partial class LocalMWQMSubsectorLanguageDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalMWQMSubsectorLanguageDBService LocalMWQMSubsectorLanguageDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalMWQMSubsectorLanguage localMWQMSubsectorLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public LocalMWQMSubsectorLanguageDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalMWQMSubsectorLanguageDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalMWQMSubsectorLanguageDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalMWQMSubsectorLanguage_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalMWQMSubsectorLanguageList = await LocalMWQMSubsectorLanguageDBService.GetLocalMWQMSubsectorLanguageList();
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSubsectorLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSubsectorLanguageList.Result).Value);
            List<LocalMWQMSubsectorLanguage> localMWQMSubsectorLanguageList = (List<LocalMWQMSubsectorLanguage>)((OkObjectResult)actionLocalMWQMSubsectorLanguageList.Result).Value;

            count = localMWQMSubsectorLanguageList.Count();

            LocalMWQMSubsectorLanguage localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localMWQMSubsectorLanguage.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localMWQMSubsectorLanguage = null;
            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");
            localMWQMSubsectorLanguage.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalMWQMSubsectorLanguage = await LocalMWQMSubsectorLanguageDBService.Post(localMWQMSubsectorLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSubsectorLanguage.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localMWQMSubsectorLanguage.MWQMSubsectorLanguageID   (Int32)
            // -----------------------------------

            localMWQMSubsectorLanguage = null;
            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");
            localMWQMSubsectorLanguage.MWQMSubsectorLanguageID = 0;

            actionLocalMWQMSubsectorLanguage = await LocalMWQMSubsectorLanguageDBService.Put(localMWQMSubsectorLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSubsectorLanguage.Result);

            localMWQMSubsectorLanguage = null;
            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");
            localMWQMSubsectorLanguage.MWQMSubsectorLanguageID = 10000000;
            actionLocalMWQMSubsectorLanguage = await LocalMWQMSubsectorLanguageDBService.Put(localMWQMSubsectorLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSubsectorLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "MWQMSubsector", ExistPlurial = "s", ExistFieldID = "MWQMSubsectorID", AllowableTVtypeList = )]
            // localMWQMSubsectorLanguage.MWQMSubsectorID   (Int32)
            // -----------------------------------

            localMWQMSubsectorLanguage = null;
            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");
            localMWQMSubsectorLanguage.MWQMSubsectorID = 0;
            actionLocalMWQMSubsectorLanguage = await LocalMWQMSubsectorLanguageDBService.Post(localMWQMSubsectorLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSubsectorLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localMWQMSubsectorLanguage.Language   (LanguageEnum)
            // -----------------------------------

            localMWQMSubsectorLanguage = null;
            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");
            localMWQMSubsectorLanguage.Language = (LanguageEnum)1000000;
             actionLocalMWQMSubsectorLanguage = await LocalMWQMSubsectorLanguageDBService.Post(localMWQMSubsectorLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSubsectorLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // localMWQMSubsectorLanguage.SubsectorDesc   (String)
            // -----------------------------------

            localMWQMSubsectorLanguage = null;
            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("SubsectorDesc");
            actionLocalMWQMSubsectorLanguage = await LocalMWQMSubsectorLanguageDBService.Post(localMWQMSubsectorLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSubsectorLanguage.Result);

            localMWQMSubsectorLanguage = null;
            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");
            localMWQMSubsectorLanguage.SubsectorDesc = GetRandomString("", 251);
            actionLocalMWQMSubsectorLanguage = await LocalMWQMSubsectorLanguageDBService.Post(localMWQMSubsectorLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSubsectorLanguage.Result);
            //Assert.AreEqual(count, localMWQMSubsectorLanguageDBService.GetLocalMWQMSubsectorLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localMWQMSubsectorLanguage.TranslationStatusSubsectorDesc   (TranslationStatusEnum)
            // -----------------------------------

            localMWQMSubsectorLanguage = null;
            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");
            localMWQMSubsectorLanguage.TranslationStatusSubsectorDesc = (TranslationStatusEnum)1000000;
             actionLocalMWQMSubsectorLanguage = await LocalMWQMSubsectorLanguageDBService.Post(localMWQMSubsectorLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSubsectorLanguage.Result);


            // -----------------------------------
            // Is Nullable
            // localMWQMSubsectorLanguage.LogBook   (String)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // localMWQMSubsectorLanguage.TranslationStatusLogBook   (TranslationStatusEnum)
            // -----------------------------------

            localMWQMSubsectorLanguage = null;
            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");
            localMWQMSubsectorLanguage.TranslationStatusLogBook = (TranslationStatusEnum)1000000;
             actionLocalMWQMSubsectorLanguage = await LocalMWQMSubsectorLanguageDBService.Post(localMWQMSubsectorLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSubsectorLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localMWQMSubsectorLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localMWQMSubsectorLanguage = null;
            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");
            localMWQMSubsectorLanguage.LastUpdateDate_UTC = new DateTime();
            actionLocalMWQMSubsectorLanguage = await LocalMWQMSubsectorLanguageDBService.Post(localMWQMSubsectorLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSubsectorLanguage.Result);
            localMWQMSubsectorLanguage = null;
            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");
            localMWQMSubsectorLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalMWQMSubsectorLanguage = await LocalMWQMSubsectorLanguageDBService.Post(localMWQMSubsectorLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSubsectorLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localMWQMSubsectorLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localMWQMSubsectorLanguage = null;
            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");
            localMWQMSubsectorLanguage.LastUpdateContactTVItemID = 0;
            actionLocalMWQMSubsectorLanguage = await LocalMWQMSubsectorLanguageDBService.Post(localMWQMSubsectorLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSubsectorLanguage.Result);

            localMWQMSubsectorLanguage = null;
            localMWQMSubsectorLanguage = GetFilledRandomLocalMWQMSubsectorLanguage("");
            localMWQMSubsectorLanguage.LastUpdateContactTVItemID = 1;
            actionLocalMWQMSubsectorLanguage = await LocalMWQMSubsectorLanguageDBService.Post(localMWQMSubsectorLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalMWQMSubsectorLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalMWQMSubsectorLanguage
            var actionLocalMWQMSubsectorLanguageAdded = await LocalMWQMSubsectorLanguageDBService.Post(localMWQMSubsectorLanguage);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSubsectorLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSubsectorLanguageAdded.Result).Value);
            LocalMWQMSubsectorLanguage localMWQMSubsectorLanguageAdded = (LocalMWQMSubsectorLanguage)((OkObjectResult)actionLocalMWQMSubsectorLanguageAdded.Result).Value;
            Assert.NotNull(localMWQMSubsectorLanguageAdded);

            // List<LocalMWQMSubsectorLanguage>
            var actionLocalMWQMSubsectorLanguageList = await LocalMWQMSubsectorLanguageDBService.GetLocalMWQMSubsectorLanguageList();
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSubsectorLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSubsectorLanguageList.Result).Value);
            List<LocalMWQMSubsectorLanguage> localMWQMSubsectorLanguageList = (List<LocalMWQMSubsectorLanguage>)((OkObjectResult)actionLocalMWQMSubsectorLanguageList.Result).Value;

            int count = ((List<LocalMWQMSubsectorLanguage>)((OkObjectResult)actionLocalMWQMSubsectorLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalMWQMSubsectorLanguage> with skip and take
            var actionLocalMWQMSubsectorLanguageListSkipAndTake = await LocalMWQMSubsectorLanguageDBService.GetLocalMWQMSubsectorLanguageList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSubsectorLanguageListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSubsectorLanguageListSkipAndTake.Result).Value);
            List<LocalMWQMSubsectorLanguage> localMWQMSubsectorLanguageListSkipAndTake = (List<LocalMWQMSubsectorLanguage>)((OkObjectResult)actionLocalMWQMSubsectorLanguageListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalMWQMSubsectorLanguage>)((OkObjectResult)actionLocalMWQMSubsectorLanguageListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localMWQMSubsectorLanguageList[0].MWQMSubsectorLanguageID == localMWQMSubsectorLanguageListSkipAndTake[0].MWQMSubsectorLanguageID);

            // Get LocalMWQMSubsectorLanguage With MWQMSubsectorLanguageID
            var actionLocalMWQMSubsectorLanguageGet = await LocalMWQMSubsectorLanguageDBService.GetLocalMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(localMWQMSubsectorLanguageList[0].MWQMSubsectorLanguageID);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSubsectorLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSubsectorLanguageGet.Result).Value);
            LocalMWQMSubsectorLanguage localMWQMSubsectorLanguageGet = (LocalMWQMSubsectorLanguage)((OkObjectResult)actionLocalMWQMSubsectorLanguageGet.Result).Value;
            Assert.NotNull(localMWQMSubsectorLanguageGet);
            Assert.Equal(localMWQMSubsectorLanguageGet.MWQMSubsectorLanguageID, localMWQMSubsectorLanguageList[0].MWQMSubsectorLanguageID);

            // Put LocalMWQMSubsectorLanguage
            var actionLocalMWQMSubsectorLanguageUpdated = await LocalMWQMSubsectorLanguageDBService.Put(localMWQMSubsectorLanguage);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSubsectorLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSubsectorLanguageUpdated.Result).Value);
            LocalMWQMSubsectorLanguage localMWQMSubsectorLanguageUpdated = (LocalMWQMSubsectorLanguage)((OkObjectResult)actionLocalMWQMSubsectorLanguageUpdated.Result).Value;
            Assert.NotNull(localMWQMSubsectorLanguageUpdated);

            // Delete LocalMWQMSubsectorLanguage
            var actionLocalMWQMSubsectorLanguageDeleted = await LocalMWQMSubsectorLanguageDBService.Delete(localMWQMSubsectorLanguage.MWQMSubsectorLanguageID);
            Assert.Equal(200, ((ObjectResult)actionLocalMWQMSubsectorLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalMWQMSubsectorLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalMWQMSubsectorLanguageDeleted.Result).Value;
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
            Services.AddSingleton<ILocalMWQMSubsectorLanguageDBService, LocalMWQMSubsectorLanguageDBService>();

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

            LocalMWQMSubsectorLanguageDBService = Provider.GetService<ILocalMWQMSubsectorLanguageDBService>();
            Assert.NotNull(LocalMWQMSubsectorLanguageDBService);

            return await Task.FromResult(true);
        }
        private LocalMWQMSubsectorLanguage GetFilledRandomLocalMWQMSubsectorLanguage(string OmitPropName)
        {
            LocalMWQMSubsectorLanguage localMWQMSubsectorLanguage = new LocalMWQMSubsectorLanguage();

            if (OmitPropName != "LocalDBCommand") localMWQMSubsectorLanguage.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "MWQMSubsectorID") localMWQMSubsectorLanguage.MWQMSubsectorID = 0;
            if (OmitPropName != "Language") localMWQMSubsectorLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "SubsectorDesc") localMWQMSubsectorLanguage.SubsectorDesc = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusSubsectorDesc") localMWQMSubsectorLanguage.TranslationStatusSubsectorDesc = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LogBook") localMWQMSubsectorLanguage.LogBook = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusLogBook") localMWQMSubsectorLanguage.TranslationStatusLogBook = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") localMWQMSubsectorLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localMWQMSubsectorLanguage.LastUpdateContactTVItemID = 2;



            return localMWQMSubsectorLanguage;
        }
        private void CheckLocalMWQMSubsectorLanguageFields(List<LocalMWQMSubsectorLanguage> localMWQMSubsectorLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(localMWQMSubsectorLanguageList[0].SubsectorDesc));
            if (!string.IsNullOrWhiteSpace(localMWQMSubsectorLanguageList[0].LogBook))
            {
                Assert.False(string.IsNullOrWhiteSpace(localMWQMSubsectorLanguageList[0].LogBook));
            }
            if (localMWQMSubsectorLanguageList[0].TranslationStatusLogBook != null)
            {
                Assert.NotNull(localMWQMSubsectorLanguageList[0].TranslationStatusLogBook);
            }
        }

        #endregion Functions private
    }
}