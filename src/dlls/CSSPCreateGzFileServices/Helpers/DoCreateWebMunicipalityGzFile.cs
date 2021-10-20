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

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> DoCreateWebMunicipalityGzFile(int MunicipalityTVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(MunicipalityTVItemID: { MunicipalityTVItemID })";
            CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemMunicipality = await GetTVItemWithTVItemID(MunicipalityTVItemID);

            if (TVItemMunicipality == null || TVItemMunicipality.TVType != TVTypeEnum.Municipality)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", MunicipalityTVItemID.ToString(), "TVType", TVTypeEnum.Municipality.ToString()));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebMunicipality webMunicipality = new WebMunicipality();

            try
            {
                if (!await FillTVItemModelAndParentTVItemModelList(webMunicipality.TVItemModel, webMunicipality.TVItemModelParentList, TVItemMunicipality)) return await Task.FromResult(false);

                if (!await FillFileModelList(webMunicipality.TVFileModelList, TVItemMunicipality)) return await Task.FromResult(false);

                if (!await FillChildListTVItemContactModelList(webMunicipality.MunicipalityContactModelList, TVItemMunicipality)) return await Task.FromResult(false);

                if (!await FillInfrastructureModelList(webMunicipality.TVItemModelParentList, webMunicipality.InfrastructureModelList, TVItemMunicipality)) return await Task.FromResult(false);

                webMunicipality.MunicipalityTVItemLinkList = await GetInfrastructureTVItemLinkListUnderMunicipality(TVItemMunicipality);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebMunicipality>(webMunicipality, $"{ WebTypeEnum.WebMunicipality }_{ MunicipalityTVItemID }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebMunicipality>(webMunicipality, $"{ WebTypeEnum.WebMunicipality }_{ MunicipalityTVItemID }.gz")) return await Task.FromResult(false);
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
