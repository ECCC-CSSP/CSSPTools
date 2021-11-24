//namespace CSSPDBLocalServices.Tests;

//public partial class AppTaskLocalServiceTest : CSSPDBLocalServiceTest
//{
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_Good_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

//        var actionTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
//        Assert.Equal(200, ((ObjectResult)actionTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((OkObjectResult)actionTVItemModelRes.Result).Value);
//        AppTaskLocalModel appTaskModelRet = (AppTaskLocalModel)((OkObjectResult)actionTVItemModelRes.Result).Value;
//        Assert.NotNull(appTaskModelRet);

//        string StatusText = "New Status Text";
//        string ErrorText = "New Error Text";

//        appTaskModelRet.AppTaskLanguageList[0].StatusText = StatusText;
//        appTaskModelRet.AppTaskLanguageList[0].ErrorText = ErrorText;
//        appTaskModelRet.AppTaskLanguageList[1].StatusText = StatusText;
//        appTaskModelRet.AppTaskLanguageList[1].ErrorText = ErrorText;

//        actionTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskModel);
//        Assert.Equal(200, ((ObjectResult)actionTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((OkObjectResult)actionTVItemModelRes.Result).Value);
//        appTaskModelRet = (AppTaskLocalModel)((OkObjectResult)actionTVItemModelRes.Result).Value;
//        Assert.NotNull(appTaskModelRet);

//        Assert.Equal(DBCommandEnum.Modified, appTaskModelRet.AppTask.DBCommand);
//        Assert.Equal(DBCommandEnum.Modified, appTaskModelRet.AppTaskLanguageList[0].DBCommand);
//        Assert.Equal(StatusText, appTaskModelRet.AppTaskLanguageList[0].StatusText);
//        Assert.Equal(ErrorText, appTaskModelRet.AppTaskLanguageList[0].ErrorText);
//        Assert.Equal(DBCommandEnum.Modified, appTaskModelRet.AppTaskLanguageList[1].DBCommand);
//        Assert.Equal(StatusText, appTaskModelRet.AppTaskLanguageList[1].StatusText);
//        Assert.Equal(ErrorText, appTaskModelRet.AppTaskLanguageList[1].ErrorText);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskModel_Unauthorized_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

//        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskModel);
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
//    public async Task ModifyAppTaskLocal_AppTaskID_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 0;

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
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
//    public async Task ModifyAppTaskLocal_AppTaskCommand_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTask.AppTaskCommand = (AppTaskCommandEnum)100000;

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_AppTaskStatus_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTask.AppTaskStatus = (AppTaskStatusEnum)100000;

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_Language_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTask.Language = (LanguageEnum)100000;

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_StartDateTime_UTC_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTask.StartDateTime_UTC = new DateTime(1970, 1, 1);

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_EndDateTime_UTC_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTask.EndDateTime_UTC = new DateTime(1970, 1, 1);

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_StartDateTime_UTC_Bigger_Than_EndDateTime_UTC_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTask.EndDateTime_UTC = appTaskLocalModel.AppTask.StartDateTime_UTC.AddDays(-1);

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDateTime_UTC", "StartDateTime_UTC"), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_AppTaskLanguage_Count_not_2_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList.Remove(appTaskLocalModel.AppTaskLanguageList[appTaskLocalModel.AppTaskLanguageList.Count - 1]);

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "appTaskModel.AppTaskLanguageList.Count", "2"), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_AppTaskLanguage_EN_AppTaskLanguageID_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID = 0;

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskLanguageID"), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_AppTaskLanguage_EN_AppTaskID_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskID = 0;

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
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
//    public async Task ModifyAppTaskLocal_AppTaskLanguage_EN_StatusText_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].StatusText = "".PadLeft(251, 'a');

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_AppTaskLanguage_EN_ErrorText_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].ErrorText = "".PadLeft(251, 'a');

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_AppTaskLanguage_FR_AppTaskLanguageID_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[1].AppTaskLanguageID = 0;

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskLanguageID"), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_AppTaskLanguage_FR_AppTaskID_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[1].AppTaskLanguageID = 10;
//        appTaskLocalModel.AppTaskLanguageList[1].AppTaskID = 0;

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
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
//    public async Task ModifyAppTaskLocal_AppTaskLanguage_FR_StatusText_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[1].AppTaskLanguageID = 10;
//        appTaskLocalModel.AppTaskLanguageList[1].AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[1].StatusText = "".PadLeft(251, 'a');

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_AppTaskLanguage_FR_ErrorText_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID = 10;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[1].AppTaskLanguageID = 10;
//        appTaskLocalModel.AppTaskLanguageList[1].AppTaskID = 10;
//        appTaskLocalModel.AppTaskLanguageList[1].ErrorText = "".PadLeft(251, 'a');

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250), errRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task ModifyAppTaskLocal_AppTask_Not_Found_Error_Test(string culture)
//    {
//        Assert.True(await AppTaskLocalServiceSetup(culture));

//        AppTaskLocalModel appTaskLocalModel = FillAppTaskLocalModel();

//        appTaskLocalModel.AppTask.AppTaskID = 100000;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskID = 100000;
//        appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID = 100000;
//        appTaskLocalModel.AppTaskLanguageList[1].AppTaskID = 100000;
//        appTaskLocalModel.AppTaskLanguageList[1].AppTaskLanguageID = 100000;

//        var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskLocalModel);
//        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.NotEmpty(errRes.ErrList);
//        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskLocalModel.AppTask.AppTaskID.ToString()), errRes.ErrList[0]);
//    }
//}

