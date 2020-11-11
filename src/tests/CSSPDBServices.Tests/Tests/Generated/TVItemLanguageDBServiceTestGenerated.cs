/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBServices_Tests.exe
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

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class TVItemLanguageDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITVItemLanguageDBService TVItemLanguageDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private TVItemLanguage tvItemLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLanguageDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLanguageDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLanguageDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            tvItemLanguage = GetFilledRandomTVItemLanguage("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLanguage_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionTVItemLanguageList = await TVItemLanguageDBService.GetTVItemLanguageList();
            Assert.Equal(200, ((ObjectResult)actionTVItemLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLanguageList.Result).Value);
            List<TVItemLanguage> tvItemLanguageList = (List<TVItemLanguage>)((OkObjectResult)actionTVItemLanguageList.Result).Value;

            count = tvItemLanguageList.Count();

            TVItemLanguage tvItemLanguage = GetFilledRandomTVItemLanguage("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tvItemLanguage.TVItemLanguageID   (Int32)
            // -----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.TVItemLanguageID = 0;

            var actionTVItemLanguage = await TVItemLanguageDBService.Put(tvItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLanguage.Result);

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.TVItemLanguageID = 10000000;
            actionTVItemLanguage = await TVItemLanguageDBService.Put(tvItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification)]
            // tvItemLanguage.TVItemID   (Int32)
            // -----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.TVItemID = 0;
            actionTVItemLanguage = await TVItemLanguageDBService.Post(tvItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLanguage.Result);

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.TVItemID = 38;
            actionTVItemLanguage = await TVItemLanguageDBService.Post(tvItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemLanguage.Language   (LanguageEnum)
            // -----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.Language = (LanguageEnum)1000000;
            actionTVItemLanguage = await TVItemLanguageDBService.Post(tvItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(200)]
            // tvItemLanguage.TVText   (String)
            // -----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("TVText");
            actionTVItemLanguage = await TVItemLanguageDBService.Post(tvItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLanguage.Result);

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.TVText = GetRandomString("", 201);
            actionTVItemLanguage = await TVItemLanguageDBService.Post(tvItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLanguage.Result);
            //Assert.AreEqual(count, tvItemLanguageDBService.GetTVItemLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            actionTVItemLanguage = await TVItemLanguageDBService.Post(tvItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItemLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.LastUpdateDate_UTC = new DateTime();
            actionTVItemLanguage = await TVItemLanguageDBService.Post(tvItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLanguage.Result);
            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTVItemLanguage = await TVItemLanguageDBService.Post(tvItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvItemLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.LastUpdateContactTVItemID = 0;
            actionTVItemLanguage = await TVItemLanguageDBService.Post(tvItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLanguage.Result);

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.LastUpdateContactTVItemID = 1;
            actionTVItemLanguage = await TVItemLanguageDBService.Post(tvItemLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post TVItemLanguage
            var actionTVItemLanguageAdded = await TVItemLanguageDBService.Post(tvItemLanguage);
            Assert.Equal(200, ((ObjectResult)actionTVItemLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLanguageAdded.Result).Value);
            TVItemLanguage tvItemLanguageAdded = (TVItemLanguage)((OkObjectResult)actionTVItemLanguageAdded.Result).Value;
            Assert.NotNull(tvItemLanguageAdded);

            // List<TVItemLanguage>
            var actionTVItemLanguageList = await TVItemLanguageDBService.GetTVItemLanguageList();
            Assert.Equal(200, ((ObjectResult)actionTVItemLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLanguageList.Result).Value);
            List<TVItemLanguage> tvItemLanguageList = (List<TVItemLanguage>)((OkObjectResult)actionTVItemLanguageList.Result).Value;

            int count = ((List<TVItemLanguage>)((OkObjectResult)actionTVItemLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // List<TVItemLanguage> with skip and take
            var actionTVItemLanguageListSkipAndTake = await TVItemLanguageDBService.GetTVItemLanguageList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionTVItemLanguageListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLanguageListSkipAndTake.Result).Value);
            List<TVItemLanguage> tvItemLanguageListSkipAndTake = (List<TVItemLanguage>)((OkObjectResult)actionTVItemLanguageListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<TVItemLanguage>)((OkObjectResult)actionTVItemLanguageListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(tvItemLanguageList[0].TVItemLanguageID == tvItemLanguageListSkipAndTake[0].TVItemLanguageID);

            // Get TVItemLanguage With TVItemLanguageID
            var actionTVItemLanguageGet = await TVItemLanguageDBService.GetTVItemLanguageWithTVItemLanguageID(tvItemLanguageList[0].TVItemLanguageID);
            Assert.Equal(200, ((ObjectResult)actionTVItemLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLanguageGet.Result).Value);
            TVItemLanguage tvItemLanguageGet = (TVItemLanguage)((OkObjectResult)actionTVItemLanguageGet.Result).Value;
            Assert.NotNull(tvItemLanguageGet);
            Assert.Equal(tvItemLanguageGet.TVItemLanguageID, tvItemLanguageList[0].TVItemLanguageID);

            // Put TVItemLanguage
            var actionTVItemLanguageUpdated = await TVItemLanguageDBService.Put(tvItemLanguage);
            Assert.Equal(200, ((ObjectResult)actionTVItemLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLanguageUpdated.Result).Value);
            TVItemLanguage tvItemLanguageUpdated = (TVItemLanguage)((OkObjectResult)actionTVItemLanguageUpdated.Result).Value;
            Assert.NotNull(tvItemLanguageUpdated);

            // Delete TVItemLanguage
            var actionTVItemLanguageDeleted = await TVItemLanguageDBService.Delete(tvItemLanguage.TVItemLanguageID);
            Assert.Equal(200, ((ObjectResult)actionTVItemLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVItemLanguageDeleted.Result).Value;
            Assert.True(retBool);

            db.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("70c662c1-a1a8-4b2c-b594-d7834bb5e6db")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITVItemLanguageDBService, TVItemLanguageDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            TVItemLanguageDBService = Provider.GetService<ITVItemLanguageDBService>();
            Assert.NotNull(TVItemLanguageDBService);

            return await Task.FromResult(true);
        }
        private TVItemLanguage GetFilledRandomTVItemLanguage(string OmitPropName)
        {
            TVItemLanguage tvItemLanguage = new TVItemLanguage();

            if (OmitPropName != "TVItemID") tvItemLanguage.TVItemID = 1;
            if (OmitPropName != "Language") tvItemLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "TVText") tvItemLanguage.TVText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") tvItemLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLanguage.LastUpdateContactTVItemID = 2;



            return tvItemLanguage;
        }
        private void CheckTVItemLanguageFields(List<TVItemLanguage> tvItemLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(tvItemLanguageList[0].TVText));
        }

        #endregion Functions private
    }
}
