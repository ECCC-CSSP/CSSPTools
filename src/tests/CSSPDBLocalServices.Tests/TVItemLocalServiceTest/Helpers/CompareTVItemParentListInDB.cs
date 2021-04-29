/* 
 *  Manually Edited
 *  
 */

using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private void CompareTVItemParentListInDB(List<TVItemStatModel> tvItemParentList)
        {
            TVItem tvItem = new TVItem();
            TVItemLanguage tvItemLanguage = new TVItemLanguage();

            List<TVItem> tvItemList = (from c in dbLocal.TVItems
                                       orderby c.TVLevel
                                       select c).ToList();

            foreach (TVItemModel webBase in tvItemParentList)
            {
                tvItem = (from c in dbLocal.TVItems
                          where c.TVItemID == webBase.TVItem.TVItemID
                          select c).FirstOrDefault();

                Assert.NotNull(tvItem);
                Assert.Equal(webBase.TVItem.TVItemID, tvItem.TVItemID);
                Assert.Equal(webBase.TVItem.DBCommand, tvItem.DBCommand);
                Assert.Equal(webBase.TVItem.TVLevel, tvItem.TVLevel);
                Assert.Equal(webBase.TVItem.TVPath, tvItem.TVPath);
                Assert.Equal(webBase.TVItem.TVType, tvItem.TVType);
                Assert.Equal(webBase.TVItem.ParentID, tvItem.ParentID);
                Assert.Equal(webBase.TVItem.IsActive, tvItem.IsActive);
                Assert.True(tvItem.LastUpdateDate_UTC.Year > 1979);
                Assert.True(tvItem.LastUpdateContactTVItemID > 0);


                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    tvItemLanguage = (from c in dbLocal.TVItemLanguages
                                      where c.TVItemID == webBase.TVItem.TVItemID
                                      && c.Language == lang
                                      select c).FirstOrDefault();

                    Assert.NotNull(tvItemLanguage);
                    Assert.Equal(webBase.TVItemLanguageList[(int)lang].TVItemLanguageID, tvItemLanguage.TVItemLanguageID);
                    Assert.Equal(webBase.TVItemLanguageList[(int)lang].DBCommand, tvItemLanguage.DBCommand);
                    Assert.Equal(webBase.TVItemLanguageList[(int)lang].TVItemID, tvItemLanguage.TVItemID);
                    Assert.Equal(webBase.TVItemLanguageList[(int)lang].Language, tvItemLanguage.Language);
                    Assert.Equal(webBase.TVItemLanguageList[(int)lang].TVText, tvItemLanguage.TVText);
                    Assert.Equal(webBase.TVItemLanguageList[(int)lang].TranslationStatus, tvItemLanguage.TranslationStatus);
                    Assert.True(tvItemLanguage.LastUpdateDate_UTC.Year > 1979);
                    Assert.True(tvItemLanguage.LastUpdateContactTVItemID > 0);
                }
            }
        }
    }
}
