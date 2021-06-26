/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files;
using Azure.Storage.Files.Shares.Models;
using CSSPWebModels;

namespace FileServices
{
    public partial class FileService : ControllerBase, IFileService
    {
        private async Task<ActionResult<LocalFileInfo>> DoGetAzureFileInfo(int ParentTVItemID, string FileName)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            ShareFileClient shareFileClient;
            ShareFileProperties shareFileProperties;
            try
            {
                ShareClient shareClient = new ShareClient(AzureStore, AzureStoreCSSPFilesPath);
                ShareDirectoryClient shareDirectoryClient = shareClient.GetDirectoryClient($"{ParentTVItemID}");
                shareFileClient = shareDirectoryClient.GetFileClient(FileName);
                shareFileProperties = shareFileClient.GetProperties();
            }
            catch (Exception ex)
            {
                string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerException: " + ex.InnerException.Message);
                return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.ErrorWhileTryingToGetAzureFileInfoFor_Error_, $"{ParentTVItemID}\\{FileName}", ErrorText)));
            }

            return await Task.FromResult(Ok(new LocalFileInfo() { FileName = FileName, Length = shareFileProperties.ContentLength }));
        }
    }
}
