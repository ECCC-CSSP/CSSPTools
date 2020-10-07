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
using LocalServices;

namespace CSSPDBLoginServices
{
    public partial interface IPreferenceService
    {
        Task<ActionResult<bool>> Delete(int PreferenceID);
        Task<ActionResult<List<Preference>>> GetPreferenceList(int skip = 0, int take = 100);
        Task<ActionResult<Preference>> GetAddressWithPreferenceID(int PreferenceID);
        Task<ActionResult<Preference>> Post(Preference preference);
        Task<ActionResult<Preference>> Put(Preference preference);
        Task<ActionResult<Preference>> AddOrChange(string VariableName, string VariableValue);
        Task<ActionResult<Preference>> GetWithVariableName(string VariableName);
    }
    public partial class PreferenceService : ControllerBase, IPreferenceService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLoginContext dbLogin { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public PreferenceService(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IEnums enums, CSSPDBLoginContext dbLogin)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.dbLogin = dbLogin;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<Preference>> AddOrChange(string VariableName, string VariableValue)
        {
            //if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            //{
            //    return await Task.FromResult(Unauthorized());
            //}

            Preference preference = (from c in dbLogin.Preferences
                                          where c.VariableName == VariableName
                                          select c).FirstOrDefault();

            if (preference == null)
            {
                int? LastID = (from c in dbLogin.Preferences
                               orderby c.PreferenceID descending
                               select c.PreferenceID).FirstOrDefault();

                LastID = LastID == null ? LastID = 1 : LastID + 1;

                return await Post(new Preference() { PreferenceID = (int)LastID, VariableName = VariableName, VariableValue = await LocalService.Scramble(VariableValue) });
            }
            else
            {
                preference.VariableValue = await LocalService.Scramble(VariableValue);
                return await Put(preference);
            }
        }
        public async Task<ActionResult<Preference>> GetAddressWithPreferenceID(int PreferenceID)
        {
            //if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            //{
            //    return await Task.FromResult(Unauthorized());
            //}

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
            //if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            //{
            //    return await Task.FromResult(Unauthorized());
            //}

            List<Preference> preferenceList = (from c in dbLogin.Preferences.AsNoTracking() orderby c.PreferenceID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(preferenceList));
        }
        public async Task<ActionResult<Preference>> GetWithVariableName(string VariableName)
        {
            //if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            //{
            //    return await Task.FromResult(Unauthorized());
            //}

            Preference preference = (from c in dbLogin.Preferences.AsNoTracking()
                                     where c.VariableName == VariableName
                                     select c).FirstOrDefault();

            if (preference == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(new Preference() { 
                PreferenceID = preference.PreferenceID, 
                VariableName = VariableName, 
                VariableValue = await LocalService.Descramble(preference.VariableValue) 
            }));
        }
        public async Task<ActionResult<bool>> Delete(int PreferenceID)
        {
            //if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            //{
            //    return await Task.FromResult(Unauthorized());
            //}

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
            //if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            //{
            //    return await Task.FromResult(Unauthorized());
            //}

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
            //if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            //{
            //    return await Task.FromResult(Unauthorized());
            //}

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

            // doing VariableName
            if (string.IsNullOrWhiteSpace(preference.VariableName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "VariableName"), new[] { nameof(preference.VariableName) });
            }

            if (!string.IsNullOrWhiteSpace(preference.VariableName) && preference.VariableName.Length > 300)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "VariableName", "300"), new[] { nameof(preference.VariableName) });
            }

            // doing VariableValue
            if (string.IsNullOrWhiteSpace(preference.VariableValue))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "VariableValue"), new[] { nameof(preference.VariableValue) });
            }

            if (!string.IsNullOrWhiteSpace(preference.VariableValue) && preference.VariableValue.Length > 300)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "VariableValue", "300"), new[] { nameof(preference.VariableValue) });
            }
        }
        #endregion Functions private

    }
}
