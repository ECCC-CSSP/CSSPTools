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
        private async Task CheckTVItemExistInWebType(int TVItemID, WebTypeEnum webType)
        {
            await LoadWebType(TVItemID, webType);

            TVItemModel webBase = await GetWebBase(webType);

            List<TVItemModel> tvItemParentList = await GetWebBaseParentList(webType);
            Assert.NotNull(tvItemParentList);

            CompareTVItems(webBase.TVItem, tvItemParentList[tvItemParentList.Count - 1].TVItem);

            CompareTVItemLanguage(webBase.TVItemLanguageList, tvItemParentList[tvItemParentList.Count - 1].TVItemLanguageList);
        }
    }
}
