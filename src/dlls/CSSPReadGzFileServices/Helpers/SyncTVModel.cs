/*
 * Manually edited
 * 
 */
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
        private void SyncTVModel(TVModel tvModelOriginal, TVModel tvModelLocal)
        {
            if (tvModelLocal != null)
            {
                if (tvModelLocal.TVItem != null)
                {
                    tvModelOriginal.TVItem = tvModelLocal.TVItem;
                }
                if (tvModelLocal.TVItemLanguageList != null)
                {
                    tvModelOriginal.TVItemLanguageList = tvModelLocal.TVItemLanguageList;
                }
            }
        }
    }
}
