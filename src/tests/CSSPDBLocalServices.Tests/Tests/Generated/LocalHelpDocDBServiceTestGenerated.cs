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
    public partial class LocalHelpDocDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalHelpDocDBService LocalHelpDocDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalHelpDoc localHelpDoc { get; set; }
        #endregion Properties

        #region Constructors
        public LocalHelpDocDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalHelpDocDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalHelpDocDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localHelpDoc = GetFilledRandomLocalHelpDoc("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalHelpDoc_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalHelpDocList = await LocalHelpDocDBService.GetLocalHelpDocList();
            Assert.Equal(200, ((ObjectResult)actionLocalHelpDocList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalHelpDocList.Result).Value);
            List<LocalHelpDoc> localHelpDocList = (List<LocalHelpDoc>)((OkObjectResult)actionLocalHelpDocList.Result).Value;

            count = localHelpDocList.Count();

            LocalHelpDoc localHelpDoc = GetFilledRandomLocalHelpDoc("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localHelpDoc.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localHelpDoc = null;
            localHelpDoc = GetFilledRandomLocalHelpDoc("");
            localHelpDoc.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalHelpDoc = await LocalHelpDocDBService.Post(localHelpDoc);
            Assert.IsType<BadRequestObjectResult>(actionLocalHelpDoc.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localHelpDoc.HelpDocID   (Int32)
            // -----------------------------------

            localHelpDoc = null;
            localHelpDoc = GetFilledRandomLocalHelpDoc("");
            localHelpDoc.HelpDocID = 0;

            actionLocalHelpDoc = await LocalHelpDocDBService.Put(localHelpDoc);
            Assert.IsType<BadRequestObjectResult>(actionLocalHelpDoc.Result);

            localHelpDoc = null;
            localHelpDoc = GetFilledRandomLocalHelpDoc("");
            localHelpDoc.HelpDocID = 10000000;
            actionLocalHelpDoc = await LocalHelpDocDBService.Put(localHelpDoc);
            Assert.IsType<BadRequestObjectResult>(actionLocalHelpDoc.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // localHelpDoc.DocKey   (String)
            // -----------------------------------

            localHelpDoc = null;
            localHelpDoc = GetFilledRandomLocalHelpDoc("DocKey");
            actionLocalHelpDoc = await LocalHelpDocDBService.Post(localHelpDoc);
            Assert.IsType<BadRequestObjectResult>(actionLocalHelpDoc.Result);

            localHelpDoc = null;
            localHelpDoc = GetFilledRandomLocalHelpDoc("");
            localHelpDoc.DocKey = GetRandomString("", 101);
            actionLocalHelpDoc = await LocalHelpDocDBService.Post(localHelpDoc);
            Assert.IsType<BadRequestObjectResult>(actionLocalHelpDoc.Result);
            //Assert.AreEqual(count, localHelpDocDBService.GetLocalHelpDocList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localHelpDoc.Language   (LanguageEnum)
            // -----------------------------------

            localHelpDoc = null;
            localHelpDoc = GetFilledRandomLocalHelpDoc("");
            localHelpDoc.Language = (LanguageEnum)1000000;
             actionLocalHelpDoc = await LocalHelpDocDBService.Post(localHelpDoc);
            Assert.IsType<BadRequestObjectResult>(actionLocalHelpDoc.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100000)]
            // localHelpDoc.DocHTMLText   (String)
            // -----------------------------------

            localHelpDoc = null;
            localHelpDoc = GetFilledRandomLocalHelpDoc("DocHTMLText");
            actionLocalHelpDoc = await LocalHelpDocDBService.Post(localHelpDoc);
            Assert.IsType<BadRequestObjectResult>(actionLocalHelpDoc.Result);

            localHelpDoc = null;
            localHelpDoc = GetFilledRandomLocalHelpDoc("");
            localHelpDoc.DocHTMLText = GetRandomString("", 100001);
            actionLocalHelpDoc = await LocalHelpDocDBService.Post(localHelpDoc);
            Assert.IsType<BadRequestObjectResult>(actionLocalHelpDoc.Result);
            //Assert.AreEqual(count, localHelpDocDBService.GetLocalHelpDocList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localHelpDoc.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localHelpDoc = null;
            localHelpDoc = GetFilledRandomLocalHelpDoc("");
            localHelpDoc.LastUpdateDate_UTC = new DateTime();
            actionLocalHelpDoc = await LocalHelpDocDBService.Post(localHelpDoc);
            Assert.IsType<BadRequestObjectResult>(actionLocalHelpDoc.Result);
            localHelpDoc = null;
            localHelpDoc = GetFilledRandomLocalHelpDoc("");
            localHelpDoc.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalHelpDoc = await LocalHelpDocDBService.Post(localHelpDoc);
            Assert.IsType<BadRequestObjectResult>(actionLocalHelpDoc.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localHelpDoc.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localHelpDoc = null;
            localHelpDoc = GetFilledRandomLocalHelpDoc("");
            localHelpDoc.LastUpdateContactTVItemID = 0;
            actionLocalHelpDoc = await LocalHelpDocDBService.Post(localHelpDoc);
            Assert.IsType<BadRequestObjectResult>(actionLocalHelpDoc.Result);

            localHelpDoc = null;
            localHelpDoc = GetFilledRandomLocalHelpDoc("");
            localHelpDoc.LastUpdateContactTVItemID = 1;
            actionLocalHelpDoc = await LocalHelpDocDBService.Post(localHelpDoc);
            Assert.IsType<BadRequestObjectResult>(actionLocalHelpDoc.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalHelpDoc
            var actionLocalHelpDocAdded = await LocalHelpDocDBService.Post(localHelpDoc);
            Assert.Equal(200, ((ObjectResult)actionLocalHelpDocAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalHelpDocAdded.Result).Value);
            LocalHelpDoc localHelpDocAdded = (LocalHelpDoc)((OkObjectResult)actionLocalHelpDocAdded.Result).Value;
            Assert.NotNull(localHelpDocAdded);

            // List<LocalHelpDoc>
            var actionLocalHelpDocList = await LocalHelpDocDBService.GetLocalHelpDocList();
            Assert.Equal(200, ((ObjectResult)actionLocalHelpDocList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalHelpDocList.Result).Value);
            List<LocalHelpDoc> localHelpDocList = (List<LocalHelpDoc>)((OkObjectResult)actionLocalHelpDocList.Result).Value;

            int count = ((List<LocalHelpDoc>)((OkObjectResult)actionLocalHelpDocList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalHelpDoc> with skip and take
            var actionLocalHelpDocListSkipAndTake = await LocalHelpDocDBService.GetLocalHelpDocList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalHelpDocListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalHelpDocListSkipAndTake.Result).Value);
            List<LocalHelpDoc> localHelpDocListSkipAndTake = (List<LocalHelpDoc>)((OkObjectResult)actionLocalHelpDocListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalHelpDoc>)((OkObjectResult)actionLocalHelpDocListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localHelpDocList[0].HelpDocID == localHelpDocListSkipAndTake[0].HelpDocID);

            // Get LocalHelpDoc With HelpDocID
            var actionLocalHelpDocGet = await LocalHelpDocDBService.GetLocalHelpDocWithHelpDocID(localHelpDocList[0].HelpDocID);
            Assert.Equal(200, ((ObjectResult)actionLocalHelpDocGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalHelpDocGet.Result).Value);
            LocalHelpDoc localHelpDocGet = (LocalHelpDoc)((OkObjectResult)actionLocalHelpDocGet.Result).Value;
            Assert.NotNull(localHelpDocGet);
            Assert.Equal(localHelpDocGet.HelpDocID, localHelpDocList[0].HelpDocID);

            // Put LocalHelpDoc
            var actionLocalHelpDocUpdated = await LocalHelpDocDBService.Put(localHelpDoc);
            Assert.Equal(200, ((ObjectResult)actionLocalHelpDocUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalHelpDocUpdated.Result).Value);
            LocalHelpDoc localHelpDocUpdated = (LocalHelpDoc)((OkObjectResult)actionLocalHelpDocUpdated.Result).Value;
            Assert.NotNull(localHelpDocUpdated);

            // Delete LocalHelpDoc
            var actionLocalHelpDocDeleted = await LocalHelpDocDBService.Delete(localHelpDoc.HelpDocID);
            Assert.Equal(200, ((ObjectResult)actionLocalHelpDocDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalHelpDocDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalHelpDocDeleted.Result).Value;
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
            Services.AddSingleton<ILocalHelpDocDBService, LocalHelpDocDBService>();

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

            LocalHelpDocDBService = Provider.GetService<ILocalHelpDocDBService>();
            Assert.NotNull(LocalHelpDocDBService);

            return await Task.FromResult(true);
        }
        private LocalHelpDoc GetFilledRandomLocalHelpDoc(string OmitPropName)
        {
            LocalHelpDoc localHelpDoc = new LocalHelpDoc();

            if (OmitPropName != "LocalDBCommand") localHelpDoc.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "DocKey") localHelpDoc.DocKey = GetRandomString("", 5);
            if (OmitPropName != "Language") localHelpDoc.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "DocHTMLText") localHelpDoc.DocHTMLText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") localHelpDoc.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localHelpDoc.LastUpdateContactTVItemID = 2;



            return localHelpDoc;
        }
        private void CheckLocalHelpDocFields(List<LocalHelpDoc> localHelpDocList)
        {
            Assert.False(string.IsNullOrWhiteSpace(localHelpDocList[0].DocKey));
            Assert.False(string.IsNullOrWhiteSpace(localHelpDocList[0].DocHTMLText));
        }

        #endregion Functions private
    }
}
