namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
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

