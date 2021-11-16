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
        private async Task<ActionResult<bool>> DoCreateWebClimateSitesGzFileLocal(int ProvinceTVItemID)
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

            WebClimateSites webClimateSites = new WebClimateSites();

            try
            {
                await FillTVItemModelLocal(webClimateSites.TVItemModel, TVItemProvince);

                await FillParentListTVItemModelListLocal(webClimateSites.TVItemParentList, TVItemProvince);

                await FillChildListTVItemModelListLocal(webClimateSites.TVItemClimateSiteList, TVItemProvince, TVTypeEnum.ClimateSite);

                await FillChildListClimateSiteModelListLocal(webClimateSites.ClimateSiteModelList, TVItemProvince);

                DoStoreLocal<WebClimateSites>(webClimateSites, $"{ WebTypeEnum.WebClimateSites }_{ ProvinceTVItemID }.gz");
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
