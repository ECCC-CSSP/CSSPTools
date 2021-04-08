﻿/*
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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebClimateDataValueGzFile(int ClimateSiteTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem TVItemClimateSite = await GetTVItemWithTVItemID(ClimateSiteTVItemID);

            if (TVItemClimateSite == null || TVItemClimateSite.TVType != TVTypeEnum.ClimateSite)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ClimateSiteTVItemID.ToString(), "TVType", TVTypeEnum.ClimateSite.ToString())));
            }

            WebClimateDataValue webClimateDataValue  = new WebClimateDataValue();

            try
            {
                await FillTVItemModel(webClimateDataValue.TVItemModel, TVItemClimateSite);

                await FillParentListTVItemModelList(webClimateDataValue.TVItemParentList, TVItemClimateSite);

                webClimateDataValue.ClimateDataValueList = await GetClimateDataValueListForClimateSite(TVItemClimateSite.TVItemID);

                await DoStore<WebClimateDataValue>(webClimateDataValue, $"{ WebTypeEnum.WebClimateDataValue }_{ ClimateSiteTVItemID }.gz");
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
