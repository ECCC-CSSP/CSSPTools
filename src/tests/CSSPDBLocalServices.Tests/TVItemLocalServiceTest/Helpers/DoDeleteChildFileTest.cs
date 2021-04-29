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
        //private async Task DoDeleteChildFileTest(int TVItemID, int ParentTVItemID, int GrandParentTVItemID,  WebTypeEnum webTypeGrandParent, TVTypeEnum tvTypeParent, TVTypeEnum tvType, WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980)
        //{
        //    await LoadWebType(GrandParentTVItemID, webTypeGrandParent);

        //    List<WebBase> tvItemParentList = await GetWebBaseParentList(webTypeGrandParent);
        //    Assert.NotNull(tvItemParentList);

        //    WebBase webBaseInfrastructure = ReadGzFileService.webAppLoaded.WebInfrastructures.TVItemInfrastructureList.Where(c => c.TVItemModel.TVItem.TVItemID == ParentTVItemID).FirstOrDefault();
        //    Assert.NotNull(webBaseInfrastructure);

        //    tvItemParentList.Add(webBaseInfrastructure);

        //    InfrastructureModel infrastructureModel = ReadGzFileService.webAppLoaded.WebInfrastructures.InfrastructureModelList.Where(c => c.Infrastructure.InfrastructureTVItemID == ParentTVItemID).FirstOrDefault();
        //    Assert.NotNull(infrastructureModel);

        //    WebBase webBaseFile = infrastructureModel.TVItemFileList.Where(c => c.TVItemModel.TVItem.TVItemID == TVItemID).FirstOrDefault();
        //    Assert.NotNull(webBaseFile);

        //    tvItemParentList.Add(webBaseFile);

        //    PostTVItemModel postTVItemModel = FillPostTVItemModelForDelete(tvItemParentList);
        //    Assert.NotNull(postTVItemModel.TVItem);
        //    Assert.NotNull(postTVItemModel.TVItemParent);
        //    Assert.Equal(3, postTVItemModel.TVItemLanguageList.Count);

        //    await TestDelete(postTVItemModel);
        //}
    }
}
