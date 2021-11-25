namespace CSSPLogServices;

public partial class CSSPLogService : ControllerBase, ICSSPLogService
{
    public async Task<ActionResult> EndFunctionReturnUnauthorized(string FunctionName, string ErrorText)
    {
        AppendError(ErrorText);
        EndFunctionLog(FunctionName);

        return await Task.FromResult(Unauthorized(ErrRes));
    }
}

