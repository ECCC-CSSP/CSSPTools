namespace CSSPCreateGzFileServices.Tests;

public partial class CSSPCreateGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteGzFiles_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await CSSPCreateGzFileService.DeleteGzFileAsync(WebTypeEnum.WebAllAddresses, 0);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteGzFiles_WebArea_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebArea;
        int TVItemID = 1000000;

        string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        var actionRes = await CSSPCreateGzFileService.DeleteGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(String.Format(CSSPCultureServicesRes.CouldNotFindFileNotDeletedAzureFile_, FileName), errRes.ErrList[0]);
    }
}

