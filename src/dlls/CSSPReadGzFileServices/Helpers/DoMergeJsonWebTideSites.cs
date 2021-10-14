﻿/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebTideSites(WebTideSites webTideSites, WebTideSites webTideSitesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTideSites WebTideSites, WebTideSites WebTideSitesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebTideSitesTVItemModel(webTideSites, webTideSitesLocal);

            DoMergeJsonWebTideSitesTVItemModelParentList(webTideSites, webTideSitesLocal);

            DoMergeJsonWebTideSitesTideSiteModelList(webTideSites, webTideSitesLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void DoMergeJsonWebTideSitesTVItemModel(WebTideSites webTideSites, WebTideSites webTideSitesLocal)
        {
            if (webTideSitesLocal.TVItemModel.TVItem.TVItemID != 0
                && (webTideSitesLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                || webTideSitesLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                || webTideSitesLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                SyncTVItemModel(webTideSites.TVItemModel, webTideSitesLocal.TVItemModel);
            }
        }
        private void DoMergeJsonWebTideSitesTVItemModelParentList(WebTideSites webTideSites, WebTideSites webTideSitesLocal)
        {
            if ((from c in webTideSitesLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                SyncTVItemModelParentList(webTideSites.TVItemModelParentList, webTideSitesLocal.TVItemModelParentList);
            }
        }
        private void DoMergeJsonWebTideSitesTideSiteModelList(WebTideSites webTideSites, WebTideSites webTideSitesLocal)
        {

            List<TideSiteModel> TideSiteModelLocalList = (from c in webTideSitesLocal.TideSiteModelList
                                                          where c.TVItemModel.TVItem.TVItemID != 0
                                                          select c).ToList();

            foreach (TideSiteModel tideSiteModelLocal in TideSiteModelLocalList)
            {
                TideSiteModel tideSiteModelOriginal = webTideSites.TideSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tideSiteModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();

                if (tideSiteModelLocal.TVItemModel.TVItem.TVItemID != 0
                    && (tideSiteModelLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                    || tideSiteModelLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                    || tideSiteModelLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
                {
                    if (tideSiteModelOriginal == null)
                    {
                        webTideSites.TideSiteModelList.Add(tideSiteModelLocal);
                    }
                    else
                    {
                        SyncTideSiteModel(tideSiteModelOriginal, tideSiteModelLocal);
                    }
                }
            }
        }
    }
}
