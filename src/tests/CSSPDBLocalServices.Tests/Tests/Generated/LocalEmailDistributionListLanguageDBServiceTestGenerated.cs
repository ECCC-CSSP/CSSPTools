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
    public partial class LocalEmailDistributionListLanguageDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalEmailDistributionListLanguageDBService LocalEmailDistributionListLanguageDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalEmailDistributionListLanguage localEmailDistributionListLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public LocalEmailDistributionListLanguageDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalEmailDistributionListLanguageDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalEmailDistributionListLanguageDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalEmailDistributionListLanguage_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalEmailDistributionListLanguageList = await LocalEmailDistributionListLanguageDBService.GetLocalEmailDistributionListLanguageList();
            Assert.Equal(200, ((ObjectResult)actionLocalEmailDistributionListLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalEmailDistributionListLanguageList.Result).Value);
            List<LocalEmailDistributionListLanguage> localEmailDistributionListLanguageList = (List<LocalEmailDistributionListLanguage>)((OkObjectResult)actionLocalEmailDistributionListLanguageList.Result).Value;

            count = localEmailDistributionListLanguageList.Count();

            LocalEmailDistributionListLanguage localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localEmailDistributionListLanguage.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localEmailDistributionListLanguage = null;
            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");
            localEmailDistributionListLanguage.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalEmailDistributionListLanguage = await LocalEmailDistributionListLanguageDBService.Post(localEmailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalEmailDistributionListLanguage.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localEmailDistributionListLanguage.EmailDistributionListLanguageID   (Int32)
            // -----------------------------------

            localEmailDistributionListLanguage = null;
            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");
            localEmailDistributionListLanguage.EmailDistributionListLanguageID = 0;

            actionLocalEmailDistributionListLanguage = await LocalEmailDistributionListLanguageDBService.Put(localEmailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalEmailDistributionListLanguage.Result);

            localEmailDistributionListLanguage = null;
            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");
            localEmailDistributionListLanguage.EmailDistributionListLanguageID = 10000000;
            actionLocalEmailDistributionListLanguage = await LocalEmailDistributionListLanguageDBService.Put(localEmailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalEmailDistributionListLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID", AllowableTVtypeList = )]
            // localEmailDistributionListLanguage.EmailDistributionListID   (Int32)
            // -----------------------------------

            localEmailDistributionListLanguage = null;
            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");
            localEmailDistributionListLanguage.EmailDistributionListID = 0;
            actionLocalEmailDistributionListLanguage = await LocalEmailDistributionListLanguageDBService.Post(localEmailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalEmailDistributionListLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localEmailDistributionListLanguage.Language   (LanguageEnum)
            // -----------------------------------

            localEmailDistributionListLanguage = null;
            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");
            localEmailDistributionListLanguage.Language = (LanguageEnum)1000000;
             actionLocalEmailDistributionListLanguage = await LocalEmailDistributionListLanguageDBService.Post(localEmailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalEmailDistributionListLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // [CSSPMinLength(1)]
            // localEmailDistributionListLanguage.EmailListName   (String)
            // -----------------------------------

            localEmailDistributionListLanguage = null;
            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("EmailListName");
            actionLocalEmailDistributionListLanguage = await LocalEmailDistributionListLanguageDBService.Post(localEmailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalEmailDistributionListLanguage.Result);

            localEmailDistributionListLanguage = null;
            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");
            localEmailDistributionListLanguage = null;
            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");
            localEmailDistributionListLanguage.EmailListName = GetRandomString("", 101);
            actionLocalEmailDistributionListLanguage = await LocalEmailDistributionListLanguageDBService.Post(localEmailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalEmailDistributionListLanguage.Result);
            //Assert.AreEqual(count, localEmailDistributionListLanguageDBService.GetLocalEmailDistributionListLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localEmailDistributionListLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            localEmailDistributionListLanguage = null;
            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");
            localEmailDistributionListLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
             actionLocalEmailDistributionListLanguage = await LocalEmailDistributionListLanguageDBService.Post(localEmailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalEmailDistributionListLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localEmailDistributionListLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localEmailDistributionListLanguage = null;
            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");
            localEmailDistributionListLanguage.LastUpdateDate_UTC = new DateTime();
            actionLocalEmailDistributionListLanguage = await LocalEmailDistributionListLanguageDBService.Post(localEmailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalEmailDistributionListLanguage.Result);
            localEmailDistributionListLanguage = null;
            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");
            localEmailDistributionListLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalEmailDistributionListLanguage = await LocalEmailDistributionListLanguageDBService.Post(localEmailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalEmailDistributionListLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localEmailDistributionListLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localEmailDistributionListLanguage = null;
            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");
            localEmailDistributionListLanguage.LastUpdateContactTVItemID = 0;
            actionLocalEmailDistributionListLanguage = await LocalEmailDistributionListLanguageDBService.Post(localEmailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalEmailDistributionListLanguage.Result);

            localEmailDistributionListLanguage = null;
            localEmailDistributionListLanguage = GetFilledRandomLocalEmailDistributionListLanguage("");
            localEmailDistributionListLanguage.LastUpdateContactTVItemID = 1;
            actionLocalEmailDistributionListLanguage = await LocalEmailDistributionListLanguageDBService.Post(localEmailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalEmailDistributionListLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalEmailDistributionListLanguage
            var actionLocalEmailDistributionListLanguageAdded = await LocalEmailDistributionListLanguageDBService.Post(localEmailDistributionListLanguage);
            Assert.Equal(200, ((ObjectResult)actionLocalEmailDistributionListLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalEmailDistributionListLanguageAdded.Result).Value);
            LocalEmailDistributionListLanguage localEmailDistributionListLanguageAdded = (LocalEmailDistributionListLanguage)((OkObjectResult)actionLocalEmailDistributionListLanguageAdded.Result).Value;
            Assert.NotNull(localEmailDistributionListLanguageAdded);

            // List<LocalEmailDistributionListLanguage>
            var actionLocalEmailDistributionListLanguageList = await LocalEmailDistributionListLanguageDBService.GetLocalEmailDistributionListLanguageList();
            Assert.Equal(200, ((ObjectResult)actionLocalEmailDistributionListLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalEmailDistributionListLanguageList.Result).Value);
            List<LocalEmailDistributionListLanguage> localEmailDistributionListLanguageList = (List<LocalEmailDistributionListLanguage>)((OkObjectResult)actionLocalEmailDistributionListLanguageList.Result).Value;

            int count = ((List<LocalEmailDistributionListLanguage>)((OkObjectResult)actionLocalEmailDistributionListLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalEmailDistributionListLanguage> with skip and take
            var actionLocalEmailDistributionListLanguageListSkipAndTake = await LocalEmailDistributionListLanguageDBService.GetLocalEmailDistributionListLanguageList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalEmailDistributionListLanguageListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalEmailDistributionListLanguageListSkipAndTake.Result).Value);
            List<LocalEmailDistributionListLanguage> localEmailDistributionListLanguageListSkipAndTake = (List<LocalEmailDistributionListLanguage>)((OkObjectResult)actionLocalEmailDistributionListLanguageListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalEmailDistributionListLanguage>)((OkObjectResult)actionLocalEmailDistributionListLanguageListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localEmailDistributionListLanguageList[0].EmailDistributionListLanguageID == localEmailDistributionListLanguageListSkipAndTake[0].EmailDistributionListLanguageID);

            // Get LocalEmailDistributionListLanguage With EmailDistributionListLanguageID
            var actionLocalEmailDistributionListLanguageGet = await LocalEmailDistributionListLanguageDBService.GetLocalEmailDistributionListLanguageWithEmailDistributionListLanguageID(localEmailDistributionListLanguageList[0].EmailDistributionListLanguageID);
            Assert.Equal(200, ((ObjectResult)actionLocalEmailDistributionListLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalEmailDistributionListLanguageGet.Result).Value);
            LocalEmailDistributionListLanguage localEmailDistributionListLanguageGet = (LocalEmailDistributionListLanguage)((OkObjectResult)actionLocalEmailDistributionListLanguageGet.Result).Value;
            Assert.NotNull(localEmailDistributionListLanguageGet);
            Assert.Equal(localEmailDistributionListLanguageGet.EmailDistributionListLanguageID, localEmailDistributionListLanguageList[0].EmailDistributionListLanguageID);

            // Put LocalEmailDistributionListLanguage
            var actionLocalEmailDistributionListLanguageUpdated = await LocalEmailDistributionListLanguageDBService.Put(localEmailDistributionListLanguage);
            Assert.Equal(200, ((ObjectResult)actionLocalEmailDistributionListLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalEmailDistributionListLanguageUpdated.Result).Value);
            LocalEmailDistributionListLanguage localEmailDistributionListLanguageUpdated = (LocalEmailDistributionListLanguage)((OkObjectResult)actionLocalEmailDistributionListLanguageUpdated.Result).Value;
            Assert.NotNull(localEmailDistributionListLanguageUpdated);

            // Delete LocalEmailDistributionListLanguage
            var actionLocalEmailDistributionListLanguageDeleted = await LocalEmailDistributionListLanguageDBService.Delete(localEmailDistributionListLanguage.EmailDistributionListLanguageID);
            Assert.Equal(200, ((ObjectResult)actionLocalEmailDistributionListLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalEmailDistributionListLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalEmailDistributionListLanguageDeleted.Result).Value;
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
            Services.AddSingleton<ILocalEmailDistributionListLanguageDBService, LocalEmailDistributionListLanguageDBService>();

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

            LocalEmailDistributionListLanguageDBService = Provider.GetService<ILocalEmailDistributionListLanguageDBService>();
            Assert.NotNull(LocalEmailDistributionListLanguageDBService);

            return await Task.FromResult(true);
        }
        private LocalEmailDistributionListLanguage GetFilledRandomLocalEmailDistributionListLanguage(string OmitPropName)
        {
            LocalEmailDistributionListLanguage localEmailDistributionListLanguage = new LocalEmailDistributionListLanguage();

            if (OmitPropName != "LocalDBCommand") localEmailDistributionListLanguage.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "EmailDistributionListID") localEmailDistributionListLanguage.EmailDistributionListID = 0;
            if (OmitPropName != "Language") localEmailDistributionListLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "EmailListName") localEmailDistributionListLanguage.EmailListName = GetRandomString("", 6);
            if (OmitPropName != "TranslationStatus") localEmailDistributionListLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") localEmailDistributionListLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localEmailDistributionListLanguage.LastUpdateContactTVItemID = 2;



            return localEmailDistributionListLanguage;
        }
        private void CheckLocalEmailDistributionListLanguageFields(List<LocalEmailDistributionListLanguage> localEmailDistributionListLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(localEmailDistributionListLanguageList[0].EmailListName));
        }

        #endregion Functions private
    }
}
