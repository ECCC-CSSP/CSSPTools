﻿/*
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
        private async Task<bool> DoMergeJsonWebPolSourceSites(WebPolSourceSites webPolSourceSites, WebPolSourceSites webPolSourceSitesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebPolSourceSites WebPolSourceSites, WebPolSourceSites WebPolSourceSitesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebPolSourceSitesTVItemModel(webPolSourceSites, webPolSourceSitesLocal);

            DoMergeJsonWebPolSourceSitesTVItemModelParentList(webPolSourceSites, webPolSourceSitesLocal);

            DoMergeJsonWebPolSourceSitesPolSourceSiteModelList(webPolSourceSites, webPolSourceSitesLocal);

            DoMergeJsonWebPolSourceSitesIsLocalized(webPolSourceSites, webPolSourceSitesLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void DoMergeJsonWebPolSourceSitesTVItemModel(WebPolSourceSites webPolSourceSites, WebPolSourceSites webPolSourceSitesLocal)
        {
            if (webPolSourceSitesLocal.TVItemModel.TVItem.TVItemID != 0
                && (webPolSourceSitesLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
              || webPolSourceSitesLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
              || webPolSourceSitesLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                SyncTVItemModel(webPolSourceSites.TVItemModel, webPolSourceSitesLocal.TVItemModel);
            }
        }
        private void DoMergeJsonWebPolSourceSitesTVItemModelParentList(WebPolSourceSites webPolSourceSites, WebPolSourceSites webPolSourceSitesLocal)
        {
            if ((from c in webPolSourceSitesLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                SyncTVItemModelParentList(webPolSourceSites.TVItemModelParentList, webPolSourceSitesLocal.TVItemModelParentList);
            }
        }
        private void DoMergeJsonWebPolSourceSitesPolSourceSiteModelList(WebPolSourceSites webPolSourceSites, WebPolSourceSites webPolSourceSitesLocal)
        {
            List<PolSourceSiteModel> PolSourceSiteModelLocalList = (from c in webPolSourceSitesLocal.PolSourceSiteModelList
                                                               where c.PolSourceSite.PolSourceSiteID != 0
                                                               && c.PolSourceSite.DBCommand != DBCommandEnum.Original
                                                               select c).ToList();

            foreach (PolSourceSiteModel mwqmPolSourceSiteModelLocal in PolSourceSiteModelLocalList)
            {
                PolSourceSiteModel mwqmPolSourceSiteModelOriginal = webPolSourceSites.PolSourceSiteModelList.Where(c => c.PolSourceSite.PolSourceSiteID == mwqmPolSourceSiteModelLocal.PolSourceSite.PolSourceSiteID).FirstOrDefault();
                if (mwqmPolSourceSiteModelOriginal == null)
                {
                    webPolSourceSites.PolSourceSiteModelList.Add(mwqmPolSourceSiteModelLocal);
                }
                else
                {
                    SyncPolSourceSiteModel(mwqmPolSourceSiteModelOriginal, mwqmPolSourceSiteModelLocal);
                }

                List<TVFileModel> TVFileModelList = (from c in mwqmPolSourceSiteModelLocal.TVFileModelList
                                                     where c.TVItem.TVItemID != 0
                                                     && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                     || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                     || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                     select c).ToList();

                foreach (TVFileModel tvFileModel in TVFileModelList)
                {
                    TVFileModel tvFileModelOriginal = mwqmPolSourceSiteModelLocal.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                    if (tvFileModelOriginal == null)
                    {
                        mwqmPolSourceSiteModelLocal.TVFileModelList.Add(tvFileModel);
                    }
                    else
                    {
                        tvFileModelOriginal = tvFileModel;
                    }
                }
            }
        }
        private void DoMergeJsonWebPolSourceSitesIsLocalized(WebPolSourceSites webPolSourceSites, WebPolSourceSites webPolSourceSitesLocal)
        {
            foreach (PolSourceSiteModel mwqmPolSourceSiteModel in webPolSourceSites.PolSourceSiteModelList)
            {
                // checking if files are localized
                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ mwqmPolSourceSiteModel.TVItemModel.TVItem.TVItemID }\\");

                if (di.Exists)
                {
                    List<FileInfo> FileInfoList = di.GetFiles().ToList();

                    foreach (TVFileModel tvFileModel in mwqmPolSourceSiteModel.TVFileModelList)
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
