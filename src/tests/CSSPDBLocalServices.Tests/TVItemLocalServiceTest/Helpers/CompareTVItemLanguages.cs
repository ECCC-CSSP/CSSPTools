/* 
 *  Manually Edited
 *  
 */

using CSSPDBModels;
using CSSPEnums;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private void CompareTVItemLanguage(List<TVItemLanguage> tvItemLanguageList, List<TVItemLanguage> tvItemLanguageList2)
        {
            foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
            {
                Assert.Equal(tvItemLanguageList[(int)lang - 1].TVItemLanguageID, tvItemLanguageList[(int)lang - 1].TVItemLanguageID);
                Assert.Equal(tvItemLanguageList[(int)lang - 1].DBCommand, tvItemLanguageList[(int)lang - 1].DBCommand);
                Assert.Equal(tvItemLanguageList[(int)lang - 1].TVItemID, tvItemLanguageList[(int)lang - 1].TVItemID);
                Assert.Equal(tvItemLanguageList[(int)lang - 1].Language, tvItemLanguageList[(int)lang - 1].Language);
                Assert.Equal(tvItemLanguageList[(int)lang - 1].TVText, tvItemLanguageList[(int)lang - 1].TVText);
                Assert.Equal(tvItemLanguageList[(int)lang - 1].TranslationStatus, tvItemLanguageList[(int)lang - 1].TranslationStatus);
                Assert.Equal(tvItemLanguageList[(int)lang - 1].LastUpdateContactTVItemID, tvItemLanguageList[(int)lang - 1].LastUpdateContactTVItemID);
                Assert.Equal(tvItemLanguageList[(int)lang - 1].LastUpdateDate_UTC, tvItemLanguageList[(int)lang - 1].LastUpdateDate_UTC);
            }
        }
    }
}
