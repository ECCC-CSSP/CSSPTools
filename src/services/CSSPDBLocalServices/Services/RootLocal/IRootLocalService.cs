namespace CSSPDBLocalServices;

public partial interface IRootLocalService
{
    Task<ActionResult<TVItemModel>> ModifyTVTextRootLocalAsync(string TVTextEN, string TVTextFR);
}
