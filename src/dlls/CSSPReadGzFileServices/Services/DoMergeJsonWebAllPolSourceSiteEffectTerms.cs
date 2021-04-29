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
        }
    }
}
