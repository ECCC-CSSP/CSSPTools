///*
// * Manually edited
// *
// */

//using CSSPEnums;
//using CSSPCultureServices.Resources;
//using CSSPCultureServices.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using CSSPDBPreferenceModels;
//using CSSPScrambleServices;
//using LoggedInServices;

//namespace PreferenceServices
//{
//    public partial interface IPreferenceService
//    {
//        Task<ActionResult<Preference>> AddOrModify(Preference preference);
//        Task<ActionResult<bool>> Delete(int PreferenceID);
//        Task<ActionResult<List<Preference>>> GetPreferenceList();
//    }
//    public partial class PreferenceService : ControllerBase, IPreferenceService
//    {
//        #region Variables
//        #endregion Variables

//        #region Properties
//        private CSSPDBPreferenceContext dbPreference { get; }
//        private ICSSPCultureService CSSPCultureService { get; }
//        private IScrambleService ScrambleService { get; }
//        private ILoggedInService LoggedInService { get; }
//        private IEnumerable<ValidationResult> ValidationResults { get; set; }

//        #endregion Properties

//        #region Constructors
//        public PreferenceService(ICSSPCultureService CSSPCultureService, IScrambleService ScrambleService,
//            ILoggedInService LoggedInService, CSSPDBPreferenceContext dbPreference)
//        {
//            this.CSSPCultureService = CSSPCultureService;
//            this.ScrambleService = ScrambleService;
//            this.LoggedInService = LoggedInService;
//            this.dbPreference = dbPreference;
//        }
//        #endregion Constructors

//        #region Functions public 
//        public async Task<ActionResult<Preference>> AddOrModify(Preference preference)
//        {
//            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
//            {
//                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
//            }

//            ValidationResults = ValidateAndAddOrModify(new ValidationContext(preference));
//            if (ValidationResults.Count() > 0)
//            {
//                return await Task.FromResult(BadRequest(ValidationResults));
//            }

//            return await DoAddOrModify(preference);
//        }
//        public async Task<ActionResult<bool>> Delete(int PreferenceID)
//        {
//            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
//            {
//                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
//            }

//            Preference preference = (from c in dbPreference.Preferences
//                                     where c.PreferenceID == PreferenceID
//                                     select c).FirstOrDefault();

//            if (preference == null)
//            {
//                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Preference", "PreferenceID", PreferenceID.ToString())));
//            }

//            try
//            {
//                dbPreference.Preferences.Remove(preference);
//                dbPreference.SaveChanges();
//            }
//            catch (DbUpdateException ex)
//            {
//                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
//            }

//            return await Task.FromResult(Ok(true));
//        }
//        public async Task<ActionResult<List<Preference>>> GetPreferenceList()
//        {
//            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
//            {
//                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
//            }

//            List<Preference> preferenceList = (from c in dbPreference.Preferences.AsNoTracking() orderby c.PreferenceID select c).ToList();

//            List<Preference> preferenceListToReturn = new List<Preference>();

//            foreach (Preference preference in preferenceList)
//            {
//                preferenceListToReturn.Add(new Preference()
//                {
//                    PreferenceID = preference.PreferenceID,
//                    VariableName = preference.VariableName,
//                    VariableValue = ScrambleService.Descramble(preference.VariableValue),
//                });
//            }

//            return await Task.FromResult(Ok(preferenceListToReturn));
//        }
//        #endregion Functions public

//        #region Functions private
//        private async Task<ActionResult<Preference>> DoAddOrModify(Preference preference)
//        {
//            string VariableValue = preference.VariableValue;

//            if (preference.PreferenceID == 0) // add
//            {
//                int? LastIndex = (from c in dbPreference.Preferences
//                                  orderby c.PreferenceID descending
//                                  select c.PreferenceID).FirstOrDefault();

//                LastIndex = LastIndex == null ? 1 : LastIndex + 1;

//                preference.PreferenceID = (int)LastIndex;
//                preference.VariableValue = ScrambleService.Scramble(VariableValue);
//                dbPreference.Preferences.Add(preference);
//            }
//            else // modify
//            {
//                Preference preferenceToModify = (from c in dbPreference.Preferences
//                                                 where c.PreferenceID == preference.PreferenceID
//                                                 select c).FirstOrDefault();

//                if (preferenceToModify == null)
//                {
//                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Preference", "PreferenceID", preference.PreferenceID.ToString())));
//                }

//                preferenceToModify.VariableValue = ScrambleService.Scramble(VariableValue);
//            }

//            try
//            {
//                dbPreference.SaveChanges();
//            }
//            catch (DbUpdateException ex)
//            {
//                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
//            }

//            Preference preferenceNewOrModify = new Preference()
//            {
//                PreferenceID = preference.PreferenceID,
//                VariableName = preference.VariableName,
//                VariableValue = VariableValue,
//            };

//            return await Task.FromResult(Ok(preferenceNewOrModify));
//        }
//        private IEnumerable<ValidationResult> ValidateAndAddOrModify(ValidationContext validationContext)
//        {
//            Preference preference = validationContext.ObjectInstance as Preference;

//            // doing VariableName
//            if (string.IsNullOrWhiteSpace(preference.VariableName))
//            {
//                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "VariableName"), new[] { "VariableName" });
//            }

//            if (!string.IsNullOrWhiteSpace(preference.VariableName) && preference.VariableName.Length > 300)
//            {
//                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "VariableName", "300"), new[] { "VariableName" });
//            }

//            // doing VariableValue
//            if (string.IsNullOrWhiteSpace(preference.VariableValue))
//            {
//                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "VariableValue"), new[] { "VariableValue" });
//            }

//            if (!string.IsNullOrWhiteSpace(preference.VariableValue) && preference.VariableValue.Length > 300)
//            {
//                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "VariableValue", "300"), new[] { "VariableValue" });
//            }

//            if (preference.PreferenceID == 0) // adding so should not already exist
//            {
//                Preference preferenceAlreadyExist = (from c in dbPreference.Preferences
//                                                     where c.VariableName == preference.VariableName
//                                                     select c).FirstOrDefault();

//                if (preferenceAlreadyExist != null)
//                {
//                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._AlreadyExists, "Preference"), new[] { "" });
//                }
//            }
//            else // modifying so should exist
//            {
//                Preference preferenceExist = (from c in dbPreference.Preferences
//                                              where c.VariableName == preference.VariableName
//                                              select c).FirstOrDefault();

//                if (preferenceExist == null)
//                {
//                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Preference", "VariableName", preference.VariableName), new[] { "" });
//                }
//            }
//        }
//        #endregion Functions private

//    }
//}
