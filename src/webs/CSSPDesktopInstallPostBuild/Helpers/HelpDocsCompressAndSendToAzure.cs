//using Azure.Storage.Blobs;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.IO.Compression;
//using System.Text;
//using System.Threading.Tasks;

//namespace CSSPDesktopInstallPostBuild
//{
//    public partial class Startup
//    {
//        private async Task<bool> HelpDocsCompressAndSendToAzure()
//        {
//            DirectoryInfo di = new DirectoryInfo(@"C:\CSSPTools\src\webs\CSSPDesktop\helpdocs\");

//            if (!di.Exists)
//            {
//                Console.WriteLine($"Directory not found [{ di.FullName }]");
//                return await Task.FromResult(false);
//            }

//            FileInfo fi = new FileInfo($@"C:\CSSPTools\src\webs\CSSPDesktop\helpdocs.zip");
//            if (fi.Exists)
//            {
//                try
//                {
//                    fi.Delete();
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Could not delete [{ fi.FullName }]. Exception: { ex.Message }");
//                    return await Task.FromResult(false);
//                }
//            }

//            ZipFile.CreateFromDirectory(di.FullName, fi.FullName);

//            fi = new FileInfo($@"C:\CSSPTools\src\webs\CSSPDesktop\helpdocs.zip");

//            if (!fi.Exists)
//            {
//                Console.WriteLine($"Zip file does not exist [{ fi.FullName }]");
//                return await Task.FromResult(false);
//            }

//            try
//            {
//                BlobClient blobClient = new BlobClient(AzureStoreConnectionString, AzureStoreCSSPWebAPIsLocalPath, fi.Name);
//                await blobClient.UploadAsync(fi.FullName, true);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Could not upload file to Azure [{ fi.FullName }]. Exception: { ex.Message }");
//                return await Task.FromResult(false);
//            }

//            return await Task.FromResult(true);
//        }
//    }
//}
