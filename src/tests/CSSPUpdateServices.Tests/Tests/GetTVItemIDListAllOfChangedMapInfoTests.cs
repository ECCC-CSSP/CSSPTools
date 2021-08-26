using CSSPDBModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

namespace UpdateServices.Tests
{
    public partial class UpdateServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UpdateService_GetTVItemListSubsectorOfChangedMapInfo_HasMapInfo_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MapInfo().AddDays(-1);

            List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedMapInfo(LastUpdateDate_UTC);
            Assert.True(SubsectorTVItemIDList.Count > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UpdateService_GetTVItemListSubsectorOfChangedMapInfo_NoMapInfo_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MapInfo().AddDays(1);

            List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedMapInfo(LastUpdateDate_UTC);
            Assert.True(SubsectorTVItemIDList.Count == 0);
        }

        #region private
        private DateTime GetLastUpdateDate_UTC_MapInfo()
        {
            DateTime DateTime1 = (from c in db.MapInfos
                                  orderby c.LastUpdateDate_UTC descending
                                  select c.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime1.Year > 2000);

            DateTime DateTime2 = (from m in db.MapInfoPoints
                                  orderby m.LastUpdateDate_UTC descending
                                  select m.LastUpdateDate_UTC).FirstOrDefault();
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
