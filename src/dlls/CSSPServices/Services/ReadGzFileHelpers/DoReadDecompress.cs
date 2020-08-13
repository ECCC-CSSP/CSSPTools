/*
 * Manually edited
 * 
 */
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Compression;

namespace CSSPServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private Stream Decompress(Stream compressed)
        {
            MemoryStream decompressed = new MemoryStream();
            using (GZipStream gZip = new GZipStream(compressed, CompressionMode.Decompress, true))
            {
                gZip.CopyTo(decompressed);
            }

            decompressed.Seek(0, SeekOrigin.Begin);
            return decompressed;
        }
    }
}
