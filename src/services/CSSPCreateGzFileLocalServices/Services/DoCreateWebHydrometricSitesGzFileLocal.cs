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
        private async Task<ActionResult<bool>> DoCreateWebHydrometricSitesGzFileLocal(int ProvinceTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem TVItemProvince = await GetTVItemWithTVItemID(ProvinceTVItemID);

            if (TVItemProvince == null || TVItemProvince.TVType != TVTypeEnum.Province)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString())));
            }

            WebHydrometricSites webHydrometricSites = new WebHydrometricSites();

            try
            {
                await FillTVItemModelLocal(webHydrometricSites.TVItemModel, TVItemProvince);

                await FillParentListTVItemModelListLocal(webHydrometricSites.TVItemParentList, TVItemProvince);

                await FillChildListTVItemModelListLocal(webHydrometricSites.TVItemHydrometricSiteList, TVItemProvince, TVTypeEnum.HydrometricSite);

                await FillChildListHydrometricSiteModelListLocal(webHydrometricSites.HydrometricSiteModelList, TVItemProvince);

                DoStoreLocal<WebHydrometricSites>(webHydrometricSites, $"{ WebTypeEnum.WebHydrometricSites }_{ ProvinceTVItemID }.gz");
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
