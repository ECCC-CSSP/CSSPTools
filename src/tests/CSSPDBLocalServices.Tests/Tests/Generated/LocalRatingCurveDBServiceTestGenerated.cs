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
    public partial class LocalRatingCurveDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalRatingCurveDBService LocalRatingCurveDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalRatingCurve localRatingCurve { get; set; }
        #endregion Properties

        #region Constructors
        public LocalRatingCurveDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalRatingCurveDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalRatingCurveDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localRatingCurve = GetFilledRandomLocalRatingCurve("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalRatingCurve_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalRatingCurveList = await LocalRatingCurveDBService.GetLocalRatingCurveList();
            Assert.Equal(200, ((ObjectResult)actionLocalRatingCurveList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalRatingCurveList.Result).Value);
            List<LocalRatingCurve> localRatingCurveList = (List<LocalRatingCurve>)((OkObjectResult)actionLocalRatingCurveList.Result).Value;

            count = localRatingCurveList.Count();

            LocalRatingCurve localRatingCurve = GetFilledRandomLocalRatingCurve("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localRatingCurve.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localRatingCurve = null;
            localRatingCurve = GetFilledRandomLocalRatingCurve("");
            localRatingCurve.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalRatingCurve = await LocalRatingCurveDBService.Post(localRatingCurve);
            Assert.IsType<BadRequestObjectResult>(actionLocalRatingCurve.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localRatingCurve.RatingCurveID   (Int32)
            // -----------------------------------

            localRatingCurve = null;
            localRatingCurve = GetFilledRandomLocalRatingCurve("");
            localRatingCurve.RatingCurveID = 0;

            actionLocalRatingCurve = await LocalRatingCurveDBService.Put(localRatingCurve);
            Assert.IsType<BadRequestObjectResult>(actionLocalRatingCurve.Result);

            localRatingCurve = null;
            localRatingCurve = GetFilledRandomLocalRatingCurve("");
            localRatingCurve.RatingCurveID = 10000000;
            actionLocalRatingCurve = await LocalRatingCurveDBService.Put(localRatingCurve);
            Assert.IsType<BadRequestObjectResult>(actionLocalRatingCurve.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID", AllowableTVtypeList = )]
            // localRatingCurve.HydrometricSiteID   (Int32)
            // -----------------------------------

            localRatingCurve = null;
            localRatingCurve = GetFilledRandomLocalRatingCurve("");
            localRatingCurve.HydrometricSiteID = 0;
            actionLocalRatingCurve = await LocalRatingCurveDBService.Post(localRatingCurve);
            Assert.IsType<BadRequestObjectResult>(actionLocalRatingCurve.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(50)]
            // localRatingCurve.RatingCurveNumber   (String)
            // -----------------------------------

            localRatingCurve = null;
            localRatingCurve = GetFilledRandomLocalRatingCurve("RatingCurveNumber");
            actionLocalRatingCurve = await LocalRatingCurveDBService.Post(localRatingCurve);
            Assert.IsType<BadRequestObjectResult>(actionLocalRatingCurve.Result);

            localRatingCurve = null;
            localRatingCurve = GetFilledRandomLocalRatingCurve("");
            localRatingCurve.RatingCurveNumber = GetRandomString("", 51);
            actionLocalRatingCurve = await LocalRatingCurveDBService.Post(localRatingCurve);
            Assert.IsType<BadRequestObjectResult>(actionLocalRatingCurve.Result);
            //Assert.AreEqual(count, localRatingCurveDBService.GetLocalRatingCurveList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localRatingCurve.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localRatingCurve = null;
            localRatingCurve = GetFilledRandomLocalRatingCurve("");
            localRatingCurve.LastUpdateDate_UTC = new DateTime();
            actionLocalRatingCurve = await LocalRatingCurveDBService.Post(localRatingCurve);
            Assert.IsType<BadRequestObjectResult>(actionLocalRatingCurve.Result);
            localRatingCurve = null;
            localRatingCurve = GetFilledRandomLocalRatingCurve("");
            localRatingCurve.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalRatingCurve = await LocalRatingCurveDBService.Post(localRatingCurve);
            Assert.IsType<BadRequestObjectResult>(actionLocalRatingCurve.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localRatingCurve.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localRatingCurve = null;
            localRatingCurve = GetFilledRandomLocalRatingCurve("");
            localRatingCurve.LastUpdateContactTVItemID = 0;
            actionLocalRatingCurve = await LocalRatingCurveDBService.Post(localRatingCurve);
            Assert.IsType<BadRequestObjectResult>(actionLocalRatingCurve.Result);

            localRatingCurve = null;
            localRatingCurve = GetFilledRandomLocalRatingCurve("");
            localRatingCurve.LastUpdateContactTVItemID = 1;
            actionLocalRatingCurve = await LocalRatingCurveDBService.Post(localRatingCurve);
            Assert.IsType<BadRequestObjectResult>(actionLocalRatingCurve.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalRatingCurve
            var actionLocalRatingCurveAdded = await LocalRatingCurveDBService.Post(localRatingCurve);
            Assert.Equal(200, ((ObjectResult)actionLocalRatingCurveAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalRatingCurveAdded.Result).Value);
            LocalRatingCurve localRatingCurveAdded = (LocalRatingCurve)((OkObjectResult)actionLocalRatingCurveAdded.Result).Value;
            Assert.NotNull(localRatingCurveAdded);

            // List<LocalRatingCurve>
            var actionLocalRatingCurveList = await LocalRatingCurveDBService.GetLocalRatingCurveList();
            Assert.Equal(200, ((ObjectResult)actionLocalRatingCurveList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalRatingCurveList.Result).Value);
            List<LocalRatingCurve> localRatingCurveList = (List<LocalRatingCurve>)((OkObjectResult)actionLocalRatingCurveList.Result).Value;

            int count = ((List<LocalRatingCurve>)((OkObjectResult)actionLocalRatingCurveList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalRatingCurve> with skip and take
            var actionLocalRatingCurveListSkipAndTake = await LocalRatingCurveDBService.GetLocalRatingCurveList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalRatingCurveListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalRatingCurveListSkipAndTake.Result).Value);
            List<LocalRatingCurve> localRatingCurveListSkipAndTake = (List<LocalRatingCurve>)((OkObjectResult)actionLocalRatingCurveListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalRatingCurve>)((OkObjectResult)actionLocalRatingCurveListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localRatingCurveList[0].RatingCurveID == localRatingCurveListSkipAndTake[0].RatingCurveID);

            // Get LocalRatingCurve With RatingCurveID
            var actionLocalRatingCurveGet = await LocalRatingCurveDBService.GetLocalRatingCurveWithRatingCurveID(localRatingCurveList[0].RatingCurveID);
            Assert.Equal(200, ((ObjectResult)actionLocalRatingCurveGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalRatingCurveGet.Result).Value);
            LocalRatingCurve localRatingCurveGet = (LocalRatingCurve)((OkObjectResult)actionLocalRatingCurveGet.Result).Value;
            Assert.NotNull(localRatingCurveGet);
            Assert.Equal(localRatingCurveGet.RatingCurveID, localRatingCurveList[0].RatingCurveID);

            // Put LocalRatingCurve
            var actionLocalRatingCurveUpdated = await LocalRatingCurveDBService.Put(localRatingCurve);
            Assert.Equal(200, ((ObjectResult)actionLocalRatingCurveUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalRatingCurveUpdated.Result).Value);
            LocalRatingCurve localRatingCurveUpdated = (LocalRatingCurve)((OkObjectResult)actionLocalRatingCurveUpdated.Result).Value;
            Assert.NotNull(localRatingCurveUpdated);

            // Delete LocalRatingCurve
            var actionLocalRatingCurveDeleted = await LocalRatingCurveDBService.Delete(localRatingCurve.RatingCurveID);
            Assert.Equal(200, ((ObjectResult)actionLocalRatingCurveDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalRatingCurveDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalRatingCurveDeleted.Result).Value;
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
            Services.AddSingleton<ILocalRatingCurveDBService, LocalRatingCurveDBService>();

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

            LocalRatingCurveDBService = Provider.GetService<ILocalRatingCurveDBService>();
            Assert.NotNull(LocalRatingCurveDBService);

            return await Task.FromResult(true);
        }
        private LocalRatingCurve GetFilledRandomLocalRatingCurve(string OmitPropName)
        {
            LocalRatingCurve localRatingCurve = new LocalRatingCurve();

            if (OmitPropName != "LocalDBCommand") localRatingCurve.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "HydrometricSiteID") localRatingCurve.HydrometricSiteID = 0;
            if (OmitPropName != "RatingCurveNumber") localRatingCurve.RatingCurveNumber = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") localRatingCurve.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localRatingCurve.LastUpdateContactTVItemID = 2;



            return localRatingCurve;
        }
        private void CheckLocalRatingCurveFields(List<LocalRatingCurve> localRatingCurveList)
        {
            Assert.False(string.IsNullOrWhiteSpace(localRatingCurveList[0].RatingCurveNumber));
        }

        #endregion Functions private
    }
}
