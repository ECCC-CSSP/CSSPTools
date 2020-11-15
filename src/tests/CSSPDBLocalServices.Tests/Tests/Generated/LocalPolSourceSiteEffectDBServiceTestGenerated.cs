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
    public partial class LocalPolSourceSiteEffectDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalPolSourceSiteEffectDBService LocalPolSourceSiteEffectDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalPolSourceSiteEffect localPolSourceSiteEffect { get; set; }
        #endregion Properties

        #region Constructors
        public LocalPolSourceSiteEffectDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalPolSourceSiteEffectDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalPolSourceSiteEffectDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalPolSourceSiteEffect_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalPolSourceSiteEffectList = await LocalPolSourceSiteEffectDBService.GetLocalPolSourceSiteEffectList();
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceSiteEffectList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceSiteEffectList.Result).Value);
            List<LocalPolSourceSiteEffect> localPolSourceSiteEffectList = (List<LocalPolSourceSiteEffect>)((OkObjectResult)actionLocalPolSourceSiteEffectList.Result).Value;

            count = localPolSourceSiteEffectList.Count();

            LocalPolSourceSiteEffect localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localPolSourceSiteEffect.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Post(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localPolSourceSiteEffect.PolSourceSiteEffectID   (Int32)
            // -----------------------------------

            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.PolSourceSiteEffectID = 0;

            actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Put(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);

            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.PolSourceSiteEffectID = 10000000;
            actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Put(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure,PolSourceSite)]
            // localPolSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID   (Int32)
            // -----------------------------------

            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID = 0;
            actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Post(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);

            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID = 1;
            actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Post(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
            // localPolSourceSiteEffect.MWQMSiteTVItemID   (Int32)
            // -----------------------------------

            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.MWQMSiteTVItemID = 0;
            actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Post(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);

            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.MWQMSiteTVItemID = 1;
            actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Post(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(250)]
            // localPolSourceSiteEffect.PolSourceSiteEffectTermIDs   (String)
            // -----------------------------------

            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.PolSourceSiteEffectTermIDs = GetRandomString("", 251);
            actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Post(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);
            //Assert.AreEqual(count, localPolSourceSiteEffectDBService.GetLocalPolSourceSiteEffectList().Count());

            // -----------------------------------
            // Is Nullable
            // localPolSourceSiteEffect.Comments   (String)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = File)]
            // localPolSourceSiteEffect.AnalysisDocumentTVItemID   (Int32)
            // -----------------------------------

            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.AnalysisDocumentTVItemID = 0;
            actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Post(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);

            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.AnalysisDocumentTVItemID = 1;
            actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Post(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localPolSourceSiteEffect.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.LastUpdateDate_UTC = new DateTime();
            actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Post(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);
            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Post(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localPolSourceSiteEffect.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.LastUpdateContactTVItemID = 0;
            actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Post(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);

            localPolSourceSiteEffect = null;
            localPolSourceSiteEffect = GetFilledRandomLocalPolSourceSiteEffect("");
            localPolSourceSiteEffect.LastUpdateContactTVItemID = 1;
            actionLocalPolSourceSiteEffect = await LocalPolSourceSiteEffectDBService.Post(localPolSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceSiteEffect.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalPolSourceSiteEffect
            var actionLocalPolSourceSiteEffectAdded = await LocalPolSourceSiteEffectDBService.Post(localPolSourceSiteEffect);
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceSiteEffectAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceSiteEffectAdded.Result).Value);
            LocalPolSourceSiteEffect localPolSourceSiteEffectAdded = (LocalPolSourceSiteEffect)((OkObjectResult)actionLocalPolSourceSiteEffectAdded.Result).Value;
            Assert.NotNull(localPolSourceSiteEffectAdded);

            // List<LocalPolSourceSiteEffect>
            var actionLocalPolSourceSiteEffectList = await LocalPolSourceSiteEffectDBService.GetLocalPolSourceSiteEffectList();
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceSiteEffectList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceSiteEffectList.Result).Value);
            List<LocalPolSourceSiteEffect> localPolSourceSiteEffectList = (List<LocalPolSourceSiteEffect>)((OkObjectResult)actionLocalPolSourceSiteEffectList.Result).Value;

            int count = ((List<LocalPolSourceSiteEffect>)((OkObjectResult)actionLocalPolSourceSiteEffectList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalPolSourceSiteEffect> with skip and take
            var actionLocalPolSourceSiteEffectListSkipAndTake = await LocalPolSourceSiteEffectDBService.GetLocalPolSourceSiteEffectList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceSiteEffectListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceSiteEffectListSkipAndTake.Result).Value);
            List<LocalPolSourceSiteEffect> localPolSourceSiteEffectListSkipAndTake = (List<LocalPolSourceSiteEffect>)((OkObjectResult)actionLocalPolSourceSiteEffectListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalPolSourceSiteEffect>)((OkObjectResult)actionLocalPolSourceSiteEffectListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localPolSourceSiteEffectList[0].PolSourceSiteEffectID == localPolSourceSiteEffectListSkipAndTake[0].PolSourceSiteEffectID);

            // Get LocalPolSourceSiteEffect With PolSourceSiteEffectID
            var actionLocalPolSourceSiteEffectGet = await LocalPolSourceSiteEffectDBService.GetLocalPolSourceSiteEffectWithPolSourceSiteEffectID(localPolSourceSiteEffectList[0].PolSourceSiteEffectID);
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceSiteEffectGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceSiteEffectGet.Result).Value);
            LocalPolSourceSiteEffect localPolSourceSiteEffectGet = (LocalPolSourceSiteEffect)((OkObjectResult)actionLocalPolSourceSiteEffectGet.Result).Value;
            Assert.NotNull(localPolSourceSiteEffectGet);
            Assert.Equal(localPolSourceSiteEffectGet.PolSourceSiteEffectID, localPolSourceSiteEffectList[0].PolSourceSiteEffectID);

            // Put LocalPolSourceSiteEffect
            var actionLocalPolSourceSiteEffectUpdated = await LocalPolSourceSiteEffectDBService.Put(localPolSourceSiteEffect);
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceSiteEffectUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceSiteEffectUpdated.Result).Value);
            LocalPolSourceSiteEffect localPolSourceSiteEffectUpdated = (LocalPolSourceSiteEffect)((OkObjectResult)actionLocalPolSourceSiteEffectUpdated.Result).Value;
            Assert.NotNull(localPolSourceSiteEffectUpdated);

            // Delete LocalPolSourceSiteEffect
            var actionLocalPolSourceSiteEffectDeleted = await LocalPolSourceSiteEffectDBService.Delete(localPolSourceSiteEffect.PolSourceSiteEffectID);
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceSiteEffectDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceSiteEffectDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalPolSourceSiteEffectDeleted.Result).Value;
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
            Services.AddSingleton<ILocalPolSourceSiteEffectDBService, LocalPolSourceSiteEffectDBService>();

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

            LocalPolSourceSiteEffectDBService = Provider.GetService<ILocalPolSourceSiteEffectDBService>();
            Assert.NotNull(LocalPolSourceSiteEffectDBService);

            return await Task.FromResult(true);
        }
        private LocalPolSourceSiteEffect GetFilledRandomLocalPolSourceSiteEffect(string OmitPropName)
        {
            LocalPolSourceSiteEffect localPolSourceSiteEffect = new LocalPolSourceSiteEffect();

            if (OmitPropName != "LocalDBCommand") localPolSourceSiteEffect.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "PolSourceSiteOrInfrastructureTVItemID") localPolSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID = 41;
            if (OmitPropName != "MWQMSiteTVItemID") localPolSourceSiteEffect.MWQMSiteTVItemID = 44;
            if (OmitPropName != "PolSourceSiteEffectTermIDs") localPolSourceSiteEffect.PolSourceSiteEffectTermIDs = GetRandomString("", 5);
            if (OmitPropName != "Comments") localPolSourceSiteEffect.Comments = GetRandomString("", 20);
            if (OmitPropName != "AnalysisDocumentTVItemID") localPolSourceSiteEffect.AnalysisDocumentTVItemID = 42;
            if (OmitPropName != "LastUpdateDate_UTC") localPolSourceSiteEffect.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localPolSourceSiteEffect.LastUpdateContactTVItemID = 2;



            return localPolSourceSiteEffect;
        }
        private void CheckLocalPolSourceSiteEffectFields(List<LocalPolSourceSiteEffect> localPolSourceSiteEffectList)
        {
            if (!string.IsNullOrWhiteSpace(localPolSourceSiteEffectList[0].PolSourceSiteEffectTermIDs))
            {
                Assert.False(string.IsNullOrWhiteSpace(localPolSourceSiteEffectList[0].PolSourceSiteEffectTermIDs));
            }
            if (!string.IsNullOrWhiteSpace(localPolSourceSiteEffectList[0].Comments))
            {
                Assert.False(string.IsNullOrWhiteSpace(localPolSourceSiteEffectList[0].Comments));
            }
            if (localPolSourceSiteEffectList[0].AnalysisDocumentTVItemID != null)
            {
                Assert.NotNull(localPolSourceSiteEffectList[0].AnalysisDocumentTVItemID);
            }
        }

        #endregion Functions private
    }
}