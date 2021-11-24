namespace CSSPDBLocalServices;

public partial interface ICountryLocalService
{
    Task<ActionResult<TVItemModel>> AddCountryLocalAsync(int ParentTVItemID);
    Task<ActionResult<TVItemModel>> DeleteCountryLocalAsync(int TVItemID);
    Task<ActionResult<TVItemModel>> ModifyTVTextCountryLocalAsync(int TVItemID, string TVTextEN, string TVTextFR);
}
