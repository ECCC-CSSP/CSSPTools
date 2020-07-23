/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
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
   public partial interface IEmailService
    {
       Task<ActionResult<bool>> Delete(int EmailID);
       Task<ActionResult<List<Email>>> GetEmailList(int skip = 0, int take = 100);
       Task<ActionResult<Email>> GetEmailWithEmailID(int EmailID);
       Task<ActionResult<Email>> Post(Email email);
       Task<ActionResult<Email>> Put(Email email);
    }
    public partial class EmailService : ControllerBase, IEmailService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public EmailService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<Email>> GetEmailWithEmailID(int EmailID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                Email email = (from c in dbIM.Emails.AsNoTracking()
                                   where c.EmailID == EmailID
                                   select c).FirstOrDefault();

                if (email == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(email));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                Email email = (from c in dbLocal.Emails.AsNoTracking()
                        where c.EmailID == EmailID
                        select c).FirstOrDefault();

                if (email == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(email));
            }
            else
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
        }
        public async Task<ActionResult<List<Email>>> GetEmailList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<Email> emailList = (from c in dbIM.Emails.AsNoTracking() orderby c.EmailID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(emailList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<Email> emailList = (from c in dbLocal.Emails.AsNoTracking() orderby c.EmailID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(emailList));
            }
            else
            {
                List<Email> emailList = (from c in db.Emails.AsNoTracking() orderby c.EmailID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(emailList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int EmailID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                Email email = (from c in dbIM.Emails
                                   where c.EmailID == EmailID
                                   select c).FirstOrDefault();
            
                if (email == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Email", "EmailID", EmailID.ToString())));
                }
            
                try
                {
                    dbIM.Emails.Remove(email);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }
            
                return await Task.FromResult(Ok(true));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                Email email = (from c in dbLocal.Emails
                                   where c.EmailID == EmailID
                                   select c).FirstOrDefault();
                
                if (email == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Email", "EmailID", EmailID.ToString())));
                }

                try
                {
                   dbLocal.Emails.Remove(email);
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
                Email email = (from c in db.Emails
                                   where c.EmailID == EmailID
                                   select c).FirstOrDefault();
                
                if (email == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Email", "EmailID", EmailID.ToString())));
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

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<Email>> Post(Email email)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(email), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.Emails.Add(email);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(email));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.Emails.Add(email);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(email));
            }
            else
            {
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
        }
        public async Task<ActionResult<Email>> Put(Email email)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(email), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.Emails.Update(email);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(email));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.Emails.Update(email);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(email));
            }
            else
            {
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
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EmailID"), new[] { nameof(email.EmailID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.Emails select c).Where(c => c.EmailID == email.EmailID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Email", "EmailID", email.EmailID.ToString()), new[] { nameof(email.EmailID) });
                    }
                }
                else
                {
                    if (!(from c in db.Emails select c).Where(c => c.EmailID == email.EmailID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Email", "EmailID", email.EmailID.ToString()), new[] { nameof(email.EmailID) });
                    }
                }
            }

            TVItem TVItemEmailTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemEmailTVItemID = (from c in dbLocal.TVItems where c.TVItemID == email.EmailTVItemID select c).FirstOrDefault();
                if (TVItemEmailTVItemID == null)
                {
                    TVItemEmailTVItemID = (from c in dbIM.TVItems where c.TVItemID == email.EmailTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemEmailTVItemID = (from c in db.TVItems where c.TVItemID == email.EmailTVItemID select c).FirstOrDefault();
            }

            if (TVItemEmailTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailTVItemID", email.EmailTVItemID.ToString()), new[] { nameof(email.EmailTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Email,
                };
                if (!AllowableTVTypes.Contains(TVItemEmailTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "EmailTVItemID", "Email"), new[] { nameof(email.EmailTVItemID) });
                }
            }

            if (string.IsNullOrWhiteSpace(email.EmailAddress))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EmailAddress"), new[] { nameof(email.EmailAddress) });
            }

            if (!string.IsNullOrWhiteSpace(email.EmailAddress) && email.EmailAddress.Length > 255)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "EmailAddress", "255"), new[] { nameof(email.EmailAddress) });
            }

            if (!string.IsNullOrWhiteSpace(email.EmailAddress))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(email.EmailAddress))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotAValidEmail, "EmailAddress"), new[] { nameof(email.EmailAddress) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(EmailTypeEnum), (int?)email.EmailType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EmailType"), new[] { nameof(email.EmailType) });
            }

            if (email.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(email.LastUpdateDate_UTC) });
            }
            else
            {
                if (email.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(email.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == email.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == email.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == email.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", email.LastUpdateContactTVItemID.ToString()), new[] { nameof(email.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(email.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
