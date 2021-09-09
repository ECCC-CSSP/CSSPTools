/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using CSSPWebModels;
using System.Linq;
using Microsoft.AspNetCore.Http;
using LoggedInServices;
using ManageServices;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FileServices
{
    public partial class FileService : ControllerBase, IFileService
    {
        public async Task<ActionResult<LocalFileInfo>> GetAzureFileInfo(int ParentTVItemID, string FileName)
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int ParentTVItemID, string FileName) - ParentTVItemID: { ParentTVItemID }  FileName: { FileName }";
            await CSSPLogService.FunctionLog(FunctionName);

            if (!await CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ValidationResultList));

            ShareFileClient shareFileClient;
            ShareFileProperties shareFileProperties;
            try
            {
                ShareClient shareClient = new ShareClient(config.AzureStore, config.AzureStoreCSSPFilesPath);
                ShareDirectoryClient shareDirectoryClient = shareClient.GetDirectoryClient($"{ParentTVItemID}");
                shareFileClient = shareDirectoryClient.GetFileClient(FileName);
                shareFileProperties = shareFileClient.GetProperties();
            }
            catch (Exception ex)
            {
                string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerException: " + ex.InnerException.Message);

                return await EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.ErrorWhileTryingToGetAzureFileInfoFor_Error_, $"{ParentTVItemID}\\{FileName}", ErrorText));
            }

            await CSSPLogService.EndFunctionLog(FunctionName);
            await CSSPLogService.Save();

            return await Task.FromResult(Ok(new LocalFileInfo() { FileName = FileName, Length = shareFileProperties.ContentLength }));
        }
    }
}
