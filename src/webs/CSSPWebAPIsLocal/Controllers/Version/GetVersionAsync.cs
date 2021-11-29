namespace CSSPWebAPIsLocal.Controllers;

public partial class VersionController : ControllerBase, IVersionController
{
    [HttpGet]
    public async Task<string> GetVersionAsync()
    {
        return await Task.FromResult("Version: 1.0.1.9");
    }
}

