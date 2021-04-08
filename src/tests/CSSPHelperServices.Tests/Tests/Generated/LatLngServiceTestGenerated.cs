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
    public partial class LatLngServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ILatLngService LatLngService { get; set; }
        #endregion Properties

        #region Constructors
        public LatLngServiceTest() : base()
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
        public async Task LatLng_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LatLng latLng = GetFilledRandomLatLng("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-180, 180)]
            // latLng.Lat   (Double)
            // -----------------------------------


            latLng = null;
            latLng = GetFilledRandomLatLng("");
            latLng.Lat = -181.0D;
            LatLngService.Validate(new ValidationContext(latLng));
            Assert.True(LatLngService.ValidationResults.Count() > 0);
            Assert.True(LatLngService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lat", "-180", "180"))).Any());

            latLng = null;
            latLng = GetFilledRandomLatLng("");
            latLng.Lat = 181.0D;
            LatLngService.Validate(new ValidationContext(latLng));
            Assert.True(LatLngService.ValidationResults.Count() > 0);
            Assert.True(LatLngService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lat", "-180", "180"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-90, 90)]
            // latLng.Lng   (Double)
            // -----------------------------------


            latLng = null;
            latLng = GetFilledRandomLatLng("");
            latLng.Lng = -91.0D;
            LatLngService.Validate(new ValidationContext(latLng));
            Assert.True(LatLngService.ValidationResults.Count() > 0);
            Assert.True(LatLngService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lng", "-90", "90"))).Any());

            latLng = null;
            latLng = GetFilledRandomLatLng("");
            latLng.Lng = 91.0D;
            LatLngService.Validate(new ValidationContext(latLng));
            Assert.True(LatLngService.ValidationResults.Count() > 0);
            Assert.True(LatLngService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lng", "-90", "90"))).Any());
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
            Services.AddSingleton<ILatLngService, LatLngService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            LatLngService = Provider.GetService<ILatLngService>();
            Assert.NotNull(LatLngService);

            return await Task.FromResult(true);
        }
        private LatLng GetFilledRandomLatLng(string OmitPropName)
        {
            LatLng latLng = new LatLng();

            if (OmitPropName != "Lat") latLng.Lat = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "Lng") latLng.Lng = GetRandomDouble(-90.0D, 90.0D);

            return latLng;
        }

        #endregion Functions private
    }
}
