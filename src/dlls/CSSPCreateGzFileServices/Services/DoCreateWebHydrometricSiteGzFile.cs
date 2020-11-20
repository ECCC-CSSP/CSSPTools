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
        private async Task<ActionResult<bool>> DoCreateWebHydrometricSiteGzFile(int ProvinceTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItemProvince = await GetTVItemWithTVItemID(ProvinceTVItemID);

            if (tvItemProvince == null || tvItemProvince.TVType != TVTypeEnum.Province)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString())));
            }

            WebHydrometricSite webHydrometricSite  = new WebHydrometricSite();

            try
            {
                await FillTVItemModel(webHydrometricSite.TVItemModel, tvItemProvince);

                await FillParentListTVItemModelList(webHydrometricSite.TVItemParentList, tvItemProvince);

                webHydrometricSite.HydrometricSiteList = await GetHydrometricSiteListUnderProvince(tvItemProvince);

                await FillChildListTVItemModelList(webHydrometricSite.TVItemHydrometricSiteList, tvItemProvince, TVTypeEnum.HydrometricSite);

                webHydrometricSite.RatingCurveList = await GetRatingCurveListUnderProvince(tvItemProvince);
                webHydrometricSite.RatingCurveValueList = await GetRatingCurveValueListUnderProvince(tvItemProvince);

                await DoStore<WebHydrometricSite>(webHydrometricSite, $"WebHydrometricSite_{ProvinceTVItemID}.gz");
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
