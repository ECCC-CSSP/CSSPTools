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
        private void CompareTVItemParentListInDB(List<WebBase> tvItemParentList)
        {
            TVItem tvItem = new TVItem();
            TVItemLanguage tvItemLanguage = new TVItemLanguage();

            List<TVItem> tvItemList = (from c in dbLocal.TVItems
                                       orderby c.TVItemID
                                       select c).ToList();

            Assert.Equal(tvItemParentList.Count + 1, tvItemList.Count);

            foreach (WebBase webBase in tvItemParentList)
            {
                tvItem = (from c in dbLocal.TVItems
                          where c.TVItemID == webBase.TVItemModel.TVItem.TVItemID
                          select c).FirstOrDefault();

                Assert.NotNull(tvItem);
                Assert.Equal(webBase.TVItemModel.TVItem.TVItemID, tvItem.TVItemID);
                Assert.Equal(webBase.TVItemModel.TVItem.DBCommand, tvItem.DBCommand);
                Assert.Equal(webBase.TVItemModel.TVItem.TVLevel, tvItem.TVLevel);
                Assert.Equal(webBase.TVItemModel.TVItem.TVPath, tvItem.TVPath);
                Assert.Equal(webBase.TVItemModel.TVItem.TVType, tvItem.TVType);
                Assert.Equal(webBase.TVItemModel.TVItem.ParentID, tvItem.ParentID);
                Assert.Equal(webBase.TVItemModel.TVItem.IsActive, tvItem.IsActive);
                Assert.True(tvItem.LastUpdateDate_UTC.Year > 1979);
                Assert.True(tvItem.LastUpdateContactTVItemID > 0);


                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    tvItemLanguage = (from c in dbLocal.TVItemLanguages
                                      where c.TVItemID == webBase.TVItemModel.TVItem.TVItemID
                                      && c.Language == lang
                                      select c).FirstOrDefault();

                    Assert.NotNull(tvItemLanguage);
                    Assert.Equal(webBase.TVItemModel.TVItemLanguageList[(int)lang].TVItemLanguageID, tvItemLanguage.TVItemLanguageID);
                    Assert.Equal(webBase.TVItemModel.TVItemLanguageList[(int)lang].DBCommand, tvItemLanguage.DBCommand);
                    Assert.Equal(webBase.TVItemModel.TVItemLanguageList[(int)lang].TVItemID, tvItemLanguage.TVItemID);
                    Assert.Equal(webBase.TVItemModel.TVItemLanguageList[(int)lang].Language, tvItemLanguage.Language);
                    Assert.Equal(webBase.TVItemModel.TVItemLanguageList[(int)lang].TVText, tvItemLanguage.TVText);
                    Assert.Equal(webBase.TVItemModel.TVItemLanguageList[(int)lang].TranslationStatus, tvItemLanguage.TranslationStatus);
                    Assert.True(tvItemLanguage.LastUpdateDate_UTC.Year > 1979);
                    Assert.True(tvItemLanguage.LastUpdateContactTVItemID > 0);
                }
            }
        }
    }
}
