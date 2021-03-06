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
    public partial class PolyPointServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IPolyPointService PolyPointService { get; set; }
        #endregion Properties

        #region Constructors
        public PolyPointServiceTest() : base()
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
        public async Task PolyPoint_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PolyPoint polyPoint = GetFilledRandomPolyPoint("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-180, 180)]
            // polyPoint.XCoord   (Double)
            // -----------------------------------


            polyPoint = null;
            polyPoint = GetFilledRandomPolyPoint("");
            polyPoint.XCoord = -181.0D;
            PolyPointService.Validate(new ValidationContext(polyPoint));
            Assert.True(PolyPointService.ValidationResults.Count() > 0);
            Assert.True(PolyPointService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "XCoord", "-180", "180"))).Any());

            polyPoint = null;
            polyPoint = GetFilledRandomPolyPoint("");
            polyPoint.XCoord = 181.0D;
            PolyPointService.Validate(new ValidationContext(polyPoint));
            Assert.True(PolyPointService.ValidationResults.Count() > 0);
            Assert.True(PolyPointService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "XCoord", "-180", "180"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-90, 90)]
            // polyPoint.YCoord   (Double)
            // -----------------------------------


            polyPoint = null;
            polyPoint = GetFilledRandomPolyPoint("");
            polyPoint.YCoord = -91.0D;
            PolyPointService.Validate(new ValidationContext(polyPoint));
            Assert.True(PolyPointService.ValidationResults.Count() > 0);
            Assert.True(PolyPointService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "YCoord", "-90", "90"))).Any());

            polyPoint = null;
            polyPoint = GetFilledRandomPolyPoint("");
            polyPoint.YCoord = 91.0D;
            PolyPointService.Validate(new ValidationContext(polyPoint));
            Assert.True(PolyPointService.ValidationResults.Count() > 0);
            Assert.True(PolyPointService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "YCoord", "-90", "90"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-10000, 10000)]
            // polyPoint.Z   (Double)
            // -----------------------------------


            polyPoint = null;
            polyPoint = GetFilledRandomPolyPoint("");
            polyPoint.Z = -10001.0D;
            PolyPointService.Validate(new ValidationContext(polyPoint));
            Assert.True(PolyPointService.ValidationResults.Count() > 0);
            Assert.True(PolyPointService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Z", "-10000", "10000"))).Any());

            polyPoint = null;
            polyPoint = GetFilledRandomPolyPoint("");
            polyPoint.Z = 10001.0D;
            PolyPointService.Validate(new ValidationContext(polyPoint));
            Assert.True(PolyPointService.ValidationResults.Count() > 0);
            Assert.True(PolyPointService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Z", "-10000", "10000"))).Any());
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
            Services.AddSingleton<IPolyPointService, PolyPointService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            PolyPointService = Provider.GetService<IPolyPointService>();
            Assert.NotNull(PolyPointService);

            return await Task.FromResult(true);
        }
        private PolyPoint GetFilledRandomPolyPoint(string OmitPropName)
        {
            PolyPoint polyPoint = new PolyPoint();

            if (OmitPropName != "XCoord") polyPoint.XCoord = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "YCoord") polyPoint.YCoord = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "Z") polyPoint.Z = GetRandomDouble(-10000.0D, 10000.0D);

            return polyPoint;
        }

        #endregion Functions private
    }
}
