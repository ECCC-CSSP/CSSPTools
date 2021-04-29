/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;
using LoggedInServices;
using CSSPWebModels;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllReportTypes(WebAllReportTypes WebAllReportTypes, WebAllReportTypes WebAllReportTypesLocal)
        {
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
        }
    }
}
