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
   public partial interface IAppTaskService
    {
       Task<ActionResult<bool>> Delete(int AppTaskID);
       Task<ActionResult<List<AppTask>>> GetAppTaskList(int skip = 0, int take = 100);
       Task<ActionResult<AppTask>> GetAppTaskWithAppTaskID(int AppTaskID);
       Task<ActionResult<AppTask>> Post(AppTask apptask);
       Task<ActionResult<AppTask>> Put(AppTask apptask);
    }
    public partial class AppTaskService : ControllerBase, IAppTaskService
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
        public AppTaskService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal = null, CSSPDBInMemoryContext dbIM = null)
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
        public async Task<ActionResult<AppTask>> GetAppTaskWithAppTaskID(int AppTaskID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                AppTask appTask = (from c in dbIM.AppTasks.AsNoTracking()
                                   where c.AppTaskID == AppTaskID
                                   select c).FirstOrDefault();

                if (appTask == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(appTask));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                AppTask appTask = (from c in dbLocal.AppTasks.AsNoTracking()
                        where c.AppTaskID == AppTaskID
                        select c).FirstOrDefault();

                if (appTask == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(appTask));
            }
            else
            {
                AppTask appTask = (from c in db.AppTasks.AsNoTracking()
                        where c.AppTaskID == AppTaskID
                        select c).FirstOrDefault();

                if (appTask == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(appTask));
            }
        }
        public async Task<ActionResult<List<AppTask>>> GetAppTaskList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<AppTask> appTaskList = (from c in dbIM.AppTasks.AsNoTracking() orderby c.AppTaskID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(appTaskList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<AppTask> appTaskList = (from c in dbLocal.AppTasks.AsNoTracking() orderby c.AppTaskID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(appTaskList));
            }
            else
            {
                List<AppTask> appTaskList = (from c in db.AppTasks.AsNoTracking() orderby c.AppTaskID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(appTaskList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int AppTaskID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                AppTask appTask = (from c in dbIM.AppTasks
                                   where c.AppTaskID == AppTaskID
                                   select c).FirstOrDefault();
            
                if (appTask == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", AppTaskID.ToString())));
                }
            
                try
                {
                    dbIM.AppTasks.Remove(appTask);
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
                AppTask appTask = (from c in dbLocal.AppTasks
                                   where c.AppTaskID == AppTaskID
                                   select c).FirstOrDefault();
                
                if (appTask == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", AppTaskID.ToString())));
                }

                try
                {
                   dbLocal.AppTasks.Remove(appTask);
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
                AppTask appTask = (from c in db.AppTasks
                                   where c.AppTaskID == AppTaskID
                                   select c).FirstOrDefault();
                
                if (appTask == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", AppTaskID.ToString())));
                }

                try
                {
                   db.AppTasks.Remove(appTask);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<AppTask>> Post(AppTask appTask)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(appTask), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.AppTasks.Add(appTask);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(appTask));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.AppTasks.Add(appTask);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(appTask));
            }
            else
            {
                try
                {
                   db.AppTasks.Add(appTask);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(appTask));
            }
        }
        public async Task<ActionResult<AppTask>> Put(AppTask appTask)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(appTask), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.AppTasks.Update(appTask);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(appTask));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.AppTasks.Update(appTask);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(appTask));
            }
            else
            {
            try
            {
               db.AppTasks.Update(appTask);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(appTask));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            AppTask appTask = validationContext.ObjectInstance as AppTask;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (appTask.AppTaskID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"), new[] { nameof(appTask.AppTaskID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.AppTasks select c).Where(c => c.AppTaskID == appTask.AppTaskID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTask.AppTaskID.ToString()), new[] { nameof(appTask.AppTaskID) });
                    }
                }
                else
                {
                    if (!(from c in db.AppTasks select c).Where(c => c.AppTaskID == appTask.AppTaskID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTask.AppTaskID.ToString()), new[] { nameof(appTask.AppTaskID) });
                    }
                }
            }

            TVItem TVItemTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemTVItemID = (from c in dbLocal.TVItems where c.TVItemID == appTask.TVItemID select c).FirstOrDefault();
                if (TVItemTVItemID == null)
                {
                    TVItemTVItemID = (from c in dbIM.TVItems where c.TVItemID == appTask.TVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemTVItemID = (from c in db.TVItems where c.TVItemID == appTask.TVItemID select c).FirstOrDefault();
            }

            if (TVItemTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", appTask.TVItemID.ToString()), new[] { nameof(appTask.TVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Address,
                    TVTypeEnum.Area,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.Country,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Province,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.WasteWaterTreatmentPlant,
                    TVTypeEnum.LiftStation,
                    TVTypeEnum.Spill,
                    TVTypeEnum.Outfall,
                    TVTypeEnum.OtherInfrastructure,
                    TVTypeEnum.SeeOtherMunicipality,
                    TVTypeEnum.LineOverflow,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow"), new[] { nameof(appTask.TVItemID) });
                }
            }

            TVItem TVItemTVItemID2 = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemTVItemID2 = (from c in dbLocal.TVItems where c.TVItemID == appTask.TVItemID2 select c).FirstOrDefault();
                if (TVItemTVItemID2 == null)
                {
                    TVItemTVItemID2 = (from c in dbIM.TVItems where c.TVItemID == appTask.TVItemID2 select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemTVItemID2 = (from c in db.TVItems where c.TVItemID == appTask.TVItemID2 select c).FirstOrDefault();
            }

            if (TVItemTVItemID2 == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID2", appTask.TVItemID2.ToString()), new[] { nameof(appTask.TVItemID2) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Address,
                    TVTypeEnum.Area,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.Country,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Province,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.WasteWaterTreatmentPlant,
                    TVTypeEnum.LiftStation,
                    TVTypeEnum.Spill,
                    TVTypeEnum.Outfall,
                    TVTypeEnum.OtherInfrastructure,
                    TVTypeEnum.SeeOtherMunicipality,
                    TVTypeEnum.LineOverflow,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID2.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID2", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow"), new[] { nameof(appTask.TVItemID2) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskCommandEnum), (int?)appTask.AppTaskCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"), new[] { nameof(appTask.AppTaskCommand) });
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskStatusEnum), (int?)appTask.AppTaskStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"), new[] { nameof(appTask.AppTaskStatus) });
            }

            if (appTask.PercentCompleted < 0 || appTask.PercentCompleted > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PercentCompleted", "0", "100"), new[] { nameof(appTask.PercentCompleted) });
            }

            if (string.IsNullOrWhiteSpace(appTask.Parameters))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Parameters"), new[] { nameof(appTask.Parameters) });
            }

            //Parameters has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTask.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(appTask.Language) });
            }

            if (appTask.StartDateTime_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StartDateTime_UTC"), new[] { nameof(appTask.StartDateTime_UTC) });
            }
            else
            {
                if (appTask.StartDateTime_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1980"), new[] { nameof(appTask.StartDateTime_UTC) });
                }
            }

            if (appTask.EndDateTime_UTC != null && ((DateTime)appTask.EndDateTime_UTC).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1980"), new[] { nameof(appTask.EndDateTime_UTC) });
            }

            if (appTask.StartDateTime_UTC > appTask.EndDateTime_UTC)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDateTime_UTC", "AppTaskStartDateTime_UTC"), new[] { nameof(appTask.EndDateTime_UTC) });
            }

            if (appTask.EstimatedLength_second != null)
            {
                if (appTask.EstimatedLength_second < 0 || appTask.EstimatedLength_second > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "EstimatedLength_second", "0", "1000000"), new[] { nameof(appTask.EstimatedLength_second) });
                }
            }

            if (appTask.RemainingTime_second != null)
            {
                if (appTask.RemainingTime_second < 0 || appTask.RemainingTime_second > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RemainingTime_second", "0", "1000000"), new[] { nameof(appTask.RemainingTime_second) });
                }
            }

            if (appTask.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(appTask.LastUpdateDate_UTC) });
            }
            else
            {
                if (appTask.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(appTask.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == appTask.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == appTask.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appTask.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", appTask.LastUpdateContactTVItemID.ToString()), new[] { nameof(appTask.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(appTask.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
