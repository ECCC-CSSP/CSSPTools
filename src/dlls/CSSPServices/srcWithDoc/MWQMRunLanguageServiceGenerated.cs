/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPServices
{
    /// <summary>
    /// > [!NOTE]
    /// > 
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [MWQMRunLanguageController](CSSPWebAPI.Controllers.MWQMRunLanguageController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.MWQMRunLanguage](CSSPModels.MWQMRunLanguage.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [LanguageEnum](CSSPEnums.LanguageEnum.html), [TranslationStatusEnum](CSSPEnums.TranslationStatusEnum.html), [TranslationStatusEnum](CSSPEnums.TranslationStatusEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class MWQMRunLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB MWQMRunLanguages table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public MWQMRunLanguageService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all MWQMRunLanguageService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMRunLanguage mwqmRunLanguage = validationContext.ObjectInstance as MWQMRunLanguage;
            mwqmRunLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmRunLanguage.MWQMRunLanguageID == 0)
                {
                    mwqmRunLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageID"), new[] { "MWQMRunLanguageID" });
                }

                if (!(from c in db.MWQMRunLanguages select c).Where(c => c.MWQMRunLanguageID == mwqmRunLanguage.MWQMRunLanguageID).Any())
                {
                    mwqmRunLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageID", mwqmRunLanguage.MWQMRunLanguageID.ToString()), new[] { "MWQMRunLanguageID" });
                }
            }

            MWQMRun MWQMRunMWQMRunID = (from c in db.MWQMRuns where c.MWQMRunID == mwqmRunLanguage.MWQMRunID select c).FirstOrDefault();

            if (MWQMRunMWQMRunID == null)
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunID", mwqmRunLanguage.MWQMRunID.ToString()), new[] { "MWQMRunID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)mwqmRunLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunComment))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RunComment"), new[] { "RunComment" });
            }

            //RunComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunComment);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TranslationStatusRunComment"), new[] { "TranslationStatusRunComment" });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunWeatherComment))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RunWeatherComment"), new[] { "RunWeatherComment" });
            }

            //RunWeatherComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunWeatherComment);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TranslationStatusRunWeatherComment"), new[] { "TranslationStatusRunWeatherComment" });
            }

            if (mwqmRunLanguage.LastUpdateDate_UTC.Year == 1)
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmRunLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmRunLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRunLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmRunLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmRunLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the MWQMRunLanguage model with the MWQMRunLanguageID identifier
        /// </summary>
        /// <param name="MWQMRunLanguageID">Is the identifier of [MWQMRunLanguages](CSSPModels.MWQMRunLanguage.html) table of CSSPDB</param>
        /// <returns>[MWQMRunLanguage](CSSPModels.MWQMRunLanguage.html) object connected to the CSSPDB</returns>
        public MWQMRunLanguage GetMWQMRunLanguageWithMWQMRunLanguageID(int MWQMRunLanguageID)
        {
            return (from c in db.MWQMRunLanguages
                    where c.MWQMRunLanguageID == MWQMRunLanguageID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [MWQMRunLanguage](CSSPModels.MWQMRunLanguage.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [MWQMRunLanguage](CSSPModels.MWQMRunLanguage.html)</returns>
        public IQueryable<MWQMRunLanguage> GetMWQMRunLanguageList()
        {
            IQueryable<MWQMRunLanguage> MWQMRunLanguageQuery = (from c in db.MWQMRunLanguages select c);

            MWQMRunLanguageQuery = EnhanceQueryStatements<MWQMRunLanguage>(MWQMRunLanguageQuery) as IQueryable<MWQMRunLanguage>;

            return MWQMRunLanguageQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [MWQMRunLanguage](CSSPModels.MWQMRunLanguage.html) item in CSSPDB
        /// </summary>
        /// <param name="mwqmRunLanguage">Is the MWQMRunLanguage item the client want to add to CSSPDB</param>
        /// <returns>true if MWQMRunLanguage item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(MWQMRunLanguage mwqmRunLanguage)
        {
            mwqmRunLanguage.ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Create);
            if (mwqmRunLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMRunLanguages.Add(mwqmRunLanguage);

            if (!TryToSave(mwqmRunLanguage)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [MWQMRunLanguage](CSSPModels.MWQMRunLanguage.html) item in CSSPDB
        /// </summary>
        /// <param name="mwqmRunLanguage">Is the MWQMRunLanguage item the client want to add to CSSPDB. What's important here is the MWQMRunLanguageID</param>
        /// <returns>true if MWQMRunLanguage item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(MWQMRunLanguage mwqmRunLanguage)
        {
            mwqmRunLanguage.ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Delete);
            if (mwqmRunLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMRunLanguages.Remove(mwqmRunLanguage);

            if (!TryToSave(mwqmRunLanguage)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [MWQMRunLanguage](CSSPModels.MWQMRunLanguage.html) item in CSSPDB
        /// </summary>
        /// <param name="mwqmRunLanguage">Is the MWQMRunLanguage item the client want to add to CSSPDB. What's important here is the MWQMRunLanguageID</param>
        /// <returns>true if MWQMRunLanguage item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(MWQMRunLanguage mwqmRunLanguage)
        {
            mwqmRunLanguage.ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Update);
            if (mwqmRunLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMRunLanguages.Update(mwqmRunLanguage);

            if (!TryToSave(mwqmRunLanguage)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [MWQMRunLanguage](CSSPModels.MWQMRunLanguage.html) item
        /// </summary>
        /// <param name="mwqmRunLanguage">Is the MWQMRunLanguage item the client want to add to CSSPDB. What's important here is the MWQMRunLanguageID</param>
        /// <returns>true if MWQMRunLanguage item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(MWQMRunLanguage mwqmRunLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmRunLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
