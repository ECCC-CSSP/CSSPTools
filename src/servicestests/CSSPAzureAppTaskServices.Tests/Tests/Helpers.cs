namespace CSSPAzureAppTaskServices.Tests;

public partial class CSSPAzureAppTaskServiceTest
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
    private async Task<AppTaskLocalModel> TestAddAsync(AppTaskLocalModel appTaskModel)
    {
        var actionPostTVItemModelRes = await AzureAppTaskService.AddAzureAppTaskAsync(appTaskModel);
        Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        AppTaskLocalModel appTaskModelRet = (AppTaskLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(appTaskModelRet);

        return await Task.FromResult(appTaskModelRet);
    }
    private async Task<AppTaskLocalModel> TestModifyAsync(AppTaskLocalModel appTaskModel)
    {
        var actionPostTVItemModelRes = await AzureAppTaskService.ModifyAzureAppTaskAsync(appTaskModel);
        Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        AppTaskLocalModel appTaskModelRet = (AppTaskLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(appTaskModelRet);

        return await Task.FromResult(appTaskModelRet);
    }
    private async Task TestAddErrorAsync(AppTaskLocalModel appTaskModel, string errorMessage)
    {
        var actionPostTVItemModelRes = await AzureAppTaskService.AddAzureAppTaskAsync(appTaskModel);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
    }
    private async Task TestModifyErrorAsync(AppTaskLocalModel appTaskModel, string errorMessage)
    {
        var actionPostTVItemModelRes = await AzureAppTaskService.ModifyAzureAppTaskAsync(appTaskModel);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
    }
    private async Task TestAddUnauthorizedAsync(AppTaskLocalModel appTaskModel, string errorMessage)
    {
        var actionPostTVItemModelRes = await AzureAppTaskService.AddAzureAppTaskAsync(appTaskModel);
        Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
    }
    private async Task TestModifyUnauthorizedAsync(AppTaskLocalModel appTaskModel, string errorMessage)
    {
        var actionPostTVItemModelRes = await AzureAppTaskService.AddAzureAppTaskAsync(appTaskModel);
        Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
    }
    private async Task<AppTaskLocalModel> TestDeleteAsync(int appTaskID)
    {
        var actionPostTVItemModelRes = await AzureAppTaskService.DeleteAzureAppTaskAsync(appTaskID);
        Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        AppTaskLocalModel appTaskLocalModel = (AppTaskLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(appTaskLocalModel);

        return appTaskLocalModel;
    }
    private async Task TestDeleteErrorAsync(int AppTaskID, string errorMessage)
    {
        var actionPostTVItemModelRes = await AzureAppTaskService.DeleteAzureAppTaskAsync(AppTaskID);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
    }
    private async Task TestDeleteUnauthorizedAsync(int AppTaskID, string errorMessage)
    {
        var actionPostTVItemModelRes = await AzureAppTaskService.DeleteAzureAppTaskAsync(AppTaskID);
        Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
    }
    private async Task<List<AppTaskLocalModel>> TestGetAllAsync()
    {
        var actionPostTVItemModelRes = await AzureAppTaskService.GetAllAzureAppTaskAsync();
        Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        List<AppTaskLocalModel> appTaskModelListRet = (List<AppTaskLocalModel>)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(appTaskModelListRet);

        return await Task.FromResult(appTaskModelListRet);
    }
    private async Task TestGetAllUnauthorizedAsync(string errorMessage)
    {
        var actionPostTVItemModelRes = await AzureAppTaskService.GetAllAzureAppTaskAsync();
        Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
    }
}

