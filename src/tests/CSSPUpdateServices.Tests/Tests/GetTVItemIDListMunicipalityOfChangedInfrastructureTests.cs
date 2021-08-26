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
        public async Task UpdateService_GetTVItemListMunicipalityOfChangedInfrastructure_HasMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_Infrastructure().AddDays(-1);

            List<int> TVItemIDList = await CSSPUpdateService.GetTVItemIDListMunicipalityOfChangedInfrastructure(LastUpdateDate_UTC);
            Assert.True(TVItemIDList.Count > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UpdateService_GetTVItemListMunicipalityOfChangedInfrastructure_NoMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_Infrastructure().AddDays(1);

            List<int> TVItemIDList = await CSSPUpdateService.GetTVItemIDListMunicipalityOfChangedInfrastructure(LastUpdateDate_UTC);
            Assert.True(TVItemIDList.Count == 0);
        }

        #region private
        private DateTime GetLastUpdateDate_UTC_Infrastructure()
        {
            DateTime DateTime1 = (from c in db.TVItems
                                  where c.TVType == TVTypeEnum.Infrastructure
                                  orderby c.LastUpdateDate_UTC descending
                                  select c.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime1.Year > 2000);

            DateTime DateTime2 = (from c in db.TVItems
                                  from cl in db.TVItemLanguages
                                  where c.TVItemID == cl.TVItemID
                                  && c.TVType == TVTypeEnum.Infrastructure
                                  orderby cl.LastUpdateDate_UTC descending
                                  select cl.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime2.Year > 2000);

            DateTime DateTime3 = (from c in db.Infrastructures
                                  orderby c.LastUpdateDate_UTC descending
                                  select c.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime3.Year > 2000);

            DateTime DateTime4 = (from c in db.InfrastructureLanguages
                                  orderby c.LastUpdateDate_UTC descending
                                  select c.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime4.Year > 2000);

            if (DateTime1 < DateTime2)
            {
                DateTime1 = DateTime2;
            }

            if (DateTime1 < DateTime3)
            {
                DateTime1 = DateTime3;
            }

            if (DateTime1 < DateTime4)
            {
                DateTime1 = DateTime4;
            }

            return DateTime1;
        }
        #endregion private
    }
}
