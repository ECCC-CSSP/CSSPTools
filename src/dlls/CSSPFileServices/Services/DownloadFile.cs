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
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace FileServices
{
    public partial class FileService : ControllerBase, IFileService
    {
        public async Task<ActionResult> DownloadFile(int ParentTVItemID, string FileName)
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int ParentTVItemID, string FileName) - ParentTVItemID: { ParentTVItemID } FileName: { FileName }";
            await CSSPLogService.FunctionLog(FunctionName);

            if (!await CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ValidationResultList));

            FileInfo fi = new FileInfo($"{config.CSSPFilesPath}{ParentTVItemID}\\{FileName}");

            if (!fi.Exists)
            {
                return await EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNotFindFile_, fi.FullName));
            }

            FileStream fileStream = fi.OpenRead();

            if (fileStream == null)
            {
                return await EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNotOpenFile_ForStreaming, fi.FullName));
            }

            await CSSPLogService.EndFunctionLog(FunctionName);
            await CSSPLogService.Save();

            return File(fileStream, "application/octet-stream");

        }
    }
}
