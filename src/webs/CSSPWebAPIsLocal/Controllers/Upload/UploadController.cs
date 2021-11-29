namespace CSSPWebAPIsLocal.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
public partial class UploadController : Controller, IUploadController
{
    public UploadController()
    {
    }
}
