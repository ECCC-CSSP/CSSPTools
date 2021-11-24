namespace CSSPCreateGzFileServices.Tests;

public partial class CSSPCreateGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateAllGzFiles_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await CSSPCreateGzFileService.CreateAllGzFilesAsync();
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
}

