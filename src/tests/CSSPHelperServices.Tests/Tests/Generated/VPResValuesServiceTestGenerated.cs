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
    public partial class VPResValuesServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IVPResValuesService VPResValuesService { get; set; }
        #endregion Properties

        #region Constructors
        public VPResValuesServiceTest() : base()
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
        public async Task VPResValues_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            VPResValues vpResValues = GetFilledRandomVPResValues("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, -1)]
            // vpResValues.Conc   (Int32)
            // -----------------------------------


            vpResValues = null;
            vpResValues = GetFilledRandomVPResValues("");
            vpResValues.Conc = -1;
            VPResValuesService.Validate(new ValidationContext(vpResValues));
            Assert.True(VPResValuesService.ValidationResults.Count() > 0);
            Assert.True(VPResValuesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "Conc", "0"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000)]
            // vpResValues.Dilu   (Double)
            // -----------------------------------


            vpResValues = null;
            vpResValues = GetFilledRandomVPResValues("");
            vpResValues.Dilu = -1.0D;
            VPResValuesService.Validate(new ValidationContext(vpResValues));
            Assert.True(VPResValuesService.ValidationResults.Count() > 0);
            Assert.True(VPResValuesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Dilu", "0", "10000"))).Any());

            vpResValues = null;
            vpResValues = GetFilledRandomVPResValues("");
            vpResValues.Dilu = 10001.0D;
            VPResValuesService.Validate(new ValidationContext(vpResValues));
            Assert.True(VPResValuesService.ValidationResults.Count() > 0);
            Assert.True(VPResValuesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Dilu", "0", "10000"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000)]
            // vpResValues.FarfieldWidth   (Double)
            // -----------------------------------


            vpResValues = null;
            vpResValues = GetFilledRandomVPResValues("");
            vpResValues.FarfieldWidth = -1.0D;
            VPResValuesService.Validate(new ValidationContext(vpResValues));
            Assert.True(VPResValuesService.ValidationResults.Count() > 0);
            Assert.True(VPResValuesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "FarfieldWidth", "0", "10000"))).Any());

            vpResValues = null;
            vpResValues = GetFilledRandomVPResValues("");
            vpResValues.FarfieldWidth = 10001.0D;
            VPResValuesService.Validate(new ValidationContext(vpResValues));
            Assert.True(VPResValuesService.ValidationResults.Count() > 0);
            Assert.True(VPResValuesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "FarfieldWidth", "0", "10000"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100000)]
            // vpResValues.Distance   (Double)
            // -----------------------------------


            vpResValues = null;
            vpResValues = GetFilledRandomVPResValues("");
            vpResValues.Distance = -1.0D;
            VPResValuesService.Validate(new ValidationContext(vpResValues));
            Assert.True(VPResValuesService.ValidationResults.Count() > 0);
            Assert.True(VPResValuesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Distance", "0", "100000"))).Any());

            vpResValues = null;
            vpResValues = GetFilledRandomVPResValues("");
            vpResValues.Distance = 100001.0D;
            VPResValuesService.Validate(new ValidationContext(vpResValues));
            Assert.True(VPResValuesService.ValidationResults.Count() > 0);
            Assert.True(VPResValuesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Distance", "0", "100000"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100000)]
            // vpResValues.TheTime   (Double)
            // -----------------------------------


            vpResValues = null;
            vpResValues = GetFilledRandomVPResValues("");
            vpResValues.TheTime = -1.0D;
            VPResValuesService.Validate(new ValidationContext(vpResValues));
            Assert.True(VPResValuesService.ValidationResults.Count() > 0);
            Assert.True(VPResValuesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TheTime", "0", "100000"))).Any());

            vpResValues = null;
            vpResValues = GetFilledRandomVPResValues("");
            vpResValues.TheTime = 100001.0D;
            VPResValuesService.Validate(new ValidationContext(vpResValues));
            Assert.True(VPResValuesService.ValidationResults.Count() > 0);
            Assert.True(VPResValuesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TheTime", "0", "100000"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // vpResValues.Decay   (Double)
            // -----------------------------------


            vpResValues = null;
            vpResValues = GetFilledRandomVPResValues("");
            vpResValues.Decay = -1.0D;
            VPResValuesService.Validate(new ValidationContext(vpResValues));
            Assert.True(VPResValuesService.ValidationResults.Count() > 0);
            Assert.True(VPResValuesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Decay", "0", "1000"))).Any());

            vpResValues = null;
            vpResValues = GetFilledRandomVPResValues("");
            vpResValues.Decay = 1001.0D;
            VPResValuesService.Validate(new ValidationContext(vpResValues));
            Assert.True(VPResValuesService.ValidationResults.Count() > 0);
            Assert.True(VPResValuesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Decay", "0", "1000"))).Any());
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
            Services.AddSingleton<IVPResValuesService, VPResValuesService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            VPResValuesService = Provider.GetService<IVPResValuesService>();
            Assert.NotNull(VPResValuesService);

            return await Task.FromResult(true);
        }
        private VPResValues GetFilledRandomVPResValues(string OmitPropName)
        {
            VPResValues vpResValues = new VPResValues();

            if (OmitPropName != "Conc") vpResValues.Conc = GetRandomInt(0, 10);
            if (OmitPropName != "Dilu") vpResValues.Dilu = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "FarfieldWidth") vpResValues.FarfieldWidth = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "Distance") vpResValues.Distance = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "TheTime") vpResValues.TheTime = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "Decay") vpResValues.Decay = GetRandomDouble(0.0D, 1000.0D);

            return vpResValues;
        }

        #endregion Functions private
    }
}
