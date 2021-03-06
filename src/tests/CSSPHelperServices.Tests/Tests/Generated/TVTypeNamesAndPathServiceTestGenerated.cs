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
    public partial class TVTypeNamesAndPathServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ITVTypeNamesAndPathService TVTypeNamesAndPathService { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeNamesAndPathServiceTest() : base()
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
        public async Task TVTypeNamesAndPath_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            TVTypeNamesAndPath tvTypeNamesAndPath = GetFilledRandomTVTypeNamesAndPath("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(255)]
            // [CSSPMinLength(1)]
            // tvTypeNamesAndPath.TVTypeName   (String)
            // -----------------------------------


            tvTypeNamesAndPath = null;
            tvTypeNamesAndPath = GetFilledRandomTVTypeNamesAndPath("TVTypeName");
            TVTypeNamesAndPathService.Validate(new ValidationContext(tvTypeNamesAndPath));
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Count() > 0);
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVTypeName"))).Any());


            tvTypeNamesAndPath = null;
            tvTypeNamesAndPath = GetFilledRandomTVTypeNamesAndPath("");
            tvTypeNamesAndPath.TVTypeName = GetRandomString("", 256);
            TVTypeNamesAndPathService.Validate(new ValidationContext(tvTypeNamesAndPath));
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Count() > 0);
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVTypeName", "1", "255"))).Any());

            tvTypeNamesAndPath = null;
            tvTypeNamesAndPath = GetFilledRandomTVTypeNamesAndPath("");
            tvTypeNamesAndPath.TVTypeName = GetRandomString("", 256);
            TVTypeNamesAndPathService.Validate(new ValidationContext(tvTypeNamesAndPath));
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Count() > 0);
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVTypeName", "1", "255"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // tvTypeNamesAndPath.Index   (Int32)
            // -----------------------------------


            tvTypeNamesAndPath = null;
            tvTypeNamesAndPath = GetFilledRandomTVTypeNamesAndPath("");
            tvTypeNamesAndPath.Index = 0;
            TVTypeNamesAndPathService.Validate(new ValidationContext(tvTypeNamesAndPath));
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Count() > 0);
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "Index", "1"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(255)]
            // [CSSPMinLength(1)]
            // tvTypeNamesAndPath.TVPath   (String)
            // -----------------------------------


            tvTypeNamesAndPath = null;
            tvTypeNamesAndPath = GetFilledRandomTVTypeNamesAndPath("TVPath");
            TVTypeNamesAndPathService.Validate(new ValidationContext(tvTypeNamesAndPath));
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Count() > 0);
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"))).Any());


            tvTypeNamesAndPath = null;
            tvTypeNamesAndPath = GetFilledRandomTVTypeNamesAndPath("");
            tvTypeNamesAndPath.TVPath = GetRandomString("", 256);
            TVTypeNamesAndPathService.Validate(new ValidationContext(tvTypeNamesAndPath));
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Count() > 0);
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVPath", "1", "255"))).Any());

            tvTypeNamesAndPath = null;
            tvTypeNamesAndPath = GetFilledRandomTVTypeNamesAndPath("");
            tvTypeNamesAndPath.TVPath = GetRandomString("", 256);
            TVTypeNamesAndPathService.Validate(new ValidationContext(tvTypeNamesAndPath));
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Count() > 0);
            Assert.True(TVTypeNamesAndPathService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVPath", "1", "255"))).Any());
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
            Services.AddSingleton<ITVTypeNamesAndPathService, TVTypeNamesAndPathService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            TVTypeNamesAndPathService = Provider.GetService<ITVTypeNamesAndPathService>();
            Assert.NotNull(TVTypeNamesAndPathService);

            return await Task.FromResult(true);
        }
        private TVTypeNamesAndPath GetFilledRandomTVTypeNamesAndPath(string OmitPropName)
        {
            TVTypeNamesAndPath tvTypeNamesAndPath = new TVTypeNamesAndPath();

            if (OmitPropName != "TVTypeName") tvTypeNamesAndPath.TVTypeName = GetRandomString("", 6);
            if (OmitPropName != "Index") tvTypeNamesAndPath.Index = GetRandomInt(1, 11);
            if (OmitPropName != "TVPath") tvTypeNamesAndPath.TVPath = GetRandomString("", 6);

            return tvTypeNamesAndPath;
        }

        #endregion Functions private
    }
}
