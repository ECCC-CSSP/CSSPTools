namespace CSSPLogServices;

public partial class CSSPLogService : ControllerBase, ICSSPLogService
{
    public async Task<ActionResult> EndFunctionReturnOkTrue(string FunctionName)
    {
        EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}

