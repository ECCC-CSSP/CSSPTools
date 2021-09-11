/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllReportTypes(WebAllReportTypes WebAllReportTypes, WebAllReportTypes WebAllReportTypesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllReportTypes WebAllReportTypes, WebAllReportTypes WebAllReportTypesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            List<ReportTypeModel> reportTypeModelLocalList = (from c in WebAllReportTypesLocal.ReportTypeModelList
                                                              where c.ReportType.DBCommand != DBCommandEnum.Original
                                                              || (from r in c.ReportSectionList
                                                                  where r.DBCommand != DBCommandEnum.Original
                                                                  select r).Any()
                                                              select c).ToList();

            foreach (ReportTypeModel reportTypeModelLocal in reportTypeModelLocalList)
            {
                ReportTypeModel reportTypeModelOriginal = WebAllReportTypes.ReportTypeModelList.Where(c => c.ReportType.ReportTypeID == reportTypeModelLocal.ReportType.ReportTypeID).FirstOrDefault();
                if (reportTypeModelOriginal == null)
                {
                    WebAllReportTypes.ReportTypeModelList.Add(reportTypeModelLocal);
                }
                else
                {
                    reportTypeModelOriginal = reportTypeModelLocal;
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);
        }
    }
}
