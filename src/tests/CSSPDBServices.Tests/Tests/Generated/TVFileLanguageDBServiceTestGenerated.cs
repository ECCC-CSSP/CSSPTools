/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
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
    public partial class TVFileLanguageDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITVFileLanguageDBService TVFileLanguageDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private TVFileLanguage tvFileLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVFileLanguageDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVFileLanguageDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            tvFileLanguage = GetFilledRandomTVFileLanguage("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVFileLanguage_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionTVFileLanguageList = await TVFileLanguageDBService.GetTVFileLanguageList();
            Assert.Equal(200, ((ObjectResult)actionTVFileLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVFileLanguageList.Result).Value);
            List<TVFileLanguage> tvFileLanguageList = (List<TVFileLanguage>)((OkObjectResult)actionTVFileLanguageList.Result).Value;

            count = tvFileLanguageList.Count();

            TVFileLanguage tvFileLanguage = GetFilledRandomTVFileLanguage("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tvFileLanguage.TVFileLanguageID   (Int32)
            // -----------------------------------

            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("");
            tvFileLanguage.TVFileLanguageID = 0;

            var actionTVFileLanguage = await TVFileLanguageDBService.Put(tvFileLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVFileLanguage.Result);

            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("");
            tvFileLanguage.TVFileLanguageID = 10000000;
            actionTVFileLanguage = await TVFileLanguageDBService.Put(tvFileLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVFileLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVFile", ExistPlurial = "s", ExistFieldID = "TVFileID", AllowableTVtypeList = )]
            // tvFileLanguage.TVFileID   (Int32)
            // -----------------------------------

            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("");
            tvFileLanguage.TVFileID = 0;
            actionTVFileLanguage = await TVFileLanguageDBService.Post(tvFileLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVFileLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvFileLanguage.Language   (LanguageEnum)
            // -----------------------------------

            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("");
            tvFileLanguage.Language = (LanguageEnum)1000000;
            actionTVFileLanguage = await TVFileLanguageDBService.Post(tvFileLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVFileLanguage.Result);


            // -----------------------------------
            // Is Nullable
            // tvFileLanguage.FileDescription   (String)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvFileLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("");
            tvFileLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            actionTVFileLanguage = await TVFileLanguageDBService.Post(tvFileLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVFileLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvFileLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("");
            tvFileLanguage.LastUpdateDate_UTC = new DateTime();
            actionTVFileLanguage = await TVFileLanguageDBService.Post(tvFileLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVFileLanguage.Result);
            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("");
            tvFileLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTVFileLanguage = await TVFileLanguageDBService.Post(tvFileLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVFileLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvFileLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("");
            tvFileLanguage.LastUpdateContactTVItemID = 0;
            actionTVFileLanguage = await TVFileLanguageDBService.Post(tvFileLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVFileLanguage.Result);

            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("");
            tvFileLanguage.LastUpdateContactTVItemID = 1;
            actionTVFileLanguage = await TVFileLanguageDBService.Post(tvFileLanguage);
            Assert.IsType<BadRequestObjectResult>(actionTVFileLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post TVFileLanguage
            var actionTVFileLanguageAdded = await TVFileLanguageDBService.Post(tvFileLanguage);
            Assert.Equal(200, ((ObjectResult)actionTVFileLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVFileLanguageAdded.Result).Value);
            TVFileLanguage tvFileLanguageAdded = (TVFileLanguage)((OkObjectResult)actionTVFileLanguageAdded.Result).Value;
            Assert.NotNull(tvFileLanguageAdded);

            // List<TVFileLanguage>
            var actionTVFileLanguageList = await TVFileLanguageDBService.GetTVFileLanguageList();
            Assert.Equal(200, ((ObjectResult)actionTVFileLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVFileLanguageList.Result).Value);
            List<TVFileLanguage> tvFileLanguageList = (List<TVFileLanguage>)((OkObjectResult)actionTVFileLanguageList.Result).Value;

            int count = ((List<TVFileLanguage>)((OkObjectResult)actionTVFileLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // List<TVFileLanguage> with skip and take
            var actionTVFileLanguageListSkipAndTake = await TVFileLanguageDBService.GetTVFileLanguageList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionTVFileLanguageListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVFileLanguageListSkipAndTake.Result).Value);
            List<TVFileLanguage> tvFileLanguageListSkipAndTake = (List<TVFileLanguage>)((OkObjectResult)actionTVFileLanguageListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<TVFileLanguage>)((OkObjectResult)actionTVFileLanguageListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(tvFileLanguageList[0].TVFileLanguageID == tvFileLanguageListSkipAndTake[0].TVFileLanguageID);

            // Get TVFileLanguage With TVFileLanguageID
            var actionTVFileLanguageGet = await TVFileLanguageDBService.GetTVFileLanguageWithTVFileLanguageID(tvFileLanguageList[0].TVFileLanguageID);
            Assert.Equal(200, ((ObjectResult)actionTVFileLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVFileLanguageGet.Result).Value);
            TVFileLanguage tvFileLanguageGet = (TVFileLanguage)((OkObjectResult)actionTVFileLanguageGet.Result).Value;
            Assert.NotNull(tvFileLanguageGet);
            Assert.Equal(tvFileLanguageGet.TVFileLanguageID, tvFileLanguageList[0].TVFileLanguageID);

            // Put TVFileLanguage
            var actionTVFileLanguageUpdated = await TVFileLanguageDBService.Put(tvFileLanguage);
            Assert.Equal(200, ((ObjectResult)actionTVFileLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVFileLanguageUpdated.Result).Value);
            TVFileLanguage tvFileLanguageUpdated = (TVFileLanguage)((OkObjectResult)actionTVFileLanguageUpdated.Result).Value;
            Assert.NotNull(tvFileLanguageUpdated);

            // Delete TVFileLanguage
            var actionTVFileLanguageDeleted = await TVFileLanguageDBService.Delete(tvFileLanguage.TVFileLanguageID);
            Assert.Equal(200, ((ObjectResult)actionTVFileLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVFileLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVFileLanguageDeleted.Result).Value;
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
            Services.AddSingleton<ITVFileLanguageDBService, TVFileLanguageDBService>();

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

            TVFileLanguageDBService = Provider.GetService<ITVFileLanguageDBService>();
            Assert.NotNull(TVFileLanguageDBService);

            return await Task.FromResult(true);
        }
        private TVFileLanguage GetFilledRandomTVFileLanguage(string OmitPropName)
        {
            TVFileLanguage tvFileLanguage = new TVFileLanguage();

            if (OmitPropName != "TVFileID") tvFileLanguage.TVFileID = 1;
            if (OmitPropName != "Language") tvFileLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "FileDescription") tvFileLanguage.FileDescription = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") tvFileLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvFileLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvFileLanguage.LastUpdateContactTVItemID = 2;



            return tvFileLanguage;
        }
        private void CheckTVFileLanguageFields(List<TVFileLanguage> tvFileLanguageList)
        {
            if (!string.IsNullOrWhiteSpace(tvFileLanguageList[0].FileDescription))
            {
                Assert.False(string.IsNullOrWhiteSpace(tvFileLanguageList[0].FileDescription));
            }
        }

        #endregion Functions private
    }
}
