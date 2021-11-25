namespace CSSPLogServices;

public partial class CSSPLogService : ControllerBase, ICSSPLogService
{
    public async Task<ActionResult> EndFunctionReturnBadRequest(string FunctionName, string ErrorText)
    {
        AppendError(ErrorText);
        EndFunctionLog(FunctionName);

        return await Task.FromResult(BadRequest(ErrRes));
    }
}

