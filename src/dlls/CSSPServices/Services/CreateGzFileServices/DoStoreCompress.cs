/*
 * Manually edited
 * 
 */
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Compression;

namespace CSSPServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private Stream Compress(Stream decompressed, CompressionLevel compressionLevel = CompressionLevel.Fastest)
        {
            MemoryStream compressed = new MemoryStream();
            using (GZipStream gZip = new GZipStream(compressed, compressionLevel, true))
            {
                decompressed.CopyTo(gZip);
            }

            compressed.Seek(0, SeekOrigin.Begin);
            return compressed;
        }
    }
}
