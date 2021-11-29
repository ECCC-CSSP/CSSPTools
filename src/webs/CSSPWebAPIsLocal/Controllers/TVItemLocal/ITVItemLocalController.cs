namespace CSSPWebAPIsLocal.Controllers;

public partial interface ITVItemLocalController
{
    Task<ActionResult<TVItemModel>> DeleteTVItemAsync(TVItemModel tvItemModel);
    Task<ActionResult<TVItemModel>> AddTVItemAsync(TVItemModel tvItemModel);
    Task<ActionResult<TVItemModel>> ModifyTVItemAsync(TVItemModel tvItemModel);
}
