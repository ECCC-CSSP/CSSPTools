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
        private PostTVItemModel FillPostTVItemModelForDelete(List<TVItemModel> tvItemCurrentParentList)
        {
            TVItem tvItemParent = null;
            //TVItem tvItemGrandParent = null;
            TVItem tvItem = new TVItem();
            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();

            if (tvItemCurrentParentList.Count > 0)
            {
                tvItem = tvItemCurrentParentList[tvItemCurrentParentList.Count - 1].TVItem;
                tvItemLanguageList = tvItemCurrentParentList[tvItemCurrentParentList.Count - 1].TVItemLanguageList;
            }
            if (tvItemCurrentParentList.Count > 1)
            {
                tvItemParent = tvItemCurrentParentList[tvItemCurrentParentList.Count - 2].TVItem;
            }
            //if (tvItemCurrentParentList.Count > 2)
            //{
            //    tvItemGrandParent = tvItemCurrentParentList[tvItemCurrentParentList.Count - 3].TVItemModel.TVItem;
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
