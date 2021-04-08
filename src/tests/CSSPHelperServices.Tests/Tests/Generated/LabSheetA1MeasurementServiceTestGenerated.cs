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
    public partial class LabSheetA1MeasurementServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ILabSheetA1MeasurementService LabSheetA1MeasurementService { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetA1MeasurementServiceTest() : base()
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
        public async Task LabSheetA1Measurement_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LabSheetA1Measurement labSheetA1Measurement = GetFilledRandomLabSheetA1Measurement("");


            // -----------------------------------
            // Is NOT Nullable
            // labSheetA1Measurement.Site   (String)
            // -----------------------------------


            labSheetA1Measurement = null;
            labSheetA1Measurement = GetFilledRandomLabSheetA1Measurement("Site");
            LabSheetA1MeasurementService.Validate(new ValidationContext(labSheetA1Measurement));
            Assert.True(LabSheetA1MeasurementService.ValidationResults.Count() > 0);
            Assert.True(LabSheetA1MeasurementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "Site"))).Any());


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // labSheetA1Measurement.TVItemID   (Int32)
            // -----------------------------------


            labSheetA1Measurement = null;
            labSheetA1Measurement = GetFilledRandomLabSheetA1Measurement("");
            labSheetA1Measurement.TVItemID = 0;
            LabSheetA1MeasurementService.Validate(new ValidationContext(labSheetA1Measurement));
            Assert.True(LabSheetA1MeasurementService.ValidationResults.Count() > 0);
            Assert.True(LabSheetA1MeasurementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "TVItemID", "1"))).Any());

            // -----------------------------------
            // Is Nullable
            // labSheetA1Measurement.Time   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // labSheetA1Measurement.MPN   (Int32)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // labSheetA1Measurement.Tube10   (Int32)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // labSheetA1Measurement.Tube1_0   (Int32)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // labSheetA1Measurement.Tube0_1   (Int32)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // labSheetA1Measurement.Salinity   (Double)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // labSheetA1Measurement.Temperature   (Double)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // labSheetA1Measurement.ProcessedBy   (String)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // labSheetA1Measurement.SampleType   (SampleTypeEnum)
            // -----------------------------------


            labSheetA1Measurement = null;
            labSheetA1Measurement = GetFilledRandomLabSheetA1Measurement("");
            labSheetA1Measurement.SampleType = (SampleTypeEnum)1000000;
            LabSheetA1MeasurementService.Validate(new ValidationContext(labSheetA1Measurement));
            Assert.True(LabSheetA1MeasurementService.ValidationResults.Count() > 0);
            Assert.True(LabSheetA1MeasurementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "SampleType"))).Any());


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100000)]
            // labSheetA1Measurement.SiteComment   (String)
            // -----------------------------------


            labSheetA1Measurement = null;
            labSheetA1Measurement = GetFilledRandomLabSheetA1Measurement("SiteComment");
            LabSheetA1MeasurementService.Validate(new ValidationContext(labSheetA1Measurement));
            Assert.True(LabSheetA1MeasurementService.ValidationResults.Count() > 0);
            Assert.True(LabSheetA1MeasurementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "SiteComment"))).Any());


            labSheetA1Measurement = null;
            labSheetA1Measurement = GetFilledRandomLabSheetA1Measurement("");
            labSheetA1Measurement.SiteComment = GetRandomString("", 100001);
            LabSheetA1MeasurementService.Validate(new ValidationContext(labSheetA1Measurement));
            Assert.True(LabSheetA1MeasurementService.ValidationResults.Count() > 0);
            Assert.True(LabSheetA1MeasurementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SiteComment", "100000"))).Any());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // labSheetA1Measurement.SampleTypeText   (String)
            // -----------------------------------


            labSheetA1Measurement = null;
            labSheetA1Measurement = GetFilledRandomLabSheetA1Measurement("");
            labSheetA1Measurement.SampleTypeText = GetRandomString("", 101);
            LabSheetA1MeasurementService.Validate(new ValidationContext(labSheetA1Measurement));
            Assert.True(LabSheetA1MeasurementService.ValidationResults.Count() > 0);
            Assert.True(LabSheetA1MeasurementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SampleTypeText", "100"))).Any());
        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_CSSPDBServicestests.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILabSheetA1MeasurementService, LabSheetA1MeasurementService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            LabSheetA1MeasurementService = Provider.GetService<ILabSheetA1MeasurementService>();
            Assert.NotNull(LabSheetA1MeasurementService);

            return await Task.FromResult(true);
        }
        private LabSheetA1Measurement GetFilledRandomLabSheetA1Measurement(string OmitPropName)
        {
            LabSheetA1Measurement labSheetA1Measurement = new LabSheetA1Measurement();

            if (OmitPropName != "Site") labSheetA1Measurement.Site = GetRandomString("", 20);
            if (OmitPropName != "TVItemID") labSheetA1Measurement.TVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Time") labSheetA1Measurement.Time = new DateTime(2005, 3, 6);
            // should implement a Range for the property MPN and type LabSheetA1Measurement
            // should implement a Range for the property Tube10 and type LabSheetA1Measurement
            // should implement a Range for the property Tube1_0 and type LabSheetA1Measurement
            // should implement a Range for the property Tube0_1 and type LabSheetA1Measurement
            // should implement a Range for the property Salinity and type LabSheetA1Measurement
            // should implement a Range for the property Temperature and type LabSheetA1Measurement
            if (OmitPropName != "ProcessedBy") labSheetA1Measurement.ProcessedBy = GetRandomString("", 20);
            if (OmitPropName != "SampleType") labSheetA1Measurement.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "SiteComment") labSheetA1Measurement.SiteComment = GetRandomString("", 5);
            if (OmitPropName != "SampleTypeText") labSheetA1Measurement.SampleTypeText = GetRandomString("", 5);

            return labSheetA1Measurement;
        }

        #endregion Functions private
    }
}
