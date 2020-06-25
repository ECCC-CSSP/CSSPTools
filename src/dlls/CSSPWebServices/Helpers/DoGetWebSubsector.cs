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
        #region Functions public 
        private async Task<ActionResult<WebSubsector>> DoGetWebSubsector(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Subsector)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Subsector }]");
            }

            WebSubsector webSubsector = new WebSubsector();

            try
            {
                webSubsector.TVItem = tvItem;

                webSubsector.TVItemLanguageList = GetTVItemLanguageListWithTVItemID(TVItemID);

                webSubsector.TVItemStatList = GetTVItemStatListWithTVItemID(TVItemID);

                webSubsector.MapInfoList = GetMapInfoListWithTVItemID(TVItemID);

                webSubsector.MapInfoPointList = GetMapInfoPointListWithTVItemID(TVItemID);

                webSubsector.TVFileList = GetTVFileListWithTVItemID(TVItemID);

                webSubsector.TVFileLanguageList = GetTVFileLanguageListWithTVItemID(TVItemID);

                webSubsector.TVItemMWQMSiteList = GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMSite);

                webSubsector.TVItemLanguageMWQMSiteList = GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMSite);

                webSubsector.TVItemStatMWQMSiteList = GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMSite);

                webSubsector.MapInfoMWQMSiteList = GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMSite);

                webSubsector.MapInfoPointMWQMSiteList = GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMSite);

                webSubsector.TVItemMWQMRunList = GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMRun);

                webSubsector.TVItemLanguageMWQMRunList = GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMRun);

                webSubsector.TVItemStatMWQMRunList = GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMRun);

                webSubsector.TVItemPolSourceSiteList = GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.PolSourceSite);

                webSubsector.TVItemLanguagePolSourceSiteList = GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.PolSourceSite);

                webSubsector.TVItemStatPolSourceSiteList = GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.PolSourceSite);

                webSubsector.MapInfoPolSourceSiteList = GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.PolSourceSite);

                webSubsector.MapInfoPointPolSourceSiteList = GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.PolSourceSite);
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webSubsector));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
