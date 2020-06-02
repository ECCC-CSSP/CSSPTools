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
   public interface IEmailDistributionListLanguageService
    {
       Task<ActionResult<EmailDistributionListLanguage>> GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(int EmailDistributionListLanguageID);
       Task<ActionResult<List<EmailDistributionListLanguage>>> GetEmailDistributionListLanguageList();
       Task<ActionResult<EmailDistributionListLanguage>> Add(EmailDistributionListLanguage emaildistributionlistlanguage);
       Task<ActionResult<EmailDistributionListLanguage>> Delete(EmailDistributionListLanguage emaildistributionlistlanguage);
       Task<ActionResult<EmailDistributionListLanguage>> Update(EmailDistributionListLanguage emaildistributionlistlanguage);
       Task SetCulture(CultureInfo culture);
    }
    public partial class EmailDistributionListLanguageService : ControllerBase, IEmailDistributionListLanguageService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListLanguageService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<EmailDistributionListLanguage>> GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(int EmailDistributionListLanguageID)
        {
            EmailDistributionListLanguage emaildistributionlistlanguage = (from c in db.EmailDistributionListLanguages.AsNoTracking()
                    where c.EmailDistributionListLanguageID == EmailDistributionListLanguageID
                    select c).FirstOrDefault();

            if (emaildistributionlistlanguage == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(emaildistributionlistlanguage));
        }
        public async Task<ActionResult<List<EmailDistributionListLanguage>>> GetEmailDistributionListLanguageList()
        {
            List<EmailDistributionListLanguage> emaildistributionlistlanguageList = (from c in db.EmailDistributionListLanguages.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(emaildistributionlistlanguageList));
        }
        public async Task<ActionResult<EmailDistributionListLanguage>> Add(EmailDistributionListLanguage emailDistributionListLanguage)
        {
            ValidationResults = Validate(new ValidationContext(emailDistributionListLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.EmailDistributionListLanguages.Add(emailDistributionListLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(emailDistributionListLanguage));
        }
        public async Task<ActionResult<EmailDistributionListLanguage>> Delete(EmailDistributionListLanguage emailDistributionListLanguage)
        {
            ValidationResults = Validate(new ValidationContext(emailDistributionListLanguage), ActionDBTypeEnum.Delete);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.EmailDistributionListLanguages.Remove(emailDistributionListLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(emailDistributionListLanguage));
        }
        public async Task<ActionResult<EmailDistributionListLanguage>> Update(EmailDistributionListLanguage emailDistributionListLanguage)
        {
            ValidationResults = Validate(new ValidationContext(emailDistributionListLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.EmailDistributionListLanguages.Update(emailDistributionListLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(emailDistributionListLanguage));
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
            EmailDistributionListLanguage emailDistributionListLanguage = validationContext.ObjectInstance as EmailDistributionListLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (emailDistributionListLanguage.EmailDistributionListLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListLanguageID"), new[] { "EmailDistributionListLanguageID" });
                }

                if (!(from c in db.EmailDistributionListLanguages select c).Where(c => c.EmailDistributionListLanguageID == emailDistributionListLanguage.EmailDistributionListLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListLanguage", "EmailDistributionListLanguageID", emailDistributionListLanguage.EmailDistributionListLanguageID.ToString()), new[] { "EmailDistributionListLanguageID" });
                }
            }

            EmailDistributionList EmailDistributionListEmailDistributionListID = (from c in db.EmailDistributionLists where c.EmailDistributionListID == emailDistributionListLanguage.EmailDistributionListID select c).FirstOrDefault();

            if (EmailDistributionListEmailDistributionListID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListID", emailDistributionListLanguage.EmailDistributionListID.ToString()), new[] { "EmailDistributionListID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)emailDistributionListLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListLanguage.EmailListName))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailListName"), new[] { "EmailListName" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListLanguage.EmailListName) && (emailDistributionListLanguage.EmailListName.Length < 1 || emailDistributionListLanguage.EmailListName.Length > 100))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "EmailListName", "1", "100"), new[] { "EmailListName" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)emailDistributionListLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TranslationStatus"), new[] { "TranslationStatus" });
            }

            if (emailDistributionListLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (emailDistributionListLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionListLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", emailDistributionListLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
