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
    public partial class CSSPReadGzFileService : ControllerBase, ICSSPReadGzFileService
    {
        private void SyncDrogueRunModel(DrogueRunModel drogueRunModelOriginal, DrogueRunModel drogueRunModelLocal)
        {
            if (drogueRunModelLocal != null)
            {
                if (drogueRunModelLocal.DrogueRun != null)
                {
                    drogueRunModelOriginal.DrogueRun = drogueRunModelLocal.DrogueRun;
                }

                foreach (DrogueRunPosition drogueRunPositionLocal in drogueRunModelLocal.DrogueRunPositionList)
                {
                    DrogueRunPosition drogueRunPositionOriginal = drogueRunModelOriginal.DrogueRunPositionList.Where(c => c.DrogueRunPositionID == drogueRunPositionLocal.DrogueRunPositionID).FirstOrDefault();

                    if (drogueRunPositionOriginal == null)
                    {
                        drogueRunModelOriginal.DrogueRunPositionList.Add(drogueRunPositionLocal);
                    }
                    else
                    {
                        drogueRunPositionOriginal = drogueRunPositionLocal;
                    }
                }
            }
        }
    }
}
