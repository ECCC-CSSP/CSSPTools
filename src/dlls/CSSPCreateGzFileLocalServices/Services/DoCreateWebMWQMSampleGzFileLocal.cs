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

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<ActionResult<bool>> DoCreateWebMWQMSampleGzFileLocal(int SubsectorTVItemID, int Year)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem TVItemSubsector = await GetTVItemWithTVItemID(SubsectorTVItemID);
            
            if (TVItemSubsector == null || TVItemSubsector.TVType != TVTypeEnum.Subsector)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SubsectorTVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString())));
            }

            WebMWQMSample webMWQMSample = new WebMWQMSample();

            try
            {
                await FillTVItemModelLocal(webMWQMSample.TVItemModel, TVItemSubsector);

                await FillParentListTVItemModelListLocal(webMWQMSample.TVItemParentList, TVItemSubsector);

                webMWQMSample.MWQMSampleList = await GetWQMSampleListFromSubsector10Years(TVItemSubsector, Year);
                webMWQMSample.MWQMSampleLanguageList = await GetWQMSampleLanguageListFromSubsector10Years(TVItemSubsector, Year);

                DoStoreLocal<WebMWQMSample>(webMWQMSample, $"{ WebTypeEnum.WebMWQMSample }_{ SubsectorTVItemID }_{Year}_{Year + 9}.gz");
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
