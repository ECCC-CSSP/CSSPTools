using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ManageServices;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckIfUpdateIsNeeded()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckIfUpdateIsNeeded));

            UpdateIsNeeded = false;


            if (contact.HasInternetConnection == null || !(bool)contact.HasInternetConnection)
            {
                return await Task.FromResult(true);
            }

            // doing required file from csspwebapislocal container
            List<string> zipFileNameList = new List<string>()
            {
                "csspwebapislocal.zip", "csspclient.zip", "csspotherfiles.zip"
            };

            foreach (string zipFileName in zipFileNameList)
            {
                FileInfo fi = new FileInfo($"{ Configuration["CSSPDesktopPath"] }{ zipFileName }");

                ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
                ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();

                ShareFileClient file = directory.GetFileClient(zipFileName);

                ShareFileProperties shareFileProperties = null;

                //BlobClient blobClient = new BlobClient(CSSPScrambleService.Descramble(AzureStoreHash), Configuration["AzureStoreCSSPWebAPIsLocalPath"], zipFileName);
                //BlobProperties blobProperties = null;

                try
                {
                    shareFileProperties = file.GetProperties();
                    //blobProperties = blobClient.GetProperties();
                }
                catch (RequestFailedException ex)
                {
                    if (ex.Status == 404)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, Configuration["AzureStoreCSSPWebAPIsLocalPath"], zipFileName)));
                        return await Task.FromResult(false);
                    }
                }

                //if (blobProperties == null)
                if (shareFileProperties == null)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, Configuration["AzureStoreCSSPWebAPIsLocalPath"], zipFileName)));
                    return await Task.FromResult(false);
                }

                ManageFile manageFile = (from c in dbManage.ManageFiles
                                         where c.AzureStorage == Configuration["AzureStoreCSSPWebAPIsLocalPath"]
                                         && c.AzureFileName == zipFileName
                                         select c).FirstOrDefault();

                //if (manageFile == null || blobProperties.ETag.ToString().Replace("\"", "") != manageFile.AzureETag)
                if (manageFile == null || shareFileProperties.ETag.ToString().Replace("\"", "") != manageFile.AzureETag)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.AzureFile_Changed, zipFileName)));
                    UpdateIsNeeded = true;
                }
                else
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.AzureFile_DidNotChanged, zipFileName)));
                }
            }

            // doing required file from csspjson container
            List<string> jsonFileNameList = new List<string>()
            {
                $"{ WebTypeEnum.WebAllAddresses }.gz",
                $"{ WebTypeEnum.WebAllContacts }.gz",
                $"{ WebTypeEnum.WebAllCountries }.gz",
                $"{ WebTypeEnum.WebAllEmails }.gz",
                $"{ WebTypeEnum.WebAllHelpDocs }.gz",
                $"{ WebTypeEnum.WebAllMunicipalities }.gz",
                $"{ WebTypeEnum.WebAllMWQMAnalysisReportParameters }.gz",
                $"{ WebTypeEnum.WebAllMWQMLookupMPNs }.gz",
                $"{ WebTypeEnum.WebAllMWQMSubsectors }.gz",
                $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz",
                $"{ WebTypeEnum.WebAllPolSourceSiteEffectTerms }.gz",
                $"{ WebTypeEnum.WebAllProvinces }.gz",
                $"{ WebTypeEnum.WebAllReportTypes }.gz",
                $"{ WebTypeEnum.WebRoot }.gz",
                $"{ WebTypeEnum.WebAllSearch }.gz",
                $"{ WebTypeEnum.WebAllTels }.gz",
                $"{ WebTypeEnum.WebAllTideLocations }.gz",
                $"{ WebTypeEnum.WebAllUseOfSites }.gz",
            };

            foreach (string jsonFileName in jsonFileNameList)
            {
                string enumTypeName = jsonFileName.Substring(0, jsonFileName.IndexOf("."));

                WebTypeEnum webType;

                foreach (int enumVal in Enum.GetValues(typeof(WebTypeEnum)))
                {

                    if (((WebTypeEnum)enumVal).ToString() == enumTypeName)
                    {
                        webType = (WebTypeEnum)enumVal;
                        break;
                    }
                }

                FileInfo fi = new FileInfo($"{ Configuration["CSSPDesktopPath"] }{ jsonFileName }");

                ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
                ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();

                ShareFileClient file = directory.GetFileClient(jsonFileName);

                ShareFileProperties shareFileProperties = null;

                //BlobClient blobClient = new BlobClient(CSSPScrambleService.Descramble(AzureStoreHash), Configuration["AzureStoreCSSPJSONPath"], jsonFileName);
                //BlobProperties blobProperties = null;

                try
                {
                    shareFileProperties = file.GetProperties();
                    //blobProperties = blobClient.GetProperties();
                }
                catch (RequestFailedException ex)
                {
                    if (ex.Status == 404)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, Configuration["AzureStoreCSSPWebAPIsLocalPath"], jsonFileName)));
                        UpdateIsNeeded = true;
                        return await Task.FromResult(true);
                    }
                }

                //if (blobProperties == null)
                if (shareFileProperties == null)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, "csspjson", jsonFileName)));
                    UpdateIsNeeded = true;
                    return await Task.FromResult(true);
                }

                ManageFile manageFile = (from c in dbManage.ManageFiles
                                         where c.AzureStorage == "csspjson"
                                         && c.AzureFileName == jsonFileName
                                         select c).FirstOrDefault();

                //if (manageFile == null || blobProperties.ETag.ToString().Replace("\"", "") != manageFile.AzureETag)
                if (manageFile == null || shareFileProperties.ETag.ToString().Replace("\"", "") != manageFile.AzureETag)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.AzureFile_Changed, jsonFileName)));
                    UpdateIsNeeded = true;
                }
                else
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.AzureFile_DidNotChanged, jsonFileName)));
                }
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
