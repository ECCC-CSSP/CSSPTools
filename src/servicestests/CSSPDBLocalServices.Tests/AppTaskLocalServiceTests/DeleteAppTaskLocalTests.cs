//namespace CSSPDBLocalServices.Tests;

//public partial class AppTaskLocalServiceTest : CSSPDBLocalServiceTest
//{
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteAppTaskModel_Good_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
//        AppTaskLocalModel appTaskModelRet = (AppTaskLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(appTaskModelRet);

//        actionPostTVItemModelRes = await AppTaskLocalService.DeleteAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
//        AppTaskLocalModel appTaskModelRet2 = (AppTaskLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(appTaskModelRet2);

//        Assert.Equal(JsonSerializer.Serialize<AppTaskLocalModel>(appTaskModelRet), JsonSerializer.Serialize<AppTaskLocalModel>(appTaskModelRet2));
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteAppTaskModel_Unauthorized_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

//        appTaskModel.AppTask.AppTaskID = 1000;

//        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

//        var actionPostTVItemModelRes = await AppTaskLocalService.DeleteAppTaskLocal(appTaskModel);
//        Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Contains(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), errRes.ErrList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteAppTaskLocal_AppTaskID_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 0;

//        var actionPostTVItemModelRes = await AppTaskLocalService.DeleteAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteAppTaskLocal_AppTask_Not_Found_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 100000;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskID = 100000;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID = 100000;
//        appTaskLocalModel.AppTaskLanguageList[1].AppTaskID = 100000;
//        appTaskLocalModel.AppTaskLanguageList[1].AppTaskLanguageID = 100000;

//        var actionPostTVItemModelRes = await AppTaskLocalService.DeleteAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskLocalModel.AppTask.AppTaskID.ToString()), errRes.ErrList[0]);
//    }
//}

