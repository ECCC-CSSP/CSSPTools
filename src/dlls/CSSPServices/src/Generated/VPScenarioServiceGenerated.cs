/*
 * Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
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
   public interface IVPScenarioService
    {
       Task<ActionResult<bool>> Delete(int VPScenarioID);
       Task<ActionResult<List<VPScenario>>> GetVPScenarioList();
       Task<ActionResult<VPScenario>> GetVPScenarioWithVPScenarioID(int VPScenarioID);
       Task<ActionResult<VPScenario>> Post(VPScenario vpscenario);
       Task<ActionResult<VPScenario>> Put(VPScenario vpscenario);
    }
    public partial class VPScenarioService : ControllerBase, IVPScenarioService
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
        public VPScenarioService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<VPScenario>> GetVPScenarioWithVPScenarioID(int VPScenarioID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                VPScenario vpscenario = (from c in dbLocal.VPScenarios.AsNoTracking()
                        where c.VPScenarioID == VPScenarioID
                        select c).FirstOrDefault();

                if (vpscenario == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(vpscenario));
            }
            else
            {
                VPScenario vpscenario = (from c in db.VPScenarios.AsNoTracking()
                        where c.VPScenarioID == VPScenarioID
                        select c).FirstOrDefault();

                if (vpscenario == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(vpscenario));
            }
        }
        public async Task<ActionResult<List<VPScenario>>> GetVPScenarioList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                List<VPScenario> vpscenarioList = (from c in dbLocal.VPScenarios.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(vpscenarioList));
            }
            else
            {
                List<VPScenario> vpscenarioList = (from c in db.VPScenarios.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(vpscenarioList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int VPScenarioID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                VPScenario vpScenario = (from c in dbLocal.VPScenarios
                                   where c.VPScenarioID == VPScenarioID
                                   select c).FirstOrDefault();
                
                if (vpScenario == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", VPScenarioID.ToString())));
                }

                try
                {
                   dbLocal.VPScenarios.Remove(vpScenario);
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
                VPScenario vpScenario = (from c in db.VPScenarios
                                   where c.VPScenarioID == VPScenarioID
                                   select c).FirstOrDefault();
                
                if (vpScenario == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", VPScenarioID.ToString())));
                }

                try
                {
                   db.VPScenarios.Remove(vpScenario);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<VPScenario>> Post(VPScenario vpScenario)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(vpScenario), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
                try
                {
                   dbLocal.VPScenarios.Add(vpScenario);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(vpScenario));
            }
            else
            {
                try
                {
                   db.VPScenarios.Add(vpScenario);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(vpScenario));
            }
        }
        public async Task<ActionResult<VPScenario>> Put(VPScenario vpScenario)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(vpScenario), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
            try
            {
               dbLocal.VPScenarios.Update(vpScenario);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(vpScenario));
            }
            else
            {
            try
            {
               db.VPScenarios.Update(vpScenario);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(vpScenario));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            VPScenario vpScenario = validationContext.ObjectInstance as VPScenario;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (vpScenario.VPScenarioID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "VPScenarioID"), new[] { "VPScenarioID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.VPScenarios select c).Where(c => c.VPScenarioID == vpScenario.VPScenarioID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", vpScenario.VPScenarioID.ToString()), new[] { "VPScenarioID" });
                    }
                }
                else
                {
                    if (!(from c in db.VPScenarios select c).Where(c => c.VPScenarioID == vpScenario.VPScenarioID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", vpScenario.VPScenarioID.ToString()), new[] { "VPScenarioID" });
                    }
                }
            }

            TVItem TVItemInfrastructureTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemInfrastructureTVItemID = (from c in dbLocal.TVItems where c.TVItemID == vpScenario.InfrastructureTVItemID select c).FirstOrDefault();
                if (TVItemInfrastructureTVItemID == null)
                {
                    TVItemInfrastructureTVItemID = (from c in dbIM.TVItems where c.TVItemID == vpScenario.InfrastructureTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == vpScenario.InfrastructureTVItemID select c).FirstOrDefault();
            }

            if (TVItemInfrastructureTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureTVItemID", vpScenario.InfrastructureTVItemID.ToString()), new[] { "InfrastructureTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                };
                if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "InfrastructureTVItemID", "Infrastructure"), new[] { "InfrastructureTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(ScenarioStatusEnum), (int?)vpScenario.VPScenarioStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "VPScenarioStatus"), new[] { "VPScenarioStatus" });
            }

            if (vpScenario.EffluentFlow_m3_s != null)
            {
                if (vpScenario.EffluentFlow_m3_s < 0 || vpScenario.EffluentFlow_m3_s > 1000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "EffluentFlow_m3_s", "0", "1000"), new[] { "EffluentFlow_m3_s" });
                }
            }

            if (vpScenario.EffluentConcentration_MPN_100ml != null)
            {
                if (vpScenario.EffluentConcentration_MPN_100ml < 0 || vpScenario.EffluentConcentration_MPN_100ml > 10000000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "EffluentConcentration_MPN_100ml", "0", "10000000"), new[] { "EffluentConcentration_MPN_100ml" });
                }
            }

            if (vpScenario.FroudeNumber != null)
            {
                if (vpScenario.FroudeNumber < 0 || vpScenario.FroudeNumber > 10000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "FroudeNumber", "0", "10000"), new[] { "FroudeNumber" });
                }
            }

            if (vpScenario.PortDiameter_m != null)
            {
                if (vpScenario.PortDiameter_m < 0 || vpScenario.PortDiameter_m > 10)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "PortDiameter_m", "0", "10"), new[] { "PortDiameter_m" });
                }
            }

            if (vpScenario.PortDepth_m != null)
            {
                if (vpScenario.PortDepth_m < 0 || vpScenario.PortDepth_m > 1000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "PortDepth_m", "0", "1000"), new[] { "PortDepth_m" });
                }
            }

            if (vpScenario.PortElevation_m != null)
            {
                if (vpScenario.PortElevation_m < 0 || vpScenario.PortElevation_m > 1000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "PortElevation_m", "0", "1000"), new[] { "PortElevation_m" });
                }
            }

            if (vpScenario.VerticalAngle_deg != null)
            {
                if (vpScenario.VerticalAngle_deg < -90 || vpScenario.VerticalAngle_deg > 90)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "VerticalAngle_deg", "-90", "90"), new[] { "VerticalAngle_deg" });
                }
            }

            if (vpScenario.HorizontalAngle_deg != null)
            {
                if (vpScenario.HorizontalAngle_deg < -180 || vpScenario.HorizontalAngle_deg > 180)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "HorizontalAngle_deg", "-180", "180"), new[] { "HorizontalAngle_deg" });
                }
            }

            if (vpScenario.NumberOfPorts != null)
            {
                if (vpScenario.NumberOfPorts < 1 || vpScenario.NumberOfPorts > 100)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "NumberOfPorts", "1", "100"), new[] { "NumberOfPorts" });
                }
            }

            if (vpScenario.PortSpacing_m != null)
            {
                if (vpScenario.PortSpacing_m < 0 || vpScenario.PortSpacing_m > 1000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "PortSpacing_m", "0", "1000"), new[] { "PortSpacing_m" });
                }
            }

            if (vpScenario.AcuteMixZone_m != null)
            {
                if (vpScenario.AcuteMixZone_m < 0 || vpScenario.AcuteMixZone_m > 100)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "AcuteMixZone_m", "0", "100"), new[] { "AcuteMixZone_m" });
                }
            }

            if (vpScenario.ChronicMixZone_m != null)
            {
                if (vpScenario.ChronicMixZone_m < 0 || vpScenario.ChronicMixZone_m > 40000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "ChronicMixZone_m", "0", "40000"), new[] { "ChronicMixZone_m" });
                }
            }

            if (vpScenario.EffluentSalinity_PSU != null)
            {
                if (vpScenario.EffluentSalinity_PSU < 0 || vpScenario.EffluentSalinity_PSU > 40)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "EffluentSalinity_PSU", "0", "40"), new[] { "EffluentSalinity_PSU" });
                }
            }

            if (vpScenario.EffluentTemperature_C != null)
            {
                if (vpScenario.EffluentTemperature_C < -10 || vpScenario.EffluentTemperature_C > 40)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "EffluentTemperature_C", "-10", "40"), new[] { "EffluentTemperature_C" });
                }
            }

            if (vpScenario.EffluentVelocity_m_s != null)
            {
                if (vpScenario.EffluentVelocity_m_s < 0 || vpScenario.EffluentVelocity_m_s > 100)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "EffluentVelocity_m_s", "0", "100"), new[] { "EffluentVelocity_m_s" });
                }
            }

            //RawResults has no StringLength Attribute

            if (vpScenario.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (vpScenario.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == vpScenario.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == vpScenario.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == vpScenario.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", vpScenario.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
