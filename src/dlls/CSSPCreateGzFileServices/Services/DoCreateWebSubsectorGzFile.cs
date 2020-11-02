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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebSubsectorGzFile(int SubsectorTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItemSubsector = await GetTVItemWithTVItemID(SubsectorTVItemID);

            if (tvItemSubsector == null || tvItemSubsector.TVType != TVTypeEnum.Subsector)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SubsectorTVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString())));
            }

            WebSubsector webSubsector = new WebSubsector();

            try
            {
                await FillTVItemModel(webSubsector.TVItemModel, tvItemSubsector);

                await FillParentListTVItemModelList(webSubsector.TVItemParentList, tvItemSubsector);

                await FillChildListTVItemModelList(webSubsector.TVItemMWQMSiteList, tvItemSubsector, TVTypeEnum.MWQMSite);

                await FillChildListTVItemModelList(webSubsector.TVItemMWQMRunList, tvItemSubsector, TVTypeEnum.MWQMRun);

                await FillChildListTVItemModelList(webSubsector.TVItemPolSourceSiteList, tvItemSubsector, TVTypeEnum.PolSourceSite);

                webSubsector.MWQMAnalysisReportParameterList = await GetMWQMAnalysisReportParameterListUnderSubsector(SubsectorTVItemID);

                await FillLabSheetModelList(webSubsector.LabSheetModelList, tvItemSubsector);

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
