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
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CSSPFileServices
{
    public partial class CSSPFileService : ControllerBase, ICSSPFileService
    {
        public async Task<ActionResult<bool>> CreateTempCSV(TableConvertToCSVModel tableConvertToCSVModel)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(TableConvertToCSVModel tableConvertToCSVModel) -- TableFileName: { tableConvertToCSVModel.TableFileName }";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));
      
            try
            {
                FileInfo fi = new FileInfo($"{ Configuration["CSSPTempFilesPath"] }\\{tableConvertToCSVModel.TableFileName}");

                CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Creating } { fi.FullName }");

                System.IO.File.WriteAllText(fi.FullName, tableConvertToCSVModel.CSVString);

                fi = new FileInfo($"{ Configuration["CSSPTempFilesPath"] }\\{tableConvertToCSVModel.TableFileName}");

                if (!fi.Exists)
                {
                    return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.FileNotCreated_, fi.FullName));
                }
            }
            catch (Exception ex)
            {
                string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerExcecption: " + ex.InnerException.Message);

                return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNotCreateTemp_FileError_, "CSV", ErrorText));
            }

            return await CSSPLogService.EndFunctionReturnOkTrue(FunctionName);
        }
    }
}
