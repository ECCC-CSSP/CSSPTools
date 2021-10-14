/*
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
        private async Task<bool> DoMergeJsonWebHydrometricSites(WebHydrometricSites webHydrometricSites, WebHydrometricSites webHydrometricSitesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebHydrometricSites WebHydrometricSites, WebHydrometricSites WebHydrometricSitesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebHydrometricSitesTVItemModel(webHydrometricSites, webHydrometricSitesLocal);

            DoMergeJsonWebHydrometricSitesTVItemModelParentList(webHydrometricSites, webHydrometricSitesLocal);

            DoMergeJsonWebHydrometricSitesHydrometricSiteModelList(webHydrometricSites, webHydrometricSitesLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void DoMergeJsonWebHydrometricSitesTVItemModel(WebHydrometricSites webHydrometricSites, WebHydrometricSites webHydrometricSitesLocal)
        {
            if (webHydrometricSitesLocal.TVItemModel.TVItem.TVItemID != 0
                && (webHydrometricSitesLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                || webHydrometricSitesLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                || webHydrometricSitesLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                SyncTVItemModel(webHydrometricSites.TVItemModel, webHydrometricSitesLocal.TVItemModel);
            }
        }
        private void DoMergeJsonWebHydrometricSitesTVItemModelParentList(WebHydrometricSites webHydrometricSites, WebHydrometricSites webHydrometricSitesLocal)
        {
            if ((from c in webHydrometricSitesLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                SyncTVItemModelParentList(webHydrometricSites.TVItemModelParentList, webHydrometricSitesLocal.TVItemModelParentList);
            }
        }
        private void DoMergeJsonWebHydrometricSitesHydrometricSiteModelList(WebHydrometricSites webHydrometricSites, WebHydrometricSites webHydrometricSitesLocal)
        {

            List<HydrometricSiteModel> HydrometricSiteModelLocalList = (from c in webHydrometricSitesLocal.HydrometricSiteModelList
                                                                        where c.TVItemModel.TVItem.TVItemID != 0
                                                                        select c).ToList();

            foreach (HydrometricSiteModel HydrometricSiteModelLocal in HydrometricSiteModelLocalList)
            {
                HydrometricSiteModel HydrometricSiteModel = webHydrometricSites.HydrometricSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == HydrometricSiteModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();

                if (HydrometricSiteModelLocal.TVItemModel.TVItem.TVItemID != 0
                    && (HydrometricSiteModelLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                    || HydrometricSiteModelLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                    || HydrometricSiteModelLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
                {
                    if (HydrometricSiteModel == null)
                    {
                        webHydrometricSites.HydrometricSiteModelList.Add(HydrometricSiteModelLocal);
                    }
                    else
                    {
                        SyncHydrometricSiteModel(HydrometricSiteModel, HydrometricSiteModelLocal);
                    }
                }
            }
        }
    }
}
