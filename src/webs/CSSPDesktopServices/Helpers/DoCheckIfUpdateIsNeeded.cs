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

            Preference preferenceHasInternetConnection = await GetPreferenceWithVariableName("HasInternetConnection");

            if (preferenceHasInternetConnection == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotFind_InDBLogin_, "HasInternetConnection", "Preferences")));
                return await Task.FromResult(false);
            }

            bool HasInternetConnection = bool.Parse(preferenceHasInternetConnection.VariableValue);

            if (!HasInternetConnection)
            {
                return await Task.FromResult(true);
            }

            //Preference preferenceAzureStore = await GetPreferenceWithVariableName("AzureStore");

            //if (preferenceAzureStore == null)
            //{
            //    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotFind_InDBLogin_, "AzureStore", "Preferences")));
            //    return await Task.FromResult(false);
            //}

            //string AzureStore = preferenceAzureStore.VariableValue;

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

                CSSPFile csspFile = (from c in dbFM.CSSPFiles
                                     where c.AzureStorage == AzureStoreCSSPWebAPIsLocalPath
                                     && c.AzureFileName == zipFileName
                                     select c).FirstOrDefault();

                if (csspFile == null || blobProperties.ETag.ToString().Replace("\"", "") != csspFile.AzureETag)
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
                "WebContact.gz", "WebHelpDoc.gz", "WebMWQMLookupMPN.gz", "WebPolSourceGrouping.gz", "WebPolSourceSiteEffectTerm.gz",
                "WebReportType.gz", "WebRoot.gz", "WebTideLocation.gz", "WebAllTVItem.gz", "WebAllTVItemLanguage.gz"
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

                CSSPFile csspFile = (from c in dbFM.CSSPFiles
                                     where c.AzureStorage == "csspjson"
                                     && c.AzureFileName == jsonFileName
                                     select c).FirstOrDefault();

                if (csspFile == null || blobProperties.ETag.ToString().Replace("\"", "") != csspFile.AzureETag)
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
