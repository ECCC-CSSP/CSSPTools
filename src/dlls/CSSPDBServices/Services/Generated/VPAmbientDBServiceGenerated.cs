/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBServices
{
    public partial interface IVPAmbientDBService
    {
        Task<ActionResult<bool>> Delete(int VPAmbientID);
        Task<ActionResult<List<VPAmbient>>> GetVPAmbientList(int skip = 0, int take = 100);
        Task<ActionResult<VPAmbient>> GetVPAmbientWithVPAmbientID(int VPAmbientID);
        Task<ActionResult<VPAmbient>> Post(VPAmbient vpambient);
        Task<ActionResult<VPAmbient>> Put(VPAmbient vpambient);
    }
    public partial class VPAmbientDBService : ControllerBase, IVPAmbientDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public VPAmbientDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<VPAmbient>> GetVPAmbientWithVPAmbientID(int VPAmbientID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            VPAmbient vpAmbient = (from c in db.VPAmbients.AsNoTracking()
                    where c.VPAmbientID == VPAmbientID
                    select c).FirstOrDefault();

            if (vpAmbient == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(vpAmbient));
        }
        public async Task<ActionResult<List<VPAmbient>>> GetVPAmbientList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<VPAmbient> vpAmbientList = (from c in db.VPAmbients.AsNoTracking() orderby c.VPAmbientID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(vpAmbientList));
        }
        public async Task<ActionResult<bool>> Delete(int VPAmbientID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            VPAmbient vpAmbient = (from c in db.VPAmbients
                    where c.VPAmbientID == VPAmbientID
                    select c).FirstOrDefault();

            if (vpAmbient == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientID", VPAmbientID.ToString())));
            }

            try
            {
                db.VPAmbients.Remove(vpAmbient);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<VPAmbient>> Post(VPAmbient vpAmbient)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.VPAmbients.Add(vpAmbient);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(vpAmbient));
        }
        public async Task<ActionResult<VPAmbient>> Put(VPAmbient vpAmbient)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.VPAmbients.Update(vpAmbient);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(vpAmbient));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            VPAmbient vpAmbient = validationContext.ObjectInstance as VPAmbient;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (vpAmbient.VPAmbientID == 0)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "VPAmbientID"), new[] { nameof(vpAmbient.VPAmbientID) }));
                }

                if (!(from c in db.VPAmbients.AsNoTracking() select c).Where(c => c.VPAmbientID == vpAmbient.VPAmbientID).Any())
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientID", vpAmbient.VPAmbientID.ToString()), new[] { nameof(vpAmbient.VPAmbientID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)vpAmbient.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(vpAmbient.DBCommand) }));
            }

            VPScenario VPScenarioVPScenarioID = null;
            VPScenarioVPScenarioID = (from c in db.VPScenarios.AsNoTracking() where c.VPScenarioID == vpAmbient.VPScenarioID select c).FirstOrDefault();

            if (VPScenarioVPScenarioID == null)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", vpAmbient.VPScenarioID.ToString()), new[] { nameof(vpAmbient.VPScenarioID)}));
            }

            if (vpAmbient.Row < 0 || vpAmbient.Row > 10)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Row", "0", "10"), new[] { nameof(vpAmbient.Row) }));
            }

            if (vpAmbient.MeasurementDepth_m != null)
            {
                if (vpAmbient.MeasurementDepth_m < 0 || vpAmbient.MeasurementDepth_m > 1000)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MeasurementDepth_m", "0", "1000"), new[] { nameof(vpAmbient.MeasurementDepth_m) }));
                }
            }

            if (vpAmbient.CurrentSpeed_m_s != null)
            {
                if (vpAmbient.CurrentSpeed_m_s < 0 || vpAmbient.CurrentSpeed_m_s > 10)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "CurrentSpeed_m_s", "0", "10"), new[] { nameof(vpAmbient.CurrentSpeed_m_s) }));
                }
            }

            if (vpAmbient.CurrentDirection_deg != null)
            {
                if (vpAmbient.CurrentDirection_deg < -180 || vpAmbient.CurrentDirection_deg > 180)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "CurrentDirection_deg", "-180", "180"), new[] { nameof(vpAmbient.CurrentDirection_deg) }));
                }
            }

            if (vpAmbient.AmbientSalinity_PSU != null)
            {
                if (vpAmbient.AmbientSalinity_PSU < 0 || vpAmbient.AmbientSalinity_PSU > 40)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "AmbientSalinity_PSU", "0", "40"), new[] { nameof(vpAmbient.AmbientSalinity_PSU) }));
                }
            }

            if (vpAmbient.AmbientTemperature_C != null)
            {
                if (vpAmbient.AmbientTemperature_C < -10 || vpAmbient.AmbientTemperature_C > 40)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "AmbientTemperature_C", "-10", "40"), new[] { nameof(vpAmbient.AmbientTemperature_C) }));
                }
            }

            if (vpAmbient.BackgroundConcentration_MPN_100ml != null)
            {
                if (vpAmbient.BackgroundConcentration_MPN_100ml < 0 || vpAmbient.BackgroundConcentration_MPN_100ml > 10000000)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "BackgroundConcentration_MPN_100ml", "0", "10000000"), new[] { nameof(vpAmbient.BackgroundConcentration_MPN_100ml) }));
                }
            }

            if (vpAmbient.PollutantDecayRate_per_day != null)
            {
                if (vpAmbient.PollutantDecayRate_per_day < 0 || vpAmbient.PollutantDecayRate_per_day > 100)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PollutantDecayRate_per_day", "0", "100"), new[] { nameof(vpAmbient.PollutantDecayRate_per_day) }));
                }
            }

            if (vpAmbient.FarFieldCurrentSpeed_m_s != null)
            {
                if (vpAmbient.FarFieldCurrentSpeed_m_s < 0 || vpAmbient.FarFieldCurrentSpeed_m_s > 10)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "FarFieldCurrentSpeed_m_s", "0", "10"), new[] { nameof(vpAmbient.FarFieldCurrentSpeed_m_s) }));
                }
            }

            if (vpAmbient.FarFieldCurrentDirection_deg != null)
            {
                if (vpAmbient.FarFieldCurrentDirection_deg < -180 || vpAmbient.FarFieldCurrentDirection_deg > 180)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "FarFieldCurrentDirection_deg", "-180", "180"), new[] { nameof(vpAmbient.FarFieldCurrentDirection_deg) }));
                }
            }

            if (vpAmbient.FarFieldDiffusionCoefficient != null)
            {
                if (vpAmbient.FarFieldDiffusionCoefficient < 0 || vpAmbient.FarFieldDiffusionCoefficient > 1)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "FarFieldDiffusionCoefficient", "0", "1"), new[] { nameof(vpAmbient.FarFieldDiffusionCoefficient) }));
                }
            }

            if (vpAmbient.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(vpAmbient.LastUpdateDate_UTC) }));
            }
            else
            {
                if (vpAmbient.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(vpAmbient.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == vpAmbient.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", vpAmbient.LastUpdateContactTVItemID.ToString()), new[] { nameof(vpAmbient.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(vpAmbient.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
