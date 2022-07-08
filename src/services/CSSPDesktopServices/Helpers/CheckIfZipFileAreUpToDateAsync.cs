namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    private async Task<bool> CheckIfZipFileAreUpToDateAsync()
    {
        foreach (string zipFileName in await GetZipFileNameListAsync())
        {
            FileInfo fi = new FileInfo($"{ Configuration["CSSPDesktopPath"] }{ zipFileName }");

            ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(contact.AzureStoreHash), Configuration["AzureStoreCSSPWebAPIsLocalPath"]);
            ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
            ShareFileClient file = directory.GetFileClient(zipFileName);
            ShareFileProperties shareFileProperties = null;

            try
            {
                shareFileProperties = file.GetProperties();
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404)
                {
                    string error = string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, Configuration["AzureStoreCSSPWebAPIsLocalPath"], zipFileName);
                    AppendStatus(new AppendEventArgs(error));
                    CSSPLogService.AppendError(error);
                    return await Task.FromResult(false);
                }
            }

            if (shareFileProperties == null)
            {
                string error = string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, Configuration["AzureStoreCSSPWebAPIsLocalPath"], zipFileName);
                AppendStatus(new AppendEventArgs(error));
                CSSPLogService.AppendError(error);
                return await Task.FromResult(false);
            }

            ManageFile manageFile = (from c in dbManage.ManageFiles
                                     where c.AzureStorage == Configuration["AzureStoreCSSPWebAPIsLocalPath"]
                                     && c.AzureFileName == zipFileName
                                     select c).FirstOrDefault();

            string eTag = shareFileProperties.ETag.ToString().Replace("\"", "");

            if (manageFile == null || eTag != manageFile.AzureETag)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.AzureFile_Changed, zipFileName)));
                UpdateIsNeeded = true;
            }
            else
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.AzureFile_DidNotChanged, zipFileName)));
            }
        }

        return await Task.FromResult(false);
    }
}

