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

namespace CSSPSyncDBsServices.Tests
{
    public partial class SyncDBsServiceTest
    {
        //private async Task<AppTaskModel> TestAddOrModify(AppTaskModel appTaskModel)
        //{
        //    var actionPostTVItemModelRes = await SyncDBsService.AddOrModifySyncDBs(appTaskModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    AppTaskModel appTaskModelRet = (AppTaskModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.NotNull(appTaskModelRet);

        //    return await Task.FromResult(appTaskModelRet);
        //}
        //private async Task TestAddOrModifyError(AppTaskModel appTaskModel, string errorMessage)
        //{
        //    var actionPostTVItemModelRes = await SyncDBsService.AddOrModifySyncDBs(appTaskModel);
        //    Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
        //    var validationResultList = ((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        //    List<ValidationResult> vrList = ((List<ValidationResult>)validationResultList).ToList();
        //    Assert.True(vrList.Where(c => c.ErrorMessage.Contains(errorMessage)).Any());
        //}
        //private async Task TestAddOrModifyUnauthorized(AppTaskModel appTaskModel, string errorMessage)
        //{
        //    var actionPostTVItemModelRes = await SyncDBsService.AddOrModifySyncDBs(appTaskModel);
        //    Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
        //    var validationResult = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.Equal(errorMessage, validationResult);
        //}
        //private async Task<bool> TestDelete(int appTaskID)
        //{
        //    var actionPostTVItemModelRes = await SyncDBsService.DeleteSyncDBs(appTaskID);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    return boolRet;
        //}
        //private async Task TestDeleteError(int AppTaskID, string errorMessage)
        //{
        //    var actionPostTVItemModelRes = await SyncDBsService.DeleteSyncDBs(AppTaskID);
        //    Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
        //    var validationResultList = ((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        //    List<ValidationResult> vrList = ((List<ValidationResult>)validationResultList).ToList();
        //    Assert.True(vrList.Where(c => c.ErrorMessage.Contains(errorMessage)).Any());
        //}
        //private async Task TestDeleteUnauthorized(int AppTaskID, string errorMessage)
        //{
        //    var actionPostTVItemModelRes = await SyncDBsService.DeleteSyncDBs(AppTaskID);
        //    Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
        //    var validationResultList = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
        //    var validationResult = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.Equal(errorMessage, validationResult);
        //}
        //private async Task<List<AppTaskModel>> TestGetAll()
        //{
        //    var actionPostTVItemModelRes = await SyncDBsService.GetAllSyncDBs();
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    List<AppTaskModel> appTaskModelListRet = (List<AppTaskModel>)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.NotNull(appTaskModelListRet);

        //    return await Task.FromResult(appTaskModelListRet);
        //}
        //private async Task TestGetAllUnauthorized(string errorMessage)
        //{
        //    var actionPostTVItemModelRes = await SyncDBsService.GetAllSyncDBs();
        //    Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
        //    var validationResultList = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
        //    var validationResult = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.Equal(errorMessage, validationResult);
        //}
    }
}
