/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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

namespace CSSPDBLocalServices
{
    public partial interface ILocalRatingCurveValueDBService
    {
        Task<ActionResult<bool>> Delete(int LocalRatingCurveValueID);
        Task<ActionResult<List<LocalRatingCurveValue>>> GetLocalRatingCurveValueList(int skip = 0, int take = 100);
        Task<ActionResult<LocalRatingCurveValue>> GetLocalRatingCurveValueWithRatingCurveValueID(int RatingCurveValueID);
        Task<ActionResult<LocalRatingCurveValue>> Post(LocalRatingCurveValue localratingcurvevalue);
        Task<ActionResult<LocalRatingCurveValue>> Put(LocalRatingCurveValue localratingcurvevalue);
    }
    public partial class LocalRatingCurveValueDBService : ControllerBase, ILocalRatingCurveValueDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LocalRatingCurveValueDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<LocalRatingCurveValue>> GetLocalRatingCurveValueWithRatingCurveValueID(int RatingCurveValueID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalRatingCurveValue localRatingCurveValue = (from c in db.LocalRatingCurveValues.AsNoTracking()
                    where c.RatingCurveValueID == RatingCurveValueID
                    select c).FirstOrDefault();

            if (localRatingCurveValue == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localRatingCurveValue));
        }
        public async Task<ActionResult<List<LocalRatingCurveValue>>> GetLocalRatingCurveValueList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalRatingCurveValue> localRatingCurveValueList = (from c in db.LocalRatingCurveValues.AsNoTracking() orderby c.RatingCurveValueID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localRatingCurveValueList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalRatingCurveValueID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalRatingCurveValue localRatingCurveValue = (from c in db.LocalRatingCurveValues
                    where c.RatingCurveValueID == LocalRatingCurveValueID
                    select c).FirstOrDefault();

            if (localRatingCurveValue == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalRatingCurveValue", "LocalRatingCurveValueID", LocalRatingCurveValueID.ToString())));
            }

            try
            {
                db.LocalRatingCurveValues.Remove(localRatingCurveValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalRatingCurveValue>> Post(LocalRatingCurveValue localRatingCurveValue)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localRatingCurveValue), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalRatingCurveValues.Add(localRatingCurveValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localRatingCurveValue));
        }
        public async Task<ActionResult<LocalRatingCurveValue>> Put(LocalRatingCurveValue localRatingCurveValue)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localRatingCurveValue), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalRatingCurveValues.Update(localRatingCurveValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localRatingCurveValue));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalRatingCurveValue localRatingCurveValue = validationContext.ObjectInstance as LocalRatingCurveValue;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localRatingCurveValue.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localRatingCurveValue.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localRatingCurveValue.RatingCurveValueID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RatingCurveValueID"), new[] { nameof(localRatingCurveValue.RatingCurveValueID) });
                }

                if (!(from c in db.LocalRatingCurveValues.AsNoTracking() select c).Where(c => c.RatingCurveValueID == localRatingCurveValue.RatingCurveValueID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "RatingCurveValue", "RatingCurveValueID", localRatingCurveValue.RatingCurveValueID.ToString()), new[] { nameof(localRatingCurveValue.RatingCurveValueID) });
                }
            }

            LocalRatingCurve localRatingCurveRatingCurveID = null;
            localRatingCurveRatingCurveID = (from c in db.LocalRatingCurves.AsNoTracking() where c.RatingCurveID == localRatingCurveValue.RatingCurveID select c).FirstOrDefault();

            if (localRatingCurveRatingCurveID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalRatingCurve", "RatingCurveID", localRatingCurveValue.RatingCurveID.ToString()), new[] { nameof(localRatingCurveValue.RatingCurveID) });
            }

            if (localRatingCurveValue.StageValue_m < 0 || localRatingCurveValue.StageValue_m > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "StageValue_m", "0", "1000"), new[] { nameof(localRatingCurveValue.StageValue_m) });
            }

            if (localRatingCurveValue.DischargeValue_m3_s < 0 || localRatingCurveValue.DischargeValue_m3_s > 1000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DischargeValue_m3_s", "0", "1000000"), new[] { nameof(localRatingCurveValue.DischargeValue_m3_s) });
            }

            if (localRatingCurveValue.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localRatingCurveValue.LastUpdateDate_UTC) });
            }
            else
            {
                if (localRatingCurveValue.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localRatingCurveValue.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localRatingCurveValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localRatingCurveValue.LastUpdateContactTVItemID.ToString()), new[] { nameof(localRatingCurveValue.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localRatingCurveValue.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
