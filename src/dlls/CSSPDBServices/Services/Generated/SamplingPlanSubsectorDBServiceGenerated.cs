/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
    public partial interface ISamplingPlanSubsectorDBService
    {
        Task<ActionResult<bool>> Delete(int SamplingPlanSubsectorID);
        Task<ActionResult<List<SamplingPlanSubsector>>> GetSamplingPlanSubsectorList(int skip = 0, int take = 100);
        Task<ActionResult<SamplingPlanSubsector>> GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(int SamplingPlanSubsectorID);
        Task<ActionResult<SamplingPlanSubsector>> Post(SamplingPlanSubsector samplingplansubsector);
        Task<ActionResult<SamplingPlanSubsector>> Put(SamplingPlanSubsector samplingplansubsector);
    }
    public partial class SamplingPlanSubsectorDBService : ControllerBase, ISamplingPlanSubsectorDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResultList { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;

            ValidationResultList = new List<ValidationResult>();
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<SamplingPlanSubsector>> GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(int SamplingPlanSubsectorID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            SamplingPlanSubsector samplingPlanSubsector = (from c in db.SamplingPlanSubsectors.AsNoTracking()
                    where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                    select c).FirstOrDefault();

            if (samplingPlanSubsector == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(samplingPlanSubsector));
        }
        public async Task<ActionResult<List<SamplingPlanSubsector>>> GetSamplingPlanSubsectorList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<SamplingPlanSubsector> samplingPlanSubsectorList = (from c in db.SamplingPlanSubsectors.AsNoTracking() orderby c.SamplingPlanSubsectorID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(samplingPlanSubsectorList));
        }
        public async Task<ActionResult<bool>> Delete(int SamplingPlanSubsectorID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            SamplingPlanSubsector samplingPlanSubsector = (from c in db.SamplingPlanSubsectors
                    where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                    select c).FirstOrDefault();

            if (samplingPlanSubsector == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", SamplingPlanSubsectorID.ToString())));
            }

            try
            {
                db.SamplingPlanSubsectors.Remove(samplingPlanSubsector);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<SamplingPlanSubsector>> Post(SamplingPlanSubsector samplingPlanSubsector)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.SamplingPlanSubsectors.Add(samplingPlanSubsector);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlanSubsector));
        }
        public async Task<ActionResult<SamplingPlanSubsector>> Put(SamplingPlanSubsector samplingPlanSubsector)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.SamplingPlanSubsectors.Update(samplingPlanSubsector);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlanSubsector));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            SamplingPlanSubsector samplingPlanSubsector = validationContext.ObjectInstance as SamplingPlanSubsector;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (samplingPlanSubsector.SamplingPlanSubsectorID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SamplingPlanSubsectorID"), new[] { nameof(samplingPlanSubsector.SamplingPlanSubsectorID) }));
                }

                if (!(from c in db.SamplingPlanSubsectors.AsNoTracking() select c).Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", samplingPlanSubsector.SamplingPlanSubsectorID.ToString()), new[] { nameof(samplingPlanSubsector.SamplingPlanSubsectorID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)samplingPlanSubsector.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(samplingPlanSubsector.DBCommand) }));
            }

            SamplingPlan SamplingPlanSamplingPlanID = null;
            SamplingPlanSamplingPlanID = (from c in db.SamplingPlans.AsNoTracking() where c.SamplingPlanID == samplingPlanSubsector.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", samplingPlanSubsector.SamplingPlanID.ToString()), new[] { nameof(samplingPlanSubsector.SamplingPlanID)}));
            }

            TVItem TVItemSubsectorTVItemID = null;
            TVItemSubsectorTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == samplingPlanSubsector.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "SubsectorTVItemID", samplingPlanSubsector.SubsectorTVItemID.ToString()), new[] { nameof(samplingPlanSubsector.SubsectorTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { nameof(samplingPlanSubsector.SubsectorTVItemID) }));
                }
            }

            if (samplingPlanSubsector.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(samplingPlanSubsector.LastUpdateDate_UTC) }));
            }
            else
            {
                if (samplingPlanSubsector.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(samplingPlanSubsector.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == samplingPlanSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", samplingPlanSubsector.LastUpdateContactTVItemID.ToString()), new[] { nameof(samplingPlanSubsector.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(samplingPlanSubsector.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
