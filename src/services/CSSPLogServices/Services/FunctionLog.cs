namespace CSSPLogServices;

public partial class CSSPLogService : ControllerBase, ICSSPLogService
{
    public void FunctionLog(string FunctionStr)
    {
        FunctionCount += 1;

        sbLog.AppendLine($"{ FunctionCount } - { DateTime.Now } - { CSSPCultureServicesRes.Start } - { FunctionStr }");
    }
}

