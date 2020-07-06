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
   public interface ITideLocationService
    {
       Task<ActionResult<bool>> Delete(int TideLocationID);
       Task<ActionResult<List<TideLocation>>> GetTideLocationList();
       Task<ActionResult<TideLocation>> GetTideLocationWithTideLocationID(int TideLocationID);
       Task<ActionResult<TideLocation>> Post(TideLocation tidelocation);
       Task<ActionResult<TideLocation>> Put(TideLocation tidelocation);
    }
    public partial class TideLocationService : ControllerBase, ITideLocationService
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
        public TideLocationService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<TideLocation>> GetTideLocationWithTideLocationID(int TideLocationID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                TideLocation tidelocation = (from c in dbLocal.TideLocations.AsNoTracking()
                        where c.TideLocationID == TideLocationID
                        select c).FirstOrDefault();

                if (tidelocation == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tidelocation));
            }
            else
            {
                TideLocation tidelocation = (from c in db.TideLocations.AsNoTracking()
                        where c.TideLocationID == TideLocationID
                        select c).FirstOrDefault();

                if (tidelocation == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tidelocation));
            }
        }
        public async Task<ActionResult<List<TideLocation>>> GetTideLocationList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                List<TideLocation> tidelocationList = (from c in dbLocal.TideLocations.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(tidelocationList));
            }
            else
            {
                List<TideLocation> tidelocationList = (from c in db.TideLocations.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(tidelocationList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int TideLocationID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                TideLocation tideLocation = (from c in dbLocal.TideLocations
                                   where c.TideLocationID == TideLocationID
                                   select c).FirstOrDefault();
                
                if (tideLocation == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TideLocation", "TideLocationID", TideLocationID.ToString())));
                }

                try
                {
                   dbLocal.TideLocations.Remove(tideLocation);
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
                TideLocation tideLocation = (from c in db.TideLocations
                                   where c.TideLocationID == TideLocationID
                                   select c).FirstOrDefault();
                
                if (tideLocation == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TideLocation", "TideLocationID", TideLocationID.ToString())));
                }

                try
                {
                   db.TideLocations.Remove(tideLocation);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<TideLocation>> Post(TideLocation tideLocation)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tideLocation), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
                try
                {
                   dbLocal.TideLocations.Add(tideLocation);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tideLocation));
            }
            else
            {
                try
                {
                   db.TideLocations.Add(tideLocation);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tideLocation));
            }
        }
        public async Task<ActionResult<TideLocation>> Put(TideLocation tideLocation)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tideLocation), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
            try
            {
               dbLocal.TideLocations.Update(tideLocation);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tideLocation));
            }
            else
            {
            try
            {
               db.TideLocations.Update(tideLocation);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tideLocation));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TideLocation tideLocation = validationContext.ObjectInstance as TideLocation;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tideLocation.TideLocationID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TideLocationID"), new[] { "TideLocationID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.TideLocations select c).Where(c => c.TideLocationID == tideLocation.TideLocationID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TideLocation", "TideLocationID", tideLocation.TideLocationID.ToString()), new[] { "TideLocationID" });
                    }
                }
                else
                {
                    if (!(from c in db.TideLocations select c).Where(c => c.TideLocationID == tideLocation.TideLocationID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TideLocation", "TideLocationID", tideLocation.TideLocationID.ToString()), new[] { "TideLocationID" });
                    }
                }
            }

            if (tideLocation.Zone < 0 || tideLocation.Zone > 10000)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Zone", "0", "10000"), new[] { "Zone" });
            }

            if (string.IsNullOrWhiteSpace(tideLocation.Name))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "Name"), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(tideLocation.Name) && tideLocation.Name.Length > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "Name", "100"), new[] { "Name" });
            }

            if (string.IsNullOrWhiteSpace(tideLocation.Prov))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "Prov"), new[] { "Prov" });
            }

            if (!string.IsNullOrWhiteSpace(tideLocation.Prov) && tideLocation.Prov.Length > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "Prov", "100"), new[] { "Prov" });
            }

            if (tideLocation.sid < 0 || tideLocation.sid > 100000)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "sid", "0", "100000"), new[] { "sid" });
            }

            if (tideLocation.Lat < -90 || tideLocation.Lat > 90)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Lat", "-90", "90"), new[] { "Lat" });
            }

            if (tideLocation.Lng < -180 || tideLocation.Lng > 180)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Lng", "-180", "180"), new[] { "Lng" });
            }

            if (tideLocation.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tideLocation.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tideLocation.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == tideLocation.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tideLocation.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tideLocation.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
