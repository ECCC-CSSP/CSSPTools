namespace CSSPCreateGzFileServices;

public interface ICSSPCreateGzFileService
{
    Task<ActionResult<bool>> CreateAllGzFilesAsync();
    Task<ActionResult<bool>> CreateGzFileAsync(WebTypeEnum webType, int TVItemID = 0);
    Task<ActionResult<bool>> DeleteGzFileAsync(WebTypeEnum webType, int TVItemID = 0);
    Task<ActionResult<bool>> SetLocal(bool local);
}
