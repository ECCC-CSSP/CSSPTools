/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CSSPWebModels;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateWebHydrometricSitesGzFile(int ProvinceTVItemID)
        {
            string FunctionName = $"{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(ProvinceTVItemID: { ProvinceTVItemID })";
            await CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemProvince = await GetTVItemWithTVItemID(ProvinceTVItemID);

            if (TVItemProvince == null || TVItemProvince.TVType != TVTypeEnum.Province)
            {
                await CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString()), new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebHydrometricSites webHydrometricSites  = new WebHydrometricSites();

            try
            {
                if (!await FillTVItemModelAndParentTVItemModelList(webHydrometricSites.TVItemModel, webHydrometricSites.TVItemModelParentList, TVItemProvince)) return await Task.FromResult(false);

                if (!await FillHydrometricSiteModelList(webHydrometricSites.HydrometricSiteModelList, TVItemProvince)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebHydrometricSites>(webHydrometricSites, $"{ WebTypeEnum.WebHydrometricSites }_{ ProvinceTVItemID }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebHydrometricSites>(webHydrometricSites, $"{ WebTypeEnum.WebHydrometricSites }_{ ProvinceTVItemID }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                await CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
