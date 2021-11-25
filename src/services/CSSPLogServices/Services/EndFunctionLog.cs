namespace CSSPLogServices;

public partial class CSSPLogService : ControllerBase, ICSSPLogService
{
    public void EndFunctionLog(string FunctionStr)
    {
        sbLog.AppendLine($"{ FunctionCount } - { DateTime.Now } -   { CSSPCultureServicesRes.End } - { FunctionStr }");

        FunctionCount -= 1;
    }
}

