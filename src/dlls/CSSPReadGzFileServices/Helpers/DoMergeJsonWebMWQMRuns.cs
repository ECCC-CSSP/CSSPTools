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
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebMWQMRuns(WebMWQMRuns WebMWQMRuns, WebMWQMRuns WebMWQMRunsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebMWQMRuns WebMWQMRuns, WebMWQMRuns WebMWQMRunsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            List<MWQMRunModel> MWQMRunModelList = (from c in WebMWQMRunsLocal.MWQMRunModelList
                                                   where c.MWQMRun.MWQMRunID != 0
                                                   && c.MWQMRun.DBCommand != DBCommandEnum.Original
                                                   select c).ToList();

            foreach (MWQMRunModel mwqmRunModel in MWQMRunModelList)
            {
                MWQMRunModel mwqmRunModelOriginal = WebMWQMRuns.MWQMRunModelList.Where(c => c.MWQMRun.MWQMRunID == mwqmRunModel.MWQMRun.MWQMRunID).FirstOrDefault();
                if (mwqmRunModelOriginal == null)
                {
                    WebMWQMRuns.MWQMRunModelList.Add(mwqmRunModelOriginal);
                }
                else
                {
                    mwqmRunModelOriginal = mwqmRunModel;
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
