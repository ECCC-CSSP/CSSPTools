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
        private async Task<ActionResult<bool>> DoCreateWebPolSourceSitesGzFileLocal(int SubsectorTVItemID)
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
                await FillTVItemModelLocal(webPolSourceSites.TVItemModel, TVItemSubsector);

                await FillChildListTVItemModelListLocal(webPolSourceSites.TVItemPolSourceSiteList, TVItemSubsector, TVTypeEnum.PolSourceSite);

                await FillParentListTVItemModelListLocal(webPolSourceSites.TVItemParentList, TVItemSubsector);

                await FillChildListOfChildTVItemModelListLocal(webPolSourceSites.TVItemFileList, TVItemSubsector, TVTypeEnum.PolSourceSite, TVTypeEnum.File);

                await FillChildListTVItemPolSourceSiteModelListLocal(webPolSourceSites.PolSourceSiteModelList, TVItemSubsector, TVTypeEnum.PolSourceSite);

                DoStoreLocal<WebPolSourceSites>(webPolSourceSites, $"{ WebTypeEnum.WebPolSourceSites }_{ SubsectorTVItemID }.gz");
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
