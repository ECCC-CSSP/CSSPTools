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
        private async Task<ActionResult<WebDrogueRun>> DoGetWebDrogueRun(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Subsector)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Subsector }]");
            }

            WebDrogueRun webDrogueRun = new WebDrogueRun();

            try
            {
                webDrogueRun.DrogueRunList = await GetDrogueRunListUnderProvince(tvItem.TVItemID);
                webDrogueRun.DrogueRunPositionList = await GetDrogueRunPositionListUnderProvince(tvItem.TVItemID);

                await DoStore<WebDrogueRun>(webDrogueRun, $"WebDrogueRun_{TVItemID}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webDrogueRun));
        }
    }
}