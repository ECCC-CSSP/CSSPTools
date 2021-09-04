/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPWebModels;
using System.Reflection;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> FillReportTypeModelList(List<ReportTypeModel> ReportTypeModelList)
        {
            string FunctionName = $"{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<ReportTypeModel> ReportTypeModelList)";
            await CSSPLogService.FunctionLog(FunctionName);

            List<ReportType> ReportTypeList = await GetReportTypeList();
            List<ReportSection> ReportSectionList = await GetReportSectionList();

            foreach(ReportType ReportType in ReportTypeList)
            {
                ReportTypeModel ReportTypeModel = new ReportTypeModel();
                ReportTypeModel.ReportType = ReportType;
                ReportTypeModel.ReportSectionList = ReportSectionList.Where(c => c.ReportTypeID == ReportType.ReportTypeID).ToList();

                ReportTypeModelList.Add(ReportTypeModel);
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}