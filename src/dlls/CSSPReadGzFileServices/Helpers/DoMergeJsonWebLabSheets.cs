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
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebLabSheets(WebLabSheets WebLabSheets, WebLabSheets WebLabSheetsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebLabSheets WebLabSheets, WebLabSheets WebLabSheetsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            if (WebLabSheetsLocal.TVItemModel.TVItem.TVItemID != 0
                && (WebLabSheetsLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebLabSheetsLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebLabSheetsLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                WebLabSheets.TVItemModel = WebLabSheetsLocal.TVItemModel;
            }

            if ((from c in WebLabSheetsLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                WebLabSheets.TVItemModelParentList = WebLabSheetsLocal.TVItemModelParentList;
            }

            List<LabSheetModel> LabSheetModelList = (from c in WebLabSheetsLocal.LabSheetModelList
                                                               where c.LabSheet.LabSheetID != 0
                                                               && (c.LabSheet.DBCommand != DBCommandEnum.Original
                                                               || c.LabSheetDetail.DBCommand != DBCommandEnum.Original
                                                               || (from d in c.LabSheetTubeMPNDetailList
                                                                   where d.DBCommand != DBCommandEnum.Original
                                                                   select d).Any())
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

            CSSPLogService.FunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
