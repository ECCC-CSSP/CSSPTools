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
        private async Task<TVItemLocalModel> FillTVItemLocalModelForDelete(int TVItemID, int ParentTVItemID, WebTypeEnum webTypeParent, WebTypeEnum webType, TVTypeEnum tvType)
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

            return new TVItemLocalModel()
            {
                TVItem = tvItemModel.TVItem,
                TVItemLanguageList = tvItemModel.TVItemLanguageList,
                TVItemParent = tvItemModelParent.TVItem,
            };
        }
    }
}
