/* 
 *  Manually Edited
 *  
 */

using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPWebModels;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPAzureAppTaskServices.Tests
{
    public partial class AzureAppTaskServiceTest
    {
        private AppTaskLocalModel FillAppTaskModel()
        {
            AppTaskLocalModel postAppTaskModel = new AppTaskLocalModel();

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
                LastUpdateContactTVItemID = CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            };

            postAppTaskModel.AppTask = appTask;

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
                    LastUpdateContactTVItemID = CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                };

                postAppTaskModel.AppTaskLanguageList.Add(appTaskLanguage);
            }

            return postAppTaskModel;
        }
        private async Task<AppTaskLocalModel> TestAddOrModify(AppTaskLocalModel appTaskModel)
        {
            var actionPostTVItemModelRes = await AzureAppTaskService.AddOrModifyAzureAppTask(appTaskModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            AppTaskLocalModel appTaskModelRet = (AppTaskLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(appTaskModelRet);

            return await Task.FromResult(appTaskModelRet);
        }
        private async Task TestAddOrModifyError(AppTaskLocalModel appTaskModel, string errorMessage)
        {
            var actionPostTVItemModelRes = await AzureAppTaskService.AddOrModifyAzureAppTask(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
        }
        private async Task TestAddOrModifyUnauthorized(AppTaskLocalModel appTaskModel, string errorMessage)
        {
            var actionPostTVItemModelRes = await AzureAppTaskService.AddOrModifyAzureAppTask(appTaskModel);
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
        }
        private async Task<bool> TestDelete(int appTaskID)
        {
            var actionPostTVItemModelRes = await AzureAppTaskService.DeleteAzureAppTask(appTaskID);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            return boolRet;
        }
        private async Task TestDeleteError(int AppTaskID, string errorMessage)
        {
            var actionPostTVItemModelRes = await AzureAppTaskService.DeleteAzureAppTask(AppTaskID);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
        }
        private async Task TestDeleteUnauthorized(int AppTaskID, string errorMessage)
        {
            var actionPostTVItemModelRes = await AzureAppTaskService.DeleteAzureAppTask(AppTaskID);
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
        }
        private async Task<List<AppTaskLocalModel>> TestGetAll()
        {
            var actionPostTVItemModelRes = await AzureAppTaskService.GetAllAzureAppTask();
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            List<AppTaskLocalModel> appTaskModelListRet = (List<AppTaskLocalModel>)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(appTaskModelListRet);

            return await Task.FromResult(appTaskModelListRet);
        }
        private async Task TestGetAllUnauthorized(string errorMessage)
        {
            var actionPostTVItemModelRes = await AzureAppTaskService.GetAllAzureAppTask();
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
        }
    }
}
