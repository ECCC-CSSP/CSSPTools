/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPWebServices
{
    public partial class WebService : ControllerBase, IWebService
    {
        #region Functions public 
        public async Task<ActionResult<WebSamplingPlan>> GetWebSamplingPlan(int SamplingPlanID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            WebSamplingPlan webSamplingPlan = new WebSamplingPlan();

            try
            {
                webSamplingPlan.SamplingPlan = (from c in db.SamplingPlans
                                                where c.SamplingPlanID == SamplingPlanID
                                                select c).FirstOrDefault();

                webSamplingPlan.SamplingPlanEmailList = (from c in db.SamplingPlanEmails
                                                         where c.SamplingPlanID == SamplingPlanID
                                                         select c).AsNoTracking().ToList();

                webSamplingPlan.SamplingPlanSubsectorList = (from c in db.SamplingPlanSubsectors
                                                             where c.SamplingPlanID == SamplingPlanID
                                                             select c).AsNoTracking().ToList();

                webSamplingPlan.SamplingPlanSubsectorSiteList = (from c in db.SamplingPlanSubsectors
                                                                 from cs in db.SamplingPlanSubsectorSites
                                                                 where c.SamplingPlanSubsectorID == cs.SamplingPlanSubsectorID
                                                                 && c.SamplingPlanID == SamplingPlanID
                                                                 select cs).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webSamplingPlan));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
