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
    public partial class DataPathOfTideServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IDataPathOfTideService DataPathOfTideService { get; set; }
        #endregion Properties

        #region Constructors
        public DataPathOfTideServiceTest() : base()
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
        public async Task DataPathOfTide_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DataPathOfTide dataPathOfTide = GetFilledRandomDataPathOfTide("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(200)]
            // [CSSPMinLength(1)]
            // dataPathOfTide.Text   (String)
            // -----------------------------------


            dataPathOfTide = null;
            dataPathOfTide = GetFilledRandomDataPathOfTide("Text");
            DataPathOfTideService.Validate(new ValidationContext(dataPathOfTide));
            Assert.True(DataPathOfTideService.ValidationResults.Count() > 0);
            Assert.True(DataPathOfTideService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "Text"))).Any());


            dataPathOfTide = null;
            dataPathOfTide = GetFilledRandomDataPathOfTide("");
            dataPathOfTide.Text = GetRandomString("", 201);
            DataPathOfTideService.Validate(new ValidationContext(dataPathOfTide));
            Assert.True(DataPathOfTideService.ValidationResults.Count() > 0);
            Assert.True(DataPathOfTideService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Text", "1", "200"))).Any());

            dataPathOfTide = null;
            dataPathOfTide = GetFilledRandomDataPathOfTide("");
            dataPathOfTide.Text = GetRandomString("", 201);
            DataPathOfTideService.Validate(new ValidationContext(dataPathOfTide));
            Assert.True(DataPathOfTideService.ValidationResults.Count() > 0);
            Assert.True(DataPathOfTideService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Text", "1", "200"))).Any());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // dataPathOfTide.WebTideDataSet   (WebTideDataSetEnum)
            // -----------------------------------


            dataPathOfTide = null;
            dataPathOfTide = GetFilledRandomDataPathOfTide("");
            dataPathOfTide.WebTideDataSet = (WebTideDataSetEnum)1000000;
            DataPathOfTideService.Validate(new ValidationContext(dataPathOfTide));
            Assert.True(DataPathOfTideService.ValidationResults.Count() > 0);
            Assert.True(DataPathOfTideService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "WebTideDataSet"))).Any());


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // dataPathOfTide.WebTideDataSetText   (String)
            // -----------------------------------


            dataPathOfTide = null;
            dataPathOfTide = GetFilledRandomDataPathOfTide("");
            dataPathOfTide.WebTideDataSetText = GetRandomString("", 101);
            DataPathOfTideService.Validate(new ValidationContext(dataPathOfTide));
            Assert.True(DataPathOfTideService.ValidationResults.Count() > 0);
            Assert.True(DataPathOfTideService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "WebTideDataSetText", "100"))).Any());
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
            Services.AddSingleton<IDataPathOfTideService, DataPathOfTideService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            DataPathOfTideService = Provider.GetService<IDataPathOfTideService>();
            Assert.NotNull(DataPathOfTideService);

            return await Task.FromResult(true);
        }
        private DataPathOfTide GetFilledRandomDataPathOfTide(string OmitPropName)
        {
            DataPathOfTide dataPathOfTide = new DataPathOfTide();

            if (OmitPropName != "Text") dataPathOfTide.Text = GetRandomString("", 6);
            if (OmitPropName != "WebTideDataSet") dataPathOfTide.WebTideDataSet = (WebTideDataSetEnum)GetRandomEnumType(typeof(WebTideDataSetEnum));
            if (OmitPropName != "WebTideDataSetText") dataPathOfTide.WebTideDataSetText = GetRandomString("", 5);

            return dataPathOfTide;
        }

        #endregion Functions private
    }
}
