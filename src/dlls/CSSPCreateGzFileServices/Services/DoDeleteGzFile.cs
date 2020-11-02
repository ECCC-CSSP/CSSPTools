/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
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
                return await Task.FromResult(Unauthorized());
            }

            try
            {
                BlobClient blobClient = new BlobClient(AzureStoreConnectionString, AzureStoreCSSPJSONPath, FileName);

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
