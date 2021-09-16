/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoStoreLocal<T>(T webJson, string fileName)
        {
            CSSPLogService.FunctionLog($"{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }<T>(T webJson, string fileName) -- fileName: { fileName }");

            FileInfo fi = new FileInfo($"{ config.CSSPJSONPathLocal }{ fileName }");

            if (fi.Exists)
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                    CSSPLogService.AppendError($"{ ex.Message } { inner }");

                    return await Task.FromResult(false);
                }
            }

            using (FileStream compressedFileStream = fi.Create())
            {
                Compress(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson)))).CopyTo(compressedFileStream);
                //new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson))).CopyTo(compressedFileStream);
            }

            CSSPLogService.EndFunctionLog($"{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }<T>(T webJson, string fileName) -- fileName: { fileName }");

            return await Task.FromResult(true);
        }
    }
}
