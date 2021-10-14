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

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void SyncMWQMRunModel(MWQMRunModel mwqmRunModelOriginal, MWQMRunModel mwqmRunModelLocal)
        {
            if (mwqmRunModelLocal != null)
            {
                if (mwqmRunModelLocal.TVItemModel != null)
                {
                    SyncTVItemModel(mwqmRunModelOriginal.TVItemModel, mwqmRunModelLocal.TVItemModel);
                }
                if (mwqmRunModelLocal.MWQMRun != null)
                {
                    mwqmRunModelOriginal.MWQMRun = mwqmRunModelLocal.MWQMRun;
                }
                if (mwqmRunModelLocal.MWQMRunLanguageList != null)
                {
                    mwqmRunModelOriginal.MWQMRunLanguageList = mwqmRunModelLocal.MWQMRunLanguageList;
                }
            }
        }
    }
}
