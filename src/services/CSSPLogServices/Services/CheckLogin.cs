namespace CSSPLogServices;

public partial class CSSPLogService : ControllerBase, ICSSPLogService
{
    public async Task<bool> CheckLogin(string FunctionName)
    {
        if (CSSPLocalLoggedInService.LoggedInContactInfo == null || CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            AppendError(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            EndFunctionLog(FunctionName);

            return await Task.FromResult(false);
        }

        return await Task.FromResult(true);
    }
}

