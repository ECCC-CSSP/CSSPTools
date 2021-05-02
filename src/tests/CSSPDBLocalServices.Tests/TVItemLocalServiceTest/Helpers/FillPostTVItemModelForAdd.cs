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
        private PostTVItemModel FillPostTVItemModelForAdd(List<TVItemModel> tvItemParentList, string tvTextEN, string tvTextFR, TVTypeEnum tvType)
        {
            TVItem tvItemParent = null;
            //TVItem tvItemGrandParent = null;
            TVItem tvItem = new TVItem();
            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();

            if (tvItemParentList.Count > 0)
            {
                tvItemParent = tvItemParentList[tvItemParentList.Count - 1].TVItem;
                tvItem.DBCommand = tvItemParent.DBCommand;
                tvItem.IsActive = tvItemParent.IsActive;
                tvItem.LastUpdateContactTVItemID = tvItemParent.LastUpdateContactTVItemID;
                tvItem.LastUpdateDate_UTC = tvItemParent.LastUpdateDate_UTC;
                tvItem.ParentID = tvItemParent.TVItemID;
                tvItem.TVItemID = 0;
                tvItem.TVLevel = tvItemParent.TVLevel + 1;
                tvItem.TVPath = tvItemParent.TVPath + "p-10000";
                tvItem.TVType = tvType;

                tvItemLanguageList.Add(new TVItemLanguage()
                {
                    DBCommand = tvItem.DBCommand,
                    Language = LanguageEnum.en,
                    LastUpdateContactTVItemID = tvItem.LastUpdateContactTVItemID,
                    LastUpdateDate_UTC = tvItem.LastUpdateDate_UTC,
                    TranslationStatus = TranslationStatusEnum.Translated,
                    TVItemID = 0,
                    TVItemLanguageID = 0,
                    TVText = tvTextEN,
                });
                tvItemLanguageList.Add(new TVItemLanguage()
                {
                    DBCommand = tvItem.DBCommand,
                    Language = LanguageEnum.en,
                    LastUpdateContactTVItemID = tvItem.LastUpdateContactTVItemID,
                    LastUpdateDate_UTC = tvItem.LastUpdateDate_UTC,
                    TranslationStatus = TranslationStatusEnum.Translated,
                    TVItemID = 0,
                    TVItemLanguageID = 0,
                    TVText = tvTextEN,
                });
                tvItemLanguageList.Add(new TVItemLanguage()
                {
                    DBCommand = tvItem.DBCommand,
                    Language = LanguageEnum.fr,
                    LastUpdateContactTVItemID = tvItem.LastUpdateContactTVItemID,
                    LastUpdateDate_UTC = tvItem.LastUpdateDate_UTC,
                    TranslationStatus = TranslationStatusEnum.Translated,
                    TVItemID = 0,
                    TVItemLanguageID = 0,
                    TVText = tvTextFR,
                });
            }
            //if (tvItemParentList.Count > 1)
            //{
            //    tvItemGrandParent = tvItemParentList[tvItemParentList.Count - 2].TVItemModel.TVItem;
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
