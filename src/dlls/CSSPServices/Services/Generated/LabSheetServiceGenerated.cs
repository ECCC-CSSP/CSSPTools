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
   public partial interface ILabSheetService
    {
       Task<ActionResult<bool>> Delete(int LabSheetID);
       Task<ActionResult<List<LabSheet>>> GetLabSheetList(int skip = 0, int take = 100);
       Task<ActionResult<LabSheet>> GetLabSheetWithLabSheetID(int LabSheetID);
       Task<ActionResult<LabSheet>> Post(LabSheet labsheet);
       Task<ActionResult<LabSheet>> Put(LabSheet labsheet);
    }
    public partial class LabSheetService : ControllerBase, ILabSheetService
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
        public LabSheetService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, 
           CSSPDBContext db, CSSPDBLocalContext dbLocal = null, CSSPDBInMemoryContext dbIM = null)
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
        public async Task<ActionResult<LabSheet>> GetLabSheetWithLabSheetID(int LabSheetID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                LabSheet labSheet = (from c in dbIM.LabSheets.AsNoTracking()
                                   where c.LabSheetID == LabSheetID
                                   select c).FirstOrDefault();

                if (labSheet == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(labSheet));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                LabSheet labSheet = (from c in dbLocal.LabSheets.AsNoTracking()
                        where c.LabSheetID == LabSheetID
                        select c).FirstOrDefault();

                if (labSheet == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(labSheet));
            }
            else
            {
                LabSheet labSheet = (from c in db.LabSheets.AsNoTracking()
                        where c.LabSheetID == LabSheetID
                        select c).FirstOrDefault();

                if (labSheet == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(labSheet));
            }
        }
        public async Task<ActionResult<List<LabSheet>>> GetLabSheetList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<LabSheet> labSheetList = (from c in dbIM.LabSheets.AsNoTracking() orderby c.LabSheetID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(labSheetList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<LabSheet> labSheetList = (from c in dbLocal.LabSheets.AsNoTracking() orderby c.LabSheetID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(labSheetList));
            }
            else
            {
                List<LabSheet> labSheetList = (from c in db.LabSheets.AsNoTracking() orderby c.LabSheetID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(labSheetList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int LabSheetID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                LabSheet labSheet = (from c in dbIM.LabSheets
                                   where c.LabSheetID == LabSheetID
                                   select c).FirstOrDefault();
            
                if (labSheet == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheet", "LabSheetID", LabSheetID.ToString())));
                }
            
                try
                {
                    dbIM.LabSheets.Remove(labSheet);
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
                LabSheet labSheet = (from c in dbLocal.LabSheets
                                   where c.LabSheetID == LabSheetID
                                   select c).FirstOrDefault();
                
                if (labSheet == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheet", "LabSheetID", LabSheetID.ToString())));
                }

                try
                {
                   dbLocal.LabSheets.Remove(labSheet);
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
                LabSheet labSheet = (from c in db.LabSheets
                                   where c.LabSheetID == LabSheetID
                                   select c).FirstOrDefault();
                
                if (labSheet == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheet", "LabSheetID", LabSheetID.ToString())));
                }

                try
                {
                   db.LabSheets.Remove(labSheet);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<LabSheet>> Post(LabSheet labSheet)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(labSheet), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.LabSheets.Add(labSheet);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(labSheet));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.LabSheets.Add(labSheet);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(labSheet));
            }
            else
            {
                try
                {
                   db.LabSheets.Add(labSheet);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(labSheet));
            }
        }
        public async Task<ActionResult<LabSheet>> Put(LabSheet labSheet)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(labSheet), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.LabSheets.Update(labSheet);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(labSheet));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.LabSheets.Update(labSheet);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(labSheet));
            }
            else
            {
            try
            {
               db.LabSheets.Update(labSheet);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(labSheet));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LabSheet labSheet = validationContext.ObjectInstance as LabSheet;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (labSheet.LabSheetID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LabSheetID"), new[] { nameof(labSheet.LabSheetID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.LabSheets select c).Where(c => c.LabSheetID == labSheet.LabSheetID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheet", "LabSheetID", labSheet.LabSheetID.ToString()), new[] { nameof(labSheet.LabSheetID) });
                    }
                }
                else
                {
                    if (!(from c in db.LabSheets select c).Where(c => c.LabSheetID == labSheet.LabSheetID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheet", "LabSheetID", labSheet.LabSheetID.ToString()), new[] { nameof(labSheet.LabSheetID) });
                    }
                }
            }

            if (labSheet.OtherServerLabSheetID < 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "OtherServerLabSheetID", "1"), new[] { nameof(labSheet.OtherServerLabSheetID) });
            }

            SamplingPlan SamplingPlanSamplingPlanID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                SamplingPlanSamplingPlanID = (from c in dbLocal.SamplingPlans where c.SamplingPlanID == labSheet.SamplingPlanID select c).FirstOrDefault();
                if (SamplingPlanSamplingPlanID == null)
                {
                    SamplingPlanSamplingPlanID = (from c in dbIM.SamplingPlans where c.SamplingPlanID == labSheet.SamplingPlanID select c).FirstOrDefault();
                }
            }
            else
            {
                SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == labSheet.SamplingPlanID select c).FirstOrDefault();
            }

            if (SamplingPlanSamplingPlanID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", labSheet.SamplingPlanID.ToString()), new[] { nameof(labSheet.SamplingPlanID) });
            }

            if (string.IsNullOrWhiteSpace(labSheet.SamplingPlanName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SamplingPlanName"), new[] { nameof(labSheet.SamplingPlanName) });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.SamplingPlanName) && (labSheet.SamplingPlanName.Length < 1 || labSheet.SamplingPlanName.Length > 250))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "SamplingPlanName", "1", "250"), new[] { nameof(labSheet.SamplingPlanName) });
            }

            if (labSheet.Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "Year", "1980"), new[] { nameof(labSheet.Year) });
            }

            if (labSheet.Month < 1 || labSheet.Month > 12)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Month", "1", "12"), new[] { nameof(labSheet.Month) });
            }

            if (labSheet.Day < 1 || labSheet.Day > 31)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Day", "1", "31"), new[] { nameof(labSheet.Day) });
            }

            if (labSheet.RunNumber < 1 || labSheet.RunNumber > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RunNumber", "1", "100"), new[] { nameof(labSheet.RunNumber) });
            }

            TVItem TVItemSubsectorTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemSubsectorTVItemID = (from c in dbLocal.TVItems where c.TVItemID == labSheet.SubsectorTVItemID select c).FirstOrDefault();
                if (TVItemSubsectorTVItemID == null)
                {
                    TVItemSubsectorTVItemID = (from c in dbIM.TVItems where c.TVItemID == labSheet.SubsectorTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.SubsectorTVItemID select c).FirstOrDefault();
            }

            if (TVItemSubsectorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "SubsectorTVItemID", labSheet.SubsectorTVItemID.ToString()), new[] { nameof(labSheet.SubsectorTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { nameof(labSheet.SubsectorTVItemID) });
                }
            }

            if (labSheet.MWQMRunTVItemID != null)
            {
                TVItem TVItemMWQMRunTVItemID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    TVItemMWQMRunTVItemID = (from c in dbLocal.TVItems where c.TVItemID == labSheet.MWQMRunTVItemID select c).FirstOrDefault();
                    if (TVItemMWQMRunTVItemID == null)
                    {
                        TVItemMWQMRunTVItemID = (from c in dbIM.TVItems where c.TVItemID == labSheet.MWQMRunTVItemID select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemMWQMRunTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.MWQMRunTVItemID select c).FirstOrDefault();
                }

                if (TVItemMWQMRunTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunTVItemID", (labSheet.MWQMRunTVItemID == null ? "" : labSheet.MWQMRunTVItemID.ToString())), new[] { nameof(labSheet.MWQMRunTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.MWQMRun,
                    };
                    if (!AllowableTVTypes.Contains(TVItemMWQMRunTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MWQMRunTVItemID", "MWQMRun"), new[] { nameof(labSheet.MWQMRunTVItemID) });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(SamplingPlanTypeEnum), (int?)labSheet.SamplingPlanType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SamplingPlanType"), new[] { nameof(labSheet.SamplingPlanType) });
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)labSheet.SampleType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SampleType"), new[] { nameof(labSheet.SampleType) });
            }

            retStr = enums.EnumTypeOK(typeof(LabSheetTypeEnum), (int?)labSheet.LabSheetType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LabSheetType"), new[] { nameof(labSheet.LabSheetType) });
            }

            retStr = enums.EnumTypeOK(typeof(LabSheetStatusEnum), (int?)labSheet.LabSheetStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LabSheetStatus"), new[] { nameof(labSheet.LabSheetStatus) });
            }

            if (string.IsNullOrWhiteSpace(labSheet.FileName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FileName"), new[] { nameof(labSheet.FileName) });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.FileName) && (labSheet.FileName.Length < 1 || labSheet.FileName.Length > 250))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FileName", "1", "250"), new[] { nameof(labSheet.FileName) });
            }

            if (labSheet.FileLastModifiedDate_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FileLastModifiedDate_Local"), new[] { nameof(labSheet.FileLastModifiedDate_Local) });
            }
            else
            {
                if (labSheet.FileLastModifiedDate_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "FileLastModifiedDate_Local", "1980"), new[] { nameof(labSheet.FileLastModifiedDate_Local) });
                }
            }

            if (string.IsNullOrWhiteSpace(labSheet.FileContent))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FileContent"), new[] { nameof(labSheet.FileContent) });
            }

            //FileContent has no StringLength Attribute

            if (labSheet.AcceptedOrRejectedByContactTVItemID != null)
            {
                TVItem TVItemAcceptedOrRejectedByContactTVItemID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    TVItemAcceptedOrRejectedByContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == labSheet.AcceptedOrRejectedByContactTVItemID select c).FirstOrDefault();
                    if (TVItemAcceptedOrRejectedByContactTVItemID == null)
                    {
                        TVItemAcceptedOrRejectedByContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == labSheet.AcceptedOrRejectedByContactTVItemID select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemAcceptedOrRejectedByContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.AcceptedOrRejectedByContactTVItemID select c).FirstOrDefault();
                }

                if (TVItemAcceptedOrRejectedByContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "AcceptedOrRejectedByContactTVItemID", (labSheet.AcceptedOrRejectedByContactTVItemID == null ? "" : labSheet.AcceptedOrRejectedByContactTVItemID.ToString())), new[] { nameof(labSheet.AcceptedOrRejectedByContactTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemAcceptedOrRejectedByContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "AcceptedOrRejectedByContactTVItemID", "Contact"), new[] { nameof(labSheet.AcceptedOrRejectedByContactTVItemID) });
                    }
                }
            }

            if (labSheet.AcceptedOrRejectedDateTime != null && ((DateTime)labSheet.AcceptedOrRejectedDateTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "AcceptedOrRejectedDateTime", "1980"), new[] { nameof(labSheet.AcceptedOrRejectedDateTime) });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.RejectReason) && labSheet.RejectReason.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "RejectReason", "250"), new[] { nameof(labSheet.RejectReason) });
            }

            if (labSheet.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(labSheet.LastUpdateDate_UTC) });
            }
            else
            {
                if (labSheet.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(labSheet.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == labSheet.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == labSheet.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", labSheet.LastUpdateContactTVItemID.ToString()), new[] { nameof(labSheet.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(labSheet.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
