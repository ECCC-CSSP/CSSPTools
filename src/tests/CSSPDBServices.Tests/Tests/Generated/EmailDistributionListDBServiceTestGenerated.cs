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

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class EmailDistributionListDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IEmailDistributionListDBService EmailDistributionListDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBContext dbIM { get; set; }
        private EmailDistributionList emailDistributionList { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmailDistributionListDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmailDistributionListDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            emailDistributionList = GetFilledRandomEmailDistributionList("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmailDistributionList_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionEmailDistributionListList = await EmailDistributionListDBService.GetEmailDistributionListList();
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListList.Result).Value);
            List<EmailDistributionList> emailDistributionListList = (List<EmailDistributionList>)((OkObjectResult)actionEmailDistributionListList.Result).Value;

            count = emailDistributionListList.Count();

            EmailDistributionList emailDistributionList = GetFilledRandomEmailDistributionList("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // emailDistributionList.EmailDistributionListID   (Int32)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.EmailDistributionListID = 0;

            var actionEmailDistributionList = await EmailDistributionListDBService.Put(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.EmailDistributionListID = 10000000;
            actionEmailDistributionList = await EmailDistributionListDBService.Put(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // emailDistributionList.DBCommand   (DBCommandEnum)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.DBCommand = (DBCommandEnum)1000000;
            actionEmailDistributionList = await EmailDistributionListDBService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Country)]
            // emailDistributionList.ParentTVItemID   (Int32)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.ParentTVItemID = 0;
            actionEmailDistributionList = await EmailDistributionListDBService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.ParentTVItemID = 1;
            actionEmailDistributionList = await EmailDistributionListDBService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // emailDistributionList.Ordinal   (Int32)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.Ordinal = -1;
            actionEmailDistributionList = await EmailDistributionListDBService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);
            //Assert.AreEqual(count, emailDistributionListService.GetEmailDistributionListList().Count());
            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.Ordinal = 1001;
            actionEmailDistributionList = await EmailDistributionListDBService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);
            //Assert.AreEqual(count, emailDistributionListDBService.GetEmailDistributionListList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // emailDistributionList.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.LastUpdateDate_UTC = new DateTime();
            actionEmailDistributionList = await EmailDistributionListDBService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);
            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionEmailDistributionList = await EmailDistributionListDBService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // emailDistributionList.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.LastUpdateContactTVItemID = 0;
            actionEmailDistributionList = await EmailDistributionListDBService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.LastUpdateContactTVItemID = 1;
            actionEmailDistributionList = await EmailDistributionListDBService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post EmailDistributionList
            var actionEmailDistributionListAdded = await EmailDistributionListDBService.Post(emailDistributionList);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListAdded.Result).Value);
            EmailDistributionList emailDistributionListAdded = (EmailDistributionList)((OkObjectResult)actionEmailDistributionListAdded.Result).Value;
            Assert.NotNull(emailDistributionListAdded);

            // List<EmailDistributionList>
            var actionEmailDistributionListList = await EmailDistributionListDBService.GetEmailDistributionListList();
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListList.Result).Value);
            List<EmailDistributionList> emailDistributionListList = (List<EmailDistributionList>)((OkObjectResult)actionEmailDistributionListList.Result).Value;

            int count = ((List<EmailDistributionList>)((OkObjectResult)actionEmailDistributionListList.Result).Value).Count();
            Assert.True(count > 0);

            // List<EmailDistributionList> with skip and take
            var actionEmailDistributionListListSkipAndTake = await EmailDistributionListDBService.GetEmailDistributionListList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListListSkipAndTake.Result).Value);
            List<EmailDistributionList> emailDistributionListListSkipAndTake = (List<EmailDistributionList>)((OkObjectResult)actionEmailDistributionListListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<EmailDistributionList>)((OkObjectResult)actionEmailDistributionListListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(emailDistributionListList[0].EmailDistributionListID == emailDistributionListListSkipAndTake[0].EmailDistributionListID);

            // Get EmailDistributionList With EmailDistributionListID
            var actionEmailDistributionListGet = await EmailDistributionListDBService.GetEmailDistributionListWithEmailDistributionListID(emailDistributionListList[0].EmailDistributionListID);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListGet.Result).Value);
            EmailDistributionList emailDistributionListGet = (EmailDistributionList)((OkObjectResult)actionEmailDistributionListGet.Result).Value;
            Assert.NotNull(emailDistributionListGet);
            Assert.Equal(emailDistributionListGet.EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);

            // Put EmailDistributionList
            var actionEmailDistributionListUpdated = await EmailDistributionListDBService.Put(emailDistributionList);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListUpdated.Result).Value);
            EmailDistributionList emailDistributionListUpdated = (EmailDistributionList)((OkObjectResult)actionEmailDistributionListUpdated.Result).Value;
            Assert.NotNull(emailDistributionListUpdated);

            // Delete EmailDistributionList
            var actionEmailDistributionListDeleted = await EmailDistributionListDBService.Delete(emailDistributionList.EmailDistributionListID);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionEmailDistributionListDeleted.Result).Value;
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
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IEmailDistributionListDBService, EmailDistributionListDBService>();

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

            EmailDistributionListDBService = Provider.GetService<IEmailDistributionListDBService>();
            Assert.NotNull(EmailDistributionListDBService);

            return await Task.FromResult(true);
        }
        private EmailDistributionList GetFilledRandomEmailDistributionList(string OmitPropName)
        {
            EmailDistributionList emailDistributionList = new EmailDistributionList();

            if (OmitPropName != "DBCommand") emailDistributionList.DBCommand = (DBCommandEnum)GetRandomEnumType(typeof(DBCommandEnum));
            if (OmitPropName != "ParentTVItemID") emailDistributionList.ParentTVItemID = 5;
            if (OmitPropName != "Ordinal") emailDistributionList.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionList.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionList.LastUpdateContactTVItemID = 2;

            return emailDistributionList;
        }
        private void CheckEmailDistributionListFields(List<EmailDistributionList> emailDistributionListList)
        {
        }

        #endregion Functions private
    }
}
