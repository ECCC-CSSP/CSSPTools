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

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<ActionResult<bool>> DoCreateWebMikeScenariosGzFileLocal(int MunicipalityTVItemID)
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
                await FillTVItemModelLocal(webMikeScenarios.TVItemModel, TVItemMunicipality);

                await FillParentListTVItemModelListLocal(webMikeScenarios.TVItemParentList, TVItemMunicipality);

                await FillChildListTVItemModelListLocal(webMikeScenarios.TVItemMikeScenarioList, TVItemMunicipality, TVTypeEnum.MikeScenario);

                await FillChildListTVItemMIKEScenarioModelListLocal(webMikeScenarios.MIKEScenarioModelList, TVItemMunicipality, TVTypeEnum.MikeScenario);

                DoStoreLocal<WebMikeScenarios>(webMikeScenarios, $"{ WebTypeEnum.WebMikeScenarios }_{ MunicipalityTVItemID }.gz");
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
