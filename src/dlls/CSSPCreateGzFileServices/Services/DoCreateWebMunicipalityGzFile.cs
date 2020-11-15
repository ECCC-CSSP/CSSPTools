﻿/*
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
        private async Task<ActionResult<bool>> DoCreateWebMunicipalityGzFile(int MunicipalityTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItemMunicipality = await GetTVItemWithTVItemID(MunicipalityTVItemID);

            if (tvItemMunicipality == null || tvItemMunicipality.TVType != TVTypeEnum.Municipality)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", MunicipalityTVItemID.ToString(), "TVType", TVTypeEnum.Municipality.ToString())));
            }

            WebMunicipality webMunicipality = new WebMunicipality();

            try
            {
                await FillTVItemModel(webMunicipality.TVItemModel, tvItemMunicipality);

                await FillParentListTVItemModelList(webMunicipality.TVItemParentList, tvItemMunicipality);

                await FillChildListTVItemModelList(webMunicipality.TVItemMikeScenarioList, tvItemMunicipality, TVTypeEnum.MikeScenario);

                await FillChildListTVItemInfrastructureModelList(webMunicipality.InfrastructureModelList, tvItemMunicipality, TVTypeEnum.Infrastructure);

                await FillChildListTVItemContactModelList(webMunicipality.MunicipalityContactModelList, tvItemMunicipality);

                webMunicipality.MunicipalityTVItemLinkList = await GetInfrastructureTVItemLinkListUnderMunicipality(tvItemMunicipality);

                await DoStore<WebMunicipality>(webMunicipality, $"WebMunicipality_{MunicipalityTVItemID}.gz");
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