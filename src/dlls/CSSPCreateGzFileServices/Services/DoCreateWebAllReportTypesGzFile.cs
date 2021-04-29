/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebAllReportTypesGzFile()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            WebAllReportTypes webAllReportTypes = new WebAllReportTypes();

            try
            {
                await FillReportTypeModelList(webAllReportTypes.ReportTypeModelList);

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebAllReportTypes>(webAllReportTypes, $"{ WebTypeEnum.WebAllReportTypes }.gz");
                }
                else
                {
                    await DoStore<WebAllReportTypes>(webAllReportTypes, $"{ WebTypeEnum.WebAllReportTypes }.gz");
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
