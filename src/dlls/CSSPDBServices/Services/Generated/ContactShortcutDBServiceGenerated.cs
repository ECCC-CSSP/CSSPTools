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
    public partial interface IContactShortcutDBService
    {
        Task<ActionResult<bool>> Delete(int ContactShortcutID);
        Task<ActionResult<List<ContactShortcut>>> GetContactShortcutList(int skip = 0, int take = 100);
        Task<ActionResult<ContactShortcut>> GetContactShortcutWithContactShortcutID(int ContactShortcutID);
        Task<ActionResult<ContactShortcut>> Post(ContactShortcut contactshortcut);
        Task<ActionResult<ContactShortcut>> Put(ContactShortcut contactshortcut);
    }
    public partial class ContactShortcutDBService : ControllerBase, IContactShortcutDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public ContactShortcutDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<ContactShortcut>> GetContactShortcutWithContactShortcutID(int ContactShortcutID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            ContactShortcut contactShortcut = (from c in db.ContactShortcuts.AsNoTracking()
                    where c.ContactShortcutID == ContactShortcutID
                    select c).FirstOrDefault();

            if (contactShortcut == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(contactShortcut));
        }
        public async Task<ActionResult<List<ContactShortcut>>> GetContactShortcutList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<ContactShortcut> contactShortcutList = (from c in db.ContactShortcuts.AsNoTracking() orderby c.ContactShortcutID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(contactShortcutList));
        }
        public async Task<ActionResult<bool>> Delete(int ContactShortcutID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            ContactShortcut contactShortcut = (from c in db.ContactShortcuts
                    where c.ContactShortcutID == ContactShortcutID
                    select c).FirstOrDefault();

            if (contactShortcut == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ContactShortcut", "ContactShortcutID", ContactShortcutID.ToString())));
            }

            try
            {
                db.ContactShortcuts.Remove(contactShortcut);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<ContactShortcut>> Post(ContactShortcut contactShortcut)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(contactShortcut), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.ContactShortcuts.Add(contactShortcut);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(contactShortcut));
        }
        public async Task<ActionResult<ContactShortcut>> Put(ContactShortcut contactShortcut)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(contactShortcut), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.ContactShortcuts.Update(contactShortcut);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(contactShortcut));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            ContactShortcut contactShortcut = validationContext.ObjectInstance as ContactShortcut;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (contactShortcut.ContactShortcutID == 0)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ContactShortcutID"), new[] { nameof(contactShortcut.ContactShortcutID) }));
                }

                if (!(from c in db.ContactShortcuts.AsNoTracking() select c).Where(c => c.ContactShortcutID == contactShortcut.ContactShortcutID).Any())
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ContactShortcut", "ContactShortcutID", contactShortcut.ContactShortcutID.ToString()), new[] { nameof(contactShortcut.ContactShortcutID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)contactShortcut.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(contactShortcut.DBCommand) }));
            }

            Contact ContactContactID = null;
            ContactContactID = (from c in db.Contacts.AsNoTracking() where c.ContactID == contactShortcut.ContactID select c).FirstOrDefault();

            if (ContactContactID == null)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactID", contactShortcut.ContactID.ToString()), new[] { nameof(contactShortcut.ContactID)}));
            }

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutText))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ShortCutText"), new[] { nameof(contactShortcut.ShortCutText) }));
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutText) && contactShortcut.ShortCutText.Length > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ShortCutText", "100"), new[] { nameof(contactShortcut.ShortCutText) }));
            }

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ShortCutAddress"), new[] { nameof(contactShortcut.ShortCutAddress) }));
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress) && contactShortcut.ShortCutAddress.Length > 200)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ShortCutAddress", "200"), new[] { nameof(contactShortcut.ShortCutAddress) }));
            }

            if (contactShortcut.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(contactShortcut.LastUpdateDate_UTC) }));
            }
            else
            {
                if (contactShortcut.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(contactShortcut.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == contactShortcut.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", contactShortcut.LastUpdateContactTVItemID.ToString()), new[] { nameof(contactShortcut.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(contactShortcut.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
