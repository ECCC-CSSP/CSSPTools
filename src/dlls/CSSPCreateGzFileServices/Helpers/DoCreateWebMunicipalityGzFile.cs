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
        private async Task<bool> DoCreateWebMunicipalityGzFile(int MunicipalityTVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(MunicipalityTVItemID: { MunicipalityTVItemID })";
            await CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemMunicipality = await GetTVItemWithTVItemID(MunicipalityTVItemID);

            if (TVItemMunicipality == null || TVItemMunicipality.TVType != TVTypeEnum.Municipality)
            {
                await CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", MunicipalityTVItemID.ToString(), "TVType", TVTypeEnum.Municipality.ToString()), new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebMunicipality webMunicipality = new WebMunicipality();

            try
            {
                if (!await FillTVItemModelAndParentTVItemModelList(webMunicipality.TVItemModel, webMunicipality.TVItemModelParentList, TVItemMunicipality)) return await Task.FromResult(false);

                if (!await FillChildListTVItemModelList(webMunicipality.TVItemModelInfrastructureList, TVItemMunicipality, TVTypeEnum.Infrastructure)) return await Task.FromResult(false);

                if (!await FillChildListTVItemModelList(webMunicipality.TVItemModelMikeScenarioList, TVItemMunicipality, TVTypeEnum.MikeScenario)) return await Task.FromResult(false);

                if (!await FillFileModelList(webMunicipality.TVFileModelList, TVItemMunicipality)) return await Task.FromResult(false);

                if (!await FillChildListTVItemContactModelList(webMunicipality.MunicipalityContactModelList, TVItemMunicipality)) return await Task.FromResult(false);

                if (!await FillInfrastructureModelList(webMunicipality.InfrastructureModelList, TVItemMunicipality)) return await Task.FromResult(false);

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
                await CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
