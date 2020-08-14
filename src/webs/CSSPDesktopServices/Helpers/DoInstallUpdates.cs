﻿using CSSPEnums;
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

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoInstallUpdates()
        {
            AppendStatus(new AppendEventArgs(appTextModel.InstallUpdates));

            // need to stop CSSPWebAPIs so we can copy over some files 
            if (!await Stop()) await Task.FromResult(false);

            DirectoryInfo di = new DirectoryInfo(LocalCSSPDesktopPath);

            if (!di.Exists)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.Directory_ShouldExist, di.FullName)));
                return await Task.FromResult(false);
            }

            List<string> zipFileNameList = new List<string>()
            {
                "csspwebapis.zip", "csspclient.zip", "helpdocs.zip"
            };

            int zipCount = 0;
            foreach (string zipFileName in zipFileNameList)
            {
                zipCount += 1;
                InstallingStatus(new InstallingEventArgs(30*zipCount));
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.Downloading_, zipFileName)));

                if (!await DownloadZipFilesFromAzure(zipFileName)) return await Task.FromResult(false);
            }

            InstallingStatus(new InstallingEventArgs(100));
            AppendStatus(new AppendEventArgs(""));

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }

        private async Task<bool> DownloadZipFilesFromAzure(string zipFileName)
        {
            AppendStatus(new AppendEventArgs(string.Format(appTextModel.DownloadingZipFileFromAzure_, zipFileName)));

            FileInfo fi = new FileInfo($"{ LocalCSSPDesktopPath }{ zipFileName }");

            BlobClient blobClient = new BlobClient(AzureStore, AzureStoreCSSPWebAPIsPath, zipFileName);
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

            if (csspFile == null || !blobProperties.ETag.Equals(csspFile.AzureETag))
            {
                blobClient.DownloadTo(fi.FullName);
            }

            AppendStatus(new AppendEventArgs(string.Format(appTextModel.Unzipping_, zipFileName)));
            if (!await UnzipDownloadedFile(zipFileName, blobProperties)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        private async Task<bool> UnzipDownloadedFile(string zipFileName, BlobProperties blobProperties)
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
                    AzureETag = blobProperties.ETag.ToString(),
                    LocalExist = false,
                    LocalOld = true,
                    AzureCreationTime = DateTime.Now
                };

                dbFM.CSSPFiles.Add(csspFile);
            }
            else
            {
                csspFile.AzureETag = blobProperties.ETag.ToString();
            }

            try
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CSSPFilesManagementUpdateAzureStorage_AzureFileName_, "csspwebapis", zipFileName)));
                dbFM.SaveChanges();
            }
            catch (Exception ex)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotAddOrModifyCSSPDBFilesManagement_dbFor_, $"csspwebapis --- { zipFileName }")));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}