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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [MikeSourceController](CSSPWebAPI.Controllers.MikeSourceController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.MikeSource](CSSPModels.MikeSource.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class MikeSourceService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB MikeSources table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public MikeSourceService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all MikeSourceService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MikeSource mikeSource = validationContext.ObjectInstance as MikeSource;
            mikeSource.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeSource.MikeSourceID == 0)
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeSourceID"), new[] { "MikeSourceID" });
                }

                if (!(from c in db.MikeSources select c).Where(c => c.MikeSourceID == mikeSource.MikeSourceID).Any())
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceID", mikeSource.MikeSourceID.ToString()), new[] { "MikeSourceID" });
                }
            }

            TVItem TVItemMikeSourceTVItemID = (from c in db.TVItems where c.TVItemID == mikeSource.MikeSourceTVItemID select c).FirstOrDefault();

            if (TVItemMikeSourceTVItemID == null)
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeSourceTVItemID", mikeSource.MikeSourceTVItemID.ToString()), new[] { "MikeSourceTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeSource,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeSourceTVItemID.TVType))
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MikeSourceTVItemID", "MikeSource"), new[] { "MikeSourceTVItemID" });
                }
            }

            if (mikeSource.HydrometricTVItemID != null)
            {
                TVItem TVItemHydrometricTVItemID = (from c in db.TVItems where c.TVItemID == mikeSource.HydrometricTVItemID select c).FirstOrDefault();

                if (TVItemHydrometricTVItemID == null)
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "HydrometricTVItemID", (mikeSource.HydrometricTVItemID == null ? "" : mikeSource.HydrometricTVItemID.ToString())), new[] { "HydrometricTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.HydrometricSite,
                    };
                    if (!AllowableTVTypes.Contains(TVItemHydrometricTVItemID.TVType))
                    {
                        mikeSource.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "HydrometricTVItemID", "HydrometricSite"), new[] { "HydrometricTVItemID" });
                    }
                }
            }

            if (mikeSource.DrainageArea_km2 != null)
            {
                if (mikeSource.DrainageArea_km2 < 0 || mikeSource.DrainageArea_km2 > 1000000)
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DrainageArea_km2", "0", "1000000"), new[] { "DrainageArea_km2" });
                }
            }

            if (mikeSource.Factor != null)
            {
                if (mikeSource.Factor < 0 || mikeSource.Factor > 1000000)
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Factor", "0", "1000000"), new[] { "Factor" });
                }
            }

            if (string.IsNullOrWhiteSpace(mikeSource.SourceNumberString))
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SourceNumberString"), new[] { "SourceNumberString" });
            }

            if (!string.IsNullOrWhiteSpace(mikeSource.SourceNumberString) && mikeSource.SourceNumberString.Length > 50)
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "SourceNumberString", "50"), new[] { "SourceNumberString" });
            }

            if (mikeSource.LastUpdateDate_UTC.Year == 1)
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeSource.LastUpdateDate_UTC.Year < 1980)
                {
                mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeSource.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeSource.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the MikeSource model with the MikeSourceID identifier
        /// </summary>
        /// <param name="MikeSourceID">Is the identifier of [MikeSources](CSSPModels.MikeSource.html) table of CSSPDB</param>
        /// <returns>[MikeSource](CSSPModels.MikeSource.html) object connected to the CSSPDB</returns>
        public MikeSource GetMikeSourceWithMikeSourceID(int MikeSourceID)
        {
            return (from c in db.MikeSources
                    where c.MikeSourceID == MikeSourceID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [MikeSource](CSSPModels.MikeSource.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [MikeSource](CSSPModels.MikeSource.html)</returns>
        public IQueryable<MikeSource> GetMikeSourceList()
        {
            IQueryable<MikeSource> MikeSourceQuery = (from c in db.MikeSources select c);

            MikeSourceQuery = EnhanceQueryStatements<MikeSource>(MikeSourceQuery) as IQueryable<MikeSource>;

            return MikeSourceQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [MikeSource](CSSPModels.MikeSource.html) item in CSSPDB
        /// </summary>
        /// <param name="mikeSource">Is the MikeSource item the client want to add to CSSPDB</param>
        /// <returns>true if MikeSource item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(MikeSource mikeSource)
        {
            mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Create);
            if (mikeSource.ValidationResults.Count() > 0) return false;

            db.MikeSources.Add(mikeSource);

            if (!TryToSave(mikeSource)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [MikeSource](CSSPModels.MikeSource.html) item in CSSPDB
        /// </summary>
        /// <param name="mikeSource">Is the MikeSource item the client want to add to CSSPDB. What's important here is the MikeSourceID</param>
        /// <returns>true if MikeSource item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(MikeSource mikeSource)
        {
            mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Delete);
            if (mikeSource.ValidationResults.Count() > 0) return false;

            db.MikeSources.Remove(mikeSource);

            if (!TryToSave(mikeSource)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [MikeSource](CSSPModels.MikeSource.html) item in CSSPDB
        /// </summary>
        /// <param name="mikeSource">Is the MikeSource item the client want to add to CSSPDB. What's important here is the MikeSourceID</param>
        /// <returns>true if MikeSource item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(MikeSource mikeSource)
        {
            mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Update);
            if (mikeSource.ValidationResults.Count() > 0) return false;

            db.MikeSources.Update(mikeSource);

            if (!TryToSave(mikeSource)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [MikeSource](CSSPModels.MikeSource.html) item
        /// </summary>
        /// <param name="mikeSource">Is the MikeSource item the client want to add to CSSPDB. What's important here is the MikeSourceID</param>
        /// <returns>true if MikeSource item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(MikeSource mikeSource)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeSource.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
