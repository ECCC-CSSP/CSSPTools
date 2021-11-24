namespace CSSPDBLocalServices;

public partial interface ITVItemLocalService
{
    Task<ActionResult<TVItemModel>> AddTVItemLocalAsync(TVItem tvItemParent, TVTypeEnum tvType, string TVTextEN, string TVTextFR);
    Task<bool> AddTVItemParentLocalAsync(List<TVItemModel> tvItemModelParent);
    Task<ActionResult<TVItemModel>> DeleteTVItemLocalAsync(TVItem tvItemParent, TVItemModel tvItemModel);
    Task<ActionResult<TVItemModel>> ModifyTVTextLocalAsync(TVItem tvItemParent, TVItemModel tvItemModel);
}
