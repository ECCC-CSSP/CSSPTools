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
        public async Task UpdateService_GetNeedToChangedWebAllMWQMLookupMPNs_HasMWQMLookupMPN_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MWQMLookupMPN().AddDays(-1);

            bool exist = await CSSPUpdateService.GetNeedToChangedWebAllMWQMLookupMPNs(LastUpdateDate_UTC);
            Assert.True(exist);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UpdateService_GetNeedToChangedWebAllMWQMLookupMPNs_NoMWQMLookupMPN_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MWQMLookupMPN().AddDays(1);

            bool exist = await CSSPUpdateService.GetNeedToChangedWebAllMWQMLookupMPNs(LastUpdateDate_UTC);
            Assert.False(exist);
        }

        #region private
        private DateTime GetLastUpdateDate_UTC_MWQMLookupMPN()
        {
            DateTime DateTime = (from e in db.MWQMLookupMPNs
                                  orderby e.LastUpdateDate_UTC descending
                                  select e.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime.Year > 2000);

            return DateTime;
        }
        #endregion private
    }
}
