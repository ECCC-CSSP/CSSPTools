/* Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBServices_Tests.exe
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
using CSSPDBPreferenceModels;
using CSSPScrambleServices;
using CSSPHelperServices;

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class EmailDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IEmailDBService EmailDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBContext dbIM { get; set; }
        private Email email { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmailDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmailDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            email = GetFilledRandomEmail("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Email_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionEmailList = await EmailDBService.GetEmailList();
            Assert.Equal(200, ((ObjectResult)actionEmailList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailList.Result).Value);
            List<Email> emailList = (List<Email>)((OkObjectResult)actionEmailList.Result).Value;

            count = emailList.Count();

            Email email = GetFilledRandomEmail("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // email.EmailID   (Int32)
            // -----------------------------------

            email = null;
            email = GetFilledRandomEmail("");
            email.EmailID = 0;

            var actionEmail = await EmailDBService.Put(email);
            Assert.IsType<BadRequestObjectResult>(actionEmail.Result);

            email = null;
            email = GetFilledRandomEmail("");
            email.EmailID = 10000000;
            actionEmail = await EmailDBService.Put(email);
            Assert.IsType<BadRequestObjectResult>(actionEmail.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // email.DBCommand   (DBCommandEnum)
            // -----------------------------------

            email = null;
            email = GetFilledRandomEmail("");
            email.DBCommand = (DBCommandEnum)1000000;
            actionEmail = await EmailDBService.Post(email);
            Assert.IsType<BadRequestObjectResult>(actionEmail.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Email)]
            // email.EmailTVItemID   (Int32)
            // -----------------------------------

            email = null;
            email = GetFilledRandomEmail("");
            email.EmailTVItemID = 0;
            actionEmail = await EmailDBService.Post(email);
            Assert.IsType<BadRequestObjectResult>(actionEmail.Result);

            email = null;
            email = GetFilledRandomEmail("");
            email.EmailTVItemID = 1;
            actionEmail = await EmailDBService.Post(email);
            Assert.IsType<BadRequestObjectResult>(actionEmail.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [DataType(DataType.EmailAddress)]
            // [CSSPMaxLength(255)]
            // email.EmailAddress   (String)
            // -----------------------------------

            email = null;
            email = GetFilledRandomEmail("EmailAddress");
            actionEmail = await EmailDBService.Post(email);
            Assert.IsType<BadRequestObjectResult>(actionEmail.Result);

            email = null;
            email = GetFilledRandomEmail("");
            email.EmailAddress = GetRandomString("", 256);
            actionEmail = await EmailDBService.Post(email);
            Assert.IsType<BadRequestObjectResult>(actionEmail.Result);
            //Assert.AreEqual(count, emailDBService.GetEmailList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // email.EmailType   (EmailTypeEnum)
            // -----------------------------------

            email = null;
            email = GetFilledRandomEmail("");
            email.EmailType = (EmailTypeEnum)1000000;
            actionEmail = await EmailDBService.Post(email);
            Assert.IsType<BadRequestObjectResult>(actionEmail.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // email.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            email = null;
            email = GetFilledRandomEmail("");
            email.LastUpdateDate_UTC = new DateTime();
            actionEmail = await EmailDBService.Post(email);
            Assert.IsType<BadRequestObjectResult>(actionEmail.Result);
            email = null;
            email = GetFilledRandomEmail("");
            email.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionEmail = await EmailDBService.Post(email);
            Assert.IsType<BadRequestObjectResult>(actionEmail.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // email.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            email = null;
            email = GetFilledRandomEmail("");
            email.LastUpdateContactTVItemID = 0;
            actionEmail = await EmailDBService.Post(email);
            Assert.IsType<BadRequestObjectResult>(actionEmail.Result);

            email = null;
            email = GetFilledRandomEmail("");
            email.LastUpdateContactTVItemID = 1;
            actionEmail = await EmailDBService.Post(email);
            Assert.IsType<BadRequestObjectResult>(actionEmail.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post Email
            var actionEmailAdded = await EmailDBService.Post(email);
            Assert.Equal(200, ((ObjectResult)actionEmailAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailAdded.Result).Value);
            Email emailAdded = (Email)((OkObjectResult)actionEmailAdded.Result).Value;
            Assert.NotNull(emailAdded);

            // List<Email>
            var actionEmailList = await EmailDBService.GetEmailList();
            Assert.Equal(200, ((ObjectResult)actionEmailList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailList.Result).Value);
            List<Email> emailList = (List<Email>)((OkObjectResult)actionEmailList.Result).Value;

            int count = ((List<Email>)((OkObjectResult)actionEmailList.Result).Value).Count();
            Assert.True(count > 0);

            // List<Email> with skip and take
            var actionEmailListSkipAndTake = await EmailDBService.GetEmailList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionEmailListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailListSkipAndTake.Result).Value);
            List<Email> emailListSkipAndTake = (List<Email>)((OkObjectResult)actionEmailListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<Email>)((OkObjectResult)actionEmailListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(emailList[0].EmailID == emailListSkipAndTake[0].EmailID);

            // Get Email With EmailID
            var actionEmailGet = await EmailDBService.GetEmailWithEmailID(emailList[0].EmailID);
            Assert.Equal(200, ((ObjectResult)actionEmailGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailGet.Result).Value);
            Email emailGet = (Email)((OkObjectResult)actionEmailGet.Result).Value;
            Assert.NotNull(emailGet);
            Assert.Equal(emailGet.EmailID, emailList[0].EmailID);

            // Put Email
            var actionEmailUpdated = await EmailDBService.Put(email);
            Assert.Equal(200, ((ObjectResult)actionEmailUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailUpdated.Result).Value);
            Email emailUpdated = (Email)((OkObjectResult)actionEmailUpdated.Result).Value;
            Assert.NotNull(emailUpdated);

            // Delete Email
            var actionEmailDeleted = await EmailDBService.Delete(email.EmailID);
            Assert.Equal(200, ((ObjectResult)actionEmailDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionEmailDeleted.Result).Value;
            Assert.True(retBool);

            db.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("a79b4a81-ba75-4dfc-8d95-46259f73f055")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            string CSSPDBConnString = Configuration.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IScrambleService, ScrambleService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IEmailDBService, EmailDBService>();

            /* ---------------------------------------------------------------------------------
             * using TestDB
             * ---------------------------------------------------------------------------------      
             */
            string TestDB = Configuration.GetValue<string>("TestDB");
            Assert.NotNull(TestDB);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDB);
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBPreference
             * ---------------------------------------------------------------------------------
             */
            string CSSPDBPreference = Configuration.GetValue<string>("CSSPDBPreference"); 
            Assert.NotNull(CSSPDBPreference);

            FileInfo fiCSSPDBPreference = new FileInfo(CSSPDBPreference);

            Services.AddDbContext<CSSPDBPreferenceContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBPreference.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(LoginEmail));

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            dbIM = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(dbIM);

            EmailDBService = Provider.GetService<IEmailDBService>();
            Assert.NotNull(EmailDBService);

            return await Task.FromResult(true);
        }
        private Email GetFilledRandomEmail(string OmitPropName)
        {
            Email email = new Email();

            if (OmitPropName != "DBCommand") email.DBCommand = (DBCommandEnum)GetRandomEnumType(typeof(DBCommandEnum));
            if (OmitPropName != "EmailTVItemID") email.EmailTVItemID = 54;
            if (OmitPropName != "EmailAddress") email.EmailAddress = GetRandomEmail();
            if (OmitPropName != "EmailType") email.EmailType = (EmailTypeEnum)GetRandomEnumType(typeof(EmailTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") email.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") email.LastUpdateContactTVItemID = 2;

            return email;
        }
        private void CheckEmailFields(List<Email> emailList)
        {
            Assert.False(string.IsNullOrWhiteSpace(emailList[0].EmailAddress));
        }

        #endregion Functions private
    }
}
