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

namespace CSSPAzureAppTaskModelServices.Tests
{
    public partial class AzureAppTaskModelServiceTest
    {
        private AppTaskModel FillAppTaskModel()
        {
            AppTaskModel appTaskModel = new AppTaskModel();

            AppTask appTask = new AppTask()
            {
                AppTaskID = 0,
                DBCommand = DBCommandEnum.Created,
                TVItemID = 1,
                TVItemID2 = 1,
                AppTaskCommand = AppTaskCommandEnum.SyncDBs,
                AppTaskStatus = AppTaskStatusEnum.Created,
                PercentCompleted = 10,
                Parameters = "parameters",
                Language = LanguageEnum.en,
                StartDateTime_UTC = DateTime.UtcNow,
                EndDateTime_UTC = null,
                EstimatedLength_second = null,
                RemainingTime_second = null,
                LastUpdateDate_UTC = DateTime.UtcNow,
                LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            };

            appTaskModel.AppTask = appTask;

            foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
            {
                AppTaskLanguage appTaskLanguage = new AppTaskLanguage()
                {
                    AppTaskLanguageID = 0,
                    DBCommand = DBCommandEnum.Created,
                    AppTaskID = 0,
                    ErrorText = "",
                    Language = lang,
                    StatusText = "This is the status text",
                    TranslationStatus = TranslationStatusEnum.Translated,
                    LastUpdateDate_UTC = DateTime.UtcNow,
                    LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                };

                appTaskModel.AppTaskLanguageList.Add(appTaskLanguage);
            }

            return appTaskModel;
        }
        private async Task<AppTaskModel> TestAddOrModify(AppTaskModel appTaskModel)
        {
            var actionPostTVItemModelRes = await AzureAppTaskModelService.AddOrModifyAzureAppTaskModel(appTaskModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            AppTaskModel appTaskModelRet = (AppTaskModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(appTaskModelRet);

            return await Task.FromResult(appTaskModelRet);
        }
        private async Task TestAddOrModifyError(AppTaskModel appTaskModel, string errorMessage)
        {
            var actionPostTVItemModelRes = await AzureAppTaskModelService.AddOrModifyAzureAppTaskModel(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            List<ValidationResult> vrList = ((List<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(errorMessage)).Any());
        }
        private async Task TestAddOrModifyUnauthorized(AppTaskModel appTaskModel, string errorMessage)
        {
            var actionPostTVItemModelRes = await AzureAppTaskModelService.AddOrModifyAzureAppTaskModel(appTaskModel);
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResult = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.Equal(errorMessage, validationResult);
        }
        private async Task<bool> TestDelete(int appTaskID)
        {
            var actionPostTVItemModelRes = await AzureAppTaskModelService.DeleteAzureAppTaskModel(appTaskID);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            return boolRet;
        }
        private async Task TestDeleteError(int AppTaskID, string errorMessage)
        {
            var actionPostTVItemModelRes = await AzureAppTaskModelService.DeleteAzureAppTaskModel(AppTaskID);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            List<ValidationResult> vrList = ((List<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(errorMessage)).Any());
        }
        private async Task TestDeleteUnauthorized(int AppTaskID, string errorMessage)
        {
            var actionPostTVItemModelRes = await AzureAppTaskModelService.DeleteAzureAppTaskModel(AppTaskID);
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResultList = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            var validationResult = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.Equal(errorMessage, validationResult);
        }
        private async Task<List<AppTaskModel>> TestGetAll()
        {
            var actionPostTVItemModelRes = await AzureAppTaskModelService.GetAllAzureAppTaskModel();
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            List<AppTaskModel> appTaskModelListRet = (List<AppTaskModel>)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(appTaskModelListRet);

            return await Task.FromResult(appTaskModelListRet);
        }
        private async Task TestGetAllUnauthorized(string errorMessage)
        {
            var actionPostTVItemModelRes = await AzureAppTaskModelService.GetAllAzureAppTaskModel();
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResultList = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            var validationResult = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.Equal(errorMessage, validationResult);
        }
    }
}
