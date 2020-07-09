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

            TVItem tvItem = await GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Subsector)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Subsector }]");
            }

            WebSubsector webSubsector = new WebSubsector();

            try
            {
                webSubsector.TVItem = tvItem;
                webSubsector.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(TVItemID);
                webSubsector.TVItemStatList = await GetTVItemStatListWithTVItemID(TVItemID);
                webSubsector.MapInfoList = await GetMapInfoListWithTVItemID(TVItemID);
                webSubsector.MapInfoPointList = await GetMapInfoPointListWithTVItemID(TVItemID);
                webSubsector.TVFileList = await GetTVFileListWithTVItemID(TVItemID);
                webSubsector.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(TVItemID);
                webSubsector.TVItemMWQMSiteList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMSite);
                webSubsector.TVItemLanguageMWQMSiteList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMSite);
                webSubsector.TVItemStatMWQMSiteList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMSite);
                webSubsector.MapInfoMWQMSiteList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMSite);
                webSubsector.MapInfoPointMWQMSiteList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMSite);
                webSubsector.TVItemMWQMRunList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMRun);
                webSubsector.TVItemLanguageMWQMRunList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMRun);
                webSubsector.TVItemStatMWQMRunList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.MWQMRun);
                webSubsector.TVItemPolSourceSiteList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.PolSourceSite);
                webSubsector.TVItemLanguagePolSourceSiteList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.PolSourceSite);
                webSubsector.TVItemStatPolSourceSiteList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.PolSourceSite);
                webSubsector.MapInfoPolSourceSiteList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.PolSourceSite);
                webSubsector.MapInfoPointPolSourceSiteList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.PolSourceSite);
                webSubsector.MWQMAnalysisReportParameterList = await GetMWQMAnalysisReportParameterListUnderSubsector(TVItemID);
                webSubsector.LabSheetList = await GetLabSheetListUnderSubsector(TVItemID);
                webSubsector.LabSheetDetailList = await GetLabSheetDetailListUnderSubsector(TVItemID);
                webSubsector.LabSheetTubeMPNDetailList = await GetLabSheetTubeMPNDetailListUnderSubsector(TVItemID);
                webSubsector.MWQMSubsector = await GetMWQMSubsector(TVItemID);
                webSubsector.MWQMSubsectorLanguageList = await GetMWQMSubsectorLanguageList(TVItemID);
                webSubsector.UseOfSiteList = await GetUseOfSiteList(TVItemID);

                await DoStore<WebSubsector>(webSubsector, $"WebSubsector_{TVItemID}.gz");
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
