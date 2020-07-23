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
        private async Task<ActionResult<WebArea>> DoGetWebArea(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Area)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Area }]");
            }

            WebArea webArea = new WebArea();

            try
            {
                webArea.TVItem = tvItem;
                webArea.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(TVItemID);
                webArea.TVItemStatList = await GetTVItemStatListWithTVItemID(TVItemID);
                webArea.MapInfoList = await GetMapInfoListWithTVItemID(TVItemID);
                webArea.MapInfoPointList = await GetMapInfoPointListWithTVItemID(TVItemID);
                webArea.TVFileList = await GetTVFileListWithTVItemID(TVItemID);
                webArea.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(TVItemID);
                webArea.TVItemSectorList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Sector);
                webArea.TVItemLanguageSectorList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Sector);
                webArea.TVItemStatSectorList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Sector);
                webArea.MapInfoSectorList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.Sector);
                webArea.MapInfoPointSectorList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.Sector);

                await DoStore<WebArea>(webArea, $"WebArea_{TVItemID}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webArea));
        }
    }
}