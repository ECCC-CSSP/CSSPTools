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

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class LabSheetTubeMPNDetailServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ILabSheetTubeMPNDetailService LabSheetTubeMPNDetailService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private LabSheetTubeMPNDetail labSheetTubeMPNDetail { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task LabSheetTubeMPNDetail_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                await DoCRUDTest();
            }
            else
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    await DoCRUDTest();
                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task LabSheetTubeMPNDetail_Properties_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLabSheetTubeMPNDetailList = await LabSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList();
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

            var actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Put(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LabSheetTubeMPNDetailID = 10000000;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Put(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "LabSheetDetail", ExistPlurial = "s", ExistFieldID = "LabSheetDetailID", AllowableTVtypeList = )]
            // labSheetTubeMPNDetail.LabSheetDetailID   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LabSheetDetailID = 0;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // labSheetTubeMPNDetail.Ordinal   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Ordinal = -1;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Ordinal = 1001;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
            // labSheetTubeMPNDetail.MWQMSiteTVItemID   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.MWQMSiteTVItemID = 0;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.MWQMSiteTVItemID = 1;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // labSheetTubeMPNDetail.SampleDateTime   (DateTime)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.SampleDateTime = new DateTime(1979, 1, 1);
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(1, 10000000)]
            // labSheetTubeMPNDetail.MPN   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.MPN = 0;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.MPN = 10000001;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 5)]
            // labSheetTubeMPNDetail.Tube10   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Tube10 = -1;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Tube10 = 6;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 5)]
            // labSheetTubeMPNDetail.Tube1_0   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Tube1_0 = -1;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Tube1_0 = 6;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 5)]
            // labSheetTubeMPNDetail.Tube0_1   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Tube0_1 = -1;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Tube0_1 = 6;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

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
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Salinity = 41.0D;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

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
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.Temperature = 41.0D;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(10)]
            // labSheetTubeMPNDetail.ProcessedBy   (String)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.ProcessedBy = GetRandomString("", 11);
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheetTubeMPNDetail.SampleType   (SampleTypeEnum)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.SampleType = (SampleTypeEnum)1000000;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(250)]
            // labSheetTubeMPNDetail.SiteComment   (String)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.SiteComment = GetRandomString("", 251);
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            //Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // labSheetTubeMPNDetail.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LastUpdateDate_UTC = new DateTime();
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);
            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // labSheetTubeMPNDetail.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LastUpdateContactTVItemID = 0;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LastUpdateContactTVItemID = 1;
            actionLabSheetTubeMPNDetail = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.IsType<BadRequestObjectResult>(actionLabSheetTubeMPNDetail.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post LabSheetTubeMPNDetail
            var actionLabSheetTubeMPNDetailAdded = await LabSheetTubeMPNDetailService.Post(labSheetTubeMPNDetail);
            Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailAdded.Result).Value);
            LabSheetTubeMPNDetail labSheetTubeMPNDetailAdded = (LabSheetTubeMPNDetail)((OkObjectResult)actionLabSheetTubeMPNDetailAdded.Result).Value;
            Assert.NotNull(labSheetTubeMPNDetailAdded);

            // List<LabSheetTubeMPNDetail>
            var actionLabSheetTubeMPNDetailList = await LabSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList();
            Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value);
            List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = (List<LabSheetTubeMPNDetail>)((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value;

            int count = ((List<LabSheetTubeMPNDetail>)((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<LabSheetTubeMPNDetail> with skip and take
                var actionLabSheetTubeMPNDetailListSkipAndTake = await LabSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailListSkipAndTake.Result).Value);
                List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailListSkipAndTake = (List<LabSheetTubeMPNDetail>)((OkObjectResult)actionLabSheetTubeMPNDetailListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<LabSheetTubeMPNDetail>)((OkObjectResult)actionLabSheetTubeMPNDetailListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID == labSheetTubeMPNDetailListSkipAndTake[0].LabSheetTubeMPNDetailID);
            }

            // Get LabSheetTubeMPNDetail With LabSheetTubeMPNDetailID
            var actionLabSheetTubeMPNDetailGet = await LabSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
            Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailGet.Result).Value);
            LabSheetTubeMPNDetail labSheetTubeMPNDetailGet = (LabSheetTubeMPNDetail)((OkObjectResult)actionLabSheetTubeMPNDetailGet.Result).Value;
            Assert.NotNull(labSheetTubeMPNDetailGet);
            Assert.Equal(labSheetTubeMPNDetailGet.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);

            // Put LabSheetTubeMPNDetail
            var actionLabSheetTubeMPNDetailUpdated = await LabSheetTubeMPNDetailService.Put(labSheetTubeMPNDetail);
            Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailUpdated.Result).Value);
            LabSheetTubeMPNDetail labSheetTubeMPNDetailUpdated = (LabSheetTubeMPNDetail)((OkObjectResult)actionLabSheetTubeMPNDetailUpdated.Result).Value;
            Assert.NotNull(labSheetTubeMPNDetailUpdated);

            // Delete LabSheetTubeMPNDetail
            var actionLabSheetTubeMPNDetailDeleted = await LabSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID);
            Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLabSheetTubeMPNDetailDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservices.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            string TestDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILabSheetTubeMPNDetailService, LabSheetTubeMPNDetailService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.DBLocation = DBLocationEnum.Local;

            dbIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            LabSheetTubeMPNDetailService = Provider.GetService<ILabSheetTubeMPNDetailService>();
            Assert.NotNull(LabSheetTubeMPNDetailService);

            return await Task.FromResult(true);
        }
        private LabSheetTubeMPNDetail GetFilledRandomLabSheetTubeMPNDetail(string OmitPropName)
        {
            List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailListToDelete = (from c in dbLocal.LabSheetTubeMPNDetails
                                                               select c).ToList(); 
            
            dbLocal.LabSheetTubeMPNDetails.RemoveRange(labSheetTubeMPNDetailListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            LabSheetTubeMPNDetail labSheetTubeMPNDetail = new LabSheetTubeMPNDetail();

            if (OmitPropName != "LabSheetDetailID") labSheetTubeMPNDetail.LabSheetDetailID = 1;
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

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "LabSheetTubeMPNDetailID") labSheetTubeMPNDetail.LabSheetTubeMPNDetailID = 10000000;

                try
                {
                    dbIM.LabSheetDetails.Add(new LabSheetDetail() { LabSheetDetailID = 1, LabSheetID = 1, SamplingPlanID = 1, SubsectorTVItemID = 12, Version = 1, RunDate = new DateTime(2017, 6, 21, 0, 0, 0), Tides = @"HT / HF", SampleCrewInitials = "", WaterBathCount = null, IncubationBath1StartTime = null, IncubationBath2StartTime = null, IncubationBath3StartTime = null, IncubationBath1EndTime = null, IncubationBath2EndTime = null, IncubationBath3EndTime = null, IncubationBath1TimeCalculated_minutes = null, IncubationBath2TimeCalculated_minutes = null, IncubationBath3TimeCalculated_minutes = null, WaterBath1 = "", WaterBath2 = "", WaterBath3 = "", TCField1 = null, TCLab1 = null, TCField2 = null, TCLab2 = null, TCFirst = null, TCAverage = null, ControlLot = "null", Positive35 = "null", NonTarget35 = "null", Negative35 = "null", Bath1Positive44_5 = "null", Bath2Positive44_5 = "null", Bath3Positive44_5 = "null", Bath1NonTarget44_5 = "null", Bath2NonTarget44_5 = "null", Bath3NonTarget44_5 = "null", Bath1Negative44_5 = "null", Bath2Negative44_5 = "null", Bath3Negative44_5 = "null", Blank35 = null, Bath1Blank44_5 = "null", Bath2Blank44_5 = "null", Bath3Blank44_5 = "null", Lot35 = "null", Lot44_5 = "null", Weather = "null", RunComment = "null", RunWeatherComment = "null", SampleBottleLotNumber = "null", SalinitiesReadBy = "null", SalinitiesReadDate = null, ResultsReadBy = "null", ResultsReadDate = null, ResultsRecordedBy = "null", ResultsRecordedDate = null, DailyDuplicateRLog = null, DailyDuplicatePrecisionCriteria = null, DailyDuplicateAcceptable = null, IntertechDuplicateRLog = null, IntertechDuplicatePrecisionCriteria = null, IntertechDuplicateAcceptable = null, IntertechReadAcceptable = null, LastUpdateDate_UTC = new DateTime(2017, 6, 26, 18, 38, 21), LastUpdateContactTVItemID = 2 });
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 44, TVLevel = 6, TVPath = "p1p5p6p9p10p12p44", TVType = (TVTypeEnum)16, ParentID = 12, IsActive = true, LastUpdateDate_UTC = new DateTime(2017, 10, 12, 17, 39, 34), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
            }

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
