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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebSubsectorGzFile(int SubsectorTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
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
                await FillTVItemModelAndParentTVItemModelList(webSubsector.TVItemModel, webSubsector.TVItemModelParentList, TVItemSubsector);

                await FillChildListTVItemModelList(webSubsector.TVItemModelClassificationList, TVItemSubsector, TVTypeEnum.Classification);

                await FillChildListTVItemModelList(webSubsector.TVItemModelMWQMSiteList, TVItemSubsector, TVTypeEnum.MWQMSite);

                await FillChildListTVItemModelList(webSubsector.TVItemModelMWQMRunList, TVItemSubsector, TVTypeEnum.MWQMRun);

                await FillChildListTVItemModelList(webSubsector.TVItemModelPolSourceSiteList, TVItemSubsector, TVTypeEnum.PolSourceSite);

                await FillFileModelList(webSubsector.TVFileModelList, TVItemSubsector);

                webSubsector.MWQMAnalysisReportParameterList = await GetMWQMAnalysisReportParameterListUnderSubsector(SubsectorTVItemID);
                webSubsector.MWQMSubsector = await GetMWQMSubsector(SubsectorTVItemID);
                webSubsector.MWQMSubsectorLanguageList = await GetMWQMSubsectorLanguageList(SubsectorTVItemID);
                webSubsector.UseOfSiteList = await GetUseOfSiteList(SubsectorTVItemID);

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebSubsector>(webSubsector, $"{ WebTypeEnum.WebSubsector }_{ SubsectorTVItemID }.gz");
                }
                else
                {
                    await DoStore<WebSubsector>(webSubsector, $"{ WebTypeEnum.WebSubsector }_{ SubsectorTVItemID }.gz");
                }
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
