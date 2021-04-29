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
                Assert.Equal(tvItemLanguageList[(int)lang].TVItemLanguageID, tvItemLanguageList[(int)lang].TVItemLanguageID);
                Assert.Equal(tvItemLanguageList[(int)lang].DBCommand, tvItemLanguageList[(int)lang].DBCommand);
                Assert.Equal(tvItemLanguageList[(int)lang].TVItemID, tvItemLanguageList[(int)lang].TVItemID);
                Assert.Equal(tvItemLanguageList[(int)lang].Language, tvItemLanguageList[(int)lang].Language);
                Assert.Equal(tvItemLanguageList[(int)lang].TVText, tvItemLanguageList[(int)lang].TVText);
                Assert.Equal(tvItemLanguageList[(int)lang].TranslationStatus, tvItemLanguageList[(int)lang].TranslationStatus);
                Assert.Equal(tvItemLanguageList[(int)lang].LastUpdateContactTVItemID, tvItemLanguageList[(int)lang].LastUpdateContactTVItemID);
                Assert.Equal(tvItemLanguageList[(int)lang].LastUpdateDate_UTC, tvItemLanguageList[(int)lang].LastUpdateDate_UTC);
            }
        }
    }
}
