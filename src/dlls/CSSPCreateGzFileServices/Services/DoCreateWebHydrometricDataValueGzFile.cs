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
        private async Task<ActionResult<bool>> DoCreateWebHydrometricDataValueGzFile(int HydrometricSiteTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            TVItem TVItemHydrometric = await GetTVItemWithTVItemID(HydrometricSiteTVItemID);

            if (TVItemHydrometric == null || TVItemHydrometric.TVType != TVTypeEnum.HydrometricSite)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", HydrometricSiteTVItemID.ToString(), "TVType", TVTypeEnum.HydrometricSite.ToString())));
            }

            WebHydrometricDataValue webHydrometricDataValue  = new WebHydrometricDataValue();

            try
            {
                await FillTVItemModel(webHydrometricDataValue.TVItemModel, TVItemHydrometric);

                await FillParentListTVItemModelList(webHydrometricDataValue.TVItemParentList, TVItemHydrometric);

                webHydrometricDataValue.HydrometricDataValueList = await GetHydrometricDataValueListForHydrometricSite(TVItemHydrometric.TVItemID);

                await DoStore<WebHydrometricDataValue>(webHydrometricDataValue, $"{ WebTypeEnum.WebHydrometricDataValue }_{ HydrometricSiteTVItemID }.gz");
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
