namespace CSSPDBAzureServices.Tests;

public partial class AppTaskAzureServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_Good_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        List<AppTaskModel> postAppTaskModelListRet = await TestGetAllAsync();
        Assert.Empty(postAppTaskModelListRet);

        AppTaskModel postAppTaskModelRet = await TestAddAsync(appTaskModel);
        Assert.NotNull(postAppTaskModelRet);
        Assert.NotNull(postAppTaskModelRet.AppTask);
        Assert.NotEmpty(postAppTaskModelRet.AppTaskLanguageList);

        string StatusText = "New Status Text";
        string ErrorText = "New Error Text";

        postAppTaskModelRet.AppTask.DBCommand = DBCommandEnum.Modified;
        postAppTaskModelRet.AppTaskLanguageList[0].DBCommand = DBCommandEnum.Modified;
        postAppTaskModelRet.AppTaskLanguageList[0].StatusText = StatusText;
        postAppTaskModelRet.AppTaskLanguageList[0].ErrorText = ErrorText;
        postAppTaskModelRet.AppTaskLanguageList[1].DBCommand = DBCommandEnum.Modified;
        postAppTaskModelRet.AppTaskLanguageList[1].StatusText = StatusText;
        postAppTaskModelRet.AppTaskLanguageList[1].ErrorText = ErrorText;

        AppTaskModel appTaskModelRet5 = await TestModifyAsync(postAppTaskModelRet);
        Assert.NotNull(postAppTaskModelRet);
        Assert.NotNull(postAppTaskModelRet.AppTask);
        Assert.NotEmpty(postAppTaskModelRet.AppTaskLanguageList);

        Assert.Equal(DBCommandEnum.Modified, appTaskModelRet5.AppTask.DBCommand);
        Assert.Equal(DBCommandEnum.Modified, appTaskModelRet5.AppTaskLanguageList[0].DBCommand);
        Assert.Equal(StatusText, appTaskModelRet5.AppTaskLanguageList[0].StatusText);
        Assert.Equal(ErrorText, appTaskModelRet5.AppTaskLanguageList[0].ErrorText);
        Assert.Equal(DBCommandEnum.Modified, appTaskModelRet5.AppTaskLanguageList[1].DBCommand);
        Assert.Equal(StatusText, appTaskModelRet5.AppTaskLanguageList[1].StatusText);
        Assert.Equal(ErrorText, appTaskModelRet5.AppTaskLanguageList[1].ErrorText);

        List<AppTaskModel> appTaskModelListRet = await TestGetAllAsync();
        Assert.NotEmpty(appTaskModelListRet);

        await TestDeleteAsync(postAppTaskModelRet.AppTask.AppTaskID);

        appTaskModelListRet = await TestGetAllAsync();
        Assert.Empty(appTaskModelListRet);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_Unauthorized_LoggedInContactInfo_null_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        CSSPServerLoggedInService.LoggedInContactInfo = null;

        await TestAddUnauthorizedAsync(appTaskModel, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_Unauthorized_LoggedInContact_null_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        await TestAddUnauthorizedAsync(appTaskModel, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTask_AppTaskID_Required_0_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_DBCommand_Required_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.DBCommand = (DBCommandEnum)10000;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_TVItemID_Required_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.TVItemID = 0;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_TVItemID2_Required_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.TVItemID2 = 0;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskCommand_Required_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskCommand = (AppTaskCommandEnum)10000;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskStatus_Required_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskStatus = (AppTaskStatusEnum)10000;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_PercentCompleted_Required_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.PercentCompleted = -1;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "PercentCompleted"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_Language_Required_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.Language = (LanguageEnum)10000;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_StartDateTime_UTC_YearBigger1979_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.StartDateTime_UTC = new DateTime(1970, 1, 1);

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_EndDateTime_UTC_YearBigger1979_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.EndDateTime_UTC = new DateTime(1970, 1, 1);

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_CountNot2_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList.Remove(appTaskModel.AppTaskLanguageList[appTaskModel.AppTaskLanguageList.Count - 1]);

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "appTaskModel.AppTaskLanguageList.Count", "2"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_Language_en_notfound_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[0].Language = LanguageEnum.fr; // make 2 fr and no en

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_Language_fr_notfound_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[1].Language = LanguageEnum.en; // make 2 en and no fr

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "fr"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_en_AppTaskLanguageID_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskID = 1;

        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 0;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskLanguageID"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_fr_AppTaskLanguageID_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskID = 1;

        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 0;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskLanguageID"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_en_AppTaskID_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[0].AppTaskID = 0;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_fr_AppTaskID_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[1].AppTaskID = 0;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_en_DBCommand_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskID = 1;

        appTaskModel.AppTaskLanguageList[0].DBCommand = (DBCommandEnum)10000;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_fr_DBCommand_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskID = 1;

        appTaskModel.AppTaskLanguageList[1].DBCommand = (DBCommandEnum)10000;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_en_Language_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskID = 1;

        appTaskModel.AppTaskLanguageList[0].Language = (LanguageEnum)10000;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_fr_Language_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskID = 1;

        appTaskModel.AppTaskLanguageList[1].Language = (LanguageEnum)10000;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "fr"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_en_StatusText_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskID = 1;

        appTaskModel.AppTaskLanguageList[0].StatusText = "".PadLeft(251, 'a');

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_fr_StatusText_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskID = 1;
        
        appTaskModel.AppTaskLanguageList[1].StatusText = "".PadLeft(251, 'a');

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_en_ErrorText_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskID = 1;

        appTaskModel.AppTaskLanguageList[0].ErrorText = "".PadLeft(251, 'a');

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_fr_ErrorText_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskID = 1;

        appTaskModel.AppTaskLanguageList[1].ErrorText = "".PadLeft(251, 'a');

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_en_TranslationStatus_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskID = 1;

        appTaskModel.AppTaskLanguageList[0].TranslationStatus = (TranslationStatusEnum)10000;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AppTaskLanguage_fr_TranslationStatus_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;
        appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;
        appTaskModel.AppTaskLanguageList[1].AppTaskID = 1;

        appTaskModel.AppTaskLanguageList[1].TranslationStatus = (TranslationStatusEnum)10000;

        await TestModifyErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_CouldNotFind_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        AppTaskModel appTaskModelRet = await TestAddAsync(appTaskModel);

        int AppTaskIDToDelete = appTaskModelRet.AppTask.AppTaskID;

        AppTaskModel appTaskModel2 = FillAppTaskModel();
        appTaskModel2.AppTask.AppTaskID = -1;
        appTaskModel2.AppTaskLanguageList[0].AppTaskLanguageID = -1;
        appTaskModel2.AppTaskLanguageList[1].AppTaskLanguageID = -1;
        appTaskModel2.AppTaskLanguageList[0].AppTaskID = -1;
        appTaskModel2.AppTaskLanguageList[1].AppTaskID = -1;
        await TestModifyErrorAsync(appTaskModel2, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskModel2.AppTask.AppTaskID.ToString()));
    }
}

