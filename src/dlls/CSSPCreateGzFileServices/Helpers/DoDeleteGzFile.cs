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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoDeleteGzFile(WebTypeEnum webType, int TVItemID)
        {
            string FunctionName = $"{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum webType, int TVItemID) -- WebTypeEnum: { webType }  TVItemID: { TVItemID }";
            await CSSPLogService.FunctionLog(FunctionName);

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            try
            {
                BlobClient blobClient = new BlobClient(config.AzureStore, config.AzureStoreCSSPJSONPath, FileName);

                Response response = await blobClient.DeleteAsync();
                if (response.Status != 202)
                {
                    await CSSPLogService.AppendError(new System.ComponentModel.DataAnnotations.ValidationResult(string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDelete_FromAzure, FileName), new[] { "" }));
                    await CSSPLogService.EndFunctionLog(FunctionName);
                    return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                await CSSPLogService.AppendError(new System.ComponentModel.DataAnnotations.ValidationResult(string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDelete_FromAzureException_, FileName, ex.Message), new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
