/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CSSPWebModels;
using CSSPDBModels;

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<ActionResult<bool>> DoCreateWebTideSitesGzFileLocal(int ProvinceTVItemID)
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

            WebTideSites webTideSites = new WebTideSites();

            try
            {
                webTideSites.TideSiteList = await GetTideSiteListUnderProvince(TVItemProvince);

                await FillTVItemModelLocal(webTideSites.TVItemModel, TVItemProvince);

                await FillParentListTVItemModelListLocal(webTideSites.TVItemParentList, TVItemProvince);

                await FillChildListTVItemModelListLocal(webTideSites.TVItemTideSiteList, TVItemProvince, TVTypeEnum.TideSite);

                DoStoreLocal<WebTideSites>(webTideSites, $"{ WebTypeEnum.WebTideSites }_{ ProvinceTVItemID }.gz");
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
