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
   public interface ITideSiteService
    {
       Task<ActionResult<TideSite>> GetTideSiteWithTideSiteID(int TideSiteID);
       Task<ActionResult<List<TideSite>>> GetTideSiteList();
       Task<ActionResult<TideSite>> Add(TideSite tidesite);
       Task<ActionResult<TideSite>> Delete(TideSite tidesite);
       Task<ActionResult<TideSite>> Update(TideSite tidesite);
       Task SetCulture(CultureInfo culture);
    }
    public partial class TideSiteService : ControllerBase, ITideSiteService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public TideSiteService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<TideSite>> GetTideSiteWithTideSiteID(int TideSiteID)
        {
            TideSite tidesite = (from c in db.TideSites.AsNoTracking()
                    where c.TideSiteID == TideSiteID
                    select c).FirstOrDefault();

            if (tidesite == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(tidesite));
        }
        public async Task<ActionResult<List<TideSite>>> GetTideSiteList()
        {
            List<TideSite> tidesiteList = (from c in db.TideSites.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(tidesiteList));
        }
        public async Task<ActionResult<TideSite>> Add(TideSite tideSite)
        {
            tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Create);
            if (tideSite.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(tideSite.ValidationResults));
            }

            try
            {
               db.TideSites.Add(tideSite);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tideSite));
        }
        public async Task<ActionResult<TideSite>> Delete(TideSite tideSite)
        {
            tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Delete);
            if (tideSite.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(tideSite.ValidationResults));
            }

            try
            {
               db.TideSites.Remove(tideSite);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tideSite));
        }
        public async Task<ActionResult<TideSite>> Update(TideSite tideSite)
        {
            tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Update);
            if (tideSite.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(tideSite.ValidationResults));
            }

            try
            {
               db.TideSites.Update(tideSite);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tideSite));
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
            TideSite tideSite = validationContext.ObjectInstance as TideSite;
            tideSite.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tideSite.TideSiteID == 0)
                {
                    tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideSiteID"), new[] { "TideSiteID" });
                }

                if (!(from c in db.TideSites select c).Where(c => c.TideSiteID == tideSite.TideSiteID).Any())
                {
                    tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteID", tideSite.TideSiteID.ToString()), new[] { "TideSiteID" });
                }
            }

            TVItem TVItemTideSiteTVItemID = (from c in db.TVItems where c.TVItemID == tideSite.TideSiteTVItemID select c).FirstOrDefault();

            if (TVItemTideSiteTVItemID == null)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TideSiteTVItemID", tideSite.TideSiteTVItemID.ToString()), new[] { "TideSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.TideSite,
                };
                if (!AllowableTVTypes.Contains(TVItemTideSiteTVItemID.TVType))
                {
                    tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TideSiteTVItemID", "TideSite"), new[] { "TideSiteTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(tideSite.TideSiteName))
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideSiteName"), new[] { "TideSiteName" });
            }

            if (!string.IsNullOrWhiteSpace(tideSite.TideSiteName) && tideSite.TideSiteName.Length > 100)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TideSiteName", "100"), new[] { "TideSiteName" });
            }

            if (string.IsNullOrWhiteSpace(tideSite.Province))
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Province"), new[] { "Province" });
            }

            if (!string.IsNullOrWhiteSpace(tideSite.Province) && (tideSite.Province.Length < 2 || tideSite.Province.Length > 2))
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "Province", "2", "2"), new[] { "Province" });
            }

            if (tideSite.sid < 0 || tideSite.sid > 10000)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "sid", "0", "10000"), new[] { "sid" });
            }

            if (tideSite.Zone < 0 || tideSite.Zone > 10000)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Zone", "0", "10000"), new[] { "Zone" });
            }

            if (tideSite.LastUpdateDate_UTC.Year == 1)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tideSite.LastUpdateDate_UTC.Year < 1980)
                {
                tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tideSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tideSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}
