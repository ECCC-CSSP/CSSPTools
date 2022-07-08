namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    private async Task<bool> DownloadZipFilesFromAzure(string zipFileName)
    {
        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.DownloadingFileFromAzure_, zipFileName)));

        FileInfo fi = new FileInfo($"{ Configuration["CSSPDesktopPath"] }{ zipFileName }");

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(contact.AzureStoreHash), Configuration["AzureStoreCSSPWebAPIsLocalPath"]);
        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
        ShareFileClient shareFileClient = directory.GetFileClient(zipFileName);
        ShareFileProperties shareFileProperties = null;

        try
        {
            shareFileProperties = shareFileClient.GetProperties();
        }
        catch (RequestFailedException ex)
        {
            if (ex.Status == 404)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, Configuration["AzureStoreCSSPWebAPIsLocalPath"], zipFileName)));
                return await Task.FromResult(false);
            }
            else
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.UnmanagedServerError_, ex.Message)));
                return await Task.FromResult(false);
            }
        }

        if (shareFileProperties == null)
        {
            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, Configuration["AzureStoreCSSPWebAPIsLocalPath"], zipFileName)));
            return await Task.FromResult(false);
        }

        ManageFile manageFile = (from c in dbManage.ManageFiles
                                 where c.AzureStorage == Configuration["AzureStoreCSSPWebAPIsLocalPath"]
                                 && c.AzureFileName == zipFileName
                                 select c).FirstOrDefault();

        string eTag = shareFileProperties.ETag.ToString().Replace("\"", "");

        if (manageFile == null || eTag != manageFile.AzureETag)
        {
            ShareFileDownloadInfo download = shareFileClient.Download();
            using (FileStream stream = File.OpenWrite(fi.FullName))
            {
                download.Content.CopyTo(stream);
            }

            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Unzipping_, zipFileName)));
            if (!await UnzipDownloadedFileAsync(zipFileName, shareFileProperties)) return await Task.FromResult(false);
        }

        return await Task.FromResult(true);
    }
}

