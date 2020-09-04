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
using LocalServices;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CSSPDBLocalIMServices
{
    public partial interface IContactDBLocalIMService
    {
        Task<ActionResult<bool>> Delete(int ContactID);
        Task<ActionResult<List<Contact>>> GetContactList(int skip = 0, int take = 100);
        Task<ActionResult<Contact>> GetContactWithContactID(int ContactID);
        Task<ActionResult<Contact>> Post(Contact contact, AddContactTypeEnum addContactType);
        Task<ActionResult<Contact>> Put(Contact contact);
    }
    public partial class ContactDBLocalIMService : ControllerBase, IContactDBLocalIMService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBInMemoryContext dbLocalIM { get; }
        private IConfiguration Configuration { get; }
        private IAspNetUserDBLocalIMService AspNetUserDBLocalIMService { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public ContactDBLocalIMService(IConfiguration Configuration,
           ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBInMemoryContext dbLocalIM)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.dbLocalIM = dbLocalIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<Contact>> GetContactWithContactID(int ContactID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            Contact contact = (from c in dbLocalIM.Contacts.AsNoTracking()
                    where c.ContactID == ContactID
                    select c).FirstOrDefault();

            if (contact == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(contact));
        }
        public async Task<ActionResult<List<Contact>>> GetContactList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<Contact> contactList = (from c in dbLocalIM.Contacts.AsNoTracking() orderby c.ContactID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(contactList));
        }
        public async Task<ActionResult<bool>> Delete(int ContactID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            Contact contact = (from c in dbLocalIM.Contacts
                    where c.ContactID == ContactID
                    select c).FirstOrDefault();

            if (contact == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactID", ContactID.ToString())));
            }

            try
            {
                dbLocalIM.Contacts.Remove(contact);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<Contact>> Post(Contact contact, AddContactTypeEnum addContactType)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(contact), ActionDBTypeEnum.Create, addContactType);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.Contacts.Add(contact);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(contact));
        }
        public async Task<ActionResult<Contact>> Put(Contact contact)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(contact), ActionDBTypeEnum.Update, AddContactTypeEnum.LoggedIn);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.Contacts.Update(contact);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(contact));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType, AddContactTypeEnum addContactType)
        {
            string retStr = "";
            Contact contact = validationContext.ObjectInstance as Contact;

            if (actionDBType == ActionDBTypeEnum.Create)
            {
                if (contact.ContactID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ContactID"), new[] { nameof(contact.ContactID) });
                }
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (contact.ContactID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ContactID"), new[] { nameof(contact.ContactID) });
                }

                if (!(from c in dbLocalIM.Contacts select c).Where(c => c.ContactID == contact.ContactID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactID", contact.ContactID.ToString()), new[] { nameof(contact.ContactID) });
                }
            }

            if (string.IsNullOrWhiteSpace(contact.Id))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Id"), new[] { nameof(contact.Id) });
            }

            if (!string.IsNullOrWhiteSpace(contact.Id) && contact.Id.Length > 450)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Id", "450"), new[] { nameof(contact.Id) });
            }

            AspNetUser AspNetUserId = null;
            AspNetUserId = (from c in dbLocalIM.AspNetUsers where c.Id == contact.Id select c).FirstOrDefault();

            if (AspNetUserId == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AspNetUser", "Id", (contact.Id == null ? "" : contact.Id.ToString())), new[] { nameof(contact.Id) });
            }

            TVItem TVItemContactTVItemID = null;
            TVItemContactTVItemID = (from c in dbLocalIM.TVItems where c.TVItemID == contact.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactTVItemID", contact.ContactTVItemID.ToString()), new[] { nameof(contact.ContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ContactTVItemID", "Contact"), new[] { nameof(contact.ContactTVItemID) });
                }
            }

            if (string.IsNullOrWhiteSpace(contact.LoginEmail))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LoginEmail"), new[] { nameof(contact.LoginEmail) });
            }

            if (!string.IsNullOrWhiteSpace(contact.LoginEmail) && (contact.LoginEmail.Length < 6 || contact.LoginEmail.Length > 255))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LoginEmail", "6", "255"), new[] { nameof(contact.LoginEmail) });
            }

            if (!string.IsNullOrWhiteSpace(contact.LoginEmail))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(contact.LoginEmail))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotAValidEmail, "LoginEmail"), new[] { nameof(contact.LoginEmail) });
                }
            }

            if (string.IsNullOrWhiteSpace(contact.FirstName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FirstName"), new[] { nameof(contact.FirstName) });
            }

            if (!string.IsNullOrWhiteSpace(contact.FirstName) && contact.FirstName.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "FirstName", "100"), new[] { nameof(contact.FirstName) });
            }

            if (string.IsNullOrWhiteSpace(contact.LastName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastName"), new[] { nameof(contact.LastName) });
            }

            if (!string.IsNullOrWhiteSpace(contact.LastName) && contact.LastName.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "LastName", "100"), new[] { nameof(contact.LastName) });
            }

            if (!string.IsNullOrWhiteSpace(contact.Initial) && contact.Initial.Length > 50)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Initial", "50"), new[] { nameof(contact.Initial) });
            }

            if (string.IsNullOrWhiteSpace(contact.WebName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "WebName"), new[] { nameof(contact.WebName) });
            }

            if (!string.IsNullOrWhiteSpace(contact.WebName) && contact.WebName.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "WebName", "100"), new[] { nameof(contact.WebName) });
            }

            if (contact.ContactTitle != null)
            {
                retStr = enums.EnumTypeOK(typeof(ContactTitleEnum), (int?)contact.ContactTitle);
                if (contact.ContactTitle == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ContactTitle"), new[] { nameof(contact.ContactTitle) });
                }
            }

            if (!string.IsNullOrWhiteSpace(contact.SamplingPlanner_ProvincesTVItemID) && contact.SamplingPlanner_ProvincesTVItemID.Length > 200)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SamplingPlanner_ProvincesTVItemID", "200"), new[] { nameof(contact.SamplingPlanner_ProvincesTVItemID) });
            }

            if (!string.IsNullOrWhiteSpace(contact.Token) && contact.Token.Length > 255)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Token", "255"), new[] { nameof(contact.Token) });
            }

            if (contact.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(contact.LastUpdateDate_UTC) });
            }
            else
            {
                if (contact.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(contact.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems where c.TVItemID == contact.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", contact.LastUpdateContactTVItemID.ToString()), new[] { nameof(contact.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(contact.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
