namespace CSSPWebAPIsLocal.Controllers;

public partial class CountryLocalController : ControllerBase, ICountryLocalController
{
    [Route("{TVItemID:int}")]
    [HttpDelete]
    public async Task<ActionResult<TVItemModel>> DeleteCountryLocalAsync(int TVItemID)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await CountryLocalService.DeleteCountryLocalAsync(TVItemID);
    }
}

