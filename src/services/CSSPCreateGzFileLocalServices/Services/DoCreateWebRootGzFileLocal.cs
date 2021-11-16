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

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<ActionResult<bool>> DoCreateWebRootGzFileLocal()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem TVItemRoot = await GetTVItemRoot();

            if (TVItemRoot == null)
            {
                return await Task.FromResult(BadRequest(CSSPCultureServicesRes.TVItemRootCouldNotBeFound));
            }

            WebRoot webRoot = new WebRoot();

            try
            {
                await FillTVItemModelLocal(webRoot.TVItemModel, TVItemRoot);

                await FillParentListTVItemModelListLocal(webRoot.TVItemParentList, TVItemRoot);

                await FillChildListTVItemModelListLocal(webRoot.TVItemStatMapModelCountryList, TVItemRoot, TVTypeEnum.Country);

                await FillChildListTVItemModelListLocal(webRoot.TVItemFileList, TVItemRoot, TVTypeEnum.File);

                DoStoreLocal<WebRoot>(webRoot, $"{ WebTypeEnum.WebRoot }.gz");
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