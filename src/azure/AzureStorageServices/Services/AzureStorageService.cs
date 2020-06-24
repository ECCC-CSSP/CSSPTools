using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AzureStorageServices.Services
{
    public partial class AzureStorageService : IAzureStorageService
    {
        #region Variables
        #endregion Variables

        #region Properties
        IConfiguration Configuration { get; set; }
        #endregion Properties

        #region Constructors
        public AzureStorageService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            Console.WriteLine("Azure Blob storage v12 - .NET quickstart sample\n");

            string connectionString = Configuration.GetValue<string>("ConnectionString");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.WriteLine("ConnectionString from UserSecrets is empty");
                return await Task.FromResult(false);
            }

            string customerProvidedKey = Configuration.GetValue<string>("CustomerProvidedKey");
            if (string.IsNullOrWhiteSpace(customerProvidedKey))
            {
                Console.WriteLine("customerProvidedKey from UserSecrets is empty");
                return await Task.FromResult(false);
            }

            BlobClient blobClient = new BlobClient(connectionString, "csspfiles", "ASUSPAD - WIN_20150211_153537.JPG");

            Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

            FileInfo fi = new FileInfo(@"C:\Users\charl\OneDrive\Pictures\Camera Roll\ASUSPAD - WIN_20150211_153537.JPG");
            if (!fi.Exists)
            {
                Console.WriteLine($"File does not exist [{ fi.FullName }]");
                return await Task.FromResult(false);
            }

            using (FileStream uploadFileStream = fi.OpenRead())
            {
                await blobClient.UploadAsync(uploadFileStream, true);
            }


            var actionBlobProperties = await blobClient.GetPropertiesAsync( new BlobRequestConditions() { IfModifiedSince = DateTime.Now.AddSeconds(-2) });

            //FileInfo fiNew = new FileInfo(@"C:\Users\charl\OneDrive\Pictures\Camera Roll\New.JPG");
            //using (FileStream downloadFileStream = fiNew.Create())
            //{
            //    await blobClient.DownloadToAsync(downloadFileStream);
            //}


            //if (!await Upload())
            //{
            //    Console.WriteLine("Upload Error");
            //    return await Task.FromResult(false);
            //}

            //if (!await Download())
            //{
            //    Console.WriteLine("Download Error");
            //    return await Task.FromResult(false);
            //}

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}