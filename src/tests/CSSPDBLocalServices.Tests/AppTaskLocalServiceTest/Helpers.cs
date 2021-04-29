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
    public partial class AppTaskLocalServiceTest
    {
        private async Task<PostAppTaskModel> TestAddOrModify(PostAppTaskModel appTaskModel)
        {
            var actionPostTVItemModelRes = await AppTaskLocalService.AddOrModifyLocal(appTaskModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            PostAppTaskModel appTaskModelRet = (PostAppTaskModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(appTaskModelRet);

            return await Task.FromResult(appTaskModelRet);
        }
        private async Task TestAddOrModifyError(PostAppTaskModel appTaskModel, string errorMessage)
        {
            var actionPostTVItemModelRes = await AppTaskLocalService.AddOrModifyLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            List<ValidationResult> vrList = ((List<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(errorMessage)).Any());
        }
        private async Task TestAddOrModifyUnauthorized(PostAppTaskModel appTaskModel, string errorMessage)
        {
            var actionPostTVItemModelRes = await AppTaskLocalService.AddOrModifyLocal(appTaskModel);
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResult = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.Equal(errorMessage, validationResult);
        }
        private async Task<bool> TestDelete(int appTaskID)
        {
            var actionPostTVItemModelRes = await AppTaskLocalService.DeleteLocal(appTaskID);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            return boolRet;
        }
        private async Task TestDeleteError(int AppTaskID, string errorMessage)
        {
            var actionPostTVItemModelRes = await AppTaskLocalService.DeleteLocal(AppTaskID);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            List<ValidationResult> vrList = ((List<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(errorMessage)).Any());
        }
        private async Task TestDeleteUnauthorized(int AppTaskID, string errorMessage)
        {
            var actionPostTVItemModelRes = await AppTaskLocalService.DeleteLocal(AppTaskID);
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResultList = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            var validationResult = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.Equal(errorMessage, validationResult);
        }
        private async Task<List<PostAppTaskModel>> TestGetAll()
        {
            var actionPostTVItemModelRes = await AppTaskLocalService.GetAllAppTaskLocal();
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            List<PostAppTaskModel> appTaskModelListRet = (List<PostAppTaskModel>)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(appTaskModelListRet);

            return await Task.FromResult(appTaskModelListRet);
        }
        private async Task TestGetAllUnauthorized(string errorMessage)
        {
            var actionPostTVItemModelRes = await AppTaskLocalService.GetAllAppTaskLocal();
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResultList = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            var validationResult = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.Equal(errorMessage, validationResult);
        }
    }
}
