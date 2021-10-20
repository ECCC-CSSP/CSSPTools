/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> DoDeleteGzFile(WebTypeEnum webType, int TVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum webType, int TVItemID) -- WebTypeEnum: { webType }  TVItemID: { TVItemID }";
            CSSPLogService.FunctionLog(FunctionName);

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            try
            {
                BlobClient blobClient = new BlobClient(CSSPScrambleService.Descramble(Configuration["AzureStore"]), Configuration["AzureStoreCSSPJSONPath"], FileName);

                Response response = await blobClient.DeleteAsync();
                if (response.Status != 202)
                {
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDelete_FromAzure, FileName));
                    CSSPLogService.EndFunctionLog(FunctionName);
                    return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDelete_FromAzureException_, FileName, ex.Message));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
