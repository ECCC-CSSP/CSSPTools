/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
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
   public interface IContactPreferenceService
    {
       Task<ActionResult<ContactPreference>> GetContactPreferenceWithContactPreferenceID(int ContactPreferenceID);
       Task<ActionResult<List<ContactPreference>>> GetContactPreferenceList();
       Task<ActionResult<ContactPreference>> Add(ContactPreference contactpreference);
       Task<ActionResult<bool>> Delete(int ContactPreferenceID);
       Task<ActionResult<ContactPreference>> Update(ContactPreference contactpreference);
    }
    public partial class ContactPreferenceService : ControllerBase, IContactPreferenceService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private ICultureService CultureService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public ContactPreferenceService(ICultureService CultureService, IEnums enums, CSSPDBContext db)
        {
            this.CultureService = CultureService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<ContactPreference>> GetContactPreferenceWithContactPreferenceID(int ContactPreferenceID)
        {
            ContactPreference contactpreference = (from c in db.ContactPreferences.AsNoTracking()
                    where c.ContactPreferenceID == ContactPreferenceID
                    select c).FirstOrDefault();

            if (contactpreference == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(contactpreference));
        }
        public async Task<ActionResult<List<ContactPreference>>> GetContactPreferenceList()
        {
            List<ContactPreference> contactpreferenceList = (from c in db.ContactPreferences.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(contactpreferenceList));
        }
        public async Task<ActionResult<ContactPreference>> Add(ContactPreference contactPreference)
        {
            ValidationResults = Validate(new ValidationContext(contactPreference), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.ContactPreferences.Add(contactPreference);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(contactPreference));
        }
        public async Task<ActionResult<bool>> Delete(int ContactPreferenceID)
        {
            ContactPreference contactPreference = (from c in db.ContactPreferences
                               where c.ContactPreferenceID == ContactPreferenceID
                               select c).FirstOrDefault();
            
            if (contactPreference == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "ContactPreference", "ContactPreferenceID", ContactPreferenceID.ToString())));
            }

            try
            {
               db.ContactPreferences.Remove(contactPreference);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<ContactPreference>> Update(ContactPreference contactPreference)
        {
            ValidationResults = Validate(new ValidationContext(contactPreference), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.ContactPreferences.Update(contactPreference);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(contactPreference));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            ContactPreference contactPreference = validationContext.ObjectInstance as ContactPreference;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (contactPreference.ContactPreferenceID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "ContactPreferenceID"), new[] { "ContactPreferenceID" });
                }

                if (!(from c in db.ContactPreferences select c).Where(c => c.ContactPreferenceID == contactPreference.ContactPreferenceID).Any())
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "ContactPreference", "ContactPreferenceID", contactPreference.ContactPreferenceID.ToString()), new[] { "ContactPreferenceID" });
                }
            }

            Contact ContactContactID = (from c in db.Contacts where c.ContactID == contactPreference.ContactID select c).FirstOrDefault();

            if (ContactContactID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactID", contactPreference.ContactID.ToString()), new[] { "ContactID" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)contactPreference.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            if (contactPreference.MarkerSize < 1 || contactPreference.MarkerSize > 1000)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "MarkerSize", "1", "1000"), new[] { "MarkerSize" });
            }

            if (contactPreference.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contactPreference.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contactPreference.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", contactPreference.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
