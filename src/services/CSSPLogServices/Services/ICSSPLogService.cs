namespace CSSPLogServices;

public interface ICSSPLogService
{
    string CSSPAppName { get; set; }
    string CSSPCommandName { get; set; }
    StringBuilder sbError { get; set; }
    StringBuilder sbLog { get; set; }
    ErrRes ErrRes { get; set; }

    void AppendError(string Err);
    void AppendLog(string logText);
    Task<bool> CheckLogin(string FunctionName);
    void EndFunctionLog(string FullFunctionName);
    Task<ActionResult> EndFunctionReturnBadRequest(string FunctionName, string ErrorText);
    Task<ActionResult> EndFunctionReturnOkTrue(string FunctionName);
    Task<ActionResult> EndFunctionReturnUnauthorized(string FunctionName, string ErrorText);
    void FunctionLog(string FullFunctionName);
    string GetFunctionName(string FullFunctionName);
    Task<ActionResult> Save();
}

