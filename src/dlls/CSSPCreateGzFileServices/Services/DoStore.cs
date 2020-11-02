/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task DoStore<T>(T webJson, string fileName)
        {
            BlobClient blobClient = new BlobClient(AzureStoreConnectionString, AzureStoreCSSPJSONPath, fileName);
            await blobClient.UploadAsync(Compress(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson)))), true);
            //BlobClient blobClient = new BlobClient(AzureStoreConnectionString, AzureStoreCSSPJSONPath, fileName.Replace("gz", "json"));
            //await blobClient.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson))), true);
        }
    }
}
