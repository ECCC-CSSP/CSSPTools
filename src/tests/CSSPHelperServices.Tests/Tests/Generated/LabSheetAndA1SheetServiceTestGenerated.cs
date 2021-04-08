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
    public partial class LabSheetAndA1SheetServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ILabSheetAndA1SheetService LabSheetAndA1SheetService { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetAndA1SheetServiceTest() : base()
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
        public async Task LabSheetAndA1Sheet_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LabSheetAndA1Sheet labSheetAndA1Sheet = GetFilledRandomLabSheetAndA1Sheet("");


            // -----------------------------------
            // Is NOT Nullable
            // labSheetAndA1Sheet.LabSheet   (LabSheet)
            // -----------------------------------

            //CSSPError: Type not implemented [LabSheet]

            //CSSPError: Type not implemented [LabSheet]


            // -----------------------------------
            // Is NOT Nullable
            // labSheetAndA1Sheet.LabSheetA1Sheet   (LabSheetA1Sheet)
            // -----------------------------------

            //CSSPError: Type not implemented [LabSheetA1Sheet]

            //CSSPError: Type not implemented [LabSheetA1Sheet]

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
            Services.AddSingleton<ILabSheetAndA1SheetService, LabSheetAndA1SheetService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            LabSheetAndA1SheetService = Provider.GetService<ILabSheetAndA1SheetService>();
            Assert.NotNull(LabSheetAndA1SheetService);

            return await Task.FromResult(true);
        }
        private LabSheetAndA1Sheet GetFilledRandomLabSheetAndA1Sheet(string OmitPropName)
        {
            LabSheetAndA1Sheet labSheetAndA1Sheet = new LabSheetAndA1Sheet();

            //CSSPError: property [LabSheet] and type [LabSheetAndA1Sheet] is  not implemented
            //CSSPError: property [LabSheetA1Sheet] and type [LabSheetAndA1Sheet] is  not implemented

            return labSheetAndA1Sheet;
        }

        #endregion Functions private
    }
}
