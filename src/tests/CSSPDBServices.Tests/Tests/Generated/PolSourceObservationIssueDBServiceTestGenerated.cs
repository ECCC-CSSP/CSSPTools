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
    public partial class PolSourceObservationIssueDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IPolSourceObservationIssueDBService PolSourceObservationIssueDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBContext dbIM { get; set; }
        private PolSourceObservationIssue polSourceObservationIssue { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PolSourceObservationIssueDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PolSourceObservationIssueDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PolSourceObservationIssue_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionPolSourceObservationIssueList = await PolSourceObservationIssueDBService.GetPolSourceObservationIssueList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueList.Result).Value);
            List<PolSourceObservationIssue> polSourceObservationIssueList = (List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueList.Result).Value;

            count = polSourceObservationIssueList.Count();

            PolSourceObservationIssue polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // polSourceObservationIssue.PolSourceObservationIssueID   (Int32)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.PolSourceObservationIssueID = 0;

            var actionPolSourceObservationIssue = await PolSourceObservationIssueDBService.Put(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.PolSourceObservationIssueID = 10000000;
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBService.Put(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // polSourceObservationIssue.DBCommand   (DBCommandEnum)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.DBCommand = (DBCommandEnum)1000000;
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "PolSourceObservation", ExistPlurial = "s", ExistFieldID = "PolSourceObservationID", AllowableTVtypeList = )]
            // polSourceObservationIssue.PolSourceObservationID   (Int32)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.PolSourceObservationID = 0;
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // polSourceObservationIssue.ObservationInfo   (String)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("ObservationInfo");
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.ObservationInfo = GetRandomString("", 251);
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);
            //Assert.AreEqual(count, polSourceObservationIssueDBService.GetPolSourceObservationIssueList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // polSourceObservationIssue.Ordinal   (Int32)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.Ordinal = -1;
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);
            //Assert.AreEqual(count, polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());
            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.Ordinal = 1001;
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);
            //Assert.AreEqual(count, polSourceObservationIssueDBService.GetPolSourceObservationIssueList().Count());

            // -----------------------------------
            // Is Nullable
            // polSourceObservationIssue.ExtraComment   (String)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // polSourceObservationIssue.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.LastUpdateDate_UTC = new DateTime();
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);
            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // polSourceObservationIssue.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.LastUpdateContactTVItemID = 0;
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.LastUpdateContactTVItemID = 1;
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post PolSourceObservationIssue
            var actionPolSourceObservationIssueAdded = await PolSourceObservationIssueDBService.Post(polSourceObservationIssue);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueAdded.Result).Value);
            PolSourceObservationIssue polSourceObservationIssueAdded = (PolSourceObservationIssue)((OkObjectResult)actionPolSourceObservationIssueAdded.Result).Value;
            Assert.NotNull(polSourceObservationIssueAdded);

            // List<PolSourceObservationIssue>
            var actionPolSourceObservationIssueList = await PolSourceObservationIssueDBService.GetPolSourceObservationIssueList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueList.Result).Value);
            List<PolSourceObservationIssue> polSourceObservationIssueList = (List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueList.Result).Value;

            int count = ((List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueList.Result).Value).Count();
            Assert.True(count > 0);

            // List<PolSourceObservationIssue> with skip and take
            var actionPolSourceObservationIssueListSkipAndTake = await PolSourceObservationIssueDBService.GetPolSourceObservationIssueList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueListSkipAndTake.Result).Value);
            List<PolSourceObservationIssue> polSourceObservationIssueListSkipAndTake = (List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(polSourceObservationIssueList[0].PolSourceObservationIssueID == polSourceObservationIssueListSkipAndTake[0].PolSourceObservationIssueID);

            // Get PolSourceObservationIssue With PolSourceObservationIssueID
            var actionPolSourceObservationIssueGet = await PolSourceObservationIssueDBService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssueList[0].PolSourceObservationIssueID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueGet.Result).Value);
            PolSourceObservationIssue polSourceObservationIssueGet = (PolSourceObservationIssue)((OkObjectResult)actionPolSourceObservationIssueGet.Result).Value;
            Assert.NotNull(polSourceObservationIssueGet);
            Assert.Equal(polSourceObservationIssueGet.PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);

            // Put PolSourceObservationIssue
            var actionPolSourceObservationIssueUpdated = await PolSourceObservationIssueDBService.Put(polSourceObservationIssue);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueUpdated.Result).Value);
            PolSourceObservationIssue polSourceObservationIssueUpdated = (PolSourceObservationIssue)((OkObjectResult)actionPolSourceObservationIssueUpdated.Result).Value;
            Assert.NotNull(polSourceObservationIssueUpdated);

            // Delete PolSourceObservationIssue
            var actionPolSourceObservationIssueDeleted = await PolSourceObservationIssueDBService.Delete(polSourceObservationIssue.PolSourceObservationIssueID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionPolSourceObservationIssueDeleted.Result).Value;
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
            Services.AddSingleton<IPolSourceObservationIssueDBService, PolSourceObservationIssueDBService>();

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

            PolSourceObservationIssueDBService = Provider.GetService<IPolSourceObservationIssueDBService>();
            Assert.NotNull(PolSourceObservationIssueDBService);

            return await Task.FromResult(true);
        }
        private PolSourceObservationIssue GetFilledRandomPolSourceObservationIssue(string OmitPropName)
        {
            PolSourceObservationIssue polSourceObservationIssue = new PolSourceObservationIssue();

            if (OmitPropName != "DBCommand") polSourceObservationIssue.DBCommand = (DBCommandEnum)GetRandomEnumType(typeof(DBCommandEnum));
            if (OmitPropName != "PolSourceObservationID") polSourceObservationIssue.PolSourceObservationID = 1;
            if (OmitPropName != "ObservationInfo") polSourceObservationIssue.ObservationInfo = GetRandomString("", 5);
            if (OmitPropName != "Ordinal") polSourceObservationIssue.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "ExtraComment") polSourceObservationIssue.ExtraComment = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservationIssue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservationIssue.LastUpdateContactTVItemID = 2;

            return polSourceObservationIssue;
        }
        private void CheckPolSourceObservationIssueFields(List<PolSourceObservationIssue> polSourceObservationIssueList)
        {
            Assert.False(string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].ObservationInfo));
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].ExtraComment))
            {
                Assert.False(string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].ExtraComment));
            }
        }

        #endregion Functions private
    }
}
