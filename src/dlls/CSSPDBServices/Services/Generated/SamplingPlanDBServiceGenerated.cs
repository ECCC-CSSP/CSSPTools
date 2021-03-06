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
    public partial interface ISamplingPlanDBService
    {
        Task<ActionResult<bool>> Delete(int SamplingPlanID);
        Task<ActionResult<List<SamplingPlan>>> GetSamplingPlanList(int skip = 0, int take = 100);
        Task<ActionResult<SamplingPlan>> GetSamplingPlanWithSamplingPlanID(int SamplingPlanID);
        Task<ActionResult<SamplingPlan>> Post(SamplingPlan samplingplan);
        Task<ActionResult<SamplingPlan>> Put(SamplingPlan samplingplan);
    }
    public partial class SamplingPlanDBService : ControllerBase, ISamplingPlanDBService
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
        public SamplingPlanDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<SamplingPlan>> GetSamplingPlanWithSamplingPlanID(int SamplingPlanID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            SamplingPlan samplingPlan = (from c in db.SamplingPlans.AsNoTracking()
                    where c.SamplingPlanID == SamplingPlanID
                    select c).FirstOrDefault();

            if (samplingPlan == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(samplingPlan));
        }
        public async Task<ActionResult<List<SamplingPlan>>> GetSamplingPlanList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<SamplingPlan> samplingPlanList = (from c in db.SamplingPlans.AsNoTracking() orderby c.SamplingPlanID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(samplingPlanList));
        }
        public async Task<ActionResult<bool>> Delete(int SamplingPlanID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            SamplingPlan samplingPlan = (from c in db.SamplingPlans
                    where c.SamplingPlanID == SamplingPlanID
                    select c).FirstOrDefault();

            if (samplingPlan == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", SamplingPlanID.ToString())));
            }

            try
            {
                db.SamplingPlans.Remove(samplingPlan);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<SamplingPlan>> Post(SamplingPlan samplingPlan)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(samplingPlan), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.SamplingPlans.Add(samplingPlan);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlan));
        }
        public async Task<ActionResult<SamplingPlan>> Put(SamplingPlan samplingPlan)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(samplingPlan), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.SamplingPlans.Update(samplingPlan);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlan));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            SamplingPlan samplingPlan = validationContext.ObjectInstance as SamplingPlan;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (samplingPlan.SamplingPlanID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SamplingPlanID"), new[] { nameof(samplingPlan.SamplingPlanID) }));
                }

                if (!(from c in db.SamplingPlans.AsNoTracking() select c).Where(c => c.SamplingPlanID == samplingPlan.SamplingPlanID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", samplingPlan.SamplingPlanID.ToString()), new[] { nameof(samplingPlan.SamplingPlanID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)samplingPlan.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(samplingPlan.DBCommand) }));
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanName))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SamplingPlanName"), new[] { nameof(samplingPlan.SamplingPlanName) }));
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanName) && samplingPlan.SamplingPlanName.Length > 200)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SamplingPlanName", "200"), new[] { nameof(samplingPlan.SamplingPlanName) }));
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.ForGroupName))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ForGroupName"), new[] { nameof(samplingPlan.ForGroupName) }));
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.ForGroupName) && samplingPlan.ForGroupName.Length > 100)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ForGroupName", "100"), new[] { nameof(samplingPlan.ForGroupName) }));
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)samplingPlan.SampleType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SampleType"), new[] { nameof(samplingPlan.SampleType) }));
            }

            retStr = enums.EnumTypeOK(typeof(SamplingPlanTypeEnum), (int?)samplingPlan.SamplingPlanType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SamplingPlanType"), new[] { nameof(samplingPlan.SamplingPlanType) }));
            }

            retStr = enums.EnumTypeOK(typeof(LabSheetTypeEnum), (int?)samplingPlan.LabSheetType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LabSheetType"), new[] { nameof(samplingPlan.LabSheetType) }));
            }

            TVItem TVItemProvinceTVItemID = null;
            TVItemProvinceTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == samplingPlan.ProvinceTVItemID select c).FirstOrDefault();

            if (TVItemProvinceTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ProvinceTVItemID", samplingPlan.ProvinceTVItemID.ToString()), new[] { nameof(samplingPlan.ProvinceTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Province,
                };
                if (!AllowableTVTypes.Contains(TVItemProvinceTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ProvinceTVItemID", "Province"), new[] { nameof(samplingPlan.ProvinceTVItemID) }));
                }
            }

            TVItem TVItemCreatorTVItemID = null;
            TVItemCreatorTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == samplingPlan.CreatorTVItemID select c).FirstOrDefault();

            if (TVItemCreatorTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "CreatorTVItemID", samplingPlan.CreatorTVItemID.ToString()), new[] { nameof(samplingPlan.CreatorTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemCreatorTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "CreatorTVItemID", "Contact"), new[] { nameof(samplingPlan.CreatorTVItemID) }));
                }
            }

            if (samplingPlan.Year < 2000 || samplingPlan.Year > 2050)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Year", "2000", "2050"), new[] { nameof(samplingPlan.Year) }));
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.AccessCode))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AccessCode"), new[] { nameof(samplingPlan.AccessCode) }));
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.AccessCode) && samplingPlan.AccessCode.Length > 15)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AccessCode", "15"), new[] { nameof(samplingPlan.AccessCode) }));
            }

            if (samplingPlan.DailyDuplicatePrecisionCriteria < 0 || samplingPlan.DailyDuplicatePrecisionCriteria > 100)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DailyDuplicatePrecisionCriteria", "0", "100"), new[] { nameof(samplingPlan.DailyDuplicatePrecisionCriteria) }));
            }

            if (samplingPlan.IntertechDuplicatePrecisionCriteria < 0 || samplingPlan.IntertechDuplicatePrecisionCriteria > 100)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "IntertechDuplicatePrecisionCriteria", "0", "100"), new[] { nameof(samplingPlan.IntertechDuplicatePrecisionCriteria) }));
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.ApprovalCode))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ApprovalCode"), new[] { nameof(samplingPlan.ApprovalCode) }));
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.ApprovalCode) && samplingPlan.ApprovalCode.Length > 15)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ApprovalCode", "15"), new[] { nameof(samplingPlan.ApprovalCode) }));
            }

            if (samplingPlan.SamplingPlanFileTVItemID != null)
            {
                TVItem TVItemSamplingPlanFileTVItemID = null;
                TVItemSamplingPlanFileTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == samplingPlan.SamplingPlanFileTVItemID select c).FirstOrDefault();

                if (TVItemSamplingPlanFileTVItemID == null)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanFileTVItemID", (samplingPlan.SamplingPlanFileTVItemID == null ? "" : samplingPlan.SamplingPlanFileTVItemID.ToString())), new[] { nameof(samplingPlan.SamplingPlanFileTVItemID) }));
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                    };
                    if (!AllowableTVTypes.Contains(TVItemSamplingPlanFileTVItemID.TVType))
                    {
                        ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "SamplingPlanFileTVItemID", "File"), new[] { nameof(samplingPlan.SamplingPlanFileTVItemID) }));
                    }
                }
            }

            if (samplingPlan.AnalyzeMethodDefault != null)
            {
                retStr = enums.EnumTypeOK(typeof(AnalyzeMethodEnum), (int?)samplingPlan.AnalyzeMethodDefault);
                if (samplingPlan.AnalyzeMethodDefault == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AnalyzeMethodDefault"), new[] { nameof(samplingPlan.AnalyzeMethodDefault) }));
                }
            }

            if (samplingPlan.SampleMatrixDefault != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleMatrixEnum), (int?)samplingPlan.SampleMatrixDefault);
                if (samplingPlan.SampleMatrixDefault == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SampleMatrixDefault"), new[] { nameof(samplingPlan.SampleMatrixDefault) }));
                }
            }

            if (samplingPlan.LaboratoryDefault != null)
            {
                retStr = enums.EnumTypeOK(typeof(LaboratoryEnum), (int?)samplingPlan.LaboratoryDefault);
                if (samplingPlan.LaboratoryDefault == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LaboratoryDefault"), new[] { nameof(samplingPlan.LaboratoryDefault) }));
                }
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.BackupDirectory))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "BackupDirectory"), new[] { nameof(samplingPlan.BackupDirectory) }));
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.BackupDirectory) && samplingPlan.BackupDirectory.Length > 250)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "BackupDirectory", "250"), new[] { nameof(samplingPlan.BackupDirectory) }));
            }

            if (samplingPlan.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(samplingPlan.LastUpdateDate_UTC) }));
            }
            else
            {
                if (samplingPlan.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(samplingPlan.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == samplingPlan.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", samplingPlan.LastUpdateContactTVItemID.ToString()), new[] { nameof(samplingPlan.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(samplingPlan.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
