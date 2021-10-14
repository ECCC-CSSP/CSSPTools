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
using System.Text.RegularExpressions;
using System.Reflection;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> FillRainExceedanceModelList(List<RainExceedanceModel> RainExceedanceModelList, TVItem TVItem)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<RainExceedanceModel> RainExceedanceModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }";
            CSSPLogService.FunctionLog(FunctionName);

            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.RainExceedance);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.RainExceedance);

            List<RainExceedance> RainExceedanceList = await GetRainExceedanceUnderCountry(TVItem);
            List<RainExceedanceClimateSite> RainExceedanceClimateSiteList = await GetRainExceedanceClimateSiteUnderCountry(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                TVItemModel tvItemModel = new TVItemModel();
                tvItemModel.TVItem = tvItem;
                tvItemModel.TVItemLanguageList = (from c in TVItemLanguageList
                                                  where c.TVItemID == tvItem.TVItemID
                                                  orderby c.Language
                                                  select c).ToList();

                foreach (TVItemLanguage tvItemLanguage in tvItemModel.TVItemLanguageList)
                {
                    tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex("[ ]{2,}", options);
                    tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
                }

                RainExceedanceModelList.Add(new RainExceedanceModel()
                {
                    TVItemModel = tvItemModel,
                    RainExceedance = RainExceedanceList.Where(c => c.RainExceedanceTVItemID == tvItem.TVItemID).FirstOrDefault(),
                    RainExceedanceClimateSiteList = RainExceedanceClimateSiteList.Where(c => c.RainExceedanceTVItemID == tvItem.TVItemID).ToList(),
                });
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}