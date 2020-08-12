/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CSSPWebService : ControllerBase, ICSSPWebService
    {
        private async Task<ActionResult<bool>> DoCreateWebMikeScenario(int MikeScenarioTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(MikeScenarioTVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.MikeScenario)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", MikeScenarioTVItemID.ToString(), "TVType", TVTypeEnum.MikeScenario.ToString())));
            }

            WebMikeScenario webMikeScenario = new WebMikeScenario();

            try
            {
                webMikeScenario.TVItem = tvItem;
                webMikeScenario.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(MikeScenarioTVItemID);
                webMikeScenario.TVItemStatList = await GetTVItemStatListWithTVItemID(MikeScenarioTVItemID);
                webMikeScenario.MapInfoList = await GetMapInfoListWithTVItemID(MikeScenarioTVItemID);
                webMikeScenario.MapInfoPointList = await GetMapInfoPointListWithTVItemID(MikeScenarioTVItemID);
                webMikeScenario.TVFileList = await GetTVFileListWithTVItemID(MikeScenarioTVItemID);
                webMikeScenario.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(MikeScenarioTVItemID);
                webMikeScenario.MikeScenario = await GetMikeScenarioWithTVItemID(MikeScenarioTVItemID);
                webMikeScenario.MikeBoundaryConditionList = await GetMikeBoundaryConditionListUnderMikeScenario(tvItem);
                webMikeScenario.TVItemMikeBoundaryConditionList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeBoundaryConditionMesh);
                webMikeScenario.TVItemLanguageMikeBoundaryConditionList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeBoundaryConditionMesh);
                webMikeScenario.TVItemStatMikeBoundaryConditionList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeBoundaryConditionMesh);
                webMikeScenario.MapInfoMikeBoundaryConditionList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeBoundaryConditionMesh);
                webMikeScenario.MapInfoPointMikeBoundaryConditionList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeBoundaryConditionMesh);
                webMikeScenario.MikeSourceList = await GetMikeSourceListUnderMikeScenario(tvItem);
                webMikeScenario.TVItemMikeSourceList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeSource);
                webMikeScenario.TVItemLanguageMikeSourceList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeSource);
                webMikeScenario.TVItemStatMikeSourceList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeSource);
                webMikeScenario.MapInfoMikeSourceList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeSource);
                webMikeScenario.MapInfoPointMikeSourceList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeSource);
                webMikeScenario.MikeSourceStartEndList = await GetMikeSourceStartEndListUnderMikeScenario(tvItem);

                await DoStore<WebMikeScenario>(webMikeScenario, $"WebMikeScenario_{MikeScenarioTVItemID}.gz");
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
