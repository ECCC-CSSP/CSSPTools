﻿/*
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
using System.Reflection;

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> FillFileModelList(List<TVFileModel> TVFileModelList, TVItem TVItem)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<TVFileModel> TVFileModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath })";
            CSSPLogService.FunctionLog(FunctionName);

            List<TVFile> TVFileList = await GetTVFileListWithTVItemID(TVItem.TVItemID);
            List<TVFileLanguage> TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(TVItem.TVItemID);

            foreach (TVFile tvFile in TVFileList)
            {
                TVFileModel tvFileModel = new TVFileModel();

                tvFileModel.TVFile = TVFileList.Where(c => c.TVFileTVItemID == tvFile.TVFileTVItemID).FirstOrDefault();
                if (tvFileModel.TVFile != null)
                {
                    tvFileModel.TVFileLanguageList = TVFileLanguageList.Where(c => c.TVFileID == tvFileModel.TVFile.TVFileID).ToList();
                }

                TVFileModelList.Add(tvFileModel);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}