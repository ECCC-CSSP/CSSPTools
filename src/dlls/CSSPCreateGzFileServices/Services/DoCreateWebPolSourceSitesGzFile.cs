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
        private async Task<ActionResult<bool>> DoCreateWebPolSourceSitesGzFile(int SubsectorTVItemID)
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

            WebPolSourceSites webPolSourceSites = new WebPolSourceSites();

            try
            {
                await FillTVItemModelAndParentTVItemModelList(webPolSourceSites.TVItemStatMapModel, webPolSourceSites.TVItemStatModelParentList, TVItemSubsector);

                await FillPolSourceSiteModelList(webPolSourceSites.PolSourceSiteModelList, TVItemSubsector, TVTypeEnum.PolSourceSite);

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebPolSourceSites>(webPolSourceSites, $"{ WebTypeEnum.WebPolSourceSites }_{ SubsectorTVItemID }.gz");
                }
                else
                {
                    await DoStore<WebPolSourceSites>(webPolSourceSites, $"{ WebTypeEnum.WebPolSourceSites }_{ SubsectorTVItemID }.gz");
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
