/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
