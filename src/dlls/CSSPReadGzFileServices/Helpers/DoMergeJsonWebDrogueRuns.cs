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
    public partial class CSSPReadGzFileService : ControllerBase, ICSSPReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebDrogueRuns(WebDrogueRuns webDrogueRuns, WebDrogueRuns webDrogueRunsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebDrogueRuns WebDrogueRuns, WebDrogueRuns WebDrogueRunsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebDrogueRunsTVItemModel(webDrogueRuns, webDrogueRunsLocal);

            DoMergeJsonWebDrogueRunsTVItemModelParentList(webDrogueRuns, webDrogueRunsLocal);

            DoMergeJsonWebDrogueRunsDrogueRunModelList(webDrogueRuns, webDrogueRunsLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void DoMergeJsonWebDrogueRunsTVItemModel(WebDrogueRuns webDrogueRuns, WebDrogueRuns webDrogueRunsLocal)
        {
            if (webDrogueRunsLocal.TVItemModel.TVItem.TVItemID != 0
                && (webDrogueRunsLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || webDrogueRunsLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || webDrogueRunsLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                SyncTVItemModel(webDrogueRuns.TVItemModel, webDrogueRunsLocal.TVItemModel);
            }
        }
        private void DoMergeJsonWebDrogueRunsTVItemModelParentList(WebDrogueRuns webDrogueRuns, WebDrogueRuns webDrogueRunsLocal)
        {
            if ((from c in webDrogueRunsLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                SyncTVItemModelParentList(webDrogueRuns.TVItemModelParentList, webDrogueRunsLocal.TVItemModelParentList);
            }
        }
        private void DoMergeJsonWebDrogueRunsDrogueRunModelList(WebDrogueRuns webDrogueRuns, WebDrogueRuns webDrogueRunsLocal)
        {
            List<DrogueRunModel> DrogueRunModelLocalList = (from c in webDrogueRunsLocal.DrogueRunModelList
                                                       where c.DrogueRun.DrogueRunID != 0
                                                       && (c.DrogueRun.DBCommand != DBCommandEnum.Original
                                                       || (from d in c.DrogueRunPositionList
                                                           where d.DBCommand != DBCommandEnum.Original
                                                           select d).Any())
                                                       select c).ToList();

            foreach (DrogueRunModel drogueRunModelLocal in DrogueRunModelLocalList)
            {
                DrogueRunModel drogueRunModelOriginal = webDrogueRuns.DrogueRunModelList.Where(c => c.DrogueRun.DrogueRunID == drogueRunModelLocal.DrogueRun.DrogueRunID).FirstOrDefault();
                if (drogueRunModelOriginal == null)
                {
                    webDrogueRuns.DrogueRunModelList.Add(drogueRunModelLocal);
                }
                else
                {
                    drogueRunModelOriginal = drogueRunModelLocal;
                }
            }
        }
    }
}
