/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ClassName]ServiceGenerated.cs] button
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
    public partial class MikeScenarioService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeScenarioService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MikeScenario mikeScenario = validationContext.ObjectInstance as MikeScenario;
            mikeScenario.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeScenario.MikeScenarioID == 0)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioID"), new[] { "MikeScenarioID" });
                }

                if (!(from c in db.MikeScenarios select c).Where(c => c.MikeScenarioID == mikeScenario.MikeScenarioID).Any())
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "MikeScenarioID", mikeScenario.MikeScenarioID.ToString()), new[] { "MikeScenarioID" });
                }
            }

            TVItem TVItemMikeScenarioTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenario.MikeScenarioTVItemID select c).FirstOrDefault();

            if (TVItemMikeScenarioTVItemID == null)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeScenarioTVItemID", mikeScenario.MikeScenarioTVItemID.ToString()), new[] { "MikeScenarioTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeScenario,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeScenarioTVItemID.TVType))
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MikeScenarioTVItemID", "MikeScenario"), new[] { "MikeScenarioTVItemID" });
                }
            }

            if (mikeScenario.ParentMikeScenarioID != null)
            {
                TVItem TVItemParentMikeScenarioID = (from c in db.TVItems where c.TVItemID == mikeScenario.ParentMikeScenarioID select c).FirstOrDefault();

                if (TVItemParentMikeScenarioID == null)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ParentMikeScenarioID", (mikeScenario.ParentMikeScenarioID == null ? "" : mikeScenario.ParentMikeScenarioID.ToString())), new[] { "ParentMikeScenarioID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.MikeScenario,
                    };
                    if (!AllowableTVTypes.Contains(TVItemParentMikeScenarioID.TVType))
                    {
                        mikeScenario.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ParentMikeScenarioID", "MikeScenario"), new[] { "ParentMikeScenarioID" });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(ScenarioStatusEnum), (int?)mikeScenario.ScenarioStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ScenarioStatus"), new[] { "ScenarioStatus" });
            }

            //ErrorInfo has no StringLength Attribute

            if (mikeScenario.MikeScenarioStartDateTime_Local.Year == 1)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioStartDateTime_Local"), new[] { "MikeScenarioStartDateTime_Local" });
            }
            else
            {
                if (mikeScenario.MikeScenarioStartDateTime_Local.Year < 1980)
                {
                mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeScenarioStartDateTime_Local", "1980"), new[] { "MikeScenarioStartDateTime_Local" });
                }
            }

            if (mikeScenario.MikeScenarioEndDateTime_Local.Year == 1)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioEndDateTime_Local"), new[] { "MikeScenarioEndDateTime_Local" });
            }
            else
            {
                if (mikeScenario.MikeScenarioEndDateTime_Local.Year < 1980)
                {
                mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeScenarioEndDateTime_Local", "1980"), new[] { "MikeScenarioEndDateTime_Local" });
                }
            }

            if (mikeScenario.MikeScenarioStartExecutionDateTime_Local != null && ((DateTime)mikeScenario.MikeScenarioStartExecutionDateTime_Local).Year < 1980)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeScenarioStartExecutionDateTime_Local", "1980"), new[] { "MikeScenarioStartExecutionDateTime_Local" });
            }

            if (mikeScenario.MikeScenarioExecutionTime_min != null)
            {
                if (mikeScenario.MikeScenarioExecutionTime_min < 1 || mikeScenario.MikeScenarioExecutionTime_min > 100000)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioExecutionTime_min", "1", "100000"), new[] { "MikeScenarioExecutionTime_min" });
                }
            }

            if (mikeScenario.WindSpeed_km_h < 0 || mikeScenario.WindSpeed_km_h > 100)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "WindSpeed_km_h", "0", "100"), new[] { "WindSpeed_km_h" });
            }

            if (mikeScenario.WindDirection_deg < 0 || mikeScenario.WindDirection_deg > 360)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "WindDirection_deg", "0", "360"), new[] { "WindDirection_deg" });
            }

            if (mikeScenario.DecayFactor_per_day < 0 || mikeScenario.DecayFactor_per_day > 100)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DecayFactor_per_day", "0", "100"), new[] { "DecayFactor_per_day" });
            }

            if (mikeScenario.DecayFactorAmplitude < 0 || mikeScenario.DecayFactorAmplitude > 100)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DecayFactorAmplitude", "0", "100"), new[] { "DecayFactorAmplitude" });
            }

            if (mikeScenario.ResultFrequency_min < 0 || mikeScenario.ResultFrequency_min > 100)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ResultFrequency_min", "0", "100"), new[] { "ResultFrequency_min" });
            }

            if (mikeScenario.AmbientTemperature_C < -10 || mikeScenario.AmbientTemperature_C > 40)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AmbientTemperature_C", "-10", "40"), new[] { "AmbientTemperature_C" });
            }

            if (mikeScenario.AmbientSalinity_PSU < 0 || mikeScenario.AmbientSalinity_PSU > 40)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AmbientSalinity_PSU", "0", "40"), new[] { "AmbientSalinity_PSU" });
            }

            if (mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID != null)
            {
                TVItem TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID select c).FirstOrDefault();

                if (TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID == null)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID", (mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID == null ? "" : mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID.ToString())), new[] { "UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                    };
                    if (!AllowableTVTypes.Contains(TVItemUseSalinityAndTemperatureInitialConditionFromTVFileTVItemID.TVType))
                    {
                        mikeScenario.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID", "File"), new[] { "UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID" });
                    }
                }
            }

            if (mikeScenario.ForSimulatingMWQMRunTVItemID != null)
            {
                TVItem TVItemForSimulatingMWQMRunTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenario.ForSimulatingMWQMRunTVItemID select c).FirstOrDefault();

                if (TVItemForSimulatingMWQMRunTVItemID == null)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ForSimulatingMWQMRunTVItemID", (mikeScenario.ForSimulatingMWQMRunTVItemID == null ? "" : mikeScenario.ForSimulatingMWQMRunTVItemID.ToString())), new[] { "ForSimulatingMWQMRunTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.MWQMRun,
                    };
                    if (!AllowableTVTypes.Contains(TVItemForSimulatingMWQMRunTVItemID.TVType))
                    {
                        mikeScenario.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ForSimulatingMWQMRunTVItemID", "MWQMRun"), new[] { "ForSimulatingMWQMRunTVItemID" });
                    }
                }
            }

            if (mikeScenario.ManningNumber < 0 || mikeScenario.ManningNumber > 100)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ManningNumber", "0", "100"), new[] { "ManningNumber" });
            }

            if (mikeScenario.NumberOfElements != null)
            {
                if (mikeScenario.NumberOfElements < 1 || mikeScenario.NumberOfElements > 1000000)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "NumberOfElements", "1", "1000000"), new[] { "NumberOfElements" });
                }
            }

            if (mikeScenario.NumberOfTimeSteps != null)
            {
                if (mikeScenario.NumberOfTimeSteps < 1 || mikeScenario.NumberOfTimeSteps > 1000000)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "NumberOfTimeSteps", "1", "1000000"), new[] { "NumberOfTimeSteps" });
                }
            }

            if (mikeScenario.NumberOfSigmaLayers != null)
            {
                if (mikeScenario.NumberOfSigmaLayers < 0 || mikeScenario.NumberOfSigmaLayers > 100)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "NumberOfSigmaLayers", "0", "100"), new[] { "NumberOfSigmaLayers" });
                }
            }

            if (mikeScenario.NumberOfZLayers != null)
            {
                if (mikeScenario.NumberOfZLayers < 0 || mikeScenario.NumberOfZLayers > 100)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "NumberOfZLayers", "0", "100"), new[] { "NumberOfZLayers" });
                }
            }

            if (mikeScenario.NumberOfHydroOutputParameters != null)
            {
                if (mikeScenario.NumberOfHydroOutputParameters < 0 || mikeScenario.NumberOfHydroOutputParameters > 100)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "NumberOfHydroOutputParameters", "0", "100"), new[] { "NumberOfHydroOutputParameters" });
                }
            }

            if (mikeScenario.NumberOfTransOutputParameters != null)
            {
                if (mikeScenario.NumberOfTransOutputParameters < 0 || mikeScenario.NumberOfTransOutputParameters > 100)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "NumberOfTransOutputParameters", "0", "100"), new[] { "NumberOfTransOutputParameters" });
                }
            }

            if (mikeScenario.EstimatedHydroFileSize != null)
            {
                if (mikeScenario.EstimatedHydroFileSize < 0 || mikeScenario.EstimatedHydroFileSize > 100000000)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "EstimatedHydroFileSize", "0", "100000000"), new[] { "EstimatedHydroFileSize" });
                }
            }

            if (mikeScenario.EstimatedTransFileSize != null)
            {
                if (mikeScenario.EstimatedTransFileSize < 0 || mikeScenario.EstimatedTransFileSize > 100000000)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "EstimatedTransFileSize", "0", "100000000"), new[] { "EstimatedTransFileSize" });
                }
            }

            if (mikeScenario.LastUpdateDate_UTC.Year == 1)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeScenario.LastUpdateDate_UTC.Year < 1980)
                {
                mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenario.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeScenario.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MikeScenario GetMikeScenarioWithMikeScenarioID(int MikeScenarioID)
        {
            return (from c in db.MikeScenarios
                    where c.MikeScenarioID == MikeScenarioID
                    select c).FirstOrDefault();

        }
        public IQueryable<MikeScenario> GetMikeScenarioList()
        {
            IQueryable<MikeScenario> MikeScenarioQuery = (from c in db.MikeScenarios select c);

            MikeScenarioQuery = EnhanceQueryStatements<MikeScenario>(MikeScenarioQuery) as IQueryable<MikeScenario>;

            return MikeScenarioQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MikeScenario mikeScenario)
        {
            mikeScenario.ValidationResults = Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Create);
            if (mikeScenario.ValidationResults.Count() > 0) return false;

            db.MikeScenarios.Add(mikeScenario);

            if (!TryToSave(mikeScenario)) return false;

            return true;
        }
        public bool Delete(MikeScenario mikeScenario)
        {
            mikeScenario.ValidationResults = Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Delete);
            if (mikeScenario.ValidationResults.Count() > 0) return false;

            db.MikeScenarios.Remove(mikeScenario);

            if (!TryToSave(mikeScenario)) return false;

            return true;
        }
        public bool Update(MikeScenario mikeScenario)
        {
            mikeScenario.ValidationResults = Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Update);
            if (mikeScenario.ValidationResults.Count() > 0) return false;

            db.MikeScenarios.Update(mikeScenario);

            if (!TryToSave(mikeScenario)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(MikeScenario mikeScenario)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeScenario.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
