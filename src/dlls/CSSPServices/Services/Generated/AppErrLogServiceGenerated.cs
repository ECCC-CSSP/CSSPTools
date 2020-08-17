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
   public partial interface IAppErrLogService
    {
       Task<ActionResult<bool>> Delete(int AppErrLogID);
       Task<ActionResult<List<AppErrLog>>> GetAppErrLogList(int skip = 0, int take = 100);
       Task<ActionResult<AppErrLog>> GetAppErrLogWithAppErrLogID(int AppErrLogID);
       Task<ActionResult<AppErrLog>> Post(AppErrLog apperrlog);
       Task<ActionResult<AppErrLog>> Put(AppErrLog apperrlog);
    }
    public partial class AppErrLogService : ControllerBase, IAppErrLogService
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
        public AppErrLogService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal = null, CSSPDBInMemoryContext dbIM = null)
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
        public async Task<ActionResult<AppErrLog>> GetAppErrLogWithAppErrLogID(int AppErrLogID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                AppErrLog appErrLog = (from c in dbIM.AppErrLogs.AsNoTracking()
                                   where c.AppErrLogID == AppErrLogID
                                   select c).FirstOrDefault();

                if (appErrLog == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(appErrLog));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                AppErrLog appErrLog = (from c in dbLocal.AppErrLogs.AsNoTracking()
                        where c.AppErrLogID == AppErrLogID
                        select c).FirstOrDefault();

                if (appErrLog == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(appErrLog));
            }
            else
            {
                AppErrLog appErrLog = (from c in db.AppErrLogs.AsNoTracking()
                        where c.AppErrLogID == AppErrLogID
                        select c).FirstOrDefault();

                if (appErrLog == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(appErrLog));
            }
        }
        public async Task<ActionResult<List<AppErrLog>>> GetAppErrLogList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<AppErrLog> appErrLogList = (from c in dbIM.AppErrLogs.AsNoTracking() orderby c.AppErrLogID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(appErrLogList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<AppErrLog> appErrLogList = (from c in dbLocal.AppErrLogs.AsNoTracking() orderby c.AppErrLogID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(appErrLogList));
            }
            else
            {
                List<AppErrLog> appErrLogList = (from c in db.AppErrLogs.AsNoTracking() orderby c.AppErrLogID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(appErrLogList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int AppErrLogID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                AppErrLog appErrLog = (from c in dbIM.AppErrLogs
                                   where c.AppErrLogID == AppErrLogID
                                   select c).FirstOrDefault();
            
                if (appErrLog == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppErrLog", "AppErrLogID", AppErrLogID.ToString())));
                }
            
                try
                {
                    dbIM.AppErrLogs.Remove(appErrLog);
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
                AppErrLog appErrLog = (from c in dbLocal.AppErrLogs
                                   where c.AppErrLogID == AppErrLogID
                                   select c).FirstOrDefault();
                
                if (appErrLog == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppErrLog", "AppErrLogID", AppErrLogID.ToString())));
                }

                try
                {
                   dbLocal.AppErrLogs.Remove(appErrLog);
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
                AppErrLog appErrLog = (from c in db.AppErrLogs
                                   where c.AppErrLogID == AppErrLogID
                                   select c).FirstOrDefault();
                
                if (appErrLog == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppErrLog", "AppErrLogID", AppErrLogID.ToString())));
                }

                try
                {
                   db.AppErrLogs.Remove(appErrLog);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<AppErrLog>> Post(AppErrLog appErrLog)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(appErrLog), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.AppErrLogs.Add(appErrLog);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(appErrLog));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.AppErrLogs.Add(appErrLog);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(appErrLog));
            }
            else
            {
                try
                {
                   db.AppErrLogs.Add(appErrLog);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(appErrLog));
            }
        }
        public async Task<ActionResult<AppErrLog>> Put(AppErrLog appErrLog)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(appErrLog), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.AppErrLogs.Update(appErrLog);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(appErrLog));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.AppErrLogs.Update(appErrLog);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(appErrLog));
            }
            else
            {
            try
            {
               db.AppErrLogs.Update(appErrLog);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(appErrLog));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            AppErrLog appErrLog = validationContext.ObjectInstance as AppErrLog;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (appErrLog.AppErrLogID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppErrLogID"), new[] { nameof(appErrLog.AppErrLogID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.AppErrLogs select c).Where(c => c.AppErrLogID == appErrLog.AppErrLogID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppErrLog", "AppErrLogID", appErrLog.AppErrLogID.ToString()), new[] { nameof(appErrLog.AppErrLogID) });
                    }
                }
                else
                {
                    if (!(from c in db.AppErrLogs select c).Where(c => c.AppErrLogID == appErrLog.AppErrLogID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppErrLog", "AppErrLogID", appErrLog.AppErrLogID.ToString()), new[] { nameof(appErrLog.AppErrLogID) });
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(appErrLog.Tag))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Tag"), new[] { nameof(appErrLog.Tag) });
            }

            if (!string.IsNullOrWhiteSpace(appErrLog.Tag) && appErrLog.Tag.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Tag", "100"), new[] { nameof(appErrLog.Tag) });
            }

            if (appErrLog.LineNumber < 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "LineNumber", "1"), new[] { nameof(appErrLog.LineNumber) });
            }

            if (string.IsNullOrWhiteSpace(appErrLog.Source))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Source"), new[] { nameof(appErrLog.Source) });
            }

            //Source has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(appErrLog.Message))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Message"), new[] { nameof(appErrLog.Message) });
            }

            //Message has no StringLength Attribute

            if (appErrLog.DateTime_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DateTime_UTC"), new[] { nameof(appErrLog.DateTime_UTC) });
            }
            else
            {
                if (appErrLog.DateTime_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTime_UTC", "1980"), new[] { nameof(appErrLog.DateTime_UTC) });
                }
            }

            if (appErrLog.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(appErrLog.LastUpdateDate_UTC) });
            }
            else
            {
                if (appErrLog.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(appErrLog.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == appErrLog.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == appErrLog.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appErrLog.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", appErrLog.LastUpdateContactTVItemID.ToString()), new[] { nameof(appErrLog.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(appErrLog.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
