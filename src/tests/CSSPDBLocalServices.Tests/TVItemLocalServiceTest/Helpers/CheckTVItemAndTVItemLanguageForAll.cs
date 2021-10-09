/* 
 *  Manually Edited
 *  
 */

using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task CheckTVItemAndTVItemLanguageForAll(int TVItemID, int ParentTVItemID, WebTypeEnum webTypeParent, WebTypeEnum webType, TVTypeEnum tvType, DBCommandEnum dbCommand, string tvTextEN, string tvTextFR)
        {
            await LoadWebType(ParentTVItemID, webTypeParent);
            await LoadWebType(TVItemID, webType);

            List<TVItemModel> tvItemModelParentList = await GetTVItemModelParentList(webTypeParent);
            Assert.NotNull(tvItemModelParentList);
            Assert.NotEmpty(tvItemModelParentList);

            TVItemModel tvItemModelParent = tvItemModelParentList.Where(c => c.TVItem.TVItemID == ParentTVItemID).FirstOrDefault();
            Assert.NotNull(tvItemModelParent);

            List<TVItemModel> TVItemModelList = await GetTVItemModelList(webType, tvType, ParentTVItemID);
            Assert.True(TVItemModelList.Count > 0);

            TVItemModel tvItemModel = TVItemModelList.Where(c => c.TVItem.TVItemID == TVItemID).FirstOrDefault();
            Assert.NotNull(tvItemModel);

            TVItem tvItem = tvItemModel.TVItem;
            List<TVItemLanguage> tvItemLanguageList = tvItemModel.TVItemLanguageList;

            TVItem tvItemNew = new TVItem()
            {
                DBCommand = dbCommand,
                IsActive = tvItemModelParent.TVItem.IsActive,
                ParentID = tvItemModelParent.TVItem.TVItemID,
                TVItemID = TVItemID,
                TVLevel = tvItemModelParent.TVItem.TVLevel + 1,
                TVPath = $"{ tvItemModelParent.TVItem.TVPath}p{TVItemID}",
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
