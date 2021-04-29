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
    public partial class LabSheetTubeMPNDetailDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ILabSheetTubeMPNDetailDBService LabSheetTubeMPNDetailDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBContext dbIM { get; set; }
        private LabSheetTubeMPNDetail labSheetTubeMPNDetail { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LabSheetTubeMPNDetailDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LabSheetTubeMPNDetailDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LabSheetTubeMPNDetail_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLabSheetTubeMPNDetailList = await LabSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailList();
            Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value);
            List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = (List<LabSheetTubeMPNDetail>)((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value;

            count = labSheetTubeMPNDetailList.Count();

            LabSheetTubeMPNDetail labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // labSheetTubeMPNDetail.LabSheetTubeMPNDetailID   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LabSheetTubeMPNDetailID = 0;

            var actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Put(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LabSheetTubeMPNDetailID = 10000000;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Put(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheetTubeMPNDetail.DBCommand   (DBCommandEnum)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.DBCommand = (DBCommandEnum)1000000;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "LabSheetDetail", ExistPlurial = "s", ExistFieldID = "LabSheetDetailID", AllowableTVtypeList = )]
            // labSheetTubeMPNDetail.LabSheetDetailID   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LabSheetDetailID = 0;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // labSheetTubeMPNDetail.Ordinal   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Ordinal = -1;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Ordinal = 1001;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
            // labSheetTubeMPNDetail.MWQMSiteTVItemID   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.MWQMSiteTVItemID = 0;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.MWQMSiteTVItemID = 1;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // labSheetTubeMPNDetail.SampleDateTime   (DateTime)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.SampleDateTime = new DateTime(1979, 1, 1);
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(1, 10000000)]
            // labSheetTubeMPNDetail.MPN   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.MPN = 0;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.MPN = 10000001;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 5)]
            // labSheetTubeMPNDetail.Tube10   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Tube10 = -1;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Tube10 = 6;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 5)]
            // labSheetTubeMPNDetail.Tube1_0   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Tube1_0 = -1;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Tube1_0 = 6;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 5)]
            // labSheetTubeMPNDetail.Tube0_1   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Tube0_1 = -1;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Tube0_1 = 6;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 40)]
            // labSheetTubeMPNDetail.Salinity   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Salinity]

            //CSSPError: Type not implemented [Salinity]

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Salinity = -1.0D;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Salinity = 41.0D;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-10, 40)]
            // labSheetTubeMPNDetail.Temperature   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Temperature]

            //CSSPError: Type not implemented [Temperature]

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Temperature = -11.0D;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Temperature = 41.0D;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(10)]
            // labSheetTubeMPNDetail.ProcessedBy   (String)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.ProcessedBy = GetRandomString("", 11);
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheetTubeMPNDetail.SampleType   (SampleTypeEnum)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.SampleType = (SampleTypeEnum)1000000;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(250)]
            // labSheetTubeMPNDetail.SiteComment   (String)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.SiteComment = GetRandomString("", 251);
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // labSheetTubeMPNDetail.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LastUpdateDate_UTC = new DateTime();
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // labSheetTubeMPNDetail.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LastUpdateContactTVItemID = 0;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LastUpdateContactTVItemID = 1;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post LabSheetTubeMPNDetail
            var actionLabSheetTubeMPNDetailAdded = await LabSheetTubeMPNDetailDBService.Post(labSheetTubeMPNDetail);
            Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailAdded.Result).Value);
            LabSheetTubeMPNDetail labSheetTubeMPNDetailAdded = (LabSheetTubeMPNDetail)((OkObjectResult)actionLabSheetTubeMPNDetailAdded.Result).Value;
            Assert.NotNull(labSheetTubeMPNDetailAdded);

            // List<LabSheetTubeMPNDetail>
            var actionLabSheetTubeMPNDetailList = await LabSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailList();
            Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value);
            List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = (List<LabSheetTubeMPNDetail>)((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value;

            int count = ((List<LabSheetTubeMPNDetail>)((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LabSheetTubeMPNDetail> with skip and take
            var actionLabSheetTubeMPNDetailListSkipAndTake = await LabSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailListSkipAndTake.Result).Value);
            List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailListSkipAndTake = (List<LabSheetTubeMPNDetail>)((OkObjectResult)actionLabSheetTubeMPNDetailListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LabSheetTubeMPNDetail>)((OkObjectResult)actionLabSheetTubeMPNDetailListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID == labSheetTubeMPNDetailListSkipAndTake[0].LabSheetTubeMPNDetailID);

            // Get LabSheetTubeMPNDetail With LabSheetTubeMPNDetailID
            var actionLabSheetTubeMPNDetailGet = await LabSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
            Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailGet.Result).Value);
            LabSheetTubeMPNDetail labSheetTubeMPNDetailGet = (LabSheetTubeMPNDetail)((OkObjectResult)actionLabSheetTubeMPNDetailGet.Result).Value;
            Assert.NotNull(labSheetTubeMPNDetailGet);
            Assert.Equal(labSheetTubeMPNDetailGet.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);

            // Put LabSheetTubeMPNDetail
            var actionLabSheetTubeMPNDetailUpdated = await LabSheetTubeMPNDetailDBService.Put(labSheetTubeMPNDetail);
            Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailUpdated.Result).Value);
            LabSheetTubeMPNDetail labSheetTubeMPNDetailUpdated = (LabSheetTubeMPNDetail)((OkObjectResult)actionLabSheetTubeMPNDetailUpdated.Result).Value;
            Assert.NotNull(labSheetTubeMPNDetailUpdated);

            // Delete LabSheetTubeMPNDetail
            var actionLabSheetTubeMPNDetailDeleted = await LabSheetTubeMPNDetailDBService.Delete(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID);
            Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLabSheetTubeMPNDetailDeleted.Result).Value;
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
            Services.AddSingleton<ILabSheetTubeMPNDetailDBService, LabSheetTubeMPNDetailDBService>();

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

            LabSheetTubeMPNDetailDBService = Provider.GetService<ILabSheetTubeMPNDetailDBService>();
            Assert.NotNull(LabSheetTubeMPNDetailDBService);

            return await Task.FromResult(true);
        }
        private LabSheetTubeMPNDetail GetFilledRandomLabSheetTubeMPNDetail(string OmitPropName)
        {
            LabSheetTubeMPNDetail labSheetTubeMPNDetail = new LabSheetTubeMPNDetail();

            if (OmitPropName != "DBCommand") labSheetTubeMPNDetail.DBCommand = (DBCommandEnum)GetRandomEnumType(typeof(DBCommandEnum));
            if (OmitPropName != "LabSheetDetailID") labSheetTubeMPNDetail.LabSheetDetailID = 0;
            if (OmitPropName != "Ordinal") labSheetTubeMPNDetail.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "MWQMSiteTVItemID") labSheetTubeMPNDetail.MWQMSiteTVItemID = 44;
            if (OmitPropName != "SampleDateTime") labSheetTubeMPNDetail.SampleDateTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "MPN") labSheetTubeMPNDetail.MPN = GetRandomInt(1, 10000000);
            if (OmitPropName != "Tube10") labSheetTubeMPNDetail.Tube10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube1_0") labSheetTubeMPNDetail.Tube1_0 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube0_1") labSheetTubeMPNDetail.Tube0_1 = GetRandomInt(0, 5);
            if (OmitPropName != "Salinity") labSheetTubeMPNDetail.Salinity = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "Temperature") labSheetTubeMPNDetail.Temperature = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "ProcessedBy") labSheetTubeMPNDetail.ProcessedBy = GetRandomString("", 5);
            if (OmitPropName != "SampleType") labSheetTubeMPNDetail.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "SiteComment") labSheetTubeMPNDetail.SiteComment = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") labSheetTubeMPNDetail.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") labSheetTubeMPNDetail.LastUpdateContactTVItemID = 2;

            return labSheetTubeMPNDetail;
        }
        private void CheckLabSheetTubeMPNDetailFields(List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList)
        {
            if (labSheetTubeMPNDetailList[0].SampleDateTime != null)
            {
                Assert.NotNull(labSheetTubeMPNDetailList[0].SampleDateTime);
            }
            if (labSheetTubeMPNDetailList[0].MPN != null)
            {
                Assert.NotNull(labSheetTubeMPNDetailList[0].MPN);
            }
            if (labSheetTubeMPNDetailList[0].Tube10 != null)
            {
                Assert.NotNull(labSheetTubeMPNDetailList[0].Tube10);
            }
            if (labSheetTubeMPNDetailList[0].Tube1_0 != null)
            {
                Assert.NotNull(labSheetTubeMPNDetailList[0].Tube1_0);
            }
            if (labSheetTubeMPNDetailList[0].Tube0_1 != null)
            {
                Assert.NotNull(labSheetTubeMPNDetailList[0].Tube0_1);
            }
            if (labSheetTubeMPNDetailList[0].Salinity != null)
            {
                Assert.NotNull(labSheetTubeMPNDetailList[0].Salinity);
            }
            if (labSheetTubeMPNDetailList[0].Temperature != null)
            {
                Assert.NotNull(labSheetTubeMPNDetailList[0].Temperature);
            }
            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailList[0].ProcessedBy))
            {
                Assert.False(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailList[0].ProcessedBy));
            }
            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailList[0].SiteComment))
            {
                Assert.False(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailList[0].SiteComment));
            }
        }

        #endregion Functions private
    }
}
