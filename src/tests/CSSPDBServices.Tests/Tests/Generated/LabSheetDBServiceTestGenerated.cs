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
    public partial class LabSheetDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ILabSheetDBService LabSheetDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private LabSheet labSheet { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DB]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LabSheetDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            labSheet = GetFilledRandomLabSheet("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LabSheet_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLabSheetList = await LabSheetDBService.GetLabSheetList();
            Assert.Equal(200, ((ObjectResult)actionLabSheetList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetList.Result).Value);
            List<LabSheet> labSheetList = (List<LabSheet>)((OkObjectResult)actionLabSheetList.Result).Value;

            count = labSheetList.Count();

            LabSheet labSheet = GetFilledRandomLabSheet("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // labSheet.LabSheetID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LabSheetID = 0;

            var actionLabSheet = await LabSheetDBService.Put(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LabSheetID = 10000000;
            actionLabSheet = await LabSheetDBService.Put(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // labSheet.OtherServerLabSheetID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.OtherServerLabSheetID = 0;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID", AllowableTVtypeList = )]
            // labSheet.SamplingPlanID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SamplingPlanID = 0;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // [CSSPMinLength(1)]
            // labSheet.SamplingPlanName   (String)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("SamplingPlanName");
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SamplingPlanName = GetRandomString("", 251);
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetDBService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1980, -1)]
            // labSheet.Year   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.Year = 1979;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, 12)]
            // labSheet.Month   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.Month = 0;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetService.GetLabSheetList().Count());
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.Month = 13;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetDBService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, 31)]
            // labSheet.Day   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.Day = 0;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetService.GetLabSheetList().Count());
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.Day = 32;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetDBService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, 100)]
            // labSheet.RunNumber   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.RunNumber = 0;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetService.GetLabSheetList().Count());
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.RunNumber = 101;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetDBService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
            // labSheet.SubsectorTVItemID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SubsectorTVItemID = 0;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SubsectorTVItemID = 1;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMRun)]
            // labSheet.MWQMRunTVItemID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.MWQMRunTVItemID = 0;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.MWQMRunTVItemID = 1;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheet.SamplingPlanType   (SamplingPlanTypeEnum)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SamplingPlanType = (SamplingPlanTypeEnum)1000000;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheet.SampleType   (SampleTypeEnum)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SampleType = (SampleTypeEnum)1000000;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheet.LabSheetType   (LabSheetTypeEnum)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LabSheetType = (LabSheetTypeEnum)1000000;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheet.LabSheetStatus   (LabSheetStatusEnum)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LabSheetStatus = (LabSheetStatusEnum)1000000;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // [CSSPMinLength(1)]
            // labSheet.FileName   (String)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("FileName");
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.FileName = GetRandomString("", 251);
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetDBService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // labSheet.FileLastModifiedDate_Local   (DateTime)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.FileLastModifiedDate_Local = new DateTime();
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.FileLastModifiedDate_Local = new DateTime(1979, 1, 1);
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            // -----------------------------------
            // Is NOT Nullable
            // labSheet.FileContent   (String)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("FileContent");
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // labSheet.AcceptedOrRejectedByContactTVItemID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.AcceptedOrRejectedByContactTVItemID = 0;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.AcceptedOrRejectedByContactTVItemID = 1;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // labSheet.AcceptedOrRejectedDateTime   (DateTime)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.AcceptedOrRejectedDateTime = new DateTime(1979, 1, 1);
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(250)]
            // labSheet.RejectReason   (String)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.RejectReason = GetRandomString("", 251);
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetDBService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // labSheet.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LastUpdateDate_UTC = new DateTime();
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // labSheet.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LastUpdateContactTVItemID = 0;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LastUpdateContactTVItemID = 1;
            actionLabSheet = await LabSheetDBService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post LabSheet
            var actionLabSheetAdded = await LabSheetDBService.Post(labSheet);
            Assert.Equal(200, ((ObjectResult)actionLabSheetAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetAdded.Result).Value);
            LabSheet labSheetAdded = (LabSheet)((OkObjectResult)actionLabSheetAdded.Result).Value;
            Assert.NotNull(labSheetAdded);

            // List<LabSheet>
            var actionLabSheetList = await LabSheetDBService.GetLabSheetList();
            Assert.Equal(200, ((ObjectResult)actionLabSheetList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetList.Result).Value);
            List<LabSheet> labSheetList = (List<LabSheet>)((OkObjectResult)actionLabSheetList.Result).Value;

            int count = ((List<LabSheet>)((OkObjectResult)actionLabSheetList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LabSheet> with skip and take
            var actionLabSheetListSkipAndTake = await LabSheetDBService.GetLabSheetList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLabSheetListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetListSkipAndTake.Result).Value);
            List<LabSheet> labSheetListSkipAndTake = (List<LabSheet>)((OkObjectResult)actionLabSheetListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LabSheet>)((OkObjectResult)actionLabSheetListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(labSheetList[0].LabSheetID == labSheetListSkipAndTake[0].LabSheetID);

            // Get LabSheet With LabSheetID
            var actionLabSheetGet = await LabSheetDBService.GetLabSheetWithLabSheetID(labSheetList[0].LabSheetID);
            Assert.Equal(200, ((ObjectResult)actionLabSheetGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetGet.Result).Value);
            LabSheet labSheetGet = (LabSheet)((OkObjectResult)actionLabSheetGet.Result).Value;
            Assert.NotNull(labSheetGet);
            Assert.Equal(labSheetGet.LabSheetID, labSheetList[0].LabSheetID);

            // Put LabSheet
            var actionLabSheetUpdated = await LabSheetDBService.Put(labSheet);
            Assert.Equal(200, ((ObjectResult)actionLabSheetUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetUpdated.Result).Value);
            LabSheet labSheetUpdated = (LabSheet)((OkObjectResult)actionLabSheetUpdated.Result).Value;
            Assert.NotNull(labSheetUpdated);

            // Delete LabSheet
            var actionLabSheetDeleted = await LabSheetDBService.Delete(labSheet.LabSheetID);
            Assert.Equal(200, ((ObjectResult)actionLabSheetDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLabSheetDeleted.Result).Value;
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

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILabSheetDBService, LabSheetDBService>();

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

            LabSheetDBService = Provider.GetService<ILabSheetDBService>();
            Assert.NotNull(LabSheetDBService);

            return await Task.FromResult(true);
        }
        private LabSheet GetFilledRandomLabSheet(string OmitPropName)
        {
            LabSheet labSheet = new LabSheet();

            if (OmitPropName != "OtherServerLabSheetID") labSheet.OtherServerLabSheetID = GetRandomInt(1, 11);
            if (OmitPropName != "SamplingPlanID") labSheet.SamplingPlanID = 1;
            if (OmitPropName != "SamplingPlanName") labSheet.SamplingPlanName = GetRandomString("", 6);
            if (OmitPropName != "Year") labSheet.Year = GetRandomInt(1980, 1990);
            if (OmitPropName != "Month") labSheet.Month = GetRandomInt(1, 12);
            if (OmitPropName != "Day") labSheet.Day = GetRandomInt(1, 31);
            if (OmitPropName != "RunNumber") labSheet.RunNumber = GetRandomInt(1, 100);
            if (OmitPropName != "SubsectorTVItemID") labSheet.SubsectorTVItemID = 11;
            if (OmitPropName != "MWQMRunTVItemID") labSheet.MWQMRunTVItemID = 50;
            if (OmitPropName != "SamplingPlanType") labSheet.SamplingPlanType = (SamplingPlanTypeEnum)GetRandomEnumType(typeof(SamplingPlanTypeEnum));
            if (OmitPropName != "SampleType") labSheet.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "LabSheetType") labSheet.LabSheetType = (LabSheetTypeEnum)GetRandomEnumType(typeof(LabSheetTypeEnum));
            if (OmitPropName != "LabSheetStatus") labSheet.LabSheetStatus = (LabSheetStatusEnum)GetRandomEnumType(typeof(LabSheetStatusEnum));
            if (OmitPropName != "FileName") labSheet.FileName = GetRandomString("", 6);
            if (OmitPropName != "FileLastModifiedDate_Local") labSheet.FileLastModifiedDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "FileContent") labSheet.FileContent = GetRandomString("", 20);
            if (OmitPropName != "AcceptedOrRejectedByContactTVItemID") labSheet.AcceptedOrRejectedByContactTVItemID = 2;
            if (OmitPropName != "AcceptedOrRejectedDateTime") labSheet.AcceptedOrRejectedDateTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "RejectReason") labSheet.RejectReason = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") labSheet.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") labSheet.LastUpdateContactTVItemID = 2;



            return labSheet;
        }
        private void CheckLabSheetFields(List<LabSheet> labSheetList)
        {
            Assert.False(string.IsNullOrWhiteSpace(labSheetList[0].SamplingPlanName));
            if (labSheetList[0].MWQMRunTVItemID != null)
            {
                Assert.NotNull(labSheetList[0].MWQMRunTVItemID);
            }
            Assert.False(string.IsNullOrWhiteSpace(labSheetList[0].FileName));
            Assert.False(string.IsNullOrWhiteSpace(labSheetList[0].FileContent));
            if (labSheetList[0].AcceptedOrRejectedByContactTVItemID != null)
            {
                Assert.NotNull(labSheetList[0].AcceptedOrRejectedByContactTVItemID);
            }
            if (labSheetList[0].AcceptedOrRejectedDateTime != null)
            {
                Assert.NotNull(labSheetList[0].AcceptedOrRejectedDateTime);
            }
            if (!string.IsNullOrWhiteSpace(labSheetList[0].RejectReason))
            {
                Assert.False(string.IsNullOrWhiteSpace(labSheetList[0].RejectReason));
            }
        }

        #endregion Functions private
    }
}
