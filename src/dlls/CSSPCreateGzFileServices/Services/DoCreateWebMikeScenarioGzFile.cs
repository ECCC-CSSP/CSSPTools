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
        private async Task<ActionResult<bool>> DoCreateWebMikeScenarioGzFile(int MikeScenarioTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
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
                await FillTVItemModel(webMikeScenario.TVItemModel, TVItemMikeScenario);

                await FillParentListTVItemModelList(webMikeScenario.TVItemParentList, TVItemMikeScenario);

                await FillChildListTVItemMikeSourceModelList(webMikeScenario.MikeSourceModelList, TVItemMikeScenario, TVTypeEnum.MikeSource);

                await FillChildListTVItemMikeBoundaryConditionModelList(webMikeScenario.MikeBoundaryConditionModelWebTideList, TVItemMikeScenario, TVTypeEnum.MikeBoundaryConditionWebTide);

                await FillChildListTVItemMikeBoundaryConditionModelList(webMikeScenario.MikeBoundaryConditionModelMeshList, TVItemMikeScenario, TVTypeEnum.MikeBoundaryConditionMesh);

                await DoStore<WebMikeScenario>(webMikeScenario, $"{ WebTypeEnum.WebMikeScenario }_{ MikeScenarioTVItemID }.gz");
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
