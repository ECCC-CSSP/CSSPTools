/*
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

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
    {
        private void SyncLabSheetModel(LabSheetModel labSheetModelOriginal, LabSheetModel labSheetModelLocal)
        {
            if (labSheetModelLocal != null)
            {
                if (labSheetModelLocal.LabSheet != null)
                {
                    labSheetModelOriginal.LabSheet = labSheetModelLocal.LabSheet;
                }
                if (labSheetModelLocal.LabSheetDetail != null)
                {
                    labSheetModelOriginal.LabSheetDetail = labSheetModelLocal.LabSheetDetail;
                }
                foreach (LabSheetTubeMPNDetail labSheetTubeMPNDetailLocal in labSheetModelLocal.LabSheetTubeMPNDetailList)
                {
                    LabSheetTubeMPNDetail labSheetTubeMPNDetailOriginal = labSheetModelOriginal.LabSheetTubeMPNDetailList.Where(c => c.LabSheetTubeMPNDetailID == labSheetTubeMPNDetailLocal.LabSheetTubeMPNDetailID).FirstOrDefault();
                    if (labSheetTubeMPNDetailOriginal == null)
                    {
                        labSheetModelOriginal.LabSheetTubeMPNDetailList.Add(labSheetTubeMPNDetailLocal);
                    }
                    else
                    {
                        labSheetTubeMPNDetailOriginal = labSheetTubeMPNDetailLocal;
                    }
                }
            }
        }
    }
}
