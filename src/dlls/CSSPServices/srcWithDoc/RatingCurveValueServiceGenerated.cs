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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [RatingCurveValueController](CSSPWebAPI.Controllers.RatingCurveValueController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.RatingCurveValue](CSSPModels.RatingCurveValue.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class RatingCurveValueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB RatingCurveValues table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public RatingCurveValueService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all RatingCurveValueService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            RatingCurveValue ratingCurveValue = validationContext.ObjectInstance as RatingCurveValue;
            ratingCurveValue.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (ratingCurveValue.RatingCurveValueID == 0)
                {
                    ratingCurveValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RatingCurveValueID"), new[] { "RatingCurveValueID" });
                }

                if (!(from c in db.RatingCurveValues select c).Where(c => c.RatingCurveValueID == ratingCurveValue.RatingCurveValueID).Any())
                {
                    ratingCurveValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "RatingCurveValue", "RatingCurveValueID", ratingCurveValue.RatingCurveValueID.ToString()), new[] { "RatingCurveValueID" });
                }
            }

            RatingCurve RatingCurveRatingCurveID = (from c in db.RatingCurves where c.RatingCurveID == ratingCurveValue.RatingCurveID select c).FirstOrDefault();

            if (RatingCurveRatingCurveID == null)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveID", ratingCurveValue.RatingCurveID.ToString()), new[] { "RatingCurveID" });
            }

            if (ratingCurveValue.StageValue_m < 0 || ratingCurveValue.StageValue_m > 1000)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "StageValue_m", "0", "1000"), new[] { "StageValue_m" });
            }

            if (ratingCurveValue.DischargeValue_m3_s < 0 || ratingCurveValue.DischargeValue_m3_s > 1000000)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DischargeValue_m3_s", "0", "1000000"), new[] { "DischargeValue_m3_s" });
            }

            if (ratingCurveValue.LastUpdateDate_UTC.Year == 1)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (ratingCurveValue.LastUpdateDate_UTC.Year < 1980)
                {
                ratingCurveValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == ratingCurveValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", ratingCurveValue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ratingCurveValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the RatingCurveValue model with the RatingCurveValueID identifier
        /// </summary>
        /// <param name="RatingCurveValueID">Is the identifier of [RatingCurveValues](CSSPModels.RatingCurveValue.html) table of CSSPDB</param>
        /// <returns>[RatingCurveValue](CSSPModels.RatingCurveValue.html) object connected to the CSSPDB</returns>
        public RatingCurveValue GetRatingCurveValueWithRatingCurveValueID(int RatingCurveValueID)
        {
            return (from c in db.RatingCurveValues
                    where c.RatingCurveValueID == RatingCurveValueID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [RatingCurveValue](CSSPModels.RatingCurveValue.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [RatingCurveValue](CSSPModels.RatingCurveValue.html)</returns>
        public IQueryable<RatingCurveValue> GetRatingCurveValueList()
        {
            IQueryable<RatingCurveValue> RatingCurveValueQuery = (from c in db.RatingCurveValues select c);

            RatingCurveValueQuery = EnhanceQueryStatements<RatingCurveValue>(RatingCurveValueQuery) as IQueryable<RatingCurveValue>;

            return RatingCurveValueQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [RatingCurveValue](CSSPModels.RatingCurveValue.html) item in CSSPDB
        /// </summary>
        /// <param name="ratingCurveValue">Is the RatingCurveValue item the client want to add to CSSPDB</param>
        /// <returns>true if RatingCurveValue item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(RatingCurveValue ratingCurveValue)
        {
            ratingCurveValue.ValidationResults = Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Create);
            if (ratingCurveValue.ValidationResults.Count() > 0) return false;

            db.RatingCurveValues.Add(ratingCurveValue);

            if (!TryToSave(ratingCurveValue)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [RatingCurveValue](CSSPModels.RatingCurveValue.html) item in CSSPDB
        /// </summary>
        /// <param name="ratingCurveValue">Is the RatingCurveValue item the client want to add to CSSPDB. What's important here is the RatingCurveValueID</param>
        /// <returns>true if RatingCurveValue item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(RatingCurveValue ratingCurveValue)
        {
            ratingCurveValue.ValidationResults = Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Delete);
            if (ratingCurveValue.ValidationResults.Count() > 0) return false;

            db.RatingCurveValues.Remove(ratingCurveValue);

            if (!TryToSave(ratingCurveValue)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [RatingCurveValue](CSSPModels.RatingCurveValue.html) item in CSSPDB
        /// </summary>
        /// <param name="ratingCurveValue">Is the RatingCurveValue item the client want to add to CSSPDB. What's important here is the RatingCurveValueID</param>
        /// <returns>true if RatingCurveValue item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(RatingCurveValue ratingCurveValue)
        {
            ratingCurveValue.ValidationResults = Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Update);
            if (ratingCurveValue.ValidationResults.Count() > 0) return false;

            db.RatingCurveValues.Update(ratingCurveValue);

            if (!TryToSave(ratingCurveValue)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [RatingCurveValue](CSSPModels.RatingCurveValue.html) item
        /// </summary>
        /// <param name="ratingCurveValue">Is the RatingCurveValue item the client want to add to CSSPDB. What's important here is the RatingCurveValueID</param>
        /// <returns>true if RatingCurveValue item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(RatingCurveValue ratingCurveValue)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                ratingCurveValue.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
