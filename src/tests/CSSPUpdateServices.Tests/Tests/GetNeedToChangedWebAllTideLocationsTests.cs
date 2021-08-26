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
        public async Task UpdateService_GetNeedToChangedWebAllTideLocations_HasTideLocation_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_TideLocation().AddDays(-1);

            bool exist = await CSSPUpdateService.GetNeedToChangedWebAllTideLocations(LastUpdateDate_UTC);
            Assert.True(exist);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UpdateService_GetNeedToChangedWebAllTideLocations_NoTideLocation_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_TideLocation().AddDays(1);

            bool exist = await CSSPUpdateService.GetNeedToChangedWebAllTideLocations(LastUpdateDate_UTC);
            Assert.False(exist);
        }

        #region private
        private DateTime GetLastUpdateDate_UTC_TideLocation()
        {
            DateTime DateTime1 = (from t in db.TideLocations
                                  orderby t.LastUpdateDate_UTC descending
                                  select t.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime1.Year > 2000);

            return DateTime1;
        }
        #endregion private
    }
}
