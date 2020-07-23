/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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

namespace CSSPServices.Tests
{
    public partial class LabSheetAndA1SheetServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILabSheetAndA1SheetService LabSheetAndA1SheetService { get; set; }
        private LabSheetAndA1Sheet labSheetAndA1Sheet { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetAndA1SheetServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Basic Test Not Mapped
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task LabSheetAndA1SheetService_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            labSheetAndA1Sheet = GetFilledRandomLabSheetAndA1Sheet("");

            List<ValidationResult> ValidationResultsList = LabSheetAndA1SheetService.Validate(new ValidationContext(labSheetAndA1Sheet)).ToList();
            Assert.True(ValidationResultsList.Count == 0);
        }
        #endregion Tests Generated Basic Test Not Mapped

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservices.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILabSheetAndA1SheetService, LabSheetAndA1SheetService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

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
        private void CheckLabSheetAndA1SheetFields(List<LabSheetAndA1Sheet> labSheetAndA1SheetList)
        {
        }
        #endregion Functions private
    }
}
