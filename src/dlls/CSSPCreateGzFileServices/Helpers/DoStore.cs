/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
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
        private async Task<bool> DoStore<T>(T webJson, string fileName)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }<T>(T webJson, string fileName) -- fileName: { fileName }";
            CSSPLogService.FunctionLog(FunctionName);

            bool ShouldSendToAzure = false;
            bool FileExistInAzure = true;

            BlobClient blobClient = new BlobClient(config.AzureStore, config.AzureStoreCSSPJSONPath, fileName);
            BlobProperties blobProperties = null;

            try
            {
                blobProperties = blobClient.GetProperties();
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404)
                {
                    FileExistInAzure = false;
                }
            }

            if (blobProperties == null)
            {
                FileExistInAzure = false;
            }

            FileInfo fi = new FileInfo($@"{config.azure_csspjson_backup_uncompress}{fileName.Replace("gz", "json")}");
            FileInfo fi2 = new FileInfo($@"{config.azure_csspjson_backup_uncompress}{fileName.Replace("gz", "json2")}");
            FileInfo fiComp = new FileInfo($@"{config.azure_csspjson_backup}\{fileName}");

            if (fi.Exists)
            {
                try
                {
                    System.IO.File.Move(fi.FullName, fi2.FullName, true);
                }
                catch (Exception ex)
                {
                    string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                    CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                    CSSPLogService.EndFunctionLog(FunctionName);
                    return await Task.FromResult(false);
                }
            }

            try
            {
                FileStream fs = new FileStream(fi.FullName, FileMode.Create);
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson)));
                ms.CopyTo(fs);
                ms.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            if (fi.Exists && fi2.Exists)
            {
                if (!FileCompare(fi.FullName, fi2.FullName))
                {
                    ShouldSendToAzure = true;
                }
            }

            if (!fiComp.Exists || ShouldSendToAzure)
            {
                try
                {
                    FileStream fsComp = new FileStream(fiComp.FullName, FileMode.Create);
                    Stream msComp = Compress(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson))));
                    msComp.CopyTo(fsComp);
                    msComp.Close();
                    fsComp.Close();
                }
                catch (Exception ex)
                {
                    string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                    CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                    CSSPLogService.EndFunctionLog(FunctionName);
                    return await Task.FromResult(false);
                }

                ShouldSendToAzure = true;
            }

            if (fi2.Exists)
            {
                try
                {
                    fi2.Delete();
                }
                catch (Exception ex)
                {
                    string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                    CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                    CSSPLogService.EndFunctionLog(FunctionName);
                    return await Task.FromResult(false);
                }
            }

            if (ShouldSendToAzure || !FileExistInAzure)
            {
                try
                {
                    await blobClient.UploadAsync(Compress(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson)))), true);
                }
                catch (Exception ex)
                {
                    string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                    CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                    CSSPLogService.EndFunctionLog(FunctionName);
                    return await Task.FromResult(false);
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
