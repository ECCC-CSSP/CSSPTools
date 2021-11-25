namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    private async Task<bool> LogError1ArgsReturnFalseAsync(List<string> AllowableCSSPCommandNameList, string FunctionName)
    {
        CSSPLogService.AppendError($"{CSSPCultureServicesRes.AllowableCommandsAre}:");
        foreach (string CSSPCommandNameItem in AllowableCSSPCommandNameList)
        {
            CSSPLogService.AppendError($"CSSPUpdate.exe {CSSPCommandNameItem}");
        }
        CSSPLogService.FunctionLog(FunctionName);

        return await Task.FromResult(false);
    }
}
