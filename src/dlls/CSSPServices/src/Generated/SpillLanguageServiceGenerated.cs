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
   public interface ISpillLanguageService
    {
       Task<ActionResult<SpillLanguage>> GetSpillLanguageWithSpillLanguageID(int SpillLanguageID);
       Task<ActionResult<List<SpillLanguage>>> GetSpillLanguageList();
       Task<ActionResult<SpillLanguage>> Add(SpillLanguage spilllanguage);
       Task<ActionResult<SpillLanguage>> Delete(SpillLanguage spilllanguage);
       Task<ActionResult<SpillLanguage>> Update(SpillLanguage spilllanguage);
       Task SetCulture(CultureInfo culture);
    }
    public partial class SpillLanguageService : ControllerBase, ISpillLanguageService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<SpillLanguage>> GetSpillLanguageWithSpillLanguageID(int SpillLanguageID)
        {
            SpillLanguage spilllanguage = (from c in db.SpillLanguages.AsNoTracking()
                    where c.SpillLanguageID == SpillLanguageID
                    select c).FirstOrDefault();

            if (spilllanguage == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(spilllanguage));
        }
        public async Task<ActionResult<List<SpillLanguage>>> GetSpillLanguageList()
        {
            List<SpillLanguage> spilllanguageList = (from c in db.SpillLanguages.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(spilllanguageList));
        }
        public async Task<ActionResult<SpillLanguage>> Add(SpillLanguage spillLanguage)
        {
            ValidationResults = Validate(new ValidationContext(spillLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.SpillLanguages.Add(spillLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(spillLanguage));
        }
        public async Task<ActionResult<SpillLanguage>> Delete(SpillLanguage spillLanguage)
        {
            ValidationResults = Validate(new ValidationContext(spillLanguage), ActionDBTypeEnum.Delete);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.SpillLanguages.Remove(spillLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(spillLanguage));
        }
        public async Task<ActionResult<SpillLanguage>> Update(SpillLanguage spillLanguage)
        {
            ValidationResults = Validate(new ValidationContext(spillLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.SpillLanguages.Update(spillLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(spillLanguage));
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
            SpillLanguage spillLanguage = validationContext.ObjectInstance as SpillLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (spillLanguage.SpillLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SpillLanguageID"), new[] { "SpillLanguageID" });
                }

                if (!(from c in db.SpillLanguages select c).Where(c => c.SpillLanguageID == spillLanguage.SpillLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SpillLanguage", "SpillLanguageID", spillLanguage.SpillLanguageID.ToString()), new[] { "SpillLanguageID" });
                }
            }

            Spill SpillSpillID = (from c in db.Spills where c.SpillID == spillLanguage.SpillID select c).FirstOrDefault();

            if (SpillSpillID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", spillLanguage.SpillID.ToString()), new[] { "SpillID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)spillLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(spillLanguage.SpillComment))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SpillComment"), new[] { "SpillComment" });
            }

            //SpillComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)spillLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TranslationStatus"), new[] { "TranslationStatus" });
            }

            if (spillLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (spillLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == spillLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", spillLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
