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
        private void SyncPolSourceGroupingModel(PolSourceGroupingModel polSourceGroupingModelOriginal, PolSourceGroupingModel polSourceGroupingModelLocal)
        {
            if (polSourceGroupingModelLocal.PolSourceGrouping != null)
            {
                polSourceGroupingModelOriginal.PolSourceGrouping = polSourceGroupingModelLocal.PolSourceGrouping;
            }
            if (polSourceGroupingModelLocal.PolSourceGroupingLanguageList != null)
            {
                polSourceGroupingModelOriginal.PolSourceGroupingLanguageList = polSourceGroupingModelLocal.PolSourceGroupingLanguageList;
            }
        }
    }
}
