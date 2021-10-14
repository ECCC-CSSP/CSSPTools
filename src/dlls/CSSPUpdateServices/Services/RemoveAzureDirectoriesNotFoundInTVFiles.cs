/*
 * Manually edited
 * 
 */
using Azure;
using CreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        public async Task<ActionResult<bool>> RemoveAzureDirectoriesNotFoundInTVFiles()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            DirectoryInfo di = new DirectoryInfo(Configuration["LocalAppDataPath"]);
            if (!di.Exists)
            {
                CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.LocalAppDataPathDoesNotExist_, di.FullName) }");

                CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);                

                return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
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

            ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(Configuration["AzureStore"]), Configuration["AzureStoreCSSPFilesPath"]);
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

                    CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.DeletingAzureDirectory_, shareFileItem.Name) }");

                    if (shareFileItem.IsDirectory)
                    {
                        ShareClient shareClientSub = new ShareClient(CSSPScrambleService.Descramble(Configuration["AzureStore"]), Configuration["AzureStoreCSSPFilesPath"]);
                        ShareDirectoryClient directorySub = shareClientSub.GetDirectoryClient(shareFileItem.Name);

                        if (directorySub.Exists())
                        {
                            foreach (ShareFileItem shareFileItemSub in directorySub.GetFilesAndDirectories())
                            {
                                ShareFileClient file = directorySub.GetFileClient(shareFileItemSub.Name);

                                string dirFile = $@"{shareFileItem.Name}\{shareFileItemSub.Name}";
                                CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.DeletingAzureFile_, dirFile) }");

                                Response<bool> responseFile = file.DeleteIfExists();

                                if (responseFile.Value)
                                {
                                    CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.DeletedAzureFile_, dirFile) }");
                                }
                                else
                                {
                                    CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.ErrorDeletingAzureFile_, dirFile) }");
                                }
                            }
                        }

                        Response<bool> responseDir = directorySub.DeleteIfExists();

                        if (responseDir.Value)
                        {
                            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.DeletedAzureDirectory_, shareFileItem.Name) }");
                        }
                        else
                        {
                            CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.ErrorDeletingAzureDirectory_, shareFileItem.Name) }");
                        }
                    }
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);            

            return await Task.FromResult(Ok(true));
        }
    }
}
