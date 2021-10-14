/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebRoot(WebRoot webRoot, WebRoot webRootLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebRoot WebRoot, WebRoot WebRootLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebRootTVItemModel(webRoot, webRootLocal);

            DoMergeJsonWebRootTVItemModelParentList(webRoot, webRootLocal);

            DoMergeJsonWebRootTVItemModelCountryList(webRoot, webRootLocal);

            DoMergeJsonWebRootTVFileModelList(webRoot, webRootLocal);

            DoMergeJsonWebRootIsLocalized(webRoot, webRootLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void DoMergeJsonWebRootTVItemModel(WebRoot webRoot, WebRoot webRootLocal)
        {
            if (webRootLocal.TVItemModel.TVItem.TVItemID != 0
                && (webRootLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || webRootLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || webRootLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                SyncTVItemModel(webRoot.TVItemModel, webRootLocal.TVItemModel);
            }
        }
        private void DoMergeJsonWebRootTVItemModelParentList(WebRoot webRoot, WebRoot webRootLocal)
        {
            if ((from c in webRootLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                SyncTVItemModelParentList(webRoot.TVItemModelParentList, webRootLocal.TVItemModelParentList);
            }
        }
        private void DoMergeJsonWebRootTVItemModelCountryList(WebRoot webRoot, WebRoot webRootLocal)
        {
            List<TVItemModel> TVItemModelLocalList = (from c in webRootLocal.TVItemModelCountryList
                                                 where c.TVItem.TVItemID != 0
                                                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                 select c).ToList();

            foreach (TVItemModel TVItemModelLocal in TVItemModelLocalList)
            {
                TVItemModel TVItemModelOriginal = webRoot.TVItemModelCountryList.Where(c => c.TVItem.TVItemID == TVItemModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (TVItemModelOriginal == null)
                {
                    webRoot.TVItemModelCountryList.Add(TVItemModelLocal);
                }
                else
                {
                    SyncTVItemModel(TVItemModelOriginal, TVItemModelLocal);
                }
            }
        }
        private void DoMergeJsonWebRootTVFileModelList(WebRoot webRoot, WebRoot webRootLocal)
        {
            List<TVFileModel> TVFileModelLocalList = (from c in webRootLocal.TVFileModelList
                                                 where c.TVItem.TVItemID != 0
                                                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                 select c).ToList();

            foreach (TVFileModel tvFileModelLocal in TVFileModelLocalList)
            {
                TVFileModel tvFileModelOriginal = webRoot.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    webRoot.TVFileModelList.Add(tvFileModelLocal);
                }
                else
                {
                    SyncTVFileModel(tvFileModelOriginal, tvFileModelLocal);
                }
            }
        }
        private void DoMergeJsonWebRootIsLocalized(WebRoot webRoot, WebRoot webRootLocal)
        {
            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ webRoot.TVItemModel.TVItem.TVItemID }\\");

            if (di.Exists)
            {
                List<FileInfo> FileInfoList = di.GetFiles().ToList();

                foreach (TVFileModel tvFileModel in webRoot.TVFileModelList)
                {
                    if ((from c in FileInfoList
                         where c.Name == tvFileModel.TVFile.ServerFileName
                         select c).Any())
                    {
                        tvFileModel.IsLocalized = true;
                    }
                    else
                    {
                        tvFileModel.IsLocalized = false;
                    }
                }
            }
        }
    }
}
