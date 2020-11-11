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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillReportTypeModelList(List<ReportTypeModel> ReportTypeModelList)
        {
            List<ReportType> ReportTypeList = await GetReportTypeList();
            List<ReportSection> ReportSectionList = await GetReportSectionList();

            foreach(ReportType reportType in ReportTypeList)
            {
                ReportTypeModel reportTypeModel = new ReportTypeModel();
                reportTypeModel.ReportType = reportType;
                reportTypeModel.ReportSectionList = ReportSectionList.Where(c => c.ReportTypeID == reportType.ReportTypeID).ToList();

                ReportTypeModelList.Add(reportTypeModel);
            }
        }
    }
}