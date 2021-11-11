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

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> DoCreateWebAllMWQMAnalysisReportParametersGzFileAsync()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            WebAllMWQMAnalysisReportParameters webAllMWQMAnalysisReportParameters = new WebAllMWQMAnalysisReportParameters();

            try
            {
                webAllMWQMAnalysisReportParameters.MWQMAnalysisReportParameterList = await GetAllMWQMAnalysisReportParameterListAsync();

                if (dbLocal != null)
                {
                    if (!await DoStoreLocalAsync<WebAllMWQMAnalysisReportParameters>(webAllMWQMAnalysisReportParameters, $"{ WebTypeEnum.WebAllMWQMAnalysisReportParameters }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStoreAsync<WebAllMWQMAnalysisReportParameters>(webAllMWQMAnalysisReportParameters, $"{ WebTypeEnum.WebAllMWQMAnalysisReportParameters }.gz")) return await Task.FromResult(false);
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
