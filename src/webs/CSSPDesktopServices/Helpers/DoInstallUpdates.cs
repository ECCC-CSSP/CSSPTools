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
using System.IO.Compression;
using Azure;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoInstallUpdates()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.InstallUpdates));

            DirectoryInfo di = new DirectoryInfo(CSSPDesktopPath);

            if (!di.Exists)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Directory_ShouldExist, di.FullName)));
                return await Task.FromResult(false);
            }

            // Doing csspwebapislocal container 
            List<string> zipFileNameList = new List<string>()
            {
                "helpdocs.zip", "csspwebapislocal.zip", "csspclient.zip"
            };

            int zipCount = 0;
            foreach (string zipFileName in zipFileNameList)
            {
                zipCount += 1;
                InstallingStatus(new InstallingEventArgs(5 * zipCount));
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Downloading_, zipFileName)));

                if (!await DownloadZipFilesFromAzure(zipFileName)) return await Task.FromResult(false);
            }

            // Doing csspjson container 
            List<string> jsonFileNameList = new List<string>()
            {
                "WebContact.gz", "WebHelpDoc.gz", "WebMWQMLookupMPN.gz", "WebPolSourceGrouping.gz", "WebPolSourceSiteEffectTerm.gz",
                "WebReportType.gz", "WebRoot.gz", "WebTideLocation.gz", "WebAllTVItem.gz", "WebAllTVItemLanguage.gz"
            };

            int jsonCount = 0;
            foreach (string jsonFileName in jsonFileNameList)
            {
                jsonCount += 1;
                InstallingStatus(new InstallingEventArgs(15 + (2 * jsonCount)));
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Downloading_, jsonFileName)));

                if (!await DownloadJsonFilesFromAzure(jsonFileName)) return await Task.FromResult(false);
            }

            InstallingStatus(new InstallingEventArgs(100));
            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }

        private async Task<bool> DownloadJsonFilesFromAzure(string jsonFileName)
        {
            //string culture = "fr-CA";
            //if (IsEnglish)
            //{
            //    culture = "en-CA";
            //}

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

            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.DownloadingFileFromAzure_, jsonFileName)));

            FileInfo fi = new FileInfo($"{ CSSPJSONPath }{ jsonFileName }");

            Preference preferenceAzureStore = await GetPreferenceWithVariableName("AzureStore");

            if (preferenceAzureStore == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotFind_InDBLogin_, "AzureStore", "Preferences")));
                return await Task.FromResult(false);
            }

            string AzureStore = preferenceAzureStore.VariableValue;

            if (string.IsNullOrWhiteSpace(AzureStore))
            {
                return await Task.FromResult(true);
            }

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
                    using (HttpClient httpClient = new HttpClient())
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalService.LoggedInContactInfo.LoggedInContact.Token);
                        HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/CreateGzFile/{ (int)webType }/0/1").Result;

                        if ((int)response.StatusCode != 200)
                        {
                            if ((int)response.StatusCode == 401)
                            {
                                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, "csspjson", jsonFileName)));
                                AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.NeedToBeLoggedIn));
                                return await Task.FromResult(false);
                            }
                            else
                            {
                                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, "csspjson", jsonFileName)));
                                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.UnmanagedServerError_, response.Content.ReadAsStringAsync())));
                                return await Task.FromResult(false);
                            }
                        }
                    }
                }
            }

            CSSPFile csspFile = (from c in dbFM.CSSPFiles
                                 where c.AzureStorage == "csspjson"
                                 && c.AzureFileName == jsonFileName
                                 select c).FirstOrDefault();

            if (csspFile == null || blobProperties.ETag.ToString().Replace("\"", "") != csspFile.AzureETag)
            {
                Response response = blobClient.DownloadTo(fi.FullName);

                if (csspFile == null)
                {
                    int LastID = (from c in dbFM.CSSPFiles
                                  orderby c.CSSPFileID descending
                                  select c.CSSPFileID).FirstOrDefault();

                    csspFile = new CSSPFile()
                    {
                        CSSPFileID = LastID + 1,
                        AzureStorage = AzureStoreCSSPJSONPath,
                        AzureFileName = jsonFileName,
                        AzureETag = response.Headers.ETag.ToString(),
                        AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString()),
                    };

                    dbFM.CSSPFiles.Add(csspFile);
                }
                else
                {
                    csspFile.AzureETag = response.Headers.ETag.ToString();
                }

                try
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CSSPFilesManagementUpdateAzureStorage_AzureFileName_, AzureStoreCSSPJSONPath, jsonFileName)));
                    dbFM.SaveChanges();
                }
                catch (Exception)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotAddOrModifyCSSPDBFilesManagement_dbFor_, AzureStoreCSSPJSONPath, jsonFileName)));
                    return await Task.FromResult(false);
                }

                if (jsonFileName == "WebAllTVItemLanguage.gz")
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.FillingCSSPDBSearchDatabaseWith_Info, jsonFileName.Replace("Language", "") + " & " + jsonFileName)));

                    if (!await FillCSSPDBSearch()) return await Task.FromResult(false);
                }
            }
            else
            {
                if (jsonFileName == "WebAllTVItemLanguage.gz")
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.UpdatingCSSPDBSearchDatabase)));

                    if (!await UpdateCSSPDBSearch()) return await Task.FromResult(false);
                }
            }

            return await Task.FromResult(true);
        }
        private async Task<bool> DownloadZipFilesFromAzure(string zipFileName)
        {
            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.DownloadingFileFromAzure_, zipFileName)));

            FileInfo fi = new FileInfo($"{ CSSPDesktopPath }{ zipFileName }");

            Preference preferenceAzureStore = await GetPreferenceWithVariableName("AzureStore");

            if (preferenceAzureStore == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotFind_InDBLogin_, "AzureStore", "Preferences")));
                return await Task.FromResult(false);
            }

            string AzureStore = preferenceAzureStore.VariableValue;

            if (string.IsNullOrWhiteSpace(AzureStore))
            {
                return await Task.FromResult(true);
            }

            if (string.IsNullOrWhiteSpace(AzureStore))
            {
                return await Task.FromResult(true);
            }

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
                else
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.UnmanagedServerError_, ex.Message)));
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
                Response response = blobClient.DownloadTo(fi.FullName);

                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Unzipping_, zipFileName)));
                if (!await UnzipDownloadedFile(zipFileName, response)) return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        private async Task<bool> UnzipDownloadedFile(string zipFileName, Response response)
        {
            FileInfo fiLocal = new FileInfo($"{ CSSPDesktopPath }{ zipFileName }");

            if (!fiLocal.Exists)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotFindFile_, fiLocal.FullName)));
                return await Task.FromResult(false);
            }

            try
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.UnzippingDownloadedFile_, zipFileName)));

                if (zipFileName.Contains("csspclient"))
                {
                    ZipFile.ExtractToDirectory(fiLocal.FullName, CSSPWebAPIsLocalPath + "\\csspclient", true);
                }
                else
                {
                    ZipFile.ExtractToDirectory(fiLocal.FullName, CSSPWebAPIsLocalPath, true);
                }
            }
            catch (Exception ex)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotUnzip_Error_, fiLocal.FullName, ex.Message)));
                return await Task.FromResult(false);
            }

            CSSPFile csspFile = (from c in dbFM.CSSPFiles
                                 where c.AzureStorage == AzureStoreCSSPWebAPIsLocalPath
                                 && c.AzureFileName == zipFileName
                                 select c).FirstOrDefault();

            if (csspFile == null)
            {
                int LastID = (from c in dbFM.CSSPFiles
                              orderby c.CSSPFileID descending
                              select c.CSSPFileID).FirstOrDefault();

                csspFile = new CSSPFile()
                {
                    CSSPFileID = LastID + 1,
                    AzureStorage = AzureStoreCSSPWebAPIsLocalPath,
                    AzureFileName = zipFileName,
                    AzureETag = response.Headers.ETag.ToString(),
                    AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString()),
                };

                dbFM.CSSPFiles.Add(csspFile);
            }
            else
            {
                csspFile.AzureETag = response.Headers.ETag.ToString();
            }

            try
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CSSPFilesManagementUpdateAzureStorage_AzureFileName_, AzureStoreCSSPWebAPIsLocalPath, zipFileName)));
                dbFM.SaveChanges();
            }
            catch (Exception)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotAddOrModifyCSSPDBFilesManagement_dbFor_, AzureStoreCSSPWebAPIsLocalPath, zipFileName)));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}