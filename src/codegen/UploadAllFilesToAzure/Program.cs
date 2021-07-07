using Azure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files;
using Azure.Storage.Files.Shares.Models;

namespace UploadAllFilesToAzure
{
    class Program
    {
        static void Main(string[] args)
        {
            int CountFileTotal = 0;
            int CountFileUploaded = 0;

            Console.WriteLine("Hello World!");

            Startup startup = new Startup();

            if (!startup.Setup()) return;

            DirectoryInfo di = new DirectoryInfo(@"E:\inetpub\wwwroot\csspwebtools\App_Data\");

            List<DirectoryInfo> diList = di.GetDirectories().ToList().Skip(0).Take(10000).ToList();

            int count = 0;
            foreach (DirectoryInfo d in diList)
            {
                count += 1;
                Console.WriteLine($"{ count } --- { d.FullName }");

                ShareClient shareClient = new ShareClient(startup.AzureStore, startup.AzureStoreCSSPFilesPath);
                ShareDirectoryClient directory = shareClient.GetDirectoryClient(d.Name);

                if (!directory.Exists())
                {
                    try
                    {
                        directory.Create();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ d.FullName } --- ERROR: { ex.Message }");
                        return;
                    }
                }

                Pageable<ShareFileItem> shareFileItemList = directory.GetFilesAndDirectories();

                List<FileInfo> fileInfoList = d.GetFiles().ToList();
                foreach (FileInfo fi in fileInfoList)
                {
                    CountFileTotal += 1;
                    Console.WriteLine($"\t\t File Count: {CountFileTotal} -- { fi.FullName }");


                    bool ShouldUpload = true;
                    foreach (ShareFileItem shareFileItem in shareFileItemList)
                    {
                        if (fi.Name == shareFileItem.Name)
                        {
                            if (fi.Length == shareFileItem.FileSize)
                            {
                                ShouldUpload = false;
                                break;
                            }
                        }
                    }

                    if (ShouldUpload)
                    {
                        try
                        {
                            ShareFileClient file = directory.GetFileClient(fi.Name);
                            using (FileStream stream = File.OpenRead(fi.FullName))
                            {
                                if (fi.Length != 0)
                                {
                                    file.Create(stream.Length);
                                    file.Upload(stream);

                                    CountFileUploaded += 1;
                                    Console.WriteLine($"\t\t File Updaloaded Count {CountFileUploaded} -- { fi.FullName }");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ fi.FullName } --- ERROR: { ex.Message }");
                            return;
                        }
                    }
                }
            }
        }
    }
}
