/*
 * Manually edited
 * 
 */
using Azure.Storage.Blobs;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<T> DoRead<T>(string fileName)
        {
            FileInfo fiGZ = new FileInfo(LocalJSONPath + fileName);

            if (!fiGZ.Exists)
            {
                return await Task.FromResult(JsonSerializer.Deserialize<T>(""));
            }

            using (FileStream gzipFileStream = fiGZ.OpenRead())
            {
                using (GZipStream gzStream = new GZipStream(gzipFileStream, CompressionMode.Decompress))
                {
                    using (StreamReader sr = new StreamReader(gzStream))
                    {
                        return await Task.FromResult(JsonSerializer.Deserialize<T>(sr.ReadToEnd()));
                    }
                }
            }
        }
    }
}
