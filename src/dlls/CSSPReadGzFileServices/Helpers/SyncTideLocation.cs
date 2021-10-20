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
        private void SyncTideLocation(TideLocation tideLocationOriginal, TideLocation tideLocationLocal)
        {
            if (tideLocationLocal != null)
            {
                tideLocationOriginal = tideLocationLocal;
            }
        }
    }
}
