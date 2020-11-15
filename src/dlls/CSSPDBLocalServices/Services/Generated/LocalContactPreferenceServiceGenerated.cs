/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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
    public partial interface ILocalContactPreferenceDBService
    {
        Task<ActionResult<bool>> Delete(int LocalContactPreferenceID);
        Task<ActionResult<List<LocalContactPreference>>> GetLocalContactPreferenceList(int skip = 0, int take = 100);
        Task<ActionResult<LocalContactPreference>> GetLocalContactPreferenceWithContactPreferenceID(int ContactPreferenceID);
        Task<ActionResult<LocalContactPreference>> Post(LocalContactPreference localcontactpreference);
        Task<ActionResult<LocalContactPreference>> Put(LocalContactPreference localcontactpreference);
    }
    public partial class LocalContactPreferenceDBService : ControllerBase, ILocalContactPreferenceDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LocalContactPreferenceDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<LocalContactPreference>> GetLocalContactPreferenceWithContactPreferenceID(int ContactPreferenceID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalContactPreference localContactPreference = (from c in db.LocalContactPreferences.AsNoTracking()
                    where c.ContactPreferenceID == ContactPreferenceID
                    select c).FirstOrDefault();

            if (localContactPreference == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localContactPreference));
        }
        public async Task<ActionResult<List<LocalContactPreference>>> GetLocalContactPreferenceList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalContactPreference> localContactPreferenceList = (from c in db.LocalContactPreferences.AsNoTracking() orderby c.ContactPreferenceID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localContactPreferenceList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalContactPreferenceID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalContactPreference localContactPreference = (from c in db.LocalContactPreferences
                    where c.ContactPreferenceID == LocalContactPreferenceID
                    select c).FirstOrDefault();

            if (localContactPreference == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalContactPreference", "LocalContactPreferenceID", LocalContactPreferenceID.ToString())));
            }

            try
            {
                db.LocalContactPreferences.Remove(localContactPreference);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalContactPreference>> Post(LocalContactPreference localContactPreference)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localContactPreference), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalContactPreferences.Add(localContactPreference);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localContactPreference));
        }
        public async Task<ActionResult<LocalContactPreference>> Put(LocalContactPreference localContactPreference)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localContactPreference), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalContactPreferences.Update(localContactPreference);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localContactPreference));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalContactPreference localContactPreference = validationContext.ObjectInstance as LocalContactPreference;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localContactPreference.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localContactPreference.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localContactPreference.ContactPreferenceID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ContactPreferenceID"), new[] { nameof(localContactPreference.ContactPreferenceID) });
                }

                if (!(from c in db.LocalContactPreferences.AsNoTracking() select c).Where(c => c.ContactPreferenceID == localContactPreference.ContactPreferenceID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ContactPreference", "ContactPreferenceID", localContactPreference.ContactPreferenceID.ToString()), new[] { nameof(localContactPreference.ContactPreferenceID) });
                }
            }

            LocalContact localContactContactID = null;
            localContactContactID = (from c in db.LocalContacts.AsNoTracking() where c.ContactID == localContactPreference.ContactID select c).FirstOrDefault();

            if (localContactContactID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalContact", "ContactID", localContactPreference.ContactID.ToString()), new[] { nameof(localContactPreference.ContactID) });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)localContactPreference.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { nameof(localContactPreference.TVType) });
            }

            if (localContactPreference.MarkerSize < 1 || localContactPreference.MarkerSize > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MarkerSize", "1", "1000"), new[] { nameof(localContactPreference.MarkerSize) });
            }

            if (localContactPreference.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localContactPreference.LastUpdateDate_UTC) });
            }
            else
            {
                if (localContactPreference.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localContactPreference.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localContactPreference.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localContactPreference.LastUpdateContactTVItemID.ToString()), new[] { nameof(localContactPreference.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localContactPreference.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}