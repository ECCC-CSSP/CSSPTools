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
    public partial interface IRatingCurveValueDBService
    {
        Task<ActionResult<bool>> Delete(int RatingCurveValueID);
        Task<ActionResult<List<RatingCurveValue>>> GetRatingCurveValueList(int skip = 0, int take = 100);
        Task<ActionResult<RatingCurveValue>> GetRatingCurveValueWithRatingCurveValueID(int RatingCurveValueID);
        Task<ActionResult<RatingCurveValue>> Post(RatingCurveValue ratingcurvevalue);
        Task<ActionResult<RatingCurveValue>> Put(RatingCurveValue ratingcurvevalue);
    }
    public partial class RatingCurveValueDBService : ControllerBase, IRatingCurveValueDBService
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
        public RatingCurveValueDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<RatingCurveValue>> GetRatingCurveValueWithRatingCurveValueID(int RatingCurveValueID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            RatingCurveValue ratingCurveValue = (from c in db.RatingCurveValues.AsNoTracking()
                    where c.RatingCurveValueID == RatingCurveValueID
                    select c).FirstOrDefault();

            if (ratingCurveValue == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(ratingCurveValue));
        }
        public async Task<ActionResult<List<RatingCurveValue>>> GetRatingCurveValueList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<RatingCurveValue> ratingCurveValueList = (from c in db.RatingCurveValues.AsNoTracking() orderby c.RatingCurveValueID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(ratingCurveValueList));
        }
        public async Task<ActionResult<bool>> Delete(int RatingCurveValueID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            RatingCurveValue ratingCurveValue = (from c in db.RatingCurveValues
                    where c.RatingCurveValueID == RatingCurveValueID
                    select c).FirstOrDefault();

            if (ratingCurveValue == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "RatingCurveValue", "RatingCurveValueID", RatingCurveValueID.ToString())));
            }

            try
            {
                db.RatingCurveValues.Remove(ratingCurveValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<RatingCurveValue>> Post(RatingCurveValue ratingCurveValue)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.RatingCurveValues.Add(ratingCurveValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(ratingCurveValue));
        }
        public async Task<ActionResult<RatingCurveValue>> Put(RatingCurveValue ratingCurveValue)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.RatingCurveValues.Update(ratingCurveValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(ratingCurveValue));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            RatingCurveValue ratingCurveValue = validationContext.ObjectInstance as RatingCurveValue;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (ratingCurveValue.RatingCurveValueID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RatingCurveValueID"), new[] { nameof(ratingCurveValue.RatingCurveValueID) }));
                }

                if (!(from c in db.RatingCurveValues.AsNoTracking() select c).Where(c => c.RatingCurveValueID == ratingCurveValue.RatingCurveValueID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "RatingCurveValue", "RatingCurveValueID", ratingCurveValue.RatingCurveValueID.ToString()), new[] { nameof(ratingCurveValue.RatingCurveValueID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)ratingCurveValue.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(ratingCurveValue.DBCommand) }));
            }

            RatingCurve RatingCurveRatingCurveID = null;
            RatingCurveRatingCurveID = (from c in db.RatingCurves.AsNoTracking() where c.RatingCurveID == ratingCurveValue.RatingCurveID select c).FirstOrDefault();

            if (RatingCurveRatingCurveID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveID", ratingCurveValue.RatingCurveID.ToString()), new[] { nameof(ratingCurveValue.RatingCurveID)}));
            }

            if (ratingCurveValue.StageValue_m < 0 || ratingCurveValue.StageValue_m > 1000)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "StageValue_m", "0", "1000"), new[] { nameof(ratingCurveValue.StageValue_m) }));
            }

            if (ratingCurveValue.DischargeValue_m3_s < 0 || ratingCurveValue.DischargeValue_m3_s > 1000000)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DischargeValue_m3_s", "0", "1000000"), new[] { nameof(ratingCurveValue.DischargeValue_m3_s) }));
            }

            if (ratingCurveValue.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(ratingCurveValue.LastUpdateDate_UTC) }));
            }
            else
            {
                if (ratingCurveValue.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(ratingCurveValue.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == ratingCurveValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", ratingCurveValue.LastUpdateContactTVItemID.ToString()), new[] { nameof(ratingCurveValue.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(ratingCurveValue.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
