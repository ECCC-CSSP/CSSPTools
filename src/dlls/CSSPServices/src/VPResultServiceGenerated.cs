/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
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
    public partial class VPResultService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPResultService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPResult vpResult = validationContext.ObjectInstance as VPResult;
            vpResult.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (vpResult.VPResultID == 0)
                {
                    vpResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "VPResultID"), new[] { "VPResultID" });
                }

                if (!(from c in db.VPResults select c).Where(c => c.VPResultID == vpResult.VPResultID).Any())
                {
                    vpResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPResult", "VPResultID", vpResult.VPResultID.ToString()), new[] { "VPResultID" });
                }
            }

            VPScenario VPScenarioVPScenarioID = (from c in db.VPScenarios where c.VPScenarioID == vpResult.VPScenarioID select c).FirstOrDefault();

            if (VPScenarioVPScenarioID == null)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", vpResult.VPScenarioID.ToString()), new[] { "VPScenarioID" });
            }

            if (vpResult.Ordinal < 0 || vpResult.Ordinal > 1000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), new[] { "Ordinal" });
            }

            if (vpResult.Concentration_MPN_100ml < 0 || vpResult.Concentration_MPN_100ml > 10000000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Concentration_MPN_100ml", "0", "10000000"), new[] { "Concentration_MPN_100ml" });
            }

            if (vpResult.Dilution < 0 || vpResult.Dilution > 1000000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Dilution", "0", "1000000"), new[] { "Dilution" });
            }

            if (vpResult.FarFieldWidth_m < 0 || vpResult.FarFieldWidth_m > 10000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "FarFieldWidth_m", "0", "10000"), new[] { "FarFieldWidth_m" });
            }

            if (vpResult.DispersionDistance_m < 0 || vpResult.DispersionDistance_m > 100000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DispersionDistance_m", "0", "100000"), new[] { "DispersionDistance_m" });
            }

            if (vpResult.TravelTime_hour < 0 || vpResult.TravelTime_hour > 100)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TravelTime_hour", "0", "100"), new[] { "TravelTime_hour" });
            }

            if (vpResult.LastUpdateDate_UTC.Year == 1)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (vpResult.LastUpdateDate_UTC.Year < 1980)
                {
                vpResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == vpResult.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", vpResult.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    vpResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public VPResult GetVPResultWithVPResultID(int VPResultID)
        {
            return (from c in db.VPResults
                    where c.VPResultID == VPResultID
                    select c).FirstOrDefault();

        }
        public IQueryable<VPResult> GetVPResultList()
        {
            IQueryable<VPResult> VPResultQuery = (from c in db.VPResults select c);

            VPResultQuery = EnhanceQueryStatements<VPResult>(VPResultQuery) as IQueryable<VPResult>;

            return VPResultQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(VPResult vpResult)
        {
            vpResult.ValidationResults = Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Create);
            if (vpResult.ValidationResults.Count() > 0) return false;

            db.VPResults.Add(vpResult);

            if (!TryToSave(vpResult)) return false;

            return true;
        }
        public bool Delete(VPResult vpResult)
        {
            vpResult.ValidationResults = Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Delete);
            if (vpResult.ValidationResults.Count() > 0) return false;

            db.VPResults.Remove(vpResult);

            if (!TryToSave(vpResult)) return false;

            return true;
        }
        public bool Update(VPResult vpResult)
        {
            vpResult.ValidationResults = Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Update);
            if (vpResult.ValidationResults.Count() > 0) return false;

            db.VPResults.Update(vpResult);

            if (!TryToSave(vpResult)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(VPResult vpResult)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpResult.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
