/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files;
using Azure.Storage.Files.Shares.Models;

namespace DownloadFileServices
{
    public partial class DownloadFileService : ControllerBase, IDownloadFileService
    {
        private async Task<ActionResult<bool>> DoLocalizeAzureFile(int ParentTVItemID, string FileName)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            ShareFileClient shareFileClient;
            ShareFileProperties shareFileProperties;
            try
            {
                ShareClient shareClient = new ShareClient(AzureStoreConnectionString, AzureStoreCSSPFilesPath);
                ShareDirectoryClient shareDirectoryClient = shareClient.GetDirectoryClient($"{ParentTVItemID}");
                shareFileClient = shareDirectoryClient.GetFileClient(FileName);
                shareFileProperties = shareFileClient.GetProperties();
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not download file \\{ParentTVItemID}\\{FileName}. Ex: {ex.Message}");
            }

            FileInfo fiDownload = new FileInfo($"{CSSPFilesPath}{ParentTVItemID}\\{FileName}");
            bool ShouldDownload = false;

            if (fiDownload.Exists)
            {
                var actionCSSPFile = await CSSPDBFilesManagementService.GetWithAzureStorageAndAzureFileName(AzureStoreCSSPFilesPath, $"{ParentTVItemID}\\{FileName}");
                if (((ObjectResult)actionCSSPFile.Result).StatusCode == 200)
                {
                    try
                    {

                        CSSPFile csspFile = (CSSPFile)((OkObjectResult)actionCSSPFile.Result).Value;

                        if (csspFile.AzureETag != shareFileProperties.ETag.ToString().Replace("\"", ""))
                        {
                            ShouldDownload = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        return BadRequest($"Could not download file \\{ParentTVItemID}\\{FileName}. Ex: {ex.Message}");
                    }

                    if (ShouldDownload)
                    {
                        try
                        {
                            fiDownload.Delete();
                        }
                        catch (Exception ex)
                        {
                            return BadRequest($"Could not delete file \\{ParentTVItemID}\\{FileName} before downloading the new one. Ex: {ex.Message}");
                        }
                    }
                }
                else
                {
                    return BadRequest($"File exist in directory [{ParentTVItemID}] but not in CSSPDBFileManagement local database");
                }
            }
            else
            {
                ShouldDownload = true;
            }

            if (ShouldDownload)
            {
                DirectoryInfo di = new DirectoryInfo(fiDownload.Directory.FullName);
                if (!di.Exists)
                {
                    try
                    {
                        di.Create();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest($"Could not create directory [{ParentTVItemID}]. Ex: {ex.Message}");
                    }
                }

                try
                {
                    ShareFileDownloadInfo download = shareFileClient.Download();
                    using (FileStream stream = System.IO.File.OpenWrite(fiDownload.FullName))
                    {
                        download.Content.CopyTo(stream);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest($"Could not download file \\{ParentTVItemID}\\{FileName}. Ex: {ex.Message}");
                }

                CSSPFile csspFile = null;

                var actionCSSPFile = await CSSPDBFilesManagementService.GetWithAzureStorageAndAzureFileName(AzureStoreCSSPFilesPath, $"{ParentTVItemID}\\{FileName}");
                if (((ObjectResult)actionCSSPFile.Result).StatusCode == 400)
                {
                    int NextIndex = -1;
                    var actionInt = await CSSPDBFilesManagementService.GetCSSPFileNextIndexToUse();
                    if (((ObjectResult)actionInt.Result).StatusCode == 200)
                    {
                        NextIndex = (int)((OkObjectResult)actionInt.Result).Value;
                    }

                    csspFile = new CSSPFile()
                    {
                        CSSPFileID = NextIndex,
                        AzureStorage = AzureStoreCSSPFilesPath,
                        AzureFileName = $"{ParentTVItemID}\\{FileName}",
                        AzureETag = shareFileProperties.ETag.ToString().Replace("\"", ""),
                        AzureCreationTimeUTC = DateTime.Parse(shareFileProperties.LastModified.ToString()),
                    };

                    var actionCSSPFileAdded = await CSSPDBFilesManagementService.Post(csspFile);
                    if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 200)
                    {
                        csspFile = (CSSPFile)((OkObjectResult)actionCSSPFileAdded.Result).Value;
                    }
                    else if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 401)
                    {
                        return await Task.FromResult(Unauthorized());
                    }
                    else
                    {
                        return await Task.FromResult((BadRequestObjectResult)actionCSSPFileAdded.Result);
                    }
                }
                else
                {
                    if (((OkObjectResult)actionCSSPFile.Result).StatusCode == 200)
                    {
                        csspFile = (CSSPFile)((OkObjectResult)actionCSSPFile.Result).Value;

                        csspFile.AzureETag = shareFileProperties.ETag.ToString().Replace("\"", "");
                        csspFile.AzureCreationTimeUTC = DateTime.Parse(shareFileProperties.LastModified.ToString());

                        var actionCSSPFilePut = await CSSPDBFilesManagementService.Put(csspFile);
                        if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 200)
                        {
                            csspFile = (CSSPFile)((OkObjectResult)actionCSSPFilePut.Result).Value;
                        }
                        else if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 401)
                        {
                            return await Task.FromResult(Unauthorized());
                        }
                        else
                        {
                            return await Task.FromResult((BadRequestObjectResult)actionCSSPFilePut.Result);
                        }
                    }
                    else
                    {
                        return await Task.FromResult((BadRequestObjectResult)actionCSSPFile.Result);
                    }
                }

            }

            return await Task.FromResult(Ok(true));
        }
    }
}
