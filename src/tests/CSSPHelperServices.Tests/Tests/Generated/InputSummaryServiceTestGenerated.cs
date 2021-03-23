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
    public partial class InputSummaryServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IInputSummaryService InputSummaryService { get; set; }
        #endregion Properties

        #region Constructors
        public InputSummaryServiceTest() : base()
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
        public async Task InputSummary_Properties_Test(string culture)
        {
            List<ValidationResult> ValidationResultList = new List<ValidationResult>();
            IEnumerable<ValidationResult> validationResults;
            Assert.True(await Setup(culture));



            InputSummary inputSummary = GetFilledRandomInputSummary("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(1000000)]
            // inputSummary.Summary   (String)
            // -----------------------------------


            inputSummary = null;
            inputSummary = GetFilledRandomInputSummary("Summary");
            validationResults = InputSummaryService.Validate(new ValidationContext(inputSummary));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "Summary"))).Any());


            inputSummary = null;
            inputSummary = GetFilledRandomInputSummary("");
            inputSummary.Summary = GetRandomString("", 1000001);
            validationResults = InputSummaryService.Validate(new ValidationContext(inputSummary));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Summary", "1000000"))).Any());
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
            Services.AddSingleton<IInputSummaryService, InputSummaryService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            InputSummaryService = Provider.GetService<IInputSummaryService>();
            Assert.NotNull(InputSummaryService);

            return await Task.FromResult(true);
        }
        private InputSummary GetFilledRandomInputSummary(string OmitPropName)
        {
            InputSummary inputSummary = new InputSummary();

            if (OmitPropName != "Summary") inputSummary.Summary = GetRandomString("", 5);

            return inputSummary;
        }

        #endregion Functions private
    }
}
