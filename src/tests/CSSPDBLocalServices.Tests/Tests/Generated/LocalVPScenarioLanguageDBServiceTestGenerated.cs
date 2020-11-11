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
    public partial class LocalVPScenarioLanguageDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalVPScenarioLanguageDBService LocalVPScenarioLanguageDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalVPScenarioLanguage localVPScenarioLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public LocalVPScenarioLanguageDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalVPScenarioLanguageDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalVPScenarioLanguageDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalVPScenarioLanguage_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalVPScenarioLanguageList = await LocalVPScenarioLanguageDBService.GetLocalVPScenarioLanguageList();
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioLanguageList.Result).Value);
            List<LocalVPScenarioLanguage> localVPScenarioLanguageList = (List<LocalVPScenarioLanguage>)((OkObjectResult)actionLocalVPScenarioLanguageList.Result).Value;

            count = localVPScenarioLanguageList.Count();

            LocalVPScenarioLanguage localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localVPScenarioLanguage.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localVPScenarioLanguage = null;
            localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("");
            localVPScenarioLanguage.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalVPScenarioLanguage = await LocalVPScenarioLanguageDBService.Post(localVPScenarioLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenarioLanguage.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localVPScenarioLanguage.VPScenarioLanguageID   (Int32)
            // -----------------------------------

            localVPScenarioLanguage = null;
            localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("");
            localVPScenarioLanguage.VPScenarioLanguageID = 0;

            actionLocalVPScenarioLanguage = await LocalVPScenarioLanguageDBService.Put(localVPScenarioLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenarioLanguage.Result);

            localVPScenarioLanguage = null;
            localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("");
            localVPScenarioLanguage.VPScenarioLanguageID = 10000000;
            actionLocalVPScenarioLanguage = await LocalVPScenarioLanguageDBService.Put(localVPScenarioLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenarioLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = )]
            // localVPScenarioLanguage.VPScenarioID   (Int32)
            // -----------------------------------

            localVPScenarioLanguage = null;
            localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("");
            localVPScenarioLanguage.VPScenarioID = 0;
            actionLocalVPScenarioLanguage = await LocalVPScenarioLanguageDBService.Post(localVPScenarioLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenarioLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localVPScenarioLanguage.Language   (LanguageEnum)
            // -----------------------------------

            localVPScenarioLanguage = null;
            localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("");
            localVPScenarioLanguage.Language = (LanguageEnum)1000000;
             actionLocalVPScenarioLanguage = await LocalVPScenarioLanguageDBService.Post(localVPScenarioLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenarioLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // localVPScenarioLanguage.VPScenarioName   (String)
            // -----------------------------------

            localVPScenarioLanguage = null;
            localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("VPScenarioName");
            actionLocalVPScenarioLanguage = await LocalVPScenarioLanguageDBService.Post(localVPScenarioLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenarioLanguage.Result);

            localVPScenarioLanguage = null;
            localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("");
            localVPScenarioLanguage.VPScenarioName = GetRandomString("", 101);
            actionLocalVPScenarioLanguage = await LocalVPScenarioLanguageDBService.Post(localVPScenarioLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenarioLanguage.Result);
            //Assert.AreEqual(count, localVPScenarioLanguageDBService.GetLocalVPScenarioLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localVPScenarioLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            localVPScenarioLanguage = null;
            localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("");
            localVPScenarioLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
             actionLocalVPScenarioLanguage = await LocalVPScenarioLanguageDBService.Post(localVPScenarioLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenarioLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localVPScenarioLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localVPScenarioLanguage = null;
            localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("");
            localVPScenarioLanguage.LastUpdateDate_UTC = new DateTime();
            actionLocalVPScenarioLanguage = await LocalVPScenarioLanguageDBService.Post(localVPScenarioLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenarioLanguage.Result);
            localVPScenarioLanguage = null;
            localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("");
            localVPScenarioLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalVPScenarioLanguage = await LocalVPScenarioLanguageDBService.Post(localVPScenarioLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenarioLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localVPScenarioLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localVPScenarioLanguage = null;
            localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("");
            localVPScenarioLanguage.LastUpdateContactTVItemID = 0;
            actionLocalVPScenarioLanguage = await LocalVPScenarioLanguageDBService.Post(localVPScenarioLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenarioLanguage.Result);

            localVPScenarioLanguage = null;
            localVPScenarioLanguage = GetFilledRandomLocalVPScenarioLanguage("");
            localVPScenarioLanguage.LastUpdateContactTVItemID = 1;
            actionLocalVPScenarioLanguage = await LocalVPScenarioLanguageDBService.Post(localVPScenarioLanguage);
            Assert.IsType<BadRequestObjectResult>(actionLocalVPScenarioLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalVPScenarioLanguage
            var actionLocalVPScenarioLanguageAdded = await LocalVPScenarioLanguageDBService.Post(localVPScenarioLanguage);
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioLanguageAdded.Result).Value);
            LocalVPScenarioLanguage localVPScenarioLanguageAdded = (LocalVPScenarioLanguage)((OkObjectResult)actionLocalVPScenarioLanguageAdded.Result).Value;
            Assert.NotNull(localVPScenarioLanguageAdded);

            // List<LocalVPScenarioLanguage>
            var actionLocalVPScenarioLanguageList = await LocalVPScenarioLanguageDBService.GetLocalVPScenarioLanguageList();
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioLanguageList.Result).Value);
            List<LocalVPScenarioLanguage> localVPScenarioLanguageList = (List<LocalVPScenarioLanguage>)((OkObjectResult)actionLocalVPScenarioLanguageList.Result).Value;

            int count = ((List<LocalVPScenarioLanguage>)((OkObjectResult)actionLocalVPScenarioLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalVPScenarioLanguage> with skip and take
            var actionLocalVPScenarioLanguageListSkipAndTake = await LocalVPScenarioLanguageDBService.GetLocalVPScenarioLanguageList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioLanguageListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioLanguageListSkipAndTake.Result).Value);
            List<LocalVPScenarioLanguage> localVPScenarioLanguageListSkipAndTake = (List<LocalVPScenarioLanguage>)((OkObjectResult)actionLocalVPScenarioLanguageListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalVPScenarioLanguage>)((OkObjectResult)actionLocalVPScenarioLanguageListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localVPScenarioLanguageList[0].VPScenarioLanguageID == localVPScenarioLanguageListSkipAndTake[0].VPScenarioLanguageID);

            // Get LocalVPScenarioLanguage With VPScenarioLanguageID
            var actionLocalVPScenarioLanguageGet = await LocalVPScenarioLanguageDBService.GetLocalVPScenarioLanguageWithVPScenarioLanguageID(localVPScenarioLanguageList[0].VPScenarioLanguageID);
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioLanguageGet.Result).Value);
            LocalVPScenarioLanguage localVPScenarioLanguageGet = (LocalVPScenarioLanguage)((OkObjectResult)actionLocalVPScenarioLanguageGet.Result).Value;
            Assert.NotNull(localVPScenarioLanguageGet);
            Assert.Equal(localVPScenarioLanguageGet.VPScenarioLanguageID, localVPScenarioLanguageList[0].VPScenarioLanguageID);

            // Put LocalVPScenarioLanguage
            var actionLocalVPScenarioLanguageUpdated = await LocalVPScenarioLanguageDBService.Put(localVPScenarioLanguage);
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioLanguageUpdated.Result).Value);
            LocalVPScenarioLanguage localVPScenarioLanguageUpdated = (LocalVPScenarioLanguage)((OkObjectResult)actionLocalVPScenarioLanguageUpdated.Result).Value;
            Assert.NotNull(localVPScenarioLanguageUpdated);

            // Delete LocalVPScenarioLanguage
            var actionLocalVPScenarioLanguageDeleted = await LocalVPScenarioLanguageDBService.Delete(localVPScenarioLanguage.VPScenarioLanguageID);
            Assert.Equal(200, ((ObjectResult)actionLocalVPScenarioLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalVPScenarioLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalVPScenarioLanguageDeleted.Result).Value;
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
            Services.AddSingleton<ILocalVPScenarioLanguageDBService, LocalVPScenarioLanguageDBService>();

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

            LocalVPScenarioLanguageDBService = Provider.GetService<ILocalVPScenarioLanguageDBService>();
            Assert.NotNull(LocalVPScenarioLanguageDBService);

            return await Task.FromResult(true);
        }
        private LocalVPScenarioLanguage GetFilledRandomLocalVPScenarioLanguage(string OmitPropName)
        {
            LocalVPScenarioLanguage localVPScenarioLanguage = new LocalVPScenarioLanguage();

            if (OmitPropName != "LocalDBCommand") localVPScenarioLanguage.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "VPScenarioID") localVPScenarioLanguage.VPScenarioID = 0;
            if (OmitPropName != "Language") localVPScenarioLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "VPScenarioName") localVPScenarioLanguage.VPScenarioName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") localVPScenarioLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") localVPScenarioLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localVPScenarioLanguage.LastUpdateContactTVItemID = 2;



            return localVPScenarioLanguage;
        }
        private void CheckLocalVPScenarioLanguageFields(List<LocalVPScenarioLanguage> localVPScenarioLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(localVPScenarioLanguageList[0].VPScenarioName));
        }

        #endregion Functions private
    }
}
