/*
 * Manually edited
 * 
 */
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
        private void SyncTVItemModelParentList(List<TVItemModel> tvItemModelParentListOriginal, List<TVItemModel> tvItemModelParentListLocal)
        {
            tvItemModelParentListOriginal = tvItemModelParentListLocal;
        }
    }
}
