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
    public partial class TVFullTextServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ITVFullTextService TVFullTextService { get; set; }
        #endregion Properties

        #region Constructors
        public TVFullTextServiceTest() : base()
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
        public async Task TVFullText_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            TVFullText tvFullText = GetFilledRandomTVFullText("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(255)]
            // [CSSPMinLength(1)]
            // tvFullText.TVPath   (String)
            // -----------------------------------


            tvFullText = null;
            tvFullText = GetFilledRandomTVFullText("TVPath");
            TVFullTextService.Validate(new ValidationContext(tvFullText));
            Assert.True(TVFullTextService.ValidationResults.Count() > 0);
            Assert.True(TVFullTextService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"))).Any());


            tvFullText = null;
            tvFullText = GetFilledRandomTVFullText("");
            tvFullText.TVPath = GetRandomString("", 256);
            TVFullTextService.Validate(new ValidationContext(tvFullText));
            Assert.True(TVFullTextService.ValidationResults.Count() > 0);
            Assert.True(TVFullTextService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVPath", "1", "255"))).Any());

            tvFullText = null;
            tvFullText = GetFilledRandomTVFullText("");
            tvFullText.TVPath = GetRandomString("", 256);
            TVFullTextService.Validate(new ValidationContext(tvFullText));
            Assert.True(TVFullTextService.ValidationResults.Count() > 0);
            Assert.True(TVFullTextService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVPath", "1", "255"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(255)]
            // [CSSPMinLength(1)]
            // tvFullText.FullText   (String)
            // -----------------------------------


            tvFullText = null;
            tvFullText = GetFilledRandomTVFullText("FullText");
            TVFullTextService.Validate(new ValidationContext(tvFullText));
            Assert.True(TVFullTextService.ValidationResults.Count() > 0);
            Assert.True(TVFullTextService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "FullText"))).Any());


            tvFullText = null;
            tvFullText = GetFilledRandomTVFullText("");
            tvFullText.FullText = GetRandomString("", 256);
            TVFullTextService.Validate(new ValidationContext(tvFullText));
            Assert.True(TVFullTextService.ValidationResults.Count() > 0);
            Assert.True(TVFullTextService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FullText", "1", "255"))).Any());

            tvFullText = null;
            tvFullText = GetFilledRandomTVFullText("");
            tvFullText.FullText = GetRandomString("", 256);
            TVFullTextService.Validate(new ValidationContext(tvFullText));
            Assert.True(TVFullTextService.ValidationResults.Count() > 0);
            Assert.True(TVFullTextService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FullText", "1", "255"))).Any());
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
            Services.AddSingleton<ITVFullTextService, TVFullTextService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            TVFullTextService = Provider.GetService<ITVFullTextService>();
            Assert.NotNull(TVFullTextService);

            return await Task.FromResult(true);
        }
        private TVFullText GetFilledRandomTVFullText(string OmitPropName)
        {
            TVFullText tvFullText = new TVFullText();

            if (OmitPropName != "TVPath") tvFullText.TVPath = GetRandomString("", 6);
            if (OmitPropName != "FullText") tvFullText.FullText = GetRandomString("", 6);

            return tvFullText;
        }

        #endregion Functions private
    }
}
