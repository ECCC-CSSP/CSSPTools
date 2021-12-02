namespace CSSPAzureAppTaskServices.Tests;

public partial class CSSPAzureAppTaskServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_Good_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        List<AppTaskLocalModel> appTaskModelListRet = await TestGetAllAsync();
        Assert.Empty(appTaskModelListRet);

        // ----------- 
        // TestAddOrModify
        AppTaskLocalModel appTaskLocalModelRet = await TestAddAsync(appTaskModel);
        Assert.NotNull(appTaskLocalModelRet);
        Assert.NotNull(appTaskLocalModelRet.AppTask);
        Assert.NotEmpty(appTaskLocalModelRet.AppTaskLanguageList);


        appTaskModelListRet = await TestGetAllAsync();
        Assert.NotEmpty(appTaskModelListRet);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_Unauthorized_LoggedInContactInfo_null_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        CSSPServerLoggedInService.LoggedInContactInfo = null;

        await TestAddUnauthorizedAsync(appTaskModel, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_Unauthorized_LoggedInContact_null_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        await TestAddUnauthorizedAsync(appTaskModel, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTask_AppTaskID_Equal_0_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskID = 1;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_DBCommand_Required_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.DBCommand = (DBCommandEnum)10000;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_TVItemID_Required_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.TVItemID = 0;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_TVItemID2_Required_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.TVItemID2 = 0;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskCommand_Required_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskCommand = (AppTaskCommandEnum)10000;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskStatus_Required_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.AppTaskStatus = (AppTaskStatusEnum)10000;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_PercentCompleted_Required_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.PercentCompleted = -1;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "PercentCompleted"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_Language_Required_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.Language = (LanguageEnum)10000;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_StartDateTime_UTC_YearBigger1979_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.StartDateTime_UTC = new DateTime(1970, 1, 1);

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_EndDateTime_UTC_YearBigger1979_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTask.EndDateTime_UTC = new DateTime(1970, 1, 1);

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_CountNot2_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList.Remove(appTaskModel.AppTaskLanguageList[appTaskModel.AppTaskLanguageList.Count - 1]);

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "appTaskModel.AppTaskLanguageList.Count", "2"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_Language_en_notfound_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[0].Language = LanguageEnum.fr; // make 2 fr and no en

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_Language_fr_notfound_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[1].Language = LanguageEnum.en; // make 2 en and no fr

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "fr"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_en_AppTaskLanguageID_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_fr_AppTaskLanguageID_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = 1;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_en_AppTaskID_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_fr_AppTaskID_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[1].AppTaskID = 1;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_en_DBCommand_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[0].DBCommand = (DBCommandEnum)10000;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_fr_DBCommand_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[1].DBCommand = (DBCommandEnum)10000;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_en_Language_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[0].Language = (LanguageEnum)10000;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_fr_Language_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[1].Language = (LanguageEnum)10000;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "fr"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_en_StatusText_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[0].StatusText = "".PadLeft(251, 'a');

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_fr_StatusText_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[1].StatusText = "".PadLeft(251, 'a');

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_en_ErrorText_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[0].ErrorText = "".PadLeft(251, 'a');

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_fr_ErrorText_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[1].ErrorText = "".PadLeft(251, 'a');

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_en_TranslationStatus_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[0].TranslationStatus = (TranslationStatusEnum)10000;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppTaskLanguage_fr_TranslationStatus_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        appTaskModel.AppTaskLanguageList[1].TranslationStatus = (TranslationStatusEnum)10000;

        await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AlreayExist_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        List<AppTaskLocalModel> postAppTaskModelListRet = await TestGetAllAsync();
        Assert.Empty(postAppTaskModelListRet);

        AppTaskLocalModel postAppTaskModelRet = await TestAddAsync(appTaskModel);
        Assert.NotNull(postAppTaskModelRet);
        Assert.NotNull(postAppTaskModelRet.AppTask);
        Assert.NotEmpty(postAppTaskModelRet.AppTaskLanguageList);

        AppTaskLocalModel appTaskModel2 = FillAppTaskModel();
        await TestAddErrorAsync(appTaskModel2, string.Format(CSSPCultureServicesRes._AlreadyExists, "AppTask"));
    }
}

