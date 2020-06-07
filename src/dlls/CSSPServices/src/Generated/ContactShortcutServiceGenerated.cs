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
   public interface IContactShortcutService
    {
       Task<ActionResult<ContactShortcut>> GetContactShortcutWithContactShortcutID(int ContactShortcutID);
       Task<ActionResult<List<ContactShortcut>>> GetContactShortcutList();
       Task<ActionResult<ContactShortcut>> Add(ContactShortcut contactshortcut);
       Task<ActionResult<bool>> Delete(int ContactShortcutID);
       Task<ActionResult<ContactShortcut>> Update(ContactShortcut contactshortcut);
       Task SetCulture(CultureInfo culture);
    }
    public partial class ContactShortcutService : ControllerBase, IContactShortcutService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public ContactShortcutService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<ContactShortcut>> GetContactShortcutWithContactShortcutID(int ContactShortcutID)
        {
            ContactShortcut contactshortcut = (from c in db.ContactShortcuts.AsNoTracking()
                    where c.ContactShortcutID == ContactShortcutID
                    select c).FirstOrDefault();

            if (contactshortcut == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(contactshortcut));
        }
        public async Task<ActionResult<List<ContactShortcut>>> GetContactShortcutList()
        {
            List<ContactShortcut> contactshortcutList = (from c in db.ContactShortcuts.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(contactshortcutList));
        }
        public async Task<ActionResult<ContactShortcut>> Add(ContactShortcut contactShortcut)
        {
            ValidationResults = Validate(new ValidationContext(contactShortcut), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.ContactShortcuts.Add(contactShortcut);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(contactShortcut));
        }
        public async Task<ActionResult<bool>> Delete(int ContactShortcutID)
        {
            ContactShortcut contactShortcut = (from c in db.ContactShortcuts
                               where c.ContactShortcutID == ContactShortcutID
                               select c).FirstOrDefault();
            
            if (contactShortcut == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ContactShortcut", "ContactShortcutID", ContactShortcutID.ToString())));
            }

            try
            {
               db.ContactShortcuts.Remove(contactShortcut);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<ContactShortcut>> Update(ContactShortcut contactShortcut)
        {
            ValidationResults = Validate(new ValidationContext(contactShortcut), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.ContactShortcuts.Update(contactShortcut);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(contactShortcut));
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
            ContactShortcut contactShortcut = validationContext.ObjectInstance as ContactShortcut;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (contactShortcut.ContactShortcutID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactShortcutID"), new[] { "ContactShortcutID" });
                }

                if (!(from c in db.ContactShortcuts select c).Where(c => c.ContactShortcutID == contactShortcut.ContactShortcutID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ContactShortcut", "ContactShortcutID", contactShortcut.ContactShortcutID.ToString()), new[] { "ContactShortcutID" });
                }
            }

            Contact ContactContactID = (from c in db.Contacts where c.ContactID == contactShortcut.ContactID select c).FirstOrDefault();

            if (ContactContactID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactID", contactShortcut.ContactID.ToString()), new[] { "ContactID" });
            }

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutText))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ShortCutText"), new[] { "ShortCutText" });
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutText) && contactShortcut.ShortCutText.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ShortCutText", "100"), new[] { "ShortCutText" });
            }

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ShortCutAddress"), new[] { "ShortCutAddress" });
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress) && contactShortcut.ShortCutAddress.Length > 200)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ShortCutAddress", "200"), new[] { "ShortCutAddress" });
            }

            if (contactShortcut.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contactShortcut.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contactShortcut.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", contactShortcut.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
