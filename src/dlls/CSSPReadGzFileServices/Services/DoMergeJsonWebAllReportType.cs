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
            // -----------------------------------------------------------
            // doing ReportTypeModelList
            // -----------------------------------------------------------
            int count = WebAllReportTypes.ReportTypeModelList.Count;
            for (int i = 0; i < count; i++)
            {
                ReportTypeModel ReportTypeModelLocal = (from c in WebAllReportTypesLocal.ReportTypeModelList
                                                        where c.ReportType.ReportTypeID == WebAllReportTypes.ReportTypeModelList[i].ReportType.ReportTypeID
                                                        && c.ReportType.DBCommand != DBCommandEnum.Original
                                                        select c).FirstOrDefault();

                if (ReportTypeModelLocal != null)
                {
                    WebAllReportTypes.ReportTypeModelList[i] = ReportTypeModelLocal;
                }
            }

            List<ReportTypeModel> ReportTypeModelLocalNewList = (from c in WebAllReportTypesLocal.ReportTypeModelList
                                                                 where c.ReportType.DBCommand == DBCommandEnum.Created
                                                                 select c).ToList();

            foreach (ReportTypeModel ReportTypeModelNew in ReportTypeModelLocalNewList)
            {
                // -----------------------------------------------------------
                // doing ReportTypeList
                // -----------------------------------------------------------
                int count2 = ReportTypeModelNew.ReportSectionList.Count;
                for (int j = 0; j < count2; j++)
                {
                    ReportSection ReportSectionLocal = (from c in ReportTypeModelNew.ReportSectionList
                                                        where c.ReportSectionID == ReportTypeModelNew.ReportSectionList[j].ReportSectionID
                                                        && c.DBCommand != DBCommandEnum.Original
                                                        select c).FirstOrDefault();

                    if (ReportSectionLocal != null)
                    {
                        ReportTypeModelNew.ReportSectionList[j] = ReportSectionLocal;
                    }
                }

                List<ReportSection> ReportSectionLocalNewList = (from c in ReportTypeModelNew.ReportSectionList
                                                                 where c.DBCommand == DBCommandEnum.Created
                                                                 select c).ToList();

                foreach (ReportSection ReportSectionNew in ReportSectionLocalNewList)
                {
                    ReportTypeModelNew.ReportSectionList.Add(ReportSectionNew);
                }

                WebAllReportTypes.ReportTypeModelList.Add(ReportTypeModelNew);
            }

            return;
        }
    }
}
