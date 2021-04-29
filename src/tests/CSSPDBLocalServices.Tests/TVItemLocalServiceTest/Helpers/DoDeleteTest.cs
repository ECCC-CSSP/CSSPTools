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
        private async Task DoDeleteTest(int TVItemID, int ParentTVItemID, WebTypeEnum webType, WebTypeEnum webTypeParent, TVTypeEnum tvType)
        {
            if (webType == webTypeParent)
            {
                await LoadWebType(ParentTVItemID, webTypeParent);

                List<TVItemStatModel> tvItemParentList = await GetWebBaseParentList(webType);
                Assert.NotNull(tvItemParentList);

                List<TVItemStatModel> webBaseList = await GetWebBaseList(webTypeParent, tvType, ParentTVItemID);

                tvItemParentList.Add(webBaseList[webBaseList.Count - 1]);

                PostTVItemModel postTVItemModel = FillPostTVItemModelForDelete(tvItemParentList);

                await TestDelete(postTVItemModel);
            }
            else
            {
                await LoadWebType(TVItemID, webType);

                List<TVItemStatModel> tvItemParentList = await GetWebBaseParentList(webType);
                Assert.NotNull(tvItemParentList);

                PostTVItemModel postTVItemModel = FillPostTVItemModelForDelete(tvItemParentList);

                await TestDelete(postTVItemModel);

            }
        }
    }
}
