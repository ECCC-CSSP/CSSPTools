/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebDrogueRuns(WebDrogueRuns WebDrogueRuns, WebDrogueRuns WebDrogueRunsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebDrogueRuns WebDrogueRuns, WebDrogueRuns WebDrogueRunsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            if (WebDrogueRunsLocal.TVItemModel.TVItem.TVItemID != 0
                && (WebDrogueRunsLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebDrogueRunsLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebDrogueRunsLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                WebDrogueRuns.TVItemModel = WebDrogueRunsLocal.TVItemModel;
            }

            if ((from c in WebDrogueRunsLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                WebDrogueRuns.TVItemModelParentList = WebDrogueRunsLocal.TVItemModelParentList;
            }

            List<DrogueRunModel> DrogueRunModelList = (from c in WebDrogueRunsLocal.DrogueRunModelList
                                                       where c.DrogueRun.DrogueRunID != 0
                                                       && (c.DrogueRun.DBCommand != DBCommandEnum.Original
                                                       || (from d in c.DrogueRunPositionList
                                                           where d.DBCommand != DBCommandEnum.Original
                                                           select d).Any())
                                                       select c).ToList();

            foreach (DrogueRunModel drogueRunModel in DrogueRunModelList)
            {
                DrogueRunModel drogueRunModelOriginal = WebDrogueRuns.DrogueRunModelList.Where(c => c.DrogueRun.DrogueRunID == drogueRunModel.DrogueRun.DrogueRunID).FirstOrDefault();
                if (drogueRunModelOriginal == null)
                {
                    WebDrogueRuns.DrogueRunModelList.Add(drogueRunModelOriginal);
                }
                else
                {
                    drogueRunModelOriginal = drogueRunModel;
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);
        }
    }
}
