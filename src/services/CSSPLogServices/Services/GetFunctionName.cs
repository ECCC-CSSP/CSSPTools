namespace CSSPLogServices;

public partial class CSSPLogService : ControllerBase, ICSSPLogService
{
    public string GetFunctionName(string FullFunctionName)
    {
        string FunctionName = FullFunctionName;
        FunctionName = FunctionName.Substring(FunctionName.IndexOf("<") + 1);
        FunctionName = FunctionName.Substring(0, FunctionName.IndexOf(">"));

        return FunctionName;
    }
}

