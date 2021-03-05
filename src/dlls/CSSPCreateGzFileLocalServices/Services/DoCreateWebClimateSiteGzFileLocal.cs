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
        private async Task<ActionResult<bool>> DoCreateWebClimateSiteGzFileLocal(int ProvinceTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem TVItemProvince = await GetTVItemWithTVItemID(ProvinceTVItemID);

            if (TVItemProvince == null || TVItemProvince.TVType != TVTypeEnum.Province)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString())));
            }

            WebClimateSite webClimateSite = new WebClimateSite();

            try
            {
                webClimateSite.ClimateSiteList = await GetClimateSiteListUnderProvince(TVItemProvince);

                await FillTVItemModelLocal(webClimateSite.TVItemModel, TVItemProvince);

                await FillParentListTVItemModelListLocal(webClimateSite.TVItemParentList, TVItemProvince);

                await FillChildListTVItemModelListLocal(webClimateSite.TVItemClimateSiteList, TVItemProvince, TVTypeEnum.ClimateSite);

                DoStoreLocal<WebClimateSite>(webClimateSite, $"{ WebTypeEnum.WebClimateSite }_{ ProvinceTVItemID }.gz");
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
