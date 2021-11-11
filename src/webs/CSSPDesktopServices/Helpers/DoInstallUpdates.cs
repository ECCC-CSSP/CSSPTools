using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using CSSPEnums;
using ManageServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoInstallUpdates()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.InstallUpdates));

            DirectoryInfo di = new DirectoryInfo(Configuration["CSSPDesktopPath"]);

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

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPath"] }{ jsonFileName }");


            ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
            ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();

            ShareFileClient shareFileClient = directory.GetFileClient(jsonFileName);

            ShareFileProperties shareFileProperties = null;

            //BlobClient blobClient = new BlobClient(CSSPScrambleService.Descramble(AzureStoreHash), Configuration["AzureStoreCSSPJSONPath"], jsonFileName);
            //BlobProperties blobProperties = null;

            try
            {
                shareFileProperties = shareFileClient.GetProperties();
                //blobProperties = blobClient.GetProperties();
            }
            catch (RequestFailedException)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, "csspjson", jsonFileName)));
                return await Task.FromResult(false);
            }

            ManageFile manageFile = (from c in dbManage.ManageFiles
                                     where c.AzureStorage == "csspjson"
                                     && c.AzureFileName == jsonFileName
                                     select c).FirstOrDefault();

            //if (manageFile == null || blobProperties.ETag.ToString().Replace("\"", "") != manageFile.AzureETag)
            if (manageFile == null || shareFileProperties.ETag.ToString().Replace("\"", "") != manageFile.AzureETag)
            {
                //Response response = blobClient.DownloadTo(fi.FullName);
                ShareFileDownloadInfo download = shareFileClient.Download();
                using (FileStream stream = File.OpenWrite(fi.FullName))
                {
                    download.Content.CopyTo(stream);
                }

                if (manageFile == null)
                {
                    int LastID = (from c in dbManage.ManageFiles
                                  orderby c.ManageFileID descending
                                  select c.ManageFileID).FirstOrDefault();

                    manageFile = new ManageFile()
                    {
                        ManageFileID = LastID + 1,
                        AzureStorage = Configuration["AzureStoreCSSPJSONPath"],
                        AzureFileName = jsonFileName,
                        AzureETag = shareFileProperties.ETag.ToString(),
                        AzureCreationTimeUTC = DateTime.Parse(shareFileProperties.LastModified.ToString()),
                        LoadedOnce = true,
                    };

                    dbManage.ManageFiles.Add(manageFile);
                }
                else
                {
                    manageFile.AzureETag = shareFileProperties.ETag.ToString();
                    manageFile.LoadedOnce = true;
                }

                try
                {
                    dbManage.SaveChanges();
                }
                catch (Exception)
                {
                    return await Task.FromResult(false);
                }
            }

            return await Task.FromResult(true);
        }
        private async Task<bool> DownloadZipFilesFromAzure(string zipFileName)
        {
            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.DownloadingFileFromAzure_, zipFileName)));

            FileInfo fi = new FileInfo($"{ Configuration["CSSPDesktopPath"] }{ zipFileName }");

            ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
            ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();

            ShareFileClient shareFileClient = directory.GetFileClient(zipFileName);

            ShareFileProperties shareFileProperties = null;
            //BlobProperties blobProperties = null;
            //BlobClient blobClient = null;

            try
            {
                shareFileProperties = shareFileClient.GetProperties();
                //blobClient = new BlobClient(CSSPScrambleService.Descramble(AzureStoreHash), Configuration["AzureStoreCSSPWebAPIsLocalPath"], zipFileName);
                //blobProperties = blobClient.GetProperties();
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, Configuration["AzureStoreCSSPWebAPIsLocalPath"], zipFileName)));
                    return await Task.FromResult(false);
                }
                else
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.UnmanagedServerError_, ex.Message)));
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

            if (manageFile == null || shareFileProperties.ETag.ToString().Replace("\"", "") != manageFile.AzureETag)
            {
                //Response response = blobClient.DownloadTo(fi.FullName);
                ShareFileDownloadInfo download = shareFileClient.Download();
                using (FileStream stream = File.OpenWrite(fi.FullName))
                {
                    download.Content.CopyTo(stream);
                }

                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Unzipping_, zipFileName)));
                //if (!await UnzipDownloadedFile(zipFileName, response)) return await Task.FromResult(false);
                if (!await UnzipDownloadedFile(zipFileName, shareFileProperties)) return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        private async Task<bool> UnzipDownloadedFile(string zipFileName, ShareFileProperties shareFileProperties)
        {
            FileInfo fiLocal = new FileInfo($"{ Configuration["CSSPDesktopPath"] }{ zipFileName }");

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
                    DirectoryInfo di = new DirectoryInfo(Configuration["CSSPWebAPIsLocalPath"] + "\\csspclient");

                    if (di.Exists)
                    {
                        try
                        {
                            di.Delete(true);
                        }
                        catch (Exception ex)
                        {
                            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotDeleteDirectory_Error_, di.FullName, ex.Message)));
                            return await Task.FromResult(false);
                        }
                    }

                    ZipFile.ExtractToDirectory(fiLocal.FullName, Configuration["CSSPWebAPIsLocalPath"] + "\\csspclient", true);
                }
                else if (zipFileName.Contains("csspotherfiles"))
                {
                    DirectoryInfo di = new DirectoryInfo(Configuration["CSSPOtherFilesPath"]);

                    if (di.Exists)
                    {
                        try
                        {
                            di.Delete(true);
                        }
                        catch (Exception ex)
                        {
                            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotDeleteDirectory_Error_, di.FullName, ex.Message)));
                            return await Task.FromResult(false);
                        }
                    }

                    ZipFile.ExtractToDirectory(fiLocal.FullName, Configuration["CSSPOtherFilesPath"], true);
                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(Configuration["CSSPWebAPIsLocalPath"]);

                    if (di.Exists)
                    {
                        try
                        {
                            di.Delete(true);
                        }
                        catch (Exception ex)
                        {
                            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotDeleteDirectory_Error_, di.FullName, ex.Message)));
                            return await Task.FromResult(false);
                        }
                    }

                    ZipFile.ExtractToDirectory(fiLocal.FullName, Configuration["CSSPWebAPIsLocalPath"], true);
                }
            }
            catch (Exception ex)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotUnzip_Error_, fiLocal.FullName, ex.Message)));
                return await Task.FromResult(false);
            }

            ManageFile manageFile = (from c in dbManage.ManageFiles
                                     where c.AzureStorage == Configuration["AzureStoreCSSPWebAPIsLocalPath"]
                                     && c.AzureFileName == zipFileName
                                     select c).FirstOrDefault();

            if (manageFile == null)
            {
                int LastID = (from c in dbManage.ManageFiles
                              orderby c.ManageFileID descending
                              select c.ManageFileID).FirstOrDefault();

                manageFile = new ManageFile()
                {
                    ManageFileID = LastID + 1,
                    AzureStorage = Configuration["AzureStoreCSSPWebAPIsLocalPath"],
                    AzureFileName = zipFileName,
                    AzureETag = shareFileProperties.ETag.ToString(),
                    AzureCreationTimeUTC = DateTime.Parse(shareFileProperties.LastModified.ToString()),
                    LoadedOnce = true,
                };

                dbManage.ManageFiles.Add(manageFile);
            }
            else
            {
                manageFile.AzureETag = shareFileProperties.ETag.ToString();
                manageFile.LoadedOnce = true;
            }

            try
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CSSPFilesManagementUpdateAzureStorage_AzureFileName_, Configuration["AzureStoreCSSPWebAPIsLocalPath"], zipFileName)));
                dbManage.SaveChanges();
            }
            catch (Exception)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotAddOrModifyCSSPDBFilesManagement_dbFor_, Configuration["AzureStoreCSSPWebAPIsLocalPath"], zipFileName)));
                return await Task.FromResult(false);
            }

            try
            {
                fiLocal.Delete();
            }
            catch (Exception ex)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotDeleteFile_Error_, fiLocal.FullName, ex.Message)));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}