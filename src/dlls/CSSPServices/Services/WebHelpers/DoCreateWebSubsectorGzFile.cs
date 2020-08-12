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
        private async Task<ActionResult<bool>> DoCreateWebSubsector(int SubsectorTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(SubsectorTVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Subsector)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SubsectorTVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString())));
            }

            WebSubsector webSubsector = new WebSubsector();

            try
            {
                webSubsector.TVItem = tvItem;
                webSubsector.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(SubsectorTVItemID);
                webSubsector.TVItemStatList = await GetTVItemStatListWithTVItemID(SubsectorTVItemID);
                webSubsector.MapInfoList = await GetMapInfoListWithTVItemID(SubsectorTVItemID);
                webSubsector.MapInfoPointList = await GetMapInfoPointListWithTVItemID(SubsectorTVItemID);
                webSubsector.TVFileList = await GetTVFileListWithTVItemID(SubsectorTVItemID);
                webSubsector.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(SubsectorTVItemID);
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
                webSubsector.MWQMAnalysisReportParameterList = await GetMWQMAnalysisReportParameterListUnderSubsector(SubsectorTVItemID);
                webSubsector.LabSheetList = await GetLabSheetListUnderSubsector(SubsectorTVItemID);
                webSubsector.LabSheetDetailList = await GetLabSheetDetailListUnderSubsector(SubsectorTVItemID);
                webSubsector.LabSheetTubeMPNDetailList = await GetLabSheetTubeMPNDetailListUnderSubsector(SubsectorTVItemID);
                webSubsector.MWQMSubsector = await GetMWQMSubsector(SubsectorTVItemID);
                webSubsector.MWQMSubsectorLanguageList = await GetMWQMSubsectorLanguageList(SubsectorTVItemID);
                webSubsector.UseOfSiteList = await GetUseOfSiteList(SubsectorTVItemID);

                await DoStore<WebSubsector>(webSubsector, $"WebSubsector_{SubsectorTVItemID}.gz");
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
