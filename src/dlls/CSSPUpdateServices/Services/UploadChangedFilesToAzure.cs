﻿/*
 * Manually edited
 * 
 */
using CSSPCreateGzFileServices;
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
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using System.IO;
using Azure.Storage.Files.Shares;
using CSSPCultureServices.Resources;
using Azure;
using Azure.Storage.Files.Shares.Models;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        public async Task<ActionResult<bool>> UploadChangedFilesToAzure(DateTime UpdateFromDate)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(DateTime UpdateFromDate) -- UpdateFromDate: { UpdateFromDate }";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            int CountFileTotal = 0;
            int CountFileUploaded = 0;

            DirectoryInfo di = new DirectoryInfo(Configuration["LocalAppDataPath"]);

            List<DirectoryInfo> diList = di.GetDirectories().ToList().Skip(0).Take(100000).ToList();

            int count = 0;
            foreach (DirectoryInfo d in diList)
            {
                count += 1;
                Console.WriteLine($"{ count } --- { d.FullName }");

                ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(Configuration["AzureStore"]), Configuration["AzureStoreCSSPFilesPath"]);
                ShareDirectoryClient directory = shareClient.GetDirectoryClient(d.Name);

                if (!directory.Exists())
                {
                    try
                    {
                        directory.Create();
                    }
                    catch (Exception ex)
                    {
                        CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.CouldNotCreateDirectory_Error_, d.FullName, ex.Message) }");

                        CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);
                        

                        return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                    }
                }

                Pageable<ShareFileItem> shareFileItemList = directory.GetFilesAndDirectories();

                List<FileInfo> fileInfoList = d.GetFiles().Where(c => c.LastWriteTime >= UpdateFromDate).ToList();
                foreach (FileInfo fi in fileInfoList)
                {
                    CountFileTotal += 1;
                    Console.WriteLine($"\t\t File Count: {CountFileTotal} -- { fi.FullName }");


                    bool ShouldUpload = true;
                    foreach (ShareFileItem shareFileItem in shareFileItemList)
                    {
                        if (fi.Name == shareFileItem.Name)
                        {
                            if (fi.Length == shareFileItem.FileSize)
                            {
                                ShouldUpload = false;
                                break;
                            }
                        }
                    }

                    if (ShouldUpload)
                    {
                        try
                        {
                            ShareFileClient file = directory.GetFileClient(fi.Name);
                            using (FileStream stream = System.IO.File.OpenRead(fi.FullName))
                            {
                                if (fi.Length != 0)
                                {

                                    file.Create(stream.Length);
                                    file.Upload(stream);

                                    CountFileUploaded += 1;
                                    CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.UploadedCount_AndFile_, CountFileUploaded, fi.FullName) }");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.CouldNotUploadFile_Error_, d.FullName, ex.Message) }");

                            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);
                            

                            return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                        }
                    }
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);            

            return await Task.FromResult(Ok(true));
        }
    }
}
