﻿/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebAllTelsGzFile()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem TVItemRoot = await GetTVItemRoot();

            if (TVItemRoot == null || TVItemRoot.TVType != TVTypeEnum.Root)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_,
                    "TVItem", "TVType", TVTypeEnum.Root.ToString())));
            }

            WebAllTels webAllTels  = new WebAllTels();

            try
            {
                webAllTels.TelList = await GetAllTel();

                await FillChildListTVItemModelList(webAllTels.TVItemAllTelList, TVItemRoot, TVTypeEnum.Tel);

                await DoStore<WebAllTels>(webAllTels, $"{WebTypeEnum.WebAllTels }.gz");
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
