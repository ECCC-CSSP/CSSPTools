﻿using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPDesktopInstallPostBuildServices.Services
{
    public partial class CSSPDesktopInstallPostBuildService : ICSSPDesktopInstallPostBuildService
    {
        public async Task<bool> CSSPClientCompressAndSendToAzureAsync()
        {

            DirectoryInfo di = new DirectoryInfo(Configuration["CSSPClientPath"]);

            if (!di.Exists)
            {
                Console.WriteLine($"Directory not found [{ di.FullName }]");
                return await Task.FromResult(false);
            }

            FileInfo fi = new FileInfo(Configuration["CSSPClientZipFile"]);
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

            fi = new FileInfo(Configuration["CSSPClientZipFile"]);
            int countSeconds = 0;
            while (!fi.Exists)
            {
                Console.WriteLine($"Zip file does not exist [{ fi.FullName }]. Time elapse {countSeconds} seconds.");
                countSeconds += 1;
                Thread.Sleep(1000);

                fi = new FileInfo(Configuration["CSSPClientZipFile"]);
            }

            try
            {
                ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(contact.AzureStoreHash), Configuration["AzureStoreCSSPWebAPIsLocalPath"]);
                ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();

                ShareFileClient shareFileClient = directory.GetFileClient(fi.Name);

                Console.WriteLine($"Uploading file { fi.Name }");

                using (FileStream stream = File.OpenRead(fi.FullName))
                {
                    if (fi.Length != 0)
                    {

                        await shareFileClient.CreateAsync(stream.Length);
                        await shareFileClient.UploadAsync(stream);
                    }
                }

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
