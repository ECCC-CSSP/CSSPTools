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

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebAllMunicipalities(WebAllMunicipalities webAllMunicipalities, WebAllMunicipalities webAllMunicipalitiesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllMunicipalities WebAllMunicipalities, WebAllMunicipalities WebAllMunicipalitiesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebAllMunicipalitiesTVItemModelList(webAllMunicipalities, webAllMunicipalitiesLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }

        private void DoMergeJsonWebAllMunicipalitiesTVItemModelList(WebAllMunicipalities webAllMunicipalities, WebAllMunicipalities webAllMunicipalitiesLocal)
        {
            List<TVItemModel> tvItemModelLocalList = (from c in webAllMunicipalitiesLocal.TVItemModelList
                                                      where c.TVItem.DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                      select c).ToList();

            foreach (TVItemModel tvItemModelLocal in tvItemModelLocalList)
            {
                TVItemModel tvItemModelOriginal = webAllMunicipalities.TVItemModelList.Where(c => c.TVItem.TVItemID == tvItemModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (tvItemModelOriginal == null)
                {
                    webAllMunicipalities.TVItemModelList.Add(tvItemModelLocal);
                }
                else
                {
                    SyncTVItemModel(tvItemModelOriginal, tvItemModelLocal);
                }
            }
        }
    }
}
