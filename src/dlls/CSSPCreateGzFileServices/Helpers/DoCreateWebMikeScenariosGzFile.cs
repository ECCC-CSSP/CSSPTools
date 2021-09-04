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
        private async Task<bool> DoCreateWebMikeScenariosGzFile(int MunicipalityTVItemID)
        {
            string FunctionName = $"{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(MunicipalityTVItemID: { MunicipalityTVItemID })";
            await CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemMunicipality = await GetTVItemWithTVItemID(MunicipalityTVItemID);

            if (TVItemMunicipality == null || TVItemMunicipality.TVType != TVTypeEnum.Municipality)
            {
                await CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", MunicipalityTVItemID.ToString(), "TVType", TVTypeEnum.Municipality.ToString()), new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebMikeScenarios webMikeScenarios = new WebMikeScenarios();

            try
            {
                if (!await FillTVItemModelAndParentTVItemModelList(webMikeScenarios.TVItemModel, webMikeScenarios.TVItemModelParentList, TVItemMunicipality)) return await Task.FromResult(false);

                if (!await FillMikeScenarioModelList(webMikeScenarios.TVItemModel, webMikeScenarios.TVItemModelParentList, webMikeScenarios.MikeScenarioModelList, TVItemMunicipality)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebMikeScenarios>(webMikeScenarios, $"{ WebTypeEnum.WebMikeScenarios }_{ MunicipalityTVItemID }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebMikeScenarios>(webMikeScenarios, $"{ WebTypeEnum.WebMikeScenarios }_{ MunicipalityTVItemID }.gz")) return await Task.FromResult(false);
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
