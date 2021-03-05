/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CSSPWebModels;

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<ActionResult<bool>> DoCreateWebSubsectorGzFileLocal(int SubsectorTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem TVItemSubsector = await GetTVItemWithTVItemID(SubsectorTVItemID);

            if (TVItemSubsector == null || TVItemSubsector.TVType != TVTypeEnum.Subsector)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SubsectorTVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString())));
            }

            WebSubsector webSubsector = new WebSubsector();

            try
            {
                await FillTVItemModelLocal(webSubsector.TVItemModel, TVItemSubsector);

                await FillParentListTVItemModelListLocal(webSubsector.TVItemParentList, TVItemSubsector);

                await FillChildListTVItemModelListLocal(webSubsector.TVItemMWQMSiteList, TVItemSubsector, TVTypeEnum.MWQMSite);

                await FillChildListTVItemModelListLocal(webSubsector.TVItemMWQMRunList, TVItemSubsector, TVTypeEnum.MWQMRun);

                await FillChildListTVItemModelListLocal(webSubsector.TVItemPolSourceSiteList, TVItemSubsector, TVTypeEnum.PolSourceSite);

                await FillChildListTVItemModelListLocal(webSubsector.TVItemClassificationList, TVItemSubsector, TVTypeEnum.Classification);

                webSubsector.MWQMAnalysisReportParameterList = await GetMWQMAnalysisReportParameterListUnderSubsector(SubsectorTVItemID);

                await FillLabSheetModelListLocal(webSubsector.LabSheetModelList, TVItemSubsector);

                webSubsector.MWQMSubsector = await GetMWQMSubsector(SubsectorTVItemID);
                webSubsector.MWQMSubsectorLanguageList = await GetMWQMSubsectorLanguageList(SubsectorTVItemID);
                webSubsector.UseOfSiteList = await GetUseOfSiteList(SubsectorTVItemID);

                DoStoreLocal<WebSubsector>(webSubsector, $"{ WebTypeEnum.WebSubsector }_{ SubsectorTVItemID }.gz");
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
