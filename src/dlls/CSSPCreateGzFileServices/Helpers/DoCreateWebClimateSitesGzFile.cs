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
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateWebClimateSitesGzFile(int ProvinceTVItemID)
        {
            string FunctionName = $"{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(ProvinceTVItemID: { ProvinceTVItemID })";
            await CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemProvince = await GetTVItemWithTVItemID(ProvinceTVItemID);

            if (TVItemProvince == null || TVItemProvince.TVType != TVTypeEnum.Province)
            {
                await CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString()), new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebClimateSites webClimateSites = new WebClimateSites();

            try
            {
                if (!await FillTVItemModelAndParentTVItemModelList(webClimateSites.TVItemModel, webClimateSites.TVItemModelParentList, TVItemProvince)) return await Task.FromResult(false);

                if (!await FillClimateSiteModelList(webClimateSites.ClimateSiteModelList, TVItemProvince)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebClimateSites>(webClimateSites, $"{ WebTypeEnum.WebClimateSites }_{ ProvinceTVItemID }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebClimateSites>(webClimateSites, $"{ WebTypeEnum.WebClimateSites }_{ ProvinceTVItemID }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                await CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
