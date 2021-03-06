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
    public partial class LastUpdateAndTVTextServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ILastUpdateAndTVTextService LastUpdateAndTVTextService { get; set; }
        #endregion Properties

        #region Constructors
        public LastUpdateAndTVTextServiceTest() : base()
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
        public async Task LastUpdateAndTVText_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LastUpdateAndTVText lastUpdateAndTVText = GetFilledRandomLastUpdateAndTVText("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // lastUpdateAndTVText.LastUpdateAndTVTextDate_UTC   (DateTime)
            // -----------------------------------


            lastUpdateAndTVText = null;
            lastUpdateAndTVText = GetFilledRandomLastUpdateAndTVText("");
            lastUpdateAndTVText.LastUpdateAndTVTextDate_UTC = new DateTime();
            LastUpdateAndTVTextService.Validate(new ValidationContext(lastUpdateAndTVText));
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Count() > 0);
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateAndTVTextDate_UTC"))).Any());

            lastUpdateAndTVText = null;
            lastUpdateAndTVText = GetFilledRandomLastUpdateAndTVText("");
            lastUpdateAndTVText.LastUpdateAndTVTextDate_UTC = new DateTime(1979, 1, 1);
            LastUpdateAndTVTextService.Validate(new ValidationContext(lastUpdateAndTVText));
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Count() > 0);
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateAndTVTextDate_UTC", "1980"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // lastUpdateAndTVText.LastUpdateDate_Local   (DateTime)
            // -----------------------------------


            lastUpdateAndTVText = null;
            lastUpdateAndTVText = GetFilledRandomLastUpdateAndTVText("");
            lastUpdateAndTVText.LastUpdateDate_Local = new DateTime();
            LastUpdateAndTVTextService.Validate(new ValidationContext(lastUpdateAndTVText));
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Count() > 0);
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_Local"))).Any());

            lastUpdateAndTVText = null;
            lastUpdateAndTVText = GetFilledRandomLastUpdateAndTVText("");
            lastUpdateAndTVText.LastUpdateDate_Local = new DateTime(1979, 1, 1);
            LastUpdateAndTVTextService.Validate(new ValidationContext(lastUpdateAndTVText));
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Count() > 0);
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_Local", "1980"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(200)]
            // [CSSPMinLength(1)]
            // lastUpdateAndTVText.TVText   (String)
            // -----------------------------------


            lastUpdateAndTVText = null;
            lastUpdateAndTVText = GetFilledRandomLastUpdateAndTVText("TVText");
            LastUpdateAndTVTextService.Validate(new ValidationContext(lastUpdateAndTVText));
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Count() > 0);
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVText"))).Any());


            lastUpdateAndTVText = null;
            lastUpdateAndTVText = GetFilledRandomLastUpdateAndTVText("");
            lastUpdateAndTVText.TVText = GetRandomString("", 201);
            LastUpdateAndTVTextService.Validate(new ValidationContext(lastUpdateAndTVText));
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Count() > 0);
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVText", "1", "200"))).Any());

            lastUpdateAndTVText = null;
            lastUpdateAndTVText = GetFilledRandomLastUpdateAndTVText("");
            lastUpdateAndTVText.TVText = GetRandomString("", 201);
            LastUpdateAndTVTextService.Validate(new ValidationContext(lastUpdateAndTVText));
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Count() > 0);
            Assert.True(LastUpdateAndTVTextService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVText", "1", "200"))).Any());
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
            Services.AddSingleton<ILastUpdateAndTVTextService, LastUpdateAndTVTextService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            LastUpdateAndTVTextService = Provider.GetService<ILastUpdateAndTVTextService>();
            Assert.NotNull(LastUpdateAndTVTextService);

            return await Task.FromResult(true);
        }
        private LastUpdateAndTVText GetFilledRandomLastUpdateAndTVText(string OmitPropName)
        {
            LastUpdateAndTVText lastUpdateAndTVText = new LastUpdateAndTVText();

            if (OmitPropName != "LastUpdateAndTVTextDate_UTC") lastUpdateAndTVText.LastUpdateAndTVTextDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateDate_Local") lastUpdateAndTVText.LastUpdateDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "TVText") lastUpdateAndTVText.TVText = GetRandomString("", 6);

            return lastUpdateAndTVText;
        }

        #endregion Functions private
    }
}
