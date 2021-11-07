﻿/*
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
        private async Task<bool> DoMergeJsonWebAllPolSourceSiteEffectTerms(WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms, WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTermsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllPolSourceSiteEffectTerms WebAllPolSourceSiteEffectTerms, WebAllPolSourceSiteEffectTerms WebAllPolSourceSiteEffectTermsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebAllPolSourceSiteEffectsTermsPolSourceSiteEffectTermList(webAllPolSourceSiteEffectTerms, webAllPolSourceSiteEffectTermsLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }

        private void DoMergeJsonWebAllPolSourceSiteEffectsTermsPolSourceSiteEffectTermList(WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms, WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTermsLocal)
        {
            List<PolSourceSiteEffectTerm> polSourceSiteEffectTermLocalList = (from c in webAllPolSourceSiteEffectTermsLocal.PolSourceSiteEffectTermList
                                                                              where c.DBCommand != DBCommandEnum.Original
                                                                              select c).ToList();

            foreach (PolSourceSiteEffectTerm polSourceSiteEffectTermLocal in polSourceSiteEffectTermLocalList)
            {
                PolSourceSiteEffectTerm polSourceSiteEffectTermOriginal = webAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList.Where(c => c.PolSourceSiteEffectTermID == polSourceSiteEffectTermLocal.PolSourceSiteEffectTermID).FirstOrDefault();
                if (polSourceSiteEffectTermOriginal == null)
                {
                    webAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList.Add(polSourceSiteEffectTermLocal);
                }
                else
                {
                    SyncPolSourceSiteEffectTerm(polSourceSiteEffectTermOriginal, polSourceSiteEffectTermLocal);
                }
            }
        }
    }
}