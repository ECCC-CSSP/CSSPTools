/* 
 *  Manually Edited
 *  
 */

using CSSPEnums;
using CSSPWebModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task CheckTVItemExistInWebTypeParentAsList(int TVItemID, int ParentTVItemID, WebTypeEnum webTypeParent, WebTypeEnum webType, TVTypeEnum tvType)
        {
            await LoadWebType(ParentTVItemID, webTypeParent);

            TVItemModel tvItemModelParent = await GetTVItemModel(webTypeParent);
            Assert.NotNull(tvItemModelParent);

            List<TVItemModel> tvItemModelList = await GetTVItemModelList(webTypeParent, tvType, ParentTVItemID);
            Assert.NotNull(tvItemModelList);
            Assert.NotEmpty(tvItemModelList);

            TVItemModel tvItemModel = tvItemModelList.Where(c => c.TVItem.TVItemID == TVItemID).FirstOrDefault();
            Assert.NotNull(tvItemModel);
        }
    }
}
