/* 
 *  Manually Edited
 *  
 */

using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task CheckTVItemAndTVItemLanguage(int TVItemID, WebTypeEnum webType, TVTypeEnum tvType, DBCommandEnum dbCommand, string tvTextEN, string tvTextFR)
        {
            await LoadWebType(TVItemID, webType);

            List<TVItemModel> tvItemParentList = await GetTVItemModelParentList(webType);
            Assert.NotNull(tvItemParentList);

            TVItem tvItem = tvItemParentList[tvItemParentList.Count - 1].TVItem;
            Assert.NotNull(tvItem);

            TVItem tvItemParent = tvItemParentList[tvItemParentList.Count - 2].TVItem;
            Assert.NotNull(tvItemParent);

            List<TVItemLanguage> tvItemLanguageList = tvItemParentList[tvItemParentList.Count - 1].TVItemLanguageList;
            Assert.True(tvItemLanguageList.Count == 3);

            TVItem tvItemNew = new TVItem()
            {
                DBCommand = dbCommand,
                IsActive = tvItemParent.IsActive,
                ParentID = tvItemParent.TVItemID,
                TVItemID = TVItemID,
                TVLevel = tvItemParent.TVLevel + 1,
                TVPath = $"{ tvItemParent.TVPath}p{TVItemID}",
                TVType = tvType,
                LastUpdateDate_UTC = tvItem.LastUpdateDate_UTC,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            };

            CompareTVItems(tvItem, tvItemNew);

            List<TVItemLanguage> tvItemLanguageListNew = new List<TVItemLanguage>()
            {
                new TVItemLanguage()
                {
                     DBCommand = dbCommand,
                     Language = LanguageEnum.en,
                     TVItemID = TVItemID,
                     TVItemLanguageID = TVItemID,
                     TranslationStatus = TranslationStatusEnum.Translated,
                     TVText = tvTextEN,
                     LastUpdateDate_UTC = tvItemLanguageList[(int)LanguageEnum.en - 1].LastUpdateDate_UTC,
                     LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                },
                new TVItemLanguage()
                {
                     DBCommand = dbCommand,
                     Language = LanguageEnum.en,
                     TVItemID = TVItemID,
                     TVItemLanguageID = TVItemID,
                     TranslationStatus = TranslationStatusEnum.Translated,
                     TVText = tvTextEN,
                     LastUpdateDate_UTC = tvItemLanguageList[(int)LanguageEnum.fr - 1].LastUpdateDate_UTC,
                     LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                },
            };

            CompareTVItemLanguage(tvItemLanguageList, tvItemLanguageListNew);
        }
    }
}
