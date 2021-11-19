using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using CSSPHelperModels;
using ManageServices;
using CSSPLocalLoggedInServices;
using CSSPCultureServices.Resources;
using CSSPScrambleServices;
using CSSPLogServices;
using System.Linq;
using System.IO;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure;

namespace CSSPDesktopServices.Services
{
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

            if (manageFile == null || shareFileProperties.ETag.ToString().Replace("\"", "") != manageFile.AzureETag)
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
}
