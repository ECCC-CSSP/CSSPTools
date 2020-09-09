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
using LocalServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBLocalServices
{
    public partial interface ILabSheetDetailDBLocalService
    {
        Task<ActionResult<bool>> Delete(int LabSheetDetailID);
        Task<ActionResult<List<LabSheetDetail>>> GetLabSheetDetailList(int skip = 0, int take = 100);
        Task<ActionResult<LabSheetDetail>> GetLabSheetDetailWithLabSheetDetailID(int LabSheetDetailID);
        Task<ActionResult<LabSheetDetail>> Post(LabSheetDetail labsheetdetail);
        Task<ActionResult<LabSheetDetail>> Put(LabSheetDetail labsheetdetail);
    }
    public partial class LabSheetDetailDBLocalService : ControllerBase, ILabSheetDetailDBLocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBInMemoryContext dbLocalIM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext dbLocal,
           CSSPDBInMemoryContext dbLocalIM)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.dbLocal = dbLocal;
            this.dbLocalIM = dbLocalIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<LabSheetDetail>> GetLabSheetDetailWithLabSheetDetailID(int LabSheetDetailID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LabSheetDetail labSheetDetail = (from c in dbLocal.LabSheetDetails.AsNoTracking()
                    where c.LabSheetDetailID == LabSheetDetailID
                    select c).FirstOrDefault();

            if (labSheetDetail == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(labSheetDetail));
        }
        public async Task<ActionResult<List<LabSheetDetail>>> GetLabSheetDetailList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LabSheetDetail> labSheetDetailList = (from c in dbLocal.LabSheetDetails.AsNoTracking() orderby c.LabSheetDetailID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(labSheetDetailList));
        }
        public async Task<ActionResult<bool>> Delete(int LabSheetDetailID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LabSheetDetail labSheetDetail = (from c in dbLocal.LabSheetDetails
                    where c.LabSheetDetailID == LabSheetDetailID
                    select c).FirstOrDefault();

            if (labSheetDetail == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheetDetail", "LabSheetDetailID", LabSheetDetailID.ToString())));
            }

            try
            {
                dbLocal.LabSheetDetails.Remove(labSheetDetail);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LabSheetDetail>> Post(LabSheetDetail labSheetDetail)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(labSheetDetail), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (labSheetDetail.LabSheetDetailID == 0)
            {
                int LastLabSheetDetailID = (from c in dbLocal.LabSheetDetails.AsNoTracking()
                          orderby c.LabSheetDetailID descending
                          select c.LabSheetDetailID).FirstOrDefault();

                labSheetDetail.LabSheetDetailID = LastLabSheetDetailID + 1;
            }

            try
            {
                dbLocal.LabSheetDetails.Add(labSheetDetail);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(labSheetDetail));
        }
        public async Task<ActionResult<LabSheetDetail>> Put(LabSheetDetail labSheetDetail)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(labSheetDetail), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.LabSheetDetails.Update(labSheetDetail);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(labSheetDetail));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            LabSheetDetail labSheetDetail = validationContext.ObjectInstance as LabSheetDetail;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (labSheetDetail.LabSheetDetailID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LabSheetDetailID"), new[] { nameof(labSheetDetail.LabSheetDetailID) });
                }

                if (!(from c in dbLocal.LabSheetDetails.AsNoTracking() select c).Where(c => c.LabSheetDetailID == labSheetDetail.LabSheetDetailID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheetDetail", "LabSheetDetailID", labSheetDetail.LabSheetDetailID.ToString()), new[] { nameof(labSheetDetail.LabSheetDetailID) });
                }
            }

            LabSheet LabSheetLabSheetID = null;
            LabSheetLabSheetID = (from c in dbLocal.LabSheets.AsNoTracking() where c.LabSheetID == labSheetDetail.LabSheetID select c).FirstOrDefault();

            if (LabSheetLabSheetID == null)
            {
                LabSheetLabSheetID = (from c in dbLocalIM.LabSheets.Local where c.LabSheetID == labSheetDetail.LabSheetID select c).FirstOrDefault();

                if (LabSheetLabSheetID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheet", "LabSheetID", labSheetDetail.LabSheetID.ToString()), new[] { nameof(labSheetDetail.LabSheetID) });
                }

            }

            SamplingPlan SamplingPlanSamplingPlanID = null;
            SamplingPlanSamplingPlanID = (from c in dbLocal.SamplingPlans.AsNoTracking() where c.SamplingPlanID == labSheetDetail.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                SamplingPlanSamplingPlanID = (from c in dbLocalIM.SamplingPlans.Local where c.SamplingPlanID == labSheetDetail.SamplingPlanID select c).FirstOrDefault();

                if (SamplingPlanSamplingPlanID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", labSheetDetail.SamplingPlanID.ToString()), new[] { nameof(labSheetDetail.SamplingPlanID) });
                }

            }

            TVItem TVItemSubsectorTVItemID = null;
            TVItemSubsectorTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == labSheetDetail.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                TVItemSubsectorTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == labSheetDetail.SubsectorTVItemID select c).FirstOrDefault();

                if (TVItemSubsectorTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "SubsectorTVItemID", labSheetDetail.SubsectorTVItemID.ToString()), new[] { nameof(labSheetDetail.SubsectorTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Subsector,
                    };
                    if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { nameof(labSheetDetail.SubsectorTVItemID) });
                    }
                }

            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { nameof(labSheetDetail.SubsectorTVItemID) });
                }
            }

            if (labSheetDetail.Version < 1 || labSheetDetail.Version > 5)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Version", "1", "5"), new[] { nameof(labSheetDetail.Version) });
            }

            if (labSheetDetail.RunDate.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RunDate"), new[] { nameof(labSheetDetail.RunDate) });
            }
            else
            {
                if (labSheetDetail.RunDate.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "RunDate", "1980"), new[] { nameof(labSheetDetail.RunDate) });
                }
            }

            if (string.IsNullOrWhiteSpace(labSheetDetail.Tides))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Tides"), new[] { nameof(labSheetDetail.Tides) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Tides) && (labSheetDetail.Tides.Length < 1 || labSheetDetail.Tides.Length > 7))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Tides", "1", "7"), new[] { nameof(labSheetDetail.Tides) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.SampleCrewInitials) && labSheetDetail.SampleCrewInitials.Length > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SampleCrewInitials", "20"), new[] { nameof(labSheetDetail.SampleCrewInitials) });
            }

            if (labSheetDetail.WaterBathCount != null)
            {
                if (labSheetDetail.WaterBathCount < 1 || labSheetDetail.WaterBathCount > 3)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WaterBathCount", "1", "3"), new[] { nameof(labSheetDetail.WaterBathCount) });
                }
            }

            if (labSheetDetail.IncubationBath1StartTime != null && ((DateTime)labSheetDetail.IncubationBath1StartTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "IncubationBath1StartTime", "1980"), new[] { nameof(labSheetDetail.IncubationBath1StartTime) });
            }

            if (labSheetDetail.IncubationBath2StartTime != null && ((DateTime)labSheetDetail.IncubationBath2StartTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "IncubationBath2StartTime", "1980"), new[] { nameof(labSheetDetail.IncubationBath2StartTime) });
            }

            if (labSheetDetail.IncubationBath3StartTime != null && ((DateTime)labSheetDetail.IncubationBath3StartTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "IncubationBath3StartTime", "1980"), new[] { nameof(labSheetDetail.IncubationBath3StartTime) });
            }

            if (labSheetDetail.IncubationBath1EndTime != null && ((DateTime)labSheetDetail.IncubationBath1EndTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "IncubationBath1EndTime", "1980"), new[] { nameof(labSheetDetail.IncubationBath1EndTime) });
            }

            if (labSheetDetail.IncubationBath2EndTime != null && ((DateTime)labSheetDetail.IncubationBath2EndTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "IncubationBath2EndTime", "1980"), new[] { nameof(labSheetDetail.IncubationBath2EndTime) });
            }

            if (labSheetDetail.IncubationBath3EndTime != null && ((DateTime)labSheetDetail.IncubationBath3EndTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "IncubationBath3EndTime", "1980"), new[] { nameof(labSheetDetail.IncubationBath3EndTime) });
            }

            if (labSheetDetail.IncubationBath1TimeCalculated_minutes != null)
            {
                if (labSheetDetail.IncubationBath1TimeCalculated_minutes < 0 || labSheetDetail.IncubationBath1TimeCalculated_minutes > 10000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "IncubationBath1TimeCalculated_minutes", "0", "10000"), new[] { nameof(labSheetDetail.IncubationBath1TimeCalculated_minutes) });
                }
            }

            if (labSheetDetail.IncubationBath2TimeCalculated_minutes != null)
            {
                if (labSheetDetail.IncubationBath2TimeCalculated_minutes < 0 || labSheetDetail.IncubationBath2TimeCalculated_minutes > 10000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "IncubationBath2TimeCalculated_minutes", "0", "10000"), new[] { nameof(labSheetDetail.IncubationBath2TimeCalculated_minutes) });
                }
            }

            if (labSheetDetail.IncubationBath3TimeCalculated_minutes != null)
            {
                if (labSheetDetail.IncubationBath3TimeCalculated_minutes < 0 || labSheetDetail.IncubationBath3TimeCalculated_minutes > 10000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "IncubationBath3TimeCalculated_minutes", "0", "10000"), new[] { nameof(labSheetDetail.IncubationBath3TimeCalculated_minutes) });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.WaterBath1) && labSheetDetail.WaterBath1.Length > 10)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "WaterBath1", "10"), new[] { nameof(labSheetDetail.WaterBath1) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.WaterBath2) && labSheetDetail.WaterBath2.Length > 10)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "WaterBath2", "10"), new[] { nameof(labSheetDetail.WaterBath2) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.WaterBath3) && labSheetDetail.WaterBath3.Length > 10)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "WaterBath3", "10"), new[] { nameof(labSheetDetail.WaterBath3) });
            }

            if (labSheetDetail.TCField1 != null)
            {
                if (labSheetDetail.TCField1 < -10 || labSheetDetail.TCField1 > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TCField1", "-10", "40"), new[] { nameof(labSheetDetail.TCField1) });
                }
            }

            if (labSheetDetail.TCLab1 != null)
            {
                if (labSheetDetail.TCLab1 < -10 || labSheetDetail.TCLab1 > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TCLab1", "-10", "40"), new[] { nameof(labSheetDetail.TCLab1) });
                }
            }

            if (labSheetDetail.TCField2 != null)
            {
                if (labSheetDetail.TCField2 < -10 || labSheetDetail.TCField2 > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TCField2", "-10", "40"), new[] { nameof(labSheetDetail.TCField2) });
                }
            }

            if (labSheetDetail.TCLab2 != null)
            {
                if (labSheetDetail.TCLab2 < -10 || labSheetDetail.TCLab2 > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TCLab2", "-10", "40"), new[] { nameof(labSheetDetail.TCLab2) });
                }
            }

            if (labSheetDetail.TCFirst != null)
            {
                if (labSheetDetail.TCFirst < -10 || labSheetDetail.TCFirst > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TCFirst", "-10", "40"), new[] { nameof(labSheetDetail.TCFirst) });
                }
            }

            if (labSheetDetail.TCAverage != null)
            {
                if (labSheetDetail.TCAverage < -10 || labSheetDetail.TCAverage > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TCAverage", "-10", "40"), new[] { nameof(labSheetDetail.TCAverage) });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.ControlLot) && labSheetDetail.ControlLot.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ControlLot", "100"), new[] { nameof(labSheetDetail.ControlLot) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Positive35) && (labSheetDetail.Positive35.Length < 1 || labSheetDetail.Positive35.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Positive35", "1", "1"), new[] { nameof(labSheetDetail.Positive35) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.NonTarget35) && (labSheetDetail.NonTarget35.Length < 1 || labSheetDetail.NonTarget35.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "NonTarget35", "1", "1"), new[] { nameof(labSheetDetail.NonTarget35) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Negative35) && (labSheetDetail.Negative35.Length < 1 || labSheetDetail.Negative35.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Negative35", "1", "1"), new[] { nameof(labSheetDetail.Negative35) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1Positive44_5) && (labSheetDetail.Bath1Positive44_5.Length < 1 || labSheetDetail.Bath1Positive44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Bath1Positive44_5", "1", "1"), new[] { nameof(labSheetDetail.Bath1Positive44_5) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2Positive44_5) && (labSheetDetail.Bath2Positive44_5.Length < 1 || labSheetDetail.Bath2Positive44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Bath2Positive44_5", "1", "1"), new[] { nameof(labSheetDetail.Bath2Positive44_5) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3Positive44_5) && (labSheetDetail.Bath3Positive44_5.Length < 1 || labSheetDetail.Bath3Positive44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Bath3Positive44_5", "1", "1"), new[] { nameof(labSheetDetail.Bath3Positive44_5) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1NonTarget44_5) && (labSheetDetail.Bath1NonTarget44_5.Length < 1 || labSheetDetail.Bath1NonTarget44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Bath1NonTarget44_5", "1", "1"), new[] { nameof(labSheetDetail.Bath1NonTarget44_5) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2NonTarget44_5) && (labSheetDetail.Bath2NonTarget44_5.Length < 1 || labSheetDetail.Bath2NonTarget44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Bath2NonTarget44_5", "1", "1"), new[] { nameof(labSheetDetail.Bath2NonTarget44_5) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3NonTarget44_5) && (labSheetDetail.Bath3NonTarget44_5.Length < 1 || labSheetDetail.Bath3NonTarget44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Bath3NonTarget44_5", "1", "1"), new[] { nameof(labSheetDetail.Bath3NonTarget44_5) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1Negative44_5) && (labSheetDetail.Bath1Negative44_5.Length < 1 || labSheetDetail.Bath1Negative44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Bath1Negative44_5", "1", "1"), new[] { nameof(labSheetDetail.Bath1Negative44_5) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2Negative44_5) && (labSheetDetail.Bath2Negative44_5.Length < 1 || labSheetDetail.Bath2Negative44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Bath2Negative44_5", "1", "1"), new[] { nameof(labSheetDetail.Bath2Negative44_5) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3Negative44_5) && (labSheetDetail.Bath3Negative44_5.Length < 1 || labSheetDetail.Bath3Negative44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Bath3Negative44_5", "1", "1"), new[] { nameof(labSheetDetail.Bath3Negative44_5) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Blank35) && (labSheetDetail.Blank35.Length < 1 || labSheetDetail.Blank35.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Blank35", "1", "1"), new[] { nameof(labSheetDetail.Blank35) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1Blank44_5) && (labSheetDetail.Bath1Blank44_5.Length < 1 || labSheetDetail.Bath1Blank44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Bath1Blank44_5", "1", "1"), new[] { nameof(labSheetDetail.Bath1Blank44_5) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2Blank44_5) && (labSheetDetail.Bath2Blank44_5.Length < 1 || labSheetDetail.Bath2Blank44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Bath2Blank44_5", "1", "1"), new[] { nameof(labSheetDetail.Bath2Blank44_5) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3Blank44_5) && (labSheetDetail.Bath3Blank44_5.Length < 1 || labSheetDetail.Bath3Blank44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Bath3Blank44_5", "1", "1"), new[] { nameof(labSheetDetail.Bath3Blank44_5) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Lot35) && labSheetDetail.Lot35.Length > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Lot35", "20"), new[] { nameof(labSheetDetail.Lot35) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Lot44_5) && labSheetDetail.Lot44_5.Length > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Lot44_5", "20"), new[] { nameof(labSheetDetail.Lot44_5) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Weather) && labSheetDetail.Weather.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Weather", "250"), new[] { nameof(labSheetDetail.Weather) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.RunComment) && labSheetDetail.RunComment.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "RunComment", "250"), new[] { nameof(labSheetDetail.RunComment) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.RunWeatherComment) && labSheetDetail.RunWeatherComment.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "RunWeatherComment", "250"), new[] { nameof(labSheetDetail.RunWeatherComment) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.SampleBottleLotNumber) && labSheetDetail.SampleBottleLotNumber.Length > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SampleBottleLotNumber", "20"), new[] { nameof(labSheetDetail.SampleBottleLotNumber) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.SalinitiesReadBy) && labSheetDetail.SalinitiesReadBy.Length > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SalinitiesReadBy", "20"), new[] { nameof(labSheetDetail.SalinitiesReadBy) });
            }

            if (labSheetDetail.SalinitiesReadDate != null && ((DateTime)labSheetDetail.SalinitiesReadDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "SalinitiesReadDate", "1980"), new[] { nameof(labSheetDetail.SalinitiesReadDate) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.ResultsReadBy) && labSheetDetail.ResultsReadBy.Length > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ResultsReadBy", "20"), new[] { nameof(labSheetDetail.ResultsReadBy) });
            }

            if (labSheetDetail.ResultsReadDate != null && ((DateTime)labSheetDetail.ResultsReadDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "ResultsReadDate", "1980"), new[] { nameof(labSheetDetail.ResultsReadDate) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.ResultsRecordedBy) && labSheetDetail.ResultsRecordedBy.Length > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ResultsRecordedBy", "20"), new[] { nameof(labSheetDetail.ResultsRecordedBy) });
            }

            if (labSheetDetail.ResultsRecordedDate != null && ((DateTime)labSheetDetail.ResultsRecordedDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "ResultsRecordedDate", "1980"), new[] { nameof(labSheetDetail.ResultsRecordedDate) });
            }

            if (labSheetDetail.DailyDuplicateRLog != null)
            {
                if (labSheetDetail.DailyDuplicateRLog < 0 || labSheetDetail.DailyDuplicateRLog > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DailyDuplicateRLog", "0", "100"), new[] { nameof(labSheetDetail.DailyDuplicateRLog) });
                }
            }

            if (labSheetDetail.DailyDuplicatePrecisionCriteria != null)
            {
                if (labSheetDetail.DailyDuplicatePrecisionCriteria < 0 || labSheetDetail.DailyDuplicatePrecisionCriteria > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DailyDuplicatePrecisionCriteria", "0", "100"), new[] { nameof(labSheetDetail.DailyDuplicatePrecisionCriteria) });
                }
            }

            if (labSheetDetail.IntertechDuplicateRLog != null)
            {
                if (labSheetDetail.IntertechDuplicateRLog < 0 || labSheetDetail.IntertechDuplicateRLog > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "IntertechDuplicateRLog", "0", "100"), new[] { nameof(labSheetDetail.IntertechDuplicateRLog) });
                }
            }

            if (labSheetDetail.IntertechDuplicatePrecisionCriteria != null)
            {
                if (labSheetDetail.IntertechDuplicatePrecisionCriteria < 0 || labSheetDetail.IntertechDuplicatePrecisionCriteria > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "IntertechDuplicatePrecisionCriteria", "0", "100"), new[] { nameof(labSheetDetail.IntertechDuplicatePrecisionCriteria) });
                }
            }

            if (labSheetDetail.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(labSheetDetail.LastUpdateDate_UTC) });
            }
            else
            {
                if (labSheetDetail.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(labSheetDetail.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == labSheetDetail.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == labSheetDetail.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", labSheetDetail.LastUpdateContactTVItemID.ToString()), new[] { nameof(labSheetDetail.LastUpdateContactTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(labSheetDetail.LastUpdateContactTVItemID) });
                    }
                }

            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(labSheetDetail.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
