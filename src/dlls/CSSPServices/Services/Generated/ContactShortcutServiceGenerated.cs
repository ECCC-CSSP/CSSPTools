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
   public partial interface IContactShortcutService
    {
       Task<ActionResult<bool>> Delete(int ContactShortcutID);
       Task<ActionResult<List<ContactShortcut>>> GetContactShortcutList(int skip = 0, int take = 100);
       Task<ActionResult<ContactShortcut>> GetContactShortcutWithContactShortcutID(int ContactShortcutID);
       Task<ActionResult<ContactShortcut>> Post(ContactShortcut contactshortcut);
       Task<ActionResult<ContactShortcut>> Put(ContactShortcut contactshortcut);
    }
    public partial class ContactShortcutService : ControllerBase, IContactShortcutService
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
        public ContactShortcutService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<ContactShortcut>> GetContactShortcutWithContactShortcutID(int ContactShortcutID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                ContactShortcut contactShortcut = (from c in dbIM.ContactShortcuts.AsNoTracking()
                                   where c.ContactShortcutID == ContactShortcutID
                                   select c).FirstOrDefault();

                if (contactShortcut == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(contactShortcut));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                ContactShortcut contactShortcut = (from c in dbLocal.ContactShortcuts.AsNoTracking()
                        where c.ContactShortcutID == ContactShortcutID
                        select c).FirstOrDefault();

                if (contactShortcut == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(contactShortcut));
            }
            else
            {
                ContactShortcut contactShortcut = (from c in db.ContactShortcuts.AsNoTracking()
                        where c.ContactShortcutID == ContactShortcutID
                        select c).FirstOrDefault();

                if (contactShortcut == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(contactShortcut));
            }
        }
        public async Task<ActionResult<List<ContactShortcut>>> GetContactShortcutList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<ContactShortcut> contactShortcutList = (from c in dbIM.ContactShortcuts.AsNoTracking() orderby c.ContactShortcutID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(contactShortcutList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<ContactShortcut> contactShortcutList = (from c in dbLocal.ContactShortcuts.AsNoTracking() orderby c.ContactShortcutID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(contactShortcutList));
            }
            else
            {
                List<ContactShortcut> contactShortcutList = (from c in db.ContactShortcuts.AsNoTracking() orderby c.ContactShortcutID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(contactShortcutList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int ContactShortcutID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                ContactShortcut contactShortcut = (from c in dbIM.ContactShortcuts
                                   where c.ContactShortcutID == ContactShortcutID
                                   select c).FirstOrDefault();
            
                if (contactShortcut == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ContactShortcut", "ContactShortcutID", ContactShortcutID.ToString())));
                }
            
                try
                {
                    dbIM.ContactShortcuts.Remove(contactShortcut);
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
                ContactShortcut contactShortcut = (from c in dbLocal.ContactShortcuts
                                   where c.ContactShortcutID == ContactShortcutID
                                   select c).FirstOrDefault();
                
                if (contactShortcut == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ContactShortcut", "ContactShortcutID", ContactShortcutID.ToString())));
                }

                try
                {
                   dbLocal.ContactShortcuts.Remove(contactShortcut);
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
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<ContactShortcut>> Post(ContactShortcut contactShortcut)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(contactShortcut), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.ContactShortcuts.Add(contactShortcut);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(contactShortcut));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.ContactShortcuts.Add(contactShortcut);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(contactShortcut));
            }
            else
            {
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
        }
        public async Task<ActionResult<ContactShortcut>> Put(ContactShortcut contactShortcut)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(contactShortcut), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.ContactShortcuts.Update(contactShortcut);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(contactShortcut));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.ContactShortcuts.Update(contactShortcut);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(contactShortcut));
            }
            else
            {
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
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ContactShortcutID"), new[] { "ContactShortcutID" });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.ContactShortcuts select c).Where(c => c.ContactShortcutID == contactShortcut.ContactShortcutID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ContactShortcut", "ContactShortcutID", contactShortcut.ContactShortcutID.ToString()), new[] { "ContactShortcutID" });
                    }
                }
                else
                {
                    if (!(from c in db.ContactShortcuts select c).Where(c => c.ContactShortcutID == contactShortcut.ContactShortcutID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ContactShortcut", "ContactShortcutID", contactShortcut.ContactShortcutID.ToString()), new[] { "ContactShortcutID" });
                    }
                }
            }

            Contact ContactContactID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                ContactContactID = (from c in dbLocal.Contacts where c.ContactID == contactShortcut.ContactID select c).FirstOrDefault();
                if (ContactContactID == null)
                {
                    ContactContactID = (from c in dbIM.Contacts where c.ContactID == contactShortcut.ContactID select c).FirstOrDefault();
                }
            }
            else
            {
                ContactContactID = (from c in db.Contacts where c.ContactID == contactShortcut.ContactID select c).FirstOrDefault();
            }

            if (ContactContactID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactID", contactShortcut.ContactID.ToString()), new[] { "ContactID" });
            }

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutText))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ShortCutText"), new[] { "ShortCutText" });
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutText) && contactShortcut.ShortCutText.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ShortCutText", "100"), new[] { "ShortCutText" });
            }

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ShortCutAddress"), new[] { "ShortCutAddress" });
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress) && contactShortcut.ShortCutAddress.Length > 200)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ShortCutAddress", "200"), new[] { "ShortCutAddress" });
            }

            if (contactShortcut.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contactShortcut.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == contactShortcut.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == contactShortcut.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contactShortcut.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", contactShortcut.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
