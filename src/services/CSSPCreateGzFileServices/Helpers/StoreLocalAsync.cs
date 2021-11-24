namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> StoreLocalAsync<T>(T webJson, string fileName)
    {
        CSSPLogService.FunctionLog($"{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }<T>(T webJson, string fileName) -- fileName: { fileName }");

        FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ fileName }");

        if (fi.Exists)
        {
            try
            {
                fi.Delete();
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                CSSPLogService.AppendError($"{ ex.Message } { inner }");

                return await Task.FromResult(false);
            }
        }

        using (FileStream compressedFileStream = fi.Create())
        {
            Compress(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson)))).CopyTo(compressedFileStream);
            //new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson))).CopyTo(compressedFileStream);
        }

        CSSPLogService.EndFunctionLog($"{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }<T>(T webJson, string fileName) -- fileName: { fileName }");

        return await Task.FromResult(true);
    }
}

