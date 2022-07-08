namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    private async Task<bool> CheckIfJsonFileAreUpToDateAsync()
    {
        foreach (string jsonFileName in await GetJsonFileNameListAsync())
        {
            string enumTypeName = jsonFileName.Substring(0, jsonFileName.IndexOf("."));

            WebTypeEnum webType;

            foreach (int enumVal in Enum.GetValues(typeof(WebTypeEnum)))
            {

                if (((WebTypeEnum)enumVal).ToString() == enumTypeName)
                {
                    webType = (WebTypeEnum)enumVal;
                    break;
                }
            }

            FileInfo fi = new FileInfo($"{ Configuration["CSSPDesktopPath"] }{ jsonFileName }");

            ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(contact.AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
            ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
            ShareFileClient file = directory.GetFileClient(jsonFileName);
            ShareFileProperties shareFileProperties = null;

            try
            {
                shareFileProperties = file.GetProperties();
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404)
                {
                    string error = string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, Configuration["AzureStoreCSSPJsonPath"], jsonFileName);
                    AppendStatus(new AppendEventArgs(error));
                    CSSPLogService.AppendError(error);
                    return await Task.FromResult(false);
                }
            }

            if (shareFileProperties == null)
            {
                string error = string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, "csspjson", jsonFileName);
                AppendStatus(new AppendEventArgs(error));
                CSSPLogService.AppendError(error);
                return await Task.FromResult(false);
            }

            ManageFile manageFile = (from c in dbManage.ManageFiles
                                     where c.AzureStorage == "csspjson"
                                     && c.AzureFileName == jsonFileName
                                     select c).FirstOrDefault();

            string eTag = shareFileProperties.ETag.ToString().Replace("\"", "");

            if (manageFile == null || eTag != manageFile.AzureETag)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.AzureFile_Changed, jsonFileName)));
                UpdateIsNeeded = true;
            }
            else
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.AzureFile_DidNotChanged, jsonFileName)));
            }
        }

        return await Task.FromResult(false);
    }
}

