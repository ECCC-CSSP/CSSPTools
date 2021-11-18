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
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebAllPolSourceGroupings(WebAllPolSourceGroupings webAllPolSourceGroupings, WebAllPolSourceGroupings webAllPolSourceGroupingsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllPolSourceGroupings WebAllPolSourceGroupings, WebAllPolSourceGroupings WebAllPolSourceGroupingsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebAllPolSourceGroupingsPolSourceGroupingModelList(webAllPolSourceGroupings, webAllPolSourceGroupingsLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }

        private void DoMergeJsonWebAllPolSourceGroupingsPolSourceGroupingModelList(WebAllPolSourceGroupings webAllPolSourceGroupings, WebAllPolSourceGroupings webAllPolSourceGroupingsLocal)
        {
            List<PolSourceGroupingModel> polSourceGroupingModelLocalList = (from c in webAllPolSourceGroupingsLocal.PolSourceGroupingModelList
                                                                            where c.PolSourceGrouping.DBCommand != DBCommandEnum.Original
                                                                            || c.PolSourceGroupingLanguageList[0].DBCommand != DBCommandEnum.Original
                                                                            || c.PolSourceGroupingLanguageList[1].DBCommand != DBCommandEnum.Original
                                                                            select c).ToList();

            foreach (PolSourceGroupingModel polSourceGroupingModelLocal in polSourceGroupingModelLocalList)
            {
                PolSourceGroupingModel polSourceGroupingModelOriginal = webAllPolSourceGroupings.PolSourceGroupingModelList.Where(c => c.PolSourceGrouping.PolSourceGroupingID == polSourceGroupingModelLocal.PolSourceGrouping.PolSourceGroupingID).FirstOrDefault();
                if (polSourceGroupingModelOriginal == null)
                {
                    webAllPolSourceGroupings.PolSourceGroupingModelList.Add(polSourceGroupingModelLocal);
                }
                else
                {
                    SyncPolSourceGroupingModel(polSourceGroupingModelOriginal, polSourceGroupingModelLocal);
                }
            }
        }
    }
}
