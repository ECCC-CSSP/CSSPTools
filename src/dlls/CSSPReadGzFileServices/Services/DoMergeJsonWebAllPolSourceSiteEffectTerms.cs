/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;
using LoggedInServices;
using CSSPWebModels;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllPolSourceSiteEffectTerms(WebAllPolSourceSiteEffectTerms WebAllPolSourceSiteEffectTerms, WebAllPolSourceSiteEffectTerms WebAllPolSourceSiteEffectTermsLocal)
        {
            // -----------------------------------------------------------
            // doing PolSourceSiteEffectTermList
            // -----------------------------------------------------------
            int count = WebAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList.Count;
            for (int i = 0; i < count; i++)
            {
                PolSourceSiteEffectTerm PolSourceSiteEffectTermLocal = (from c in WebAllPolSourceSiteEffectTermsLocal.PolSourceSiteEffectTermList
                                        where c.PolSourceSiteEffectTermID == WebAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList[i].PolSourceSiteEffectTermID
                                        && c.DBCommand != DBCommandEnum.Original
                                        select c).FirstOrDefault();

                if (PolSourceSiteEffectTermLocal != null)
                {
                    WebAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList[i] = PolSourceSiteEffectTermLocal;
                }
            }

            List<PolSourceSiteEffectTerm> PolSourceSiteEffectTermLocalNewList = (from c in WebAllPolSourceSiteEffectTermsLocal.PolSourceSiteEffectTermList
                                                 where c.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (PolSourceSiteEffectTerm PolSourceSiteEffectTermNew in PolSourceSiteEffectTermLocalNewList)
            {
                WebAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList.Add(PolSourceSiteEffectTermNew);
            }

            return;
        }
    }
}
