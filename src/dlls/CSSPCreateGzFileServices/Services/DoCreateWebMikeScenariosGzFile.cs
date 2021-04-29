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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebMikeScenariosGzFile(int MunicipalityTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem TVItemMunicipality = await GetTVItemWithTVItemID(MunicipalityTVItemID);

            if (TVItemMunicipality == null || TVItemMunicipality.TVType != TVTypeEnum.Municipality)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", MunicipalityTVItemID.ToString(), "TVType", TVTypeEnum.Municipality.ToString())));
            }

            WebMikeScenarios webMikeScenarios = new WebMikeScenarios();

            try
            {
                await FillTVItemModelAndParentTVItemModelList(webMikeScenarios.TVItemStatMapModel, webMikeScenarios.TVItemStatModelParentList, TVItemMunicipality);

                await FillMikeScenarioModelList(webMikeScenarios.TVItemStatMapModel, webMikeScenarios.TVItemStatModelParentList, webMikeScenarios.MikeScenarioModelList, TVItemMunicipality);

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebMikeScenarios>(webMikeScenarios, $"{ WebTypeEnum.WebMikeScenarios }_{ MunicipalityTVItemID }.gz");
                }
                else
                {
                    await DoStore<WebMikeScenarios>(webMikeScenarios, $"{ WebTypeEnum.WebMikeScenarios }_{ MunicipalityTVItemID }.gz");
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return await Task.FromResult(BadRequest($"{ ex.Message } { inner }"));
            }

            return await Task.FromResult(Ok(true));
        }
    }
}
