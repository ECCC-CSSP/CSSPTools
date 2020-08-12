/*
 * Manually edited
 * 
 */
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CSSPWebService : ControllerBase, ICSSPWebService
    {
        private async Task<ActionResult<bool>> DoCreateWebReportType()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            WebReportType webReportType = new WebReportType();

            try
            {
                webReportType.ReportTypeList = await GetReportTypeList();
                webReportType.ReportSectionList = await GetReportSectionList();

                await DoStore<WebReportType>(webReportType, $"WebReportType.gz");
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
