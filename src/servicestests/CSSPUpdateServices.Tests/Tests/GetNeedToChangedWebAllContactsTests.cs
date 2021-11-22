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
        public async Task GetNeedToChangedWebAllContacts_HasContact_Good_Test(string culture)
        {
            Assert.True(await CSSPUpdateServiceSetup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_Contact().AddDays(-1);

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(await CSSPUpdateService.GetNeedToChangedWebAllContacts(LastUpdateDate_UTC));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetNeedToChangedWebAllContacts_NoContact_Good_Test(string culture)
        {
            Assert.True(await CSSPUpdateServiceSetup(culture));

            DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_Contact().AddDays(1);

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            Assert.False(await CSSPUpdateService.GetNeedToChangedWebAllContacts(LastUpdateDate_UTC));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
        }

        #region private
        private DateTime GetLastUpdateDate_UTC_Contact()
        {
            DateTime DateTime1 = (from t in db.TVItems
                                  where t.TVType == TVTypeEnum.Contact
                                  orderby t.LastUpdateDate_UTC descending
                                  select t.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime1.Year > 2000);

            DateTime DateTime2 = (from t in db.TVItems
                                  from tl in db.TVItemLanguages
                                  where t.TVItemID == tl.TVItemID
                                  && t.TVType == TVTypeEnum.Contact
                                  orderby tl.LastUpdateDate_UTC descending
                                  select tl.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime2.Year > 2000);

            DateTime DateTime3 = (from e in db.Contacts
                                  orderby e.LastUpdateDate_UTC descending
                                  select e.LastUpdateDate_UTC).FirstOrDefault();
            Assert.True(DateTime3.Year > 2000);

            DateTime DateTime4 = (from t in db.TVItemLinks
                                  where t.FromTVType == TVTypeEnum.Contact
                                  && (t.ToTVType == TVTypeEnum.Email
                                  || t.ToTVType == TVTypeEnum.Tel
                                  || t.ToTVType == TVTypeEnum.Address)
                                  orderby t.LastUpdateDate_UTC descending
                                  select t.LastUpdateDate_UTC).FirstOrDefault();

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