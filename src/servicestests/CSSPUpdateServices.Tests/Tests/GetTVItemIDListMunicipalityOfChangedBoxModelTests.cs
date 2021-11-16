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
        public async Task GetTVItemIDListMunicipalityOfChangedBoxModel_HasMunicipality_Good_Test(string culture)
        {
            Assert.True(await CSSPUpdateServiceSetup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_BoxModel().AddDays(-1);

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            List<int> TVItemIDList = await CSSPUpdateService.GetTVItemIDListMunicipalityOfChangedBoxModel(LastUpdateDate_UTC);
            Assert.True(TVItemIDList.Count > 0);

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetTVItemIDListMunicipalityOfChangedBoxModel_NoMunicipality_Good_Test(string culture)
        {
            Assert.True(await CSSPUpdateServiceSetup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_BoxModel().AddDays(1);

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            List<int> TVItemIDList = await CSSPUpdateService.GetTVItemIDListMunicipalityOfChangedBoxModel(LastUpdateDate_UTC);
            Assert.True(TVItemIDList.Count == 0);

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
        }

        #region private
        private DateTime GetLastUpdateDate_UTC_BoxModel()
        {
            DateTime DateTime1 = (from c in db.BoxModels
                                  orderby c.LastUpdateDate_UTC descending
                                  select c.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime1.Year > 2000);

            DateTime DateTime2 = (from c in db.BoxModelResults
                                  orderby c.LastUpdateDate_UTC descending
                                  select c.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime2.Year > 2000);

            DateTime DateTime3 = (from c in db.BoxModelLanguages
                                  orderby c.LastUpdateDate_UTC descending
                                  select c.LastUpdateDate_UTC).FirstOrDefault();
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
