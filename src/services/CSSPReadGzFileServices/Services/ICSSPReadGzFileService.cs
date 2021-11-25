namespace CSSPReadGzFileServices;

public interface ICSSPReadGzFileService
{
    Task<T> GetUncompressJSONAsync<T>(WebTypeEnum webType, int TVItemID = 0);
    Task<ActionResult<T>> ReadJSONAsync<T>(WebTypeEnum webType, int TVItemID = 0);
}

