/*
 * Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
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
   public interface ISamplingPlanService
    {
       Task<ActionResult<SamplingPlan>> GetSamplingPlanWithSamplingPlanID(int SamplingPlanID);
       Task<ActionResult<List<SamplingPlan>>> GetSamplingPlanList();
       Task<ActionResult<SamplingPlan>> Add(SamplingPlan samplingplan);
       Task<ActionResult<bool>> Delete(int SamplingPlanID);
       Task<ActionResult<SamplingPlan>> Update(SamplingPlan samplingplan);
    }
    public partial class SamplingPlanService : ControllerBase, ISamplingPlanService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private ICultureService CultureService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanService(ICultureService CultureService, IEnums enums, CSSPDBContext db)
        {
            this.CultureService = CultureService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<SamplingPlan>> GetSamplingPlanWithSamplingPlanID(int SamplingPlanID)
        {
            SamplingPlan samplingplan = (from c in db.SamplingPlans.AsNoTracking()
                    where c.SamplingPlanID == SamplingPlanID
                    select c).FirstOrDefault();

            if (samplingplan == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(samplingplan));
        }
        public async Task<ActionResult<List<SamplingPlan>>> GetSamplingPlanList()
        {
            List<SamplingPlan> samplingplanList = (from c in db.SamplingPlans.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(samplingplanList));
        }
        public async Task<ActionResult<SamplingPlan>> Add(SamplingPlan samplingPlan)
        {
            ValidationResults = Validate(new ValidationContext(samplingPlan), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.SamplingPlans.Add(samplingPlan);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlan));
        }
        public async Task<ActionResult<bool>> Delete(int SamplingPlanID)
        {
            SamplingPlan samplingPlan = (from c in db.SamplingPlans
                               where c.SamplingPlanID == SamplingPlanID
                               select c).FirstOrDefault();
            
            if (samplingPlan == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", SamplingPlanID.ToString())));
            }

            try
            {
               db.SamplingPlans.Remove(samplingPlan);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<SamplingPlan>> Update(SamplingPlan samplingPlan)
        {
            ValidationResults = Validate(new ValidationContext(samplingPlan), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.SamplingPlans.Update(samplingPlan);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlan));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            SamplingPlan samplingPlan = validationContext.ObjectInstance as SamplingPlan;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (samplingPlan.SamplingPlanID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "SamplingPlanID"), new[] { "SamplingPlanID" });
                }

                if (!(from c in db.SamplingPlans select c).Where(c => c.SamplingPlanID == samplingPlan.SamplingPlanID).Any())
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", samplingPlan.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
                }
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanName))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "SamplingPlanName"), new[] { "SamplingPlanName" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanName) && samplingPlan.SamplingPlanName.Length > 200)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "SamplingPlanName", "200"), new[] { "SamplingPlanName" });
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.ForGroupName))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "ForGroupName"), new[] { "ForGroupName" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.ForGroupName) && samplingPlan.ForGroupName.Length > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "ForGroupName", "100"), new[] { "ForGroupName" });
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)samplingPlan.SampleType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "SampleType"), new[] { "SampleType" });
            }

            retStr = enums.EnumTypeOK(typeof(SamplingPlanTypeEnum), (int?)samplingPlan.SamplingPlanType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "SamplingPlanType"), new[] { "SamplingPlanType" });
            }

            retStr = enums.EnumTypeOK(typeof(LabSheetTypeEnum), (int?)samplingPlan.LabSheetType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LabSheetType"), new[] { "LabSheetType" });
            }

            TVItem TVItemProvinceTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.ProvinceTVItemID select c).FirstOrDefault();

            if (TVItemProvinceTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ProvinceTVItemID", samplingPlan.ProvinceTVItemID.ToString()), new[] { "ProvinceTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Province,
                };
                if (!AllowableTVTypes.Contains(TVItemProvinceTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "ProvinceTVItemID", "Province"), new[] { "ProvinceTVItemID" });
                }
            }

            TVItem TVItemCreatorTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.CreatorTVItemID select c).FirstOrDefault();

            if (TVItemCreatorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "CreatorTVItemID", samplingPlan.CreatorTVItemID.ToString()), new[] { "CreatorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemCreatorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "CreatorTVItemID", "Contact"), new[] { "CreatorTVItemID" });
                }
            }

            if (samplingPlan.Year < 2000 || samplingPlan.Year > 2050)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Year", "2000", "2050"), new[] { "Year" });
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.AccessCode))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "AccessCode"), new[] { "AccessCode" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.AccessCode) && samplingPlan.AccessCode.Length > 15)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "AccessCode", "15"), new[] { "AccessCode" });
            }

            if (samplingPlan.DailyDuplicatePrecisionCriteria < 0 || samplingPlan.DailyDuplicatePrecisionCriteria > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "DailyDuplicatePrecisionCriteria", "0", "100"), new[] { "DailyDuplicatePrecisionCriteria" });
            }

            if (samplingPlan.IntertechDuplicatePrecisionCriteria < 0 || samplingPlan.IntertechDuplicatePrecisionCriteria > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "IntertechDuplicatePrecisionCriteria", "0", "100"), new[] { "IntertechDuplicatePrecisionCriteria" });
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.ApprovalCode))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "ApprovalCode"), new[] { "ApprovalCode" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.ApprovalCode) && samplingPlan.ApprovalCode.Length > 15)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "ApprovalCode", "15"), new[] { "ApprovalCode" });
            }

            if (samplingPlan.SamplingPlanFileTVItemID != null)
            {
                TVItem TVItemSamplingPlanFileTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.SamplingPlanFileTVItemID select c).FirstOrDefault();

                if (TVItemSamplingPlanFileTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanFileTVItemID", (samplingPlan.SamplingPlanFileTVItemID == null ? "" : samplingPlan.SamplingPlanFileTVItemID.ToString())), new[] { "SamplingPlanFileTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                    };
                    if (!AllowableTVTypes.Contains(TVItemSamplingPlanFileTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "SamplingPlanFileTVItemID", "File"), new[] { "SamplingPlanFileTVItemID" });
                    }
                }
            }

            if (samplingPlan.AnalyzeMethodDefault != null)
            {
                retStr = enums.EnumTypeOK(typeof(AnalyzeMethodEnum), (int?)samplingPlan.AnalyzeMethodDefault);
                if (samplingPlan.AnalyzeMethodDefault == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "AnalyzeMethodDefault"), new[] { "AnalyzeMethodDefault" });
                }
            }

            if (samplingPlan.SampleMatrixDefault != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleMatrixEnum), (int?)samplingPlan.SampleMatrixDefault);
                if (samplingPlan.SampleMatrixDefault == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "SampleMatrixDefault"), new[] { "SampleMatrixDefault" });
                }
            }

            if (samplingPlan.LaboratoryDefault != null)
            {
                retStr = enums.EnumTypeOK(typeof(LaboratoryEnum), (int?)samplingPlan.LaboratoryDefault);
                if (samplingPlan.LaboratoryDefault == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LaboratoryDefault"), new[] { "LaboratoryDefault" });
                }
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.BackupDirectory))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "BackupDirectory"), new[] { "BackupDirectory" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.BackupDirectory) && samplingPlan.BackupDirectory.Length > 250)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "BackupDirectory", "250"), new[] { "BackupDirectory" });
            }

            if (samplingPlan.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlan.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", samplingPlan.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
