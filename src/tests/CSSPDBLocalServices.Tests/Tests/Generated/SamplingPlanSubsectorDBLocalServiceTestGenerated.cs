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
    public partial class SamplingPlanSubsectorDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ISamplingPlanSubsectorDBLocalService SamplingPlanSubsectorDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private SamplingPlanSubsector samplingPlanSubsector { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocal]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SamplingPlanSubsectorDBLocal_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocal]

        #region Tests Generated [DBLocal] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SamplingPlanSubsectorDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated [DBLocal] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SamplingPlanSubsector_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionSamplingPlanSubsectorList = await SamplingPlanSubsectorDBLocalService.GetSamplingPlanSubsectorList();
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorList.Result).Value);
            List<SamplingPlanSubsector> samplingPlanSubsectorList = (List<SamplingPlanSubsector>)((OkObjectResult)actionSamplingPlanSubsectorList.Result).Value;

            count = samplingPlanSubsectorList.Count();

            SamplingPlanSubsector samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // samplingPlanSubsector.SamplingPlanSubsectorID   (Int32)
            // -----------------------------------

            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            samplingPlanSubsector.SamplingPlanSubsectorID = 0;

            var actionSamplingPlanSubsector = await SamplingPlanSubsectorDBLocalService.Put(samplingPlanSubsector);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsector.Result);

            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            samplingPlanSubsector.SamplingPlanSubsectorID = 10000000;
            actionSamplingPlanSubsector = await SamplingPlanSubsectorDBLocalService.Put(samplingPlanSubsector);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsector.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID", AllowableTVtypeList = )]
            // samplingPlanSubsector.SamplingPlanID   (Int32)
            // -----------------------------------

            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            samplingPlanSubsector.SamplingPlanID = 0;
            actionSamplingPlanSubsector = await SamplingPlanSubsectorDBLocalService.Post(samplingPlanSubsector);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsector.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
            // samplingPlanSubsector.SubsectorTVItemID   (Int32)
            // -----------------------------------

            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            samplingPlanSubsector.SubsectorTVItemID = 0;
            actionSamplingPlanSubsector = await SamplingPlanSubsectorDBLocalService.Post(samplingPlanSubsector);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsector.Result);

            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            samplingPlanSubsector.SubsectorTVItemID = 1;
            actionSamplingPlanSubsector = await SamplingPlanSubsectorDBLocalService.Post(samplingPlanSubsector);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsector.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // samplingPlanSubsector.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            samplingPlanSubsector.LastUpdateDate_UTC = new DateTime();
            actionSamplingPlanSubsector = await SamplingPlanSubsectorDBLocalService.Post(samplingPlanSubsector);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsector.Result);
            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            samplingPlanSubsector.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionSamplingPlanSubsector = await SamplingPlanSubsectorDBLocalService.Post(samplingPlanSubsector);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsector.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // samplingPlanSubsector.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            samplingPlanSubsector.LastUpdateContactTVItemID = 0;
            actionSamplingPlanSubsector = await SamplingPlanSubsectorDBLocalService.Post(samplingPlanSubsector);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsector.Result);

            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            samplingPlanSubsector.LastUpdateContactTVItemID = 1;
            actionSamplingPlanSubsector = await SamplingPlanSubsectorDBLocalService.Post(samplingPlanSubsector);
            Assert.IsType<BadRequestObjectResult>(actionSamplingPlanSubsector.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post SamplingPlanSubsector
            var actionSamplingPlanSubsectorAdded = await SamplingPlanSubsectorDBLocalService.Post(samplingPlanSubsector);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorAdded.Result).Value);
            SamplingPlanSubsector samplingPlanSubsectorAdded = (SamplingPlanSubsector)((OkObjectResult)actionSamplingPlanSubsectorAdded.Result).Value;
            Assert.NotNull(samplingPlanSubsectorAdded);

            // List<SamplingPlanSubsector>
            var actionSamplingPlanSubsectorList = await SamplingPlanSubsectorDBLocalService.GetSamplingPlanSubsectorList();
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorList.Result).Value);
            List<SamplingPlanSubsector> samplingPlanSubsectorList = (List<SamplingPlanSubsector>)((OkObjectResult)actionSamplingPlanSubsectorList.Result).Value;

            int count = ((List<SamplingPlanSubsector>)((OkObjectResult)actionSamplingPlanSubsectorList.Result).Value).Count();
            Assert.True(count > 0);

            // Get SamplingPlanSubsector With SamplingPlanSubsectorID
            var actionSamplingPlanSubsectorGet = await SamplingPlanSubsectorDBLocalService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorGet.Result).Value);
            SamplingPlanSubsector samplingPlanSubsectorGet = (SamplingPlanSubsector)((OkObjectResult)actionSamplingPlanSubsectorGet.Result).Value;
            Assert.NotNull(samplingPlanSubsectorGet);
            Assert.Equal(samplingPlanSubsectorGet.SamplingPlanSubsectorID, samplingPlanSubsectorList[0].SamplingPlanSubsectorID);

            // Put SamplingPlanSubsector
            var actionSamplingPlanSubsectorUpdated = await SamplingPlanSubsectorDBLocalService.Put(samplingPlanSubsector);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorUpdated.Result).Value);
            SamplingPlanSubsector samplingPlanSubsectorUpdated = (SamplingPlanSubsector)((OkObjectResult)actionSamplingPlanSubsectorUpdated.Result).Value;
            Assert.NotNull(samplingPlanSubsectorUpdated);

            // Delete SamplingPlanSubsector
            var actionSamplingPlanSubsectorDeleted = await SamplingPlanSubsectorDBLocalService.Delete(samplingPlanSubsector.SamplingPlanSubsectorID);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionSamplingPlanSubsectorDeleted.Result).Value;
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
            Services.AddSingleton<ISamplingPlanSubsectorDBLocalService, SamplingPlanSubsectorDBLocalService>();

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

            SamplingPlanSubsectorDBLocalService = Provider.GetService<ISamplingPlanSubsectorDBLocalService>();
            Assert.NotNull(SamplingPlanSubsectorDBLocalService);

            return await Task.FromResult(true);
        }
        private SamplingPlanSubsector GetFilledRandomSamplingPlanSubsector(string OmitPropName)
        {
            SamplingPlanSubsector samplingPlanSubsector = new SamplingPlanSubsector();

            if (OmitPropName != "SamplingPlanID") samplingPlanSubsector.SamplingPlanID = 1;
            if (OmitPropName != "SubsectorTVItemID") samplingPlanSubsector.SubsectorTVItemID = 11;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsector.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanSubsector.LastUpdateContactTVItemID = 2;

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
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }


            return samplingPlanSubsector;
        }
        private void CheckSamplingPlanSubsectorFields(List<SamplingPlanSubsector> samplingPlanSubsectorList)
        {
        }

        #endregion Functions private
    }
}
