using CSSPDBModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using CSSPEnums;

namespace UpdateServices.Tests
{
    public partial class UpdateServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UpdateService_GetUseOfSiteListSubsectorOfChangedUseOfSite_HasUseOfSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_UseOfSite().AddDays(-1);

            List<int> SubsectorUseOfSiteIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedUseOfSite(LastUpdateDate_UTC);
            Assert.True(SubsectorUseOfSiteIDList.Count > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UpdateService_GetUseOfSiteListSubsectorOfChangedUseOfSite_NoUseOfSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_UseOfSite().AddDays(1);

            List<int> SubsectorUseOfSiteIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedUseOfSite(LastUpdateDate_UTC);
            Assert.True(SubsectorUseOfSiteIDList.Count == 0);
        }

        #region private
        private DateTime GetLastUpdateDate_UTC_UseOfSite()
        {
            DateTime DateTime1 = (from c in db.UseOfSites
                                  orderby c.LastUpdateDate_UTC descending
                                  select c.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime1.Year > 2000);

            return DateTime1;
        }
        #endregion private
    }
}
