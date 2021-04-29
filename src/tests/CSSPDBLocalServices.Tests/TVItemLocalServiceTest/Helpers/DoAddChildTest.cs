/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDBPreferenceModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPScrambleServices;
using CSSPWebModels;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task DoAddChildFileTest(int GrandParentTVItemID, int ParentTVItemID, WebTypeEnum webTypeGrandParent, TVTypeEnum tvTypeParent, TVTypeEnum tvType, string TVTextEN, string TVTextFR)
        {
            await LoadWebType(GrandParentTVItemID, webTypeGrandParent);

            List<TVItemStatModel> tvItemParentList = await GetWebBaseParentList(webTypeGrandParent);
            Assert.NotNull(tvItemParentList);

            if (tvTypeParent == TVTypeEnum.Infrastructure)
            {
                List<TVItemStatModel> webBaseInfrastructureList = await GetWebBaseList(webTypeGrandParent, tvTypeParent, ParentTVItemID);
                Assert.NotNull(webBaseInfrastructureList);

                TVItemStatModel webBase = webBaseInfrastructureList.Where(c => c.TVItem.TVItemID == ParentTVItemID).FirstOrDefault();
                Assert.NotNull(webBase);

                tvItemParentList.Add(webBase);
            }
            else if (tvTypeParent == TVTypeEnum.MWQMSite)
            {
                List<TVItemStatModel> webBaseMWQMSiteList = await GetWebBaseList(webTypeGrandParent, tvTypeParent, ParentTVItemID);
                Assert.NotNull(webBaseMWQMSiteList);

                TVItemStatModel webBase = webBaseMWQMSiteList.Where(c => c.TVItem.TVItemID == ParentTVItemID).FirstOrDefault();
                Assert.NotNull(webBase);

                tvItemParentList.Add(webBase);
            }
            else if (tvTypeParent == TVTypeEnum.PolSourceSite)
            {
                List<TVItemStatModel> webBasePolSourceSiteList = await GetWebBaseList(webTypeGrandParent, tvTypeParent, ParentTVItemID);
                Assert.NotNull(webBasePolSourceSiteList);

                TVItemStatModel webBase = webBasePolSourceSiteList.Where(c => c.TVItem.TVItemID == ParentTVItemID).FirstOrDefault();
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
