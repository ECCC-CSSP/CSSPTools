/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public interface IVPAmbientService
    {
       Task<ActionResult<bool>> Delete(int VPAmbientID);
       Task<ActionResult<List<VPAmbient>>> GetVPAmbientList(int skip = 0, int take = 100);
       Task<ActionResult<VPAmbient>> GetVPAmbientWithVPAmbientID(int VPAmbientID);
       Task<ActionResult<VPAmbient>> Post(VPAmbient vpambient);
       Task<ActionResult<VPAmbient>> Put(VPAmbient vpambient);
    }
    public partial class VPAmbientService : ControllerBase, IVPAmbientService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public VPAmbientService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<VPAmbient>> GetVPAmbientWithVPAmbientID(int VPAmbientID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsMemory)
            {
                VPAmbient vpAmbient = (from c in dbIM.VPAmbients.AsNoTracking()
                                   where c.VPAmbientID == VPAmbientID
                                   select c).FirstOrDefault();

                if (vpAmbient == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(vpAmbient));
            }
            else if (LoggedInService.IsLocal)
            {
                VPAmbient vpAmbient = (from c in dbLocal.VPAmbients.AsNoTracking()
                        where c.VPAmbientID == VPAmbientID
                        select c).FirstOrDefault();

                if (vpAmbient == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(vpAmbient));
            }
            else
            {
                VPAmbient vpAmbient = (from c in db.VPAmbients.AsNoTracking()
                        where c.VPAmbientID == VPAmbientID
                        select c).FirstOrDefault();

                if (vpAmbient == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(vpAmbient));
            }
        }
        public async Task<ActionResult<List<VPAmbient>>> GetVPAmbientList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsMemory)
            {
                List<VPAmbient> vpAmbientList = (from c in dbIM.VPAmbients.AsNoTracking() orderby c.VPAmbientID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(vpAmbientList));
            }
            else if (LoggedInService.IsLocal)
            {
                List<VPAmbient> vpAmbientList = (from c in dbLocal.VPAmbients.AsNoTracking() orderby c.VPAmbientID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(vpAmbientList));
            }
            else
            {
                List<VPAmbient> vpAmbientList = (from c in db.VPAmbients.AsNoTracking() orderby c.VPAmbientID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(vpAmbientList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int VPAmbientID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsMemory)
            {
                VPAmbient vpAmbient = (from c in dbIM.VPAmbients
                                   where c.VPAmbientID == VPAmbientID
                                   select c).FirstOrDefault();
            
                if (vpAmbient == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientID", VPAmbientID.ToString())));
                }
            
                try
                {
                    dbIM.VPAmbients.Remove(vpAmbient);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }
            
                return await Task.FromResult(Ok(true));
            }
            else if (LoggedInService.IsLocal)
            {
                VPAmbient vpAmbient = (from c in dbLocal.VPAmbients
                                   where c.VPAmbientID == VPAmbientID
                                   select c).FirstOrDefault();
                
                if (vpAmbient == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientID", VPAmbientID.ToString())));
                }

                try
                {
                   dbLocal.VPAmbients.Remove(vpAmbient);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
            else
            {
                VPAmbient vpAmbient = (from c in db.VPAmbients
                                   where c.VPAmbientID == VPAmbientID
                                   select c).FirstOrDefault();
                
                if (vpAmbient == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientID", VPAmbientID.ToString())));
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

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<VPAmbient>> Post(VPAmbient vpAmbient)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsMemory)
            {
                try
                {
                    dbIM.VPAmbients.Add(vpAmbient);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(vpAmbient));
            }
            else if (LoggedInService.IsLocal)
            {
                try
                {
                   dbLocal.VPAmbients.Add(vpAmbient);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(vpAmbient));
            }
            else
            {
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
        }
        public async Task<ActionResult<VPAmbient>> Put(VPAmbient vpAmbient)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsMemory)
            {
                try
                {
                    dbIM.VPAmbients.Update(vpAmbient);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(vpAmbient));
            }
            else if (LoggedInService.IsLocal)
            {
            try
            {
               dbLocal.VPAmbients.Update(vpAmbient);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(vpAmbient));
            }
            else
            {
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
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            VPAmbient vpAmbient = validationContext.ObjectInstance as VPAmbient;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (vpAmbient.VPAmbientID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "VPAmbientID"), new[] { "VPAmbientID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.VPAmbients select c).Where(c => c.VPAmbientID == vpAmbient.VPAmbientID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientID", vpAmbient.VPAmbientID.ToString()), new[] { "VPAmbientID" });
                    }
                }
                else
                {
                    if (!(from c in db.VPAmbients select c).Where(c => c.VPAmbientID == vpAmbient.VPAmbientID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientID", vpAmbient.VPAmbientID.ToString()), new[] { "VPAmbientID" });
                    }
                }
            }

            VPScenario VPScenarioVPScenarioID = null;
            if (LoggedInService.IsLocal)
            {
                VPScenarioVPScenarioID = (from c in dbLocal.VPScenarios where c.VPScenarioID == vpAmbient.VPScenarioID select c).FirstOrDefault();
                if (VPScenarioVPScenarioID == null)
                {
                    VPScenarioVPScenarioID = (from c in dbIM.VPScenarios where c.VPScenarioID == vpAmbient.VPScenarioID select c).FirstOrDefault();
                }
            }
            else
            {
                VPScenarioVPScenarioID = (from c in db.VPScenarios where c.VPScenarioID == vpAmbient.VPScenarioID select c).FirstOrDefault();
            }

            if (VPScenarioVPScenarioID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", vpAmbient.VPScenarioID.ToString()), new[] { "VPScenarioID" });
            }

            if (vpAmbient.Row < 0 || vpAmbient.Row > 10)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Row", "0", "10"), new[] { "Row" });
            }

            if (vpAmbient.MeasurementDepth_m != null)
            {
                if (vpAmbient.MeasurementDepth_m < 0 || vpAmbient.MeasurementDepth_m > 1000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "MeasurementDepth_m", "0", "1000"), new[] { "MeasurementDepth_m" });
                }
            }

            if (vpAmbient.CurrentSpeed_m_s != null)
            {
                if (vpAmbient.CurrentSpeed_m_s < 0 || vpAmbient.CurrentSpeed_m_s > 10)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "CurrentSpeed_m_s", "0", "10"), new[] { "CurrentSpeed_m_s" });
                }
            }

            if (vpAmbient.CurrentDirection_deg != null)
            {
                if (vpAmbient.CurrentDirection_deg < -180 || vpAmbient.CurrentDirection_deg > 180)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "CurrentDirection_deg", "-180", "180"), new[] { "CurrentDirection_deg" });
                }
            }

            if (vpAmbient.AmbientSalinity_PSU != null)
            {
                if (vpAmbient.AmbientSalinity_PSU < 0 || vpAmbient.AmbientSalinity_PSU > 40)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "AmbientSalinity_PSU", "0", "40"), new[] { "AmbientSalinity_PSU" });
                }
            }

            if (vpAmbient.AmbientTemperature_C != null)
            {
                if (vpAmbient.AmbientTemperature_C < -10 || vpAmbient.AmbientTemperature_C > 40)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "AmbientTemperature_C", "-10", "40"), new[] { "AmbientTemperature_C" });
                }
            }

            if (vpAmbient.BackgroundConcentration_MPN_100ml != null)
            {
                if (vpAmbient.BackgroundConcentration_MPN_100ml < 0 || vpAmbient.BackgroundConcentration_MPN_100ml > 10000000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "BackgroundConcentration_MPN_100ml", "0", "10000000"), new[] { "BackgroundConcentration_MPN_100ml" });
                }
            }

            if (vpAmbient.PollutantDecayRate_per_day != null)
            {
                if (vpAmbient.PollutantDecayRate_per_day < 0 || vpAmbient.PollutantDecayRate_per_day > 100)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "PollutantDecayRate_per_day", "0", "100"), new[] { "PollutantDecayRate_per_day" });
                }
            }

            if (vpAmbient.FarFieldCurrentSpeed_m_s != null)
            {
                if (vpAmbient.FarFieldCurrentSpeed_m_s < 0 || vpAmbient.FarFieldCurrentSpeed_m_s > 10)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "FarFieldCurrentSpeed_m_s", "0", "10"), new[] { "FarFieldCurrentSpeed_m_s" });
                }
            }

            if (vpAmbient.FarFieldCurrentDirection_deg != null)
            {
                if (vpAmbient.FarFieldCurrentDirection_deg < -180 || vpAmbient.FarFieldCurrentDirection_deg > 180)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "FarFieldCurrentDirection_deg", "-180", "180"), new[] { "FarFieldCurrentDirection_deg" });
                }
            }

            if (vpAmbient.FarFieldDiffusionCoefficient != null)
            {
                if (vpAmbient.FarFieldDiffusionCoefficient < 0 || vpAmbient.FarFieldDiffusionCoefficient > 1)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "FarFieldDiffusionCoefficient", "0", "1"), new[] { "FarFieldDiffusionCoefficient" });
                }
            }

            if (vpAmbient.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (vpAmbient.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == vpAmbient.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == vpAmbient.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == vpAmbient.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", vpAmbient.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}
