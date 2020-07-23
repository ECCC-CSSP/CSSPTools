/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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

namespace CSSPServices
{
   public partial interface IMikeScenarioService
    {
       Task<ActionResult<bool>> Delete(int MikeScenarioID);
       Task<ActionResult<List<MikeScenario>>> GetMikeScenarioList(int skip = 0, int take = 100);
       Task<ActionResult<MikeScenario>> GetMikeScenarioWithMikeScenarioID(int MikeScenarioID);
       Task<ActionResult<MikeScenario>> Post(MikeScenario mikescenario);
       Task<ActionResult<MikeScenario>> Put(MikeScenario mikescenario);
    }
    public partial class MikeScenarioService : ControllerBase, IMikeScenarioService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBInMemoryContext dbIM { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, CSSPDBInMemoryContext dbIM)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MikeScenario>> GetMikeScenarioWithMikeScenarioID(int MikeScenarioID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MikeScenario mikeScenario = (from c in dbIM.MikeScenarios.AsNoTracking()
                                   where c.MikeScenarioID == MikeScenarioID
                                   select c).FirstOrDefault();

                if (mikeScenario == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mikeScenario));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                MikeScenario mikeScenario = (from c in dbLocal.MikeScenarios.AsNoTracking()
                        where c.MikeScenarioID == MikeScenarioID
                        select c).FirstOrDefault();

                if (mikeScenario == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mikeScenario));
            }
            else
            {
                MikeScenario mikeScenario = (from c in db.MikeScenarios.AsNoTracking()
                        where c.MikeScenarioID == MikeScenarioID
                        select c).FirstOrDefault();

                if (mikeScenario == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mikeScenario));
            }
        }
        public async Task<ActionResult<List<MikeScenario>>> GetMikeScenarioList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<MikeScenario> mikeScenarioList = (from c in dbIM.MikeScenarios.AsNoTracking() orderby c.MikeScenarioID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(mikeScenarioList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<MikeScenario> mikeScenarioList = (from c in dbLocal.MikeScenarios.AsNoTracking() orderby c.MikeScenarioID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mikeScenarioList));
            }
            else
            {
                List<MikeScenario> mikeScenarioList = (from c in db.MikeScenarios.AsNoTracking() orderby c.MikeScenarioID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mikeScenarioList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int MikeScenarioID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MikeScenario mikeScenario = (from c in dbIM.MikeScenarios
                                   where c.MikeScenarioID == MikeScenarioID
                                   select c).FirstOrDefault();
            
                if (mikeScenario == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "MikeScenarioID", MikeScenarioID.ToString())));
                }
            
                try
                {
                    dbIM.MikeScenarios.Remove(mikeScenario);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }
            
                return await Task.FromResult(Ok(true));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                MikeScenario mikeScenario = (from c in dbLocal.MikeScenarios
                                   where c.MikeScenarioID == MikeScenarioID
                                   select c).FirstOrDefault();
                
                if (mikeScenario == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "MikeScenarioID", MikeScenarioID.ToString())));
                }

                try
                {
                   dbLocal.MikeScenarios.Remove(mikeScenario);
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
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<MikeScenario>> Post(MikeScenario mikeScenario)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MikeScenarios.Add(mikeScenario);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mikeScenario));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.MikeScenarios.Add(mikeScenario);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mikeScenario));
            }
            else
            {
                try
                {
                   db.MikeScenarios.Add(mikeScenario);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mikeScenario));
            }
        }
        public async Task<ActionResult<MikeScenario>> Put(MikeScenario mikeScenario)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MikeScenarios.Update(mikeScenario);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mikeScenario));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.MikeScenarios.Update(mikeScenario);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeScenario));
            }
            else
            {
            try
            {
               db.MikeScenarios.Update(mikeScenario);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeScenario));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MikeScenario mikeScenario = validationContext.ObjectInstance as MikeScenario;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeScenario.MikeScenarioID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeScenarioID"), new[] { nameof(mikeScenario.MikeScenarioID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.MikeScenarios select c).Where(c => c.MikeScenarioID == mikeScenario.MikeScenarioID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "MikeScenarioID", mikeScenario.MikeScenarioID.ToString()), new[] { nameof(mikeScenario.MikeScenarioID) });
                    }
                }
                else
                {
                    if (!(from c in db.MikeScenarios select c).Where(c => c.MikeScenarioID == mikeScenario.MikeScenarioID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "MikeScenarioID", mikeScenario.MikeScenarioID.ToString()), new[] { nameof(mikeScenario.MikeScenarioID) });
                    }
                }
            }

            TVItem TVItemMikeScenarioTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemMikeScenarioTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mikeScenario.MikeScenarioTVItemID select c).FirstOrDefault();
                if (TVItemMikeScenarioTVItemID == null)
                {
                    TVItemMikeScenarioTVItemID = (from c in dbIM.TVItems where c.TVItemID == mikeScenario.MikeScenarioTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemMikeScenarioTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenario.MikeScenarioTVItemID select c).FirstOrDefault();
            }

            if (TVItemMikeScenarioTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeScenarioTVItemID", mikeScenario.MikeScenarioTVItemID.ToString()), new[] { nameof(mikeScenario.MikeScenarioTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeScenario,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeScenarioTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MikeScenarioTVItemID", "MikeScenario"), new[] { nameof(mikeScenario.MikeScenarioTVItemID) });
                }
            }

            if (mikeScenario.ParentMikeScenarioID != null)
            {
                MikeScenario MikeScenarioParentMikeScenarioID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    MikeScenarioParentMikeScenarioID = (from c in dbLocal.MikeScenarios where c.MikeScenarioID == mikeScenario.ParentMikeScenarioID select c).FirstOrDefault();
                    if (MikeScenarioParentMikeScenarioID == null)
                    {
                        MikeScenarioParentMikeScenarioID = (from c in dbIM.MikeScenarios where c.MikeScenarioID == mikeScenario.ParentMikeScenarioID select c).FirstOrDefault();
                    }
                }
                else
                {
                    MikeScenarioParentMikeScenarioID = (from c in db.MikeScenarios where c.MikeScenarioID == mikeScenario.ParentMikeScenarioID select c).FirstOrDefault();
                }

                if (MikeScenarioParentMikeScenarioID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "ParentMikeScenarioID", (mikeScenario.ParentMikeScenarioID == null ? "" : mikeScenario.ParentMikeScenarioID.ToString())), new[] { nameof(mikeScenario.ParentMikeScenarioID) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(ScenarioStatusEnum), (int?)mikeScenario.ScenarioStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ScenarioStatus"), new[] { nameof(mikeScenario.ScenarioStatus) });
            }

            //ErrorInfo has no StringLength Attribute

            if (mikeScenario.MikeScenarioStartDateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeScenarioStartDateTime_Local"), new[] { nameof(mikeScenario.MikeScenarioStartDateTime_Local) });
            }
            else
            {
                if (mikeScenario.MikeScenarioStartDateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "MikeScenarioStartDateTime_Local", "1980"), new[] { nameof(mikeScenario.MikeScenarioStartDateTime_Local) });
                }
            }

            if (mikeScenario.MikeScenarioEndDateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeScenarioEndDateTime_Local"), new[] { nameof(mikeScenario.MikeScenarioEndDateTime_Local) });
            }
            else
            {
                if (mikeScenario.MikeScenarioEndDateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "MikeScenarioEndDateTime_Local", "1980"), new[] { nameof(mikeScenario.MikeScenarioEndDateTime_Local) });
                }
            }

            if (mikeScenario.MikeScenarioStartExecutionDateTime_Local != null && ((DateTime)mikeScenario.MikeScenarioStartExecutionDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "MikeScenarioStartExecutionDateTime_Local", "1980"), new[] { nameof(mikeScenario.MikeScenarioStartExecutionDateTime_Local) });
            }

            if (mikeScenario.MikeScenarioExecutionTime_min != null)
            {
                if (mikeScenario.MikeScenarioExecutionTime_min < 1 || mikeScenario.MikeScenarioExecutionTime_min > 100000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MikeScenarioExecutionTime_min", "1", "100000"), new[] { nameof(mikeScenario.MikeScenarioExecutionTime_min) });
                }
            }

            if (mikeScenario.WindSpeed_km_h < 0 || mikeScenario.WindSpeed_km_h > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WindSpeed_km_h", "0", "100"), new[] { nameof(mikeScenario.WindSpeed_km_h) });
            }

            if (mikeScenario.WindDirection_deg < 0 || mikeScenario.WindDirection_deg > 360)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WindDirection_deg", "0", "360"), new[] { nameof(mikeScenario.WindDirection_deg) });
            }

            if (mikeScenario.DecayFactor_per_day < 0 || mikeScenario.DecayFactor_per_day > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DecayFactor_per_day", "0", "100"), new[] { nameof(mikeScenario.DecayFactor_per_day) });
            }

            if (mikeScenario.DecayFactorAmplitude < 0 || mikeScenario.DecayFactorAmplitude > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DecayFactorAmplitude", "0", "100"), new[] { nameof(mikeScenario.DecayFactorAmplitude) });
            }

            if (mikeScenario.ResultFrequency_min < 0 || mikeScenario.ResultFrequency_min > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ResultFrequency_min", "0", "100"), new[] { nameof(mikeScenario.ResultFrequency_min) });
            }

            if (mikeScenario.AmbientTemperature_C < -10 || mikeScenario.AmbientTemperature_C > 40)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "AmbientTemperature_C", "-10", "40"), new[] { nameof(mikeScenario.AmbientTemperature_C) });
            }

            if (mikeScenario.AmbientSalinity_PSU < 0 || mikeScenario.AmbientSalinity_PSU > 40)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "AmbientSalinity_PSU", "0", "40"), new[] { nameof(mikeScenario.AmbientSalinity_PSU) });
            }

            if (mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID != null)
            {
                TVItem TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID select c).FirstOrDefault();
                    if (TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID == null)
                    {
                        TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = (from c in dbIM.TVItems where c.TVItemID == mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID select c).FirstOrDefault();
                }

                if (TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID", (mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID == null ? "" : mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID.ToString())), new[] { nameof(mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                    };
                    if (!AllowableTVTypes.Contains(TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID", "File"), new[] { nameof(mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID) });
                    }
                }
            }

            if (mikeScenario.ForSimulatingMWQMRunTVItemID != null)
            {
                TVItem TVItemForSimulatingMWQMRunTVItemID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    TVItemForSimulatingMWQMRunTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mikeScenario.ForSimulatingMWQMRunTVItemID select c).FirstOrDefault();
                    if (TVItemForSimulatingMWQMRunTVItemID == null)
                    {
                        TVItemForSimulatingMWQMRunTVItemID = (from c in dbIM.TVItems where c.TVItemID == mikeScenario.ForSimulatingMWQMRunTVItemID select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemForSimulatingMWQMRunTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenario.ForSimulatingMWQMRunTVItemID select c).FirstOrDefault();
                }

                if (TVItemForSimulatingMWQMRunTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ForSimulatingMWQMRunTVItemID", (mikeScenario.ForSimulatingMWQMRunTVItemID == null ? "" : mikeScenario.ForSimulatingMWQMRunTVItemID.ToString())), new[] { nameof(mikeScenario.ForSimulatingMWQMRunTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.MWQMRun,
                    };
                    if (!AllowableTVTypes.Contains(TVItemForSimulatingMWQMRunTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ForSimulatingMWQMRunTVItemID", "MWQMRun"), new[] { nameof(mikeScenario.ForSimulatingMWQMRunTVItemID) });
                    }
                }
            }

            if (mikeScenario.ManningNumber < 0 || mikeScenario.ManningNumber > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ManningNumber", "0", "100"), new[] { nameof(mikeScenario.ManningNumber) });
            }

            if (mikeScenario.NumberOfElements != null)
            {
                if (mikeScenario.NumberOfElements < 1 || mikeScenario.NumberOfElements > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfElements", "1", "1000000"), new[] { nameof(mikeScenario.NumberOfElements) });
                }
            }

            if (mikeScenario.NumberOfTimeSteps != null)
            {
                if (mikeScenario.NumberOfTimeSteps < 1 || mikeScenario.NumberOfTimeSteps > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfTimeSteps", "1", "1000000"), new[] { nameof(mikeScenario.NumberOfTimeSteps) });
                }
            }

            if (mikeScenario.NumberOfSigmaLayers != null)
            {
                if (mikeScenario.NumberOfSigmaLayers < 0 || mikeScenario.NumberOfSigmaLayers > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfSigmaLayers", "0", "100"), new[] { nameof(mikeScenario.NumberOfSigmaLayers) });
                }
            }

            if (mikeScenario.NumberOfZLayers != null)
            {
                if (mikeScenario.NumberOfZLayers < 0 || mikeScenario.NumberOfZLayers > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfZLayers", "0", "100"), new[] { nameof(mikeScenario.NumberOfZLayers) });
                }
            }

            if (mikeScenario.NumberOfHydroOutputParameters != null)
            {
                if (mikeScenario.NumberOfHydroOutputParameters < 0 || mikeScenario.NumberOfHydroOutputParameters > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfHydroOutputParameters", "0", "100"), new[] { nameof(mikeScenario.NumberOfHydroOutputParameters) });
                }
            }

            if (mikeScenario.NumberOfTransOutputParameters != null)
            {
                if (mikeScenario.NumberOfTransOutputParameters < 0 || mikeScenario.NumberOfTransOutputParameters > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfTransOutputParameters", "0", "100"), new[] { nameof(mikeScenario.NumberOfTransOutputParameters) });
                }
            }

            if (mikeScenario.EstimatedHydroFileSize != null)
            {
                if (mikeScenario.EstimatedHydroFileSize < 0 || mikeScenario.EstimatedHydroFileSize > 100000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "EstimatedHydroFileSize", "0", "100000000"), new[] { nameof(mikeScenario.EstimatedHydroFileSize) });
                }
            }

            if (mikeScenario.EstimatedTransFileSize != null)
            {
                if (mikeScenario.EstimatedTransFileSize < 0 || mikeScenario.EstimatedTransFileSize > 100000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "EstimatedTransFileSize", "0", "100000000"), new[] { nameof(mikeScenario.EstimatedTransFileSize) });
                }
            }

            if (mikeScenario.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mikeScenario.LastUpdateDate_UTC) });
            }
            else
            {
                if (mikeScenario.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mikeScenario.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mikeScenario.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == mikeScenario.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenario.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeScenario.LastUpdateContactTVItemID.ToString()), new[] { nameof(mikeScenario.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mikeScenario.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
