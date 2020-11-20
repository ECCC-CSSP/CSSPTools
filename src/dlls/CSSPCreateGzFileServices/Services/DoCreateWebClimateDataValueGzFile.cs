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
        private async Task<ActionResult<bool>> DoCreateWebClimateDataValueGzFile(int ClimateSiteTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItemClimateSite = await GetTVItemWithTVItemID(ClimateSiteTVItemID);

            if (tvItemClimateSite == null || tvItemClimateSite.TVType != TVTypeEnum.ClimateSite)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ClimateSiteTVItemID.ToString(), "TVType", TVTypeEnum.ClimateSite.ToString())));
            }

            WebClimateDataValue webClimateDataValue  = new WebClimateDataValue();

            try
            {
                await FillTVItemModel(webClimateDataValue.TVItemModel, tvItemClimateSite);

                await FillParentListTVItemModelList(webClimateDataValue.TVItemParentList, tvItemClimateSite);

                webClimateDataValue.ClimateDataValueList = await GetClimateDataValueListForClimateSite(tvItemClimateSite.TVItemID);

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
