/*
 * Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
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
   public interface IEmailDistributionListContactService
    {
       Task<ActionResult<bool>> Delete(int EmailDistributionListContactID);
       Task<ActionResult<List<EmailDistributionListContact>>> GetEmailDistributionListContactList();
       Task<ActionResult<EmailDistributionListContact>> GetEmailDistributionListContactWithEmailDistributionListContactID(int EmailDistributionListContactID);
       Task<ActionResult<EmailDistributionListContact>> Post(EmailDistributionListContact emaildistributionlistcontact);
       Task<ActionResult<EmailDistributionListContact>> Put(EmailDistributionListContact emaildistributionlistcontact);
    }
    public partial class EmailDistributionListContactService : ControllerBase, IEmailDistributionListContactService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<EmailDistributionListContact>> GetEmailDistributionListContactWithEmailDistributionListContactID(int EmailDistributionListContactID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                EmailDistributionListContact emaildistributionlistcontact = (from c in dbLocal.EmailDistributionListContacts.AsNoTracking()
                        where c.EmailDistributionListContactID == EmailDistributionListContactID
                        select c).FirstOrDefault();

                if (emaildistributionlistcontact == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(emaildistributionlistcontact));
            }
            else
            {
                EmailDistributionListContact emaildistributionlistcontact = (from c in db.EmailDistributionListContacts.AsNoTracking()
                        where c.EmailDistributionListContactID == EmailDistributionListContactID
                        select c).FirstOrDefault();

                if (emaildistributionlistcontact == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(emaildistributionlistcontact));
            }
        }
        public async Task<ActionResult<List<EmailDistributionListContact>>> GetEmailDistributionListContactList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                List<EmailDistributionListContact> emaildistributionlistcontactList = (from c in dbLocal.EmailDistributionListContacts.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(emaildistributionlistcontactList));
            }
            else
            {
                List<EmailDistributionListContact> emaildistributionlistcontactList = (from c in db.EmailDistributionListContacts.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(emaildistributionlistcontactList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int EmailDistributionListContactID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                EmailDistributionListContact emailDistributionListContact = (from c in dbLocal.EmailDistributionListContacts
                                   where c.EmailDistributionListContactID == EmailDistributionListContactID
                                   select c).FirstOrDefault();
                
                if (emailDistributionListContact == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContact", "EmailDistributionListContactID", EmailDistributionListContactID.ToString())));
                }

                try
                {
                   dbLocal.EmailDistributionListContacts.Remove(emailDistributionListContact);
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
                EmailDistributionListContact emailDistributionListContact = (from c in db.EmailDistributionListContacts
                                   where c.EmailDistributionListContactID == EmailDistributionListContactID
                                   select c).FirstOrDefault();
                
                if (emailDistributionListContact == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContact", "EmailDistributionListContactID", EmailDistributionListContactID.ToString())));
                }

                try
                {
                   db.EmailDistributionListContacts.Remove(emailDistributionListContact);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<EmailDistributionListContact>> Post(EmailDistributionListContact emailDistributionListContact)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(emailDistributionListContact), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
                try
                {
                   dbLocal.EmailDistributionListContacts.Add(emailDistributionListContact);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(emailDistributionListContact));
            }
            else
            {
                try
                {
                   db.EmailDistributionListContacts.Add(emailDistributionListContact);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(emailDistributionListContact));
            }
        }
        public async Task<ActionResult<EmailDistributionListContact>> Put(EmailDistributionListContact emailDistributionListContact)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(emailDistributionListContact), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
            try
            {
               dbLocal.EmailDistributionListContacts.Update(emailDistributionListContact);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(emailDistributionListContact));
            }
            else
            {
            try
            {
               db.EmailDistributionListContacts.Update(emailDistributionListContact);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(emailDistributionListContact));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            EmailDistributionListContact emailDistributionListContact = validationContext.ObjectInstance as EmailDistributionListContact;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (emailDistributionListContact.EmailDistributionListContactID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "EmailDistributionListContactID"), new[] { "EmailDistributionListContactID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.EmailDistributionListContacts select c).Where(c => c.EmailDistributionListContactID == emailDistributionListContact.EmailDistributionListContactID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContact", "EmailDistributionListContactID", emailDistributionListContact.EmailDistributionListContactID.ToString()), new[] { "EmailDistributionListContactID" });
                    }
                }
                else
                {
                    if (!(from c in db.EmailDistributionListContacts select c).Where(c => c.EmailDistributionListContactID == emailDistributionListContact.EmailDistributionListContactID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContact", "EmailDistributionListContactID", emailDistributionListContact.EmailDistributionListContactID.ToString()), new[] { "EmailDistributionListContactID" });
                    }
                }
            }

            EmailDistributionList EmailDistributionListEmailDistributionListID = null;
            if (LoggedInService.IsLocal)
            {
                EmailDistributionListEmailDistributionListID = (from c in dbLocal.EmailDistributionLists where c.EmailDistributionListID == emailDistributionListContact.EmailDistributionListID select c).FirstOrDefault();
                if (EmailDistributionListEmailDistributionListID == null)
                {
                    EmailDistributionListEmailDistributionListID = (from c in dbIM.EmailDistributionLists where c.EmailDistributionListID == emailDistributionListContact.EmailDistributionListID select c).FirstOrDefault();
                }
            }
            else
            {
                EmailDistributionListEmailDistributionListID = (from c in db.EmailDistributionLists where c.EmailDistributionListID == emailDistributionListContact.EmailDistributionListID select c).FirstOrDefault();
            }

            if (EmailDistributionListEmailDistributionListID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListID", emailDistributionListContact.EmailDistributionListID.ToString()), new[] { "EmailDistributionListID" });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListContact.Name))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "Name"), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Name) && emailDistributionListContact.Name.Length > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "Name", "100"), new[] { "Name" });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListContact.Email))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "Email"), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Email) && emailDistributionListContact.Email.Length > 200)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "Email", "200"), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Email))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(emailDistributionListContact.Email))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotAValidEmail, "Email"), new[] { "Email" });
                }
            }

            if (emailDistributionListContact.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (emailDistributionListContact.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == emailDistributionListContact.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == emailDistributionListContact.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionListContact.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", emailDistributionListContact.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
