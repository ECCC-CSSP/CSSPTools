namespace CSSPDBLocalServices.Tests;

public partial class AppTaskLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_Good_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        AppTaskModel appTaskModelRet = (AppTaskModel)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(appTaskModelRet);

        Assert.Equal(1, (from c in dbLocal.AppTasks select c).Count());
        Assert.Equal(2, (from c in dbLocal.AppTaskLanguages select c).Count());

        Assert.Equal(-1, appTaskModelRet.AppTask.AppTaskID);
        Assert.Equal(DBCommandEnum.Created, appTaskModelRet.AppTask.DBCommand);
        Assert.Equal(appTaskLocalModel.AppTask.TVItemID, appTaskModelRet.AppTask.TVItemID);
        Assert.Equal(appTaskLocalModel.AppTask.TVItemID2, appTaskModelRet.AppTask.TVItemID2);
        Assert.Equal(appTaskLocalModel.AppTask.AppTaskCommand, appTaskModelRet.AppTask.AppTaskCommand);
        Assert.Equal(appTaskLocalModel.AppTask.AppTaskStatus, appTaskModelRet.AppTask.AppTaskStatus);
        Assert.Equal(appTaskLocalModel.AppTask.PercentCompleted, appTaskModelRet.AppTask.PercentCompleted);
        Assert.Equal(appTaskLocalModel.AppTask.Parameters, appTaskModelRet.AppTask.Parameters);
        Assert.Equal(appTaskLocalModel.AppTask.Language, appTaskModelRet.AppTask.Language);
        Assert.Equal(appTaskLocalModel.AppTask.StartDateTime_UTC, appTaskModelRet.AppTask.StartDateTime_UTC);
        Assert.Equal(appTaskLocalModel.AppTask.EndDateTime_UTC, appTaskModelRet.AppTask.EndDateTime_UTC);
        Assert.Equal(appTaskLocalModel.AppTask.EstimatedLength_second, appTaskModelRet.AppTask.EstimatedLength_second);
        Assert.Equal(appTaskLocalModel.AppTask.RemainingTime_second, appTaskModelRet.AppTask.RemainingTime_second);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, appTaskModelRet.AppTask.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < appTaskModelRet.AppTask.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > appTaskModelRet.AppTask.LastUpdateDate_UTC);

        Assert.Equal(-1, appTaskModelRet.AppTaskLanguageList[0].AppTaskLanguageID);
        Assert.Equal(DBCommandEnum.Created, appTaskModelRet.AppTaskLanguageList[0].DBCommand);
        Assert.Equal(-1, appTaskModelRet.AppTaskLanguageList[0].AppTaskID);
        Assert.Equal(LanguageEnum.en, appTaskModelRet.AppTaskLanguageList[0].Language);
        Assert.Equal(appTaskLocalModel.AppTaskLanguageList[0].StatusText, appTaskModelRet.AppTaskLanguageList[0].StatusText);
        Assert.Equal(appTaskLocalModel.AppTaskLanguageList[0].ErrorText, appTaskModelRet.AppTaskLanguageList[0].ErrorText);
        Assert.Equal(TranslationStatusEnum.Translated, appTaskModelRet.AppTaskLanguageList[0].TranslationStatus);

        Assert.Equal(-2, appTaskModelRet.AppTaskLanguageList[1].AppTaskLanguageID);
        Assert.Equal(DBCommandEnum.Created, appTaskModelRet.AppTaskLanguageList[1].DBCommand);
        Assert.Equal(-1, appTaskModelRet.AppTaskLanguageList[1].AppTaskID);
        Assert.Equal(LanguageEnum.fr, appTaskModelRet.AppTaskLanguageList[1].Language);
        Assert.Equal(appTaskLocalModel.AppTaskLanguageList[1].StatusText, appTaskModelRet.AppTaskLanguageList[1].StatusText);
        Assert.Equal(appTaskLocalModel.AppTaskLanguageList[1].ErrorText, appTaskModelRet.AppTaskLanguageList[1].ErrorText);
        Assert.Equal(TranslationStatusEnum.Translated, appTaskModelRet.AppTaskLanguageList[1].TranslationStatus);

        List<AppTask> appTaskLocalList = (from c in dbLocal.AppTasks
                                          select c).ToList();

        Assert.NotNull(appTaskLocalList);
        Assert.NotEmpty(appTaskLocalList);

        List<AppTaskLanguage> appTaskLanguageLocalList = (from c in dbLocal.AppTaskLanguages
                                                          orderby c.Language
                                                          select c).ToList();

        Assert.NotNull(appTaskLanguageLocalList);
        Assert.NotEmpty(appTaskLanguageLocalList);

        AppTaskModel appTaskLocalModelDB = new AppTaskModel()
        {
            AppTask = appTaskLocalList[0],
            AppTaskLanguageList = appTaskLanguageLocalList,
        };

        Assert.Equal(JsonSerializer.Serialize<AppTaskModel>(appTaskModelRet), JsonSerializer.Serialize<AppTaskModel>(appTaskLocalModelDB));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await AppTaskLocalService.ModifyAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((UnauthorizedObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await AppTaskLocalService.ModifyAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((UnauthorizedObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_AppTaskID_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTask.AppTaskID = 10;

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_TVItemID_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTask.TVItemID = 0;

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_TVItemID2_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTask.TVItemID2 = 0;

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_AppTaskCommand_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTask.AppTaskCommand = (AppTaskCommandEnum)10000;

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_AppTaskStatus_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTask.AppTaskStatus = (AppTaskStatusEnum)10000;

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_PercentCompeted_0_to_100_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTask.PercentCompleted = -1;

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PercentCompleted", "0", "100"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_Parameters_length_100000_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTask.Parameters = "a".PadRight(100001);

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Parameters", "100000"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_Language_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTask.Language = (LanguageEnum)10000;

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_StartDateTime_UTC_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTask.StartDateTime_UTC = new DateTime(1970, 1, 1);

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_EndDateTime_UTC_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTask.EndDateTime_UTC = new DateTime(1970, 1, 1);

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_StartDateTime_UTC_Bigger_Than_EndDateTime_UTC_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTask.EndDateTime_UTC = appTaskLocalModel.AppTask.StartDateTime_UTC.AddDays(-1);

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDateTime_UTC", "StartDateTime_UTC"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_AppTaskLanguage_CountNot2_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTaskLanguageList.Remove(appTaskLocalModel.AppTaskLanguageList[appTaskLocalModel.AppTaskLanguageList.Count - 1]);

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageList.Count", "2"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_AppTaskLanguage_EN_AppTaskLanguageID_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_AppTaskLanguage_EN_AppTaskID_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTaskLanguageList[0].AppTaskID = 1;

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_AppTaskLanguage_EN_StatusText_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTaskLanguageList[0].StatusText = "".PadLeft(251, 'a');

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_AppTaskLanguage_EN_ErrorText_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTaskLanguageList[0].ErrorText = "".PadLeft(251, 'a');

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_AppTaskLanguage_FR_AppTaskLanguageID_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_AppTaskLanguage_FR_AppTaskID_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTaskLanguageList[1].AppTaskID = 1;

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_AppTaskLanguage_FR_StatusText_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTaskLanguageList[1].StatusText = "".PadLeft(251, 'a');

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_AppTaskLanguage_FR_ErrorText_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        appTaskLocalModel.AppTaskLanguageList[1].ErrorText = "".PadLeft(251, 'a');

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250), errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAppTaskLocal_AlreayExist_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        AppTaskModel appTaskLocalModel = FillAppTaskLocalModel();

        var actionTVItemModelRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskLocalModel);
        Assert.Equal(200, ((ObjectResult)actionTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModelRes.Result).Value);
        AppTaskModel appTaskModelRet = (AppTaskModel)((OkObjectResult)actionTVItemModelRes.Result).Value;
        Assert.NotNull(appTaskModelRet);

        AppTaskModel appTaskModel2 = FillAppTaskLocalModel();

        var actionRes = await AppTaskLocalService.AddAppTaskLocalAsync(appTaskModel2);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Contains(string.Format(CSSPCultureServicesRes._AlreadyExists, "AppTask"), errRes.ErrList);
    }
}

