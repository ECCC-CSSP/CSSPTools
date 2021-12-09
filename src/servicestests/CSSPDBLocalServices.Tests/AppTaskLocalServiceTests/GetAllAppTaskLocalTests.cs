namespace CSSPDBLocalServices.Tests;

public partial class AppTaskLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAllAppTaskLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await AppTaskLocalServiceSetupAsync(culture));

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionPostTVItemModelRes = await AppTaskLocalService.GetAllAppTaskLocalAsync();
        Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Contains(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), errRes.ErrList);
    }
}

