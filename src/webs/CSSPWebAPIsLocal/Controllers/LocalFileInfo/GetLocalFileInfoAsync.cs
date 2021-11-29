namespace CSSPWebAPIsLocal.Controllers;

public partial class LocalFileInfoController : ControllerBase, ILocalFileInfoController
{
    [Route("GetLocalFileInfo/{ParentTVItemID:int}/{FileName}")]
    [HttpGet]
    public async Task<ActionResult<LocalFileInfo>> GetLocalFileInfoAsync(int ParentTVItemID, string FileName)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        FileName = FileName.Replace(".mmdf", ".mdf");

        return await FileService.GetLocalFileInfoAsync(ParentTVItemID, FileName);
    }
}

