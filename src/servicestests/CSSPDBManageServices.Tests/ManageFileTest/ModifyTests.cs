namespace ManageServices.Tests;

public partial class ManageFileServicesTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_Good_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        ManageFile manageFileModify = await ModifyTestAsync(manageFileAdd);
        Assert.NotNull(manageFileModify);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_manageFile_null_Error_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        manageFileAdd = null;

        var actionCommandLog = await ManageFileService.ModifyAsync(manageFileAdd);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "manageFile"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_ManageFileID_equal_0_Error_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        manageFileAdd.ManageFileID = 0;

        var actionCommandLog = await ManageFileService.ModifyAsync(manageFileAdd);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "ManageFileID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AzureStorage_empty_Error_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        manageFileAdd.AzureStorage = "";

        var actionCommandLog = await ManageFileService.ModifyAsync(manageFileAdd);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "AzureStorage"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AzureStorage_length_bigger_100_Error_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        manageFileAdd.AzureStorage = "a".PadRight(101);

        var actionCommandLog = await ManageFileService.ModifyAsync(manageFileAdd);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureStorage", "100"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AzureFileName_empty_Error_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        manageFileAdd.AzureFileName = "";

        var actionCommandLog = await ManageFileService.ModifyAsync(manageFileAdd);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "AzureFileName"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AzureFileName_length_bigger_100_Error_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        manageFileAdd.AzureFileName = "a".PadRight(201);

        var actionCommandLog = await ManageFileService.ModifyAsync(manageFileAdd);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureFileName", "200"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AzureETag_empty_Error_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        manageFileAdd.AzureETag = "";

        var actionCommandLog = await ManageFileService.ModifyAsync(manageFileAdd);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "AzureETag"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AzureCreationTimeUTC_Year_smaller_1980_Error_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        manageFileAdd.AzureCreationTimeUTC = new DateTime(1979, 1, 1);

        var actionCommandLog = await ManageFileService.ModifyAsync(manageFileAdd);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "AzureCreationTimeUTC", "1980"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_AlreadyExist_Error_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        manageFile = await FillManageFileAsync();
        manageFile.AzureStorage = "unique";

        ManageFile manageFileAdd2 = await AddTestAsync(manageFile);

        manageFileAdd2.AzureStorage = manageFileAdd.AzureStorage;

        var actionCommandLog = await ManageFileService.ModifyAsync(manageFileAdd2);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExistsWithDifferent_, "ManageFile", "ManageFileID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Modify_Could_notFind_Error_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        manageFileAdd.AzureStorage = "unique";
        manageFileAdd.ManageFileID = 10000;

        var actionCommandLog = await ManageFileService.ModifyAsync(manageFileAdd);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "ManageFileID", manageFileAdd.ManageFileID.ToString()), errRes.ErrList[0]);
    }
}

