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
        private async Task DoModifyFileTest(int TVItemID, int ParentTVItemID, WebTypeEnum webTypeParent, TVTypeEnum tvType, string TVTextEN, string TVTextFR)
        {
            await LoadWebType(ParentTVItemID, webTypeParent);

            List<TVItemModel> tvItemParentList = await GetWebBaseParentList(webTypeParent);
            Assert.NotNull(tvItemParentList);

            List<TVItemModel> webBaseList = await GetWebBaseList(webTypeParent, tvType, ParentTVItemID);

            TVItemModel webBaseJustAdded = webBaseList.Where(c => c.TVItem.TVItemID == TVItemID).FirstOrDefault();

            PostTVItemModel postTVItemModel = FillPostTVItemModelForModify(webBaseJustAdded, tvItemParentList, TVTextEN, TVTextFR, tvType);
            Assert.NotNull(postTVItemModel.TVItem);
            Assert.NotNull(postTVItemModel.TVItemParent);
            Assert.Equal(3, postTVItemModel.TVItemLanguageList.Count);

            await TestAddOrModify(postTVItemModel);
        }
    }
}
