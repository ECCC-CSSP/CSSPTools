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
        public async Task GetNeedToChangedWebAllPolSourceGroupings_HasPolSourceGrouping_Good_Test(string culture)
        {
            Assert.True(await CSSPUpdateServiceSetup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_PolSourceGrouping().AddDays(-1);

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await CSSPUpdateService.GetNeedToChangedWebAllPolSourceGroupings(LastUpdateDate_UTC));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetNeedToChangedWebAllPolSourceGroupings_NoPolSourceGrouping_Good_Test(string culture)
        {
            Assert.True(await CSSPUpdateServiceSetup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_PolSourceGrouping().AddDays(1);

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            Assert.False(await CSSPUpdateService.GetNeedToChangedWebAllPolSourceGroupings(LastUpdateDate_UTC));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
        }

        #region private
        private DateTime GetLastUpdateDate_UTC_PolSourceGrouping()
        {
            DateTime DateTime1 = (from c in db.PolSourceGroupings
                                 orderby c.LastUpdateDate_UTC descending
                                 select c.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime1.Year > 2000);

            DateTime DateTime2 = (from c in db.PolSourceGroupings
                                 from cl in db.PolSourceGroupingLanguages
                                 where c.PolSourceGroupingID == cl.PolSourceGroupingID
                                 orderby cl.LastUpdateDate_UTC descending
                                  select cl.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime2.Year > 2000);


            if (DateTime1 < DateTime2)
            {
                DateTime1 = DateTime2;
            }

            return DateTime1;
        }
        #endregion private
    }
}
