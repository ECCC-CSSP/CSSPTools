namespace CSSPDBAzureServices.Tests;

public partial class TVTypeUserAuthorizationAzureServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Full_Good_Test(string culture)
    {
        Assert.True(await TVTypeUserAuthorizationAzureServiceSetup(culture));

        var actionListRes = await TVTypeUserAuthorizationAzureService.GetTVTypeUserAuthorizationAzureWithContactTVItemIDAsync(1 /* is the number for ContactTVTypeID use for testing */);
        Assert.Equal(200, ((ObjectResult)actionListRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionListRes.Result).Value);
        List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = (List<TVTypeUserAuthorization>)((OkObjectResult)actionListRes.Result).Value;
        Assert.NotNull(tvTypeUserAuthorizationList);
        Assert.Empty(tvTypeUserAuthorizationList);

        TVTypeUserAuthorization tvTypeUserAuthorization = await FillTVTypeUserAuthorization();

        var actionRes = await TVTypeUserAuthorizationAzureService.AddTVTypeUserAuthorizationAzureAsync(tvTypeUserAuthorization);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        TVTypeUserAuthorization tvTypeUserAuthorizationRet = (TVTypeUserAuthorization)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(tvTypeUserAuthorizationRet);
        Assert.Equal(1, tvTypeUserAuthorizationRet.ContactTVItemID);

        actionListRes = await TVTypeUserAuthorizationAzureService.GetTVTypeUserAuthorizationAzureWithContactTVItemIDAsync(tvTypeUserAuthorizationRet.ContactTVItemID);
        Assert.Equal(200, ((ObjectResult)actionListRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionListRes.Result).Value);
        tvTypeUserAuthorizationList = (List<TVTypeUserAuthorization>)((OkObjectResult)actionListRes.Result).Value;
        Assert.NotNull(tvTypeUserAuthorizationList);
        Assert.NotEmpty(tvTypeUserAuthorizationList);

        actionRes = await TVTypeUserAuthorizationAzureService.DeleteTVTypeUserAuthorizationAzureAsync(tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        tvTypeUserAuthorizationRet = (TVTypeUserAuthorization)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(tvTypeUserAuthorizationRet);
        Assert.Equal(1, tvTypeUserAuthorizationRet.ContactTVItemID);

        actionListRes = await TVTypeUserAuthorizationAzureService.GetTVTypeUserAuthorizationAzureWithContactTVItemIDAsync(tvTypeUserAuthorizationRet.ContactTVItemID);
        Assert.Equal(200, ((ObjectResult)actionListRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionListRes.Result).Value);
        tvTypeUserAuthorizationList = (List<TVTypeUserAuthorization>)((OkObjectResult)actionListRes.Result).Value;
        Assert.NotNull(tvTypeUserAuthorizationList);
        Assert.Empty(tvTypeUserAuthorizationList);
    }
}

