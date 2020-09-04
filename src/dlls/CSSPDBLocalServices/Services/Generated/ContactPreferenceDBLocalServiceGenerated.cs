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

namespace CSSPDBLocalServices
{
    public partial interface IContactPreferenceDBLocalService
    {
        Task<ActionResult<bool>> Delete(int ContactPreferenceID);
        Task<ActionResult<List<ContactPreference>>> GetContactPreferenceList(int skip = 0, int take = 100);
        Task<ActionResult<ContactPreference>> GetContactPreferenceWithContactPreferenceID(int ContactPreferenceID);
        Task<ActionResult<ContactPreference>> Post(ContactPreference contactpreference);
        Task<ActionResult<ContactPreference>> Put(ContactPreference contactpreference);
    }
    public partial class ContactPreferenceDBLocalService : ControllerBase, IContactPreferenceDBLocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext dbLocal { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public ContactPreferenceDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext dbLocal)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.dbLocal = dbLocal;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<ContactPreference>> GetContactPreferenceWithContactPreferenceID(int ContactPreferenceID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            ContactPreference contactPreference = (from c in dbLocal.ContactPreferences.AsNoTracking()
                    where c.ContactPreferenceID == ContactPreferenceID
                    select c).FirstOrDefault();

            if (contactPreference == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(contactPreference));
        }
        public async Task<ActionResult<List<ContactPreference>>> GetContactPreferenceList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<ContactPreference> contactPreferenceList = (from c in dbLocal.ContactPreferences.AsNoTracking() orderby c.ContactPreferenceID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(contactPreferenceList));
        }
        public async Task<ActionResult<bool>> Delete(int ContactPreferenceID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ContactPreference contactPreference = (from c in dbLocal.ContactPreferences
                    where c.ContactPreferenceID == ContactPreferenceID
                    select c).FirstOrDefault();

            if (contactPreference == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ContactPreference", "ContactPreferenceID", ContactPreferenceID.ToString())));
            }

            try
            {
                dbLocal.ContactPreferences.Remove(contactPreference);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<ContactPreference>> Post(ContactPreference contactPreference)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(contactPreference), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (contactPreference.ContactPreferenceID == 0)
            {
                int LastContactPreferenceID = (from c in dbLocal.ContactPreferences
                          orderby c.ContactPreferenceID descending
                          select c.ContactPreferenceID).FirstOrDefault();

                contactPreference.ContactPreferenceID = LastContactPreferenceID + 1;
            }

            try
            {
                dbLocal.ContactPreferences.Add(contactPreference);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(contactPreference));
        }
        public async Task<ActionResult<ContactPreference>> Put(ContactPreference contactPreference)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(contactPreference), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.ContactPreferences.Update(contactPreference);
                dbLocal.SaveChanges();
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
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ContactPreferenceID"), new[] { nameof(contactPreference.ContactPreferenceID) });
                }

                if (!(from c in dbLocal.ContactPreferences select c).Where(c => c.ContactPreferenceID == contactPreference.ContactPreferenceID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ContactPreference", "ContactPreferenceID", contactPreference.ContactPreferenceID.ToString()), new[] { nameof(contactPreference.ContactPreferenceID) });
                }
            }

            Contact ContactContactID = null;
            ContactContactID = (from c in dbLocal.Contacts where c.ContactID == contactPreference.ContactID select c).FirstOrDefault();

            if (ContactContactID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactID", contactPreference.ContactID.ToString()), new[] { nameof(contactPreference.ContactID) });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)contactPreference.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { nameof(contactPreference.TVType) });
            }

            if (contactPreference.MarkerSize < 1 || contactPreference.MarkerSize > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MarkerSize", "1", "1000"), new[] { nameof(contactPreference.MarkerSize) });
            }

            if (contactPreference.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(contactPreference.LastUpdateDate_UTC) });
            }
            else
            {
                if (contactPreference.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(contactPreference.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == contactPreference.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", contactPreference.LastUpdateContactTVItemID.ToString()), new[] { nameof(contactPreference.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(contactPreference.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
