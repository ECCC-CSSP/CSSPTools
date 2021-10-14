﻿/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void SyncReportTypeModel(ReportTypeModel reportTypeModelOriginal, ReportTypeModel reportTypeModelLocal)
        {
            if (reportTypeModelLocal != null)
            {
                if (reportTypeModelLocal.ReportType != null)
                {
                    reportTypeModelOriginal.ReportType = reportTypeModelLocal.ReportType;
                }
                if (reportTypeModelLocal.ReportSectionList != null)
                {
                    reportTypeModelOriginal.ReportSectionList = reportTypeModelLocal.ReportSectionList;
                }
            }
        }
    }
}
