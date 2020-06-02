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
   public interface IMikeSourceService
    {
       Task<ActionResult<MikeSource>> GetMikeSourceWithMikeSourceID(int MikeSourceID);
       Task<ActionResult<List<MikeSource>>> GetMikeSourceList();
       Task<ActionResult<MikeSource>> Add(MikeSource mikesource);
       Task<ActionResult<MikeSource>> Delete(MikeSource mikesource);
       Task<ActionResult<MikeSource>> Update(MikeSource mikesource);
       Task SetCulture(CultureInfo culture);
    }
    public partial class MikeSourceService : ControllerBase, IMikeSourceService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MikeSource>> GetMikeSourceWithMikeSourceID(int MikeSourceID)
        {
            MikeSource mikesource = (from c in db.MikeSources.AsNoTracking()
                    where c.MikeSourceID == MikeSourceID
                    select c).FirstOrDefault();

            if (mikesource == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(mikesource));
        }
        public async Task<ActionResult<List<MikeSource>>> GetMikeSourceList()
        {
            List<MikeSource> mikesourceList = (from c in db.MikeSources.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(mikesourceList));
        }
        public async Task<ActionResult<MikeSource>> Add(MikeSource mikeSource)
        {
            ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.MikeSources.Add(mikeSource);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeSource));
        }
        public async Task<ActionResult<MikeSource>> Delete(MikeSource mikeSource)
        {
            ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Delete);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.MikeSources.Remove(mikeSource);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeSource));
        }
        public async Task<ActionResult<MikeSource>> Update(MikeSource mikeSource)
        {
            ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.MikeSources.Update(mikeSource);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeSource));
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
            MikeSource mikeSource = validationContext.ObjectInstance as MikeSource;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeSource.MikeSourceID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeSourceID"), new[] { "MikeSourceID" });
                }

                if (!(from c in db.MikeSources select c).Where(c => c.MikeSourceID == mikeSource.MikeSourceID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceID", mikeSource.MikeSourceID.ToString()), new[] { "MikeSourceID" });
                }
            }

            TVItem TVItemMikeSourceTVItemID = (from c in db.TVItems where c.TVItemID == mikeSource.MikeSourceTVItemID select c).FirstOrDefault();

            if (TVItemMikeSourceTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeSourceTVItemID", mikeSource.MikeSourceTVItemID.ToString()), new[] { "MikeSourceTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeSource,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeSourceTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MikeSourceTVItemID", "MikeSource"), new[] { "MikeSourceTVItemID" });
                }
            }

            if (mikeSource.HydrometricTVItemID != null)
            {
                TVItem TVItemHydrometricTVItemID = (from c in db.TVItems where c.TVItemID == mikeSource.HydrometricTVItemID select c).FirstOrDefault();

                if (TVItemHydrometricTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "HydrometricTVItemID", (mikeSource.HydrometricTVItemID == null ? "" : mikeSource.HydrometricTVItemID.ToString())), new[] { "HydrometricTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.HydrometricSite,
                    };
                    if (!AllowableTVTypes.Contains(TVItemHydrometricTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "HydrometricTVItemID", "HydrometricSite"), new[] { "HydrometricTVItemID" });
                    }
                }
            }

            if (mikeSource.DrainageArea_km2 != null)
            {
                if (mikeSource.DrainageArea_km2 < 0 || mikeSource.DrainageArea_km2 > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DrainageArea_km2", "0", "1000000"), new[] { "DrainageArea_km2" });
                }
            }

            if (mikeSource.Factor != null)
            {
                if (mikeSource.Factor < 0 || mikeSource.Factor > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Factor", "0", "1000000"), new[] { "Factor" });
                }
            }

            if (string.IsNullOrWhiteSpace(mikeSource.SourceNumberString))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SourceNumberString"), new[] { "SourceNumberString" });
            }

            if (!string.IsNullOrWhiteSpace(mikeSource.SourceNumberString) && mikeSource.SourceNumberString.Length > 50)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "SourceNumberString", "50"), new[] { "SourceNumberString" });
            }

            if (mikeSource.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeSource.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeSource.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeSource.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
