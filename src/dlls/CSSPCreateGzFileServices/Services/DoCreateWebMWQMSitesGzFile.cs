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
        private async Task<ActionResult<bool>> DoCreateWebMWQMSitesGzFile(int SubsectorTVItemID)
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

            WebMWQMSites webMWQMSites = new WebMWQMSites();

            try
            {
                await FillTVItemModelAndParentTVItemModelList(webMWQMSites.TVItemStatMapModel, webMWQMSites.TVItemStatModelParentList, TVItemSubsector);

                await FillMWQMSiteModelList(webMWQMSites.MWQMSiteModelList, TVItemSubsector, TVTypeEnum.MWQMSite);

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebMWQMSites>(webMWQMSites, $"{ WebTypeEnum.WebMWQMSites }_{ SubsectorTVItemID }.gz");
                }
                else
                {
                    await DoStore<WebMWQMSites>(webMWQMSites, $"{ WebTypeEnum.WebMWQMSites }_{ SubsectorTVItemID }.gz");
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
