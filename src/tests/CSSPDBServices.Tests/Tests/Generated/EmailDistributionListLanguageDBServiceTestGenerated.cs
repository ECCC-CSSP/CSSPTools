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
    public partial class EmailDistributionListLanguageDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IEmailDistributionListLanguageDBService EmailDistributionListLanguageDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private EmailDistributionListLanguage emailDistributionListLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListLanguageDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmailDistributionListLanguageDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmailDistributionListLanguageDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmailDistributionListLanguage_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionEmailDistributionListLanguageList = await EmailDistributionListLanguageDBService.GetEmailDistributionListLanguageList();
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListLanguageList.Result).Value);
            List<EmailDistributionListLanguage> emailDistributionListLanguageList = (List<EmailDistributionListLanguage>)((OkObjectResult)actionEmailDistributionListLanguageList.Result).Value;

            count = emailDistributionListLanguageList.Count();

            EmailDistributionListLanguage emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // emailDistributionListLanguage.EmailDistributionListLanguageID   (Int32)
            // -----------------------------------

            emailDistributionListLanguage = null;
            emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
            emailDistributionListLanguage.EmailDistributionListLanguageID = 0;

            var actionEmailDistributionListLanguage = await EmailDistributionListLanguageDBService.Put(emailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListLanguage.Result);

            emailDistributionListLanguage = null;
            emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
            emailDistributionListLanguage.EmailDistributionListLanguageID = 10000000;
            actionEmailDistributionListLanguage = await EmailDistributionListLanguageDBService.Put(emailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID", AllowableTVtypeList = )]
            // emailDistributionListLanguage.EmailDistributionListID   (Int32)
            // -----------------------------------

            emailDistributionListLanguage = null;
            emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
            emailDistributionListLanguage.EmailDistributionListID = 0;
            actionEmailDistributionListLanguage = await EmailDistributionListLanguageDBService.Post(emailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // emailDistributionListLanguage.Language   (LanguageEnum)
            // -----------------------------------

            emailDistributionListLanguage = null;
            emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
            emailDistributionListLanguage.Language = (LanguageEnum)1000000;
            actionEmailDistributionListLanguage = await EmailDistributionListLanguageDBService.Post(emailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // [CSSPMinLength(1)]
            // emailDistributionListLanguage.EmailListName   (String)
            // -----------------------------------

            emailDistributionListLanguage = null;
            emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("EmailListName");
            actionEmailDistributionListLanguage = await EmailDistributionListLanguageDBService.Post(emailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListLanguage.Result);

            emailDistributionListLanguage = null;
            emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
            emailDistributionListLanguage = null;
            emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
            emailDistributionListLanguage.EmailListName = GetRandomString("", 101);
            actionEmailDistributionListLanguage = await EmailDistributionListLanguageDBService.Post(emailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListLanguage.Result);
            //Assert.AreEqual(count, emailDistributionListLanguageDBService.GetEmailDistributionListLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // emailDistributionListLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            emailDistributionListLanguage = null;
            emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
            emailDistributionListLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            actionEmailDistributionListLanguage = await EmailDistributionListLanguageDBService.Post(emailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // emailDistributionListLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            emailDistributionListLanguage = null;
            emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
            emailDistributionListLanguage.LastUpdateDate_UTC = new DateTime();
            actionEmailDistributionListLanguage = await EmailDistributionListLanguageDBService.Post(emailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListLanguage.Result);
            emailDistributionListLanguage = null;
            emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
            emailDistributionListLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionEmailDistributionListLanguage = await EmailDistributionListLanguageDBService.Post(emailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // emailDistributionListLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            emailDistributionListLanguage = null;
            emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
            emailDistributionListLanguage.LastUpdateContactTVItemID = 0;
            actionEmailDistributionListLanguage = await EmailDistributionListLanguageDBService.Post(emailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListLanguage.Result);

            emailDistributionListLanguage = null;
            emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
            emailDistributionListLanguage.LastUpdateContactTVItemID = 1;
            actionEmailDistributionListLanguage = await EmailDistributionListLanguageDBService.Post(emailDistributionListLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post EmailDistributionListLanguage
            var actionEmailDistributionListLanguageAdded = await EmailDistributionListLanguageDBService.Post(emailDistributionListLanguage);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListLanguageAdded.Result).Value);
            EmailDistributionListLanguage emailDistributionListLanguageAdded = (EmailDistributionListLanguage)((OkObjectResult)actionEmailDistributionListLanguageAdded.Result).Value;
            Assert.NotNull(emailDistributionListLanguageAdded);

            // List<EmailDistributionListLanguage>
            var actionEmailDistributionListLanguageList = await EmailDistributionListLanguageDBService.GetEmailDistributionListLanguageList();
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListLanguageList.Result).Value);
            List<EmailDistributionListLanguage> emailDistributionListLanguageList = (List<EmailDistributionListLanguage>)((OkObjectResult)actionEmailDistributionListLanguageList.Result).Value;

            int count = ((List<EmailDistributionListLanguage>)((OkObjectResult)actionEmailDistributionListLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // List<EmailDistributionListLanguage> with skip and take
            var actionEmailDistributionListLanguageListSkipAndTake = await EmailDistributionListLanguageDBService.GetEmailDistributionListLanguageList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListLanguageListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListLanguageListSkipAndTake.Result).Value);
            List<EmailDistributionListLanguage> emailDistributionListLanguageListSkipAndTake = (List<EmailDistributionListLanguage>)((OkObjectResult)actionEmailDistributionListLanguageListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<EmailDistributionListLanguage>)((OkObjectResult)actionEmailDistributionListLanguageListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(emailDistributionListLanguageList[0].EmailDistributionListLanguageID == emailDistributionListLanguageListSkipAndTake[0].EmailDistributionListLanguageID);

            // Get EmailDistributionListLanguage With EmailDistributionListLanguageID
            var actionEmailDistributionListLanguageGet = await EmailDistributionListLanguageDBService.GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListLanguageGet.Result).Value);
            EmailDistributionListLanguage emailDistributionListLanguageGet = (EmailDistributionListLanguage)((OkObjectResult)actionEmailDistributionListLanguageGet.Result).Value;
            Assert.NotNull(emailDistributionListLanguageGet);
            Assert.Equal(emailDistributionListLanguageGet.EmailDistributionListLanguageID, emailDistributionListLanguageList[0].EmailDistributionListLanguageID);

            // Put EmailDistributionListLanguage
            var actionEmailDistributionListLanguageUpdated = await EmailDistributionListLanguageDBService.Put(emailDistributionListLanguage);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListLanguageUpdated.Result).Value);
            EmailDistributionListLanguage emailDistributionListLanguageUpdated = (EmailDistributionListLanguage)((OkObjectResult)actionEmailDistributionListLanguageUpdated.Result).Value;
            Assert.NotNull(emailDistributionListLanguageUpdated);

            // Delete EmailDistributionListLanguage
            var actionEmailDistributionListLanguageDeleted = await EmailDistributionListLanguageDBService.Delete(emailDistributionListLanguage.EmailDistributionListLanguageID);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionEmailDistributionListLanguageDeleted.Result).Value;
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
            Services.AddSingleton<IEmailDistributionListLanguageDBService, EmailDistributionListLanguageDBService>();

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

            EmailDistributionListLanguageDBService = Provider.GetService<IEmailDistributionListLanguageDBService>();
            Assert.NotNull(EmailDistributionListLanguageDBService);

            return await Task.FromResult(true);
        }
        private EmailDistributionListLanguage GetFilledRandomEmailDistributionListLanguage(string OmitPropName)
        {
            EmailDistributionListLanguage emailDistributionListLanguage = new EmailDistributionListLanguage();

            if (OmitPropName != "EmailDistributionListID") emailDistributionListLanguage.EmailDistributionListID = 1;
            if (OmitPropName != "Language") emailDistributionListLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "EmailListName") emailDistributionListLanguage.EmailListName = GetRandomString("", 6);
            if (OmitPropName != "TranslationStatus") emailDistributionListLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionListLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionListLanguage.LastUpdateContactTVItemID = 2;



            return emailDistributionListLanguage;
        }
        private void CheckEmailDistributionListLanguageFields(List<EmailDistributionListLanguage> emailDistributionListLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(emailDistributionListLanguageList[0].EmailListName));
        }

        #endregion Functions private
    }
}
