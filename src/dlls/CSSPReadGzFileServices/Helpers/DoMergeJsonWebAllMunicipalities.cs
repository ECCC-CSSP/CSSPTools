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
            List<TVModel> tvModelLocalList = (from c in webAllMunicipalitiesLocal.TVModelList
                                                      where c.TVItem.DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                      select c).ToList();

            foreach (TVModel tvModelLocal in tvModelLocalList)
            {
                TVModel tvModelOriginal = webAllMunicipalities.TVModelList.Where(c => c.TVItem.TVItemID == tvModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (tvModelOriginal == null)
                {
                    webAllMunicipalities.TVModelList.Add(tvModelLocal);
                }
                else
                {
                    SyncTVModel(tvModelOriginal, tvModelLocal);
                }
            }
        }
    }
}
