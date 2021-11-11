/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> DoDeleteGzFileAsync(WebTypeEnum webType, int TVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum webType, int TVItemID) -- WebTypeEnum: { webType }  TVItemID: { TVItemID }";
            CSSPLogService.FunctionLog(FunctionName);

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            try
            {
                ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
                ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();

                ShareFileClient file = directory.GetFileClient(FileName);

                Response response = await file.DeleteAsync();

                if (response.Status != 202)
                {
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDelete_FromAzure, FileName));
                    CSSPLogService.EndFunctionLog(FunctionName);
                    return await Task.FromResult(false);
                }

            }
            catch (Exception)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDelete_FromAzure, FileName));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            FileInfo fiBackup = new FileInfo($"{ Configuration["azure_csspjson_backup"] }{ FileName }");
            try
            {
                fiBackup.Delete();
            }
            catch (Exception)
            {
                // nothing required
            }

            FileInfo fiBackupUncompress = new FileInfo($"{ Configuration["azure_csspjson_backup_uncompress"] }{ FileName.Replace(".gz", ".json") }");
            try
            {
                fiBackupUncompress.Delete();
            }
            catch (Exception)
            {
                // nothing required
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
