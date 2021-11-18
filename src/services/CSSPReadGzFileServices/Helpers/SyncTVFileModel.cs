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
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
    {
        private void SyncTVFileModel(TVFileModel tvFileModelOriginal, TVFileModel tvFileModelLocal)
        {
            if (tvFileModelLocal != null)
            {
                if (tvFileModelLocal.TVFile != null)
                {
                    tvFileModelOriginal.TVFile = tvFileModelLocal.TVFile;
                }
                if (tvFileModelLocal.TVFileLanguageList != null)
                {
                    tvFileModelOriginal.TVFileLanguageList = tvFileModelLocal.TVFileLanguageList;
                }

                if (tvFileModelOriginal.TVItemModel == null)
                {
                    tvFileModelOriginal.TVItemModel = tvFileModelLocal.TVItemModel;
                }
                else
                {
                    SyncTVItemModel(tvFileModelOriginal.TVItemModel, tvFileModelLocal.TVItemModel);
                }
            }
        }
    }
}
