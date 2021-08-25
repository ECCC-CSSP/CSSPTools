﻿/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        public async Task<bool> DoRemoveAzureDirectoriesNotFoundInTVFiles()
        {
            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.Starting } DoRemoveAzureDirectoriesNotFoundInTVFiles ...");

            if (!await CheckComputerName()) return await Task.FromResult(false);

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.RunningOn } { Environment.MachineName.ToString().ToLower() }");

            DirectoryInfo di = new DirectoryInfo(LocalAppDataPath);
            if (!di.Exists)
            {
                CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.LocalAppDataPathDoesNotExist_, di.FullName) }");

                await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.RemoveAzureDirectoriesNotFoundInTVFiles);

                return await Task.FromResult(false);
            }

            List<TVItem> TVItemList = (from c in db.TVItems
                                       where c.TVType == TVTypeEnum.File
                                       orderby c.TVLevel
                                       select c).AsNoTracking().ToList();


            List<int> ParentIDList = (from c in TVItemList
                                      orderby c.ParentID
                                      select (int)c.ParentID).Distinct().ToList();


            // ---------------------------------------------
            // Cleaning Azure drive
            //----------------------------------------------

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.StartingAzureDirectoryCleanup }");

            ShareClient shareClient = new ShareClient(AzureStore, AzureStoreCSSPFilesPath);
            ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();

            Pageable<ShareFileItem> shareFileItemList = directory.GetFilesAndDirectories();

            foreach (ShareFileItem shareFileItem in shareFileItemList)
            {
                int? ParentIDExist = (from c in ParentIDList
                                      where c.ToString() == shareFileItem.Name
                                      select c).FirstOrDefault();

                if (ParentIDExist == 0)
                {
                    if (shareFileItem.Name == "WebTide")
                    {
                        continue;
                    }

                    CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletingAzureDirectory_, shareFileItem.Name) }");

                    if (shareFileItem.IsDirectory)
                    {
                        ShareClient shareClientSub = new ShareClient(AzureStore, AzureStoreCSSPFilesPath);
                        ShareDirectoryClient directorySub = shareClientSub.GetDirectoryClient(shareFileItem.Name);

                        if (directorySub.Exists())
                        {
                            foreach (ShareFileItem shareFileItemSub in directorySub.GetFilesAndDirectories())
                            {
                                ShareFileClient file = directorySub.GetFileClient(shareFileItemSub.Name);

                                string dirFile = $@"{shareFileItem.Name}\{shareFileItemSub.Name}";
                                CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletingAzureFile_, dirFile) }");

                                Response<bool> responseFile = file.DeleteIfExists();

                                if (responseFile.Value)
                                {
                                    CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletedAzureFile_, dirFile) }");
                                }
                                else
                                {
                                    CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingAzureFile_, dirFile) }");
                                }
                            }
                        }

                        Response<bool> responseDir = directorySub.DeleteIfExists();

                        if (responseDir.Value)
                        {
                            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletedAzureDirectory_, shareFileItem.Name) }");
                        }
                        else
                        {
                            CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingAzureDirectory_, shareFileItem.Name) }");
                        }
                    }
                }
            }

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.End } DoRemoveAzureDirectoriesNotFoundInTVFiles ...");

            await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.RemoveAzureDirectoriesNotFoundInTVFiles);

            return await Task.FromResult(true);
        }
    }
}