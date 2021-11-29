namespace CSSPWebAPIsLocal.Controllers;

public partial class TVItemLocalController : ControllerBase, ITVItemLocalController
{
    [HttpPost]
    public async Task<ActionResult<TVItemModel>> AddTVItemAsync(TVItemModel tvItemModel)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await Task.FromResult(Ok(new TVItemModel()));
        //return await TVItemService.AddTVItemLocal(postTVItemModel);
    }
}

