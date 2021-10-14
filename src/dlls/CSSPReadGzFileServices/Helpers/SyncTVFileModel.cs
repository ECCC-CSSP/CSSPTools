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

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void SyncTVFileModel(TVFileModel tvFileModelOriginal, TVFileModel tvFileModelLocal)
        {
            if (tvFileModelLocal != null)
            {
                if (tvFileModelLocal.TVItem != null)
                {
                    tvFileModelOriginal.TVItem = tvFileModelLocal.TVItem;
                }
                if (tvFileModelLocal.TVItemLanguageList != null)
                {
                    tvFileModelOriginal.TVItemLanguageList = tvFileModelLocal.TVItemLanguageList;
                }
                if (tvFileModelLocal.MapInfoModelList != null)
                {
                    tvFileModelOriginal.MapInfoModelList = tvFileModelLocal.MapInfoModelList;
                }
                if (tvFileModelLocal.TVItemStatList != null)
                {
                    tvFileModelOriginal.TVItemStatList = tvFileModelLocal.TVItemStatList;
                }
                if (tvFileModelLocal.TVFile!= null)
                {
                    tvFileModelOriginal.TVFile = tvFileModelLocal.TVFile;
                }
                if (tvFileModelLocal.TVFileLanguageList != null)
                {
                    tvFileModelOriginal.TVFileLanguageList = tvFileModelLocal.TVFileLanguageList;
                }
            }
        }
    }
}
