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
    public partial interface IMikeScenarioDBService
    {
        Task<ActionResult<bool>> Delete(int MikeScenarioID);
        Task<ActionResult<List<MikeScenario>>> GetMikeScenarioList(int skip = 0, int take = 100);
        Task<ActionResult<MikeScenario>> GetMikeScenarioWithMikeScenarioID(int MikeScenarioID);
        Task<ActionResult<MikeScenario>> Post(MikeScenario mikescenario);
        Task<ActionResult<MikeScenario>> Put(MikeScenario mikescenario);
    }
    public partial class MikeScenarioDBService : ControllerBase, IMikeScenarioDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResultList { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;

            ValidationResultList = new List<ValidationResult>();
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MikeScenario>> GetMikeScenarioWithMikeScenarioID(int MikeScenarioID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            MikeScenario mikeScenario = (from c in db.MikeScenarios.AsNoTracking()
                    where c.MikeScenarioID == MikeScenarioID
                    select c).FirstOrDefault();

            if (mikeScenario == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mikeScenario));
        }
        public async Task<ActionResult<List<MikeScenario>>> GetMikeScenarioList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<MikeScenario> mikeScenarioList = (from c in db.MikeScenarios.AsNoTracking() orderby c.MikeScenarioID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mikeScenarioList));
        }
        public async Task<ActionResult<bool>> Delete(int MikeScenarioID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            MikeScenario mikeScenario = (from c in db.MikeScenarios
                    where c.MikeScenarioID == MikeScenarioID
                    select c).FirstOrDefault();

            if (mikeScenario == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "MikeScenarioID", MikeScenarioID.ToString())));
            }

            try
            {
                db.MikeScenarios.Remove(mikeScenario);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MikeScenario>> Post(MikeScenario mikeScenario)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.MikeScenarios.Add(mikeScenario);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeScenario));
        }
        public async Task<ActionResult<MikeScenario>> Put(MikeScenario mikeScenario)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.MikeScenarios.Update(mikeScenario);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeScenario));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MikeScenario mikeScenario = validationContext.ObjectInstance as MikeScenario;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeScenario.MikeScenarioID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeScenarioID"), new[] { nameof(mikeScenario.MikeScenarioID) }));
                }

                if (!(from c in db.MikeScenarios.AsNoTracking() select c).Where(c => c.MikeScenarioID == mikeScenario.MikeScenarioID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "MikeScenarioID", mikeScenario.MikeScenarioID.ToString()), new[] { nameof(mikeScenario.MikeScenarioID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)mikeScenario.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(mikeScenario.DBCommand) }));
            }

            TVItem TVItemMikeScenarioTVItemID = null;
            TVItemMikeScenarioTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mikeScenario.MikeScenarioTVItemID select c).FirstOrDefault();

            if (TVItemMikeScenarioTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeScenarioTVItemID", mikeScenario.MikeScenarioTVItemID.ToString()), new[] { nameof(mikeScenario.MikeScenarioTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeScenario,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeScenarioTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MikeScenarioTVItemID", "MikeScenario"), new[] { nameof(mikeScenario.MikeScenarioTVItemID) }));
                }
            }

            if (mikeScenario.ParentMikeScenarioID != null)
            {
                MikeScenario MikeScenarioParentMikeScenarioID = null;
                MikeScenarioParentMikeScenarioID = (from c in db.MikeScenarios.AsNoTracking() where c.MikeScenarioID == mikeScenario.ParentMikeScenarioID select c).FirstOrDefault();

                if (MikeScenarioParentMikeScenarioID == null)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "ParentMikeScenarioID", (mikeScenario.ParentMikeScenarioID == null ? "" : mikeScenario.ParentMikeScenarioID.ToString())), new[] { nameof(mikeScenario.ParentMikeScenarioID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(ScenarioStatusEnum), (int?)mikeScenario.ScenarioStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ScenarioStatus"), new[] { nameof(mikeScenario.ScenarioStatus) }));
            }

            //ErrorInfo has no StringLength Attribute

            if (mikeScenario.MikeScenarioStartDateTime_Local.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeScenarioStartDateTime_Local"), new[] { nameof(mikeScenario.MikeScenarioStartDateTime_Local) }));
            }
            else
            {
                if (mikeScenario.MikeScenarioStartDateTime_Local.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "MikeScenarioStartDateTime_Local", "1980"), new[] { nameof(mikeScenario.MikeScenarioStartDateTime_Local) }));
                }
            }

            if (mikeScenario.MikeScenarioEndDateTime_Local.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeScenarioEndDateTime_Local"), new[] { nameof(mikeScenario.MikeScenarioEndDateTime_Local) }));
            }
            else
            {
                if (mikeScenario.MikeScenarioEndDateTime_Local.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "MikeScenarioEndDateTime_Local", "1980"), new[] { nameof(mikeScenario.MikeScenarioEndDateTime_Local) }));
                }
            }

            if (mikeScenario.MikeScenarioStartExecutionDateTime_Local != null && ((DateTime)mikeScenario.MikeScenarioStartExecutionDateTime_Local).Year < 1980)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "MikeScenarioStartExecutionDateTime_Local", "1980"), new[] { nameof(mikeScenario.MikeScenarioStartExecutionDateTime_Local) }));
            }

            if (mikeScenario.MikeScenarioExecutionTime_min != null)
            {
                if (mikeScenario.MikeScenarioExecutionTime_min < 1 || mikeScenario.MikeScenarioExecutionTime_min > 100000)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MikeScenarioExecutionTime_min", "1", "100000"), new[] { nameof(mikeScenario.MikeScenarioExecutionTime_min) }));
                }
            }

            if (mikeScenario.WindSpeed_km_h < 0 || mikeScenario.WindSpeed_km_h > 100)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WindSpeed_km_h", "0", "100"), new[] { nameof(mikeScenario.WindSpeed_km_h) }));
            }

            if (mikeScenario.WindDirection_deg < 0 || mikeScenario.WindDirection_deg > 360)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WindDirection_deg", "0", "360"), new[] { nameof(mikeScenario.WindDirection_deg) }));
            }

            if (mikeScenario.DecayFactor_per_day < 0 || mikeScenario.DecayFactor_per_day > 100)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DecayFactor_per_day", "0", "100"), new[] { nameof(mikeScenario.DecayFactor_per_day) }));
            }

            if (mikeScenario.DecayFactorAmplitude < 0 || mikeScenario.DecayFactorAmplitude > 100)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DecayFactorAmplitude", "0", "100"), new[] { nameof(mikeScenario.DecayFactorAmplitude) }));
            }

            if (mikeScenario.ResultFrequency_min < 0 || mikeScenario.ResultFrequency_min > 100)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ResultFrequency_min", "0", "100"), new[] { nameof(mikeScenario.ResultFrequency_min) }));
            }

            if (mikeScenario.AmbientTemperature_C < -10 || mikeScenario.AmbientTemperature_C > 40)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "AmbientTemperature_C", "-10", "40"), new[] { nameof(mikeScenario.AmbientTemperature_C) }));
            }

            if (mikeScenario.AmbientSalinity_PSU < 0 || mikeScenario.AmbientSalinity_PSU > 40)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "AmbientSalinity_PSU", "0", "40"), new[] { nameof(mikeScenario.AmbientSalinity_PSU) }));
            }

            if (mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID != null)
            {
                TVItem TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = null;
                TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID select c).FirstOrDefault();

                if (TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID == null)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID", (mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID == null ? "" : mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID.ToString())), new[] { nameof(mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID) }));
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                    };
                    if (!AllowableTVTypes.Contains(TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID.TVType))
                    {
                        ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID", "File"), new[] { nameof(mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID) }));
                    }
                }
            }

            if (mikeScenario.ForSimulatingMWQMRunTVItemID != null)
            {
                TVItem TVItemForSimulatingMWQMRunTVItemID = null;
                TVItemForSimulatingMWQMRunTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mikeScenario.ForSimulatingMWQMRunTVItemID select c).FirstOrDefault();

                if (TVItemForSimulatingMWQMRunTVItemID == null)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ForSimulatingMWQMRunTVItemID", (mikeScenario.ForSimulatingMWQMRunTVItemID == null ? "" : mikeScenario.ForSimulatingMWQMRunTVItemID.ToString())), new[] { nameof(mikeScenario.ForSimulatingMWQMRunTVItemID) }));
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.MWQMRun,
                    };
                    if (!AllowableTVTypes.Contains(TVItemForSimulatingMWQMRunTVItemID.TVType))
                    {
                        ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ForSimulatingMWQMRunTVItemID", "MWQMRun"), new[] { nameof(mikeScenario.ForSimulatingMWQMRunTVItemID) }));
                    }
                }
            }

            if (mikeScenario.ManningNumber < 0 || mikeScenario.ManningNumber > 100)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ManningNumber", "0", "100"), new[] { nameof(mikeScenario.ManningNumber) }));
            }

            if (mikeScenario.NumberOfElements != null)
            {
                if (mikeScenario.NumberOfElements < 1 || mikeScenario.NumberOfElements > 1000000)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfElements", "1", "1000000"), new[] { nameof(mikeScenario.NumberOfElements) }));
                }
            }

            if (mikeScenario.NumberOfTimeSteps != null)
            {
                if (mikeScenario.NumberOfTimeSteps < 1 || mikeScenario.NumberOfTimeSteps > 1000000)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfTimeSteps", "1", "1000000"), new[] { nameof(mikeScenario.NumberOfTimeSteps) }));
                }
            }

            if (mikeScenario.NumberOfSigmaLayers != null)
            {
                if (mikeScenario.NumberOfSigmaLayers < 0 || mikeScenario.NumberOfSigmaLayers > 100)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfSigmaLayers", "0", "100"), new[] { nameof(mikeScenario.NumberOfSigmaLayers) }));
                }
            }

            if (mikeScenario.NumberOfZLayers != null)
            {
                if (mikeScenario.NumberOfZLayers < 0 || mikeScenario.NumberOfZLayers > 100)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfZLayers", "0", "100"), new[] { nameof(mikeScenario.NumberOfZLayers) }));
                }
            }

            if (mikeScenario.NumberOfHydroOutputParameters != null)
            {
                if (mikeScenario.NumberOfHydroOutputParameters < 0 || mikeScenario.NumberOfHydroOutputParameters > 100)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfHydroOutputParameters", "0", "100"), new[] { nameof(mikeScenario.NumberOfHydroOutputParameters) }));
                }
            }

            if (mikeScenario.NumberOfTransOutputParameters != null)
            {
                if (mikeScenario.NumberOfTransOutputParameters < 0 || mikeScenario.NumberOfTransOutputParameters > 100)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfTransOutputParameters", "0", "100"), new[] { nameof(mikeScenario.NumberOfTransOutputParameters) }));
                }
            }

            if (mikeScenario.EstimatedHydroFileSize != null)
            {
                if (mikeScenario.EstimatedHydroFileSize < 0 || mikeScenario.EstimatedHydroFileSize > 100000000)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "EstimatedHydroFileSize", "0", "100000000"), new[] { nameof(mikeScenario.EstimatedHydroFileSize) }));
                }
            }

            if (mikeScenario.EstimatedTransFileSize != null)
            {
                if (mikeScenario.EstimatedTransFileSize < 0 || mikeScenario.EstimatedTransFileSize > 100000000)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "EstimatedTransFileSize", "0", "100000000"), new[] { nameof(mikeScenario.EstimatedTransFileSize) }));
                }
            }

            if (mikeScenario.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mikeScenario.LastUpdateDate_UTC) }));
            }
            else
            {
                if (mikeScenario.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mikeScenario.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mikeScenario.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeScenario.LastUpdateContactTVItemID.ToString()), new[] { nameof(mikeScenario.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mikeScenario.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
