namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    public async Task<T> GetUncompressJSONAsync<T>(WebTypeEnum webType, int TVItemID = 0)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum: { webType }, TVItemID: { TVItemID })";
        CSSPLogService.FunctionLog(FunctionName);

        // might need to implement the check for unauthorized
        //if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        var actionRes = await ReadJSONAsync<T>(webType, TVItemID);

        CSSPLogService.EndFunctionLog(FunctionName);

        if (CSSPLogService.ErrRes.ErrList.Count > 0)
        {
            return await Task.FromResult(JsonSerializer.Deserialize<T>("{}"));
        }

        return (T)((OkObjectResult)actionRes.Result).Value;
    }
}

