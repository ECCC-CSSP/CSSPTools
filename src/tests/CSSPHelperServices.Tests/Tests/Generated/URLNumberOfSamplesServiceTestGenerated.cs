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
    public partial class URLNumberOfSamplesServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IURLNumberOfSamplesService URLNumberOfSamplesService { get; set; }
        #endregion Properties

        #region Constructors
        public URLNumberOfSamplesServiceTest() : base()
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
        public async Task URLNumberOfSamples_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            URLNumberOfSamples uRLNumberOfSamples = GetFilledRandomURLNumberOfSamples("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(255)]
            // [CSSPMinLength(1)]
            // uRLNumberOfSamples.url   (String)
            // -----------------------------------


            uRLNumberOfSamples = null;
            uRLNumberOfSamples = GetFilledRandomURLNumberOfSamples("url");
            URLNumberOfSamplesService.Validate(new ValidationContext(uRLNumberOfSamples));
            Assert.True(URLNumberOfSamplesService.ValidationResults.Count() > 0);
            Assert.True(URLNumberOfSamplesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "url"))).Any());


            uRLNumberOfSamples = null;
            uRLNumberOfSamples = GetFilledRandomURLNumberOfSamples("");
            uRLNumberOfSamples.url = GetRandomString("", 256);
            URLNumberOfSamplesService.Validate(new ValidationContext(uRLNumberOfSamples));
            Assert.True(URLNumberOfSamplesService.ValidationResults.Count() > 0);
            Assert.True(URLNumberOfSamplesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "url", "1", "255"))).Any());

            uRLNumberOfSamples = null;
            uRLNumberOfSamples = GetFilledRandomURLNumberOfSamples("");
            uRLNumberOfSamples.url = GetRandomString("", 256);
            URLNumberOfSamplesService.Validate(new ValidationContext(uRLNumberOfSamples));
            Assert.True(URLNumberOfSamplesService.ValidationResults.Count() > 0);
            Assert.True(URLNumberOfSamplesService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "url", "1", "255"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // uRLNumberOfSamples.NumberOfSamples   (Int32)
            // -----------------------------------

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
            Services.AddSingleton<IURLNumberOfSamplesService, URLNumberOfSamplesService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            URLNumberOfSamplesService = Provider.GetService<IURLNumberOfSamplesService>();
            Assert.NotNull(URLNumberOfSamplesService);

            return await Task.FromResult(true);
        }
        private URLNumberOfSamples GetFilledRandomURLNumberOfSamples(string OmitPropName)
        {
            URLNumberOfSamples uRLNumberOfSamples = new URLNumberOfSamples();

            if (OmitPropName != "url") uRLNumberOfSamples.url = GetRandomString("", 6);
            // should implement a Range for the property NumberOfSamples and type URLNumberOfSamples

            return uRLNumberOfSamples;
        }

        #endregion Functions private
    }
}
