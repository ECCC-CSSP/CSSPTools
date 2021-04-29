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
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;

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

            if (string.IsNullOrWhiteSpace(AzureStore))
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
                FileInfo fi = new FileInfo($"{ CSSPDesktopPath }{ zipFileName }");

                BlobClient blobClient = new BlobClient(AzureStore, AzureStoreCSSPWebAPIsLocalPath, zipFileName);
                BlobProperties blobProperties = null;

                try
                {
                    blobProperties = blobClient.GetProperties();
                }
                catch (RequestFailedException ex)
                {
                    if (ex.Status == 404)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, AzureStoreCSSPWebAPIsLocalPath, zipFileName)));
                        return await Task.FromResult(false);
                    }
                }

                if (blobProperties == null)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, AzureStoreCSSPWebAPIsLocalPath, zipFileName)));
                    return await Task.FromResult(false);
                }

                FilesManagement filesManagement = (from c in dbFM.FilesManagements
                                     where c.AzureStorage == AzureStoreCSSPWebAPIsLocalPath
                                     && c.AzureFileName == zipFileName
                                     select c).FirstOrDefault();

                if (filesManagement == null || blobProperties.ETag.ToString().Replace("\"", "") != filesManagement.AzureETag)
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
                $"{ WebTypeEnum.WebAllMunicipalities }.gz",
                $"{ WebTypeEnum.WebAllHelpDocs }.gz",
                $"{ WebTypeEnum.WebAllMWQMLookupMPNs }.gz",
                $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz",
                $"{ WebTypeEnum.WebAllPolSourceSiteEffectTerms }.gz",
                $"{ WebTypeEnum.WebAllProvinces }.gz",
                $"{ WebTypeEnum.WebAllReportTypes }.gz",
                $"{ WebTypeEnum.WebRoot }.gz",
                $"{ WebTypeEnum.WebAllTels }.gz",
                $"{ WebTypeEnum.WebAllTideLocations }.gz",
                $"{ WebTypeEnum.WebAllTVItems1980_2020 }.gz",
                $"{ WebTypeEnum.WebAllTVItems2021_2060 }.gz",
                $"{ WebTypeEnum.WebAllTVItemLanguages1980_2020 }.gz",
                $"{ WebTypeEnum.WebAllTVItemLanguages2021_2060 }.gz",
            };

            foreach (string jsonFileName in jsonFileNameList)
            {
                string enumTypeName = jsonFileName.Substring(0, jsonFileName.IndexOf("."));

                WebTypeEnum webType = WebTypeEnum.WebRoot;

                foreach (int enumVal in Enum.GetValues(typeof(WebTypeEnum)))
                {

                    if (((WebTypeEnum)enumVal).ToString() == enumTypeName)
                    {
                        webType = (WebTypeEnum)enumVal;
                        break;
                    }
                }

                FileInfo fi = new FileInfo($"{ CSSPDesktopPath }{ jsonFileName }");

                BlobClient blobClient = new BlobClient(AzureStore, AzureStoreCSSPJSONPath, jsonFileName);
                BlobProperties blobProperties = null;

                try
                {
                    blobProperties = blobClient.GetProperties();
                }
                catch (RequestFailedException ex)
                {
                    if (ex.Status == 404)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, AzureStoreCSSPWebAPIsLocalPath, jsonFileName)));
                        UpdateIsNeeded = true;
                        return await Task.FromResult(true);
                    }
                }

                if (blobProperties == null)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, "csspjson", jsonFileName)));
                    UpdateIsNeeded = true;
                    return await Task.FromResult(true);
                }

                FilesManagement filesManagement = (from c in dbFM.FilesManagements
                                     where c.AzureStorage == "csspjson"
                                     && c.AzureFileName == jsonFileName
                                     select c).FirstOrDefault();

                if (filesManagement == null || blobProperties.ETag.ToString().Replace("\"", "") != filesManagement.AzureETag)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.AzureFile_Changed, jsonFileName)));
                    UpdateIsNeeded = true;
                }
                else
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.AzureFile_DidNotChanged, jsonFileName)));
                }
            }

            TVItem tvItem = await (from c in dbSearch.TVItems
                                   select c).FirstOrDefaultAsync();

            if (tvItem == null)
            {
                AppendStatus(new AppendEventArgs("CSSPDBSearch needs to be populated"));
                UpdateIsNeeded = true;
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
