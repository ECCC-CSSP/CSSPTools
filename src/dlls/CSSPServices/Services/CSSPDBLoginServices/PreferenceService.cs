/*
 * Manually edited
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
    public partial interface IPreferenceService
    {
        Task<ActionResult<bool>> Delete(int PreferenceID);
        Task<ActionResult<List<Preference>>> GetPreferenceList(int skip = 0, int take = 100);
        Task<ActionResult<Preference>> GetAddressWithPreferenceID(int PreferenceID);
        Task<ActionResult<Preference>> Post(Preference preference);
        Task<ActionResult<Preference>> Put(Preference preference);
    }
    public partial class PreferenceService : ControllerBase, IPreferenceService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLoginContext dbLogin { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public PreferenceService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBLoginContext dbLogin)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.dbLogin = dbLogin;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<Preference>> GetAddressWithPreferenceID(int PreferenceID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            Preference preference = (from c in dbLogin.Preferences.AsNoTracking()
                                 where c.PreferenceID == PreferenceID
                                 select c).FirstOrDefault();

            if (preference == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(preference));
        }
        public async Task<ActionResult<List<Preference>>> GetPreferenceList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            List<Preference> preferenceList = (from c in dbLogin.Preferences.AsNoTracking() orderby c.PreferenceID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(preferenceList));
        }
        public async Task<ActionResult<bool>> Delete(int PreferenceID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            Preference preference = (from c in dbLogin.Preferences
                                 where c.PreferenceID == PreferenceID
                                 select c).FirstOrDefault();

            if (preference == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Preference", "PreferenceID", PreferenceID.ToString())));
            }

            try
            {
                dbLogin.Preferences.Remove(preference);
                dbLogin.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<Preference>> Post(Preference preference)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(preference), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLogin.Preferences.Add(preference);
                dbLogin.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(preference));
        }
        public async Task<ActionResult<Preference>> Put(Preference preference)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(preference), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLogin.Preferences.Update(preference);
                dbLogin.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(preference));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            Preference preference = validationContext.ObjectInstance as Preference;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (preference.PreferenceID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PreferenceID"), new[] { nameof(preference.PreferenceID) });
                }

                if (!(from c in dbLogin.Preferences select c).Where(c => c.PreferenceID == preference.PreferenceID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Preference", "PreferenceID", preference.PreferenceID.ToString()), new[] { nameof(preference.PreferenceID) });
                }
            }

            // doing AzureStore
            if (string.IsNullOrWhiteSpace(preference.AzureStore))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AzureStore"), new[] { nameof(preference.AzureStore) });
            }

            if (!string.IsNullOrWhiteSpace(preference.AzureStore) && preference.AzureStore.Length > 200)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureStore", "200"), new[] { nameof(preference.AzureStore) });
            }

            // doing LoginEmail
            if (string.IsNullOrWhiteSpace(preference.LoginEmail))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LoginEmail"), new[] { nameof(preference.LoginEmail) });
            }

            if (!string.IsNullOrWhiteSpace(preference.LoginEmail) && preference.LoginEmail.Length > 200)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureStore", "200"), new[] { nameof(preference.AzureStore) });
            }

            // doing Password
            if (string.IsNullOrWhiteSpace(preference.Password))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Password"), new[] { nameof(preference.Password) });
            }

            if (!string.IsNullOrWhiteSpace(preference.Password) && preference.Password.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Password", "100"), new[] { nameof(preference.Password) });
            }

            // doing AzureToken
            if (string.IsNullOrWhiteSpace(preference.AzureToken))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Token"), new[] { nameof(preference.AzureToken) });
            }

            if (!string.IsNullOrWhiteSpace(preference.AzureToken) && preference.AzureToken.Length > 300)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Token", "300"), new[] { nameof(preference.AzureToken) });
            }

            // doing LocalToken
            if (string.IsNullOrWhiteSpace(preference.LocalToken))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Token"), new[] { nameof(preference.LocalToken) });
            }

            if (!string.IsNullOrWhiteSpace(preference.LocalToken) && preference.LocalToken.Length > 300)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Token", "300"), new[] { nameof(preference.LocalToken) });
            }
        }
        #endregion Functions private

    }
}
