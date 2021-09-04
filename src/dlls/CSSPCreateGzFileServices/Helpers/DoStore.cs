/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
            string FunctionName = $"{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }<T>(T webJson, string fileName) -- fileName: { fileName }";
            await CSSPLogService.FunctionLog(FunctionName);

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

            if (!FileExistInAzure)
            {
                FileInfo fi = new FileInfo($@"{config.azure_csspjson_backup_uncompress}{fileName.Replace("gz", "json")}");
                FileInfo fi2 = new FileInfo($@"{config.azure_csspjson_backup_uncompress}{fileName.Replace("gz", "json2")}");
                FileInfo fiComp = new FileInfo($@"{config.azure_csspjson_backup}\{fileName}");

                if (!fiComp.Exists)
                {
                    FileStream fsComp = new FileStream(fiComp.FullName, FileMode.Create);

                    Stream msComp = Compress(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson))));
                    msComp.CopyTo(fsComp);
                    msComp.Close();

                    fsComp.Close();

                    FileStream fs = new FileStream(fi.FullName, FileMode.Create);

                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson)));
                    ms.CopyTo(fs);
                    ms.Close();

                    fs.Close();

                    ShouldSendToAzure = true;
                }

                if (!ShouldSendToAzure)
                {
                    System.IO.File.Move(fi.FullName, fi2.FullName, true);

                    FileStream fsComp = new FileStream(fiComp.FullName, FileMode.Create);

                    Stream msComp = Compress(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson))));
                    msComp.CopyTo(fsComp);
                    msComp.Close();

                    fsComp.Close();

                    FileStream fs = new FileStream(fi.FullName, FileMode.Create);

                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson)));
                    ms.CopyTo(fs);
                    ms.Close();

                    fs.Close();
                }

                if (fi2.Exists)
                {
                    if (!FileCompare(fi.FullName, fi2.FullName))
                    {
                        ShouldSendToAzure = true;
                    }
                }

                if (fi2.Exists)
                {
                    fi2.Delete();
                }
            }

            if (ShouldSendToAzure || !FileExistInAzure)
            {
                //BlobClient blobClient = new BlobClient(config.AzureStore, config.AzureStoreCSSPJSONPath, fileName);
                await blobClient.UploadAsync(Compress(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson)))), true);

                //BlobClient blobClient = new BlobClient(AzureStore, AzureStoreCSSPJSONPath, fileName.Replace("gz", "json"));
                //await blobClient.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson))), true);
            }


            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
