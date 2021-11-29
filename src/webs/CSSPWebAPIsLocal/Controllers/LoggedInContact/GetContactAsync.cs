namespace CSSPWebAPIsLocal.Controllers;

public partial class LoggedInContactController : ControllerBase, ILoggedInContactController
{
    [HttpGet]
    public async Task<ActionResult<Contact>> GetContactAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.PasswordHash = "";
        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.GoogleMapKeyHash = CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.GoogleMapKeyHash);
        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash = CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash);
        return await Task.FromResult(Ok(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact));
    }
}

