/*
 * Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public interface IRatingCurveService
    {
       Task<ActionResult<bool>> Delete(int RatingCurveID);
       Task<ActionResult<List<RatingCurve>>> GetRatingCurveList();
       Task<ActionResult<RatingCurve>> GetRatingCurveWithRatingCurveID(int RatingCurveID);
       Task<ActionResult<RatingCurve>> Post(RatingCurve ratingcurve);
       Task<ActionResult<RatingCurve>> Put(RatingCurve ratingcurve);
    }
    public partial class RatingCurveService : ControllerBase, IRatingCurveService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<RatingCurve>> GetRatingCurveWithRatingCurveID(int RatingCurveID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                RatingCurve ratingcurve = (from c in dbLocal.RatingCurves.AsNoTracking()
                        where c.RatingCurveID == RatingCurveID
                        select c).FirstOrDefault();

                if (ratingcurve == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(ratingcurve));
            }
            else
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
        }
        public async Task<ActionResult<List<RatingCurve>>> GetRatingCurveList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                List<RatingCurve> ratingcurveList = (from c in dbLocal.RatingCurves.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(ratingcurveList));
            }
            else
            {
                List<RatingCurve> ratingcurveList = (from c in db.RatingCurves.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(ratingcurveList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int RatingCurveID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                RatingCurve ratingCurve = (from c in dbLocal.RatingCurves
                                   where c.RatingCurveID == RatingCurveID
                                   select c).FirstOrDefault();
                
                if (ratingCurve == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveID", RatingCurveID.ToString())));
                }

                try
                {
                   dbLocal.RatingCurves.Remove(ratingCurve);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
            else
            {
                RatingCurve ratingCurve = (from c in db.RatingCurves
                                   where c.RatingCurveID == RatingCurveID
                                   select c).FirstOrDefault();
                
                if (ratingCurve == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveID", RatingCurveID.ToString())));
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

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<RatingCurve>> Post(RatingCurve ratingCurve)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
                try
                {
                   dbLocal.RatingCurves.Add(ratingCurve);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(ratingCurve));
            }
            else
            {
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
        }
        public async Task<ActionResult<RatingCurve>> Put(RatingCurve ratingCurve)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
            try
            {
               dbLocal.RatingCurves.Update(ratingCurve);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(ratingCurve));
            }
            else
            {
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
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "RatingCurveID"), new[] { "RatingCurveID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.RatingCurves select c).Where(c => c.RatingCurveID == ratingCurve.RatingCurveID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveID", ratingCurve.RatingCurveID.ToString()), new[] { "RatingCurveID" });
                    }
                }
                else
                {
                    if (!(from c in db.RatingCurves select c).Where(c => c.RatingCurveID == ratingCurve.RatingCurveID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveID", ratingCurve.RatingCurveID.ToString()), new[] { "RatingCurveID" });
                    }
                }
            }

            HydrometricSite HydrometricSiteHydrometricSiteID = null;
            if (LoggedInService.IsLocal)
            {
                HydrometricSiteHydrometricSiteID = (from c in dbLocal.HydrometricSites where c.HydrometricSiteID == ratingCurve.HydrometricSiteID select c).FirstOrDefault();
                if (HydrometricSiteHydrometricSiteID == null)
                {
                    HydrometricSiteHydrometricSiteID = (from c in dbIM.HydrometricSites where c.HydrometricSiteID == ratingCurve.HydrometricSiteID select c).FirstOrDefault();
                }
            }
            else
            {
                HydrometricSiteHydrometricSiteID = (from c in db.HydrometricSites where c.HydrometricSiteID == ratingCurve.HydrometricSiteID select c).FirstOrDefault();
            }

            if (HydrometricSiteHydrometricSiteID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteID", ratingCurve.HydrometricSiteID.ToString()), new[] { "HydrometricSiteID" });
            }

            if (string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "RatingCurveNumber"), new[] { "RatingCurveNumber" });
            }

            if (!string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber) && ratingCurve.RatingCurveNumber.Length > 50)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "RatingCurveNumber", "50"), new[] { "RatingCurveNumber" });
            }

            if (ratingCurve.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (ratingCurve.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == ratingCurve.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == ratingCurve.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == ratingCurve.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", ratingCurve.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
