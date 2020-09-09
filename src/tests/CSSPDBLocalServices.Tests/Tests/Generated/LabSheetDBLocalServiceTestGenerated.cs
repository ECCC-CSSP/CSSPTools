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
    public partial class LabSheetDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILabSheetDBLocalService LabSheetDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private LabSheet labSheet { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocal]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LabSheetDBLocal_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocal]

        #region Tests Generated [DBLocal] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LabSheetDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            labSheet = GetFilledRandomLabSheet("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated [DBLocal] CRUD

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

            var actionLabSheetList = await LabSheetDBLocalService.GetLabSheetList();
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

            var actionLabSheet = await LabSheetDBLocalService.Put(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LabSheetID = 10000000;
            actionLabSheet = await LabSheetDBLocalService.Put(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // labSheet.OtherServerLabSheetID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.OtherServerLabSheetID = 0;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
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
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // [CSSPMinLength(1)]
            // labSheet.SamplingPlanName   (String)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("SamplingPlanName");
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SamplingPlanName = GetRandomString("", 251);
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetDBLocalService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1980, -1)]
            // labSheet.Year   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.Year = 1979;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
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
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetService.GetLabSheetList().Count());
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.Month = 13;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetDBLocalService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, 31)]
            // labSheet.Day   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.Day = 0;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetService.GetLabSheetList().Count());
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.Day = 32;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetDBLocalService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, 100)]
            // labSheet.RunNumber   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.RunNumber = 0;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetService.GetLabSheetList().Count());
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.RunNumber = 101;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetDBLocalService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
            // labSheet.SubsectorTVItemID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SubsectorTVItemID = 0;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SubsectorTVItemID = 1;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMRun)]
            // labSheet.MWQMRunTVItemID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.MWQMRunTVItemID = 0;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.MWQMRunTVItemID = 1;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheet.SamplingPlanType   (SamplingPlanTypeEnum)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SamplingPlanType = (SamplingPlanTypeEnum)1000000;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheet.SampleType   (SampleTypeEnum)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SampleType = (SampleTypeEnum)1000000;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheet.LabSheetType   (LabSheetTypeEnum)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LabSheetType = (LabSheetTypeEnum)1000000;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheet.LabSheetStatus   (LabSheetStatusEnum)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LabSheetStatus = (LabSheetStatusEnum)1000000;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // [CSSPMinLength(1)]
            // labSheet.FileName   (String)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("FileName");
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.FileName = GetRandomString("", 251);
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetDBLocalService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // labSheet.FileLastModifiedDate_Local   (DateTime)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.FileLastModifiedDate_Local = new DateTime();
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.FileLastModifiedDate_Local = new DateTime(1979, 1, 1);
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            // -----------------------------------
            // Is NOT Nullable
            // labSheet.FileContent   (String)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("FileContent");
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // labSheet.AcceptedOrRejectedByContactTVItemID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.AcceptedOrRejectedByContactTVItemID = 0;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.AcceptedOrRejectedByContactTVItemID = 1;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // labSheet.AcceptedOrRejectedDateTime   (DateTime)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.AcceptedOrRejectedDateTime = new DateTime(1979, 1, 1);
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(250)]
            // labSheet.RejectReason   (String)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.RejectReason = GetRandomString("", 251);
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            //Assert.AreEqual(count, labSheetDBLocalService.GetLabSheetList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // labSheet.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LastUpdateDate_UTC = new DateTime();
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // labSheet.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LastUpdateContactTVItemID = 0;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LastUpdateContactTVItemID = 1;
            actionLabSheet = await LabSheetDBLocalService.Post(labSheet);
            Assert.IsType<BadRequestObjectResult>(actionLabSheet.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LabSheet
            var actionLabSheetAdded = await LabSheetDBLocalService.Post(labSheet);
            Assert.Equal(200, ((ObjectResult)actionLabSheetAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetAdded.Result).Value);
            LabSheet labSheetAdded = (LabSheet)((OkObjectResult)actionLabSheetAdded.Result).Value;
            Assert.NotNull(labSheetAdded);

            // List<LabSheet>
            var actionLabSheetList = await LabSheetDBLocalService.GetLabSheetList();
            Assert.Equal(200, ((ObjectResult)actionLabSheetList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetList.Result).Value);
            List<LabSheet> labSheetList = (List<LabSheet>)((OkObjectResult)actionLabSheetList.Result).Value;

            int count = ((List<LabSheet>)((OkObjectResult)actionLabSheetList.Result).Value).Count();
            Assert.True(count > 0);

            // Get LabSheet With LabSheetID
            var actionLabSheetGet = await LabSheetDBLocalService.GetLabSheetWithLabSheetID(labSheetList[0].LabSheetID);
            Assert.Equal(200, ((ObjectResult)actionLabSheetGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetGet.Result).Value);
            LabSheet labSheetGet = (LabSheet)((OkObjectResult)actionLabSheetGet.Result).Value;
            Assert.NotNull(labSheetGet);
            Assert.Equal(labSheetGet.LabSheetID, labSheetList[0].LabSheetID);

            // Put LabSheet
            var actionLabSheetUpdated = await LabSheetDBLocalService.Put(labSheet);
            Assert.Equal(200, ((ObjectResult)actionLabSheetUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetUpdated.Result).Value);
            LabSheet labSheetUpdated = (LabSheet)((OkObjectResult)actionLabSheetUpdated.Result).Value;
            Assert.NotNull(labSheetUpdated);

            // Delete LabSheet
            var actionLabSheetDeleted = await LabSheetDBLocalService.Delete(labSheet.LabSheetID);
            Assert.Equal(200, ((ObjectResult)actionLabSheetDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLabSheetDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLabSheetDeleted.Result).Value;
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
            Services.AddSingleton<ILabSheetDBLocalService, LabSheetDBLocalService>();

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

            LabSheetDBLocalService = Provider.GetService<ILabSheetDBLocalService>();
            Assert.NotNull(LabSheetDBLocalService);

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

            try
            {
                dbLocalIM.SamplingPlans.Add(new SamplingPlan() { SamplingPlanID = 1, IsActive = false, SamplingPlanName = @"C:\CSSPLabSheets\SamplingPlan_Subsector_Routine_A1_2019_a_aa.txt", ForGroupName = "a_aa", SampleType = (SampleTypeEnum)109, SamplingPlanType = (SamplingPlanTypeEnum)1, LabSheetType = (LabSheetTypeEnum)1, ProvinceTVItemID = 6, CreatorTVItemID = 2, Year = 2019, AccessCode = "Microlab12", DailyDuplicatePrecisionCriteria = 0.6872000098228455, IntertechDuplicatePrecisionCriteria = 0.09300000220537186, IncludeLaboratoryQAQC = false, ApprovalCode = "aaabbb", SamplingPlanFileTVItemID = 49, AnalyzeMethodDefault = (AnalyzeMethodEnum)6, SampleMatrixDefault = (SampleMatrixEnum)7, LaboratoryDefault = (LaboratoryEnum)19, BackupDirectory = @"\\Atlantic.int.ec.gc.ca\shares\Branches\EPB\ShellFish\CSSPTools\CSSPLabSheets\", LastUpdateDate_UTC = new DateTime(2019, 1, 28, 15, 15, 42), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }
            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 11, TVLevel = 5, TVPath = "p1p5p6p9p10p11", TVType = (TVTypeEnum)20, ParentID = 10, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 18, 53, 40), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }
            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 50, TVLevel = 6, TVPath = "p1p5p6p9p10p12p50", TVType = (TVTypeEnum)31, ParentID = 12, IsActive = true, LastUpdateDate_UTC = new DateTime(2017, 6, 28, 12, 41, 23), LastUpdateContactTVItemID = 2 });
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
