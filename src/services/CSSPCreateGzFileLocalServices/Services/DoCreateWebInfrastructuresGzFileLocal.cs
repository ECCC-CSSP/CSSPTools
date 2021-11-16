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
        private async Task<ActionResult<bool>> DoCreateWebInfrastructuresGzFileLocal(int MunicipalityTVItemID)
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

            WebInfrastructures webInfrastructures = new WebInfrastructures();

            try
            {
                await FillTVItemModelLocal(webInfrastructures.TVItemModel, TVItemMunicipality);

                await FillParentListTVItemModelListLocal(webInfrastructures.TVItemParentList, TVItemMunicipality);

                await FillChildListOfChildTVItemModelListLocal(webInfrastructures.TVItemFileList, TVItemMunicipality, TVTypeEnum.Infrastructure, TVTypeEnum.File);

                await FillChildListTVItemModelListLocal(webInfrastructures.TVItemInfrastructureList, TVItemMunicipality, TVTypeEnum.Infrastructure);

                await FillChildListTVItemInfrastructureModelListLocal(webInfrastructures.InfrastructureModelList, TVItemMunicipality, TVTypeEnum.Infrastructure);

                webInfrastructures.InfrastructureTVItemLinkList = await GetInfrastructureTVItemLinkListUnderMunicipality(TVItemMunicipality);

                DoStoreLocal<WebInfrastructures>(webInfrastructures, $"{ WebTypeEnum.WebInfrastructures }_{ MunicipalityTVItemID }.gz");
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
