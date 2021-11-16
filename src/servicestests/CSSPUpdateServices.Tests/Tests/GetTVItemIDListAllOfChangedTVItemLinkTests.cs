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
        public async Task GetTVItemIDListAllOfChangedTVItemLink_HasTVItemLink_Good_Test(string culture)
        {
            Assert.True(await CSSPUpdateServiceSetup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_TVItemLink().AddDays(-1);

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            List<int> SubsectorTVItemLinkIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedTVItemLink(LastUpdateDate_UTC);
            Assert.True(SubsectorTVItemLinkIDList.Count > 0);

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetTVItemIDListAllOfChangedTVItemLink_NoTVItemLink_Good_Test(string culture)
        {
            Assert.True(await CSSPUpdateServiceSetup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_TVItemLink().AddDays(1);

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            List<int> SubsectorTVItemLinkIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedTVItemLink(LastUpdateDate_UTC);
            Assert.True(SubsectorTVItemLinkIDList.Count == 0);

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
        }

        #region private
        private DateTime GetLastUpdateDate_UTC_TVItemLink()
        {
            DateTime DateTime1 = (from tl in db.TVItemLinks
                                  where (tl.FromTVType == TVTypeEnum.Contact
                                  || tl.FromTVType == TVTypeEnum.LiftStation
                                  || tl.FromTVType == TVTypeEnum.Infrastructure
                                  || tl.FromTVType == TVTypeEnum.Municipality)
                                  orderby tl.LastUpdateDate_UTC descending
                                  select tl.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime1.Year > 2000);

            return DateTime1;
        }
        #endregion private
    }
}
