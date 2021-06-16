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
        private async Task<ActionResult<AzureFileInfo>> DoGetAzureFileInfo(int ParentTVItemID, string FileName)
        {
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
                return BadRequest($"Could not download file \\{ParentTVItemID}\\{FileName}. Ex: {ex.Message}");
            }

            return await Task.FromResult(Ok(new AzureFileInfo() { FileName = FileName, Length = shareFileProperties.ContentLength }));
        }
    }
}
