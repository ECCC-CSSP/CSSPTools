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
        private async Task CheckTVItemAndTVItemLanguageForTVTypeList(int TVItemID, int ParentTVItemID, WebTypeEnum webTypeParent, TVTypeEnum tvType, DBCommandEnum dbCommand, string tvTextEN, string tvTextFR)
        {
            await LoadWebType(ParentTVItemID, webTypeParent);

            List<TVItemModel> TVItemModelList = await GetTVItemModelList(webTypeParent, tvType, ParentTVItemID);

            TVItemModel tvItemModel = TVItemModelList.Where(c => c.TVItem.TVItemID == TVItemID).FirstOrDefault();

            List<TVItemModel> tvItemModelParentList = await GetTVItemModelParentList(webTypeParent);
            Assert.NotNull(tvItemModelParentList);
            Assert.NotEmpty(tvItemModelParentList);

            TVItemModel tvItemModelParent = tvItemModelParentList.Where(c => c.TVItem.TVItemID == ParentTVItemID).FirstOrDefault();
            Assert.NotNull(tvItemModelParent);

            TVItem tvItemNew = new TVItem()
            {
                DBCommand = dbCommand,
                IsActive = tvItemModelParent.TVItem.IsActive,
                ParentID = tvItemModelParent.TVItem.TVItemID,
                TVItemID = TVItemID,
                TVLevel = tvItemModelParent.TVItem.TVLevel + 1,
                TVPath = $"{ tvItemModelParent.TVItem.TVPath}p{TVItemID}",
                TVType = tvType,
                LastUpdateDate_UTC = tvItemModel.TVItem.LastUpdateDate_UTC,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            };

            CompareTVItems(tvItemModel.TVItem, tvItemNew);

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
                     LastUpdateDate_UTC = tvItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].LastUpdateDate_UTC,
                     LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                },
                new TVItemLanguage()
                {
                     DBCommand = dbCommand,
                     Language = LanguageEnum.fr,
                     TVItemID = TVItemID,
                     TVItemLanguageID = TVItemID - 1,
                     TranslationStatus = TranslationStatusEnum.Translated,
                     TVText = tvTextFR,
                     LastUpdateDate_UTC = tvItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].LastUpdateDate_UTC,
                     LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                }
            };

            CompareTVItemLanguage(tvItemModel.TVItemLanguageList, tvItemLanguageListNew);
        }
    }
}
