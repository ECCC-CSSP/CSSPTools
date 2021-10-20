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
        private async Task<bool> DoMergeJsonWebMWQMSites(WebMWQMSites webMWQMSites, WebMWQMSites webMWQMSitesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebMWQMSites WebMWQMSites, WebMWQMSites WebMWQMSitesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebMWQMSitesTVItemModel(webMWQMSites, webMWQMSitesLocal);

            DoMergeJsonWebMWQMSitesTVItemModelParentList(webMWQMSites, webMWQMSitesLocal);

            DoMergeJsonWebMWQMSitesMWQMSiteModelList(webMWQMSites, webMWQMSitesLocal);

            DoMergeJsonWebMWQMSitesIsLocalized(webMWQMSites, webMWQMSitesLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void DoMergeJsonWebMWQMSitesTVItemModel(WebMWQMSites webMWQMSites, WebMWQMSites webMWQMSitesLocal)
        {
            if (webMWQMSitesLocal.TVItemModel.TVItem.TVItemID != 0
                && (webMWQMSitesLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
              || webMWQMSitesLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
              || webMWQMSitesLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                SyncTVItemModel(webMWQMSites.TVItemModel, webMWQMSitesLocal.TVItemModel);
            }
        }
        private void DoMergeJsonWebMWQMSitesTVItemModelParentList(WebMWQMSites webMWQMSites, WebMWQMSites webMWQMSitesLocal)
        {
            if ((from c in webMWQMSitesLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                SyncTVItemModelParentList(webMWQMSites.TVItemModelParentList, webMWQMSitesLocal.TVItemModelParentList);
            }
        }
        private void DoMergeJsonWebMWQMSitesMWQMSiteModelList(WebMWQMSites webMWQMSites, WebMWQMSites webMWQMSitesLocal)
        {
            List<MWQMSiteModel> MWQMSiteModelLocalList = (from c in webMWQMSitesLocal.MWQMSiteModelList
                                                          where c.TVItemModel.TVItem.TVItemID != 0
                                                          && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                          select c).ToList();

            foreach (MWQMSiteModel mwqmSiteModelLocal in MWQMSiteModelLocalList)
            {
                MWQMSiteModel mwqmSiteModelOriginal = (from c in webMWQMSites.MWQMSiteModelList
                                                       where c.TVItemModel.TVItem.TVItemID == mwqmSiteModelLocal.TVItemModel.TVItem.TVItemID
                                                       select c).FirstOrDefault();
                if (mwqmSiteModelOriginal == null)
                {
                    webMWQMSites.MWQMSiteModelList.Add(mwqmSiteModelLocal);
                }
                else
                {
                    SyncMWQMSiteModel(mwqmSiteModelOriginal, mwqmSiteModelLocal);
                }
            }
        }
        private void DoMergeJsonWebMWQMSitesIsLocalized(WebMWQMSites webMWQMSites, WebMWQMSites webMWQMSitesLocal)
        {
            foreach (MWQMSiteModel mwqmSiteModel in webMWQMSites.MWQMSiteModelList)
            {
                // checking if files are localized
                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ mwqmSiteModel.TVItemModel.TVItem.TVItemID }\\");

                if (di.Exists)
                {
                    List<FileInfo> FileInfoList = di.GetFiles().ToList();

                    foreach (TVFileModel tvFileModel in mwqmSiteModel.TVFileModelList)
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
}
