namespace CSSPWebAPIsLocal.Controllers;

public partial class CountryLocalController : ControllerBase, ICountryLocalController
{
    [HttpPut]
    public async Task<ActionResult<TVItemModel>> ModifyTVTextCountryLocalAsync(ttt obj)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await CountryLocalService.ModifyTVTextCountryLocalAsync(obj.TVItemID, obj.TVTextEN, obj.TVTextFR);
    }
}

