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
    public partial class LocalPolSourceObservationDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalPolSourceObservationDBService LocalPolSourceObservationDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalPolSourceObservation localPolSourceObservation { get; set; }
        #endregion Properties

        #region Constructors
        public LocalPolSourceObservationDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalPolSourceObservationDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalPolSourceObservationDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalPolSourceObservation_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalPolSourceObservationList = await LocalPolSourceObservationDBService.GetLocalPolSourceObservationList();
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceObservationList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceObservationList.Result).Value);
            List<LocalPolSourceObservation> localPolSourceObservationList = (List<LocalPolSourceObservation>)((OkObjectResult)actionLocalPolSourceObservationList.Result).Value;

            count = localPolSourceObservationList.Count();

            LocalPolSourceObservation localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localPolSourceObservation.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localPolSourceObservation = null;
            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");
            localPolSourceObservation.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalPolSourceObservation = await LocalPolSourceObservationDBService.Post(localPolSourceObservation);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceObservation.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localPolSourceObservation.PolSourceObservationID   (Int32)
            // -----------------------------------

            localPolSourceObservation = null;
            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");
            localPolSourceObservation.PolSourceObservationID = 0;

            actionLocalPolSourceObservation = await LocalPolSourceObservationDBService.Put(localPolSourceObservation);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceObservation.Result);

            localPolSourceObservation = null;
            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");
            localPolSourceObservation.PolSourceObservationID = 10000000;
            actionLocalPolSourceObservation = await LocalPolSourceObservationDBService.Put(localPolSourceObservation);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceObservation.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "PolSourceSite", ExistPlurial = "s", ExistFieldID = "PolSourceSiteID", AllowableTVtypeList = )]
            // localPolSourceObservation.PolSourceSiteID   (Int32)
            // -----------------------------------

            localPolSourceObservation = null;
            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");
            localPolSourceObservation.PolSourceSiteID = 0;
            actionLocalPolSourceObservation = await LocalPolSourceObservationDBService.Post(localPolSourceObservation);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceObservation.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localPolSourceObservation.ObservationDate_Local   (DateTime)
            // -----------------------------------

            localPolSourceObservation = null;
            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");
            localPolSourceObservation.ObservationDate_Local = new DateTime();
            actionLocalPolSourceObservation = await LocalPolSourceObservationDBService.Post(localPolSourceObservation);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceObservation.Result);
            localPolSourceObservation = null;
            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");
            localPolSourceObservation.ObservationDate_Local = new DateTime(1979, 1, 1);
            actionLocalPolSourceObservation = await LocalPolSourceObservationDBService.Post(localPolSourceObservation);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceObservation.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localPolSourceObservation.ContactTVItemID   (Int32)
            // -----------------------------------

            localPolSourceObservation = null;
            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");
            localPolSourceObservation.ContactTVItemID = 0;
            actionLocalPolSourceObservation = await LocalPolSourceObservationDBService.Post(localPolSourceObservation);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceObservation.Result);

            localPolSourceObservation = null;
            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");
            localPolSourceObservation.ContactTVItemID = 1;
            actionLocalPolSourceObservation = await LocalPolSourceObservationDBService.Post(localPolSourceObservation);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceObservation.Result);


            // -----------------------------------
            // Is NOT Nullable
            // localPolSourceObservation.DesktopReviewed   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // localPolSourceObservation.Observation_ToBeDeleted   (String)
            // -----------------------------------

            localPolSourceObservation = null;
            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("Observation_ToBeDeleted");
            actionLocalPolSourceObservation = await LocalPolSourceObservationDBService.Post(localPolSourceObservation);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceObservation.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localPolSourceObservation.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localPolSourceObservation = null;
            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");
            localPolSourceObservation.LastUpdateDate_UTC = new DateTime();
            actionLocalPolSourceObservation = await LocalPolSourceObservationDBService.Post(localPolSourceObservation);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceObservation.Result);
            localPolSourceObservation = null;
            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");
            localPolSourceObservation.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalPolSourceObservation = await LocalPolSourceObservationDBService.Post(localPolSourceObservation);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceObservation.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localPolSourceObservation.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localPolSourceObservation = null;
            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");
            localPolSourceObservation.LastUpdateContactTVItemID = 0;
            actionLocalPolSourceObservation = await LocalPolSourceObservationDBService.Post(localPolSourceObservation);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceObservation.Result);

            localPolSourceObservation = null;
            localPolSourceObservation = GetFilledRandomLocalPolSourceObservation("");
            localPolSourceObservation.LastUpdateContactTVItemID = 1;
            actionLocalPolSourceObservation = await LocalPolSourceObservationDBService.Post(localPolSourceObservation);
            Assert.IsType<BadRequestObjectResult>(actionLocalPolSourceObservation.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalPolSourceObservation
            var actionLocalPolSourceObservationAdded = await LocalPolSourceObservationDBService.Post(localPolSourceObservation);
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceObservationAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceObservationAdded.Result).Value);
            LocalPolSourceObservation localPolSourceObservationAdded = (LocalPolSourceObservation)((OkObjectResult)actionLocalPolSourceObservationAdded.Result).Value;
            Assert.NotNull(localPolSourceObservationAdded);

            // List<LocalPolSourceObservation>
            var actionLocalPolSourceObservationList = await LocalPolSourceObservationDBService.GetLocalPolSourceObservationList();
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceObservationList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceObservationList.Result).Value);
            List<LocalPolSourceObservation> localPolSourceObservationList = (List<LocalPolSourceObservation>)((OkObjectResult)actionLocalPolSourceObservationList.Result).Value;

            int count = ((List<LocalPolSourceObservation>)((OkObjectResult)actionLocalPolSourceObservationList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalPolSourceObservation> with skip and take
            var actionLocalPolSourceObservationListSkipAndTake = await LocalPolSourceObservationDBService.GetLocalPolSourceObservationList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceObservationListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceObservationListSkipAndTake.Result).Value);
            List<LocalPolSourceObservation> localPolSourceObservationListSkipAndTake = (List<LocalPolSourceObservation>)((OkObjectResult)actionLocalPolSourceObservationListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalPolSourceObservation>)((OkObjectResult)actionLocalPolSourceObservationListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localPolSourceObservationList[0].PolSourceObservationID == localPolSourceObservationListSkipAndTake[0].PolSourceObservationID);

            // Get LocalPolSourceObservation With PolSourceObservationID
            var actionLocalPolSourceObservationGet = await LocalPolSourceObservationDBService.GetLocalPolSourceObservationWithPolSourceObservationID(localPolSourceObservationList[0].PolSourceObservationID);
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceObservationGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceObservationGet.Result).Value);
            LocalPolSourceObservation localPolSourceObservationGet = (LocalPolSourceObservation)((OkObjectResult)actionLocalPolSourceObservationGet.Result).Value;
            Assert.NotNull(localPolSourceObservationGet);
            Assert.Equal(localPolSourceObservationGet.PolSourceObservationID, localPolSourceObservationList[0].PolSourceObservationID);

            // Put LocalPolSourceObservation
            var actionLocalPolSourceObservationUpdated = await LocalPolSourceObservationDBService.Put(localPolSourceObservation);
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceObservationUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceObservationUpdated.Result).Value);
            LocalPolSourceObservation localPolSourceObservationUpdated = (LocalPolSourceObservation)((OkObjectResult)actionLocalPolSourceObservationUpdated.Result).Value;
            Assert.NotNull(localPolSourceObservationUpdated);

            // Delete LocalPolSourceObservation
            var actionLocalPolSourceObservationDeleted = await LocalPolSourceObservationDBService.Delete(localPolSourceObservation.PolSourceObservationID);
            Assert.Equal(200, ((ObjectResult)actionLocalPolSourceObservationDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalPolSourceObservationDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalPolSourceObservationDeleted.Result).Value;
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
            Services.AddSingleton<ILocalPolSourceObservationDBService, LocalPolSourceObservationDBService>();

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

            LocalPolSourceObservationDBService = Provider.GetService<ILocalPolSourceObservationDBService>();
            Assert.NotNull(LocalPolSourceObservationDBService);

            return await Task.FromResult(true);
        }
        private LocalPolSourceObservation GetFilledRandomLocalPolSourceObservation(string OmitPropName)
        {
            LocalPolSourceObservation localPolSourceObservation = new LocalPolSourceObservation();

            if (OmitPropName != "LocalDBCommand") localPolSourceObservation.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "PolSourceSiteID") localPolSourceObservation.PolSourceSiteID = 0;
            if (OmitPropName != "ObservationDate_Local") localPolSourceObservation.ObservationDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "ContactTVItemID") localPolSourceObservation.ContactTVItemID = 2;
            if (OmitPropName != "DesktopReviewed") localPolSourceObservation.DesktopReviewed = true;
            if (OmitPropName != "Observation_ToBeDeleted") localPolSourceObservation.Observation_ToBeDeleted = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") localPolSourceObservation.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localPolSourceObservation.LastUpdateContactTVItemID = 2;



            return localPolSourceObservation;
        }
        private void CheckLocalPolSourceObservationFields(List<LocalPolSourceObservation> localPolSourceObservationList)
        {
            Assert.False(string.IsNullOrWhiteSpace(localPolSourceObservationList[0].Observation_ToBeDeleted));
        }

        #endregion Functions private
    }
}