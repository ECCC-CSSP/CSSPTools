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
using LocalServices;
using System.Threading;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class EmailDistributionListContactLanguageDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IEmailDistributionListContactLanguageDBLocalService EmailDistributionListContactLanguageDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private EmailDistributionListContactLanguage emailDistributionListContactLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactLanguageDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocal]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmailDistributionListContactLanguageDBLocal_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocal]

        #region Tests Generated [DBLocal] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmailDistributionListContactLanguageDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated [DBLocal] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmailDistributionListContactLanguage_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionEmailDistributionListContactLanguageList = await EmailDistributionListContactLanguageDBLocalService.GetEmailDistributionListContactLanguageList();
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactLanguageList.Result).Value);
            List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList = (List<EmailDistributionListContactLanguage>)((OkObjectResult)actionEmailDistributionListContactLanguageList.Result).Value;

            count = emailDistributionListContactLanguageList.Count();

            EmailDistributionListContactLanguage emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // emailDistributionListContactLanguage.EmailDistributionListContactLanguageID   (Int32)
            // -----------------------------------

            emailDistributionListContactLanguage = null;
            emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
            emailDistributionListContactLanguage.EmailDistributionListContactLanguageID = 0;

            var actionEmailDistributionListContactLanguage = await EmailDistributionListContactLanguageDBLocalService.Put(emailDistributionListContactLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListContactLanguage.Result);

            emailDistributionListContactLanguage = null;
            emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
            emailDistributionListContactLanguage.EmailDistributionListContactLanguageID = 10000000;
            actionEmailDistributionListContactLanguage = await EmailDistributionListContactLanguageDBLocalService.Put(emailDistributionListContactLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListContactLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "EmailDistributionListContact", ExistPlurial = "s", ExistFieldID = "EmailDistributionListContactID", AllowableTVtypeList = )]
            // emailDistributionListContactLanguage.EmailDistributionListContactID   (Int32)
            // -----------------------------------

            emailDistributionListContactLanguage = null;
            emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
            emailDistributionListContactLanguage.EmailDistributionListContactID = 0;
            actionEmailDistributionListContactLanguage = await EmailDistributionListContactLanguageDBLocalService.Post(emailDistributionListContactLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListContactLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // emailDistributionListContactLanguage.Language   (LanguageEnum)
            // -----------------------------------

            emailDistributionListContactLanguage = null;
            emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
            emailDistributionListContactLanguage.Language = (LanguageEnum)1000000;
            actionEmailDistributionListContactLanguage = await EmailDistributionListContactLanguageDBLocalService.Post(emailDistributionListContactLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListContactLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // [CSSPMinLength(1)]
            // emailDistributionListContactLanguage.Agency   (String)
            // -----------------------------------

            emailDistributionListContactLanguage = null;
            emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("Agency");
            actionEmailDistributionListContactLanguage = await EmailDistributionListContactLanguageDBLocalService.Post(emailDistributionListContactLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListContactLanguage.Result);

            emailDistributionListContactLanguage = null;
            emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
            emailDistributionListContactLanguage = null;
            emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
            emailDistributionListContactLanguage.Agency = GetRandomString("", 101);
            actionEmailDistributionListContactLanguage = await EmailDistributionListContactLanguageDBLocalService.Post(emailDistributionListContactLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListContactLanguage.Result);
            //Assert.AreEqual(count, emailDistributionListContactLanguageDBLocalService.GetEmailDistributionListContactLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // emailDistributionListContactLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            emailDistributionListContactLanguage = null;
            emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
            emailDistributionListContactLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            actionEmailDistributionListContactLanguage = await EmailDistributionListContactLanguageDBLocalService.Post(emailDistributionListContactLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListContactLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // emailDistributionListContactLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            emailDistributionListContactLanguage = null;
            emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
            emailDistributionListContactLanguage.LastUpdateDate_UTC = new DateTime();
            actionEmailDistributionListContactLanguage = await EmailDistributionListContactLanguageDBLocalService.Post(emailDistributionListContactLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListContactLanguage.Result);
            emailDistributionListContactLanguage = null;
            emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
            emailDistributionListContactLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionEmailDistributionListContactLanguage = await EmailDistributionListContactLanguageDBLocalService.Post(emailDistributionListContactLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListContactLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // emailDistributionListContactLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            emailDistributionListContactLanguage = null;
            emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
            emailDistributionListContactLanguage.LastUpdateContactTVItemID = 0;
            actionEmailDistributionListContactLanguage = await EmailDistributionListContactLanguageDBLocalService.Post(emailDistributionListContactLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListContactLanguage.Result);

            emailDistributionListContactLanguage = null;
            emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
            emailDistributionListContactLanguage.LastUpdateContactTVItemID = 1;
            actionEmailDistributionListContactLanguage = await EmailDistributionListContactLanguageDBLocalService.Post(emailDistributionListContactLanguage);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionListContactLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post EmailDistributionListContactLanguage
            var actionEmailDistributionListContactLanguageAdded = await EmailDistributionListContactLanguageDBLocalService.Post(emailDistributionListContactLanguage);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactLanguageAdded.Result).Value);
            EmailDistributionListContactLanguage emailDistributionListContactLanguageAdded = (EmailDistributionListContactLanguage)((OkObjectResult)actionEmailDistributionListContactLanguageAdded.Result).Value;
            Assert.NotNull(emailDistributionListContactLanguageAdded);

            // List<EmailDistributionListContactLanguage>
            var actionEmailDistributionListContactLanguageList = await EmailDistributionListContactLanguageDBLocalService.GetEmailDistributionListContactLanguageList();
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactLanguageList.Result).Value);
            List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList = (List<EmailDistributionListContactLanguage>)((OkObjectResult)actionEmailDistributionListContactLanguageList.Result).Value;

            int count = ((List<EmailDistributionListContactLanguage>)((OkObjectResult)actionEmailDistributionListContactLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // Get EmailDistributionListContactLanguage With EmailDistributionListContactLanguageID
            var actionEmailDistributionListContactLanguageGet = await EmailDistributionListContactLanguageDBLocalService.GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(emailDistributionListContactLanguageList[0].EmailDistributionListContactLanguageID);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactLanguageGet.Result).Value);
            EmailDistributionListContactLanguage emailDistributionListContactLanguageGet = (EmailDistributionListContactLanguage)((OkObjectResult)actionEmailDistributionListContactLanguageGet.Result).Value;
            Assert.NotNull(emailDistributionListContactLanguageGet);
            Assert.Equal(emailDistributionListContactLanguageGet.EmailDistributionListContactLanguageID, emailDistributionListContactLanguageList[0].EmailDistributionListContactLanguageID);

            // Put EmailDistributionListContactLanguage
            var actionEmailDistributionListContactLanguageUpdated = await EmailDistributionListContactLanguageDBLocalService.Put(emailDistributionListContactLanguage);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactLanguageUpdated.Result).Value);
            EmailDistributionListContactLanguage emailDistributionListContactLanguageUpdated = (EmailDistributionListContactLanguage)((OkObjectResult)actionEmailDistributionListContactLanguageUpdated.Result).Value;
            Assert.NotNull(emailDistributionListContactLanguageUpdated);

            // Delete EmailDistributionListContactLanguage
            var actionEmailDistributionListContactLanguageDeleted = await EmailDistributionListContactLanguageDBLocalService.Delete(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionEmailDistributionListContactLanguageDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLoginFileName = Config.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IEmailDistributionListContactLanguageDBLocalService, EmailDistributionListContactLanguageDBLocalService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbLocalIM);

            EmailDistributionListContactLanguageDBLocalService = Provider.GetService<IEmailDistributionListContactLanguageDBLocalService>();
            Assert.NotNull(EmailDistributionListContactLanguageDBLocalService);

            return await Task.FromResult(true);
        }
        private EmailDistributionListContactLanguage GetFilledRandomEmailDistributionListContactLanguage(string OmitPropName)
        {
            EmailDistributionListContactLanguage emailDistributionListContactLanguage = new EmailDistributionListContactLanguage();

            if (OmitPropName != "EmailDistributionListContactID") emailDistributionListContactLanguage.EmailDistributionListContactID = 1;
            if (OmitPropName != "Language") emailDistributionListContactLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "Agency") emailDistributionListContactLanguage.Agency = GetRandomString("", 6);
            if (OmitPropName != "TranslationStatus") emailDistributionListContactLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionListContactLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionListContactLanguage.LastUpdateContactTVItemID = 2;

            try
            {
                dbLocalIM.EmailDistributionListContacts.Add(new EmailDistributionListContact() { EmailDistributionListContactID = 1, EmailDistributionListID = 1, IsCC = true, Name = "Bernice Losier", Email = "bernice.losier@inspection.gc.ca", CMPRainfallSeasonal = true, CMPWastewater = true, EmergencyWeather = true, EmergencyWastewater = true, ReopeningAllTypes = true, LastUpdateDate_UTC = new DateTime(2017, 6, 16, 12, 58, 34), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }
            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }


            return emailDistributionListContactLanguage;
        }
        private void CheckEmailDistributionListContactLanguageFields(List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageList[0].Agency));
        }

        #endregion Functions private
    }
}
