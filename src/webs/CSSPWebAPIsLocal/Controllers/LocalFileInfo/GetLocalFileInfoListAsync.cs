namespace CSSPWebAPIsLocal.Controllers;

public partial class LocalFileInfoController : ControllerBase, ILocalFileInfoController
{
    [Route("GetLocalFileInfoList/{ParentTVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoListAsync(int ParentTVItemID)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await FileService.GetLocalFileInfoListAsync(ParentTVItemID);
    }
}

