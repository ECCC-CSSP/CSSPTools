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
        private async Task<ActionResult<WebClimateSite>> DoGetWebClimateSite(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Province)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Province }]");
            }

            WebClimateSite webClimateSite  = new WebClimateSite();

            try
            {
                webClimateSite.ClimateSiteList = await GetClimateSiteListUnderProvince(tvItem);
                webClimateSite.TVItemList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.ClimateSite);
                webClimateSite.TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.ClimateSite);
                webClimateSite.MapInfoList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.ClimateSite);
                webClimateSite.MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.ClimateSite);

                await DoStore<WebClimateSite>(webClimateSite, $"WebClimateSite_{TVItemID}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webClimateSite));
        }
    }
}