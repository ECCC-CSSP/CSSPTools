/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPWebModels;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebRootGzFile()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            TVItem TVItemRoot = await GetTVItemRoot();

            if (TVItemRoot == null)
            {
                return await Task.FromResult(BadRequest(CSSPCultureServicesRes.TVItemRootCouldNotBeFound));
            }

            WebRoot webRoot = new WebRoot();

            try
            {
                await FillTVItemModel(webRoot.TVItemModel, TVItemRoot);

                await FillParentListTVItemModelList(webRoot.TVItemParentList, TVItemRoot);

                await FillChildListTVItemModelList(webRoot.TVItemCountryList, TVItemRoot, TVTypeEnum.Country);

                await FillChildListTVItemModelList(webRoot.TVItemFileList, TVItemRoot, TVTypeEnum.File);

                await DoStore<WebRoot>(webRoot, $"{ WebTypeEnum.WebRoot }.gz");
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