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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        public async Task<ActionResult<bool>> DoRemoveAzureDirectoriesNotFoundInTVFiles()
        {
            await CSSPLogService.FunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            DirectoryInfo di = new DirectoryInfo(LocalAppDataPath);
            if (!di.Exists)
            {
                await CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.LocalAppDataPathDoesNotExist_, di.FullName) }", new[] { "" }));

                await CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                await CSSPLogService.Save();

                return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
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

            await CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.StartingAzureDirectoryCleanup }");

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

                    await CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletingAzureDirectory_, shareFileItem.Name) }");

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
                                await CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletingAzureFile_, dirFile) }");

                                Response<bool> responseFile = file.DeleteIfExists();

                                if (responseFile.Value)
                                {
                                    await CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletedAzureFile_, dirFile) }");
                                }
                                else
                                {
                                    await CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingAzureFile_, dirFile) }", new[] { "" }));
                                }
                            }
                        }

                        Response<bool> responseDir = directorySub.DeleteIfExists();

                        if (responseDir.Value)
                        {
                            await CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletedAzureDirectory_, shareFileItem.Name) }");
                        }
                        else
                        {
                            await CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingAzureDirectory_, shareFileItem.Name) }", new[] { "" }));
                        }
                    }
                }
            }

            await CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.End } DoRemoveAzureDirectoriesNotFoundInTVFiles ...");

            await CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(Ok(true));
        }
    }
}
