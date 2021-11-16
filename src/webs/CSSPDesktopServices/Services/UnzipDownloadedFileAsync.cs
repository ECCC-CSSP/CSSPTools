using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using CSSPHelperModels;
using ManageServices;
using CSSPLocalLoggedInServices;
using CSSPCultureServices.Resources;
using CSSPScrambleServices;
using CSSPLogServices;
using System.Linq;
using System.IO;
using Azure.Storage.Files.Shares.Models;
using System.IO.Compression;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> UnzipDownloadedFileAsync(string zipFileName, ShareFileProperties shareFileProperties)
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
