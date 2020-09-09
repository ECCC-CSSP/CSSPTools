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
    public partial class MWQMRunLanguageDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMWQMRunLanguageDBService MWQMRunLanguageDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private MWQMRunLanguage mwqmRunLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMRunLanguageDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMRunLanguageDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMRunLanguage_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionMWQMRunLanguageList = await MWQMRunLanguageDBService.GetMWQMRunLanguageList();
            Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageList.Result).Value);
            List<MWQMRunLanguage> mwqmRunLanguageList = (List<MWQMRunLanguage>)((OkObjectResult)actionMWQMRunLanguageList.Result).Value;

            count = mwqmRunLanguageList.Count();

            MWQMRunLanguage mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmRunLanguage.MWQMRunLanguageID   (Int32)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.MWQMRunLanguageID = 0;

            var actionMWQMRunLanguage = await MWQMRunLanguageDBService.Put(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.MWQMRunLanguageID = 10000000;
            actionMWQMRunLanguage = await MWQMRunLanguageDBService.Put(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "MWQMRun", ExistPlurial = "s", ExistFieldID = "MWQMRunID", AllowableTVtypeList = )]
            // mwqmRunLanguage.MWQMRunID   (Int32)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.MWQMRunID = 0;
            actionMWQMRunLanguage = await MWQMRunLanguageDBService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmRunLanguage.Language   (LanguageEnum)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.Language = (LanguageEnum)1000000;
            actionMWQMRunLanguage = await MWQMRunLanguageDBService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // mwqmRunLanguage.RunComment   (String)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunComment");
            actionMWQMRunLanguage = await MWQMRunLanguageDBService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmRunLanguage.TranslationStatusRunComment   (TranslationStatusEnum)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.TranslationStatusRunComment = (TranslationStatusEnum)1000000;
            actionMWQMRunLanguage = await MWQMRunLanguageDBService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // mwqmRunLanguage.RunWeatherComment   (String)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunWeatherComment");
            actionMWQMRunLanguage = await MWQMRunLanguageDBService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmRunLanguage.TranslationStatusRunWeatherComment   (TranslationStatusEnum)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.TranslationStatusRunWeatherComment = (TranslationStatusEnum)1000000;
            actionMWQMRunLanguage = await MWQMRunLanguageDBService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmRunLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.LastUpdateDate_UTC = new DateTime();
            actionMWQMRunLanguage = await MWQMRunLanguageDBService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);
            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMWQMRunLanguage = await MWQMRunLanguageDBService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mwqmRunLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.LastUpdateContactTVItemID = 0;
            actionMWQMRunLanguage = await MWQMRunLanguageDBService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.LastUpdateContactTVItemID = 1;
            actionMWQMRunLanguage = await MWQMRunLanguageDBService.Post(mwqmRunLanguage);
            Assert.IsType<BadRequestObjectResult>(actionMWQMRunLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post MWQMRunLanguage
            var actionMWQMRunLanguageAdded = await MWQMRunLanguageDBService.Post(mwqmRunLanguage);
            Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageAdded.Result).Value);
            MWQMRunLanguage mwqmRunLanguageAdded = (MWQMRunLanguage)((OkObjectResult)actionMWQMRunLanguageAdded.Result).Value;
            Assert.NotNull(mwqmRunLanguageAdded);

            // List<MWQMRunLanguage>
            var actionMWQMRunLanguageList = await MWQMRunLanguageDBService.GetMWQMRunLanguageList();
            Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageList.Result).Value);
            List<MWQMRunLanguage> mwqmRunLanguageList = (List<MWQMRunLanguage>)((OkObjectResult)actionMWQMRunLanguageList.Result).Value;

            int count = ((List<MWQMRunLanguage>)((OkObjectResult)actionMWQMRunLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // List<MWQMRunLanguage> with skip and take
            var actionMWQMRunLanguageListSkipAndTake = await MWQMRunLanguageDBService.GetMWQMRunLanguageList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageListSkipAndTake.Result).Value);
            List<MWQMRunLanguage> mwqmRunLanguageListSkipAndTake = (List<MWQMRunLanguage>)((OkObjectResult)actionMWQMRunLanguageListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<MWQMRunLanguage>)((OkObjectResult)actionMWQMRunLanguageListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(mwqmRunLanguageList[0].MWQMRunLanguageID == mwqmRunLanguageListSkipAndTake[0].MWQMRunLanguageID);

            // Get MWQMRunLanguage With MWQMRunLanguageID
            var actionMWQMRunLanguageGet = await MWQMRunLanguageDBService.GetMWQMRunLanguageWithMWQMRunLanguageID(mwqmRunLanguageList[0].MWQMRunLanguageID);
            Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageGet.Result).Value);
            MWQMRunLanguage mwqmRunLanguageGet = (MWQMRunLanguage)((OkObjectResult)actionMWQMRunLanguageGet.Result).Value;
            Assert.NotNull(mwqmRunLanguageGet);
            Assert.Equal(mwqmRunLanguageGet.MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);

            // Put MWQMRunLanguage
            var actionMWQMRunLanguageUpdated = await MWQMRunLanguageDBService.Put(mwqmRunLanguage);
            Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageUpdated.Result).Value);
            MWQMRunLanguage mwqmRunLanguageUpdated = (MWQMRunLanguage)((OkObjectResult)actionMWQMRunLanguageUpdated.Result).Value;
            Assert.NotNull(mwqmRunLanguageUpdated);

            // Delete MWQMRunLanguage
            var actionMWQMRunLanguageDeleted = await MWQMRunLanguageDBService.Delete(mwqmRunLanguage.MWQMRunLanguageID);
            Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMRunLanguageDeleted.Result).Value;
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
            Services.AddSingleton<IMWQMRunLanguageDBService, MWQMRunLanguageDBService>();

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

            MWQMRunLanguageDBService = Provider.GetService<IMWQMRunLanguageDBService>();
            Assert.NotNull(MWQMRunLanguageDBService);

            return await Task.FromResult(true);
        }
        private MWQMRunLanguage GetFilledRandomMWQMRunLanguage(string OmitPropName)
        {
            MWQMRunLanguage mwqmRunLanguage = new MWQMRunLanguage();

            if (OmitPropName != "MWQMRunID") mwqmRunLanguage.MWQMRunID = 1;
            if (OmitPropName != "Language") mwqmRunLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "RunComment") mwqmRunLanguage.RunComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusRunComment") mwqmRunLanguage.TranslationStatusRunComment = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "RunWeatherComment") mwqmRunLanguage.RunWeatherComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusRunWeatherComment") mwqmRunLanguage.TranslationStatusRunWeatherComment = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmRunLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmRunLanguage.LastUpdateContactTVItemID = 2;



            return mwqmRunLanguage;
        }
        private void CheckMWQMRunLanguageFields(List<MWQMRunLanguage> mwqmRunLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].RunComment));
            Assert.False(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].RunWeatherComment));
        }

        #endregion Functions private
    }
}
