/*
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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> FillFileModelList(List<TVFileModel> TVFileModelList, TVItem TVItem)
        {
            string FunctionName = $"{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<TVFileModel> TVFileModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath })";
            await CSSPLogService.FunctionLog(FunctionName);

            List<TVItem> TVItemFileList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.File);
            List<TVItemLanguage> TVItemLanguageFileList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.File);

            List<TVFile> TVFileList = await GetTVFileListWithTVItemID(TVItem.TVItemID);
            List<TVFileLanguage> TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(TVItem.TVItemID);

            foreach (TVItem tvItem in TVItemFileList)
            {
                TVFileModel tvFileModel = new TVFileModel();
                tvFileModel.TVItem = tvItem;
                tvFileModel.TVItemLanguageList = TVItemLanguageFileList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                TVFile tvFile = TVFileList.Where(c => c.TVFileTVItemID == tvItem.TVItemID).FirstOrDefault();
                if (tvFile != null)
                {
                    tvFileModel.TVFile = tvFile;
                    tvFileModel.TVFileLanguageList = TVFileLanguageList.Where(c => c.TVFileID == tvFile.TVFileID).ToList();

                    TVFileModelList.Add(tvFileModel);
                }
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}