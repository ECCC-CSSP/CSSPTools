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
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoDeleteGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID, webTypeYear);

            if (LoggedInService.LoggedInContactInfo == null || LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            try
            {
                BlobClient blobClient = new BlobClient(AzureStore, AzureStoreCSSPJSONPath, FileName);

                Response response = await blobClient.DeleteAsync();
                if (response.Status == 202)
                {
                    return await Task.FromResult(Ok(true));
                }
                else
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDelete_FromAzure, FileName)));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDelete_FromAzureException_, FileName, ex.Message)));
            }
        }
    }
}
