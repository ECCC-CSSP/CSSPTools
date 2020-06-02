/*
 * Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public interface IRatingCurveService
    {
       Task<ActionResult<RatingCurve>> GetRatingCurveWithRatingCurveID(int RatingCurveID);
       Task<ActionResult<List<RatingCurve>>> GetRatingCurveList();
       Task<ActionResult<RatingCurve>> Add(RatingCurve ratingcurve);
       Task<ActionResult<RatingCurve>> Delete(RatingCurve ratingcurve);
       Task<ActionResult<RatingCurve>> Update(RatingCurve ratingcurve);
       Task SetCulture(CultureInfo culture);
    }
    public partial class RatingCurveService : ControllerBase, IRatingCurveService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<RatingCurve>> GetRatingCurveWithRatingCurveID(int RatingCurveID)
        {
            RatingCurve ratingcurve = (from c in db.RatingCurves.AsNoTracking()
                    where c.RatingCurveID == RatingCurveID
                    select c).FirstOrDefault();

            if (ratingcurve == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(ratingcurve));
        }
        public async Task<ActionResult<List<RatingCurve>>> GetRatingCurveList()
        {
            List<RatingCurve> ratingcurveList = (from c in db.RatingCurves.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(ratingcurveList));
        }
        public async Task<ActionResult<RatingCurve>> Add(RatingCurve ratingCurve)
        {
            ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.RatingCurves.Add(ratingCurve);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(ratingCurve));
        }
        public async Task<ActionResult<RatingCurve>> Delete(RatingCurve ratingCurve)
        {
            ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Delete);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.RatingCurves.Remove(ratingCurve);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(ratingCurve));
        }
        public async Task<ActionResult<RatingCurve>> Update(RatingCurve ratingCurve)
        {
            ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.RatingCurves.Update(ratingCurve);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(ratingCurve));
        }
        public async Task SetCulture(CultureInfo culture)
        {
            CSSPServicesRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            RatingCurve ratingCurve = validationContext.ObjectInstance as RatingCurve;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (ratingCurve.RatingCurveID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RatingCurveID"), new[] { "RatingCurveID" });
                }

                if (!(from c in db.RatingCurves select c).Where(c => c.RatingCurveID == ratingCurve.RatingCurveID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveID", ratingCurve.RatingCurveID.ToString()), new[] { "RatingCurveID" });
                }
            }

            HydrometricSite HydrometricSiteHydrometricSiteID = (from c in db.HydrometricSites where c.HydrometricSiteID == ratingCurve.HydrometricSiteID select c).FirstOrDefault();

            if (HydrometricSiteHydrometricSiteID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteID", ratingCurve.HydrometricSiteID.ToString()), new[] { "HydrometricSiteID" });
            }

            if (string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RatingCurveNumber"), new[] { "RatingCurveNumber" });
            }

            if (!string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber) && ratingCurve.RatingCurveNumber.Length > 50)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "RatingCurveNumber", "50"), new[] { "RatingCurveNumber" });
            }

            if (ratingCurve.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (ratingCurve.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == ratingCurve.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", ratingCurve.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}
