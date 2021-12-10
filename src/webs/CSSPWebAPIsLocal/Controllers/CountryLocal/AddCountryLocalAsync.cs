namespace CSSPWebAPIsLocal.Controllers;

public partial class CountryLocalController : ControllerBase, ICountryLocalController
{
    [Route("{ParentTVItemID:int}")]
    [HttpPost]
    public async Task<ActionResult<TVItemModel>> AddCountryLocalAsync(int ParentTVItemID)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await CountryLocalService.AddCountryLocalAsync(ParentTVItemID);
    }
}

