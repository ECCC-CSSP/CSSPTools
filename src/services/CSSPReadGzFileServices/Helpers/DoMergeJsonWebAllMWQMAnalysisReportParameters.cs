/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
    {
        private async Task<bool> MergeJsonWebAllMWQMAnalysisReportParameters(WebAllMWQMAnalysisReportParameters webAllMWQMAnalysisReportParameters, WebAllMWQMAnalysisReportParameters webAllMWQMAnalysisReportParametersLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllMWQMAnalysisReportParameters webAllMWQMAnalysisReportParameters, WebAllMWQMAnalysisReportParameters webAllMWQMAnalysisReportParametersLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            MergeJsonWebSubsectorMWQMAnalysisReportParameterList(webAllMWQMAnalysisReportParameters, webAllMWQMAnalysisReportParametersLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void MergeJsonWebSubsectorMWQMAnalysisReportParameterList(WebAllMWQMAnalysisReportParameters webAllMWQMAnalysisReportParameters, WebAllMWQMAnalysisReportParameters webAllMWQMAnalysisReportParametersLocal)
        {
            List<MWQMAnalysisReportParameter> MWQMAnalysisReportParameterLocalList = (from c in webAllMWQMAnalysisReportParametersLocal.MWQMAnalysisReportParameterList
                                                                                      where c.SubsectorTVItemID != 0
                                                                                      && c.DBCommand != DBCommandEnum.Original
                                                                                      select c).ToList();

            foreach (MWQMAnalysisReportParameter mwqmAnalysisReportParameterLocal in MWQMAnalysisReportParameterLocalList)
            {
                MWQMAnalysisReportParameter mwqmAnalysisReportParameterOriginal = webAllMWQMAnalysisReportParameters.MWQMAnalysisReportParameterList.Where(c => c.SubsectorTVItemID == mwqmAnalysisReportParameterLocal.SubsectorTVItemID).FirstOrDefault();
                if (mwqmAnalysisReportParameterOriginal == null)
                {
                    webAllMWQMAnalysisReportParameters.MWQMAnalysisReportParameterList.Add(mwqmAnalysisReportParameterLocal);
                }
                else
                {
                    mwqmAnalysisReportParameterOriginal = mwqmAnalysisReportParameterLocal;
                }
            }
        }
    }
}
