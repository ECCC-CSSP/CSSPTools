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
        private async Task<ActionResult<bool>> DoCreateWebMikeScenarioGzFileLocal(int MikeScenarioTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem TVItemMikeScenario = await GetTVItemWithTVItemID(MikeScenarioTVItemID);

            if (TVItemMikeScenario == null || TVItemMikeScenario.TVType != TVTypeEnum.MikeScenario)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", MikeScenarioTVItemID.ToString(), "TVType", TVTypeEnum.MikeScenario.ToString())));
            }

            WebMikeScenario webMikeScenario = new WebMikeScenario();

            try
            {
                await FillTVItemModelLocal(webMikeScenario.TVItemModel, TVItemMikeScenario);

                await FillParentListTVItemModelListLocal(webMikeScenario.TVItemParentList, TVItemMikeScenario);

                await FillChildListTVItemModelListLocal(webMikeScenario.TVItemFileList, TVItemMikeScenario, TVTypeEnum.File);

                await FillChildListTVItemModelListLocal(webMikeScenario.TVItemMikeSourceList, TVItemMikeScenario, TVTypeEnum.MikeSource);

                await FillChildListTVItemModelListLocal(webMikeScenario.TVItemMikeBoundaryConditionMeshList, TVItemMikeScenario, TVTypeEnum.MikeBoundaryConditionMesh);

                await FillChildListTVItemModelListLocal(webMikeScenario.TVItemMikeBoundaryConditionWebTideList, TVItemMikeScenario, TVTypeEnum.MikeBoundaryConditionWebTide);

                await FillChildListTVItemMikeSourceModelListLocal(webMikeScenario.MikeSourceModelList, TVItemMikeScenario, TVTypeEnum.MikeSource);

                await FillChildListTVItemMikeBoundaryConditionModelListLocal(webMikeScenario.MikeBoundaryConditionModelWebTideList, TVItemMikeScenario, TVTypeEnum.MikeBoundaryConditionWebTide);

                await FillChildListTVItemMikeBoundaryConditionModelListLocal(webMikeScenario.MikeBoundaryConditionModelMeshList, TVItemMikeScenario, TVTypeEnum.MikeBoundaryConditionMesh);

                DoStoreLocal<WebMikeScenario>(webMikeScenario, $"{ WebTypeEnum.WebMikeScenario }_{ MikeScenarioTVItemID }.gz");
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
