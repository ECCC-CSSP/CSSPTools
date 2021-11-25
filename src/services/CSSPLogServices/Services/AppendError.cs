namespace CSSPLogServices;

public partial class CSSPLogService : ControllerBase, ICSSPLogService
{
    public void AppendError(string Err)
    {
        ErrRes.ErrList.Add(Err);

        string errorText = $"{CSSPCultureServicesRes.ERRORCap}: { Err }";

        Console.WriteLine($"\r{errorText}");

        sbLog.AppendLine($"    {errorText}");
        sbError.AppendLine(errorText);
    }
}

