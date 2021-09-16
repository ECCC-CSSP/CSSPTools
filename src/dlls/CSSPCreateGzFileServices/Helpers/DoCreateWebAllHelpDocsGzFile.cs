/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateWebAllHelpDocsGzFile()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            WebAllHelpDocs webAllHelpDocs = new WebAllHelpDocs();

            try
            {
                webAllHelpDocs.HelpDocList = await GetHelpDoc();

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebAllHelpDocs>(webAllHelpDocs, $"{ WebTypeEnum.WebAllHelpDocs }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebAllHelpDocs>(webAllHelpDocs, $"{ WebTypeEnum.WebAllHelpDocs }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                CSSPLogService.AppendError($"{ ex.Message } { inner }");
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
