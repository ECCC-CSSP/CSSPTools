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
        private async Task DoAddTest(int ParentTVItemID, WebTypeEnum webTypeParent, TVTypeEnum tvType, string TVTextEN, string TVTextFR)
        {
            await LoadWebType(ParentTVItemID, webTypeParent);

            List<TVItemModel> tvItemParentList = await GetWebBaseParentList(webTypeParent);
            Assert.NotNull(tvItemParentList);

            PostTVItemModel postTVItemModel = FillPostTVItemModelForAdd(tvItemParentList, TVTextEN, TVTextFR, tvType);
            Assert.NotNull(postTVItemModel.TVItem);
            Assert.NotNull(postTVItemModel.TVItemParent);
            Assert.Equal(3, postTVItemModel.TVItemLanguageList.Count);

            await TestAddOrModify(postTVItemModel);
        }
    }
}
