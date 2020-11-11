/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebAllTVItemLanguageGzFile()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            WebAllTVItemLanguage webAllTVItemLanguage = new WebAllTVItemLanguage();

            try
            {
                webAllTVItemLanguage.TVItemLanguageList = await GetAllTVItemLanguage();

                await DoStore<WebAllTVItemLanguage>(webAllTVItemLanguage, $"WebAllTVItemLanguage.gz");
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
