namespace CSSPWebAPIsLocal.Controllers;

public partial interface IUploadController
{
    Task<IActionResult> UploadAsync();
}
