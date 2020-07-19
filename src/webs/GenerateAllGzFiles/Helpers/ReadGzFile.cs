/*
 * Manually edited
 * 
 */
using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace GenerateAllGzFiles
{
    public partial class Startup
    {
        private async Task<bool> ReadGzFile()
        {
            FileInfo fi = new FileInfo(@"C:\Users\charl\AppData\Roaming\cssp\csspjson\WebRoot.gz");

            if (!fi.Exists)
            {
                Console.WriteLine($"Can't find file [{fi.FullName}]");
                return await Task.FromResult(false);
            }

            string str = "";
            using (Stream stream = Decompress(fi.OpenRead()))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    str = sr.ReadToEnd();
                }
            }

            Console.WriteLine(str);

            return await Task.FromResult(true);
        }

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
