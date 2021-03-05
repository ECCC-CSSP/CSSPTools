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
        private async Task<ActionResult<bool>> DoCreateWebHydrometricSiteGzFileLocal(int ProvinceTVItemID)
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

            WebHydrometricSite webHydrometricSite  = new WebHydrometricSite();

            try
            {
                await FillTVItemModelLocal(webHydrometricSite.TVItemModel, TVItemProvince);

                await FillParentListTVItemModelListLocal(webHydrometricSite.TVItemParentList, TVItemProvince);

                webHydrometricSite.HydrometricSiteList = await GetHydrometricSiteListUnderProvince(TVItemProvince);

                await FillChildListTVItemModelListLocal(webHydrometricSite.TVItemHydrometricSiteList, TVItemProvince, TVTypeEnum.HydrometricSite);

                webHydrometricSite.RatingCurveList = await GetRatingCurveListUnderProvince(TVItemProvince);
                webHydrometricSite.RatingCurveValueList = await GetRatingCurveValueListUnderProvince(TVItemProvince);

                DoStoreLocal<WebHydrometricSite>(webHydrometricSite, $"{ WebTypeEnum.WebHydrometricSite }_{ ProvinceTVItemID }.gz");
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
