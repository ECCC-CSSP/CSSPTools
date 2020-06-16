/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
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
   public interface IPolSourceObservationService
    {
       Task<ActionResult<bool>> Delete(int PolSourceObservationID);
       Task<ActionResult<List<PolSourceObservation>>> GetPolSourceObservationList();
       Task<ActionResult<PolSourceObservation>> GetPolSourceObservationWithPolSourceObservationID(int PolSourceObservationID);
       Task<ActionResult<PolSourceObservation>> Post(PolSourceObservation polsourceobservation);
       Task<ActionResult<PolSourceObservation>> Put(PolSourceObservation polsourceobservation);
    }
    public partial class PolSourceObservationService : ControllerBase, IPolSourceObservationService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<PolSourceObservation>> GetPolSourceObservationWithPolSourceObservationID(int PolSourceObservationID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            PolSourceObservation polsourceobservation = (from c in db.PolSourceObservations.AsNoTracking()
                    where c.PolSourceObservationID == PolSourceObservationID
                    select c).FirstOrDefault();

            if (polsourceobservation == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(polsourceobservation));
        }
        public async Task<ActionResult<List<PolSourceObservation>>> GetPolSourceObservationList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            List<PolSourceObservation> polsourceobservationList = (from c in db.PolSourceObservations.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(polsourceobservationList));
        }
        public async Task<ActionResult<bool>> Delete(int PolSourceObservationID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            PolSourceObservation polSourceObservation = (from c in db.PolSourceObservations
                               where c.PolSourceObservationID == PolSourceObservationID
                               select c).FirstOrDefault();
            
            if (polSourceObservation == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationID", PolSourceObservationID.ToString())));
            }

            try
            {
               db.PolSourceObservations.Remove(polSourceObservation);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<PolSourceObservation>> Post(PolSourceObservation polSourceObservation)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.PolSourceObservations.Add(polSourceObservation);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceObservation));
        }
        public async Task<ActionResult<PolSourceObservation>> Put(PolSourceObservation polSourceObservation)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.PolSourceObservations.Update(polSourceObservation);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceObservation));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            PolSourceObservation polSourceObservation = validationContext.ObjectInstance as PolSourceObservation;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceObservation.PolSourceObservationID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "PolSourceObservationID"), new[] { "PolSourceObservationID" });
                }

                if (!(from c in db.PolSourceObservations select c).Where(c => c.PolSourceObservationID == polSourceObservation.PolSourceObservationID).Any())
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationID", polSourceObservation.PolSourceObservationID.ToString()), new[] { "PolSourceObservationID" });
                }
            }

            PolSourceSite PolSourceSitePolSourceSiteID = (from c in db.PolSourceSites where c.PolSourceSiteID == polSourceObservation.PolSourceSiteID select c).FirstOrDefault();

            if (PolSourceSitePolSourceSiteID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", polSourceObservation.PolSourceSiteID.ToString()), new[] { "PolSourceSiteID" });
            }

            if (polSourceObservation.ObservationDate_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "ObservationDate_Local"), new[] { "ObservationDate_Local" });
            }
            else
            {
                if (polSourceObservation.ObservationDate_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "ObservationDate_Local", "1980"), new[] { "ObservationDate_Local" });
                }
            }

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservation.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactTVItemID", polSourceObservation.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "ContactTVItemID", "Contact"), new[] { "ContactTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(polSourceObservation.Observation_ToBeDeleted))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "Observation_ToBeDeleted"), new[] { "Observation_ToBeDeleted" });
            }

            //Observation_ToBeDeleted has no StringLength Attribute

            if (polSourceObservation.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (polSourceObservation.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservation.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceObservation.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
