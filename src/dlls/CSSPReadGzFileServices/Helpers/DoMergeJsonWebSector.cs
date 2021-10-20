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

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ControllerBase, ICSSPReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebSector(WebSector webSector, WebSector webSectorLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebSector WebSector, WebSector WebSectorLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebSectorTVItemModel(webSector, webSectorLocal);

            DoMergeJsonWebSectorTVItemModelParentList(webSector, webSectorLocal);

            DoMergeJsonWebSectorTVItemModelSubsectorList(webSector, webSectorLocal);

            DoMergeJsonWebSectorTVFileModelList(webSector, webSectorLocal);

            DoMergeJsonWebSectorIsLocalized(webSector, webSectorLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void DoMergeJsonWebSectorTVItemModel(WebSector webSector, WebSector webSectorLocal)
        {
            if (webSectorLocal.TVItemModel.TVItem.TVItemID != 0
                && (webSectorLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || webSectorLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || webSectorLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                SyncTVItemModel(webSector.TVItemModel, webSectorLocal.TVItemModel);
            }
        }
        private void DoMergeJsonWebSectorTVItemModelParentList(WebSector webSector, WebSector webSectorLocal)
        {
            if ((from c in webSectorLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                SyncTVItemModelParentList(webSector.TVItemModelParentList, webSectorLocal.TVItemModelParentList);
            }
        }
        private void DoMergeJsonWebSectorTVItemModelSubsectorList(WebSector webSector, WebSector webSectorLocal)
        {
            List<TVItemModel> TVItemModelLocalList = (from c in webSectorLocal.TVItemModelSubsectorList
                                                      where c.TVItem.TVItemID != 0
                                                      && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                      select c).ToList();

            foreach (TVItemModel TVItemModelLocal in TVItemModelLocalList)
            {
                TVItemModel TVItemModelOriginal = webSector.TVItemModelSubsectorList.Where(c => c.TVItem.TVItemID == TVItemModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (TVItemModelOriginal == null)
                {
                    webSector.TVItemModelSubsectorList.Add(TVItemModelLocal);
                }
                else
                {
                    SyncTVItemModel(TVItemModelOriginal, TVItemModelLocal);
                }
            }

        }
        private void DoMergeJsonWebSectorTVFileModelList(WebSector webSector, WebSector webSectorLocal)
        {
            List<TVFileModel> TVFileModelLocalList = (from c in webSectorLocal.TVFileModelList
                                                      where c.TVFile.TVFileID != 0
                                                      && (c.TVFile.DBCommand != DBCommandEnum.Original
                                                      || c.TVFileLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVFileLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                      select c).ToList();

            foreach (TVFileModel tvFileModelLocal in TVFileModelLocalList)
            {
                TVFileModel tvFileModelOriginal = webSector.TVFileModelList.Where(c => c.TVFile.TVFileID == tvFileModelLocal.TVFile.TVFileID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    webSector.TVFileModelList.Add(tvFileModelLocal);
                }
                else
                {
                    SyncTVFileModel(tvFileModelOriginal, tvFileModelLocal);
                }
            }
        }
        private void DoMergeJsonWebSectorIsLocalized(WebSector webSector, WebSector webSectorLocal)
        {
            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ webSector.TVItemModel.TVItem.TVItemID }\\");

            if (di.Exists)
            {
                List<FileInfo> FileInfoList = di.GetFiles().ToList();

                foreach (TVFileModel tvFileModel in webSector.TVFileModelList)
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
