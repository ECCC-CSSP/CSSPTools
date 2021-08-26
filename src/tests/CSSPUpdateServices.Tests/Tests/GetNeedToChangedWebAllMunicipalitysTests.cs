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
        public async Task UpdateService_GetNeedToChangedWebAllMunicipalities_HasMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_Municipality().AddDays(-1);

            bool exist = await CSSPUpdateService.GetNeedToChangedWebAllMunicipalities(LastUpdateDate_UTC);
            Assert.True(exist);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UpdateService_GetNeedToChangedWebAllMunicipalities_NoMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_Municipality().AddDays(1);

            bool exist = await CSSPUpdateService.GetNeedToChangedWebAllMunicipalities(LastUpdateDate_UTC);
            Assert.False(exist);
        }

        #region private
        private DateTime GetLastUpdateDate_UTC_Municipality()
        {
            DateTime DateTime1 = (from t in db.TVItems
                                  where t.TVType == TVTypeEnum.Municipality
                                  orderby t.LastUpdateDate_UTC descending
                                  select t.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime1.Year > 2000);

            DateTime DateTime2 = (from t in db.TVItems
                                  from tl in db.TVItemLanguages
                                  where t.TVItemID == tl.TVItemID
                                  && t.TVType == TVTypeEnum.Municipality
                                  orderby tl.LastUpdateDate_UTC descending
                                  select tl.LastUpdateDate_UTC).FirstOrDefault();
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
