/* Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPHelperServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPHelperModels;
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
using CSSPHelperServices.Tests;

namespace CSSPHelperServices.Tests
{
    [Collection("Sequential")]
    public partial class SamplingPlanAndFilesLabSheetCountServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ISamplingPlanAndFilesLabSheetCountService SamplingPlanAndFilesLabSheetCountService { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanAndFilesLabSheetCountServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructors
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskParameter_Constructor_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(enums);
        }
        #endregion Tests Generated Constructors

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SamplingPlanAndFilesLabSheetCount_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SamplingPlanAndFilesLabSheetCount samplingPlanAndFilesLabSheetCount = GetFilledRandomSamplingPlanAndFilesLabSheetCount("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, -1)]
            // samplingPlanAndFilesLabSheetCount.LabSheetHistoryCount   (Int32)
            // -----------------------------------


            samplingPlanAndFilesLabSheetCount = null;
            samplingPlanAndFilesLabSheetCount = GetFilledRandomSamplingPlanAndFilesLabSheetCount("");
            samplingPlanAndFilesLabSheetCount.LabSheetHistoryCount = -1;
            SamplingPlanAndFilesLabSheetCountService.Validate(new ValidationContext(samplingPlanAndFilesLabSheetCount));
            Assert.True(SamplingPlanAndFilesLabSheetCountService.ValidationResults.Count() > 0);
            Assert.True(SamplingPlanAndFilesLabSheetCountService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "LabSheetHistoryCount", "0"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, -1)]
            // samplingPlanAndFilesLabSheetCount.LabSheetTransferredCount   (Int32)
            // -----------------------------------


            samplingPlanAndFilesLabSheetCount = null;
            samplingPlanAndFilesLabSheetCount = GetFilledRandomSamplingPlanAndFilesLabSheetCount("");
            samplingPlanAndFilesLabSheetCount.LabSheetTransferredCount = -1;
            SamplingPlanAndFilesLabSheetCountService.Validate(new ValidationContext(samplingPlanAndFilesLabSheetCount));
            Assert.True(SamplingPlanAndFilesLabSheetCountService.ValidationResults.Count() > 0);
            Assert.True(SamplingPlanAndFilesLabSheetCountService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "LabSheetTransferredCount", "0"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // samplingPlanAndFilesLabSheetCount.SamplingPlan   (SamplingPlan)
            // -----------------------------------

            //CSSPError: Type not implemented [SamplingPlan]

            //CSSPError: Type not implemented [SamplingPlan]


            // -----------------------------------
            // Is NOT Nullable
            // samplingPlanAndFilesLabSheetCount.TVFileSamplingPlanFileTXT   (TVFile)
            // -----------------------------------

            //CSSPError: Type not implemented [TVFileSamplingPlanFileTXT]

            //CSSPError: Type not implemented [TVFileSamplingPlanFileTXT]

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_cssphelperservicestests.json")
               .AddUserSecrets("a79b4a81-ba75-4dfc-8d95-46259f73f055")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ISamplingPlanAndFilesLabSheetCountService, SamplingPlanAndFilesLabSheetCountService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            SamplingPlanAndFilesLabSheetCountService = Provider.GetService<ISamplingPlanAndFilesLabSheetCountService>();
            Assert.NotNull(SamplingPlanAndFilesLabSheetCountService);

            return await Task.FromResult(true);
        }
        private SamplingPlanAndFilesLabSheetCount GetFilledRandomSamplingPlanAndFilesLabSheetCount(string OmitPropName)
        {
            SamplingPlanAndFilesLabSheetCount samplingPlanAndFilesLabSheetCount = new SamplingPlanAndFilesLabSheetCount();

            if (OmitPropName != "LabSheetHistoryCount") samplingPlanAndFilesLabSheetCount.LabSheetHistoryCount = GetRandomInt(0, 10);
            if (OmitPropName != "LabSheetTransferredCount") samplingPlanAndFilesLabSheetCount.LabSheetTransferredCount = GetRandomInt(0, 10);
            //CSSPError: property [SamplingPlan] and type [SamplingPlanAndFilesLabSheetCount] is  not implemented
            //CSSPError: property [TVFileSamplingPlanFileTXT] and type [SamplingPlanAndFilesLabSheetCount] is  not implemented

            return samplingPlanAndFilesLabSheetCount;
        }

        #endregion Functions private
    }
}
