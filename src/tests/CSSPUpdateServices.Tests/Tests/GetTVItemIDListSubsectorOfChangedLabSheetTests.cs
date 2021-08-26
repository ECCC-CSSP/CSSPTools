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
        public async Task UpdateService_GetTVItemListSubsectorOfChangedLabSheet_HasLabSheet_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_LabSheet().AddDays(-1);

            List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListSubsectorOfChangedLabSheet(LastUpdateDate_UTC);
            Assert.True(SubsectorTVItemIDList.Count > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UpdateService_GetTVItemListSubsectorOfChangedLabSheet_NoLabSheet_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_LabSheet().AddDays(1);

            List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListSubsectorOfChangedLabSheet(LastUpdateDate_UTC);
            Assert.True(SubsectorTVItemIDList.Count == 0);
        }

        #region private
        private DateTime GetLastUpdateDate_UTC_LabSheet()
        {
            DateTime DateTime1 = (from e in db.LabSheets
                                  orderby e.LastUpdateDate_UTC descending
                                  select e.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime1.Year > 2000);

            DateTime DateTime2 = (from e in db.LabSheetDetails
                                  orderby e.LastUpdateDate_UTC descending
                                  select e.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime2.Year > 2000);

            DateTime DateTime3 = (from e in db.LabSheetTubeMPNDetails
                                  orderby e.LastUpdateDate_UTC descending
                                  select e.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime3.Year > 2000);


            if (DateTime1 < DateTime2)
            {
                DateTime1 = DateTime2;
            }

            if (DateTime1 < DateTime3)
            {
                DateTime1 = DateTime3;
            }

            return DateTime1;
        }
        #endregion private
    }
}
