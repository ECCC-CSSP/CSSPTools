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
    public partial class SubsectorMWQMSampleYearServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ISubsectorMWQMSampleYearService SubsectorMWQMSampleYearService { get; set; }
        #endregion Properties

        #region Constructors
        public SubsectorMWQMSampleYearServiceTest() : base()
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
        public async Task SubsectorMWQMSampleYear_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SubsectorMWQMSampleYear subsectorMWQMSampleYear = GetFilledRandomSubsectorMWQMSampleYear("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // subsectorMWQMSampleYear.SubsectorTVItemID   (Int32)
            // -----------------------------------


            subsectorMWQMSampleYear = null;
            subsectorMWQMSampleYear = GetFilledRandomSubsectorMWQMSampleYear("");
            subsectorMWQMSampleYear.SubsectorTVItemID = 0;
            SubsectorMWQMSampleYearService.Validate(new ValidationContext(subsectorMWQMSampleYear));
            Assert.True(SubsectorMWQMSampleYearService.errRes.ErrList.Count() > 0);
            Assert.True(SubsectorMWQMSampleYearService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "SubsectorTVItemID", "1"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // subsectorMWQMSampleYear.Year   (Int32)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // subsectorMWQMSampleYear.EarliestDate   (DateTime)
            // -----------------------------------


            subsectorMWQMSampleYear = null;
            subsectorMWQMSampleYear = GetFilledRandomSubsectorMWQMSampleYear("");
            subsectorMWQMSampleYear.EarliestDate = new DateTime();
            SubsectorMWQMSampleYearService.Validate(new ValidationContext(subsectorMWQMSampleYear));
            Assert.True(SubsectorMWQMSampleYearService.errRes.ErrList.Count() > 0);
            Assert.True(SubsectorMWQMSampleYearService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "EarliestDate"))).Any());

            subsectorMWQMSampleYear = null;
            subsectorMWQMSampleYear = GetFilledRandomSubsectorMWQMSampleYear("");
            subsectorMWQMSampleYear.EarliestDate = new DateTime(1979, 1, 1);
            SubsectorMWQMSampleYearService.Validate(new ValidationContext(subsectorMWQMSampleYear));
            Assert.True(SubsectorMWQMSampleYearService.errRes.ErrList.Count() > 0);
            Assert.True(SubsectorMWQMSampleYearService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EarliestDate", "1980"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = EarliestDate)]
            // subsectorMWQMSampleYear.LatestDate   (DateTime)
            // -----------------------------------


            subsectorMWQMSampleYear = null;
            subsectorMWQMSampleYear = GetFilledRandomSubsectorMWQMSampleYear("");
            subsectorMWQMSampleYear.LatestDate = new DateTime();
            SubsectorMWQMSampleYearService.Validate(new ValidationContext(subsectorMWQMSampleYear));
            Assert.True(SubsectorMWQMSampleYearService.errRes.ErrList.Count() > 0);
            Assert.True(SubsectorMWQMSampleYearService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "LatestDate"))).Any());

            subsectorMWQMSampleYear = null;
            subsectorMWQMSampleYear = GetFilledRandomSubsectorMWQMSampleYear("");
            subsectorMWQMSampleYear.LatestDate = new DateTime(1979, 1, 1);
            SubsectorMWQMSampleYearService.Validate(new ValidationContext(subsectorMWQMSampleYear));
            Assert.True(SubsectorMWQMSampleYearService.errRes.ErrList.Count() > 0);
            Assert.True(SubsectorMWQMSampleYearService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LatestDate", "1980"))).Any());
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
            Services.AddSingleton<ISubsectorMWQMSampleYearService, SubsectorMWQMSampleYearService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            SubsectorMWQMSampleYearService = Provider.GetService<ISubsectorMWQMSampleYearService>();
            Assert.NotNull(SubsectorMWQMSampleYearService);

            return await Task.FromResult(true);
        }
        private SubsectorMWQMSampleYear GetFilledRandomSubsectorMWQMSampleYear(string OmitPropName)
        {
            SubsectorMWQMSampleYear subsectorMWQMSampleYear = new SubsectorMWQMSampleYear();

            if (OmitPropName != "SubsectorTVItemID") subsectorMWQMSampleYear.SubsectorTVItemID = GetRandomInt(1, 11);
            // should implement a Range for the property Year and type SubsectorMWQMSampleYear
            if (OmitPropName != "EarliestDate") subsectorMWQMSampleYear.EarliestDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "LatestDate") subsectorMWQMSampleYear.LatestDate = new DateTime(2005, 3, 6);

            return subsectorMWQMSampleYear;
        }

        #endregion Functions private
    }
}
