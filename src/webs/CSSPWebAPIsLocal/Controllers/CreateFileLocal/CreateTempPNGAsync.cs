namespace CSSPWebAPIsLocal.Controllers;

public partial class CreateFileController : ControllerBase, ICreateFileController
{
    [Route("CreateTempPNG")]
    [HttpPost]
    public async Task<ActionResult<bool>> CreateTempPNGAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await FileService.CreateTempPNGAsync(Request);
    }
}

