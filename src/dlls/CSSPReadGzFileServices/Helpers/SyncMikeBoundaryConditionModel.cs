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
        private void SyncMikeBoundaryConditionModel(MikeBoundaryConditionModel mikeBoundaryConditionModelOriginal, MikeBoundaryConditionModel mikeBoundaryConditionModelLocal)
        {
            if (mikeBoundaryConditionModelLocal != null)
            {
                if (mikeBoundaryConditionModelLocal.TVItemModel != null)
                {
                    SyncTVItemModel(mikeBoundaryConditionModelOriginal.TVItemModel, mikeBoundaryConditionModelLocal.TVItemModel);
                }
                if (mikeBoundaryConditionModelLocal.MikeBoundaryCondition != null)
                {
                    mikeBoundaryConditionModelOriginal.MikeBoundaryCondition = mikeBoundaryConditionModelLocal.MikeBoundaryCondition;
                }
            }
        }
    }
}
