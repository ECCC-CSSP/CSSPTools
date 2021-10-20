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
    public partial class CSSPReadGzFileService : ControllerBase, ICSSPReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebAllCountries(WebAllCountries webAllCountries, WebAllCountries webAllCountriesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllCountries WebAllCountries, WebAllCountries WebAllCountriesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebAllCountriesTVItemModelList(webAllCountries, webAllCountriesLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }

        private void DoMergeJsonWebAllCountriesTVItemModelList(WebAllCountries webAllCountries, WebAllCountries webAllCountriesLocal)
        {
            List<TVModel> tvModelLocalList = (from c in webAllCountriesLocal.TVModelList
                                                      where c.TVItem.DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                      select c).ToList();

            foreach (TVModel tvModelLocal in tvModelLocalList)
            {
                TVModel tvModelOriginal = webAllCountries.TVModelList.Where(c => c.TVItem.TVItemID == tvModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (tvModelOriginal == null)
                {
                    webAllCountries.TVModelList.Add(tvModelLocal);
                }
                else
                {
                    SyncTVModel(tvModelOriginal, tvModelLocal);
                }
            }
        }
    }
}
