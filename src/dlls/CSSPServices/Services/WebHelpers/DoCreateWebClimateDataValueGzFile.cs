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
    public partial class CSSPWebService : ControllerBase, ICSSPWebService
    {
        private async Task<ActionResult<bool>> DoCreateWebClimateDataValue(int ClimateSiteTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(ClimateSiteTVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.ClimateSite)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ClimateSiteTVItemID.ToString(), "TVType", TVTypeEnum.ClimateSite.ToString())));
            }

            WebClimateDataValue webClimateDataValue  = new WebClimateDataValue();

            try
            {
                webClimateDataValue.ClimateDataValueList = await GetClimateDataValueListForClimateSite(tvItem.TVItemID);

                await DoStore<WebClimateDataValue>(webClimateDataValue, $"WebClimateDataValue_{ClimateSiteTVItemID}.gz");
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
