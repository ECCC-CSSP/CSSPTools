/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebMWQMRuns(WebMWQMRuns WebMWQMRuns, WebMWQMRuns WebMWQMRunsLocal)
        {
            List<MWQMRunModel> MWQMRunModelList = (from c in WebMWQMRunsLocal.MWQMRunModelList
                                                               where c.MWQMRun.DBCommand != DBCommandEnum.Original
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
        }
    }
}
