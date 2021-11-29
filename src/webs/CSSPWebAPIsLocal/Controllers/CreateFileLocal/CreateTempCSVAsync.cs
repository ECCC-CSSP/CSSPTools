namespace CSSPWebAPIsLocal.Controllers;

public partial class CreateFileController : ControllerBase, ICreateFileController
{
    [Route("CreateTempCSV")]
    [HttpPost]
    public async Task<ActionResult<bool>> CreateTempCSVAsync(TableConvertToCSVModel tableConvertToCSVModel)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await FileService.CreateTempCSVAsync(tableConvertToCSVModel);
    }
}

