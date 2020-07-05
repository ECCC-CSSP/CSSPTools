/*
 * Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
using LoggedInServices.Services;
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
   public interface ILogService
    {
       Task<ActionResult<bool>> Delete(int LogID);
       Task<ActionResult<List<Log>>> GetLogList();
       Task<ActionResult<Log>> GetLogWithLogID(int LogID);
       Task<ActionResult<Log>> Post(Log log);
       Task<ActionResult<Log>> Put(Log log);
    }
    public partial class LogService : ControllerBase, ILogService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LogService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<Log>> GetLogWithLogID(int LogID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                Log log = (from c in dbLocal.Logs.AsNoTracking()
                        where c.LogID == LogID
                        select c).FirstOrDefault();

                if (log == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(log));
            }
            else
            {
                Log log = (from c in db.Logs.AsNoTracking()
                        where c.LogID == LogID
                        select c).FirstOrDefault();

                if (log == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(log));
            }
        }
        public async Task<ActionResult<List<Log>>> GetLogList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                List<Log> logList = (from c in dbLocal.Logs.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(logList));
            }
            else
            {
                List<Log> logList = (from c in db.Logs.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(logList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int LogID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                Log log = (from c in dbLocal.Logs
                                   where c.LogID == LogID
                                   select c).FirstOrDefault();
                
                if (log == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Log", "LogID", LogID.ToString())));
                }

                try
                {
                   dbLocal.Logs.Remove(log);
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
                Log log = (from c in db.Logs
                                   where c.LogID == LogID
                                   select c).FirstOrDefault();
                
                if (log == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Log", "LogID", LogID.ToString())));
                }

                try
                {
                   db.Logs.Remove(log);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<Log>> Post(Log log)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(log), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
                try
                {
                   dbLocal.Logs.Add(log);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(log));
            }
            else
            {
                try
                {
                   db.Logs.Add(log);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(log));
            }
        }
        public async Task<ActionResult<Log>> Put(Log log)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(log), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
            try
            {
               dbLocal.Logs.Update(log);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(log));
            }
            else
            {
            try
            {
               db.Logs.Update(log);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(log));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Log log = validationContext.ObjectInstance as Log;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (log.LogID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LogID"), new[] { "LogID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.Logs select c).Where(c => c.LogID == log.LogID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Log", "LogID", log.LogID.ToString()), new[] { "LogID" });
                    }
                }
                else
                {
                    if (!(from c in db.Logs select c).Where(c => c.LogID == log.LogID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Log", "LogID", log.LogID.ToString()), new[] { "LogID" });
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(log.TableName))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TableName"), new[] { "TableName" });
            }

            if (!string.IsNullOrWhiteSpace(log.TableName) && log.TableName.Length > 50)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "TableName", "50"), new[] { "TableName" });
            }

            if (log.ID < 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MinValueIs_, "ID", "1"), new[] { "ID" });
            }

            retStr = enums.EnumTypeOK(typeof(LogCommandEnum), (int?)log.LogCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LogCommand"), new[] { "LogCommand" });
            }

            if (string.IsNullOrWhiteSpace(log.Information))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "Information"), new[] { "Information" });
            }

            //Information has no StringLength Attribute

            if (log.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (log.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == log.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == log.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == log.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", log.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
