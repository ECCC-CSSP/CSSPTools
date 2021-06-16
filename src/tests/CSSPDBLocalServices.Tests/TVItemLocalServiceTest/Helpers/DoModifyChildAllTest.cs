/* 
 *  Manually Edited
 *  
 */

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
        private async Task DoModifyChildAllTest(int TVItemID, int ParentTVItemID, WebTypeEnum webType, TVTypeEnum tvType, string TVTextEN, string TVTextFR)
        {
            await LoadWebType(TVItemID, webType);

            List<TVItemModel> tvItemParentList = await GetWebBaseParentList(webType);
            Assert.NotNull(tvItemParentList);

            List<TVItemModel> webBaseList = await GetWebBaseList(webType, tvType, ParentTVItemID);

            tvItemParentList.Add(webBaseList.Where(c => c.TVItem.TVItemID == TVItemID).FirstOrDefault());

            TVItemModel webBaseJustAdded = tvItemParentList[tvItemParentList.Count - 1];

            PostTVItemModel postTVItemModel = FillPostTVItemModelForModify(webBaseJustAdded, tvItemParentList, TVTextEN, TVTextFR, tvType);
            Assert.NotNull(postTVItemModel.TVItem);
            Assert.NotNull(postTVItemModel.TVItemParent);
            Assert.Equal(3, postTVItemModel.TVItemLanguageList.Count);

            await TestAddOrModify(postTVItemModel);
        }
    }
}
