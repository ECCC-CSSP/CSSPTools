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
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
    {
        private void SyncPolSourceSiteEffectTerm(PolSourceSiteEffectTerm polSourceSiteEffectTermOriginal, PolSourceSiteEffectTerm polSourceSiteEffectTermLocal)
        {
            if (polSourceSiteEffectTermLocal != null)
            {
                polSourceSiteEffectTermOriginal = polSourceSiteEffectTermLocal;
            }
        }
    }
}
