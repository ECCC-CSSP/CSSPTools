namespace CSSPWebAPIsLocal.Controllers;

public partial interface ICreateFileController
{
    Task<ActionResult<bool>> CreateTempCSVAsync(TableConvertToCSVModel tableConvertToCSVModel);
    Task<ActionResult<bool>> CreateTempPNGAsync();
}

