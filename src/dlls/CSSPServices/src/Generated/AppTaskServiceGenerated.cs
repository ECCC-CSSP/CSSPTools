/*
 * Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public interface IAppTaskService
    {
       Task<ActionResult<AppTask>> GetAppTaskWithAppTaskID(int AppTaskID);
       Task<ActionResult<List<AppTask>>> GetAppTaskList();
       Task<ActionResult<AppTask>> Add(AppTask apptask);
       Task<ActionResult<bool>> Delete(int AppTaskID);
       Task<ActionResult<AppTask>> Update(AppTask apptask);
       Task SetCulture(CultureInfo culture);
    }
    public partial class AppTaskService : ControllerBase, IAppTaskService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<AppTask>> GetAppTaskWithAppTaskID(int AppTaskID)
        {
            AppTask apptask = (from c in db.AppTasks.AsNoTracking()
                    where c.AppTaskID == AppTaskID
                    select c).FirstOrDefault();

            if (apptask == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(apptask));
        }
        public async Task<ActionResult<List<AppTask>>> GetAppTaskList()
        {
            List<AppTask> apptaskList = (from c in db.AppTasks.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(apptaskList));
        }
        public async Task<ActionResult<AppTask>> Add(AppTask appTask)
        {
            ValidationResults = Validate(new ValidationContext(appTask), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

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
        public async Task<ActionResult<bool>> Delete(int AppTaskID)
        {
            AppTask appTask = (from c in db.AppTasks
                               where c.AppTaskID == AppTaskID
                               select c).FirstOrDefault();
            
            if (appTask == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", AppTaskID.ToString())));
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
        public async Task<ActionResult<AppTask>> Update(AppTask appTask)
        {
            ValidationResults = Validate(new ValidationContext(appTask), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

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
        public async Task SetCulture(CultureInfo culture)
        {
            CSSPServicesRes.Culture = culture;
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskID"), new[] { "AppTaskID" });
                }

                if (!(from c in db.AppTasks select c).Where(c => c.AppTaskID == appTask.AppTaskID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTask.AppTaskID.ToString()), new[] { "AppTaskID" });
                }
            }

            TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == appTask.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", appTask.TVItemID.ToString()), new[] { "TVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemID", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow"), new[] { "TVItemID" });
                }
            }

            TVItem TVItemTVItemID2 = (from c in db.TVItems where c.TVItemID == appTask.TVItemID2 select c).FirstOrDefault();

            if (TVItemTVItemID2 == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID2", appTask.TVItemID2.ToString()), new[] { "TVItemID2" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemID2", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow"), new[] { "TVItemID2" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskCommandEnum), (int?)appTask.AppTaskCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskCommand"), new[] { "AppTaskCommand" });
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskStatusEnum), (int?)appTask.AppTaskStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskStatus"), new[] { "AppTaskStatus" });
            }

            if (appTask.PercentCompleted < 0 || appTask.PercentCompleted > 100)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PercentCompleted", "0", "100"), new[] { "PercentCompleted" });
            }

            if (string.IsNullOrWhiteSpace(appTask.Parameters))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Parameters"), new[] { "Parameters" });
            }

            //Parameters has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTask.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            if (appTask.StartDateTime_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "StartDateTime_UTC"), new[] { "StartDateTime_UTC" });
            }
            else
            {
                if (appTask.StartDateTime_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1980"), new[] { "StartDateTime_UTC" });
                }
            }

            if (appTask.EndDateTime_UTC != null && ((DateTime)appTask.EndDateTime_UTC).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1980"), new[] { "EndDateTime_UTC" });
            }

            if (appTask.StartDateTime_UTC > appTask.EndDateTime_UTC)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "EndDateTime_UTC", "AppTaskStartDateTime_UTC"), new[] { "EndDateTime_UTC" });
            }

            if (appTask.EstimatedLength_second != null)
            {
                if (appTask.EstimatedLength_second < 0 || appTask.EstimatedLength_second > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "EstimatedLength_second", "0", "1000000"), new[] { "EstimatedLength_second" });
                }
            }

            if (appTask.RemainingTime_second != null)
            {
                if (appTask.RemainingTime_second < 0 || appTask.RemainingTime_second > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RemainingTime_second", "0", "1000000"), new[] { "RemainingTime_second" });
                }
            }

            if (appTask.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (appTask.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appTask.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", appTask.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
