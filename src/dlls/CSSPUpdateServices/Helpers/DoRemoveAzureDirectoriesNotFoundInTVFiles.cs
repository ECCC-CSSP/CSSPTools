/*
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
            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.Starting } DoRemoveAzureDirectoriesNotFoundInTVFiles ...");

            if (!await CheckComputerName()) return await Task.FromResult(false);

            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.RunningOn } { Environment.MachineName.ToString().ToLower() }");

            DirectoryInfo di = new DirectoryInfo(LocalAppDataPath);
            if (!di.Exists)
            {
                ErrorAppend(sbError, $"{ String.Format(CSSPCultureUpdateRes.LocalAppDataPathDoesNotExist_, di.FullName) }");

                await StoreInCommandLog(sbLog, sbError, "RemoveAzureDirectoriesNotFoundInTVFiles");

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

            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.StartingAzureDirectoryCleanup }");

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

                    LogAppend(sbLog, $"{ String.Format(CSSPCultureUpdateRes.DeletingAzureDirectory_, shareFileItem.Name) }");

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
                                LogAppend(sbLog, $"{ String.Format(CSSPCultureUpdateRes.DeletingAzureFile_, dirFile) }");

                                Response<bool> responseFile = file.DeleteIfExists();

                                if (responseFile.Value)
                                {
                                    LogAppend(sbLog, $"{ String.Format(CSSPCultureUpdateRes.DeletedAzureFile_, dirFile) }");
                                }
                                else
                                {
                                    ErrorAppend(sbError, $"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingAzureFile_, dirFile) }");
                                }
                            }
                        }

                        Response<bool> responseDir = directorySub.DeleteIfExists();

                        if (responseDir.Value)
                        {
                            LogAppend(sbLog, $"{ String.Format(CSSPCultureUpdateRes.DeletedAzureDirectory_, shareFileItem.Name) }");
                        }
                        else
                        {
                            ErrorAppend(sbError, $"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingAzureDirectory_, shareFileItem.Name) }");
                        }
                    }
                }
            }

            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.End } DoRemoveAzureDirectoriesNotFoundInTVFiles ...");

            await StoreInCommandLog(sbLog, sbError, "RemoveAzureDirectoriesNotFoundInTVFiles");

            return await Task.FromResult(true);
        }
    }
}
