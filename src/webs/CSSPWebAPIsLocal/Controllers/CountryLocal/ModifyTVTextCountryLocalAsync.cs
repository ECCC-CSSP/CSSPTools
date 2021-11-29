namespace CSSPWebAPIsLocal.Controllers;

public partial class CountryLocalController : ControllerBase, ICountryLocalController
{
    [HttpPut]
    public async Task<ActionResult<TVItemModel>> ModifyTVTextCountryLocalAsync(int TVItemID, string TVTextEN, string TVTextFR)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await CountryLocalService.ModifyTVTextCountryLocalAsync(TVItemID, TVTextEN, TVTextFR);
    }
}

