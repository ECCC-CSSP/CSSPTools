/*
 * Manually edited
 * 
 */
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class GzFileService : ControllerBase, IGzFileService
    {
        private async Task DoStore<T>(T webJson, string fileName)
        {
            BlobClient blobClient = new BlobClient(AzureCSSPStorageConnectionString, AzureCSSPStorageCSSPJSON, fileName);
            await blobClient.UploadAsync(Compress(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson)))), true);
        }
    }
}
