namespace CSSPWebAPIsLocal.Controllers;

public partial class TVItemLocalController : ControllerBase, ITVItemLocalController
{
    [HttpDelete]
    public async Task<ActionResult<TVItemModel>> DeleteTVItemAsync(TVItemModel tvItemModel)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await Task.FromResult(Ok(new TVItemModel()));

        //return await TVItemService.DeleteTVItemLocal(postTVItemModel);
    }
}

