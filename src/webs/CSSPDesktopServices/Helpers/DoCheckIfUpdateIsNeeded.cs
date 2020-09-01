using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using System.IO;
using Azure.Storage.Blobs.Models;
using CSSPDesktopServices.Models;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckIfUpdateIsNeeded()
        {
            AppendStatus(new AppendEventArgs(appTextModel.CheckIfUpdateIsNeeded));

            UpdateIsNeeded = false;

            if (preference.HasInternetConnection == null || (bool)preference.HasInternetConnection == false)
            {
                return await Task.FromResult(true);
            }

            // doing required file from csspwebapis container
            List<string> zipFileNameList = new List<string>()
            {
                "csspwebapis.zip", "csspclient.zip", "helpdocs.zip"
            };

            foreach (string zipFileName in zipFileNameList)
            {
                FileInfo fi = new FileInfo($"{ LocalCSSPDesktopPath }{ zipFileName }");

                BlobClient blobClient = new BlobClient(preference.AzureStore, AzureStoreCSSPWebAPIsPath, zipFileName);
                BlobProperties blobProperties = blobClient.GetProperties();
                if (blobProperties == null)
                {
                    AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotGetPropertiesFromAzureStore_AndFile_, "csspwebapis", zipFileName)));
                    return await Task.FromResult(false);
                }

                CSSPFile csspFile = (from c in dbFM.CSSPFiles
                                     where c.AzureStorage == "csspwebapis"
                                     && c.AzureFileName == zipFileName
                                     select c).FirstOrDefault();

                if (csspFile == null || blobProperties.ETag.ToString().Replace("\"", "") != csspFile.AzureETag)
                {
                    AppendStatus(new AppendEventArgs(string.Format(appTextModel.AzureFile_Changed, zipFileName)));
                    UpdateIsNeeded = true;
                }
                else
                {
                    AppendStatus(new AppendEventArgs(string.Format(appTextModel.AzureFile_DidNotChanged, zipFileName)));
                }
            }

            // doing required file from csspjson container
            List<string> jsonFileNameList = new List<string>()
            {
                "WebContact.gz", "WebHelpDoc.gz", "WebMWQMLookupMPN.gz", "WebPolSourceGrouping.gz",
                "WebReportType.gz", "WebRoot.gz", "WebTideLocation.gz", "WebTVItem.gz"
            };

            foreach (string jsonFileName in jsonFileNameList)
            {
                FileInfo fi = new FileInfo($"{ LocalCSSPDesktopPath }{ jsonFileName }");

                BlobClient blobClient = new BlobClient(preference.AzureStore, AzureStoreCSSPJSONPath, jsonFileName);
                BlobProperties blobProperties = blobClient.GetProperties();
                if (blobProperties == null)
                {
                    AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotGetPropertiesFromAzureStore_AndFile_, "csspjson", jsonFileName)));
                    return await Task.FromResult(false);
                }

                CSSPFile csspFile = (from c in dbFM.CSSPFiles
                                     where c.AzureStorage == "csspjson"
                                     && c.AzureFileName == jsonFileName
                                     select c).FirstOrDefault();

                if (csspFile == null || blobProperties.ETag.ToString().Replace("\"", "") != csspFile.AzureETag)
                {
                    AppendStatus(new AppendEventArgs(string.Format(appTextModel.AzureFile_Changed, jsonFileName)));
                    UpdateIsNeeded = true;
                }
                else
                {
                    AppendStatus(new AppendEventArgs(string.Format(appTextModel.AzureFile_DidNotChanged, jsonFileName)));
                }
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
