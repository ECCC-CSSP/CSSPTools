using CSSPModels;
using PolSourceGroupingExcelFileReadServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSSPWebAPIs.Tests.Controllers
{
    public class PolSourceGroupingTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        IPolSourceGroupingExcelFileReadService PolSourceGroupingExcelFileReadService { get; set; }
        CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingTests(IPolSourceGroupingExcelFileReadService polSourceGroupingExcelFileReadService, CSSPDBContext db)
        {
            PolSourceGroupingExcelFileReadService = polSourceGroupingExcelFileReadService;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        public async Task GetGrouping_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture)));

            PolSourceGroupingController PolSourceGroupingController = new PolSourceGroupingController();

        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
        {
            await PolSourceGroupingExcelFileReadService.SetCulture(culture);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
