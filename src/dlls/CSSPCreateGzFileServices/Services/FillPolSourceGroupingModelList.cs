/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPWebModels;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillPolSourceGroupingModelList(List<PolSourceGroupingModel> PolSourceGroupingModelList)
        {
            List<PolSourceGrouping> PolSourceGroupingList = await GetPolSourceGroupingList();
            List<PolSourceGroupingLanguage> PolSourceGroupingLanguageList = await GetPolSourceGroupingLanguageList();

            foreach (PolSourceGrouping polSourceGrouping in PolSourceGroupingList)
            {
                PolSourceGroupingModelList.Add(new PolSourceGroupingModel()
                {
                    PolSourceGrouping = polSourceGrouping,
                    PolSourceGroupingLanguageList = PolSourceGroupingLanguageList.Where(c => c.PolSourceGroupingID == polSourceGrouping.PolSourceGroupingID).ToList(),
                });
            }
        }
    }
}