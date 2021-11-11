/*
 * Manually edited
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
using CSSPServerLoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPHelperModels;

namespace CSSPDBServices
{
    public partial interface IAppTaskDBService
    {
        Task<ActionResult<bool>> Delete(int AppTaskID);
        Task<ActionResult<List<AppTask>>> GetAppTaskList(int skip = 0, int take = 100);
        Task<ActionResult<AppTask>> GetAppTaskWithAppTaskID(int AppTaskID);
        Task<ActionResult<AppTask>> Post(AppTask apptask);
        Task<ActionResult<AppTask>> Put(AppTask apptask);
    }
    public partial class AppTaskDBService : ControllerBase, IAppTaskDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
        private CSSPDBContext db { get; }
        private ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public AppTaskDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPServerLoggedInService CSSPServerLoggedInService, CSSPDBContext db)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
            if (CSSPServerLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPServerLoggedInService") }");
            if (db == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db") }");

            //if (string.IsNullOrEmpty(Configuration["APISecret"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "APISecret", "CSSPDBServices") }");
            //if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup", "CSSPDBServices") }");
            //if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup_uncompress"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup_uncompress", "CSSPDBServices") }");
            //if (string.IsNullOrEmpty(Configuration["AzureCSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureCSSPDB", "CSSPDBServices") }");
            //if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPFilesPath", "CSSPDBServices") }");
            //if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CSSPDBServices") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPDBServices") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "CSSPDBServices") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CSSPDBServices") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPDBServices") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CSSPDBServices") }");

            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.CSSPServerLoggedInService = CSSPServerLoggedInService;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<AppTask>> GetAppTaskWithAppTaskID(int AppTaskID)
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            AppTask appTask = (from c in db.AppTasks.AsNoTracking()
                               where c.AppTaskID == AppTaskID
                               select c).FirstOrDefault();

            if (appTask == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(appTask));
        }
        public async Task<ActionResult<List<AppTask>>> GetAppTaskList(int skip = 0, int take = 100)
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            List<AppTask> appTaskList = (from c in db.AppTasks.AsNoTracking() orderby c.AppTaskID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(appTaskList));
        }
        public async Task<ActionResult<bool>> Delete(int AppTaskID)
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            AppTask appTask = (from c in db.AppTasks
                               where c.AppTaskID == AppTaskID
                               select c).FirstOrDefault();

            if (appTask == null)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", AppTaskID.ToString()));
                return await Task.FromResult(BadRequest(errRes));
            }

            try
            {
                db.AppTasks.Remove(appTask);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                return await Task.FromResult(BadRequest(errRes));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<AppTask>> Post(AppTask appTask)
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            if (!await Validate(new ValidationContext(appTask), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(errRes));
            }

            try
            {
                db.AppTasks.Add(appTask);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                return await Task.FromResult(BadRequest(errRes));
            }

            return await Task.FromResult(Ok(appTask));
        }
        public async Task<ActionResult<AppTask>> Put(AppTask appTask)
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            if (!await Validate(new ValidationContext(appTask), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(errRes));
            }

            try
            {
                db.AppTasks.Update(appTask);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                return await Task.FromResult(BadRequest(errRes));
            }

            return await Task.FromResult(Ok(appTask));
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            AppTask appTask = validationContext.ObjectInstance as AppTask;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (appTask.AppTaskID == 0)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
                }

                if (!(from c in db.AppTasks.AsNoTracking() select c).Where(c => c.AppTaskID == appTask.AppTaskID).Any())
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTask.AppTaskID.ToString()));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTask.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            }

            TVItem TVItemTVItemID = null;
            TVItemTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == appTask.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", appTask.TVItemID.ToString()));
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
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow"));
                }
            }

            TVItem TVItemTVItemID2 = null;
            TVItemTVItemID2 = (from c in db.TVItems.AsNoTracking() where c.TVItemID == appTask.TVItemID2 select c).FirstOrDefault();

            if (TVItemTVItemID2 == null)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID2", appTask.TVItemID2.ToString()));
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
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID2", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow"));
                }
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskCommandEnum), (int?)appTask.AppTaskCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"));
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskStatusEnum), (int?)appTask.AppTaskStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"));
            }

            if (appTask.PercentCompleted < 0 || appTask.PercentCompleted > 100)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PercentCompleted", "0", "100"));
            }

            if (string.IsNullOrWhiteSpace(appTask.Parameters))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Parameters"));
            }

            //Parameters has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTask.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
            }

            if (appTask.StartDateTime_UTC.Year == 1)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "StartDateTime_UTC"));
            }
            else
            {
                if (appTask.StartDateTime_UTC.Year < 1980)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1980"));
                }
            }

            if (appTask.EndDateTime_UTC != null && ((DateTime)appTask.EndDateTime_UTC).Year < 1980)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1980"));
            }

            if (appTask.StartDateTime_UTC > appTask.EndDateTime_UTC)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDateTime_UTC", "AppTaskStartDateTime_UTC"));
            }

            if (appTask.EstimatedLength_second != null)
            {
                if (appTask.EstimatedLength_second < 0 || appTask.EstimatedLength_second > 1000000)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "EstimatedLength_second", "0", "1000000"));
                }
            }

            if (appTask.RemainingTime_second != null)
            {
                if (appTask.RemainingTime_second < 0 || appTask.RemainingTime_second > 1000000)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RemainingTime_second", "0", "1000000"));
                }
            }

            if (appTask.LastUpdateDate_UTC.Year == 1)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"));
            }
            else
            {
                if (appTask.LastUpdateDate_UTC.Year < 1980)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == appTask.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", appTask.LastUpdateContactTVItemID.ToString()));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"));
                }
            }

            return errRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
        }
        #endregion Functions private
    }

}
