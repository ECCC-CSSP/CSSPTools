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
        private PostTVItemModel FillPostTVItemModelForModify(TVItemModel webBaseCurrent, List<TVItemStatModel> tvItemParentList, string tvTextEN, string tvTextFR, TVTypeEnum tvType)
        {
            TVItem tvItemParent = null;
            //TVItem tvItemGrandParent = null;
            TVItem tvItem = new TVItem();
            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();

            if (tvItemParentList.Count > 0)
            {
                tvItemParent = tvItemParentList[tvItemParentList.Count - 1].TVItem;
                tvItem.DBCommand = webBaseCurrent.TVItem.DBCommand;
                tvItem.IsActive = webBaseCurrent.TVItem.IsActive;
                tvItem.LastUpdateContactTVItemID = webBaseCurrent.TVItem.LastUpdateContactTVItemID;
                tvItem.LastUpdateDate_UTC = webBaseCurrent.TVItem.LastUpdateDate_UTC;
                tvItem.ParentID = webBaseCurrent.TVItem.ParentID;
                tvItem.TVItemID = webBaseCurrent.TVItem.TVItemID;
                tvItem.TVLevel = webBaseCurrent.TVItem.TVLevel;
                tvItem.TVPath = webBaseCurrent.TVItem.TVPath;
                tvItem.TVType = tvType;

                tvItemLanguageList.Add(new TVItemLanguage()
                {
                    DBCommand = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.en].DBCommand,
                    Language = LanguageEnum.en,
                    LastUpdateContactTVItemID = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.en].LastUpdateContactTVItemID,
                    LastUpdateDate_UTC = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.en].LastUpdateDate_UTC,
                    TranslationStatus = TranslationStatusEnum.Translated,
                    TVItemID = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.en].TVItemID,
                    TVItemLanguageID = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.en].TVItemLanguageID,
                    TVText = tvTextEN,
                });
                tvItemLanguageList.Add(new TVItemLanguage()
                {
                    DBCommand = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.en].DBCommand,
                    Language = LanguageEnum.en,
                    LastUpdateContactTVItemID = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.en].LastUpdateContactTVItemID,
                    LastUpdateDate_UTC = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.en].LastUpdateDate_UTC,
                    TranslationStatus = TranslationStatusEnum.Translated,
                    TVItemID = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.en].TVItemID,
                    TVItemLanguageID = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.en].TVItemLanguageID,
                    TVText = tvTextEN,
                });
                tvItemLanguageList.Add(new TVItemLanguage()
                {
                    DBCommand = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand,
                    Language = LanguageEnum.fr,
                    LastUpdateContactTVItemID = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.fr].LastUpdateContactTVItemID,
                    LastUpdateDate_UTC = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.fr].LastUpdateDate_UTC,
                    TranslationStatus = TranslationStatusEnum.Translated,
                    TVItemID = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.fr].TVItemID,
                    TVItemLanguageID = webBaseCurrent.TVItemLanguageList[(int)LanguageEnum.fr].TVItemLanguageID,
                    TVText = tvTextFR,
                });
            }
            //if (tvItemParentList.Count > 1)
            //{
            //    tvItemGrandParent = tvItemParentList[tvItemParentList.Count - 2].TVItem;
            //}

            return new PostTVItemModel()
            {
                TVItem = tvItem,
                TVItemLanguageList = tvItemLanguageList,
                TVItemParent = tvItemParent,
                //TVItemGrandParent = tvItemGrandParent,
            };
        }
    }
}
