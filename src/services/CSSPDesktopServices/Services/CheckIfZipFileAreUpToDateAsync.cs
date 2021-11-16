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
using Azure;
using Azure.Storage.Files.Shares.Models;

namespace CSSPDesktopServices.Services
{
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
                        return await Task.FromResult(true);
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

                //if (manageFile == null || blobProperties.ETag.ToString().Replace("\"", "") != manageFile.AzureETag)
                if (manageFile == null || shareFileProperties.ETag.ToString().Replace("\"", "") != manageFile.AzureETag)
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
}
