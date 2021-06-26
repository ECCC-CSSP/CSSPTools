/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileServices
{
    public partial class FileService : ControllerBase, IFileService
    {
        private async Task<ActionResult> DoDownloadTempFile(string FileName)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            FileInfo fi = new FileInfo($"{CSSPTempFilesPath}\\{FileName}");

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
