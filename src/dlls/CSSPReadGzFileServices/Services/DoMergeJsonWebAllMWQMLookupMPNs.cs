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

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllMWQMLookupMPNs(WebAllMWQMLookupMPNs WebAllMWQMLookupMPNs, WebAllMWQMLookupMPNs WebAllMWQMLookupMPNsLocal)
        {
            List<MWQMLookupMPN> mwqmLookupMPNLocalList = (from c in WebAllMWQMLookupMPNsLocal.MWQMLookupMPNList
                                              where c.DBCommand != DBCommandEnum.Original
                                              select c).ToList();

            foreach (MWQMLookupMPN mwqmLookupMPNLocal in mwqmLookupMPNLocalList)
            {
                MWQMLookupMPN mwqmLookupMPNOriginal = WebAllMWQMLookupMPNs.MWQMLookupMPNList.Where(c => c.MWQMLookupMPNID == mwqmLookupMPNLocal.MWQMLookupMPNID).FirstOrDefault();
                if (mwqmLookupMPNOriginal == null)
                {
                    WebAllMWQMLookupMPNs.MWQMLookupMPNList.Add(mwqmLookupMPNLocal);
                }
                else
                {
                    mwqmLookupMPNOriginal = mwqmLookupMPNLocal;
                }
            }
        }
    }
}
