﻿/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPWebServices.Services
{
    public partial class WebService : ControllerBase, IWebService
    {
        private async Task<ActionResult<WebMWQMSample>> DoGetWebSample(int TVItemID, int Year)
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

            WebMWQMSample webMWQMSample = new WebMWQMSample();

            try
            {
                webMWQMSample.MWQMSampleList = await GetWQMSampleListFromSubsector10Years(tvItem, Year);
                webMWQMSample.MWQMSampleLanguageList = await GetWQMSampleLanguageListFromSubsector10Years(tvItem, Year);

                await DoStore<WebMWQMSample>(webMWQMSample, $"WebMWQMSample_{TVItemID}_{Year}_{Year + 9}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webMWQMSample));
        }
    }
}
