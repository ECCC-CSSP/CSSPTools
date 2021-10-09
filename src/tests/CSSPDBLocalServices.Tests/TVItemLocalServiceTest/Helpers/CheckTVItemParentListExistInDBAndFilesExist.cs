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
        private async Task CheckTVItemParentListExistInDBAndFilesExist(int TVItemID, WebTypeEnum webType)
        {
            await LoadWebType(TVItemID, webType);

            List<TVItemModel> tvItemParentList = await GetTVItemModelParentList(webType);
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count > 0);

            CompareTVItemParentListInDB(tvItemParentList);

            CheckLocalFilesExist(tvItemParentList);
        }
    }
}
