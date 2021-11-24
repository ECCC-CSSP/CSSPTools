namespace CSSPDBLocalServices;

public partial interface IProvinceLocalService
{
    Task<ActionResult<TVItemModel>> AddProvinceLocalAsync(int ParentTVItemID);
    Task<ActionResult<TVItemModel>> DeleteProvinceLocalAsync(int ParentTVItemID, int TVItemID);
    Task<ActionResult<TVItemModel>> ModifyTVTextProvinceLocalAsync(int ParentTVItemID, int TVItemID, string TVTextEN, string TVTextFR);
}
