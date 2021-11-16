﻿/*
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

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> FillReportTypeModelListAsync(List<ReportTypeModel> ReportTypeModelList)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<ReportTypeModel> ReportTypeModelList)";
            CSSPLogService.FunctionLog(FunctionName);

            List<ReportType> ReportTypeList = await GetReportTypeListAsync();
            List<ReportSection> ReportSectionList = await GetReportSectionListAsync();

            foreach(ReportType ReportType in ReportTypeList)
            {
                ReportTypeModel ReportTypeModel = new ReportTypeModel();
                ReportTypeModel.ReportType = ReportType;
                ReportTypeModel.ReportSectionList = ReportSectionList.Where(c => c.ReportTypeID == ReportType.ReportTypeID).ToList();

                ReportTypeModelList.Add(ReportTypeModel);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}