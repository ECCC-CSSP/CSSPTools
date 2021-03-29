/* 
 *  Manually Edited
 *  
 */

using CSSPDBModels;
using CSSPEnums;
using System.Linq;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemServiceTest
    {
        private void CompareTVItemLanguageAddInDB(int TVItemLanguageID, DBCommandEnum DBCommand, int TVItemID, LanguageEnum Language, string TVText, TranslationStatusEnum TranslationStatus)
        {
            TVItemLanguage tvItemLanguage = new TVItemLanguage();

            tvItemLanguage = (from c in dbLocal.TVItemLanguages
                              where c.TVItemLanguageID == TVItemLanguageID
                              select c).FirstOrDefault();

            Assert.NotNull(tvItemLanguage);
            Assert.Equal(TVItemLanguageID, tvItemLanguage.TVItemLanguageID);
            Assert.Equal(DBCommand, tvItemLanguage.DBCommand);
            Assert.Equal(TVItemID, tvItemLanguage.TVItemID);
            Assert.Equal(Language, tvItemLanguage.Language);
            Assert.Equal(TVText, tvItemLanguage.TVText);
            Assert.Equal(TranslationStatus, tvItemLanguage.TranslationStatus);
            Assert.True(tvItemLanguage.LastUpdateDate_UTC.Year > 1979);
            Assert.True(tvItemLanguage.LastUpdateContactTVItemID > 0);
        }
    }
}
