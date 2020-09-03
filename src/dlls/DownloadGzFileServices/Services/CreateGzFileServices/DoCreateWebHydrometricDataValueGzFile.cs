/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebHydrometricDataValueGzFile(int HydrometricSiteTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(HydrometricSiteTVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.HydrometricSite)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", HydrometricSiteTVItemID.ToString(), "TVType", TVTypeEnum.HydrometricSite.ToString())));
            }

            WebHydrometricDataValue webHydrometricDataValue  = new WebHydrometricDataValue();

            try
            {
                webHydrometricDataValue.HydrometricDataValueList = await GetHydrometricDataValueListForHydrometricSite(tvItem.TVItemID);

                await DoStore<WebHydrometricDataValue>(webHydrometricDataValue, $"WebHydrometricDataValue_{HydrometricSiteTVItemID}.gz");
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
