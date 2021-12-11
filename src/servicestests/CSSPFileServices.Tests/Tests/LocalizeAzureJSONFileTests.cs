namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LocalizeAzureJSONFile_Good_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

        string fileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        GetJsonGzFileFromAzure(fileName);

        SendJsonGzFileToAzure(fileName);

        var actionRes = await CSSPFileService.LocalizeAzureJSONFileAsync(fileName);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LocalizeAzureJSONFile_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

        string fileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await CSSPFileService.LocalizeAzureJSONFileAsync(fileName);
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LocalizeAzureJSONFile_ParentTVItemIDDoesNotExist_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

        string fileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        var actionRes = await CSSPFileService.LocalizeAzureJSONFileAsync(fileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LocalizeAzureJSONFile_FileNameDoesNotExist_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

        string fileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        var actionRes = await CSSPFileService.LocalizeAzureJSONFileAsync(fileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
}

