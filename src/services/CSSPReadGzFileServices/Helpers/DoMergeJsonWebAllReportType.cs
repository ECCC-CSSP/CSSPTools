/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebAllReportTypes(WebAllReportTypes webAllReportTypes, WebAllReportTypes webAllReportTypesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllReportTypes WebAllReportTypes, WebAllReportTypes WebAllReportTypesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebAllReportsTypesReportTypeModelList(webAllReportTypes, webAllReportTypesLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }

        private void DoMergeJsonWebAllReportsTypesReportTypeModelList(WebAllReportTypes webAllReportTypes, WebAllReportTypes webAllReportTypesLocal)
        {
            List<ReportTypeModel> reportTypeModelLocalList = (from c in webAllReportTypesLocal.ReportTypeModelList
                                                              where c.ReportType.DBCommand != DBCommandEnum.Original
                                                              || (from r in c.ReportSectionList
                                                                  where r.DBCommand != DBCommandEnum.Original
                                                                  select r).Any()
                                                              select c).ToList();

            foreach (ReportTypeModel reportTypeModelLocal in reportTypeModelLocalList)
            {
                ReportTypeModel reportTypeModelOriginal = webAllReportTypes.ReportTypeModelList.Where(c => c.ReportType.ReportTypeID == reportTypeModelLocal.ReportType.ReportTypeID).FirstOrDefault();
                if (reportTypeModelOriginal == null)
                {
                    webAllReportTypes.ReportTypeModelList.Add(reportTypeModelLocal);
                }
                else
                {
                    SyncReportTypeModel(reportTypeModelOriginal, reportTypeModelLocal);
                }
            }
        }
    }
}
