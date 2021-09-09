/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllPolSourceGroupings(WebAllPolSourceGroupings WebAllPolSourceGroupings, WebAllPolSourceGroupings WebAllPolSourceGroupingsLocal)
        {
            List<PolSourceGroupingModel> polSourceGroupingModelLocalList = (from c in WebAllPolSourceGroupingsLocal.PolSourceGroupingModelList
                                                                            where c.PolSourceGrouping.DBCommand != DBCommandEnum.Original
                                                                            || c.PolSourceGroupingLanguageList[0].DBCommand != DBCommandEnum.Original
                                                                            || c.PolSourceGroupingLanguageList[1].DBCommand != DBCommandEnum.Original
                                                                            select c).ToList();

            foreach (PolSourceGroupingModel polSourceGroupingModelLocal in polSourceGroupingModelLocalList)
            {
                PolSourceGroupingModel polSourceGroupingModelOriginal = WebAllPolSourceGroupings.PolSourceGroupingModelList.Where(c => c.PolSourceGrouping.PolSourceGroupingID == polSourceGroupingModelLocal.PolSourceGrouping.PolSourceGroupingID).FirstOrDefault();
                if (polSourceGroupingModelOriginal == null)
                {
                    WebAllPolSourceGroupings.PolSourceGroupingModelList.Add(polSourceGroupingModelLocal);
                }
                else
                {
                    polSourceGroupingModelOriginal = polSourceGroupingModelLocal;
                }
            }
        }
    }
}
