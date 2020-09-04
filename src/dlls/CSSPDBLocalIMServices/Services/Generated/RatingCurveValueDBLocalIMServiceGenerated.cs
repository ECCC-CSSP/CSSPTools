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
using LocalServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBLocalIMServices
{
    public partial interface IRatingCurveValueDBLocalIMService
    {
        Task<ActionResult<bool>> Delete(int RatingCurveValueID);
        Task<ActionResult<List<RatingCurveValue>>> GetRatingCurveValueList(int skip = 0, int take = 100);
        Task<ActionResult<RatingCurveValue>> GetRatingCurveValueWithRatingCurveValueID(int RatingCurveValueID);
        Task<ActionResult<RatingCurveValue>> Post(RatingCurveValue ratingcurvevalue);
        Task<ActionResult<RatingCurveValue>> Put(RatingCurveValue ratingcurvevalue);
    }
    public partial class RatingCurveValueDBLocalIMService : ControllerBase, IRatingCurveValueDBLocalIMService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBInMemoryContext dbLocalIM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueDBLocalIMService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBInMemoryContext dbLocalIM)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.dbLocalIM = dbLocalIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<RatingCurveValue>> GetRatingCurveValueWithRatingCurveValueID(int RatingCurveValueID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            RatingCurveValue ratingCurveValue = (from c in dbLocalIM.RatingCurveValues.AsNoTracking()
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
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<RatingCurveValue> ratingCurveValueList = (from c in dbLocalIM.RatingCurveValues.AsNoTracking() orderby c.RatingCurveValueID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(ratingCurveValueList));
        }
        public async Task<ActionResult<bool>> Delete(int RatingCurveValueID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            RatingCurveValue ratingCurveValue = (from c in dbLocalIM.RatingCurveValues
                    where c.RatingCurveValueID == RatingCurveValueID
                    select c).FirstOrDefault();

            if (ratingCurveValue == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "RatingCurveValue", "RatingCurveValueID", RatingCurveValueID.ToString())));
            }

            try
            {
                dbLocalIM.RatingCurveValues.Remove(ratingCurveValue);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<RatingCurveValue>> Post(RatingCurveValue ratingCurveValue)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.RatingCurveValues.Add(ratingCurveValue);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(ratingCurveValue));
        }
        public async Task<ActionResult<RatingCurveValue>> Put(RatingCurveValue ratingCurveValue)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.RatingCurveValues.Update(ratingCurveValue);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(ratingCurveValue));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            RatingCurveValue ratingCurveValue = validationContext.ObjectInstance as RatingCurveValue;

            if (actionDBType == ActionDBTypeEnum.Create)
            {
                if (ratingCurveValue.RatingCurveValueID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RatingCurveValueID"), new[] { nameof(ratingCurveValue.RatingCurveValueID) });
                }
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (ratingCurveValue.RatingCurveValueID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RatingCurveValueID"), new[] { nameof(ratingCurveValue.RatingCurveValueID) });
                }

                if (!(from c in dbLocalIM.RatingCurveValues select c).Where(c => c.RatingCurveValueID == ratingCurveValue.RatingCurveValueID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "RatingCurveValue", "RatingCurveValueID", ratingCurveValue.RatingCurveValueID.ToString()), new[] { nameof(ratingCurveValue.RatingCurveValueID) });
                }
            }

            RatingCurve RatingCurveRatingCurveID = null;
            RatingCurveRatingCurveID = (from c in dbLocalIM.RatingCurves where c.RatingCurveID == ratingCurveValue.RatingCurveID select c).FirstOrDefault();

            if (RatingCurveRatingCurveID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveID", ratingCurveValue.RatingCurveID.ToString()), new[] { nameof(ratingCurveValue.RatingCurveID) });
            }

            if (ratingCurveValue.StageValue_m < 0 || ratingCurveValue.StageValue_m > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "StageValue_m", "0", "1000"), new[] { nameof(ratingCurveValue.StageValue_m) });
            }

            if (ratingCurveValue.DischargeValue_m3_s < 0 || ratingCurveValue.DischargeValue_m3_s > 1000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DischargeValue_m3_s", "0", "1000000"), new[] { nameof(ratingCurveValue.DischargeValue_m3_s) });
            }

            if (ratingCurveValue.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(ratingCurveValue.LastUpdateDate_UTC) });
            }
            else
            {
                if (ratingCurveValue.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(ratingCurveValue.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems where c.TVItemID == ratingCurveValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", ratingCurveValue.LastUpdateContactTVItemID.ToString()), new[] { nameof(ratingCurveValue.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(ratingCurveValue.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
