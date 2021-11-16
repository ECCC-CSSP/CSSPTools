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
using CSSPLocalLoggedInServices;
using ManageServices;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CSSPFileServices
{
    public partial class CSSPFileService : ControllerBase, ICSSPFileService
    {
        public async Task<ActionResult<LocalFileInfo>> GetAzureFileInfo(int ParentTVItemID, string FileName)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int ParentTVItemID, string FileName) - ParentTVItemID: { ParentTVItemID }  FileName: { FileName }";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            ShareFileClient shareFileClient;
            ShareFileProperties shareFileProperties;
            try
            {
                ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(AzureStoreHash), Configuration["AzureStoreCSSPFilesPath"]);
                ShareDirectoryClient shareDirectoryClient = shareClient.GetDirectoryClient($"{ParentTVItemID}");
                shareFileClient = shareDirectoryClient.GetFileClient(FileName);
                shareFileProperties = shareFileClient.GetProperties();
            }
            catch (Exception ex)
            {
                string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerException: " + ex.InnerException.Message);

                return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.ErrorWhileTryingToGetAzureFileInfoFor_Error_, $"{ParentTVItemID}\\{FileName}", ErrorText));
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(new LocalFileInfo() { FileName = FileName, Length = shareFileProperties.ContentLength }));
        }
    }
}
