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
using CSSPServices;
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
            AppendStatus(new AppendEventArgs(appTextModel.InstallUpdates));

            DirectoryInfo di = new DirectoryInfo(LocalCSSPDesktopPath);

            if (!di.Exists)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.Directory_ShouldExist, di.FullName)));
                return await Task.FromResult(false);
            }

            // Doing csspwebapis container 
            List<string> zipFileNameList = new List<string>()
            {
                "helpdocs.zip", "csspwebapis.zip", "csspclient.zip"
            };

            int zipCount = 0;
            foreach (string zipFileName in zipFileNameList)
            {
                zipCount += 1;
                InstallingStatus(new InstallingEventArgs(20 * zipCount));
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.Downloading_, zipFileName)));

                if (!await DownloadZipFilesFromAzure(zipFileName)) return await Task.FromResult(false);
            }

            // Doing csspjson container 
            List<string> jsonFileNameList = new List<string>()
            {
                "WebContact.gz", "WebHelpDoc.gz", "WebMWQMLookupMPN.gz", "WebPolSourceGrouping.gz",
                "WebReportType.gz", "WebRoot.gz", "WebTideLocation.gz", "WebTVItem.gz"
            };

            int jsonCount = 0;
            foreach (string jsonFileName in jsonFileNameList)
            {
                zipCount += 1;
                InstallingStatus(new InstallingEventArgs(60 + (5 * jsonCount)));
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.Downloading_, jsonFileName)));

                if (!await DownloadJsonFilesFromAzure(jsonFileName)) return await Task.FromResult(false);
            }


            InstallingStatus(new InstallingEventArgs(100));
            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }

        private async Task<bool> DownloadJsonFilesFromAzure(string jsonFileName)
        {
            AppendStatus(new AppendEventArgs(string.Format(appTextModel.DownloadingFileFromAzure_, jsonFileName)));

            FileInfo fi = new FileInfo($"{ LocalCSSPDesktopPath }{ jsonFileName }");

            BlobClient blobClient = new BlobClient(preference.AzureStore, AzureStoreCSSPWebAPIsPath, jsonFileName);
            BlobProperties blobProperties = blobClient.GetProperties();
            if (blobProperties == null)
            {
                // looks like the file does not exist on Azure
                // will need to create it before downloading it

                WebTypeEnum webType = WebTypeEnum.WebRoot;
                int TVItemID = 0;
                WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

                switch (jsonFileName)
                {
                    case "WebContact.gz":
                        {
                            webType = WebTypeEnum.WebContact;
                        }
                        break;
                    case "WebHelpDoc.gz":
                        {
                            webType = WebTypeEnum.WebHelpDoc;
                        }
                        break;
                    case "WebMWQMLookupMPN.gz":
                        {
                            webType = WebTypeEnum.WebMWQMLookupMPN;
                        }
                        break;
                    case "WebPolSourceGrouping.gz":
                        {
                            webType = WebTypeEnum.WebPolSourceGrouping;
                        }
                        break;
                    case "WebReportType.gz":
                        {
                            webType = WebTypeEnum.WebReportType;
                        }
                        break;
                    case "WebRoot.gz":
                        {
                            webType = WebTypeEnum.WebRoot;
                        }
                        break;
                    case "WebTideLocation.gz":
                        {
                            webType = WebTypeEnum.WebTideLocation;
                        }
                        break;
                    case "WebTVItem.gz":
                        {
                            webType = WebTypeEnum.WebTVItem;
                        }
                        break;
                    default:
                        break;
                }

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                    string culture = "fr-CA";
                    if (IsEnglish)
                    {
                        culture = "en-CA";
                    }
                    string url = $"{ CSSPAzureUrl }api/{ culture }/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }";
                    var response = await httpClient.GetAsync(url);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(appTextModel.File_CreatedOnAzure, jsonFileName)));
                    }
                    else
                    {
                        AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotCreateFile_OnAzure, jsonFileName)));
                        return await Task.FromResult(false);
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

                if (jsonFileName == "WebTVItem.gz")
                {
                    AppendStatus(new AppendEventArgs(string.Format(appTextModel.FillingCSSPDBSearchDatabaseWith_Info, jsonFileName)));
                    
                    if (!await FillCSSPDBSearch()) return await Task.FromResult(false);
                }
            }
            else
            {
                if (jsonFileName == "WebTVItem.gz")
                {
                    AppendStatus(new AppendEventArgs(string.Format(appTextModel.UpdatingCSSPDBSearchDatabase)));

                    if (!await UpdateCSSPDBSearch()) return await Task.FromResult(false);
                }
            }

            return await Task.FromResult(true);
        }
        private async Task<bool> DownloadZipFilesFromAzure(string zipFileName)
        {
            AppendStatus(new AppendEventArgs(string.Format(appTextModel.DownloadingFileFromAzure_, zipFileName)));

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
                Response response = blobClient.DownloadTo(fi.FullName);

                AppendStatus(new AppendEventArgs(string.Format(appTextModel.Unzipping_, zipFileName)));
                if (!await UnzipDownloadedFile(zipFileName, response)) return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        private async Task<bool> UnzipDownloadedFile(string zipFileName, Response response)
        {
            FileInfo fiLocal = new FileInfo($"{ LocalCSSPDesktopPath }{ zipFileName }");

            if (!fiLocal.Exists)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotFindFile_, fiLocal.FullName)));
                return await Task.FromResult(false);
            }

            try
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.UnzippingDownloadedFile_, zipFileName)));

                if (zipFileName.Contains("csspclient"))
                {
                    ZipFile.ExtractToDirectory(fiLocal.FullName, LocalCSSPWebAPIsPath + "\\csspclient", true);
                }
                else
                {
                    ZipFile.ExtractToDirectory(fiLocal.FullName, LocalCSSPWebAPIsPath, true);
                }
            }
            catch (Exception ex)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotUnzip_Error_, fiLocal.FullName, ex.Message)));
                return await Task.FromResult(false);
            }

            CSSPFile csspFile = (from c in dbFM.CSSPFiles
                                 where c.AzureStorage == "csspwebapis"
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
                    AzureStorage = "csspwebapis",
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
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CSSPFilesManagementUpdateAzureStorage_AzureFileName_, "csspwebapis", zipFileName)));
                dbFM.SaveChanges();
            }
            catch (Exception)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotAddOrModifyCSSPDBFilesManagement_dbFor_, "csspwebapis", zipFileName)));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}