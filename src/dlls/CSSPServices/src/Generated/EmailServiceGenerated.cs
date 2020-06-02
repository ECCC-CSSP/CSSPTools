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
   public interface IEmailService
    {
       Task<ActionResult<Email>> GetEmailWithEmailID(int EmailID);
       Task<ActionResult<List<Email>>> GetEmailList();
       Task<ActionResult<Email>> Add(Email email);
       Task<ActionResult<Email>> Delete(Email email);
       Task<ActionResult<Email>> Update(Email email);
       Task SetCulture(CultureInfo culture);
    }
    public partial class EmailService : ControllerBase, IEmailService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public EmailService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<Email>> GetEmailWithEmailID(int EmailID)
        {
            Email email = (from c in db.Emails.AsNoTracking()
                    where c.EmailID == EmailID
                    select c).FirstOrDefault();

            if (email == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(email));
        }
        public async Task<ActionResult<List<Email>>> GetEmailList()
        {
            List<Email> emailList = (from c in db.Emails.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(emailList));
        }
        public async Task<ActionResult<Email>> Add(Email email)
        {
            ValidationResults = Validate(new ValidationContext(email), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.Emails.Add(email);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(email));
        }
        public async Task<ActionResult<Email>> Delete(Email email)
        {
            ValidationResults = Validate(new ValidationContext(email), ActionDBTypeEnum.Delete);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.Emails.Remove(email);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(email));
        }
        public async Task<ActionResult<Email>> Update(Email email)
        {
            ValidationResults = Validate(new ValidationContext(email), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.Emails.Update(email);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(email));
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
            Email email = validationContext.ObjectInstance as Email;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (email.EmailID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailID"), new[] { "EmailID" });
                }

                if (!(from c in db.Emails select c).Where(c => c.EmailID == email.EmailID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Email", "EmailID", email.EmailID.ToString()), new[] { "EmailID" });
                }
            }

            TVItem TVItemEmailTVItemID = (from c in db.TVItems where c.TVItemID == email.EmailTVItemID select c).FirstOrDefault();

            if (TVItemEmailTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailTVItemID", email.EmailTVItemID.ToString()), new[] { "EmailTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Email,
                };
                if (!AllowableTVTypes.Contains(TVItemEmailTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "EmailTVItemID", "Email"), new[] { "EmailTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(email.EmailAddress))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailAddress"), new[] { "EmailAddress" });
            }

            if (!string.IsNullOrWhiteSpace(email.EmailAddress) && email.EmailAddress.Length > 255)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "EmailAddress", "255"), new[] { "EmailAddress" });
            }

            if (!string.IsNullOrWhiteSpace(email.EmailAddress))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(email.EmailAddress))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotAValidEmail, "EmailAddress"), new[] { "EmailAddress" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(EmailTypeEnum), (int?)email.EmailType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailType"), new[] { "EmailType" });
            }

            if (email.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (email.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == email.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", email.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
