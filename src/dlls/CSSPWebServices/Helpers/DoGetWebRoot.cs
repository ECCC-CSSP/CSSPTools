/*
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
        private async Task<ActionResult<WebRoot>> DoGetWebRoot()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItemRoot = GetTVItemRoot();

            if (tvItemRoot == null)
            {
                return BadRequest("TVItemRoot could not be found");
            }

            int TVItemID = tvItemRoot.TVItemID;

            WebRoot webRoot = new WebRoot();

            try
            {
                webRoot.TVItem = tvItemRoot;

                webRoot.TVItemLanguageList = GetTVItemLanguageListWithTVItemID(TVItemID);

                webRoot.TVItemStatList = GetTVItemStatListWithTVItemID(TVItemID);

                webRoot.MapInfoList = GetMapInfoListWithTVItemID(TVItemID);

                webRoot.MapInfoPointList = GetMapInfoPointListWithTVItemID(TVItemID);

                webRoot.TVFileList = GetTVFileListWithTVItemID(TVItemID);

                webRoot.TVFileLanguageList = GetTVFileLanguageListWithTVItemID(TVItemID);

                webRoot.TVItemCountryList = GetTVItemChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);

                webRoot.TVItemLanguageCountryList = GetTVItemLanguageChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);

                webRoot.TVItemStatCountryList = GetTVItemStatChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);

                webRoot.MapInfoCountryList = GetMapInfoChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);

                webRoot.MapInfoPointCountryList = GetMapInfoPointChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webRoot));
        }
    }
}
