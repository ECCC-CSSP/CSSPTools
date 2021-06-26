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
        private async Task<ActionResult<List<LocalFileInfo>>> DoGetLocalFileInfoList(int ParentTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalFileInfo> LocalFileList = new List<LocalFileInfo>();

            DirectoryInfo di = new DirectoryInfo($"{CSSPFilesPath}{ParentTVItemID}\\");

            if (!di.Exists)
            {
                return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.CouldNotFindDirectory_, di.FullName)));
            }

            List<FileInfo> FileInfoList = di.GetFiles().ToList();

            foreach (FileInfo fi in FileInfoList)
            {
                LocalFileList.Add(new LocalFileInfo() { FileName = fi.Name, Length = fi.Length });
            }

            return await Task.FromResult(Ok(LocalFileList));
        }
    }
}