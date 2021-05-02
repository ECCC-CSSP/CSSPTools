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
        private static void DoMergeJsonWebLabSheets(WebLabSheets WebLabSheets, WebLabSheets WebLabSheetsLocal)
        {
            if (WebLabSheetsLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebLabSheetsLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebLabSheetsLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebLabSheets.TVItemModel = WebLabSheetsLocal.TVItemModel;
            }

            if ((from c in WebLabSheetsLocal.TVItemModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebLabSheets.TVItemModelParentList = WebLabSheetsLocal.TVItemModelParentList;
            }

            List<LabSheetModel> LabSheetModelList = (from c in WebLabSheetsLocal.LabSheetModelList
                                                               where c.LabSheet.DBCommand != DBCommandEnum.Original
                                                               || c.LabSheetDetail.DBCommand != DBCommandEnum.Original
                                                               || (from d in c.LabSheetTubeMPNDetailList
                                                                   where d.DBCommand != DBCommandEnum.Original
                                                                   select d).Any()
                                                               select c).ToList();

            foreach (LabSheetModel labSheetModel in LabSheetModelList)
            {
                LabSheetModel labSheetModelOriginal = WebLabSheets.LabSheetModelList.Where(c => c.LabSheet.LabSheetID == labSheetModel.LabSheet.LabSheetID).FirstOrDefault();
                if (labSheetModelOriginal == null)
                {
                    WebLabSheets.LabSheetModelList.Add(labSheetModelOriginal);
                }
                else
                {
                    labSheetModelOriginal = labSheetModel;
                }
            }
        }
    }
}
