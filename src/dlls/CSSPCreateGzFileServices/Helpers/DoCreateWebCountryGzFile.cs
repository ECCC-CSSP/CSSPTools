/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CSSPWebModels;
using CSSPDBModels;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> DoCreateWebCountryGzFile(int CountryTVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(CountryTVItemID: { CountryTVItemID })";
            CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemCountry = await GetTVItemWithTVItemID(CountryTVItemID);

            if (TVItemCountry == null || TVItemCountry.TVType != TVTypeEnum.Country)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", CountryTVItemID.ToString(), "TVType", TVTypeEnum.Country.ToString()));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebCountry webCountry = new WebCountry();

            try
            {
                if (!await FillTVItemModelAndParentTVItemModelList(webCountry.TVItemModel, webCountry.TVItemModelParentList, TVItemCountry)) return await Task.FromResult(false);

                if (!await FillChildListTVItemModelList(webCountry.TVItemModelProvinceList, TVItemCountry, TVTypeEnum.Province)) return await Task.FromResult(false);

                if (!await FillFileModelList(webCountry.TVFileModelList, TVItemCountry)) return await Task.FromResult(false);

                if (!await FillRainExceedanceModelList(webCountry.RainExceedanceModelList, TVItemCountry)) return await Task.FromResult(false);

                if (!await FillEmailDistributionListModelList(webCountry.EmailDistributionListModelList, TVItemCountry)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebCountry>(webCountry, $"{ WebTypeEnum.WebCountry }_{ CountryTVItemID }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebCountry>(webCountry, $"{ WebTypeEnum.WebCountry }_{ CountryTVItemID }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                CSSPLogService.AppendError($"{ ex.Message } { inner }");
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
