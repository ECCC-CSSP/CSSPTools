/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBServices
{
    public partial interface IEmailDistributionListContactDBService
    {
        Task<ActionResult<bool>> Delete(int EmailDistributionListContactID);
        Task<ActionResult<List<EmailDistributionListContact>>> GetEmailDistributionListContactList(int skip = 0, int take = 100);
        Task<ActionResult<EmailDistributionListContact>> GetEmailDistributionListContactWithEmailDistributionListContactID(int EmailDistributionListContactID);
        Task<ActionResult<EmailDistributionListContact>> Post(EmailDistributionListContact emaildistributionlistcontact);
        Task<ActionResult<EmailDistributionListContact>> Put(EmailDistributionListContact emaildistributionlistcontact);
    }
    public partial class EmailDistributionListContactDBService : ControllerBase, IEmailDistributionListContactDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResultList { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;

            ValidationResultList = new List<ValidationResult>();
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<EmailDistributionListContact>> GetEmailDistributionListContactWithEmailDistributionListContactID(int EmailDistributionListContactID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            EmailDistributionListContact emailDistributionListContact = (from c in db.EmailDistributionListContacts.AsNoTracking()
                    where c.EmailDistributionListContactID == EmailDistributionListContactID
                    select c).FirstOrDefault();

            if (emailDistributionListContact == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(emailDistributionListContact));
        }
        public async Task<ActionResult<List<EmailDistributionListContact>>> GetEmailDistributionListContactList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<EmailDistributionListContact> emailDistributionListContactList = (from c in db.EmailDistributionListContacts.AsNoTracking() orderby c.EmailDistributionListContactID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(emailDistributionListContactList));
        }
        public async Task<ActionResult<bool>> Delete(int EmailDistributionListContactID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            EmailDistributionListContact emailDistributionListContact = (from c in db.EmailDistributionListContacts
                    where c.EmailDistributionListContactID == EmailDistributionListContactID
                    select c).FirstOrDefault();

            if (emailDistributionListContact == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContact", "EmailDistributionListContactID", EmailDistributionListContactID.ToString())));
            }

            try
            {
                db.EmailDistributionListContacts.Remove(emailDistributionListContact);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<EmailDistributionListContact>> Post(EmailDistributionListContact emailDistributionListContact)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(emailDistributionListContact), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.EmailDistributionListContacts.Add(emailDistributionListContact);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(emailDistributionListContact));
        }
        public async Task<ActionResult<EmailDistributionListContact>> Put(EmailDistributionListContact emailDistributionListContact)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(emailDistributionListContact), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.EmailDistributionListContacts.Update(emailDistributionListContact);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(emailDistributionListContact));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            EmailDistributionListContact emailDistributionListContact = validationContext.ObjectInstance as EmailDistributionListContact;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (emailDistributionListContact.EmailDistributionListContactID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EmailDistributionListContactID"), new[] { nameof(emailDistributionListContact.EmailDistributionListContactID) }));
                }

                if (!(from c in db.EmailDistributionListContacts.AsNoTracking() select c).Where(c => c.EmailDistributionListContactID == emailDistributionListContact.EmailDistributionListContactID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContact", "EmailDistributionListContactID", emailDistributionListContact.EmailDistributionListContactID.ToString()), new[] { nameof(emailDistributionListContact.EmailDistributionListContactID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)emailDistributionListContact.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(emailDistributionListContact.DBCommand) }));
            }

            EmailDistributionList EmailDistributionListEmailDistributionListID = null;
            EmailDistributionListEmailDistributionListID = (from c in db.EmailDistributionLists.AsNoTracking() where c.EmailDistributionListID == emailDistributionListContact.EmailDistributionListID select c).FirstOrDefault();

            if (EmailDistributionListEmailDistributionListID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListID", emailDistributionListContact.EmailDistributionListID.ToString()), new[] { nameof(emailDistributionListContact.EmailDistributionListID)}));
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListContact.Name))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Name"), new[] { nameof(emailDistributionListContact.Name) }));
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Name) && emailDistributionListContact.Name.Length > 100)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Name", "100"), new[] { nameof(emailDistributionListContact.Name) }));
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListContact.Email))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Email"), new[] { nameof(emailDistributionListContact.Email) }));
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Email) && emailDistributionListContact.Email.Length > 200)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Email", "200"), new[] { nameof(emailDistributionListContact.Email) }));
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Email))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(emailDistributionListContact.Email))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotAValidEmail, "Email"), new[] { nameof(emailDistributionListContact.Email) }));
                }
            }

            if (emailDistributionListContact.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(emailDistributionListContact.LastUpdateDate_UTC) }));
            }
            else
            {
                if (emailDistributionListContact.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(emailDistributionListContact.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == emailDistributionListContact.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", emailDistributionListContact.LastUpdateContactTVItemID.ToString()), new[] { nameof(emailDistributionListContact.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(emailDistributionListContact.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
