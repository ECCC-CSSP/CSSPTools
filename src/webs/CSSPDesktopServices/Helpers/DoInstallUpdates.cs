using CSSPEnums;
using CSSPDBModels;
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
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;

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
                "csspwebapislocal.zip", "csspclient.zip", "csspotherfiles.zip",
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
                $"{ WebTypeEnum.WebAllAddresses }.gz",
                $"{ WebTypeEnum.WebAllContacts }.gz",
                $"{ WebTypeEnum.WebAllCountries }.gz",
                $"{ WebTypeEnum.WebAllEmails }.gz",
                $"{ WebTypeEnum.WebAllHelpDocs }.gz",
                $"{ WebTypeEnum.WebAllMunicipalities }.gz",
                $"{ WebTypeEnum.WebAllMWQMLookupMPNs }.gz",
                $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz",
                $"{ WebTypeEnum.WebAllPolSourceSiteEffectTerms }.gz",
                $"{ WebTypeEnum.WebAllProvinces }.gz",
                $"{ WebTypeEnum.WebAllReportTypes }.gz",
                $"{ WebTypeEnum.WebAllTels }.gz",
                $"{ WebTypeEnum.WebAllTideLocations }.gz",
                $"{ WebTypeEnum.WebAllSearch }.gz",
                $"{ WebTypeEnum.WebRoot }.gz",
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

            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.DownloadingFileFromAzure_, jsonFileName)));

            FileInfo fi = new FileInfo($"{ CSSPJSONPath }{ jsonFileName }");

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
            catch (RequestFailedException)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, "csspjson", jsonFileName)));
                return await Task.FromResult(false);
            }

            FilesManagement filesManagement = (from c in dbFM.FilesManagements
                                               where c.AzureStorage == "csspjson"
                                               && c.AzureFileName == jsonFileName
                                               select c).FirstOrDefault();

            if (filesManagement == null || blobProperties.ETag.ToString().Replace("\"", "") != filesManagement.AzureETag)
            {
                Response response = blobClient.DownloadTo(fi.FullName);

                if (filesManagement == null)
                {
                    int LastID = (from c in dbFM.FilesManagements
                                  orderby c.FilesManagementID descending
                                  select c.FilesManagementID).FirstOrDefault();

                    filesManagement = new FilesManagement()
                    {
                        FilesManagementID = LastID + 1,
                        AzureStorage = AzureStoreCSSPJSONPath,
                        AzureFileName = jsonFileName,
                        AzureETag = response.Headers.ETag.ToString(),
                        AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString()),
                    };

                    dbFM.FilesManagements.Add(filesManagement);
                }
                else
                {
                    filesManagement.AzureETag = response.Headers.ETag.ToString();
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
            }

            return await Task.FromResult(true);
        }
        private async Task<bool> DownloadZipFilesFromAzure(string zipFileName)
        {
            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.DownloadingFileFromAzure_, zipFileName)));

            FileInfo fi = new FileInfo($"{ CSSPDesktopPath }{ zipFileName }");

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

            FilesManagement filesManagement = (from c in dbFM.FilesManagements
                                               where c.AzureStorage == AzureStoreCSSPWebAPIsLocalPath
                                               && c.AzureFileName == zipFileName
                                               select c).FirstOrDefault();

            if (filesManagement == null || blobProperties.ETag.ToString().Replace("\"", "") != filesManagement.AzureETag)
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
                else if (zipFileName.Contains("csspotherfiles"))
                {
                    ZipFile.ExtractToDirectory(fiLocal.FullName, CSSPOtherFilesPath, true);
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

            FilesManagement filesManagement = (from c in dbFM.FilesManagements
                                               where c.AzureStorage == AzureStoreCSSPWebAPIsLocalPath
                                               && c.AzureFileName == zipFileName
                                               select c).FirstOrDefault();

            if (filesManagement == null)
            {
                int LastID = (from c in dbFM.FilesManagements
                              orderby c.FilesManagementID descending
                              select c.FilesManagementID).FirstOrDefault();

                filesManagement = new FilesManagement()
                {
                    FilesManagementID = LastID + 1,
                    AzureStorage = AzureStoreCSSPWebAPIsLocalPath,
                    AzureFileName = zipFileName,
                    AzureETag = response.Headers.ETag.ToString(),
                    AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString()),
                };

                dbFM.FilesManagements.Add(filesManagement);
            }
            else
            {
                filesManagement.AzureETag = response.Headers.ETag.ToString();
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