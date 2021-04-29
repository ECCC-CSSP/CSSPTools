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
using System.IO;
using System.Threading.Tasks;

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<bool> DoDeleteGzFileLocal(WebTypeEnum webType, int TVItemID)
        {
            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            if (LoggedInService.LoggedInContactInfo == null || LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(false);
            }

            FileInfo fiToDelete = new FileInfo($"{ CSSPJSONPathLocal }{FileName}");
            if (fiToDelete.Exists)
            {
                try
                {
                    fiToDelete.Delete();
                }
                catch (Exception)
                {
                    return await Task.FromResult(false);
                }
            }
            return await Task.FromResult(true);
        }
    }
}
