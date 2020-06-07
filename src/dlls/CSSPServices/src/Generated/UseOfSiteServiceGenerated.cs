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
   public interface IUseOfSiteService
    {
       Task<ActionResult<UseOfSite>> GetUseOfSiteWithUseOfSiteID(int UseOfSiteID);
       Task<ActionResult<List<UseOfSite>>> GetUseOfSiteList();
       Task<ActionResult<UseOfSite>> Add(UseOfSite useofsite);
       Task<ActionResult<bool>> Delete(int UseOfSiteID);
       Task<ActionResult<UseOfSite>> Update(UseOfSite useofsite);
       Task SetCulture(CultureInfo culture);
    }
    public partial class UseOfSiteService : ControllerBase, IUseOfSiteService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public UseOfSiteService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<UseOfSite>> GetUseOfSiteWithUseOfSiteID(int UseOfSiteID)
        {
            UseOfSite useofsite = (from c in db.UseOfSites.AsNoTracking()
                    where c.UseOfSiteID == UseOfSiteID
                    select c).FirstOrDefault();

            if (useofsite == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(useofsite));
        }
        public async Task<ActionResult<List<UseOfSite>>> GetUseOfSiteList()
        {
            List<UseOfSite> useofsiteList = (from c in db.UseOfSites.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(useofsiteList));
        }
        public async Task<ActionResult<UseOfSite>> Add(UseOfSite useOfSite)
        {
            ValidationResults = Validate(new ValidationContext(useOfSite), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.UseOfSites.Add(useOfSite);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(useOfSite));
        }
        public async Task<ActionResult<bool>> Delete(int UseOfSiteID)
        {
            UseOfSite useOfSite = (from c in db.UseOfSites
                               where c.UseOfSiteID == UseOfSiteID
                               select c).FirstOrDefault();
            
            if (useOfSite == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "UseOfSite", "UseOfSiteID", UseOfSiteID.ToString())));
            }

            try
            {
               db.UseOfSites.Remove(useOfSite);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<UseOfSite>> Update(UseOfSite useOfSite)
        {
            ValidationResults = Validate(new ValidationContext(useOfSite), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.UseOfSites.Update(useOfSite);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(useOfSite));
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
            UseOfSite useOfSite = validationContext.ObjectInstance as UseOfSite;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (useOfSite.UseOfSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "UseOfSiteID"), new[] { "UseOfSiteID" });
                }

                if (!(from c in db.UseOfSites select c).Where(c => c.UseOfSiteID == useOfSite.UseOfSiteID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "UseOfSite", "UseOfSiteID", useOfSite.UseOfSiteID.ToString()), new[] { "UseOfSiteID" });
                }
            }

            TVItem TVItemSiteTVItemID = (from c in db.TVItems where c.TVItemID == useOfSite.SiteTVItemID select c).FirstOrDefault();

            if (TVItemSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SiteTVItemID", useOfSite.SiteTVItemID.ToString()), new[] { "SiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.TideSite,
                };
                if (!AllowableTVTypes.Contains(TVItemSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SiteTVItemID", "ClimateSite,HydrometricSite,TideSite"), new[] { "SiteTVItemID" });
                }
            }

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == useOfSite.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SubsectorTVItemID", useOfSite.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)useOfSite.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            if (useOfSite.Ordinal < 0 || useOfSite.Ordinal > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), new[] { "Ordinal" });
            }

            if (useOfSite.StartYear < 1980 || useOfSite.StartYear > 2050)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "StartYear", "1980", "2050"), new[] { "StartYear" });
            }

            if (useOfSite.EndYear != null)
            {
                if (useOfSite.EndYear < 1980 || useOfSite.EndYear > 2050)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "EndYear", "1980", "2050"), new[] { "EndYear" });
                }
            }

            if (useOfSite.Weight_perc != null)
            {
                if (useOfSite.Weight_perc < 0 || useOfSite.Weight_perc > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Weight_perc", "0", "100"), new[] { "Weight_perc" });
                }
            }

            if (useOfSite.Param1 != null)
            {
                if (useOfSite.Param1 < 0 || useOfSite.Param1 > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Param1", "0", "100"), new[] { "Param1" });
                }
            }

            if (useOfSite.Param2 != null)
            {
                if (useOfSite.Param2 < 0 || useOfSite.Param2 > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Param2", "0", "100"), new[] { "Param2" });
                }
            }

            if (useOfSite.Param3 != null)
            {
                if (useOfSite.Param3 < 0 || useOfSite.Param3 > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Param3", "0", "100"), new[] { "Param3" });
                }
            }

            if (useOfSite.Param4 != null)
            {
                if (useOfSite.Param4 < 0 || useOfSite.Param4 > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Param4", "0", "100"), new[] { "Param4" });
                }
            }

            if (useOfSite.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (useOfSite.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == useOfSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", useOfSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
