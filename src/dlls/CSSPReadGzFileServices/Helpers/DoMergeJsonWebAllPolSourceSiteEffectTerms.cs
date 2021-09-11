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

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllPolSourceSiteEffectTerms(WebAllPolSourceSiteEffectTerms WebAllPolSourceSiteEffectTerms, WebAllPolSourceSiteEffectTerms WebAllPolSourceSiteEffectTermsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllPolSourceSiteEffectTerms WebAllPolSourceSiteEffectTerms, WebAllPolSourceSiteEffectTerms WebAllPolSourceSiteEffectTermsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            List<PolSourceSiteEffectTerm> polSourceSiteEffectTermLocalList = (from c in WebAllPolSourceSiteEffectTermsLocal.PolSourceSiteEffectTermList
                                              where c.DBCommand != DBCommandEnum.Original
                                              select c).ToList();

            foreach (PolSourceSiteEffectTerm polSourceSiteEffectTermLocal in polSourceSiteEffectTermLocalList)
            {
                PolSourceSiteEffectTerm polSourceSiteEffectTermOriginal = WebAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList.Where(c => c.PolSourceSiteEffectTermID == polSourceSiteEffectTermLocal.PolSourceSiteEffectTermID).FirstOrDefault();
                if (polSourceSiteEffectTermOriginal == null)
                {
                    WebAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList.Add(polSourceSiteEffectTermLocal);
                }
                else
                {
                    polSourceSiteEffectTermOriginal = polSourceSiteEffectTermLocal;
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);
        }
    }
}
