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
        private async Task DoAddChildFileTest(int GrandParentTVItemID, int ParentTVItemID, WebTypeEnum webTypeGrandParent, TVTypeEnum tvTypeParent, TVTypeEnum tvType, string TVTextEN, string TVTextFR)
        {
            await LoadWebType(GrandParentTVItemID, webTypeGrandParent);

            List<TVItemModel> tvItemParentList = await GetWebBaseParentList(webTypeGrandParent);
            Assert.NotNull(tvItemParentList);

            if (tvTypeParent == TVTypeEnum.Infrastructure)
            {
                List<TVItemModel> webBaseInfrastructureList = await GetWebBaseList(webTypeGrandParent, tvTypeParent, ParentTVItemID);
                Assert.NotNull(webBaseInfrastructureList);

                TVItemModel webBase = webBaseInfrastructureList.Where(c => c.TVItem.TVItemID == ParentTVItemID).FirstOrDefault();
                Assert.NotNull(webBase);

                tvItemParentList.Add(webBase);
            }
            else if (tvTypeParent == TVTypeEnum.MWQMSite)
            {
                List<TVItemModel> webBaseMWQMSiteList = await GetWebBaseList(webTypeGrandParent, tvTypeParent, ParentTVItemID);
                Assert.NotNull(webBaseMWQMSiteList);

                TVItemModel webBase = webBaseMWQMSiteList.Where(c => c.TVItem.TVItemID == ParentTVItemID).FirstOrDefault();
                Assert.NotNull(webBase);

                tvItemParentList.Add(webBase);
            }
            else if (tvTypeParent == TVTypeEnum.PolSourceSite)
            {
                List<TVItemModel> webBasePolSourceSiteList = await GetWebBaseList(webTypeGrandParent, tvTypeParent, ParentTVItemID);
                Assert.NotNull(webBasePolSourceSiteList);

                TVItemModel webBase = webBasePolSourceSiteList.Where(c => c.TVItem.TVItemID == ParentTVItemID).FirstOrDefault();
                Assert.NotNull(webBase);

                tvItemParentList.Add(webBase);
            }
            else
            {
                Assert.True(false, $"{tvTypeParent} is not implemented in DoAddChildFileTest");
            }

            PostTVItemModel postTVItemModel = FillPostTVItemModelForAdd(tvItemParentList, TVTextEN, TVTextFR, tvType);
            Assert.NotNull(postTVItemModel.TVItem);
            Assert.NotNull(postTVItemModel.TVItemParent);
            Assert.Equal(3, postTVItemModel.TVItemLanguageList.Count);

            await TestAddOrModify(postTVItemModel);
        }
    }
}
