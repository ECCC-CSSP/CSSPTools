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
        private async Task<bool> DoMergeJsonWebAllTideLocations(WebAllTideLocations WebAllTideLocations, WebAllTideLocations WebAllTideLocationsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllTideLocations WebAllTideLocations, WebAllTideLocations WebAllTideLocationsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            List<TideLocation> tideLocationLocalList = (from c in WebAllTideLocationsLocal.TideLocationList
                                              where c.DBCommand != DBCommandEnum.Original
                                              select c).ToList();

            foreach (TideLocation tideLocationLocal in tideLocationLocalList)
            {
                TideLocation tideLocationOriginal = WebAllTideLocations.TideLocationList.Where(c => c.TideLocationID == tideLocationLocal.TideLocationID).FirstOrDefault();
                if (tideLocationOriginal == null)
                {
                    WebAllTideLocations.TideLocationList.Add(tideLocationLocal);
                }
                else
                {
                    tideLocationOriginal = tideLocationLocal;
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
