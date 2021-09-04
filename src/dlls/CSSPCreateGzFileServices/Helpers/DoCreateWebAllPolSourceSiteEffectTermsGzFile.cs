/*
 * Manually edited
 * 
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CSSPWebModels;
using CSSPEnums;
using CSSPCultureServices.Resources;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateWebAllPolSourceSiteEffectTermsGzFile()
        {
            string FunctionName = $"{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            await CSSPLogService.FunctionLog(FunctionName);

            WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms = new WebAllPolSourceSiteEffectTerms();

            try
            {
                webAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList = await GetPolSourceSiteEffectTermList();

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebAllPolSourceSiteEffectTerms>(webAllPolSourceSiteEffectTerms, $"{ WebTypeEnum.WebAllPolSourceSiteEffectTerms }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebAllPolSourceSiteEffectTerms>(webAllPolSourceSiteEffectTerms, $"{ WebTypeEnum.WebAllPolSourceSiteEffectTerms }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                await CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}