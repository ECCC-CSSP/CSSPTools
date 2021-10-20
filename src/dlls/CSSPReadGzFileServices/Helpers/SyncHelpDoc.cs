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
        private void SyncHelpDoc(HelpDoc helpDocOriginal, HelpDoc helpDocLocal)
        {
            if (helpDocLocal != null)
            {
                helpDocOriginal = helpDocLocal;
            }
        }
    }
}
