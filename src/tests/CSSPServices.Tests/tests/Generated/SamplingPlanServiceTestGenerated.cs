/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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
using Xunit;

namespace CSSPServices.Tests
{
    public partial class SamplingPlanServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ISamplingPlanService samplingPlanService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SamplingPlan_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            SamplingPlan samplingPlan = GetFilledRandomSamplingPlan(""); 

            // List<SamplingPlan>
            var actionSamplingPlanList = await samplingPlanService.GetSamplingPlanList();
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanList.Result).Value);
            List<SamplingPlan> samplingPlanList = (List<SamplingPlan>)(((OkObjectResult)actionSamplingPlanList.Result).Value);

            int count = ((List<SamplingPlan>)((OkObjectResult)actionSamplingPlanList.Result).Value).Count();
            Assert.True(count > 0);

            // Add SamplingPlan
            var actionSamplingPlanAdded = await samplingPlanService.Add(samplingPlan);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanAdded.Result).Value);
            SamplingPlan samplingPlanAdded = (SamplingPlan)(((OkObjectResult)actionSamplingPlanAdded.Result).Value);
            Assert.NotNull(samplingPlanAdded);

            // Update SamplingPlan
            var actionSamplingPlanUpdated = await samplingPlanService.Update(samplingPlan);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanUpdated.Result).Value);
            SamplingPlan samplingPlanUpdated = (SamplingPlan)(((OkObjectResult)actionSamplingPlanUpdated.Result).Value);
            Assert.NotNull(samplingPlanUpdated);

            // Delete SamplingPlan
            var actionSamplingPlanDeleted = await samplingPlanService.Delete(samplingPlan);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanDeleted.Result).Value);
            SamplingPlan samplingPlanDeleted = (SamplingPlan)(((OkObjectResult)actionSamplingPlanDeleted.Result).Value);
            Assert.NotNull(samplingPlanDeleted);
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();
        
            Services = new ServiceCollection();
        
            Services.AddSingleton<IConfiguration>(Config);
        
            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);
        
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });
        
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ISamplingPlanService, SamplingPlanService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            samplingPlanService = Provider.GetService<ISamplingPlanService>();
            Assert.NotNull(samplingPlanService);
        
            await samplingPlanService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private SamplingPlan GetFilledRandomSamplingPlan(string OmitPropName)
        {
            SamplingPlan samplingPlan = new SamplingPlan();

            if (OmitPropName != "IsActive") samplingPlan.IsActive = true;
            if (OmitPropName != "SamplingPlanName") samplingPlan.SamplingPlanName = GetRandomString("", 5);
            if (OmitPropName != "ForGroupName") samplingPlan.ForGroupName = GetRandomString("", 5);
            if (OmitPropName != "SampleType") samplingPlan.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "SamplingPlanType") samplingPlan.SamplingPlanType = (SamplingPlanTypeEnum)GetRandomEnumType(typeof(SamplingPlanTypeEnum));
            if (OmitPropName != "LabSheetType") samplingPlan.LabSheetType = (LabSheetTypeEnum)GetRandomEnumType(typeof(LabSheetTypeEnum));
            if (OmitPropName != "ProvinceTVItemID") samplingPlan.ProvinceTVItemID = 6;
            if (OmitPropName != "CreatorTVItemID") samplingPlan.CreatorTVItemID = 2;
            if (OmitPropName != "Year") samplingPlan.Year = GetRandomInt(2000, 2050);
            if (OmitPropName != "AccessCode") samplingPlan.AccessCode = GetRandomString("", 5);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") samplingPlan.DailyDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") samplingPlan.IntertechDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IncludeLaboratoryQAQC") samplingPlan.IncludeLaboratoryQAQC = true;
            if (OmitPropName != "ApprovalCode") samplingPlan.ApprovalCode = GetRandomString("", 5);
            if (OmitPropName != "SamplingPlanFileTVItemID") samplingPlan.SamplingPlanFileTVItemID = 42;
            if (OmitPropName != "AnalyzeMethodDefault") samplingPlan.AnalyzeMethodDefault = (AnalyzeMethodEnum)GetRandomEnumType(typeof(AnalyzeMethodEnum));
            if (OmitPropName != "SampleMatrixDefault") samplingPlan.SampleMatrixDefault = (SampleMatrixEnum)GetRandomEnumType(typeof(SampleMatrixEnum));
            if (OmitPropName != "LaboratoryDefault") samplingPlan.LaboratoryDefault = (LaboratoryEnum)GetRandomEnumType(typeof(LaboratoryEnum));
            if (OmitPropName != "BackupDirectory") samplingPlan.BackupDirectory = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlan.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlan.LastUpdateContactTVItemID = 2;

            return samplingPlan;
        }
        #endregion Functions private
    }
}
