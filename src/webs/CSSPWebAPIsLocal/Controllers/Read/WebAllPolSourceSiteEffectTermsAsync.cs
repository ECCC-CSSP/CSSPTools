namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllPolSourceSiteEffectTerms")]
    [HttpGet]
    public async Task<ActionResult<WebAllPolSourceSiteEffectTerms>> WebAllPolSourceSiteEffectTermsAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllPolSourceSiteEffectTerms>(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
    }
}

