﻿/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class WebService : ControllerBase, IWebService
    {
        private async Task<ActionResult<WebMikeScenario>> DoGetWebMikeScenario(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.MikeScenario)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.MikeScenario }]");
            }

            WebMikeScenario webMikeScenario = new WebMikeScenario();

            try
            {
                webMikeScenario.TVItem = tvItem;
                webMikeScenario.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(TVItemID);
                webMikeScenario.TVItemStatList = await GetTVItemStatListWithTVItemID(TVItemID);
                webMikeScenario.MapInfoList = await GetMapInfoListWithTVItemID(TVItemID);
                webMikeScenario.MapInfoPointList = await GetMapInfoPointListWithTVItemID(TVItemID);
                webMikeScenario.TVFileList = await GetTVFileListWithTVItemID(TVItemID);
                webMikeScenario.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(TVItemID);
                webMikeScenario.MikeScenario = await GetMikeScenarioWithTVItemID(TVItemID);
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

                await DoStore<WebMikeScenario>(webMikeScenario, $"WebMikeScenario_{TVItemID}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webMikeScenario));
        }
    }
}