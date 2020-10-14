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
        Task<string> Descramble(string Text);
        Task<string> Scramble(string Text);
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
        private CSSPDBLoginContext dbLogin { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        private List<int> skip { get; set; } = new List<int>()
        {
            3, 1, -3, 2, 2, 0, 4, 1, -2, 2, -1, 3, -2, 0, 1, 3, 1, 2, -4, -1, 1, 2, 0, 2, 1,
            -1, 4, -4, 2, 3, 1, 2, 3, 1, 2, 3, 1, 3, 1, -2, -1, -1, 4, -2, 2, -3, 2, 2, 0, 4,
            3, 1, 1, -2, -1, 3, -2, 0, 3, 2, 0, 1, 4, 1, 1, -4, -1, 2, 0, 2, 1, -3, 2, -2, -1, 3, -2, 0, 3, 1, -4, -1, 2, 0, 2, 1,
            -2, 3, 1, -3, 2, 3, -2, -1, 4, 1, -2, 2, 2, -1, 0, 4, 1, -2, -1, 3, -2, 0, 3, -1, 1, -4, -1, 2, 0, 2, 1,
            -1, 2, 3, 2, 1, -3, 2, 3, 2, 0, 4, 1, 2, -2, -1, 0, 3, -2, 0, 3, 1, -4, -1, 3, 2, 0, 2, 1,
            -4, 3, 1, -3, 1, 2, 2, 0, 1, 2, 4, 1, -1, 3, -1, -2, -1, 3, -2, 0, 3, 1, -4, -1, 2, 0, -1, 2, 1,
            1, 3, 4, 1, -3, -2, 2, 2, 0, -1, 4, 1, -2, -1, 3, 2, -2, 0, 1, 3, 1, -2, -4, -1, -1, 2, 0, 2, 1,
            4, 3, -2, -1, 2, 0, 2, -1, 4, 2, 0, 1, -1, -1, -3, -2, 2, -4, 3, 2, 1, -3, 2, -1, 2, 4, 0, 0, 1,
            2, 1, -2, -4, 1, 3, -3, 1, -1, 2, 1, 0, 4, -1, 1, -1, -3, 1, 1, -3, -4, 1, -3, 1, -3, 1, -1, 0,
            4, 2, 1, -3, 1, -2, 1, -4, 1, -2, 0, 3, -1, 4, 1, -2, 1, 0, -4, -1, -3, 2, 1, 4, -1, 1, 2, 4, 2
        };

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
        public async Task<string> Descramble(string Text)
        {
            string retStr = "";
            if (string.IsNullOrWhiteSpace(Text)) return "";

            string retStr2 = "";
            int length = Text.Length - 1;
            for (int j = length; j > -1; j--)
            {
                retStr2 += Text[j].ToString();
            }

            Text = retStr2;

            int Start = int.Parse(Text.Substring(0, 1));

            Text = Text.Substring(1);
            int i = 0;
            foreach (char c in Text)
            {
                retStr += (char)((int)c - skip[i + Start]);
                i += 1;
            }

            return await Task.FromResult(retStr);
        }
        public async Task<string> Scramble(string Text)
        {
            Random r = new Random();
            int Start = r.Next(1, 9);

            if (Text.Length == 0) return await Task.FromResult("");

            string retStr = Start.ToString();
            int i = 0;
            foreach (char c in Text)
            {
                retStr += (char)((int)c + skip[i + Start]);
                i += 1;
            }

            string retStr2 = "";
            int length = retStr.Length - 1;
            for (int j = length; j > -1; j--)
            {
                retStr2 += retStr[j].ToString();
            }

            return await Task.FromResult(retStr2);
        }
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

            Preference preference = (from c in dbLogin.Preferences.AsNoTracking()
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
                VariableValue = await Descramble(preference.VariableValue),
            };

            return await Task.FromResult(Ok(preferenceToReturn));
        }
        public async Task<ActionResult<List<Preference>>> GetPreferenceList(int skip = 0, int take = 100)
        {
            //if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            //{
            //    return await Task.FromResult(Unauthorized());
            //}

            List<Preference> preferenceList = (from c in dbLogin.Preferences.AsNoTracking() orderby c.PreferenceID select c).Skip(skip).Take(take).ToList();

            List<Preference> preferenceListToReturn = new List<Preference>();

            foreach (Preference preference in preferenceList)
            {
                preferenceListToReturn.Add(new Preference()
                {
                    PreferenceID = preference.PreferenceID,
                    VariableName = preference.VariableName,
                    VariableValue = await Descramble(preference.VariableValue),
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

            Preference preference = (from c in dbLogin.Preferences.AsNoTracking()
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
                VariableValue = await Descramble(preference.VariableValue)
            };

            return await Task.FromResult(Ok(preferenceToReturn));
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

            int? LastIndex = (from c in dbLogin.Preferences
                              orderby c.PreferenceID descending
                              select c.PreferenceID).FirstOrDefault();

            LastIndex = LastIndex == null ? 1 : LastIndex + 1;

            string VariableValue = preference.VariableValue;

            try
            {
                preference.PreferenceID = (int)LastIndex;
                preference.VariableValue = await Scramble(preference.VariableValue);
                dbLogin.Preferences.Add(preference);
                dbLogin.SaveChanges();
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
                preference.VariableValue = await Scramble(preference.VariableValue);
                dbLogin.Preferences.Update(preference);
                dbLogin.SaveChanges();
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
