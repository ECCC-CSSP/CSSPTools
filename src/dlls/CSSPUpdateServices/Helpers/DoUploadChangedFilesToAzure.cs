using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        public async Task<ActionResult<bool>> DoUploadChangedFilesToAzure()
        {
            CSSPLogService.FunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            //int CountFileTotal = 0;
            //int CountFileUploaded = 0;

            //DirectoryInfo di = new DirectoryInfo(LocalAppDataPath);

            //List<DirectoryInfo> diList = di.GetDirectories().ToList().Skip(0).Take(10000).ToList();

            //int count = 0;
            //foreach (DirectoryInfo d in diList)
            //{
            //    count += 1;
            //    Console.WriteLine($"{ count } --- { d.FullName }");

            //    ShareClient shareClient = new ShareClient(AzureStore, AzureStoreCSSPFilesPath);
            //    ShareDirectoryClient directory = shareClient.GetDirectoryClient(d.Name);

            //    if (!directory.Exists())
            //    {
            //        try
            //        {
            //            directory.Create();
            //        }
            //        catch (Exception ex)
            //        {
            //            CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.CouldNotCreateDirectory_Error_, d.FullName, ex.Message) }");

            //            await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.UploadAllFilesToAzure);

            //            return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            //        }
            //    }

            //    Pageable<ShareFileItem> shareFileItemList = directory.GetFilesAndDirectories();

            //    List<FileInfo> fileInfoList = d.GetFiles().ToList();
            //    foreach (FileInfo fi in fileInfoList)
            //    {
            //        CountFileTotal += 1;
            //        Console.WriteLine($"\t\t File Count: {CountFileTotal} -- { fi.FullName }");


            //        bool ShouldUpload = true;
            //        foreach (ShareFileItem shareFileItem in shareFileItemList)
            //        {
            //            if (fi.Name == shareFileItem.Name)
            //            {
            //                if (fi.Length == shareFileItem.FileSize)
            //                {
            //                    ShouldUpload = false;
            //                    break;
            //                }
            //            }
            //        }

            //        if (ShouldUpload)
            //        {
            //            try
            //            {
            //                ShareFileClient file = directory.GetFileClient(fi.Name);
            //                using (FileStream stream = File.OpenRead(fi.FullName))
            //                {
            //                    if (fi.Length != 0)
            //                    {

            //                        file.Create(stream.Length);
            //                        file.Upload(stream);

            //                        CountFileUploaded += 1;
            //                        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.UploadedCount_AndFile_, CountFileUploaded, fi.FullName) }");
            //                    }
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.CouldNotUploadFile_Error_, d.FullName, ex.Message) }");

            //                await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.UploadAllFilesToAzure);

            //                return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            //            }
            //        }
            //    }
            //}

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(Ok(true));
        }
    }
}
