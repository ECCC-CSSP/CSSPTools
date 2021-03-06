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
    public partial class CSSPWQInputAppServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ICSSPWQInputAppService CSSPWQInputAppService { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPWQInputAppServiceTest() : base()
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
        public async Task CSSPWQInputApp_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPWQInputApp csspWQInputApp = GetFilledRandomCSSPWQInputApp("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // [CSSPMinLength(1)]
            // csspWQInputApp.AccessCode   (String)
            // -----------------------------------


            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("AccessCode");
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "AccessCode"))).Any());


            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("");
            csspWQInputApp.AccessCode = GetRandomString("", 101);
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "AccessCode", "1", "100"))).Any());

            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("");
            csspWQInputApp.AccessCode = GetRandomString("", 101);
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "AccessCode", "1", "100"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(4)]
            // [CSSPMinLength(4)]
            // csspWQInputApp.ActiveYear   (String)
            // -----------------------------------


            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("ActiveYear");
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "ActiveYear"))).Any());


            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("");
            csspWQInputApp.ActiveYear = GetRandomString("", 5);
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "ActiveYear", "4", "4"))).Any());

            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("");
            csspWQInputApp.ActiveYear = GetRandomString("", 5);
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "ActiveYear", "4", "4"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100)]
            // csspWQInputApp.DailyDuplicatePrecisionCriteria   (Double)
            // -----------------------------------


            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("");
            csspWQInputApp.DailyDuplicatePrecisionCriteria = -1.0D;
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DailyDuplicatePrecisionCriteria", "0", "100"))).Any());

            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("");
            csspWQInputApp.DailyDuplicatePrecisionCriteria = 101.0D;
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DailyDuplicatePrecisionCriteria", "0", "100"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100)]
            // csspWQInputApp.IntertechDuplicatePrecisionCriteria   (Double)
            // -----------------------------------


            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("");
            csspWQInputApp.IntertechDuplicatePrecisionCriteria = -1.0D;
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "IntertechDuplicatePrecisionCriteria", "0", "100"))).Any());

            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("");
            csspWQInputApp.IntertechDuplicatePrecisionCriteria = 101.0D;
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "IntertechDuplicatePrecisionCriteria", "0", "100"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // csspWQInputApp.IncludeLaboratoryQAQC   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // [CSSPMinLength(1)]
            // csspWQInputApp.ApprovalCode   (String)
            // -----------------------------------


            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("ApprovalCode");
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "ApprovalCode"))).Any());


            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("");
            csspWQInputApp.ApprovalCode = GetRandomString("", 101);
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "ApprovalCode", "1", "100"))).Any());

            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("");
            csspWQInputApp.ApprovalCode = GetRandomString("", 101);
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "ApprovalCode", "1", "100"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // csspWQInputApp.ApprovalDate   (DateTime)
            // -----------------------------------


            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("");
            csspWQInputApp.ApprovalDate = new DateTime();
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "ApprovalDate"))).Any());

            csspWQInputApp = null;
            csspWQInputApp = GetFilledRandomCSSPWQInputApp("");
            csspWQInputApp.ApprovalDate = new DateTime(1979, 1, 1);
            CSSPWQInputAppService.Validate(new ValidationContext(csspWQInputApp));
            Assert.True(CSSPWQInputAppService.ValidationResults.Count() > 0);
            Assert.True(CSSPWQInputAppService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "ApprovalDate", "1980"))).Any());
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
            Services.AddSingleton<ICSSPWQInputAppService, CSSPWQInputAppService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            CSSPWQInputAppService = Provider.GetService<ICSSPWQInputAppService>();
            Assert.NotNull(CSSPWQInputAppService);

            return await Task.FromResult(true);
        }
        private CSSPWQInputApp GetFilledRandomCSSPWQInputApp(string OmitPropName)
        {
            CSSPWQInputApp csspWQInputApp = new CSSPWQInputApp();

            if (OmitPropName != "AccessCode") csspWQInputApp.AccessCode = GetRandomString("", 6);
            if (OmitPropName != "ActiveYear") csspWQInputApp.ActiveYear = GetRandomString("", 4);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") csspWQInputApp.DailyDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") csspWQInputApp.IntertechDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IncludeLaboratoryQAQC") csspWQInputApp.IncludeLaboratoryQAQC = true;
            if (OmitPropName != "ApprovalCode") csspWQInputApp.ApprovalCode = GetRandomString("", 6);
            if (OmitPropName != "ApprovalDate") csspWQInputApp.ApprovalDate = new DateTime(2005, 3, 6);

            return csspWQInputApp;
        }

        #endregion Functions private
    }
}
