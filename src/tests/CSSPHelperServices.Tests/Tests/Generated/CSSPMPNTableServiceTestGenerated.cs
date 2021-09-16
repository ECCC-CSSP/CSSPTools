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
    public partial class CSSPMPNTableServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ICSSPMPNTableService CSSPMPNTableService { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPMPNTableServiceTest() : base()
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
        public async Task CSSPMPNTable_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPMPNTable csspMPNTable = GetFilledRandomCSSPMPNTable("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 5)]
            // csspMPNTable.Tube10   (Int32)
            // -----------------------------------


            csspMPNTable = null;
            csspMPNTable = GetFilledRandomCSSPMPNTable("");
            csspMPNTable.Tube10 = -1;
            CSSPMPNTableService.Validate(new ValidationContext(csspMPNTable));
            Assert.True(CSSPMPNTableService.errRes.ErrList.Count() > 0);
            Assert.True(CSSPMPNTableService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tube10", "0", "5"))).Any());

            csspMPNTable = null;
            csspMPNTable = GetFilledRandomCSSPMPNTable("");
            csspMPNTable.Tube10 = 6;
            CSSPMPNTableService.Validate(new ValidationContext(csspMPNTable));
            Assert.True(CSSPMPNTableService.errRes.ErrList.Count() > 0);
            Assert.True(CSSPMPNTableService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tube10", "0", "5"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 5)]
            // csspMPNTable.Tube1_0   (Int32)
            // -----------------------------------


            csspMPNTable = null;
            csspMPNTable = GetFilledRandomCSSPMPNTable("");
            csspMPNTable.Tube1_0 = -1;
            CSSPMPNTableService.Validate(new ValidationContext(csspMPNTable));
            Assert.True(CSSPMPNTableService.errRes.ErrList.Count() > 0);
            Assert.True(CSSPMPNTableService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tube1_0", "0", "5"))).Any());

            csspMPNTable = null;
            csspMPNTable = GetFilledRandomCSSPMPNTable("");
            csspMPNTable.Tube1_0 = 6;
            CSSPMPNTableService.Validate(new ValidationContext(csspMPNTable));
            Assert.True(CSSPMPNTableService.errRes.ErrList.Count() > 0);
            Assert.True(CSSPMPNTableService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tube1_0", "0", "5"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 5)]
            // csspMPNTable.Tube0_1   (Int32)
            // -----------------------------------


            csspMPNTable = null;
            csspMPNTable = GetFilledRandomCSSPMPNTable("");
            csspMPNTable.Tube0_1 = -1;
            CSSPMPNTableService.Validate(new ValidationContext(csspMPNTable));
            Assert.True(CSSPMPNTableService.errRes.ErrList.Count() > 0);
            Assert.True(CSSPMPNTableService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tube0_1", "0", "5"))).Any());

            csspMPNTable = null;
            csspMPNTable = GetFilledRandomCSSPMPNTable("");
            csspMPNTable.Tube0_1 = 6;
            CSSPMPNTableService.Validate(new ValidationContext(csspMPNTable));
            Assert.True(CSSPMPNTableService.errRes.ErrList.Count() > 0);
            Assert.True(CSSPMPNTableService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tube0_1", "0", "5"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100000000)]
            // csspMPNTable.MPN   (Int32)
            // -----------------------------------


            csspMPNTable = null;
            csspMPNTable = GetFilledRandomCSSPMPNTable("");
            csspMPNTable.MPN = -1;
            CSSPMPNTableService.Validate(new ValidationContext(csspMPNTable));
            Assert.True(CSSPMPNTableService.errRes.ErrList.Count() > 0);
            Assert.True(CSSPMPNTableService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MPN", "0", "100000000"))).Any());

            csspMPNTable = null;
            csspMPNTable = GetFilledRandomCSSPMPNTable("");
            csspMPNTable.MPN = 100000001;
            CSSPMPNTableService.Validate(new ValidationContext(csspMPNTable));
            Assert.True(CSSPMPNTableService.errRes.ErrList.Count() > 0);
            Assert.True(CSSPMPNTableService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MPN", "0", "100000000"))).Any());
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
            Services.AddSingleton<ICSSPMPNTableService, CSSPMPNTableService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            CSSPMPNTableService = Provider.GetService<ICSSPMPNTableService>();
            Assert.NotNull(CSSPMPNTableService);

            return await Task.FromResult(true);
        }
        private CSSPMPNTable GetFilledRandomCSSPMPNTable(string OmitPropName)
        {
            CSSPMPNTable csspMPNTable = new CSSPMPNTable();

            if (OmitPropName != "Tube10") csspMPNTable.Tube10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube1_0") csspMPNTable.Tube1_0 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube0_1") csspMPNTable.Tube0_1 = GetRandomInt(0, 5);
            if (OmitPropName != "MPN") csspMPNTable.MPN = GetRandomInt(0, 100000000);

            return csspMPNTable;
        }

        #endregion Functions private
    }
}
