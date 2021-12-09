namespace CSSPDBLocalServices.Tests;

public partial class AppTaskLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteAppTaskModel_Good_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        var actionAddRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(200, ((ObjectResult)actionAddRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionAddRes.Result).Value);
        AppTaskModel appTaskModelRet = (AppTaskModel)((OkObjectResult)actionAddRes.Result).Value;
        Assert.NotNull(appTaskModelRet);

        var actionDeleteRes = await AppTaskLocalService.DeleteAppTaskLocalAsync(appTaskModelRet.AppTask.AppTaskID);
        Assert.Equal(200, ((ObjectResult)actionDeleteRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionDeleteRes.Result).Value);
        AppTaskModel appTaskModelRet2 = (AppTaskModel)((OkObjectResult)actionDeleteRes.Result).Value;
        Assert.NotNull(appTaskModelRet2);

        Assert.Equal(JsonSerializer.Serialize<AppTaskModel>(appTaskModelRet), JsonSerializer.Serialize<AppTaskModel>(appTaskModelRet2));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteAppTaskModel_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        var actionAddRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(200, ((ObjectResult)actionAddRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionAddRes.Result).Value);
        AppTaskModel appTaskModelRet = (AppTaskModel)((OkObjectResult)actionAddRes.Result).Value;
        Assert.NotNull(appTaskModelRet);

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionDeleteRes = await AppTaskLocalService.DeleteAppTaskLocalAsync(appTaskModelRet.AppTask.AppTaskID);
        Assert.Equal(401, ((ObjectResult)actionDeleteRes.Result).StatusCode);
        Assert.NotNull(((UnauthorizedObjectResult)actionDeleteRes.Result).Value);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionDeleteRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteAppTaskModel_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        var actionAddRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(200, ((ObjectResult)actionAddRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionAddRes.Result).Value);
        AppTaskModel appTaskModelRet = (AppTaskModel)((OkObjectResult)actionAddRes.Result).Value;
        Assert.NotNull(appTaskModelRet);

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionDeleteRes = await AppTaskLocalService.DeleteAppTaskLocalAsync(appTaskModelRet.AppTask.AppTaskID);
        Assert.Equal(401, ((ObjectResult)actionDeleteRes.Result).StatusCode);
        Assert.NotNull(((UnauthorizedObjectResult)actionDeleteRes.Result).Value);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionDeleteRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteAppTaskLocal_AppTaskID_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        var actionAddRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(200, ((ObjectResult)actionAddRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionAddRes.Result).Value);
        AppTaskModel appTaskModelRet = (AppTaskModel)((OkObjectResult)actionAddRes.Result).Value;
        Assert.NotNull(appTaskModelRet);

        int AppTaskID = 0;

        var actionDeleteRes = await AppTaskLocalService.DeleteAppTaskLocalAsync(AppTaskID);
        Assert.Equal(400, ((ObjectResult)actionDeleteRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionDeleteRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionDeleteRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteAppTaskLocal_AppTask_Not_Found_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        var actionAddRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(200, ((ObjectResult)actionAddRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionAddRes.Result).Value);
        AppTaskModel appTaskModelRet = (AppTaskModel)((OkObjectResult)actionAddRes.Result).Value;
        Assert.NotNull(appTaskModelRet);

        int AppTaskID = 10000;

        var actionPostTVItemModelRes = await AppTaskLocalService.DeleteAppTaskLocalAsync(AppTaskID);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", AppTaskID.ToString()), errRes.ErrList[0]);
    }
}

