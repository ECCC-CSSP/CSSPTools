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
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem TVItemMunicipality = await GetTVItemWithTVItemID(MunicipalityTVItemID);

            if (TVItemMunicipality == null || TVItemMunicipality.TVType != TVTypeEnum.Municipality)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", MunicipalityTVItemID.ToString(), "TVType", TVTypeEnum.Municipality.ToString())));
            }

            WebMunicipality webMunicipality = new WebMunicipality();

            try
            {
                await FillTVItemModelAndParentTVItemModelList(webMunicipality.TVItemModel, webMunicipality.TVItemModelParentList, TVItemMunicipality);

                await FillChildListTVItemModelList(webMunicipality.TVItemModelInfrastructureList, TVItemMunicipality, TVTypeEnum.Infrastructure);

                await FillChildListTVItemModelList(webMunicipality.TVItemModelMikeScenarioList, TVItemMunicipality, TVTypeEnum.MikeScenario);

                await FillFileModelList(webMunicipality.TVFileModelList, TVItemMunicipality);

                await FillChildListTVItemContactModelList(webMunicipality.MunicipalityContactModelList, TVItemMunicipality);

                await FillInfrastructureModelList(webMunicipality.InfrastructureModelList, TVItemMunicipality);

                webMunicipality.MunicipalityTVItemLinkList = await GetInfrastructureTVItemLinkListUnderMunicipality(TVItemMunicipality);

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebMunicipality>(webMunicipality, $"{ WebTypeEnum.WebMunicipality }_{ MunicipalityTVItemID }.gz");
                }
                else
                {
                    await DoStore<WebMunicipality>(webMunicipality, $"{ WebTypeEnum.WebMunicipality }_{ MunicipalityTVItemID }.gz");
                }
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
