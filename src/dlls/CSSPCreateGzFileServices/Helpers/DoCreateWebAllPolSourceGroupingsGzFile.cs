/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
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
        private async Task<bool> DoCreateWebAllPolSourceGroupingsGzFile()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            WebAllPolSourceGroupings webAllPolSourceGroupings = new WebAllPolSourceGroupings();

            try
            {
                if (!await FillPolSourceGroupingModelList(webAllPolSourceGroupings.PolSourceGroupingModelList)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebAllPolSourceGroupings>(webAllPolSourceGroupings, $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebAllPolSourceGroupings>(webAllPolSourceGroupings, $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
