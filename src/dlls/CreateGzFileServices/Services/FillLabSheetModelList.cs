/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillLabSheetModelList(List<LabSheetModel> LabSheetModelList, TVItem TVItem)
        {
            List<LabSheet> LabSheetList = await GetLabSheetListUnderSubsector(TVItem.TVItemID);
            List<LabSheetDetail> LabSheetDetailList = await GetLabSheetDetailListUnderSubsector(TVItem.TVItemID);
            List<LabSheetTubeMPNDetail> LabSheetTubeMPNDetailList = await GetLabSheetTubeMPNDetailListUnderSubsector(TVItem.TVItemID);

            foreach (LabSheet labSheet in LabSheetList)
            {
                LabSheetModel labSheetModel = new LabSheetModel();
                labSheetModel.LabSheet = labSheet;

                foreach(LabSheetDetail labSheetDetail in LabSheetDetailList)
                {
                    LabSheetDetailModel labSheetDetailModel = new LabSheetDetailModel();
                    labSheetDetailModel.LabSheetDetail = labSheetDetail;
                    labSheetDetailModel.LabSheetTubeMPNDetailList = LabSheetTubeMPNDetailList.Where(c => c.LabSheetDetailID == labSheetDetail.LabSheetDetailID).ToList();

                    labSheetModel.LabSheetDetailModelList.Add(labSheetDetailModel);
                }

                LabSheetModelList.Add(labSheetModel);
            }
        }
    }
}