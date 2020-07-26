using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService
    {
        private void DoCheckingInternetConnection()
        {
            HasInternetConnection = false;

            try
            {
                string AzureCSSPStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=csspstorage;AccountKey=DzzuCB7LovmJ5J5DssKRz58pCyBTjjBVnFE9j23eWo3FRRqXsF3X9vDZv/OHh63REYIQlEIkeFcRj29fl4w31Q==;EndpointSuffix=core.windows.net";

                BlobClient blobClient = new BlobClient(AzureCSSPStorageConnectionString, "csspjson", "WebRoot.gz");

                BlobDownloadInfo download = blobClient.Download();

                if (download.Details.ETag != null)
                {
                    HasInternetConnection = true;
                }
            }
            catch (Exception ex)
            {
                //AppendStatus(new AppendEventArgs(ex.Message));
            }
        }
    }
}
