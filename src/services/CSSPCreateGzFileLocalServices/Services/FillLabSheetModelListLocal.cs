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
        private async Task FillLabSheetModelListLocal(List<LabSheetModel> LabSheetModelList, TVItem TVItem)
        {
            List<LabSheet> LabSheetList = await GetLabSheetListUnderSubsector(TVItem.TVItemID);
            List<LabSheetDetail> LabSheetDetailList = await GetLabSheetDetailListUnderSubsector(TVItem.TVItemID);
            List<LabSheetTubeMPNDetail> LabSheetTubeMPNDetailList = await GetLabSheetTubeMPNDetailListUnderSubsector(TVItem.TVItemID);

            foreach (LabSheet LabSheet in LabSheetList)
            {
                LabSheetModel LabSheetModel = new LabSheetModel();
                LabSheetModel.LabSheet = LabSheet;

                foreach(LabSheetDetail LabSheetDetail in LabSheetDetailList)
                {
                    LabSheetDetailModel LabSheetDetailModel = new LabSheetDetailModel();
                    LabSheetDetailModel.LabSheetDetail = LabSheetDetail;
                    LabSheetDetailModel.LabSheetTubeMPNDetailList = LabSheetTubeMPNDetailList.Where(c => c.LabSheetDetailID == LabSheetDetail.LabSheetDetailID).ToList();

                    LabSheetModel.LabSheetDetailModelList.Add(LabSheetDetailModel);
                }

                LabSheetModelList.Add(LabSheetModel);
            }
        }
    }
}