/* 
 *  Manually Edited
 *  
 */

using CSSPEnums;
using CSSPWebModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task DoModifyTest(int TVItemID, WebTypeEnum webType, TVTypeEnum tvType, string TVTextEN, string TVTextFR)
        {
            await LoadWebType(TVItemID, webType);

            List<TVItemModel> tvItemParentList = await GetWebBaseParentList(webType);
            Assert.NotNull(tvItemParentList);

            TVItemModel webBaseJustAdded = tvItemParentList[tvItemParentList.Count - 1];
            Assert.NotNull(webBaseJustAdded);

            PostTVItemModel postTVItemModel = FillPostTVItemModelForModify(webBaseJustAdded, tvItemParentList, TVTextEN, TVTextFR, tvType);
            Assert.NotNull(postTVItemModel.TVItem);
            Assert.NotNull(postTVItemModel.TVItemParent);
            Assert.Equal(3, postTVItemModel.TVItemLanguageList.Count);

            await TestAddOrModify(postTVItemModel);
        }
    }
}
