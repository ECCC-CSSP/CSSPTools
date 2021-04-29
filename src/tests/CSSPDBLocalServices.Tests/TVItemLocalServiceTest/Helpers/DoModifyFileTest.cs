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
        private async Task DoModifyFileTest(int TVItemID, int ParentTVItemID, WebTypeEnum webTypeParent, TVTypeEnum tvType, string TVTextEN, string TVTextFR)
        {
            await LoadWebType(ParentTVItemID, webTypeParent);

            List<TVItemStatModel> tvItemParentList = await GetWebBaseParentList(webTypeParent);
            Assert.NotNull(tvItemParentList);

            List<TVItemStatModel> webBaseList = await GetWebBaseList(webTypeParent, tvType, ParentTVItemID);

            TVItemModel webBaseJustAdded = webBaseList.Where(c => c.TVItem.TVItemID == TVItemID).FirstOrDefault();

            PostTVItemModel postTVItemModel = FillPostTVItemModelForModify(webBaseJustAdded, tvItemParentList, TVTextEN, TVTextFR, tvType);
            Assert.NotNull(postTVItemModel.TVItem);
            Assert.NotNull(postTVItemModel.TVItemParent);
            Assert.Equal(3, postTVItemModel.TVItemLanguageList.Count);

            await TestAddOrModify(postTVItemModel);
        }
    }
}
