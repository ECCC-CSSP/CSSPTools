namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    public async Task<ActionResult<bool>> SetLocal(bool local)
    {
        Local = local;
        return await Task.FromResult(Ok(true));
    }
}

