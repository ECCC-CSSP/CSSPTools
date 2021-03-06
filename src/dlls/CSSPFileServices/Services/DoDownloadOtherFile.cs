﻿/*
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
        private async Task<ActionResult> DoDownloadOtherFile(string FileName)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            FileInfo fi = new FileInfo($"{CSSPOtherFilesPath}\\{FileName}");

            if (!fi.Exists)
            {
                return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.CouldNotFindFile_, fi.FullName)));
            }

            FileStream fileStream = fi.OpenRead();

            if (fileStream == null)
            {
                return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.CouldNotOpenFile_ForStreaming, fi.FullName)));
            }

            return File(fileStream, "application/octet-stream");
        }
    }
}
