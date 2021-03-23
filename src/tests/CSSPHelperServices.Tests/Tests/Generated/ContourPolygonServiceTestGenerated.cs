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
    public partial class ContourPolygonServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IContourPolygonService ContourPolygonService { get; set; }
        #endregion Properties

        #region Constructors
        public ContourPolygonServiceTest() : base()
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
        public async Task ContourPolygon_Properties_Test(string culture)
        {
            List<ValidationResult> ValidationResultList = new List<ValidationResult>();
            IEnumerable<ValidationResult> validationResults;
            Assert.True(await Setup(culture));



            ContourPolygon contourPolygon = GetFilledRandomContourPolygon("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, -1)]
            // contourPolygon.ContourValue   (Double)
            // -----------------------------------


            contourPolygon = null;
            contourPolygon = GetFilledRandomContourPolygon("");
            contourPolygon.ContourValue = -1.0D;
            validationResults = ContourPolygonService.Validate(new ValidationContext(contourPolygon));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "ContourValue", "0"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, 100)]
            // contourPolygon.Layer   (Int32)
            // -----------------------------------


            contourPolygon = null;
            contourPolygon = GetFilledRandomContourPolygon("");
            contourPolygon.Layer = 0;
            validationResults = ContourPolygonService.Validate(new ValidationContext(contourPolygon));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Layer", "1", "100"))).Any());

            contourPolygon = null;
            contourPolygon = GetFilledRandomContourPolygon("");
            contourPolygon.Layer = 101;
            validationResults = ContourPolygonService.Validate(new ValidationContext(contourPolygon));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Layer", "1", "100"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, 10000)]
            // contourPolygon.Depth_m   (Double)
            // -----------------------------------


            contourPolygon = null;
            contourPolygon = GetFilledRandomContourPolygon("");
            contourPolygon.Depth_m = 0.0D;
            validationResults = ContourPolygonService.Validate(new ValidationContext(contourPolygon));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Depth_m", "1", "10000"))).Any());

            contourPolygon = null;
            contourPolygon = GetFilledRandomContourPolygon("");
            contourPolygon.Depth_m = 10001.0D;
            validationResults = ContourPolygonService.Validate(new ValidationContext(contourPolygon));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Depth_m", "1", "10000"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // contourPolygon.ContourNodeList   (Node)
            // -----------------------------------

            //CSSPError: Type not implemented [ContourNodeList]

            //CSSPError: Type not implemented [ContourNodeList]

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
            Services.AddSingleton<IContourPolygonService, ContourPolygonService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            ContourPolygonService = Provider.GetService<IContourPolygonService>();
            Assert.NotNull(ContourPolygonService);

            return await Task.FromResult(true);
        }
        private ContourPolygon GetFilledRandomContourPolygon(string OmitPropName)
        {
            ContourPolygon contourPolygon = new ContourPolygon();

            if (OmitPropName != "ContourValue") contourPolygon.ContourValue = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Layer") contourPolygon.Layer = GetRandomInt(1, 100);
            if (OmitPropName != "Depth_m") contourPolygon.Depth_m = GetRandomDouble(1.0D, 10000.0D);
            //CSSPError: property [ContourNodeList] and type [ContourPolygon] is  not implemented

            return contourPolygon;
        }

        #endregion Functions private
    }
}
