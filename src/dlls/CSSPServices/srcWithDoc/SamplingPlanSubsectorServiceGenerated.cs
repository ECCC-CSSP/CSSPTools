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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [SamplingPlanSubsectorController](CSSPWebAPI.Controllers.SamplingPlanSubsectorController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.SamplingPlanSubsector](CSSPModels.SamplingPlanSubsector.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class SamplingPlanSubsectorService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB SamplingPlanSubsectors table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public SamplingPlanSubsectorService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all SamplingPlanSubsectorService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SamplingPlanSubsector samplingPlanSubsector = validationContext.ObjectInstance as SamplingPlanSubsector;
            samplingPlanSubsector.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (samplingPlanSubsector.SamplingPlanSubsectorID == 0)
                {
                    samplingPlanSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSubsectorID"), new[] { "SamplingPlanSubsectorID" });
                }

                if (!(from c in db.SamplingPlanSubsectors select c).Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).Any())
                {
                    samplingPlanSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", samplingPlanSubsector.SamplingPlanSubsectorID.ToString()), new[] { "SamplingPlanSubsectorID" });
                }
            }

            SamplingPlan SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == samplingPlanSubsector.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", samplingPlanSubsector.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
            }

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsector.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SubsectorTVItemID", samplingPlanSubsector.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    samplingPlanSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            if (samplingPlanSubsector.LastUpdateDate_UTC.Year == 1)
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlanSubsector.LastUpdateDate_UTC.Year < 1980)
                {
                samplingPlanSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", samplingPlanSubsector.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    samplingPlanSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the SamplingPlanSubsector model with the SamplingPlanSubsectorID identifier
        /// </summary>
        /// <param name="SamplingPlanSubsectorID">Is the identifier of [SamplingPlanSubsectors](CSSPModels.SamplingPlanSubsector.html) table of CSSPDB</param>
        /// <returns>[SamplingPlanSubsector](CSSPModels.SamplingPlanSubsector.html) object connected to the CSSPDB</returns>
        public SamplingPlanSubsector GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(int SamplingPlanSubsectorID)
        {
            return (from c in db.SamplingPlanSubsectors
                    where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [SamplingPlanSubsector](CSSPModels.SamplingPlanSubsector.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [SamplingPlanSubsector](CSSPModels.SamplingPlanSubsector.html)</returns>
        public IQueryable<SamplingPlanSubsector> GetSamplingPlanSubsectorList()
        {
            IQueryable<SamplingPlanSubsector> SamplingPlanSubsectorQuery = (from c in db.SamplingPlanSubsectors select c);

            SamplingPlanSubsectorQuery = EnhanceQueryStatements<SamplingPlanSubsector>(SamplingPlanSubsectorQuery) as IQueryable<SamplingPlanSubsector>;

            return SamplingPlanSubsectorQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [SamplingPlanSubsector](CSSPModels.SamplingPlanSubsector.html) item in CSSPDB
        /// </summary>
        /// <param name="samplingPlanSubsector">Is the SamplingPlanSubsector item the client want to add to CSSPDB</param>
        /// <returns>true if SamplingPlanSubsector item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(SamplingPlanSubsector samplingPlanSubsector)
        {
            samplingPlanSubsector.ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Create);
            if (samplingPlanSubsector.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectors.Add(samplingPlanSubsector);

            if (!TryToSave(samplingPlanSubsector)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [SamplingPlanSubsector](CSSPModels.SamplingPlanSubsector.html) item in CSSPDB
        /// </summary>
        /// <param name="samplingPlanSubsector">Is the SamplingPlanSubsector item the client want to add to CSSPDB. What's important here is the SamplingPlanSubsectorID</param>
        /// <returns>true if SamplingPlanSubsector item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(SamplingPlanSubsector samplingPlanSubsector)
        {
            samplingPlanSubsector.ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Delete);
            if (samplingPlanSubsector.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectors.Remove(samplingPlanSubsector);

            if (!TryToSave(samplingPlanSubsector)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [SamplingPlanSubsector](CSSPModels.SamplingPlanSubsector.html) item in CSSPDB
        /// </summary>
        /// <param name="samplingPlanSubsector">Is the SamplingPlanSubsector item the client want to add to CSSPDB. What's important here is the SamplingPlanSubsectorID</param>
        /// <returns>true if SamplingPlanSubsector item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(SamplingPlanSubsector samplingPlanSubsector)
        {
            samplingPlanSubsector.ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Update);
            if (samplingPlanSubsector.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectors.Update(samplingPlanSubsector);

            if (!TryToSave(samplingPlanSubsector)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [SamplingPlanSubsector](CSSPModels.SamplingPlanSubsector.html) item
        /// </summary>
        /// <param name="samplingPlanSubsector">Is the SamplingPlanSubsector item the client want to add to CSSPDB. What's important here is the SamplingPlanSubsectorID</param>
        /// <returns>true if SamplingPlanSubsector item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(SamplingPlanSubsector samplingPlanSubsector)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                samplingPlanSubsector.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
