/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBServices
{
    public partial interface ISamplingPlanSubsectorSiteDBService
    {
        Task<ActionResult<bool>> Delete(int SamplingPlanSubsectorSiteID);
        Task<ActionResult<List<SamplingPlanSubsectorSite>>> GetSamplingPlanSubsectorSiteList(int skip = 0, int take = 100);
        Task<ActionResult<SamplingPlanSubsectorSite>> GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(int SamplingPlanSubsectorSiteID);
        Task<ActionResult<SamplingPlanSubsectorSite>> Post(SamplingPlanSubsectorSite samplingplansubsectorsite);
        Task<ActionResult<SamplingPlanSubsectorSite>> Put(SamplingPlanSubsectorSite samplingplansubsectorsite);
    }
    public partial class SamplingPlanSubsectorSiteDBService : ControllerBase, ISamplingPlanSubsectorSiteDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<SamplingPlanSubsectorSite>> GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(int SamplingPlanSubsectorSiteID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            SamplingPlanSubsectorSite samplingPlanSubsectorSite = (from c in db.SamplingPlanSubsectorSites.AsNoTracking()
                    where c.SamplingPlanSubsectorSiteID == SamplingPlanSubsectorSiteID
                    select c).FirstOrDefault();

            if (samplingPlanSubsectorSite == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(samplingPlanSubsectorSite));
        }
        public async Task<ActionResult<List<SamplingPlanSubsectorSite>>> GetSamplingPlanSubsectorSiteList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = (from c in db.SamplingPlanSubsectorSites.AsNoTracking() orderby c.SamplingPlanSubsectorSiteID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(samplingPlanSubsectorSiteList));
        }
        public async Task<ActionResult<bool>> Delete(int SamplingPlanSubsectorSiteID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            SamplingPlanSubsectorSite samplingPlanSubsectorSite = (from c in db.SamplingPlanSubsectorSites
                    where c.SamplingPlanSubsectorSiteID == SamplingPlanSubsectorSiteID
                    select c).FirstOrDefault();

            if (samplingPlanSubsectorSite == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsectorSite", "SamplingPlanSubsectorSiteID", SamplingPlanSubsectorSiteID.ToString())));
            }

            try
            {
                db.SamplingPlanSubsectorSites.Remove(samplingPlanSubsectorSite);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<SamplingPlanSubsectorSite>> Post(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(samplingPlanSubsectorSite), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.SamplingPlanSubsectorSites.Add(samplingPlanSubsectorSite);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlanSubsectorSite));
        }
        public async Task<ActionResult<SamplingPlanSubsectorSite>> Put(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(samplingPlanSubsectorSite), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.SamplingPlanSubsectorSites.Update(samplingPlanSubsectorSite);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlanSubsectorSite));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            SamplingPlanSubsectorSite samplingPlanSubsectorSite = validationContext.ObjectInstance as SamplingPlanSubsectorSite;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SamplingPlanSubsectorSiteID"), new[] { nameof(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID) });
                }

                if (!(from c in db.SamplingPlanSubsectorSites select c).Where(c => c.SamplingPlanSubsectorSiteID == samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsectorSite", "SamplingPlanSubsectorSiteID", samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID.ToString()), new[] { nameof(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID) });
                }
            }

            SamplingPlanSubsector SamplingPlanSubsectorSamplingPlanSubsectorID = null;
            SamplingPlanSubsectorSamplingPlanSubsectorID = (from c in db.SamplingPlanSubsectors where c.SamplingPlanSubsectorID == samplingPlanSubsectorSite.SamplingPlanSubsectorID select c).FirstOrDefault();

            if (SamplingPlanSubsectorSamplingPlanSubsectorID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", samplingPlanSubsectorSite.SamplingPlanSubsectorID.ToString()), new[] { nameof(samplingPlanSubsectorSite.SamplingPlanSubsectorID) });
            }

            TVItem TVItemMWQMSiteTVItemID = null;
            TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsectorSite.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteTVItemID", samplingPlanSubsectorSite.MWQMSiteTVItemID.ToString()), new[] { nameof(samplingPlanSubsectorSite.MWQMSiteTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MWQMSiteTVItemID", "MWQMSite"), new[] { nameof(samplingPlanSubsectorSite.MWQMSiteTVItemID) });
                }
            }

            if (samplingPlanSubsectorSite.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(samplingPlanSubsectorSite.LastUpdateDate_UTC) });
            }
            else
            {
                if (samplingPlanSubsectorSite.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(samplingPlanSubsectorSite.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsectorSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", samplingPlanSubsectorSite.LastUpdateContactTVItemID.ToString()), new[] { nameof(samplingPlanSubsectorSite.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(samplingPlanSubsectorSite.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
