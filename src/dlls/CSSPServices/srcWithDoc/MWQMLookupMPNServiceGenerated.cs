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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [MWQMLookupMPNController](CSSPWebAPI.Controllers.MWQMLookupMPNController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.MWQMLookupMPN](CSSPModels.MWQMLookupMPN.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class MWQMLookupMPNService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB MWQMLookupMPNs table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public MWQMLookupMPNService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all MWQMLookupMPNService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMLookupMPN mwqmLookupMPN = validationContext.ObjectInstance as MWQMLookupMPN;
            mwqmLookupMPN.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmLookupMPN.MWQMLookupMPNID == 0)
                {
                    mwqmLookupMPN.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMLookupMPNID"), new[] { "MWQMLookupMPNID" });
                }

                if (!(from c in db.MWQMLookupMPNs select c).Where(c => c.MWQMLookupMPNID == mwqmLookupMPN.MWQMLookupMPNID).Any())
                {
                    mwqmLookupMPN.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMLookupMPN", "MWQMLookupMPNID", mwqmLookupMPN.MWQMLookupMPNID.ToString()), new[] { "MWQMLookupMPNID" });
                }
            }

            if (mwqmLookupMPN.Tubes10 < 0 || mwqmLookupMPN.Tubes10 > 5)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Tubes10", "0", "5"), new[] { "Tubes10" });
            }

            if (mwqmLookupMPN.Tubes1 < 0 || mwqmLookupMPN.Tubes1 > 5)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Tubes1", "0", "5"), new[] { "Tubes1" });
            }

            if (mwqmLookupMPN.Tubes01 < 0 || mwqmLookupMPN.Tubes01 > 5)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Tubes01", "0", "5"), new[] { "Tubes01" });
            }

            if (mwqmLookupMPN.MPN_100ml < 1 || mwqmLookupMPN.MPN_100ml > 10000)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MPN_100ml", "1", "10000"), new[] { "MPN_100ml" });
            }

            if (mwqmLookupMPN.LastUpdateDate_UTC.Year == 1)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmLookupMPN.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmLookupMPN.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmLookupMPN.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmLookupMPN.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmLookupMPN.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the MWQMLookupMPN model with the MWQMLookupMPNID identifier
        /// </summary>
        /// <param name="MWQMLookupMPNID">Is the identifier of [MWQMLookupMPNs](CSSPModels.MWQMLookupMPN.html) table of CSSPDB</param>
        /// <returns>[MWQMLookupMPN](CSSPModels.MWQMLookupMPN.html) object connected to the CSSPDB</returns>
        public MWQMLookupMPN GetMWQMLookupMPNWithMWQMLookupMPNID(int MWQMLookupMPNID)
        {
            return (from c in db.MWQMLookupMPNs
                    where c.MWQMLookupMPNID == MWQMLookupMPNID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [MWQMLookupMPN](CSSPModels.MWQMLookupMPN.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [MWQMLookupMPN](CSSPModels.MWQMLookupMPN.html)</returns>
        public IQueryable<MWQMLookupMPN> GetMWQMLookupMPNList()
        {
            IQueryable<MWQMLookupMPN> MWQMLookupMPNQuery = (from c in db.MWQMLookupMPNs select c);

            MWQMLookupMPNQuery = EnhanceQueryStatements<MWQMLookupMPN>(MWQMLookupMPNQuery) as IQueryable<MWQMLookupMPN>;

            return MWQMLookupMPNQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [MWQMLookupMPN](CSSPModels.MWQMLookupMPN.html) item in CSSPDB
        /// </summary>
        /// <param name="mwqmLookupMPN">Is the MWQMLookupMPN item the client want to add to CSSPDB</param>
        /// <returns>true if MWQMLookupMPN item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(MWQMLookupMPN mwqmLookupMPN)
        {
            mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Create);
            if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;

            db.MWQMLookupMPNs.Add(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [MWQMLookupMPN](CSSPModels.MWQMLookupMPN.html) item in CSSPDB
        /// </summary>
        /// <param name="mwqmLookupMPN">Is the MWQMLookupMPN item the client want to add to CSSPDB. What's important here is the MWQMLookupMPNID</param>
        /// <returns>true if MWQMLookupMPN item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(MWQMLookupMPN mwqmLookupMPN)
        {
            mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Delete);
            if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;

            db.MWQMLookupMPNs.Remove(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [MWQMLookupMPN](CSSPModels.MWQMLookupMPN.html) item in CSSPDB
        /// </summary>
        /// <param name="mwqmLookupMPN">Is the MWQMLookupMPN item the client want to add to CSSPDB. What's important here is the MWQMLookupMPNID</param>
        /// <returns>true if MWQMLookupMPN item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(MWQMLookupMPN mwqmLookupMPN)
        {
            mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Update);
            if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;

            db.MWQMLookupMPNs.Update(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [MWQMLookupMPN](CSSPModels.MWQMLookupMPN.html) item
        /// </summary>
        /// <param name="mwqmLookupMPN">Is the MWQMLookupMPN item the client want to add to CSSPDB. What's important here is the MWQMLookupMPNID</param>
        /// <returns>true if MWQMLookupMPN item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(MWQMLookupMPN mwqmLookupMPN)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmLookupMPN.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
