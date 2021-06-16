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
        private async Task<ActionResult<LocalFileInfo>> DoGetLocalFileInfo(string DirectoryPath, string FileName)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            DirectoryInfo di = new DirectoryInfo(DirectoryPath);

            if (!di.Exists)
            {
                return await Task.FromResult(Ok(new LocalFileInfo() { FileName = "", Length = 0 }));
            }

            FileInfo fi = new FileInfo($"{ DirectoryPath }{ FileName }");

            if (!fi.Exists)
            {
                return await Task.FromResult(Ok(new LocalFileInfo() { FileName = "", Length = 0 }));
            }

            return await Task.FromResult(Ok(new LocalFileInfo() { FileName = fi.Name, Length = fi.Length }));
        }
    }
}
