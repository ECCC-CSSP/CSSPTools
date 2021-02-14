/*
 * Manually edited
 *
 */

using CSSPEnums;
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
//using LocalServices;
using CSSPDBPreferenceModels;
using CSSPScrambleServices;

namespace CSSPDBPreferenceServices
{
    public partial interface IPreferenceService
    {
        Task<ActionResult<bool>> Delete(int PreferenceID);
        Task<ActionResult<List<Preference>>> GetPreferenceList(int skip = 0, int take = 100);
        Task<ActionResult<Preference>> GetPreferenceWithPreferenceID(int PreferenceID);
        Task<ActionResult<Preference>> Post(Preference preference);
        Task<ActionResult<Preference>> Put(Preference preference);
        Task<ActionResult<Preference>> AddOrChange(string VariableName, string VariableValue);
        Task<ActionResult<Preference>> GetPreferenceWithVariableName(string VariableName);
    }
    public partial class PreferenceService : ControllerBase, IPreferenceService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBPreferenceContext dbPreference { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IScrambleService ScrambleService { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }

        #endregion Properties

        #region Constructors
        public PreferenceService(ICSSPCultureService CSSPCultureService, IScrambleService ScrambleService, IEnums enums, CSSPDBPreferenceContext dbPreference)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.ScrambleService = ScrambleService;
            this.dbPreference = dbPreference;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<Preference>> AddOrChange(string VariableName, string VariableValue)
        {
            //if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            //{
            //    return await Task.FromResult(Unauthorized());
            //}

            Preference preference = (from c in dbPreference.Preferences
                                     where c.VariableName == VariableName
                                     select c).FirstOrDefault();

            if (preference == null)
            {
                return await Post(new Preference() { PreferenceID = 0, VariableName = VariableName, VariableValue = VariableValue });
            }
            else
            {
                preference.VariableValue = VariableValue;
                return await Put(preference);
            }
        }
        public async Task<ActionResult<Preference>> GetPreferenceWithPreferenceID(int PreferenceID)
        {
            //if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            //{
            //    return await Task.FromResult(Unauthorized());
            //}

            Preference preference = (from c in dbPreference.Preferences.AsNoTracking()
                                     where c.PreferenceID == PreferenceID
                                     select c).FirstOrDefault();

            if (preference == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Preference", "PreferenceID", PreferenceID.ToString())));
            }

            Preference preferenceToReturn = new Preference()
            {
                PreferenceID = preference.PreferenceID,
                VariableName = preference.VariableName,
                VariableValue = await ScrambleService.Descramble(preference.VariableValue),
            };

            return await Task.FromResult(Ok(preferenceToReturn));
        }
        public async Task<ActionResult<List<Preference>>> GetPreferenceList(int skip = 0, int take = 100)
        {
            //if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            //{
            //    return await Task.FromResult(Unauthorized());
            //}

            List<Preference> preferenceList = (from c in dbPreference.Preferences.AsNoTracking() orderby c.PreferenceID select c).Skip(skip).Take(take).ToList();

            List<Preference> preferenceListToReturn = new List<Preference>();

            foreach (Preference preference in preferenceList)
            {
                preferenceListToReturn.Add(new Preference()
                {
                    PreferenceID = preference.PreferenceID,
                    VariableName = preference.VariableName,
                    VariableValue = await ScrambleService.Descramble(preference.VariableValue),
                });
            }

            return await Task.FromResult(Ok(preferenceListToReturn));
        }
        public async Task<ActionResult<Preference>> GetPreferenceWithVariableName(string VariableName)
        {
            //if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            //{
            //    return await Task.FromResult(Unauthorized());
            //}

            Preference preference = (from c in dbPreference.Preferences.AsNoTracking()
                                     where c.VariableName == VariableName
                                     select c).FirstOrDefault();

            if (preference == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Preference", "VariableName", VariableName)));
            }

            Preference preferenceToReturn = new Preference()
            {
                PreferenceID = preference.PreferenceID,
                VariableName = VariableName,
                VariableValue = await ScrambleService.Descramble(preference.VariableValue)
            };

            return await Task.FromResult(Ok(preferenceToReturn));
        }
        public async Task<ActionResult<bool>> Delete(int PreferenceID)
        {
            //if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            //{
            //    return await Task.FromResult(Unauthorized());
            //}

            Preference preference = (from c in dbPreference.Preferences
                                     where c.PreferenceID == PreferenceID
                                     select c).FirstOrDefault();

            if (preference == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Preference", "PreferenceID", PreferenceID.ToString())));
            }

            try
            {
                dbPreference.Preferences.Remove(preference);
                dbPreference.SaveChanges();
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

            int? LastIndex = (from c in dbPreference.Preferences
                              orderby c.PreferenceID descending
                              select c.PreferenceID).FirstOrDefault();

            LastIndex = LastIndex == null ? 1 : LastIndex + 1;

            string VariableValue = preference.VariableValue;

            try
            {
                preference.PreferenceID = (int)LastIndex;
                preference.VariableValue = await ScrambleService.Scramble(preference.VariableValue);
                dbPreference.Preferences.Add(preference);
                dbPreference.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            Preference preferenceToReturn = new Preference()
            {
                PreferenceID = preference.PreferenceID,
                VariableName = preference.VariableName,
                VariableValue = VariableValue,
            };

            return await Task.FromResult(Ok(preferenceToReturn));
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

            string VariableValue = preference.VariableValue;

            try
            {
                preference.VariableValue = await ScrambleService.Scramble(preference.VariableValue);
                dbPreference.Preferences.Update(preference);
                dbPreference.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            Preference preferenceToReturn = new Preference()
            {
                PreferenceID = preference.PreferenceID,
                VariableName = preference.VariableName,
                VariableValue = VariableValue,
            };

            return await Task.FromResult(Ok(preferenceToReturn));
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

                if (!(from c in dbPreference.Preferences select c).Where(c => c.PreferenceID == preference.PreferenceID).Any())
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
