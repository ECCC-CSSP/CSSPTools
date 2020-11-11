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

namespace DownloadFileServices
{
    public partial class DownloadFileService : ControllerBase, IDownloadFileService
    {
        private async Task<ActionResult> DoDownloadFile(int ParentTVItemID, string FileName)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            FileInfo fi = new FileInfo($"{CSSPFilesPath}{ParentTVItemID}\\{FileName}");

            if (!fi.Exists)
            {
                var actionRes = await LocalizeAzureFile(ParentTVItemID, FileName);
                if (((ObjectResult)actionRes.Result).StatusCode != 200)
                {
                    return NotFound($"Could not localize Azure file [{fi.FullName}]");
                }
            }

            FileStream fileStream = fi.OpenRead();

            if (fileStream == null)
            {
                return NotFound($"Could not find file [{fi.FullName}]");
            }

            return File(fileStream, "application/octet-stream");
        }
    }
}
