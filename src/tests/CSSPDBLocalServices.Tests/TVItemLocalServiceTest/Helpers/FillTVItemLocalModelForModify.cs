/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task<TVItemLocalModel> FillTVItemLocalModelForModify(int TVItemID, int ParentTVItemID, WebTypeEnum webTypeParent, WebTypeEnum webType, TVTypeEnum tvType, string tvTextEN, string tvTextFR)
        {
            await LoadWebType(ParentTVItemID, webTypeParent);

            List<TVItemModel> tvItemParentList = await GetTVItemModelParentList(webTypeParent);
            Assert.NotNull(tvItemParentList);
            Assert.NotEmpty(tvItemParentList);

            TVItemModel tvItemModelParent = tvItemParentList.Where(c => c.TVItem.TVItemID == ParentTVItemID).FirstOrDefault();
            Assert.NotNull(tvItemModelParent);

            List<TVItemModel> tvItemModelList = await GetTVItemModelList(webType, tvType, ParentTVItemID);
            Assert.NotNull(tvItemModelList);
            Assert.NotEmpty(tvItemModelList);

            TVItemModel tvItemModel = tvItemModelList.Where(c => c.TVItem.TVItemID == TVItemID).FirstOrDefault();
            Assert.NotNull(tvItemModel);

            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();

            tvItemLanguageList.Add(new TVItemLanguage()
            {
                DBCommand = tvItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].DBCommand,
                Language = LanguageEnum.en,
                LastUpdateContactTVItemID = tvItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].LastUpdateContactTVItemID,
                LastUpdateDate_UTC = tvItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].LastUpdateDate_UTC,
                TranslationStatus = TranslationStatusEnum.Translated,
                TVItemID = tvItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVItemID,
                TVItemLanguageID = tvItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVItemLanguageID,
                TVText = tvTextEN,
            });
            tvItemLanguageList.Add(new TVItemLanguage()
            {
                DBCommand = tvItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].DBCommand,
                Language = LanguageEnum.fr,
                LastUpdateContactTVItemID = tvItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].LastUpdateContactTVItemID,
                LastUpdateDate_UTC = tvItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].LastUpdateDate_UTC,
                TranslationStatus = TranslationStatusEnum.Translated,
                TVItemID = tvItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVItemID,
                TVItemLanguageID = tvItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVItemLanguageID,
                TVText = tvTextFR,
            });

            return new TVItemLocalModel()
            {
                TVItem = tvItemModel.TVItem,
                TVItemLanguageList = tvItemLanguageList,
                TVItemParent = tvItemModelParent.TVItem,
            };
        }
    }
}
