/* 
 *  Manually Edited
 *  
 */

using CSSPEnums;
using CSSPWebModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task CheckTVItemExistInWebTypeParentAsList(int TVItemID, int ParentTVItemID, WebTypeEnum webType, WebTypeEnum webTypeParent, TVTypeEnum tvType)
        {
            await LoadWebType(TVItemID, webType);

            TVItemModel webBase = await GetWebBase(webType);

            await LoadWebType(ParentTVItemID, webTypeParent);

            List<TVItemModel> webBaseList = await GetWebBaseList(webTypeParent, tvType, ParentTVItemID);

            CompareTVItems(webBase.TVItem, webBaseList[webBaseList.Count - 1].TVItem);

            CompareTVItemLanguage(webBase.TVItemLanguageList, webBaseList[webBaseList.Count - 1].TVItemLanguageList);
        }
    }
}
