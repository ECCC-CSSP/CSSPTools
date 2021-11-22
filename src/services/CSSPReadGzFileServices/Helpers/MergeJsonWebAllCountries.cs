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
        private async Task<bool> MergeJsonWebAllCountries(WebAllCountries webAllCountries, WebAllCountries webAllCountriesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllCountries WebAllCountries, WebAllCountries WebAllCountriesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            MergeJsonWebAllCountriesTVItemModelList(webAllCountries, webAllCountriesLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }

        private void MergeJsonWebAllCountriesTVItemModelList(WebAllCountries webAllCountries, WebAllCountries webAllCountriesLocal)
        {
            List<TVItemModel> tvItemModelLocalList = (from c in webAllCountriesLocal.TVItemModelList
                                                      where c.TVItem.DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                      select c).ToList();
            
            foreach (TVItemModel tvItemModelLocal in tvItemModelLocalList)
            {
                TVItemModel tvItemModelOriginal = webAllCountries.TVItemModelList.Where(c => c.TVItem.TVItemID == tvItemModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (tvItemModelOriginal == null)
                {
                    webAllCountries.TVItemModelList.Add(tvItemModelLocal);
                }
                else
                {
                    SyncTVModel(tvItemModelOriginal, tvItemModelLocal);
                }
            }
        }
    }
}
