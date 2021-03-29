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
    public partial class SamplingPlanEmailDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ISamplingPlanEmailDBService SamplingPlanEmailDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBContext dbIM { get; set; }
        private SamplingPlanEmail samplingPlanEmail { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SamplingPlanEmailDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SamplingPlanEmailDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SamplingPlanEmail_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionSamplingPlanEmailList = await SamplingPlanEmailDBService.GetSamplingPlanEmailList();
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailList.Result).Value);
            List<SamplingPlanEmail> samplingPlanEmailList = (List<SamplingPlanEmail>)((OkObjectResult)actionSamplingPlanEmailList.Result).Value;

            count = samplingPlanEmailList.Count();

            SamplingPlanEmail samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // samplingPlanEmail.SamplingPlanEmailID   (Int32)
            // -----------------------------------

            samplingPlanEmail = null;
            samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
            samplingPlanEmail.SamplingPlanEmailID = 0;

            var actionSamplingPlanEmail = await SamplingPlanEmailDBService.Put(samplingPlanEmail);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanEmail.Result);

            samplingPlanEmail = null;
            samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
            samplingPlanEmail.SamplingPlanEmailID = 10000000;
            actionSamplingPlanEmail = await SamplingPlanEmailDBService.Put(samplingPlanEmail);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanEmail.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // samplingPlanEmail.DBCommand   (DBCommandEnum)
            // -----------------------------------

            samplingPlanEmail = null;
            samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
            samplingPlanEmail.DBCommand = (DBCommandEnum)1000000;
            actionSamplingPlanEmail = await SamplingPlanEmailDBService.Post(samplingPlanEmail);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanEmail.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID", AllowableTVtypeList = )]
            // samplingPlanEmail.SamplingPlanID   (Int32)
            // -----------------------------------

            samplingPlanEmail = null;
            samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
            samplingPlanEmail.SamplingPlanID = 0;
            actionSamplingPlanEmail = await SamplingPlanEmailDBService.Post(samplingPlanEmail);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanEmail.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [DataType(DataType.EmailAddress)]
            // [CSSPMaxLength(150)]
            // samplingPlanEmail.Email   (String)
            // -----------------------------------

            samplingPlanEmail = null;
            samplingPlanEmail = GetFilledRandomSamplingPlanEmail("Email");
            actionSamplingPlanEmail = await SamplingPlanEmailDBService.Post(samplingPlanEmail);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanEmail.Result);

            samplingPlanEmail = null;
            samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
            samplingPlanEmail.Email = GetRandomString("", 151);
            actionSamplingPlanEmail = await SamplingPlanEmailDBService.Post(samplingPlanEmail);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanEmail.Result);
            //Assert.AreEqual(count, samplingPlanEmailDBService.GetSamplingPlanEmailList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // samplingPlanEmail.IsContractor   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // samplingPlanEmail.LabSheetHasValueOver500   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // samplingPlanEmail.LabSheetReceived   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // samplingPlanEmail.LabSheetAccepted   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // samplingPlanEmail.LabSheetRejected   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // samplingPlanEmail.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            samplingPlanEmail = null;
            samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
            samplingPlanEmail.LastUpdateDate_UTC = new DateTime();
            actionSamplingPlanEmail = await SamplingPlanEmailDBService.Post(samplingPlanEmail);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanEmail.Result);
            samplingPlanEmail = null;
            samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
            samplingPlanEmail.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionSamplingPlanEmail = await SamplingPlanEmailDBService.Post(samplingPlanEmail);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanEmail.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // samplingPlanEmail.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            samplingPlanEmail = null;
            samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
            samplingPlanEmail.LastUpdateContactTVItemID = 0;
            actionSamplingPlanEmail = await SamplingPlanEmailDBService.Post(samplingPlanEmail);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanEmail.Result);

            samplingPlanEmail = null;
            samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
            samplingPlanEmail.LastUpdateContactTVItemID = 1;
            actionSamplingPlanEmail = await SamplingPlanEmailDBService.Post(samplingPlanEmail);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanEmail.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post SamplingPlanEmail
            var actionSamplingPlanEmailAdded = await SamplingPlanEmailDBService.Post(samplingPlanEmail);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailAdded.Result).Value);
            SamplingPlanEmail samplingPlanEmailAdded = (SamplingPlanEmail)((OkObjectResult)actionSamplingPlanEmailAdded.Result).Value;
            Assert.NotNull(samplingPlanEmailAdded);

            // List<SamplingPlanEmail>
            var actionSamplingPlanEmailList = await SamplingPlanEmailDBService.GetSamplingPlanEmailList();
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailList.Result).Value);
            List<SamplingPlanEmail> samplingPlanEmailList = (List<SamplingPlanEmail>)((OkObjectResult)actionSamplingPlanEmailList.Result).Value;

            int count = ((List<SamplingPlanEmail>)((OkObjectResult)actionSamplingPlanEmailList.Result).Value).Count();
            Assert.True(count > 0);

            // List<SamplingPlanEmail> with skip and take
            var actionSamplingPlanEmailListSkipAndTake = await SamplingPlanEmailDBService.GetSamplingPlanEmailList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailListSkipAndTake.Result).Value);
            List<SamplingPlanEmail> samplingPlanEmailListSkipAndTake = (List<SamplingPlanEmail>)((OkObjectResult)actionSamplingPlanEmailListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<SamplingPlanEmail>)((OkObjectResult)actionSamplingPlanEmailListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(samplingPlanEmailList[0].SamplingPlanEmailID == samplingPlanEmailListSkipAndTake[0].SamplingPlanEmailID);

            // Get SamplingPlanEmail With SamplingPlanEmailID
            var actionSamplingPlanEmailGet = await SamplingPlanEmailDBService.GetSamplingPlanEmailWithSamplingPlanEmailID(samplingPlanEmailList[0].SamplingPlanEmailID);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailGet.Result).Value);
            SamplingPlanEmail samplingPlanEmailGet = (SamplingPlanEmail)((OkObjectResult)actionSamplingPlanEmailGet.Result).Value;
            Assert.NotNull(samplingPlanEmailGet);
            Assert.Equal(samplingPlanEmailGet.SamplingPlanEmailID, samplingPlanEmailList[0].SamplingPlanEmailID);

            // Put SamplingPlanEmail
            var actionSamplingPlanEmailUpdated = await SamplingPlanEmailDBService.Put(samplingPlanEmail);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailUpdated.Result).Value);
            SamplingPlanEmail samplingPlanEmailUpdated = (SamplingPlanEmail)((OkObjectResult)actionSamplingPlanEmailUpdated.Result).Value;
            Assert.NotNull(samplingPlanEmailUpdated);

            // Delete SamplingPlanEmail
            var actionSamplingPlanEmailDeleted = await SamplingPlanEmailDBService.Delete(samplingPlanEmail.SamplingPlanEmailID);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionSamplingPlanEmailDeleted.Result).Value;
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
            Services.AddSingleton<ISamplingPlanEmailDBService, SamplingPlanEmailDBService>();

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

            SamplingPlanEmailDBService = Provider.GetService<ISamplingPlanEmailDBService>();
            Assert.NotNull(SamplingPlanEmailDBService);

            return await Task.FromResult(true);
        }
        private SamplingPlanEmail GetFilledRandomSamplingPlanEmail(string OmitPropName)
        {
            SamplingPlanEmail samplingPlanEmail = new SamplingPlanEmail();

            if (OmitPropName != "DBCommand") samplingPlanEmail.DBCommand = (DBCommandEnum)GetRandomEnumType(typeof(DBCommandEnum));
            if (OmitPropName != "SamplingPlanID") samplingPlanEmail.SamplingPlanID = 1;
            if (OmitPropName != "Email") samplingPlanEmail.Email = GetRandomEmail();
            if (OmitPropName != "IsContractor") samplingPlanEmail.IsContractor = true;
            if (OmitPropName != "LabSheetHasValueOver500") samplingPlanEmail.LabSheetHasValueOver500 = true;
            if (OmitPropName != "LabSheetReceived") samplingPlanEmail.LabSheetReceived = true;
            if (OmitPropName != "LabSheetAccepted") samplingPlanEmail.LabSheetAccepted = true;
            if (OmitPropName != "LabSheetRejected") samplingPlanEmail.LabSheetRejected = true;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanEmail.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanEmail.LastUpdateContactTVItemID = 2;

            return samplingPlanEmail;
        }
        private void CheckSamplingPlanEmailFields(List<SamplingPlanEmail> samplingPlanEmailList)
        {
            Assert.False(string.IsNullOrWhiteSpace(samplingPlanEmailList[0].Email));
        }

        #endregion Functions private
    }
}
