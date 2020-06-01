/*
 * Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public interface IVPAmbientService
    {
       Task<ActionResult<VPAmbient>> GetVPAmbientWithVPAmbientID(int VPAmbientID);
       Task<ActionResult<List<VPAmbient>>> GetVPAmbientList();
       Task<ActionResult<VPAmbient>> Add(VPAmbient vpambient);
       Task<ActionResult<VPAmbient>> Delete(VPAmbient vpambient);
       Task<ActionResult<VPAmbient>> Update(VPAmbient vpambient);
       Task SetCulture(CultureInfo culture);
    }
    public partial class VPAmbientService : ControllerBase, IVPAmbientService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public VPAmbientService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<VPAmbient>> GetVPAmbientWithVPAmbientID(int VPAmbientID)
        {
            VPAmbient vpambient = (from c in db.VPAmbients.AsNoTracking()
                    where c.VPAmbientID == VPAmbientID
                    select c).FirstOrDefault();

            if (vpambient == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(vpambient));
        }
        public async Task<ActionResult<List<VPAmbient>>> GetVPAmbientList()
        {
            List<VPAmbient> vpambientList = (from c in db.VPAmbients.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(vpambientList));
        }
        public async Task<ActionResult<VPAmbient>> Add(VPAmbient vpAmbient)
        {
            vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Create);
            if (vpAmbient.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(vpAmbient.ValidationResults));
            }

            try
            {
               db.VPAmbients.Add(vpAmbient);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(vpAmbient));
        }
        public async Task<ActionResult<VPAmbient>> Delete(VPAmbient vpAmbient)
        {
            vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Delete);
            if (vpAmbient.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(vpAmbient.ValidationResults));
            }

            try
            {
               db.VPAmbients.Remove(vpAmbient);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(vpAmbient));
        }
        public async Task<ActionResult<VPAmbient>> Update(VPAmbient vpAmbient)
        {
            vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Update);
            if (vpAmbient.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(vpAmbient.ValidationResults));
            }

            try
            {
               db.VPAmbients.Update(vpAmbient);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(vpAmbient));
        }
        public async Task SetCulture(CultureInfo culture)
        {
            CSSPServicesRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            VPAmbient vpAmbient = validationContext.ObjectInstance as VPAmbient;
            vpAmbient.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (vpAmbient.VPAmbientID == 0)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "VPAmbientID"), new[] { "VPAmbientID" });
                }

                if (!(from c in db.VPAmbients select c).Where(c => c.VPAmbientID == vpAmbient.VPAmbientID).Any())
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientID", vpAmbient.VPAmbientID.ToString()), new[] { "VPAmbientID" });
                }
            }

            VPScenario VPScenarioVPScenarioID = (from c in db.VPScenarios where c.VPScenarioID == vpAmbient.VPScenarioID select c).FirstOrDefault();

            if (VPScenarioVPScenarioID == null)
            {
                vpAmbient.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", vpAmbient.VPScenarioID.ToString()), new[] { "VPScenarioID" });
            }

            if (vpAmbient.Row < 0 || vpAmbient.Row > 10)
            {
                vpAmbient.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Row", "0", "10"), new[] { "Row" });
            }

            if (vpAmbient.MeasurementDepth_m != null)
            {
                if (vpAmbient.MeasurementDepth_m < 0 || vpAmbient.MeasurementDepth_m > 1000)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MeasurementDepth_m", "0", "1000"), new[] { "MeasurementDepth_m" });
                }
            }

            if (vpAmbient.CurrentSpeed_m_s != null)
            {
                if (vpAmbient.CurrentSpeed_m_s < 0 || vpAmbient.CurrentSpeed_m_s > 10)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CurrentSpeed_m_s", "0", "10"), new[] { "CurrentSpeed_m_s" });
                }
            }

            if (vpAmbient.CurrentDirection_deg != null)
            {
                if (vpAmbient.CurrentDirection_deg < -180 || vpAmbient.CurrentDirection_deg > 180)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CurrentDirection_deg", "-180", "180"), new[] { "CurrentDirection_deg" });
                }
            }

            if (vpAmbient.AmbientSalinity_PSU != null)
            {
                if (vpAmbient.AmbientSalinity_PSU < 0 || vpAmbient.AmbientSalinity_PSU > 40)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AmbientSalinity_PSU", "0", "40"), new[] { "AmbientSalinity_PSU" });
                }
            }

            if (vpAmbient.AmbientTemperature_C != null)
            {
                if (vpAmbient.AmbientTemperature_C < -10 || vpAmbient.AmbientTemperature_C > 40)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AmbientTemperature_C", "-10", "40"), new[] { "AmbientTemperature_C" });
                }
            }

            if (vpAmbient.BackgroundConcentration_MPN_100ml != null)
            {
                if (vpAmbient.BackgroundConcentration_MPN_100ml < 0 || vpAmbient.BackgroundConcentration_MPN_100ml > 10000000)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BackgroundConcentration_MPN_100ml", "0", "10000000"), new[] { "BackgroundConcentration_MPN_100ml" });
                }
            }

            if (vpAmbient.PollutantDecayRate_per_day != null)
            {
                if (vpAmbient.PollutantDecayRate_per_day < 0 || vpAmbient.PollutantDecayRate_per_day > 100)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PollutantDecayRate_per_day", "0", "100"), new[] { "PollutantDecayRate_per_day" });
                }
            }

            if (vpAmbient.FarFieldCurrentSpeed_m_s != null)
            {
                if (vpAmbient.FarFieldCurrentSpeed_m_s < 0 || vpAmbient.FarFieldCurrentSpeed_m_s > 10)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "FarFieldCurrentSpeed_m_s", "0", "10"), new[] { "FarFieldCurrentSpeed_m_s" });
                }
            }

            if (vpAmbient.FarFieldCurrentDirection_deg != null)
            {
                if (vpAmbient.FarFieldCurrentDirection_deg < -180 || vpAmbient.FarFieldCurrentDirection_deg > 180)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "FarFieldCurrentDirection_deg", "-180", "180"), new[] { "FarFieldCurrentDirection_deg" });
                }
            }

            if (vpAmbient.FarFieldDiffusionCoefficient != null)
            {
                if (vpAmbient.FarFieldDiffusionCoefficient < 0 || vpAmbient.FarFieldDiffusionCoefficient > 1)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "FarFieldDiffusionCoefficient", "0", "1"), new[] { "FarFieldDiffusionCoefficient" });
                }
            }

            if (vpAmbient.LastUpdateDate_UTC.Year == 1)
            {
                vpAmbient.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (vpAmbient.LastUpdateDate_UTC.Year < 1980)
                {
                vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == vpAmbient.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                vpAmbient.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", vpAmbient.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                vpAmbient.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}
