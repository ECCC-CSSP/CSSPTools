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
        private void DoMergeJsonWebAllMunicipalities(WebAllMunicipalities WebAllMunicipalities, WebAllMunicipalities WebAllMunicipalitiesLocal)
        {
            List<TVItemModel> tvItemModelLocalList = (from c in WebAllMunicipalitiesLocal.TVItemModelList
                                                                        where c.TVItem.DBCommand != DBCommandEnum.Original
                                                                        || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                                        || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                                        select c).ToList();

            foreach (TVItemModel tvItemModelLocal in tvItemModelLocalList)
            {
                TVItemModel tvItemModelOriginal = WebAllMunicipalities.TVItemModelList.Where(c => c.TVItem.TVItemID == tvItemModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (tvItemModelOriginal == null)
                {
                    WebAllMunicipalities.TVItemModelList.Add(tvItemModelLocal);
                }
                else
                {
                    tvItemModelOriginal = tvItemModelLocal;
                }
            }
        }
    }
}
