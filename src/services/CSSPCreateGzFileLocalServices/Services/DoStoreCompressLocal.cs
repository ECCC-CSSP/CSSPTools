/*
 * Manually edited
 * 
 */
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Compression;

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private Stream CompressLocal(Stream decompressed, CompressionLevel compressionLevel = CompressionLevel.Fastest)
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
