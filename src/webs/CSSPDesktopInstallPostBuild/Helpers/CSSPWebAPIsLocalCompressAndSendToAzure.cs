using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPDesktopInstallPostBuild
{
    public partial class Startup
    {
        private async Task<bool> CSSPWebAPIsLocalCompressAndSendToAzure()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\CSSPTools\src\webs\CSSPWebAPIsLocal\bin\Release\net5.0\publish\");

            if (!di.Exists)
            {
                Console.WriteLine($"Directory not found [{ di.FullName }]");
                return await Task.FromResult(false);
            }

            FileInfo fi = new FileInfo($@"C:\CSSPTools\src\webs\CSSPWebAPIsLocal\bin\Release\net5.0\csspwebapislocal.zip");
            if (fi.Exists)
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not delete [{ fi.FullName }]. Exception: { ex.Message }");
                    return await Task.FromResult(false);
                }
            }

            ZipFile.CreateFromDirectory(di.FullName, fi.FullName);

            fi = new FileInfo($@"C:\CSSPTools\src\webs\CSSPWebAPIsLocal\bin\Release\net5.0\csspwebapislocal.zip");

            int countSeconds = 0;
            while (!fi.Exists)
            {
                Console.WriteLine($"Zip file does not exist [{ fi.FullName }]. Time elapse {countSeconds} seconds.");
                countSeconds += 1;
                Thread.Sleep(1000);

                fi = new FileInfo($@"C:\CSSPTools\src\webs\CSSPWebAPIsLocal\bin\Release\net5.0\csspwebapislocal.zip");
            }

            try
            {
                BlobClient blobClient = new BlobClient(AzureStore, AzureStoreCSSPWebAPIsLocalPath, fi.Name);
                Console.WriteLine($"Uploading file { fi.Name }");
                await blobClient.UploadAsync(fi.FullName, true);
                Console.WriteLine($"Uploaded file { fi.Name }");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not upload file to Azure [{ fi.FullName }]. Exception: { ex.Message }");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
