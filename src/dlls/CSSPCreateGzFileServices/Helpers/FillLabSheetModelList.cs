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

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> FillLabSheetModelList(List<LabSheetModel> LabSheetModelList, TVItem TVItem)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<LabSheetModel> LabSheetModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath })";
            CSSPLogService.FunctionLog(FunctionName);

            List<LabSheet> LabSheetList = await GetLabSheetListUnderSubsector(TVItem.TVItemID);
            List<LabSheetDetail> LabSheetDetailList = await GetLabSheetDetailListUnderSubsector(TVItem.TVItemID);
            List<LabSheetTubeMPNDetail> LabSheetTubeMPNDetailList = await GetLabSheetTubeMPNDetailListUnderSubsector(TVItem.TVItemID);

            foreach (LabSheet LabSheet in LabSheetList)
            {
                LabSheetModel LabSheetModel = new LabSheetModel();
                LabSheetModel.LabSheet = LabSheet;
                LabSheetModel.LabSheetDetail = LabSheetDetailList.Where(c => c.LabSheetID == LabSheet.LabSheetID).FirstOrDefault();
                if (LabSheetModel.LabSheetDetail != null)
                {
                    LabSheetModel.LabSheetTubeMPNDetailList = LabSheetTubeMPNDetailList.Where(c => c.LabSheetDetailID == LabSheetModel.LabSheetDetail.LabSheetDetailID).ToList();
                }

                LabSheetModelList.Add(LabSheetModel);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}