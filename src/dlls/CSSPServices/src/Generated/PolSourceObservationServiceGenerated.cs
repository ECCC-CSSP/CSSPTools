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
   public interface IPolSourceObservationService
    {
       Task<ActionResult<PolSourceObservation>> GetPolSourceObservationWithPolSourceObservationID(int PolSourceObservationID);
       Task<ActionResult<List<PolSourceObservation>>> GetPolSourceObservationList();
       Task<ActionResult<PolSourceObservation>> Add(PolSourceObservation polsourceobservation);
       Task<ActionResult<PolSourceObservation>> Delete(PolSourceObservation polsourceobservation);
       Task<ActionResult<PolSourceObservation>> Update(PolSourceObservation polsourceobservation);
       Task SetCulture(CultureInfo culture);
    }
    public partial class PolSourceObservationService : ControllerBase, IPolSourceObservationService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<PolSourceObservation>> GetPolSourceObservationWithPolSourceObservationID(int PolSourceObservationID)
        {
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
            List<PolSourceObservation> polsourceobservationList = (from c in db.PolSourceObservations.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(polsourceobservationList));
        }
        public async Task<ActionResult<PolSourceObservation>> Add(PolSourceObservation polSourceObservation)
        {
            polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Create);
            if (polSourceObservation.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(polSourceObservation.ValidationResults));
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
        public async Task<ActionResult<PolSourceObservation>> Delete(PolSourceObservation polSourceObservation)
        {
            polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Delete);
            if (polSourceObservation.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(polSourceObservation.ValidationResults));
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

            return await Task.FromResult(Ok(polSourceObservation));
        }
        public async Task<ActionResult<PolSourceObservation>> Update(PolSourceObservation polSourceObservation)
        {
            polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Update);
            if (polSourceObservation.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(polSourceObservation.ValidationResults));
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
        public async Task SetCulture(CultureInfo culture)
        {
            CSSPServicesRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            PolSourceObservation polSourceObservation = validationContext.ObjectInstance as PolSourceObservation;
            polSourceObservation.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceObservation.PolSourceObservationID == 0)
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationID"), new[] { "PolSourceObservationID" });
                }

                if (!(from c in db.PolSourceObservations select c).Where(c => c.PolSourceObservationID == polSourceObservation.PolSourceObservationID).Any())
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationID", polSourceObservation.PolSourceObservationID.ToString()), new[] { "PolSourceObservationID" });
                }
            }

            PolSourceSite PolSourceSitePolSourceSiteID = (from c in db.PolSourceSites where c.PolSourceSiteID == polSourceObservation.PolSourceSiteID select c).FirstOrDefault();

            if (PolSourceSitePolSourceSiteID == null)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", polSourceObservation.PolSourceSiteID.ToString()), new[] { "PolSourceSiteID" });
            }

            if (polSourceObservation.ObservationDate_Local.Year == 1)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ObservationDate_Local"), new[] { "ObservationDate_Local" });
            }
            else
            {
                if (polSourceObservation.ObservationDate_Local.Year < 1980)
                {
                polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ObservationDate_Local", "1980"), new[] { "ObservationDate_Local" });
                }
            }

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservation.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactTVItemID", polSourceObservation.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ContactTVItemID", "Contact"), new[] { "ContactTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(polSourceObservation.Observation_ToBeDeleted))
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Observation_ToBeDeleted"), new[] { "Observation_ToBeDeleted" });
            }

            //Observation_ToBeDeleted has no StringLength Attribute

            if (polSourceObservation.LastUpdateDate_UTC.Year == 1)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (polSourceObservation.LastUpdateDate_UTC.Year < 1980)
                {
                polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservation.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceObservation.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}