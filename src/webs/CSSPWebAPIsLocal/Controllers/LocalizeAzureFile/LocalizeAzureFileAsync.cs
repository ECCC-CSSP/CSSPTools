namespace CSSPWebAPIsLocal.Controllers;

public partial class LocalizeAzureFileController : ControllerBase, ILocalizeAzureFileController
{
    [Route("{ParentTVItemID:int}/{FileName}")]
    [HttpGet]
    public async Task<ActionResult<bool>> LocalizeAzureFileAsync(int ParentTVItemID, string FileName)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        FileName = FileName.Replace(".mmdf", ".mdf");

        return await FileService.LocalizeAzureFileAsync(ParentTVItemID, FileName);
    }
}

