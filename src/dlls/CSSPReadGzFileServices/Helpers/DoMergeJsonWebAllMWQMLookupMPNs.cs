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

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebAllMWQMLookupMPNs(WebAllMWQMLookupMPNs webAllMWQMLookupMPNs, WebAllMWQMLookupMPNs webAllMWQMLookupMPNsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllMWQMLookupMPNs WebAllMWQMLookupMPNs, WebAllMWQMLookupMPNs WebAllMWQMLookupMPNsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebAllMWQMLookupMPNsMWQMLookupMPNList(webAllMWQMLookupMPNs, webAllMWQMLookupMPNsLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }

        private void DoMergeJsonWebAllMWQMLookupMPNsMWQMLookupMPNList(WebAllMWQMLookupMPNs webAllMWQMLookupMPNs, WebAllMWQMLookupMPNs webAllMWQMLookupMPNsLocal)
        {
            List<MWQMLookupMPN> mwqmLookupMPNLocalList = (from c in webAllMWQMLookupMPNsLocal.MWQMLookupMPNList
                                                          where c.DBCommand != DBCommandEnum.Original
                                                          select c).ToList();

            foreach (MWQMLookupMPN mwqmLookupMPNLocal in mwqmLookupMPNLocalList)
            {
                MWQMLookupMPN mwqmLookupMPNOriginal = webAllMWQMLookupMPNs.MWQMLookupMPNList.Where(c => c.MWQMLookupMPNID == mwqmLookupMPNLocal.MWQMLookupMPNID).FirstOrDefault();
                if (mwqmLookupMPNOriginal == null)
                {
                    webAllMWQMLookupMPNs.MWQMLookupMPNList.Add(mwqmLookupMPNLocal);
                }
                else
                {
                    SyncMWQMLookupMPN(mwqmLookupMPNOriginal, mwqmLookupMPNLocal);
                }
            }
        }
    }
}
