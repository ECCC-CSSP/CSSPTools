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
    public partial class WebService : ControllerBase, IWebService
    {
        private async Task DoStore<T>(T webJson, string fileName)
        {
            if (StoreLocal)
            {
                FileInfo fiGZ = new FileInfo(LocalJSONPath + fileName);

                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson))))
                {
                    using (FileStream gzipTargetAsStream = fiGZ.Create())
                    {
                        using (GZipStream gzipStream = new GZipStream(gzipTargetAsStream, CompressionMode.Compress))
                        {
                            ms.CopyTo(gzipStream);
                        }
                    }
                }
            }

            if (StoreInAzure)
            {
                BlobClient blobClient = new BlobClient(AzureCSSPStorageConnectionString, AzureCSSPStorageCSSPJSON, fileName);

                await blobClient.UploadAsync(Compress(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson)))), true);
            }
        }
    }
}
