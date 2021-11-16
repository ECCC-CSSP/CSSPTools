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

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task FillReportTypeModelListLocal(List<ReportTypeModel> ReportTypeModelList)
        {
            List<ReportType> ReportTypeList = await GetReportTypeList();
            List<ReportSection> ReportSectionList = await GetReportSectionList();

            foreach(ReportType ReportType in ReportTypeList)
            {
                ReportTypeModel ReportTypeModel = new ReportTypeModel();
                ReportTypeModel.ReportType = ReportType;
                ReportTypeModel.ReportSectionList = ReportSectionList.Where(c => c.ReportTypeID == ReportType.ReportTypeID).ToList();

                ReportTypeModelList.Add(ReportTypeModel);
            }
        }
    }
}