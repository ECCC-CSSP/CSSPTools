using CSSPCultureServices.Resources;

namespace CSSPAzureLoginServices.Tests;

public partial class CSSPAzureLoginServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Login_Good_Test(string culture)
    {
        Assert.True(await CSSPAzureLoginServiceSetup(culture));

        LoginModel loginModel = new LoginModel()
        {
            LoginEmail = Configuration["LoginEmail"],
            Password = Configuration["Password"],
        };

        var actionRes = await CSSPAzureLoginService.AzureLoginAsync(loginModel);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        Assert.Empty(CSSPLogService.ErrRes.ErrList);

        Contact contact = new Contact();
        contact = (from c in dbManage.Contacts
                   select c).FirstOrDefault();
        Assert.NotNull(contact);

        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);
        Assert.Equal(contact.ContactTVItemID, CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Login_LoginEmail_Required_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureLoginServiceSetup(culture));

        LoginModel loginModel = new LoginModel()
        {
            LoginEmail = Configuration["LoginEmail"],
            Password = Configuration["Password"],
        };

        loginModel.LoginEmail = "";
        var actionRes = await CSSPAzureLoginService.AzureLoginAsync(loginModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "LoginEmail"), CSSPLogService.ErrRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Login_Password_Required_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureLoginServiceSetup(culture));

        LoginModel loginModel = new LoginModel()
        {
            LoginEmail = Configuration["LoginEmail"],
            Password = Configuration["Password"],
        };

        loginModel.Password = "";
        var actionRes = await CSSPAzureLoginService.AzureLoginAsync(loginModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "Password"), CSSPLogService.ErrRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Login_UnableToLogin_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureLoginServiceSetup(culture));

        LoginModel loginModel = new LoginModel()
        {
            LoginEmail = Configuration["LoginEmail"],
            Password = Configuration["Password"],
        };

        loginModel.LoginEmail = "WillNotWork" + loginModel.LoginEmail;
        var actionRes = await CSSPAzureLoginService.AzureLoginAsync(loginModel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail), CSSPLogService.ErrRes.ErrList[0]);
    }
}

