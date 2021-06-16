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
        private async Task DoDeleteTest(int TVItemID, int ParentTVItemID, WebTypeEnum webType, WebTypeEnum webTypeParent, TVTypeEnum tvType)
        {
            if (webType == webTypeParent)
            {
                await LoadWebType(ParentTVItemID, webTypeParent);

                List<TVItemModel> tvItemParentList = await GetWebBaseParentList(webType);
                Assert.NotNull(tvItemParentList);

                List<TVItemModel> webBaseList = await GetWebBaseList(webTypeParent, tvType, ParentTVItemID);

                tvItemParentList.Add(webBaseList[webBaseList.Count - 1]);

                PostTVItemModel postTVItemModel = FillPostTVItemModelForDelete(tvItemParentList);

                await TestDelete(postTVItemModel);
            }
            else
            {
                await LoadWebType(TVItemID, webType);

                List<TVItemModel> tvItemParentList = await GetWebBaseParentList(webType);
                Assert.NotNull(tvItemParentList);

                PostTVItemModel postTVItemModel = FillPostTVItemModelForDelete(tvItemParentList);

                await TestDelete(postTVItemModel);

            }
        }
    }
}
