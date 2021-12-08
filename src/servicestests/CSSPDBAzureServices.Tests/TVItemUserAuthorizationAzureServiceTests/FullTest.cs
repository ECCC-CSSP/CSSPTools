namespace CSSPDBAzureServices.Tests;

public partial class TVItemUserAuthorizationAzureServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Full_Good_Test(string culture)
    {
        Assert.True(await TVItemUserAuthorizationAzureServiceSetup(culture));

        var actionListRes = await TVItemUserAuthorizationAzureService.GetTVItemUserAuthorizationAzureWithContactTVItemIDAsync(1 /* is the number for ContactTVItemID use for testing */);
        Assert.Equal(200, ((ObjectResult)actionListRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionListRes.Result).Value);
        List<TVItemUserAuthorization> tvItemUserAuthorizationList = (List<TVItemUserAuthorization>)((OkObjectResult)actionListRes.Result).Value;
        Assert.NotNull(tvItemUserAuthorizationList);
        Assert.Empty(tvItemUserAuthorizationList);

        TVItemUserAuthorization tvItemUserAuthorization = await FillTVItemUserAuthorization();

        var actionRes = await TVItemUserAuthorizationAzureService.AddTVItemUserAuthorizationAzureAsync(tvItemUserAuthorization);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        TVItemUserAuthorization tvItemUserAuthorizationRet = (TVItemUserAuthorization)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(tvItemUserAuthorizationRet);
        Assert.Equal(1, tvItemUserAuthorizationRet.ContactTVItemID);

        actionListRes = await TVItemUserAuthorizationAzureService.GetTVItemUserAuthorizationAzureWithContactTVItemIDAsync(tvItemUserAuthorizationRet.ContactTVItemID);
        Assert.Equal(200, ((ObjectResult)actionListRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionListRes.Result).Value);
        tvItemUserAuthorizationList = (List<TVItemUserAuthorization>)((OkObjectResult)actionListRes.Result).Value;
        Assert.NotNull(tvItemUserAuthorizationList);
        Assert.NotEmpty(tvItemUserAuthorizationList);

        actionRes = await TVItemUserAuthorizationAzureService.DeleteTVItemUserAuthorizationAzureAsync(tvItemUserAuthorizationRet.TVItemUserAuthorizationID);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        tvItemUserAuthorizationRet = (TVItemUserAuthorization)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(tvItemUserAuthorizationRet);
        Assert.Equal(1, tvItemUserAuthorizationRet.ContactTVItemID);

        actionListRes = await TVItemUserAuthorizationAzureService.GetTVItemUserAuthorizationAzureWithContactTVItemIDAsync(tvItemUserAuthorizationRet.ContactTVItemID);
        Assert.Equal(200, ((ObjectResult)actionListRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionListRes.Result).Value);
        tvItemUserAuthorizationList = (List<TVItemUserAuthorization>)((OkObjectResult)actionListRes.Result).Value;
        Assert.NotNull(tvItemUserAuthorizationList);
        Assert.Empty(tvItemUserAuthorizationList);
    }
}

