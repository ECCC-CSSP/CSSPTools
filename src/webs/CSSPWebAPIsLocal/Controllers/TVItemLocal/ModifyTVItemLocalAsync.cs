namespace CSSPWebAPIsLocal.Controllers;

public partial class TVItemLocalController : ControllerBase, ITVItemLocalController
{
    [HttpPut]
    public async Task<ActionResult<TVItemModel>> ModifyTVItemAsync(TVItemModel tvItemModel)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await Task.FromResult(Ok(new TVItemModel()));
        //return await TVItemService.ModifyTVItemLocal(postTVItemModel);
    }
}

