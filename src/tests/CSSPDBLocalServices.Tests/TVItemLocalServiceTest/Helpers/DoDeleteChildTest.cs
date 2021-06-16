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
        private async Task DoDeleteChildTest(int ParentTVItemID, int TVItemID, WebTypeEnum webType, WebTypeEnum webTypeParent, TVTypeEnum tvType)
        {
            await LoadWebType(ParentTVItemID, webTypeParent);

            List<TVItemModel> tvItemParentList = await GetWebBaseParentList(webType);
            Assert.NotNull(tvItemParentList);

            if (webType == webTypeParent)
            {
                List<TVItemModel> webBaseList = await GetWebBaseList(webTypeParent, tvType, ParentTVItemID);

                TVItemModel webBase = webBaseList.Where(c => c.TVItem.TVItemID == TVItemID).FirstOrDefault();
                Assert.NotNull(webBase);

                tvItemParentList.Add(webBase);
            }

            PostTVItemModel postTVItemModel = FillPostTVItemModelForDelete(tvItemParentList);

            await TestDelete(postTVItemModel);

            await LoadWebType(TVItemID, webType);

            tvItemParentList = await GetWebBaseParentList(webType);
            Assert.NotNull(tvItemParentList);

            TVItem tvItem = tvItemParentList[tvItemParentList.Count - 1].TVItem;
            TVItem tvItemParent = tvItemParentList[tvItemParentList.Count - 2].TVItem;

            CompareTVItemParentListInDBForDelete(tvItemParentList);
            CompareTVItemDeleteInDB(tvItem.TVItemID, DBCommandEnum.Deleted, tvItem.TVLevel, tvItem.TVPath, TVTypeEnum.Area, (int)tvItem.ParentID, tvItem.IsActive);

            await LoadWebType(tvItemParent.TVItemID, webTypeParent);

            tvItemParentList = await GetWebBaseParentList(webType);
            Assert.NotNull(tvItemParentList);

            await GetWebBaseList(webTypeParent, tvType, ParentTVItemID);

            CheckLocalFilesExist(tvItemParentList);

        }
    }
}
