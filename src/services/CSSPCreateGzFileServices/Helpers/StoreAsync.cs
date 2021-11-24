namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> StoreAsync<T>(T webJson, string fileName)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }<T>(T webJson, string fileName) -- fileName: { fileName }";
        CSSPLogService.FunctionLog(FunctionName);

        bool ShouldSendToAzure = false;
        bool FileExistInAzure = true;

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();

        if (string.IsNullOrWhiteSpace(directory.ShareName))
        {
            CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.CouldNotFindDirectory_, Configuration["AzureStoreCSSPJsonPath"]) }");

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(false);
        }

        FileInfo fi = new FileInfo($@"{Configuration["azure_csspjson_backup_uncompress"]}{fileName.Replace("gz", "json")}");
        FileInfo fi2 = new FileInfo($@"{Configuration["azure_csspjson_backup_uncompress"]}{fileName.Replace("gz", "json2")}");
        FileInfo fiComp = new FileInfo($@"{Configuration["azure_csspjson_backup"]}\{fileName}");

        if (fi.Exists)
        {
            try
            {
                System.IO.File.Move(fi.FullName, fi2.FullName, true);
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                CSSPLogService.AppendError($"{ ex.Message } { inner }");
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }
        }

        try
        {
            FileStream fs = new FileStream(fi.FullName, FileMode.Create);
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson)));
            ms.CopyTo(fs);
            ms.Close();
            fs.Close();
        }
        catch (Exception ex)
        {
            string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
            CSSPLogService.AppendError($"{ ex.Message } { inner }");
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(false);
        }

        if (fi.Exists && fi2.Exists)
        {
            if (!FileCompare(fi.FullName, fi2.FullName))
            {
                ShouldSendToAzure = true;
            }
        }

        if (!fiComp.Exists || ShouldSendToAzure)
        {
            try
            {
                FileStream fsComp = new FileStream(fiComp.FullName, FileMode.Create);
                Stream msComp = Compress(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson))));
                msComp.CopyTo(fsComp);
                msComp.Close();
                fsComp.Close();
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                CSSPLogService.AppendError($"{ ex.Message } { inner }");
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            ShouldSendToAzure = true;
        }

        if (fi2.Exists)
        {
            try
            {
                fi2.Delete();
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                CSSPLogService.AppendError($"{ ex.Message } { inner }");
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }
        }

        if (ShouldSendToAzure || !FileExistInAzure)
        {
            fiComp = new FileInfo(fiComp.FullName);

            ShareFileClient file = directory.GetFileClient(fiComp.Name);

            using (FileStream stream = fiComp.OpenRead())
            {
                if (fiComp.Length != 0)
                {
                    file.Create(stream.Length);
                    file.Upload(stream);
                }
            }
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}

