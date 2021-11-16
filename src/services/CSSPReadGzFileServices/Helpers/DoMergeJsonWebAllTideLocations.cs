/*
 * Manually edited
 * 
 */
using CSSPDBModels;
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
        private async Task<bool> DoMergeJsonWebAllTideLocations(WebAllTideLocations webAllTideLocations, WebAllTideLocations webAllTideLocationsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllTideLocations WebAllTideLocations, WebAllTideLocations WebAllTideLocationsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebAllTideLocationsTideLocationList(webAllTideLocations, webAllTideLocationsLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }

        private void DoMergeJsonWebAllTideLocationsTideLocationList(WebAllTideLocations webAllTideLocations, WebAllTideLocations webAllTideLocationsLocal)
        {
            List<TideLocation> tideLocationLocalList = (from c in webAllTideLocationsLocal.TideLocationList
                                                        where c.DBCommand != DBCommandEnum.Original
                                                        select c).ToList();

            foreach (TideLocation tideLocationLocal in tideLocationLocalList)
            {
                TideLocation tideLocationOriginal = webAllTideLocations.TideLocationList.Where(c => c.TideLocationID == tideLocationLocal.TideLocationID).FirstOrDefault();
                if (tideLocationOriginal == null)
                {
                    webAllTideLocations.TideLocationList.Add(tideLocationLocal);
                }
                else
                {
                    SyncTideLocation(tideLocationOriginal, tideLocationLocal);
                }
            }
        }
    }
}
