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
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn1980FromSubsector(int TVItemID)
        {
            return await GetWeb10YearOfSampleStartingFromYearFromSubsector(TVItemID, 1980);
        }
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn1990FromSubsector(int TVItemID)
        {
            return await GetWeb10YearOfSampleStartingFromYearFromSubsector(TVItemID, 1990);
        }
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2000FromSubsector(int TVItemID)
        {
            return await GetWeb10YearOfSampleStartingFromYearFromSubsector(TVItemID, 2000);
        }
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2010FromSubsector(int TVItemID)
        {
            return await GetWeb10YearOfSampleStartingFromYearFromSubsector(TVItemID, 2010);
        }
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2020FromSubsector(int TVItemID)
        {
            return await GetWeb10YearOfSampleStartingFromYearFromSubsector(TVItemID, 2020);
        }
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2030FromSubsector(int TVItemID)
        {
            return await GetWeb10YearOfSampleStartingFromYearFromSubsector(TVItemID, 2030);
        }
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2040FromSubsector(int TVItemID)
        {
            return await GetWeb10YearOfSampleStartingFromYearFromSubsector(TVItemID, 2040);
        }
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2050FromSubsector(int TVItemID)
        {
            return await GetWeb10YearOfSampleStartingFromYearFromSubsector(TVItemID, 2050);
        }
        #endregion Functions public

        #region Functions private
        private async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingFromYearFromSubsector(int TVItemID, int Year)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVTypeEnum tvType = TVTypeEnum.Subsector;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == TVItemID
                             && c.TVType == tvType
                             select c).FirstOrDefault();

            if (tvItem == null)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Subsector }]");
            }

            if (Year < 1980)
            {
                Year = 1980;
            }

            DateTime StartDate = new DateTime(Year, 1, 1);
            DateTime EndDate = new DateTime(Year + 9, 12, 31);

            WebSample webSample = new WebSample();

            try
            {
                webSample.MWQMSampleList = (from c in db.TVItems
                                            from s in db.MWQMSites
                                            from sa in db.MWQMSamples
                                            where c.TVItemID == s.MWQMSiteTVItemID
                                            && c.TVItemID == sa.MWQMSiteTVItemID
                                            && c.TVPath.Contains(tvItem.TVPath + "p")
                                            && c.ParentID == tvItem.TVItemID
                                            && c.TVType == TVTypeEnum.MWQMSite
                                            && sa.SampleDateTime_Local >= StartDate
                                            && sa.SampleDateTime_Local <= EndDate
                                            select sa).AsNoTracking().ToList();
                webSample.MWQMSampleLanguageList = (from c in db.TVItems
                                                    from s in db.MWQMSites
                                                    from sa in db.MWQMSamples
                                                    from sal in db.MWQMSampleLanguages
                                                    where c.TVItemID == s.MWQMSiteTVItemID
                                                    && c.TVItemID == sa.MWQMSiteTVItemID
                                                    && sa.MWQMSampleID == sal.MWQMSampleID
                                                    && c.TVPath.Contains(tvItem.TVPath + "p")
                                                    && c.ParentID == tvItem.TVItemID
                                                    && c.TVType == TVTypeEnum.MWQMSite
                                                    && sa.SampleDateTime_Local >= StartDate
                                                    && sa.SampleDateTime_Local <= EndDate
                                                    select sal).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webSample));
        }
        #endregion Functions private

    }
}
