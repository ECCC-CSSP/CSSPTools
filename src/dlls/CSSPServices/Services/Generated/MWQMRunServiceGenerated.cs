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
   public partial interface IMWQMRunService
    {
       Task<ActionResult<bool>> Delete(int MWQMRunID);
       Task<ActionResult<List<MWQMRun>>> GetMWQMRunList(int skip = 0, int take = 100);
       Task<ActionResult<MWQMRun>> GetMWQMRunWithMWQMRunID(int MWQMRunID);
       Task<ActionResult<MWQMRun>> Post(MWQMRun mwqmrun);
       Task<ActionResult<MWQMRun>> Put(MWQMRun mwqmrun);
    }
    public partial class MWQMRunService : ControllerBase, IMWQMRunService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<MWQMRun>> GetMWQMRunWithMWQMRunID(int MWQMRunID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MWQMRun mwqmRun = (from c in dbIM.MWQMRuns.AsNoTracking()
                                   where c.MWQMRunID == MWQMRunID
                                   select c).FirstOrDefault();

                if (mwqmRun == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmRun));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                MWQMRun mwqmRun = (from c in dbLocal.MWQMRuns.AsNoTracking()
                        where c.MWQMRunID == MWQMRunID
                        select c).FirstOrDefault();

                if (mwqmRun == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmRun));
            }
            else
            {
                MWQMRun mwqmRun = (from c in db.MWQMRuns.AsNoTracking()
                        where c.MWQMRunID == MWQMRunID
                        select c).FirstOrDefault();

                if (mwqmRun == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmRun));
            }
        }
        public async Task<ActionResult<List<MWQMRun>>> GetMWQMRunList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<MWQMRun> mwqmRunList = (from c in dbIM.MWQMRuns.AsNoTracking() orderby c.MWQMRunID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(mwqmRunList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<MWQMRun> mwqmRunList = (from c in dbLocal.MWQMRuns.AsNoTracking() orderby c.MWQMRunID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mwqmRunList));
            }
            else
            {
                List<MWQMRun> mwqmRunList = (from c in db.MWQMRuns.AsNoTracking() orderby c.MWQMRunID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mwqmRunList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int MWQMRunID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MWQMRun mwqmRun = (from c in dbIM.MWQMRuns
                                   where c.MWQMRunID == MWQMRunID
                                   select c).FirstOrDefault();
            
                if (mwqmRun == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunID", MWQMRunID.ToString())));
                }
            
                try
                {
                    dbIM.MWQMRuns.Remove(mwqmRun);
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
                MWQMRun mwqmRun = (from c in dbLocal.MWQMRuns
                                   where c.MWQMRunID == MWQMRunID
                                   select c).FirstOrDefault();
                
                if (mwqmRun == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunID", MWQMRunID.ToString())));
                }

                try
                {
                   dbLocal.MWQMRuns.Remove(mwqmRun);
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
                MWQMRun mwqmRun = (from c in db.MWQMRuns
                                   where c.MWQMRunID == MWQMRunID
                                   select c).FirstOrDefault();
                
                if (mwqmRun == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunID", MWQMRunID.ToString())));
                }

                try
                {
                   db.MWQMRuns.Remove(mwqmRun);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<MWQMRun>> Post(MWQMRun mwqmRun)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmRun), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MWQMRuns.Add(mwqmRun);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmRun));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.MWQMRuns.Add(mwqmRun);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmRun));
            }
            else
            {
                try
                {
                   db.MWQMRuns.Add(mwqmRun);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmRun));
            }
        }
        public async Task<ActionResult<MWQMRun>> Put(MWQMRun mwqmRun)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmRun), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MWQMRuns.Update(mwqmRun);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmRun));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.MWQMRuns.Update(mwqmRun);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmRun));
            }
            else
            {
            try
            {
               db.MWQMRuns.Update(mwqmRun);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmRun));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MWQMRun mwqmRun = validationContext.ObjectInstance as MWQMRun;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmRun.MWQMRunID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMRunID"), new[] { "MWQMRunID" });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.MWQMRuns select c).Where(c => c.MWQMRunID == mwqmRun.MWQMRunID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunID", mwqmRun.MWQMRunID.ToString()), new[] { "MWQMRunID" });
                    }
                }
                else
                {
                    if (!(from c in db.MWQMRuns select c).Where(c => c.MWQMRunID == mwqmRun.MWQMRunID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunID", mwqmRun.MWQMRunID.ToString()), new[] { "MWQMRunID" });
                    }
                }
            }

            TVItem TVItemSubsectorTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemSubsectorTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmRun.SubsectorTVItemID select c).FirstOrDefault();
                if (TVItemSubsectorTVItemID == null)
                {
                    TVItemSubsectorTVItemID = (from c in dbIM.TVItems where c.TVItemID == mwqmRun.SubsectorTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.SubsectorTVItemID select c).FirstOrDefault();
            }

            if (TVItemSubsectorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "SubsectorTVItemID", mwqmRun.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            TVItem TVItemMWQMRunTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemMWQMRunTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmRun.MWQMRunTVItemID select c).FirstOrDefault();
                if (TVItemMWQMRunTVItemID == null)
                {
                    TVItemMWQMRunTVItemID = (from c in dbIM.TVItems where c.TVItemID == mwqmRun.MWQMRunTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemMWQMRunTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.MWQMRunTVItemID select c).FirstOrDefault();
            }

            if (TVItemMWQMRunTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunTVItemID", mwqmRun.MWQMRunTVItemID.ToString()), new[] { "MWQMRunTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMRun,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMRunTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MWQMRunTVItemID", "MWQMRun"), new[] { "MWQMRunTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)mwqmRun.RunSampleType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RunSampleType"), new[] { "RunSampleType" });
            }

            if (mwqmRun.DateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DateTime_Local"), new[] { "DateTime_Local" });
            }
            else
            {
                if (mwqmRun.DateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTime_Local", "1980"), new[] { "DateTime_Local" });
                }
            }

            if (mwqmRun.RunNumber < 1 || mwqmRun.RunNumber > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RunNumber", "1", "1000"), new[] { "RunNumber" });
            }

            if (mwqmRun.StartDateTime_Local != null && ((DateTime)mwqmRun.StartDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_Local", "1980"), new[] { "StartDateTime_Local" });
            }

            if (mwqmRun.EndDateTime_Local != null && ((DateTime)mwqmRun.EndDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_Local", "1980"), new[] { "EndDateTime_Local" });
            }

            if (mwqmRun.StartDateTime_Local > mwqmRun.EndDateTime_Local)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDateTime_Local", "MWQMRunStartDateTime_Local"), new[] { "EndDateTime_Local" });
            }

            if (mwqmRun.LabReceivedDateTime_Local != null && ((DateTime)mwqmRun.LabReceivedDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LabReceivedDateTime_Local", "1980"), new[] { "LabReceivedDateTime_Local" });
            }

            if (mwqmRun.TemperatureControl1_C != null)
            {
                if (mwqmRun.TemperatureControl1_C < -10 || mwqmRun.TemperatureControl1_C > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TemperatureControl1_C", "-10", "40"), new[] { "TemperatureControl1_C" });
                }
            }

            if (mwqmRun.TemperatureControl2_C != null)
            {
                if (mwqmRun.TemperatureControl2_C < -10 || mwqmRun.TemperatureControl2_C > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TemperatureControl2_C", "-10", "40"), new[] { "TemperatureControl2_C" });
                }
            }

            if (mwqmRun.SeaStateAtStart_BeaufortScale != null)
            {
                retStr = enums.EnumTypeOK(typeof(BeaufortScaleEnum), (int?)mwqmRun.SeaStateAtStart_BeaufortScale);
                if (mwqmRun.SeaStateAtStart_BeaufortScale == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SeaStateAtStart_BeaufortScale"), new[] { "SeaStateAtStart_BeaufortScale" });
                }
            }

            if (mwqmRun.SeaStateAtEnd_BeaufortScale != null)
            {
                retStr = enums.EnumTypeOK(typeof(BeaufortScaleEnum), (int?)mwqmRun.SeaStateAtEnd_BeaufortScale);
                if (mwqmRun.SeaStateAtEnd_BeaufortScale == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SeaStateAtEnd_BeaufortScale"), new[] { "SeaStateAtEnd_BeaufortScale" });
                }
            }

            if (mwqmRun.WaterLevelAtBrook_m != null)
            {
                if (mwqmRun.WaterLevelAtBrook_m < 0 || mwqmRun.WaterLevelAtBrook_m > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WaterLevelAtBrook_m", "0", "100"), new[] { "WaterLevelAtBrook_m" });
                }
            }

            if (mwqmRun.WaveHightAtStart_m != null)
            {
                if (mwqmRun.WaveHightAtStart_m < 0 || mwqmRun.WaveHightAtStart_m > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WaveHightAtStart_m", "0", "100"), new[] { "WaveHightAtStart_m" });
                }
            }

            if (mwqmRun.WaveHightAtEnd_m != null)
            {
                if (mwqmRun.WaveHightAtEnd_m < 0 || mwqmRun.WaveHightAtEnd_m > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WaveHightAtEnd_m", "0", "100"), new[] { "WaveHightAtEnd_m" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.SampleCrewInitials) && mwqmRun.SampleCrewInitials.Length > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SampleCrewInitials", "20"), new[] { "SampleCrewInitials" });
            }

            if (mwqmRun.AnalyzeMethod != null)
            {
                retStr = enums.EnumTypeOK(typeof(AnalyzeMethodEnum), (int?)mwqmRun.AnalyzeMethod);
                if (mwqmRun.AnalyzeMethod == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AnalyzeMethod"), new[] { "AnalyzeMethod" });
                }
            }

            if (mwqmRun.SampleMatrix != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleMatrixEnum), (int?)mwqmRun.SampleMatrix);
                if (mwqmRun.SampleMatrix == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SampleMatrix"), new[] { "SampleMatrix" });
                }
            }

            if (mwqmRun.Laboratory != null)
            {
                retStr = enums.EnumTypeOK(typeof(LaboratoryEnum), (int?)mwqmRun.Laboratory);
                if (mwqmRun.Laboratory == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Laboratory"), new[] { "Laboratory" });
                }
            }

            if (mwqmRun.SampleStatus != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleStatusEnum), (int?)mwqmRun.SampleStatus);
                if (mwqmRun.SampleStatus == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SampleStatus"), new[] { "SampleStatus" });
                }
            }

            if (mwqmRun.LabSampleApprovalContactTVItemID != null)
            {
                TVItem TVItemLabSampleApprovalContactTVItemID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    TVItemLabSampleApprovalContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmRun.LabSampleApprovalContactTVItemID select c).FirstOrDefault();
                    if (TVItemLabSampleApprovalContactTVItemID == null)
                    {
                        TVItemLabSampleApprovalContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == mwqmRun.LabSampleApprovalContactTVItemID select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemLabSampleApprovalContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.LabSampleApprovalContactTVItemID select c).FirstOrDefault();
                }

                if (TVItemLabSampleApprovalContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSampleApprovalContactTVItemID", (mwqmRun.LabSampleApprovalContactTVItemID == null ? "" : mwqmRun.LabSampleApprovalContactTVItemID.ToString())), new[] { "LabSampleApprovalContactTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLabSampleApprovalContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LabSampleApprovalContactTVItemID", "Contact"), new[] { "LabSampleApprovalContactTVItemID" });
                    }
                }
            }

            if (mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local != null && ((DateTime)mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LabAnalyzeBath1IncubationStartDateTime_Local", "1980"), new[] { "LabAnalyzeBath1IncubationStartDateTime_Local" });
            }

            if (mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local != null && ((DateTime)mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LabAnalyzeBath2IncubationStartDateTime_Local", "1980"), new[] { "LabAnalyzeBath2IncubationStartDateTime_Local" });
            }

            if (mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local != null && ((DateTime)mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LabAnalyzeBath3IncubationStartDateTime_Local", "1980"), new[] { "LabAnalyzeBath3IncubationStartDateTime_Local" });
            }

            if (mwqmRun.LabRunSampleApprovalDateTime_Local != null && ((DateTime)mwqmRun.LabRunSampleApprovalDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LabRunSampleApprovalDateTime_Local", "1980"), new[] { "LabRunSampleApprovalDateTime_Local" });
            }

            if (mwqmRun.Tide_Start != null)
            {
                retStr = enums.EnumTypeOK(typeof(TideTextEnum), (int?)mwqmRun.Tide_Start);
                if (mwqmRun.Tide_Start == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Tide_Start"), new[] { "Tide_Start" });
                }
            }

            if (mwqmRun.Tide_End != null)
            {
                retStr = enums.EnumTypeOK(typeof(TideTextEnum), (int?)mwqmRun.Tide_End);
                if (mwqmRun.Tide_End == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Tide_End"), new[] { "Tide_End" });
                }
            }

            if (mwqmRun.RainDay0_mm != null)
            {
                if (mwqmRun.RainDay0_mm < 0 || mwqmRun.RainDay0_mm > 300)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RainDay0_mm", "0", "300"), new[] { "RainDay0_mm" });
                }
            }

            if (mwqmRun.RainDay1_mm != null)
            {
                if (mwqmRun.RainDay1_mm < 0 || mwqmRun.RainDay1_mm > 300)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RainDay1_mm", "0", "300"), new[] { "RainDay1_mm" });
                }
            }

            if (mwqmRun.RainDay2_mm != null)
            {
                if (mwqmRun.RainDay2_mm < 0 || mwqmRun.RainDay2_mm > 300)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RainDay2_mm", "0", "300"), new[] { "RainDay2_mm" });
                }
            }

            if (mwqmRun.RainDay3_mm != null)
            {
                if (mwqmRun.RainDay3_mm < 0 || mwqmRun.RainDay3_mm > 300)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RainDay3_mm", "0", "300"), new[] { "RainDay3_mm" });
                }
            }

            if (mwqmRun.RainDay4_mm != null)
            {
                if (mwqmRun.RainDay4_mm < 0 || mwqmRun.RainDay4_mm > 300)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RainDay4_mm", "0", "300"), new[] { "RainDay4_mm" });
                }
            }

            if (mwqmRun.RainDay5_mm != null)
            {
                if (mwqmRun.RainDay5_mm < 0 || mwqmRun.RainDay5_mm > 300)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RainDay5_mm", "0", "300"), new[] { "RainDay5_mm" });
                }
            }

            if (mwqmRun.RainDay6_mm != null)
            {
                if (mwqmRun.RainDay6_mm < 0 || mwqmRun.RainDay6_mm > 300)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RainDay6_mm", "0", "300"), new[] { "RainDay6_mm" });
                }
            }

            if (mwqmRun.RainDay7_mm != null)
            {
                if (mwqmRun.RainDay7_mm < 0 || mwqmRun.RainDay7_mm > 300)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RainDay7_mm", "0", "300"), new[] { "RainDay7_mm" });
                }
            }

            if (mwqmRun.RainDay8_mm != null)
            {
                if (mwqmRun.RainDay8_mm < 0 || mwqmRun.RainDay8_mm > 300)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RainDay8_mm", "0", "300"), new[] { "RainDay8_mm" });
                }
            }

            if (mwqmRun.RainDay9_mm != null)
            {
                if (mwqmRun.RainDay9_mm < 0 || mwqmRun.RainDay9_mm > 300)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RainDay9_mm", "0", "300"), new[] { "RainDay9_mm" });
                }
            }

            if (mwqmRun.RainDay10_mm != null)
            {
                if (mwqmRun.RainDay10_mm < 0 || mwqmRun.RainDay10_mm > 300)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RainDay10_mm", "0", "300"), new[] { "RainDay10_mm" });
                }
            }

            if (mwqmRun.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmRun.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmRun.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == mwqmRun.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmRun.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
