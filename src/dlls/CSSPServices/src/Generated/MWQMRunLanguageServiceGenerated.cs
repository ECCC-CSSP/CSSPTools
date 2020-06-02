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
   public interface IMWQMRunLanguageService
    {
       Task<ActionResult<MWQMRunLanguage>> GetMWQMRunLanguageWithMWQMRunLanguageID(int MWQMRunLanguageID);
       Task<ActionResult<List<MWQMRunLanguage>>> GetMWQMRunLanguageList();
       Task<ActionResult<MWQMRunLanguage>> Add(MWQMRunLanguage mwqmrunlanguage);
       Task<ActionResult<MWQMRunLanguage>> Delete(MWQMRunLanguage mwqmrunlanguage);
       Task<ActionResult<MWQMRunLanguage>> Update(MWQMRunLanguage mwqmrunlanguage);
       Task SetCulture(CultureInfo culture);
    }
    public partial class MWQMRunLanguageService : ControllerBase, IMWQMRunLanguageService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MWQMRunLanguage>> GetMWQMRunLanguageWithMWQMRunLanguageID(int MWQMRunLanguageID)
        {
            MWQMRunLanguage mwqmrunlanguage = (from c in db.MWQMRunLanguages.AsNoTracking()
                    where c.MWQMRunLanguageID == MWQMRunLanguageID
                    select c).FirstOrDefault();

            if (mwqmrunlanguage == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(mwqmrunlanguage));
        }
        public async Task<ActionResult<List<MWQMRunLanguage>>> GetMWQMRunLanguageList()
        {
            List<MWQMRunLanguage> mwqmrunlanguageList = (from c in db.MWQMRunLanguages.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(mwqmrunlanguageList));
        }
        public async Task<ActionResult<MWQMRunLanguage>> Add(MWQMRunLanguage mwqmRunLanguage)
        {
            ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.MWQMRunLanguages.Add(mwqmRunLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmRunLanguage));
        }
        public async Task<ActionResult<MWQMRunLanguage>> Delete(MWQMRunLanguage mwqmRunLanguage)
        {
            ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Delete);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.MWQMRunLanguages.Remove(mwqmRunLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmRunLanguage));
        }
        public async Task<ActionResult<MWQMRunLanguage>> Update(MWQMRunLanguage mwqmRunLanguage)
        {
            ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.MWQMRunLanguages.Update(mwqmRunLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmRunLanguage));
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
            MWQMRunLanguage mwqmRunLanguage = validationContext.ObjectInstance as MWQMRunLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmRunLanguage.MWQMRunLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageID"), new[] { "MWQMRunLanguageID" });
                }

                if (!(from c in db.MWQMRunLanguages select c).Where(c => c.MWQMRunLanguageID == mwqmRunLanguage.MWQMRunLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageID", mwqmRunLanguage.MWQMRunLanguageID.ToString()), new[] { "MWQMRunLanguageID" });
                }
            }

            MWQMRun MWQMRunMWQMRunID = (from c in db.MWQMRuns where c.MWQMRunID == mwqmRunLanguage.MWQMRunID select c).FirstOrDefault();

            if (MWQMRunMWQMRunID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunID", mwqmRunLanguage.MWQMRunID.ToString()), new[] { "MWQMRunID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)mwqmRunLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunComment))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RunComment"), new[] { "RunComment" });
            }

            //RunComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunComment);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TranslationStatusRunComment"), new[] { "TranslationStatusRunComment" });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunWeatherComment))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RunWeatherComment"), new[] { "RunWeatherComment" });
            }

            //RunWeatherComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunWeatherComment);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TranslationStatusRunWeatherComment"), new[] { "TranslationStatusRunWeatherComment" });
            }

            if (mwqmRunLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmRunLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRunLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmRunLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
